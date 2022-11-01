using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Sims3.Collections;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000008 RID: 8
	public class IntermediatePersister
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x00004220 File Offset: 0x00003220
		public IntermediatePersister(string prototypesDir, string instancesDir)
		{
			if (string.IsNullOrEmpty(prototypesDir))
			{
				throw new Exception(string.Format("Intermediate prototypes directory '{0}' invalid", prototypesDir));
			}
			if (string.IsNullOrEmpty(instancesDir))
			{
				throw new Exception(string.Format("Intermediate instances directory'{0}' invalid", prototypesDir));
			}
			this.mPrototypesDir = Path.Combine(Application.StartupPath, prototypesDir);
			this.mInstancesDir = Path.Combine(Application.StartupPath, instancesDir);
			this.CreateDirectory(this.mPrototypesDir);
			this.CreateDirectory(this.mInstancesDir);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000042C0 File Offset: 0x000032C0
		public IntermediatePersister(string prototypesDir, string instancesDir, string branch) : this(prototypesDir, instancesDir)
		{
			this.mBranch = branch;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000AA RID: 170 RVA: 0x000042D1 File Offset: 0x000032D1
		public string InstancesDir
		{
			get
			{
				if (Path.IsPathRooted(this.mInstancesDir))
				{
					return this.mInstancesDir;
				}
				return Path.Combine(Application.StartupPath, this.mInstancesDir);
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000042F8 File Offset: 0x000032F8
		public void SaveInstances(SerializableDictionary<ItemKey, PersistedObject> objects)
		{
			if (!Directory.Exists(this.mInstancesDir))
			{
				this.CreateDirectory(this.mInstancesDir);
			}
			string filename = this.GetFilename(this.mInstancesDir, IntermediatePersister.kInstanceFile);
			try
			{
				FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerializableDictionary<ItemKey, PersistedObject>));
				xmlSerializer.Serialize(fileStream, objects);
				fileStream.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format("Cannot save intermediate instances to file '{0}'. {1}", filename, ex.Message));
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00004384 File Offset: 0x00003384
		public void SavePrototypes(SerializableDictionary<ItemKey, PersistedPrototype> prototypes)
		{
			if (!Directory.Exists(this.mPrototypesDir))
			{
				this.CreateDirectory(this.mPrototypesDir);
			}
			string filename = this.GetFilename(this.mPrototypesDir, IntermediatePersister.kPrototypeFile);
			try
			{
				FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerializableDictionary<ItemKey, PersistedPrototype>));
				xmlSerializer.Serialize(fileStream, prototypes);
				fileStream.Close();
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format("Cannot save intermediate instances to file '{0}'. {1}", filename, ex.Message));
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00004410 File Offset: 0x00003410
		public SerializableDictionary<ItemKey, PersistedObject> LoadInstances()
		{
			SerializableDictionary<ItemKey, PersistedObject> serializableDictionary = new SerializableDictionary<ItemKey, PersistedObject>();
			string filename = this.GetFilename(this.mInstancesDir, IntermediatePersister.kInstanceFile);
			if (File.Exists(filename))
			{
				FileStream fileStream = new FileStream(filename, FileMode.Open);
				if (fileStream.Length > 0L)
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerializableDictionary<ItemKey, PersistedObject>));
					serializableDictionary = (SerializableDictionary<ItemKey, PersistedObject>)xmlSerializer.Deserialize(fileStream);
				}
				fileStream.Close();
				foreach (ItemKey itemKey in serializableDictionary.Keys)
				{
					itemKey.KeyType = ItemType.INSTANCE;
				}
			}
			return serializableDictionary;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000044BC File Offset: 0x000034BC
		public SerializableDictionary<ItemKey, PersistedPrototype> LoadPrototypes()
		{
			SerializableDictionary<ItemKey, PersistedPrototype> serializableDictionary = new SerializableDictionary<ItemKey, PersistedPrototype>();
			string filename = this.GetFilename(this.mPrototypesDir, IntermediatePersister.kPrototypeFile);
			if (File.Exists(filename))
			{
				FileStream fileStream = new FileStream(filename, FileMode.Open);
				if (fileStream.Length > 0L)
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerializableDictionary<ItemKey, PersistedPrototype>));
					serializableDictionary = (SerializableDictionary<ItemKey, PersistedPrototype>)xmlSerializer.Deserialize(fileStream);
				}
				fileStream.Close();
				foreach (ItemKey itemKey in serializableDictionary.Keys)
				{
					itemKey.KeyType = ItemType.PROTOTYPE;
				}
			}
			return serializableDictionary;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00004568 File Offset: 0x00003568
		private string GetFilename(string directory, string filebase)
		{
			string path;
			if (string.IsNullOrEmpty(this.mBranch))
			{
				path = string.Format("{0}.{1}", filebase, IntermediatePersister.kExtension);
			}
			else
			{
				path = string.Format("{0}_{1}.{2}", filebase, this.mBranch, IntermediatePersister.kExtension);
			}
			string result;
			if (Path.IsPathRooted(directory))
			{
				result = Path.Combine(directory, path);
			}
			else
			{
				string path2 = Path.Combine(Application.StartupPath, directory);
				result = Path.Combine(path2, path);
			}
			return result;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000045E0 File Offset: 0x000035E0
		private void CreateDirectory(string dirName)
		{
			try
			{
				string fullPath = Path.GetFullPath(dirName);
				DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);
				if (!directoryInfo.Exists)
				{
					directoryInfo.Create();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		// Token: 0x0400001B RID: 27
		private static readonly string kExtension = "xml";

		// Token: 0x0400001C RID: 28
		private static readonly string kInstanceFile = "OpenInstances";

		// Token: 0x0400001D RID: 29
		private static readonly string kPrototypeFile = "ReferencedPrototypes";

		// Token: 0x0400001E RID: 30
		private string mPrototypesDir = string.Empty;

		// Token: 0x0400001F RID: 31
		private string mInstancesDir = string.Empty;

		// Token: 0x04000020 RID: 32
		private string mBranch = string.Empty;
	}
}
