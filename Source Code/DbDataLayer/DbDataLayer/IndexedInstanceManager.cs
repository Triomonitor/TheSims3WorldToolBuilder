using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Sims3.Collections;
using Sims3.RevisionControl;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200007C RID: 124
	public class IndexedInstanceManager : InstanceManager
	{
		// Token: 0x06000406 RID: 1030 RVA: 0x0000C1BC File Offset: 0x0000B1BC
		public IndexedInstanceManager(List<string> instanceDirs, string intermediateDir, RCS rcs) : base(instanceDirs, intermediateDir, rcs)
		{
			this.mWorker = new BackgroundWorker();
			this.mWorker.WorkerReportsProgress = false;
			this.mWorker.WorkerSupportsCancellation = false;
			this.mWorker.DoWork += this.Worker_DoWork;
			this.mWorker.RunWorkerCompleted += this.Worker_RunWorkerCompleted;
			this.mWorker.RunWorkerAsync();
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000C244 File Offset: 0x0000B244
		protected override void ReadInstances(string dir)
		{
			this.mDirectories.Add(dir);
			DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(dir));
			string name = directoryInfo.Name;
			string text = Path.Combine(this.mIntermediateDir, name + ".idxxml");
			if (!File.Exists(text))
			{
				string directoryRoot = Directory.GetDirectoryRoot(dir);
				text = Path.Combine(directoryRoot, name + ".idxxml");
				try
				{
					if (this.mRCS != null && this.mRCS.Connected)
					{
						this.mRCS.SyncToHead(text);
					}
				}
				catch (Exception)
				{
				}
			}
			SKU key = SKU.BaseGame;
			bool flag = false;
			foreach (SKU sku in SKUManager.GetAllValidSKUs())
			{
				if (string.Compare(dir, SKUManager.GetSKUInstanceDirectory(sku), true) == 0)
				{
					flag = true;
					key = sku;
					break;
				}
			}
			if (flag)
			{
				if (File.Exists(text))
				{
					try
					{
						XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<IndexInstance>));
						using (StreamReader streamReader = new StreamReader(text))
						{
							XmlReader xmlReader = XmlReader.Create(streamReader);
							List<IndexInstance> list = xmlSerializer.Deserialize(xmlReader) as List<IndexInstance>;
							SerializableDictionary<long, IndexInstance> serializableDictionary = new SerializableDictionary<long, IndexInstance>();
							foreach (IndexInstance indexInstance in list)
							{
								serializableDictionary[indexInstance.InstanceKey.Id] = indexInstance;
							}
							if (serializableDictionary != null)
							{
								DateTime now = DateTime.Now;
								string[] files = Directory.GetFiles(dir, "*." + InstanceManager.kExtension, SearchOption.AllDirectories);
								Dictionary<string, string> dictionary = new Dictionary<string, string>();
								foreach (string path in files)
								{
									string text2 = Path.GetFileNameWithoutExtension(path).ToLower();
									dictionary.Add(text2, text2);
								}
								List<string> list2 = new List<string>();
								foreach (string text3 in files)
								{
									long idByFilename = IndexedInstanceManager.GetIdByFilename(text3);
									if (!serializableDictionary.ContainsKey(idByFilename))
									{
										list2.Add(text3);
									}
								}
								foreach (string file in list2)
								{
									this.LoadInstance(file);
								}
								List<IndexInstance> list3 = new List<IndexInstance>();
								foreach (IndexInstance indexInstance2 in serializableDictionary.Values)
								{
									string key2 = Path.GetFileNameWithoutExtension(base.GetFilenameById(indexInstance2.InstanceKey.Id)).ToLower();
									if (!dictionary.ContainsKey(key2))
									{
										list3.Add(indexInstance2);
									}
								}
								foreach (IndexInstance indexInstance3 in list3)
								{
									serializableDictionary.Remove(indexInstance3.InstanceKey.Id);
								}
								list2.Clear();
								foreach (string text4 in files)
								{
									FileInfo fileInfo = new FileInfo(text4);
									long idByFilename2 = IndexedInstanceManager.GetIdByFilename(text4);
									IndexInstance indexInstance4;
									if (serializableDictionary.TryGetValue(idByFilename2, out indexInstance4) && fileInfo.LastWriteTime > indexInstance4.TimeStamp)
									{
										list2.Add(text4);
									}
								}
								foreach (string file2 in list2)
								{
									this.LoadInstance(file2);
								}
								base.PrintInterval("Index Fixup", now);
								this.mIndices[key] = serializableDictionary;
								foreach (IndexInstance indexInstance5 in serializableDictionary.Values)
								{
									this.mIdToItemKey[indexInstance5.InstanceKey.Id] = indexInstance5.InstanceKey;
									if (!this.mPrototypeIdToInstanceIds.ContainsKey(indexInstance5.PrototypeId))
									{
										this.mPrototypeIdToInstanceIds.Add(indexInstance5.PrototypeId, new List<long>());
									}
									if (!this.mPrototypeIdToInstanceIds[indexInstance5.PrototypeId].Contains(indexInstance5.InstanceKey.Id))
									{
										this.mPrototypeIdToInstanceIds[indexInstance5.PrototypeId].Add(indexInstance5.InstanceKey.Id);
									}
									this.mInstanceIdToPrototypeId[indexInstance5.InstanceKey.Id] = indexInstance5.PrototypeId;
								}
							}
						}
						return;
					}
					catch (InvalidOperationException)
					{
						base.ReadInstances(dir);
						this.SaveIndexFiles();
						return;
					}
				}
				base.ReadInstances(dir);
				this.SaveIndexFiles();
			}
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000C7F0 File Offset: 0x0000B7F0
		private static long GetIdByFilename(string filename)
		{
			string s = Path.GetFileNameWithoutExtension(filename).Substring(2);
			return long.Parse(s, NumberStyles.AllowHexSpecifier);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000C818 File Offset: 0x0000B818
		private bool FilesMatch(long instanceId, string filename)
		{
			string filenameById = base.GetFilenameById(instanceId);
			return string.Compare(Path.GetFileNameWithoutExtension(filename), Path.GetFileNameWithoutExtension(filenameById), true) == 0;
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000C844 File Offset: 0x0000B844
		protected override void PopulateDictionaries(Instance instance)
		{
			this.mIdToInstance[instance.ItemKey.Id] = instance;
			this.mIdToItemKey[instance.ItemKey.Id] = instance.ItemKey;
			this.mInstanceIdToPrototypeId[instance.ItemKey.Id] = instance.PrototypeId;
			if (!this.mPrototypeIdToInstanceIds.ContainsKey(instance.PrototypeId))
			{
				this.mPrototypeIdToInstanceIds.Add(instance.PrototypeId, new List<long>());
			}
			if (!this.mPrototypeIdToInstanceIds[instance.PrototypeId].Contains(instance.ItemKey.Id))
			{
				this.mPrototypeIdToInstanceIds[instance.PrototypeId].Add(instance.ItemKey.Id);
			}
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000C90D File Offset: 0x0000B90D
		public override string GetXmlDataFromInstanceId(long id, string filename)
		{
			if (!this.mIdToInstance.ContainsKey(id))
			{
				this.LoadInstance(filename);
			}
			return base.GetXmlDataFromInstanceId(id, filename);
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0000C92D File Offset: 0x0000B92D
		public override List<ItemKey> GetInstanceKeysByReference(ItemKey instanceKey)
		{
			while (!this.mWorkerCompleted && this.mWorker.IsBusy)
			{
			}
			return base.GetInstanceKeysByReference(instanceKey);
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0000C94B File Offset: 0x0000B94B
		public override ItemKey[] GetAllInstanceKeys()
		{
			while (!this.mWorkerCompleted && this.mWorker.IsBusy)
			{
			}
			return base.GetAllInstanceKeys();
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0000C968 File Offset: 0x0000B968
		public override void AddInstance(ItemKey instanceKey, ItemKey prototypeKey, string instanceXml)
		{
			base.AddInstance(instanceKey, prototypeKey, instanceXml);
			SKU skuFromGroupId = SKUManager.GetSkuFromGroupId((uint)instanceKey.GroupId);
			if (!this.mIndices.ContainsKey(skuFromGroupId))
			{
				this.mIndices[skuFromGroupId] = new SerializableDictionary<long, IndexInstance>();
			}
			this.mIndices[skuFromGroupId][instanceKey.Id] = new IndexInstance(instanceKey, prototypeKey.Id, DateTime.Now);
			this.SaveIndexFiles();
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0000C9D8 File Offset: 0x0000B9D8
		public override void UpdateInstance(ItemKey instanceKey, ItemKey updatedPrototypeKey, ItemKey originalPrototypeKey, string instanceXml, string filename)
		{
			if (!this.mIdToInstance.ContainsKey(instanceKey.Id))
			{
				this.LoadInstance(filename);
			}
			base.UpdateInstance(instanceKey, updatedPrototypeKey, originalPrototypeKey, instanceXml, filename);
			SKU skuFromGroupId = SKUManager.GetSkuFromGroupId((uint)instanceKey.GroupId);
			Dictionary<long, IndexInstance> dictionary = this.mIndices[skuFromGroupId];
			IndexInstance indexInstance;
			if (dictionary.TryGetValue(instanceKey.Id, out indexInstance))
			{
				indexInstance.InstanceKey = instanceKey;
				indexInstance.PrototypeId = updatedPrototypeKey.Id;
				indexInstance.TimeStamp = DateTime.Now;
			}
			this.SaveIndexFiles();
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0000CA5C File Offset: 0x0000BA5C
		public override void DeleteById(long id)
		{
			base.DeleteById(id);
			foreach (Dictionary<long, IndexInstance> dictionary in this.mIndices.Values)
			{
				if (dictionary.ContainsKey(id))
				{
					dictionary.Remove(id);
					break;
				}
			}
			this.SaveIndexFiles();
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x0000CAD0 File Offset: 0x0000BAD0
		protected override Instance LoadInstance(string file)
		{
			Instance result;
			lock (this.mIndices)
			{
				Instance instance = base.LoadInstance(file);
				FileInfo fileInfo = new FileInfo(file);
				SKU skuFromGroupId = SKUManager.GetSkuFromGroupId((uint)instance.ItemKey.GroupId);
				if (!this.mIndices.ContainsKey(skuFromGroupId))
				{
					this.mIndices[skuFromGroupId] = new SerializableDictionary<long, IndexInstance>();
				}
				this.mIndices[skuFromGroupId][instance.ItemKey.Id] = new IndexInstance(instance.ItemKey, instance.PrototypeId, fileInfo.LastWriteTime);
				result = instance;
			}
			return result;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0000CB7C File Offset: 0x0000BB7C
		private void SaveIndexFiles()
		{
			if (!Directory.Exists(this.mIntermediateDir))
			{
				Directory.CreateDirectory(this.mIntermediateDir);
			}
			foreach (KeyValuePair<SKU, SerializableDictionary<long, IndexInstance>> keyValuePair in this.mIndices)
			{
				SKU key = keyValuePair.Key;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(SKUManager.GetSkuAssetsDirectory(key));
					string name = directoryInfo.Name;
					string path = Path.Combine(this.mIntermediateDir, name + ".idxxml");
					FileStream fileStream = File.Open(path, FileMode.Create);
					XmlTextWriter xmlTextWriter = new XmlTextWriter(fileStream, Encoding.UTF8);
					xmlTextWriter.Formatting = Formatting.Indented;
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<IndexInstance>));
					XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
					xmlSerializerNamespaces.Add("", "");
					List<IndexInstance> o = new List<IndexInstance>(keyValuePair.Value.Values);
					xmlSerializer.Serialize(xmlTextWriter, o, xmlSerializerNamespaces);
					xmlTextWriter.Flush();
					fileStream.Close();
				}
				catch (IOException)
				{
				}
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0000CCAC File Offset: 0x0000BCAC
		private void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			foreach (string dir in this.mDirectories)
			{
				base.ReadInstances(dir);
			}
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0000CD00 File Offset: 0x0000BD00
		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.mWorkerCompleted = true;
			this.SaveIndexFiles();
			base.OnInstancesLoaded();
		}

		// Token: 0x04000103 RID: 259
		private const string kIndexExtension = ".idxxml";

		// Token: 0x04000104 RID: 260
		private BackgroundWorker mWorker;

		// Token: 0x04000105 RID: 261
		private bool mWorkerCompleted;

		// Token: 0x04000106 RID: 262
		private Dictionary<SKU, SerializableDictionary<long, IndexInstance>> mIndices = new Dictionary<SKU, SerializableDictionary<long, IndexInstance>>();

		// Token: 0x04000107 RID: 263
		private List<string> mDirectories = new List<string>();
	}
}
