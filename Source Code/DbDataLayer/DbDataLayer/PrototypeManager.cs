using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200007E RID: 126
	internal class PrototypeManager
	{
		// Token: 0x0600041D RID: 1053 RVA: 0x0000CD70 File Offset: 0x0000BD70
		public PrototypeManager(string prototypesFile)
		{
			this.mIdToPrototype.Clear();
			this.mIdToItemKey.Clear();
			this.mClassIdToPrototypeIds.Clear();
			if (!File.Exists(prototypesFile))
			{
				throw new FileNotFoundException(string.Format("Path to directory '{0}' not found", prototypesFile));
			}
			this.mPrototypesFile = prototypesFile;
			this.ReadPrototypesFile();
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0000CDF8 File Offset: 0x0000BDF8
		public ItemKey[] GetAllPrototypeKeys()
		{
			ItemKey[] array = new ItemKey[this.mIdToItemKey.Count];
			this.mIdToItemKey.Values.CopyTo(array, 0);
			return array;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0000CE2C File Offset: 0x0000BE2C
		public long GetClassIdFromPrototypeId(long id)
		{
			if (this.mIdToPrototype.ContainsKey(id))
			{
				Prototype prototype = this.mIdToPrototype[id];
				return prototype.ClassId;
			}
			throw new Exception(string.Format("GetClassIdFromPrototypeKey: Cannot find prototype with id {0}", id));
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x0000CE70 File Offset: 0x0000BE70
		public ItemKey GetPrototypeKeyFromPrototypeId(long id)
		{
			if (this.mIdToItemKey.ContainsKey(id))
			{
				return this.mIdToItemKey[id];
			}
			throw new Exception(string.Format("GetItemKeyFromPrototypeId: Cannot find prototype with id {0}", id));
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000CEA2 File Offset: 0x0000BEA2
		public string GetXmlDataFromPrototypeId(long id)
		{
			if (this.mIdToPrototype.ContainsKey(id))
			{
				return this.mIdToPrototype[id].PrototypeXml.ToString();
			}
			throw new Exception(string.Format("GetXmlDataFromPrototypeId: Cannot find prototype with id {0}", id));
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0000CEE0 File Offset: 0x0000BEE0
		public List<ItemKey> GetPrototypeKeysFromClassId(long classId)
		{
			List<ItemKey> list = new List<ItemKey>();
			if (this.mClassIdToPrototypeIds.ContainsKey(classId))
			{
				List<long> list2 = this.mClassIdToPrototypeIds[classId];
				foreach (long key in list2)
				{
					list.Add(this.mIdToItemKey[key]);
				}
			}
			return list;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0000CF5C File Offset: 0x0000BF5C
		public ItemKey FindItemKey(string name, long groupId, long resourceType)
		{
			foreach (ItemKey itemKey in this.mIdToItemKey.Values)
			{
				if (itemKey.Name.ToLower() == name.ToLower() && itemKey.GroupId == groupId && itemKey.ResourceType == resourceType)
				{
					return itemKey;
				}
			}
			return null;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0000CFE0 File Offset: 0x0000BFE0
		public void AddPrototype(ItemKey prototypeKey, ItemKey classKey, string prototypeXml)
		{
			if (prototypeKey.Id == -1L)
			{
				throw new Exception(string.Format("Prototype has invalid id of '{0}'", prototypeKey.Id));
			}
			if (this.mIdToPrototype.ContainsKey(prototypeKey.Id))
			{
				throw new Exception(string.Format("Prototype with id '{0}' already exists", prototypeKey.Id));
			}
			Prototype value = this.CreatePrototypeInternal(prototypeKey, classKey, prototypeXml);
			this.mIdToPrototype.Add(prototypeKey.Id, value);
			this.mIdToItemKey.Add(prototypeKey.Id, prototypeKey);
			if (!this.mClassIdToPrototypeIds.ContainsKey(classKey.Id))
			{
				this.mClassIdToPrototypeIds.Add(classKey.Id, new List<long>());
			}
			this.mClassIdToPrototypeIds[classKey.Id].Add(prototypeKey.Id);
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0000D0B4 File Offset: 0x0000C0B4
		public void UpdatePrototype(ItemKey prototypeKey, ItemKey classKey, string prototypeXml)
		{
			if (this.mIdToPrototype.ContainsKey(prototypeKey.Id))
			{
				Prototype value = this.CreatePrototypeInternal(prototypeKey, classKey, prototypeXml);
				this.mIdToPrototype[prototypeKey.Id] = value;
				this.mIdToItemKey[prototypeKey.Id] = prototypeKey;
				return;
			}
			throw new Exception(string.Format("UpdatePrototype: Cannot find prototype with id '{0}'", prototypeKey.Id));
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0000D11D File Offset: 0x0000C11D
		public int SavePrototypes()
		{
			this.WritePrototypesFile();
			return 1;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0000D126 File Offset: 0x0000C126
		public long GeneratePrototypeId()
		{
			return IdGenerator.GeneratePrototypeId();
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000D130 File Offset: 0x0000C130
		private void ReadPrototypesFile()
		{
			Prototypes prototypes = null;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Prototypes));
				XmlTextReader xmlReader = new XmlTextReader(this.mPrototypesFile);
				prototypes = (xmlSerializer.Deserialize(xmlReader) as Prototypes);
			}
			catch (Exception)
			{
				throw new Exception(string.Format("Cannot deserialize prototypes file '{0}'", this.mPrototypesFile));
			}
			this.PopulateDictionaries(prototypes);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0000D19C File Offset: 0x0000C19C
		private void WritePrototypesFile()
		{
			try
			{
				Prototypes prototypes = new Prototypes();
				prototypes.PrototypeList = new List<Prototype>(this.mIdToPrototype.Values);
				FileStream fileStream = File.Open(this.mPrototypesFile, FileMode.Truncate);
				if (fileStream == null)
				{
					throw new Exception("WritePrototypesFile: stream is null");
				}
				XmlTextWriter xmlTextWriter = new XmlTextWriter(fileStream, Encoding.UTF8);
				xmlTextWriter.Formatting = Formatting.Indented;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Prototypes));
				XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
				xmlSerializerNamespaces.Add("", "");
				xmlSerializer.Serialize(xmlTextWriter, prototypes, xmlSerializerNamespaces);
				try
				{
					xmlTextWriter.Flush();
					fileStream.Close();
				}
				catch (InvalidOperationException)
				{
					throw new Exception("Exception while trying to save prototypes file '" + this.mPrototypesFile + "'.");
				}
			}
			catch (Exception)
			{
				throw new Exception("Exception while trying to save prototypes file '" + this.mPrototypesFile + "'.");
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0000D290 File Offset: 0x0000C290
		private void PopulateDictionaries(Prototypes prototypes)
		{
			foreach (Prototype prototype in prototypes.PrototypeList)
			{
				try
				{
					this.mIdToPrototype.Add(prototype.ItemKey.Id, prototype);
					this.mIdToItemKey.Add(prototype.ItemKey.Id, prototype.ItemKey);
					if (!this.mClassIdToPrototypeIds.ContainsKey(prototype.ClassId))
					{
						this.mClassIdToPrototypeIds.Add(prototype.ClassId, new List<long>());
					}
					this.mClassIdToPrototypeIds[prototype.ClassId].Add(prototype.ItemKey.Id);
				}
				catch (Exception)
				{
					throw new Exception("Error populating prototype dictionaries");
				}
			}
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0000D37C File Offset: 0x0000C37C
		private Prototype CreatePrototypeInternal(ItemKey prototypeKey, ItemKey classKey, string prototypeXml)
		{
			if (prototypeKey.Id == -1L)
			{
				throw new Exception(string.Format("CreatePrototypeInternal: Prototype '{0}' has an invalid id", prototypeKey.Name));
			}
			if (classKey.Id == -1L)
			{
				throw new Exception(string.Format("CreatePrototypeInternal: Class '{0}' has an invalid id", classKey.Name));
			}
			if (string.IsNullOrEmpty(prototypeXml))
			{
				throw new Exception("CreatePrototypeInternal: Empty instanceXml");
			}
			Prototype prototype = new Prototype();
			prototype.ItemKey = prototypeKey;
			prototype.ClassId = classKey.Id;
			prototype.ClassName = classKey.Name;
			prototype.SetXmlString(prototypeXml);
			return prototype;
		}

		// Token: 0x0400010B RID: 267
		private string mPrototypesFile = string.Empty;

		// Token: 0x0400010C RID: 268
		private Dictionary<long, Prototype> mIdToPrototype = new Dictionary<long, Prototype>();

		// Token: 0x0400010D RID: 269
		private Dictionary<long, ItemKey> mIdToItemKey = new Dictionary<long, ItemKey>();

		// Token: 0x0400010E RID: 270
		private Dictionary<long, List<long>> mClassIdToPrototypeIds = new Dictionary<long, List<long>>();
	}
}
