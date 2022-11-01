using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000088 RID: 136
	internal class ClassManager
	{
		// Token: 0x060004B1 RID: 1201 RVA: 0x0000FF3C File Offset: 0x0000EF3C
		public ClassManager(string classesFile)
		{
			this.mIdToClass.Clear();
			this.mIdToItemKey.Clear();
			if (!File.Exists(classesFile))
			{
				throw new FileNotFoundException(string.Format("Path to directory '{0}' not found", classesFile));
			}
			this.mClassesFile = classesFile;
			this.ReadClasses();
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0000FFAC File Offset: 0x0000EFAC
		public ItemKey[] GetAllClassKeys()
		{
			ItemKey[] array = new ItemKey[this.mIdToItemKey.Count];
			this.mIdToItemKey.Values.CopyTo(array, 0);
			return array;
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0000FFDD File Offset: 0x0000EFDD
		public ItemKey GetClassKeyFromClassId(long classId)
		{
			if (this.mIdToItemKey.ContainsKey(classId))
			{
				return this.mIdToItemKey[classId];
			}
			throw new Exception(string.Format("GetClassKeyFromPrototypeId: Cannot find class with id {0}", classId));
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0001000F File Offset: 0x0000F00F
		public string GetCodeClassNameFromId(long id)
		{
			if (this.mIdToClass.ContainsKey(id))
			{
				return this.mIdToClass[id].ClassName;
			}
			throw new Exception(string.Format("GetCodeClassNameFromId: Cannot find class with id {0}", id));
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x00010046 File Offset: 0x0000F046
		public string GetAssemblyNameFromId(long id)
		{
			if (this.mIdToClass.ContainsKey(id))
			{
				return this.mIdToClass[id].AssemblyName;
			}
			throw new Exception(string.Format("GetAssemblyNameFromId: Cannot find class with id {0}", id));
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00010080 File Offset: 0x0000F080
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

		// Token: 0x060004B7 RID: 1207 RVA: 0x00010104 File Offset: 0x0000F104
		private void ReadClasses()
		{
			Classes classes = null;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Classes));
				XmlTextReader xmlTextReader = new XmlTextReader(this.mClassesFile);
				classes = (xmlSerializer.Deserialize(xmlTextReader) as Classes);
				xmlTextReader.Close();
			}
			catch (Exception)
			{
				throw new Exception(string.Format("Cannot deserialize classes file '{0}'", this.mClassesFile));
			}
			this.PopulateDictionaries(classes);
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00010174 File Offset: 0x0000F174
		private void PopulateDictionaries(Classes classes)
		{
			foreach (ClassInfo classInfo in classes.ClassInfoList)
			{
				try
				{
					this.mIdToClass.Add(classInfo.ItemKey.Id, classInfo);
					this.mIdToItemKey.Add(classInfo.ItemKey.Id, classInfo.ItemKey);
				}
				catch (Exception)
				{
					throw new Exception("Error populating class dictionaries");
				}
			}
		}

		// Token: 0x0400014F RID: 335
		private string mClassesFile = string.Empty;

		// Token: 0x04000150 RID: 336
		private Dictionary<long, ClassInfo> mIdToClass = new Dictionary<long, ClassInfo>();

		// Token: 0x04000151 RID: 337
		private Dictionary<long, ItemKey> mIdToItemKey = new Dictionary<long, ItemKey>();
	}
}
