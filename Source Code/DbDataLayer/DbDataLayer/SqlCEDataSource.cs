using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Sims3.Collections;
using Sims3.DbDataLayer.Sims3WebService;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200000A RID: 10
	public class SqlCEDataSource : IDataSource
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x000046F8 File Offset: 0x000036F8
		public SqlCEDataSource()
		{
			this.DataPath = Application.StartupPath;
			this.mConn = null;
			this.TableNameForType = new Dictionary<ItemType, string>();
			this.TableNameForType.Add(ItemType.CLASS, "classes");
			this.TableNameForType.Add(ItemType.INSTANCE, "instances");
			this.TableNameForType.Add(ItemType.PROTOTYPE, "prototypes");
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00004794 File Offset: 0x00003794
		public void LoadConfig(XmlElement element, string assetRoot)
		{
			try
			{
				foreach (object obj in element.ChildNodes)
				{
					XmlNode xmlNode = (XmlNode)obj;
					string key;
					switch (key = xmlNode.Name.ToLower())
					{
					case "filename":
						this.mFileName = xmlNode.Attributes["name"].Value.ToString();
						break;
					case "datapath":
						this.mDataPath = xmlNode.Attributes["datapath"].Value.ToString();
						break;
					case "url":
						this.mUrl = xmlNode.Attributes["name"].Value.ToString();
						break;
					case "publisher":
						this.mPublisher = xmlNode.Attributes["name"].Value.ToString();
						break;
					case "publishdatabase":
						this.mPublishDatabase = xmlNode.Attributes["name"].Value.ToString();
						break;
					case "publication":
						this.mPublication = xmlNode.Attributes["name"].Value.ToString();
						break;
					case "instancesdir":
						this.mInstancesDir = xmlNode.Attributes["name"].Value.ToString();
						break;
					case "prototypesdir":
						this.mPrototypesDir = xmlNode.Attributes["name"].Value.ToString();
						break;
					}
				}
			}
			catch (NullReferenceException)
			{
				throw new NullReferenceException("FileDataSource configuration problem: At least one of the needed directories is not specified. Please check you medator.config.xml file.");
			}
			this.CreateDirectory(this.mPrototypesDir);
			this.CreateDirectory(this.mInstancesDir);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004A1C File Offset: 0x00003A1C
		private void CreateDirectory(string dirName)
		{
			try
			{
				string text = dirName;
				if (!Path.IsPathRooted(text))
				{
					text = Path.Combine(Application.StartupPath, text);
				}
				DirectoryInfo directoryInfo = new DirectoryInfo(text);
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

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00004A74 File Offset: 0x00003A74
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00004A7C File Offset: 0x00003A7C
		public string DataPath
		{
			get
			{
				return this.mDataPath;
			}
			set
			{
				this.mDataPath = value;
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004A88 File Offset: 0x00003A88
		public bool Sync()
		{
			bool result = false;
			if (this.IsSyncable())
			{
				this.mFullDataPath = this.DataPath + Path.DirectorySeparatorChar + this.mFileName;
				SqlCeReplication sqlCeReplication = new SqlCeReplication(this.mUrl, "", "", this.mPublisher, this.mPublishDatabase, this.mPublication, Environment.MachineName, string.Format("Data Source='{0}'", this.mFullDataPath));
				if (!File.Exists(this.mFullDataPath))
				{
					sqlCeReplication.AddSubscription(1);
				}
				try
				{
					sqlCeReplication.Synchronize();
					result = true;
				}
				catch
				{
				}
			}
			return result;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004B30 File Offset: 0x00003B30
		public bool IsSyncable()
		{
			return this.mPublisher != null && this.mUrl != null && this.mPublishDatabase != null && this.mPublication != null;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00004B58 File Offset: 0x00003B58
		public bool IsOnline()
		{
			return false;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00004B5B File Offset: 0x00003B5B
		public DateTime LastSync()
		{
			return File.GetLastWriteTime(this.mFullDataPath);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004B68 File Offset: 0x00003B68
		public bool Connect(params object[] args)
		{
			this.mFullDataPath = this.DataPath + Path.DirectorySeparatorChar + this.mFileName;
			if (this.IsSyncable())
			{
				this.Sync();
			}
			this.mConn = new SqlCeConnection(string.Format("Data Source='{0}'", this.mFullDataPath));
			this.mConn.Open();
			return this.mConn != null;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004BD7 File Offset: 0x00003BD7
		public void Initialize()
		{
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004BD9 File Offset: 0x00003BD9
		public bool Disconnect()
		{
			this.mConn.Close();
			return true;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00004BE7 File Offset: 0x00003BE7
		public string ConnectionInfo
		{
			get
			{
				return string.Format("Local DB: using {0}", this.mConn.Database);
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004C00 File Offset: 0x00003C00
		public DBItemInfo[] GetDatabaseItemTree()
		{
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			sqlCeCommand.CommandText = "\r\n            SELECT\r\n                i.Name AS InstanceName,\r\n                i.GroupId AS InstanceGroupId,\r\n                i.id AS InstanceId,\r\n                p.Name as PrototypeName,\r\n                p.GroupId as PrototypeGroupId,\r\n                p.id AS PrototypeId,\r\n                c.Name as ClassName,\r\n                c.GroupId as ClassGroupId,\r\n                c.ResourceType AS ResourceType,\r\n                c.id AS ClassId\r\n            FROM classes c \r\n             LEFT OUTER JOIN prototypes p ON p.class_id = c.id\r\n             LEFT OUTER JOIN instances i ON i.prototype_id = p.id\r\n            WHERE (i.Deleted IS  NULL OR i.Deleted = 0) AND (p.Deleted IS  NULL OR p.Deleted = 0) AND (c.Deleted IS  NULL OR c.Deleted = 0)\r\n            ORDER BY ClassName ASC, PrototypeName ASC, InstanceName ASC\r\n            ";
			IDataReader dataReader = sqlCeCommand.ExecuteReader();
			List<DBItemInfo> list = new List<DBItemInfo>();
			DBItemInfo dbitemInfo = null;
			DBItemInfo dbitemInfo2 = null;
			long num = -1L;
			long num2 = -1L;
			Dictionary<DBItemInfo, List<DBItemInfo>> dictionary = new Dictionary<DBItemInfo, List<DBItemInfo>>();
			Dictionary<DBItemInfo, List<DBItemInfo>> dictionary2 = new Dictionary<DBItemInfo, List<DBItemInfo>>();
			while (dataReader.Read())
			{
				long num3 = (long)dataReader["ClassId"];
				long resourceType = (long)dataReader["ResourceType"];
				if (num3 != num)
				{
					if (dbitemInfo != null)
					{
						list.Add(dbitemInfo);
					}
					string name = (string)dataReader["ClassName"];
					long groupId = (long)dataReader["ClassGroupId"];
					dbitemInfo = new DBItemInfo();
					dbitemInfo.thisItem = new ItemKey
					{
						Id = num3,
						Name = name,
						KeyType = ItemType.CLASS,
						GroupId = groupId,
						ResourceType = resourceType
					};
					num = num3;
				}
				object obj = dataReader["PrototypeId"];
				if (obj != DBNull.Value && num2 != (long)obj)
				{
					string name2 = (string)dataReader["PrototypeName"];
					long groupId2 = (long)dataReader["PrototypeGroupId"];
					dbitemInfo2 = new DBItemInfo();
					dbitemInfo2.thisItem = new ItemKey
					{
						Id = (long)obj,
						KeyType = ItemType.PROTOTYPE,
						Name = name2,
						GroupId = groupId2,
						ResourceType = resourceType
					};
					num2 = (long)obj;
					if (!dictionary.ContainsKey(dbitemInfo))
					{
						dictionary.Add(dbitemInfo, new List<DBItemInfo>());
					}
					dictionary[dbitemInfo].Add(dbitemInfo2);
				}
				object obj2 = dataReader["InstanceId"];
				if (obj2 != DBNull.Value)
				{
					DBItemInfo dbitemInfo3 = new DBItemInfo();
					dbitemInfo3.thisItem = new ItemKey
					{
						Name = (string)dataReader["InstanceName"],
						GroupId = (long)dataReader["InstanceGroupId"],
						Id = (long)obj2,
						ResourceType = resourceType,
						KeyType = ItemType.INSTANCE
					};
					if (!dictionary2.ContainsKey(dbitemInfo2))
					{
						dictionary2.Add(dbitemInfo2, new List<DBItemInfo>());
					}
					dictionary2[dbitemInfo2].Add(dbitemInfo3);
				}
			}
			foreach (DBItemInfo dbitemInfo4 in list)
			{
				if (dictionary.ContainsKey(dbitemInfo4))
				{
					dbitemInfo4.childrenItems = dictionary[dbitemInfo4].ToArray();
					foreach (DBItemInfo dbitemInfo5 in dbitemInfo4.childrenItems)
					{
						if (dictionary2.ContainsKey(dbitemInfo5))
						{
							dbitemInfo5.childrenItems = dictionary2[dbitemInfo5].ToArray();
						}
						else
						{
							dbitemInfo5.childrenItems = new DBItemInfo[0];
						}
					}
				}
				else
				{
					dbitemInfo4.childrenItems = new DBItemInfo[0];
				}
			}
			return list.ToArray();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004F2C File Offset: 0x00003F2C
		public DBItemInfo[] GetSKUBasedDatabaseItemTree()
		{
			return this.GetDatabaseItemTree();
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004F34 File Offset: 0x00003F34
		private List<ItemKey> GetItemKeysOfType(ItemType type)
		{
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			sqlCeCommand.CommandText = string.Format("SELECT Name, GroupId, ResourceType, deleted, id FROM {0} WHERE ([Deleted] IS NULL OR [Deleted] = 0) ORDER BY Name", this.TableNameForType[type]);
			IDataReader dataReader = sqlCeCommand.ExecuteReader();
			List<ItemKey> list = new List<ItemKey>();
			while (dataReader.Read())
			{
				ItemKey itemKey = ItemKey.Parse(dataReader);
				itemKey.KeyType = type;
				list.Add(itemKey);
			}
			return list;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004F96 File Offset: 0x00003F96
		public List<ItemKey> GetClassesList()
		{
			return this.GetItemKeysOfType(ItemType.CLASS);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004F9F File Offset: 0x00003F9F
		public List<ItemKey> GetPrototypesList()
		{
			return this.GetItemKeysOfType(ItemType.PROTOTYPE);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004FA8 File Offset: 0x00003FA8
		private List<ItemKey> GetChildrenForKey(ItemKey theKey)
		{
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			sqlCeCommand.Parameters.AddWithValue("@Name", theKey.Name);
			sqlCeCommand.Parameters.AddWithValue("@GroupId", theKey.GroupId);
			if (theKey.ResourceType != -1L)
			{
				sqlCeCommand.Parameters.AddWithValue("@ResourceType", theKey.ResourceType);
				string arg = "  AND ResourceType = @ResourceType";
				ItemType keyType;
				switch (theKey.KeyType)
				{
				case ItemType.CLASS:
					sqlCeCommand.CommandText = string.Format("SELECT Name,GroupId,ResourceType,deleted,id FROM {0}\r\n                            WHERE ClassName = @Name AND\r\n                            ClassGroupId = @GroupId{1} AND ([Deleted] IS NULL OR [Deleted] = 0)\r\n                            ORDER BY Name", this.TableNameForType[ItemType.PROTOTYPE], arg);
					keyType = ItemType.PROTOTYPE;
					break;
				case ItemType.PROTOTYPE:
					sqlCeCommand.CommandText = string.Format("SELECT Name,GroupId,ResourceType,deleted,id  FROM {0}\r\n                            WHERE ([Deleted] IS NULL OR [Deleted] = 0) AND PrototypeName = @Name AND\r\n                            PrototypeGroupId = @GroupId{1} AND ([Deleted] IS NULL OR [Deleted] = 0)\r\n                            ORDER BY Name", this.TableNameForType[ItemType.INSTANCE], arg);
					keyType = ItemType.INSTANCE;
					break;
				default:
					throw new Exception("Children are not possible to find for this ItemKey type.  They've been kidnapped, or were never there, like some bad sci-fi movie.");
				}
				IDataReader dataReader = sqlCeCommand.ExecuteReader();
				List<ItemKey> list = new List<ItemKey>();
				while (dataReader.Read())
				{
					ItemKey itemKey = ItemKey.Parse(dataReader);
					itemKey.KeyType = keyType;
					list.Add(itemKey);
				}
				return list;
			}
			throw new NotSupportedException("The database no longer supports -1 ResourceTypes");
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000050D0 File Offset: 0x000040D0
		public List<ObjectInstance> GetInstancesOfPrototype(ItemKey prototype)
		{
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			sqlCeCommand.Parameters.AddWithValue("@PrototypeName", prototype.Name);
			sqlCeCommand.Parameters.AddWithValue("@PrototypeGroupId", prototype.GroupId);
			if (prototype.ResourceType != -1L)
			{
				sqlCeCommand.Parameters.AddWithValue("@ResourceType", prototype.ResourceType);
				string arg = "  AND i.ResourceType = @ResourceType";
				sqlCeCommand.CommandText = string.Format("\r\n            SELECT\r\n                i.Name AS InstanceName,\r\n                i.GroupId AS InstanceGroupId,\r\n                i.PrototypeName,\r\n                i.PrototypeGroupId,\r\n                i.ResourceType, \r\n                i.CheckoutId as InstanceCheckoutId,\r\n                i.xmldata,\r\n                i.Deleted as InstanceDeleted,\r\n                i.id as InstanceId\r\n            FROM  {0} i\r\n            WHERE i.PrototypeName = @PrototypeName \r\n            AND i.PrototypeGroupId = @PrototypeGroupId{1} AND ([Deleted] IS NULL OR [Deleted] = 0)\r\n            ORDER BY i.Name", this.TableNameForType[ItemType.INSTANCE], arg);
				IDataReader dataReader = sqlCeCommand.ExecuteReader();
				List<ObjectInstance> list = new List<ObjectInstance>();
				while (dataReader.Read())
				{
					ObjectInstance item = ObjectInstance.Parse(dataReader, false, false);
					list.Add(item);
				}
				return list;
			}
			throw new NotSupportedException("The database no longer supports -1 ResourceTypes");
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000051A2 File Offset: 0x000041A2
		public List<ItemKey> GetInstanceKeysOfPrototype(ItemKey key)
		{
			return this.GetChildrenForKey(key);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000051AC File Offset: 0x000041AC
		public List<ItemKey> GetInstanceKeysOfClassKey(ItemKey classKey)
		{
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			if (classKey.ResourceType != -1L)
			{
				sqlCeCommand.CommandText = "SELECT Name, GroupId, ResourceType, Deleted, id\r\n                FROM instances \r\n                WHERE ResourceType = @ResourceType AND ([Deleted] IS NULL OR [Deleted] = 0)\r\n                ORDER BY Name";
				sqlCeCommand.Parameters.AddWithValue("@Resourcetype", classKey.ResourceType);
				IDataReader dataReader = sqlCeCommand.ExecuteReader();
				List<ItemKey> list = new List<ItemKey>();
				while (dataReader.Read())
				{
					ItemKey itemKey = ItemKey.Parse(dataReader);
					itemKey.KeyType = ItemType.INSTANCE;
					list.Add(itemKey);
				}
				return list;
			}
			throw new NotSupportedException("The database no longer supports -1 ResourceTypes");
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00005230 File Offset: 0x00004230
		public List<ObjectInstance> GetInstancesForClassKey(ItemKey classKey)
		{
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			if (classKey.ResourceType == -1L)
			{
				throw new NotSupportedException("The database no longer supports -1 ResourceTypes");
			}
			sqlCeCommand.CommandText = "\r\n                    SELECT\r\n                    i.Name AS InstanceName,\r\n                    i.GroupId AS InstanceGroupId,\r\n                    i.ResourceType,\r\n                    i.PrototypeName,\r\n                    i.PrototypeGroupId, \r\n                    i.CheckoutId as InstanceCheckoutId,\r\n                    i.xmldata,\r\n                    i.Deleted as InstanceDeleted,\r\n                    i.id as InstanceId\r\n                   FROM instances i \r\n                   WHERE ResourceType = @ResourceType  AND ([Deleted] IS NULL OR [Deleted] = 0)\r\n                   ORDER BY i.Name";
			sqlCeCommand.Parameters.AddWithValue("@Resourcetype", classKey.ResourceType);
			IDataReader dataReader = sqlCeCommand.ExecuteReader();
			List<ObjectInstance> list = new List<ObjectInstance>();
			while (dataReader.Read())
			{
				ObjectInstance item = ObjectInstance.Parse(dataReader, true, false);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000052B0 File Offset: 0x000042B0
		public ItemKey GetInstancePrototypeKey(ItemKey instanceKey)
		{
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			if (instanceKey.ResourceType != -1L)
			{
				sqlCeCommand.Parameters.AddWithValue("@ResourceType", instanceKey.ResourceType);
				string arg = "  AND i.ResourceType = @ResourceType";
				sqlCeCommand.CommandText = string.Format("            \r\n            SELECT\r\n                i.PrototypeName,\r\n                i.PrototypeGroupId,\r\n                i.ResourceType,\r\n                p.id as PrototypeId,\r\n                p.Deleted as PrototypeDeleted\r\n               FROM prototypes p INNER JOIN {0} i ON i.prototype_id = p.id \r\n                WHERE i.Name = @Name AND i.GroupId = @GroupId {1}", this.TableNameForType[ItemType.INSTANCE], arg);
				sqlCeCommand.Parameters.AddWithValue("@Name", instanceKey.Name);
				sqlCeCommand.Parameters.AddWithValue("@GroupId", instanceKey.GroupId);
				IDataReader dataReader = sqlCeCommand.ExecuteReader();
				ItemKey itemKey = null;
				if (dataReader.Read())
				{
					itemKey = new ItemKey((string)dataReader["PrototypeName"], (long)dataReader["PrototypeGroupId"], (long)dataReader["ResourceType"], ItemType.PROTOTYPE);
					itemKey.Deleted = (dataReader["PrototypeDeleted"] != DBNull.Value && (bool)dataReader["PrototypeDeleted"]);
					itemKey.Id = (long)dataReader["PrototypeId"];
				}
				return itemKey;
			}
			throw new NotSupportedException("The database no longer supports -1 ResourceTypes");
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000053E2 File Offset: 0x000043E2
		public List<ItemKey> GetPrototypeKeysOfClass(ItemKey classKey)
		{
			return this.GetChildrenForKey(classKey);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000053EC File Offset: 0x000043EC
		public string GetXmlData(ItemKey item)
		{
			if (item.ResourceType == -1L)
			{
				throw new NotSupportedException("The database no longer supports -1 ResourceTypes");
			}
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			sqlCeCommand.CommandText = string.Format("            \r\n            SELECT\r\n                p.xmldata\r\n                FROM {0} p WHERE \r\n                p.Name = @Name AND p.GroupId = @GroupId AND\r\n                p.ResourceType = @ResourceType AND ([Deleted] IS NULL OR [Deleted] = 0)", this.TableNameForType[item.KeyType]);
			sqlCeCommand.Parameters.AddWithValue("@Name", item.Name);
			sqlCeCommand.Parameters.AddWithValue("@GroupId", item.GroupId);
			sqlCeCommand.Parameters.AddWithValue("@Resourcetype", item.ResourceType);
			object obj = sqlCeCommand.ExecuteScalar();
			if (obj != null)
			{
				return (string)obj;
			}
			return null;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000549C File Offset: 0x0000449C
		public string GetPrototypeData(ItemKey item)
		{
			return this.GetXmlData(item);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000054A5 File Offset: 0x000044A5
		public string GetInstanceData(ItemKey item)
		{
			return this.GetXmlData(item);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000054B0 File Offset: 0x000044B0
		public ObjectClass GetObjectClassByPrototype(ItemKey prototypeKey)
		{
			if (prototypeKey.ResourceType == -1L)
			{
				throw new NotSupportedException("The database no longer supports -1 ResourceTypes");
			}
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			sqlCeCommand.CommandText = "            \r\n            SELECT c.Name AS ClassName,\r\n                c.GroupId AS ClassGroupId,\r\n                c.[Assembly] AS ClassAssemblyName,\r\n                c.Class AS ClassDef,\r\n                c.ResourceType AS ResourceType,\r\n                c.Deleted as ClassDeleted,\r\n                c.id as ClassId\r\n               FROM classes c \r\n               WHERE c.ResourceType = @ResourceType";
			sqlCeCommand.Parameters.AddWithValue("@Resourcetype", prototypeKey.ResourceType);
			IDataReader dataReader = sqlCeCommand.ExecuteReader();
			ObjectClass result = null;
			if (dataReader.Read())
			{
				result = ObjectClass.Parse(dataReader);
			}
			return result;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00005520 File Offset: 0x00004520
		public string GetClassNameByPrototype(ItemKey key)
		{
			if (key.ResourceType == -1L)
			{
				throw new NotSupportedException("The database no longer supports -1 ResourceTypes");
			}
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			sqlCeCommand.CommandText = string.Format("            \r\n            SELECT\r\n                c.Class\r\n                FROM {0} c WHERE\r\n                c.ResourceType = @ResourceType", this.TableNameForType[ItemType.CLASS]);
			sqlCeCommand.Parameters.AddWithValue("@Resourcetype", key.ResourceType);
			object obj = sqlCeCommand.ExecuteScalar();
			string result = "";
			if (obj != null)
			{
				result = (string)obj;
			}
			return result;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000055A0 File Offset: 0x000045A0
		public long GetClassResourceTypeFromPrototype(ItemKey key)
		{
			long resourceType = key.ResourceType;
			if (resourceType == -1L)
			{
				throw new Exception("Unexpected resource type for key " + key.ToString());
			}
			return key.ResourceType;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000055D8 File Offset: 0x000045D8
		public ObjectClass GetObjectClass(ItemKey classKey)
		{
			if (classKey.ResourceType == -1L)
			{
				throw new NotSupportedException("The database no longer supports -1 ResourceTypes");
			}
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			sqlCeCommand.CommandText = string.Format("            \r\n            SELECT c.Name AS ClassName,\r\n                c.GroupId AS ClassGroupId,\r\n                c.[Assembly] AS ClassAssemblyName,\r\n                c.Class AS ClassDef,\r\n                c.ResourceType AS ResourceType,\r\n                c.id AS ClassId,\r\n                c.Deleted as ClassDeleted\r\n               FROM {0} c \r\n               WHERE c.Name = @Name AND\r\n                    c.GroupId = @GroupID AND\r\n                    c.ResourceType = @ResourceType  AND ([Deleted] IS NULL OR [Deleted] = 0)", this.TableNameForType[classKey.KeyType]);
			sqlCeCommand.Parameters.AddWithValue("@Name", classKey.Name);
			sqlCeCommand.Parameters.AddWithValue("@Groupid", classKey.GroupId);
			sqlCeCommand.Parameters.AddWithValue("@Resourcetype", classKey.ResourceType);
			IDataReader dataReader = sqlCeCommand.ExecuteReader();
			ObjectClass result = null;
			if (dataReader.Read())
			{
				result = ObjectClass.Parse(dataReader);
			}
			return result;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00005690 File Offset: 0x00004690
		public ObjectInstance GetInstance(ItemKey instanceKey)
		{
			if (instanceKey.ResourceType == -1L)
			{
				throw new NotSupportedException("The database no longer supports -1 ResourceTypes");
			}
			SqlCeCommand sqlCeCommand = this.mConn.CreateCommand();
			sqlCeCommand.CommandText = string.Format("\r\n                SELECT\r\n                i.Name AS InstanceName,\r\n                i.GroupId AS InstanceGroupId,\r\n                i.ResourceType,\r\n                i.PrototypeName,\r\n                i.PrototypeGroupId, \r\n                i.CheckoutId as InstanceCheckoutId,\r\n                i.xmldata,\r\n                i.Deleted as InstanceDeleted,\r\n                i.id as InstanceId\r\n               FROM {0} i \r\n                WHERE i.Name = @Name AND\r\n                    i.GroupId = @GroupId AND\r\n                    i.ResourceType = @ResourceType  AND ([Deleted] IS NULL OR [Deleted] = 0)", this.TableNameForType[instanceKey.KeyType]);
			sqlCeCommand.Parameters.AddWithValue("@Name", instanceKey.Name);
			sqlCeCommand.Parameters.AddWithValue("@Groupid", instanceKey.GroupId);
			sqlCeCommand.Parameters.AddWithValue("@Resourcetype", instanceKey.ResourceType);
			IDataReader dataReader = sqlCeCommand.ExecuteReader();
			ObjectInstance result = null;
			if (dataReader.Read())
			{
				result = ObjectInstance.Parse(dataReader, true, false);
			}
			return result;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00005749 File Offset: 0x00004749
		public string GetAllInstancesXml()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00005750 File Offset: 0x00004750
		public List<ObjectInstance> GetAllInstances()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00005757 File Offset: 0x00004757
		public List<ObjectInstance> GetAllInstancesByDate(DateTime dateTime)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000575E File Offset: 0x0000475E
		public IList<ObjectPrototype> GetAllPrototypes()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00005765 File Offset: 0x00004765
		public List<ItemKey> GetInstancesByReference(ItemKey instanceKey)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000576C File Offset: 0x0000476C
		public bool DoesItemKeyExist(string name, long groupId, long resourceType, ItemType itemType)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00005773 File Offset: 0x00004773
		public ItemKey FindItemKey(string name, long groupId, long resourceType, ItemType itemType)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000577A File Offset: 0x0000477A
		public string GetInstanceFilePath(ItemKey instanceKey)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00005781 File Offset: 0x00004781
		public Guid CheckOutInstance(ItemKey item)
		{
			return Guid.Empty;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00005788 File Offset: 0x00004788
		public Guid CheckOutPrototype(ItemKey item)
		{
			return Guid.Empty;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000578F File Offset: 0x0000478F
		public void CheckInInstance(ItemKey item)
		{
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00005791 File Offset: 0x00004791
		public ItemKey[][] ListCheckedOutChildrenForKey(ItemKey key)
		{
			return new ItemKey[0][];
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00005799 File Offset: 0x00004799
		public Guid[] CheckoutsForCurrentUser()
		{
			return new Guid[0];
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000057A1 File Offset: 0x000047A1
		public void CheckInPrototype(ItemKey item)
		{
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000057A3 File Offset: 0x000047A3
		public bool IsInstanceCheckOut(ItemKey instanceKey)
		{
			return false;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000057A6 File Offset: 0x000047A6
		public string GetInstanceCheckoutUser(ItemKey instanceKey)
		{
			return "";
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000057AD File Offset: 0x000047AD
		public int DeleteInstance(ItemKey theInstance)
		{
			throw new NotImplementedException("Deletion not supported on local DB");
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000057B9 File Offset: 0x000047B9
		public int DeletePrototype(ItemKey theInstance)
		{
			throw new NotImplementedException("Deletion not supported on local DB");
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000057C5 File Offset: 0x000047C5
		public bool RevertInstance(ItemKey instanceKey)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000057CC File Offset: 0x000047CC
		public bool RevertPrototype(ItemKey prototypeKey)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000057D3 File Offset: 0x000047D3
		public int InsertInstance(string name, long groupId, long resourceType, ItemKey prototypeKey, string instanceXml)
		{
			throw new NotImplementedException("Insert new instance not supported on local DB");
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000057DF File Offset: 0x000047DF
		public int UpdateInstance(ItemKey updatedKey, ItemKey originalKey, ItemKey updatedPrototypeKey, ItemKey originalPrototypeKey, string instanceXml)
		{
			throw new NotImplementedException("Update  instance not supported on local DB");
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000057EB File Offset: 0x000047EB
		public int InsertPrototype(string name, long groupId, long resourceType, ItemKey classKey, string prototypeXml)
		{
			throw new NotImplementedException("Insert new instance not supported on local DB");
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000057F7 File Offset: 0x000047F7
		public int UpdatePrototype(ItemKey updatedKey, ItemKey originalKey, ItemKey classKey, string prototypeXml)
		{
			throw new NotImplementedException("Update Prototype not supported on local DB");
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00005803 File Offset: 0x00004803
		public void SaveInstances(SerializableDictionary<ItemKey, PersistedObject> objects)
		{
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00005805 File Offset: 0x00004805
		public void SavePrototypes(SerializableDictionary<ItemKey, PersistedPrototype> prototypes)
		{
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005807 File Offset: 0x00004807
		public SerializableDictionary<ItemKey, PersistedObject> LoadInstances()
		{
			return new SerializableDictionary<ItemKey, PersistedObject>();
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000580E File Offset: 0x0000480E
		public SerializableDictionary<ItemKey, PersistedPrototype> LoadPrototypes()
		{
			return new SerializableDictionary<ItemKey, PersistedPrototype>();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00005815 File Offset: 0x00004815
		public bool IsLocked()
		{
			return false;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00005818 File Offset: 0x00004818
		public string GetLockAdmin()
		{
			return "<none>";
		}

		// Token: 0x04000024 RID: 36
		private string mDataPath = "";

		// Token: 0x04000025 RID: 37
		private string mPrototypesDir = "";

		// Token: 0x04000026 RID: 38
		private string mInstancesDir = "";

		// Token: 0x04000027 RID: 39
		private string mFullDataPath = "";

		// Token: 0x04000028 RID: 40
		private string mFileName = "";

		// Token: 0x04000029 RID: 41
		private string mUrl;

		// Token: 0x0400002A RID: 42
		private string mPublisher;

		// Token: 0x0400002B RID: 43
		private string mPublishDatabase;

		// Token: 0x0400002C RID: 44
		private string mPublication;

		// Token: 0x0400002D RID: 45
		private SqlCeConnection mConn;

		// Token: 0x0400002E RID: 46
		private Dictionary<ItemType, string> TableNameForType;
	}
}
