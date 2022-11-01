using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Sims3.RevisionControl;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000002 RID: 2
	public class InstanceManager
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		// (remove) Token: 0x06000002 RID: 2 RVA: 0x00002069 File Offset: 0x00001069
		public event EventHandler InstancesLoaded;

		// Token: 0x06000003 RID: 3 RVA: 0x00002084 File Offset: 0x00001084
		public InstanceManager(List<string> instanceDirs, string intermediateDir, RCS rcs)
		{
			this.mRCS = rcs;
			this.mIdToInstance.Clear();
			this.mIdToItemKey.Clear();
			this.mPrototypeIdToInstanceIds.Clear();
			this.mInstanceIdToPrototypeId.Clear();
			this.mIntermediateDir = intermediateDir;
			DateTime now = DateTime.Now;
			foreach (string text in instanceDirs)
			{
				if (Directory.Exists(text))
				{
					this.ReadInstances(text);
				}
			}
			this.PrintInterval("Total", now);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002164 File Offset: 0x00001164
		public void SyncInstanceForCheckout(string file)
		{
			this.mRCS.SyncToHead(file);
			this.LoadInstance(file);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000217C File Offset: 0x0000117C
		public virtual ItemKey[] GetAllInstanceKeys()
		{
			ItemKey[] array = new ItemKey[this.mIdToItemKey.Count];
			this.mIdToItemKey.Values.CopyTo(array, 0);
			return array;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021AD File Offset: 0x000011AD
		public virtual string GetXmlDataFromInstanceId(long id, string instanceFile)
		{
			if (this.mIdToInstance.ContainsKey(id))
			{
				return this.mIdToInstance[id].InstanceXml.ToString();
			}
			throw new Exception(string.Format("GetXmlDataFromInstanceId: Cannot find instance with id {0}", id));
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021EC File Offset: 0x000011EC
		public List<ItemKey> GetInstanceKeysFromPrototypeId(long prototypeId)
		{
			List<ItemKey> list = new List<ItemKey>();
			if (prototypeId == -1L)
			{
				throw new Exception(string.Format("GetInstanceKeysFromPrototypeId: Invalid prototype id '{0}'", prototypeId));
			}
			if (this.mPrototypeIdToInstanceIds.ContainsKey(prototypeId))
			{
				List<long> list2 = this.mPrototypeIdToInstanceIds[prototypeId];
				foreach (long key in list2)
				{
					list.Add(this.mIdToItemKey[key]);
				}
			}
			return list;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002284 File Offset: 0x00001284
		public long GetPrototypeIdFromInstanceId(long instanceId)
		{
			if (this.mInstanceIdToPrototypeId.ContainsKey(instanceId))
			{
				return this.mInstanceIdToPrototypeId[instanceId];
			}
			throw new Exception(string.Format("GetPrototypeIdFromInstanceId: Cannot find instance with id {0}", instanceId));
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000022B6 File Offset: 0x000012B6
		public int SaveInstanceToFile(long instanceId, string filePath)
		{
			if (this.mIdToInstance.ContainsKey(instanceId))
			{
				this.WriteInstanceFile(filePath, this.mIdToInstance[instanceId]);
				return 1;
			}
			throw new Exception(string.Format("SaveInstanceToFile: Cannot find instance with id {0}", instanceId));
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000022F0 File Offset: 0x000012F0
		public ItemKey FindItemKey(string name, long groupId, long resourceType)
		{
			string b = name.ToLower().Trim();
			List<ItemKey> list = new List<ItemKey>(this.mIdToItemKey.Values);
			foreach (ItemKey itemKey in list)
			{
				if (itemKey.Name.ToLower().Trim() == b && itemKey.GroupId == groupId && itemKey.ResourceType == resourceType)
				{
					return itemKey;
				}
			}
			return null;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002388 File Offset: 0x00001388
		public bool FindForMigrate(long id)
		{
			return this.mIdToInstance.ContainsKey(id);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002396 File Offset: 0x00001396
		public string GetFilenameById(long id)
		{
			if (id == -1L)
			{
				throw new Exception(string.Format("Cannot generate filename for instance with id {0}", id));
			}
			return string.Format("0x{0:X16}.{1}", id, InstanceManager.kExtension);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000023C8 File Offset: 0x000013C8
		public long GenerateInstanceId()
		{
			return IdGenerator.GenerateInstanceId();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000023D0 File Offset: 0x000013D0
		public virtual List<ItemKey> GetInstanceKeysByReference(ItemKey instanceKey)
		{
			List<ItemKey> list = new List<ItemKey>();
			foreach (Instance instance in this.mIdToInstance.Values)
			{
				ItemKey referenceByReferenceType = this.GetReferenceByReferenceType(instance, instanceKey, "DBReference");
				if (referenceByReferenceType != null)
				{
					list.Add(referenceByReferenceType);
				}
				else
				{
					referenceByReferenceType = this.GetReferenceByReferenceType(instance, instanceKey, "optionalRef");
					if (referenceByReferenceType != null)
					{
						list.Add(referenceByReferenceType);
					}
				}
			}
			return list;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000245C File Offset: 0x0000145C
		public virtual void AddInstance(ItemKey instanceKey, ItemKey prototypeKey, string instanceXml)
		{
			if (instanceKey.Id == -1L)
			{
				throw new Exception(string.Format("Instance has invalid id of '{0}'", instanceKey.Id));
			}
			if (this.mIdToInstance.ContainsKey(instanceKey.Id))
			{
				throw new Exception(string.Format("Instance with id '{0}' already exists", instanceKey.Id));
			}
			Instance value = this.CreateInstanceInternal(instanceKey, prototypeKey, instanceXml);
			this.mIdToInstance.Add(instanceKey.Id, value);
			this.mIdToItemKey.Add(instanceKey.Id, instanceKey);
			this.mInstanceIdToPrototypeId.Add(instanceKey.Id, prototypeKey.Id);
			if (!this.mPrototypeIdToInstanceIds.ContainsKey(prototypeKey.Id))
			{
				this.mPrototypeIdToInstanceIds.Add(prototypeKey.Id, new List<long>());
			}
			this.mPrototypeIdToInstanceIds[prototypeKey.Id].Add(instanceKey.Id);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002548 File Offset: 0x00001548
		public virtual void UpdateInstance(ItemKey instanceKey, ItemKey updatedPrototypeKey, ItemKey originalPrototypeKey, string instanceXml, string filename)
		{
			if (this.mIdToInstance.ContainsKey(instanceKey.Id))
			{
				if (updatedPrototypeKey != originalPrototypeKey)
				{
					this.mIdToInstance[instanceKey.Id].PrototypeId = updatedPrototypeKey.Id;
					this.mIdToInstance[instanceKey.Id].PrototypeName = updatedPrototypeKey.Name;
					this.mInstanceIdToPrototypeId[instanceKey.Id] = updatedPrototypeKey.Id;
					if (this.mPrototypeIdToInstanceIds.ContainsKey(originalPrototypeKey.Id))
					{
						if (this.mPrototypeIdToInstanceIds[originalPrototypeKey.Id].Contains(instanceKey.Id))
						{
							this.mPrototypeIdToInstanceIds[originalPrototypeKey.Id].Remove(instanceKey.Id);
						}
						if (!this.mPrototypeIdToInstanceIds.ContainsKey(updatedPrototypeKey.Id))
						{
							this.mPrototypeIdToInstanceIds.Add(updatedPrototypeKey.Id, new List<long>());
						}
						this.mPrototypeIdToInstanceIds[updatedPrototypeKey.Id].Add(instanceKey.Id);
					}
				}
				Instance value = this.CreateInstanceInternal(instanceKey, updatedPrototypeKey, instanceXml);
				this.mIdToInstance[instanceKey.Id] = value;
				this.mIdToItemKey[instanceKey.Id] = instanceKey;
				return;
			}
			throw new Exception(string.Format("UpdateInstance: Cannot find instance with id '{0}'", instanceKey.Id));
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000026A4 File Offset: 0x000016A4
		public virtual void DeleteById(long id)
		{
			if (this.mIdToInstance.ContainsKey(id))
			{
				this.mIdToInstance.Remove(id);
			}
			if (this.mIdToItemKey.ContainsKey(id))
			{
				this.mIdToItemKey.Remove(id);
			}
			if (this.mInstanceIdToPrototypeId.ContainsKey(id))
			{
				long key = this.mInstanceIdToPrototypeId[id];
				if (this.mPrototypeIdToInstanceIds[key] != null && this.mPrototypeIdToInstanceIds[key].Contains(id))
				{
					this.mPrototypeIdToInstanceIds[key].Remove(id);
				}
				this.mInstanceIdToPrototypeId.Remove(id);
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002744 File Offset: 0x00001744
		protected virtual void ReadInstances(string dir)
		{
			DateTime now = DateTime.Now;
			string[] files = Directory.GetFiles(dir, "*." + InstanceManager.kExtension, SearchOption.AllDirectories);
			this.PrintInterval("GetFiles", now);
			now = DateTime.Now;
			foreach (string file in files)
			{
				this.LoadInstance(file);
			}
			this.PrintInterval("Directory " + dir, now);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000027B3 File Offset: 0x000017B3
		protected void PrintInterval(string label, DateTime startTime)
		{
			DateTime.Now - startTime;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000027C4 File Offset: 0x000017C4
		protected virtual Instance LoadInstance(string file)
		{
			Instance instance = null;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Instance));
				StreamReader input = new StreamReader(file);
				XmlReader xmlReader = XmlReader.Create(input);
				instance = (xmlSerializer.Deserialize(xmlReader) as Instance);
				xmlReader.Close();
			}
			catch (Exception)
			{
				throw new Exception(string.Format("Cannot deserialize instance file '{0}'", file));
			}
			this.PopulateDictionaries(instance);
			return instance;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002830 File Offset: 0x00001830
		protected void OnInstancesLoaded()
		{
			if (this.InstancesLoaded != null)
			{
				this.InstancesLoaded(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000284C File Offset: 0x0000184C
		protected virtual void PopulateDictionaries(Instance instance)
		{
			try
			{
				this.mIdToInstance.Add(instance.ItemKey.Id, instance);
				this.mIdToItemKey.Add(instance.ItemKey.Id, instance.ItemKey);
				if (!this.mPrototypeIdToInstanceIds.ContainsKey(instance.PrototypeId))
				{
					this.mPrototypeIdToInstanceIds.Add(instance.PrototypeId, new List<long>());
				}
				this.mPrototypeIdToInstanceIds[instance.PrototypeId].Add(instance.ItemKey.Id);
				this.mInstanceIdToPrototypeId.Add(instance.ItemKey.Id, instance.PrototypeId);
			}
			catch (Exception)
			{
				throw new Exception(string.Format("Error populating instance dictionaries. Item with same Id '{0:X16}' has already been added.", instance.ItemKey.Id));
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002928 File Offset: 0x00001928
		private Instance CreateInstanceInternal(ItemKey instanceKey, ItemKey prototypeKey, string instanceXml)
		{
			if (instanceKey.Id == -1L)
			{
				throw new Exception(string.Format("CreateInstanceInternal: Instance '{0}' has an invalid id", instanceKey.Name));
			}
			if (prototypeKey.Id == -1L)
			{
				throw new Exception(string.Format("CreateInstanceInternal: Prototype '{0}' has an invalid id", prototypeKey.Name));
			}
			if (string.IsNullOrEmpty(instanceXml))
			{
				throw new Exception("CreateInstanceInternal: Empty instanceXml");
			}
			Instance instance = new Instance();
			instance.ItemKey = instanceKey;
			instance.PrototypeId = prototypeKey.Id;
			instance.PrototypeName = prototypeKey.Name;
			instance.SetXmlString(instanceXml);
			return instance;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000029B8 File Offset: 0x000019B8
		private void WriteInstanceFile(string filename, Instance newInstance)
		{
			try
			{
				FileStream fileStream;
				if (!File.Exists(filename))
				{
					fileStream = File.Open(filename, FileMode.CreateNew);
				}
				else
				{
					fileStream = File.Open(filename, FileMode.Truncate);
				}
				if (fileStream == null)
				{
					throw new Exception("WriteInstanceFile: stream is null");
				}
				XmlTextWriter xmlTextWriter = new XmlTextWriter(fileStream, Encoding.UTF8);
				xmlTextWriter.Formatting = Formatting.Indented;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Instance));
				XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
				xmlSerializerNamespaces.Add("", "");
				xmlSerializer.Serialize(xmlTextWriter, newInstance, xmlSerializerNamespaces);
				try
				{
					xmlTextWriter.Flush();
					fileStream.Close();
				}
				catch (InvalidOperationException)
				{
					throw new Exception("Exception while trying to save instance file '" + filename + "'.");
				}
			}
			catch (Exception)
			{
				throw new Exception("Exception while trying to save instance file '" + filename + "'.");
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002A90 File Offset: 0x00001A90
		private ItemKey GetReferenceByReferenceType(Instance instance, ItemKey sourceKey, string referenceType)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(instance.InstanceXml.ToString());
			string xpath = string.Format(".//{0}[translate(instance, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')='{1}']", referenceType, sourceKey.Name);
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes(xpath);
			if (xmlNodeList.Count > 0)
			{
				return instance.ItemKey;
			}
			return null;
		}

		// Token: 0x04000002 RID: 2
		protected static string kExtension = "instxml";

		// Token: 0x04000003 RID: 3
		protected Dictionary<long, Instance> mIdToInstance = new Dictionary<long, Instance>();

		// Token: 0x04000004 RID: 4
		protected Dictionary<long, ItemKey> mIdToItemKey = new Dictionary<long, ItemKey>();

		// Token: 0x04000005 RID: 5
		protected Dictionary<long, List<long>> mPrototypeIdToInstanceIds = new Dictionary<long, List<long>>();

		// Token: 0x04000006 RID: 6
		protected Dictionary<long, long> mInstanceIdToPrototypeId = new Dictionary<long, long>();

		// Token: 0x04000007 RID: 7
		protected string mIntermediateDir = string.Empty;

		// Token: 0x04000008 RID: 8
		protected RCS mRCS;
	}
}
