using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using Sims3.Collections;
using Sims3.DbDataLayer.Sims3WebService;
using Sims3.RevisionControl;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000081 RID: 129
	internal class FileDataSource : IDataSource
	{
		// Token: 0x14000034 RID: 52
		// (add) Token: 0x06000439 RID: 1081 RVA: 0x0000D4A5 File Offset: 0x0000C4A5
		// (remove) Token: 0x0600043A RID: 1082 RVA: 0x0000D4BE File Offset: 0x0000C4BE
		public event EventHandler AsyncInstancesLoaded;

		// Token: 0x0600043B RID: 1083 RVA: 0x0000D4D8 File Offset: 0x0000C4D8
		public FileDataSource()
		{
			SKUManagerHelper.Initialize();
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0000D548 File Offset: 0x0000C548
		public void LoadConfig(XmlElement element, string assetRoot)
		{
			if (string.IsNullOrEmpty(assetRoot))
			{
				throw new Exception("LoadConfig: Asset root not specified");
			}
			if (!Directory.Exists(assetRoot))
			{
				throw new Exception(string.Format("LoadConfig: Asset root '{0}' doesn't exist", assetRoot));
			}
			this.mAssetRoot = assetRoot;
			Utils.FilePath.EnsureTrailingPathSeparator(ref this.mAssetRoot);
			string instancesDir = string.Empty;
			string prototypesDir = string.Empty;
			string branch = string.Empty;
			try
			{
				foreach (object obj in element.ChildNodes)
				{
					XmlNode xmlNode = (XmlNode)obj;
					string a;
					if ((a = xmlNode.Name.ToLower()) != null)
					{
						if (!(a == "instanceidcounter"))
						{
							if (!(a == "classesfile"))
							{
								if (!(a == "prototypesfile"))
								{
									if (!(a == "intermediateinstancesdir"))
									{
										if (!(a == "intermediateprototypesdir"))
										{
											if (a == "branch")
											{
												branch = xmlNode.InnerText;
											}
										}
										else
										{
											prototypesDir = xmlNode.InnerText;
										}
									}
									else
									{
										instancesDir = xmlNode.InnerText;
									}
								}
								else
								{
									this.mPrototypesFile = xmlNode.InnerText;
									if (this.mPrototypesFile.ToLower().Contains("($assetroot)"))
									{
										this.mPrototypesFile = this.mPrototypesFile.ToLower().Replace("($assetroot)", assetRoot);
									}
								}
							}
							else
							{
								this.mClassesFile = xmlNode.InnerText;
								if (this.mClassesFile.ToLower().Contains("($assetroot)"))
								{
									this.mClassesFile = this.mClassesFile.ToLower().Replace("($assetroot)", assetRoot);
								}
							}
						}
						else
						{
							this.mIdCounterFile = xmlNode.InnerText;
							if (this.mIdCounterFile.ToLower().Contains("($assetroot)"))
							{
								this.mIdCounterFile = this.mIdCounterFile.ToLower().Replace("($assetroot)", assetRoot);
							}
						}
					}
				}
			}
			catch (Exception)
			{
				throw new Exception("FileDataSource configuration problem: At least one of the needed directories is not specified. Please check you pipeline.config.xml file.");
			}
			this.mIntermediatePersister = new IntermediatePersister(prototypesDir, instancesDir, branch);
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0000D794 File Offset: 0x0000C794
		public bool Connect(params object[] args)
		{
			if (args.Length == 0)
			{
				this.mRCS = new RCS("DB Instances");
				this.mRCS.Connect();
			}
			else if (args.Length == 1 && args[0] is RCS)
			{
				this.mRCS = (args[0] as RCS);
				if (!this.mRCS.Connected)
				{
				}
			}
			else
			{
				if (args.Length != 3)
				{
					throw new Exception("Incorrect number of arguments passed to Connect function");
				}
				if (!(args[0] is string) || !(args[1] is string) || !(args[2] is string))
				{
					throw new Exception("Expecting strings for server name, clientSpec and userName");
				}
				string serverName = args[0] as string;
				string clientName = args[1] as string;
				string userName = args[2] as string;
				this.mRCS.Connect(serverName, clientName, userName, string.Empty);
			}
			try
			{
				this.ChangelistId = this.mRCS.GetChangeListByDescription("Edit via DB Instances");
				string[] files = new string[]
				{
					this.mClassesFile,
					this.mPrototypesFile
				};
				try
				{
					this.SyncFilesToHead(files);
				}
				catch (Exception)
				{
				}
				IdGenerator.SetRCSProvider(this.mRCS);
				IdGenerator.SetIdCounterFile(this.mIdCounterFile);
			}
			catch (RCSException)
			{
				this.ChangelistId = 0;
			}
			return true;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x0000D8E0 File Offset: 0x0000C8E0
		private void SyncFilesToHead(string[] files)
		{
			if (this.mRCS == null)
			{
				return;
			}
			int num = 250;
			if (files.Length < num && this.mRCS.AreFilesInSync(files))
			{
				return;
			}
			int num2 = 5;
			if (files.Length > num2)
			{
				int num3 = files.Length / 2;
				string[] array = new string[num3];
				string[] array2 = new string[files.Length - num3];
				Array.Copy(files, 0, array, 0, num3);
				Array.Copy(files, num3, array2, 0, files.Length - num3);
				this.SyncFilesToHead(array);
				this.SyncFilesToHead(array2);
				return;
			}
			foreach (string text in files)
			{
				if (!this.mRCS.IsInSync(text))
				{
					this.mRCS.SyncToHead(text);
				}
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0000D9AC File Offset: 0x0000C9AC
		public void Initialize()
		{
			this.mInstanceDirs.Clear();
			this.mClassManager = new ClassManager(this.mClassesFile);
			this.mPrototypeManager = new PrototypeManager(this.mPrototypesFile);
			new List<string>();
			List<SKU> allValidSKUs = SKUManager.GetAllValidSKUs();
			foreach (SKU sku in allValidSKUs)
			{
				string skuinstanceDirectory = SKUManager.GetSKUInstanceDirectory(sku);
				this.mInstanceDirs.Add(skuinstanceDirectory);
				if (Directory.Exists(skuinstanceDirectory))
				{
					string[] files = Directory.GetFiles(skuinstanceDirectory, "*.*", SearchOption.AllDirectories);
					try
					{
						this.SyncFilesToHead(files);
					}
					catch (Exception)
					{
					}
				}
			}
			this.mInstanceManager = new IndexedInstanceManager(this.mInstanceDirs, this.mIntermediatePersister.InstancesDir, this.mRCS);
			this.mInstanceManager.InstancesLoaded += delegate(object o, EventArgs e)
			{
				if (this.AsyncInstancesLoaded != null)
				{
					this.AsyncInstancesLoaded(this, e);
				}
			};
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x0000DAA8 File Offset: 0x0000CAA8
		public bool Disconnect()
		{
			this.mClassManager = null;
			this.mPrototypeManager = null;
			this.mInstanceManager = null;
			return true;
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x0000DAC0 File Offset: 0x0000CAC0
		public string ConnectionInfo
		{
			get
			{
				string text = "File Data Source:";
				if (this.mRCS != null && this.mRCS.Connected)
				{
					text = string.Format("{0} Connected to {1}:{2}", text, this.mRCS.ServerName, this.mRCS.ClientName);
				}
				else
				{
					text = string.Format("{0} Not Connected!", text);
				}
				return text;
			}
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x0000DB19 File Offset: 0x0000CB19
		public bool Sync()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x0000DB20 File Offset: 0x0000CB20
		public bool IsSyncable()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0000DB27 File Offset: 0x0000CB27
		public bool IsOnline()
		{
			return this.mRCS != null && this.mRCS.Connected;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0000DB3E File Offset: 0x0000CB3E
		public DateTime LastSync()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0000DB48 File Offset: 0x0000CB48
		public DBItemInfo[] GetDatabaseItemTree()
		{
			DateTime now = DateTime.Now;
			IDictionary<string, string> filesOpenForEdit = this.mRCS.GetFilesOpenForEdit(SKUManager.GetSKUInstanceDirectory(SKU.BaseGame));
			List<ItemKey> classesList = this.GetClassesList();
			List<DBItemInfo> list = new List<DBItemInfo>();
			foreach (ItemKey itemKey in classesList)
			{
				DBItemInfo dbitemInfo = new DBItemInfo();
				dbitemInfo.thisItem = itemKey;
				List<DBItemInfo> list2 = new List<DBItemInfo>();
				foreach (ItemKey itemKey2 in this.GetPrototypeKeysOfClass(itemKey))
				{
					DBItemInfo dbitemInfo2 = new DBItemInfo();
					dbitemInfo2.thisItem = itemKey2;
					List<DBItemInfo> list3 = new List<DBItemInfo>();
					foreach (ItemKey itemKey3 in this.GetInstanceKeysOfPrototype(itemKey2))
					{
						DBItemInfo dbitemInfo3 = new DBItemInfo();
						dbitemInfo3.thisItem = itemKey3;
						string text = this.GetFilePathFromInstanceKeyPrototypeKey(itemKey3, itemKey2);
						text = this.mRCS.GetPhysicalPath(text);
						if (filesOpenForEdit.ContainsKey(text))
						{
							dbitemInfo3.checkoutUser = FileDataSource.BaseUsername(filesOpenForEdit[text]);
						}
						dbitemInfo3.childrenItems = new DBItemInfo[0];
						list3.Add(dbitemInfo3);
					}
					dbitemInfo2.childrenItems = list3.ToArray();
					list2.Add(dbitemInfo2);
				}
				dbitemInfo.childrenItems = list2.ToArray();
				list.Add(dbitemInfo);
			}
			DateTime now2 = DateTime.Now;
			now2 - now;
			return list.ToArray();
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0000DD34 File Offset: 0x0000CD34
		private static string BaseUsername(string username)
		{
			string result = username;
			int num = username.IndexOf('@');
			if (num > 0)
			{
				result = username.Substring(0, num);
			}
			return result;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0000DD5C File Offset: 0x0000CD5C
		public DBItemInfo[] GetSKUBasedDatabaseItemTree()
		{
			DateTime now = DateTime.Now;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (this.mRCS != null && this.mRCS.Connected)
			{
				foreach (string fileRoot in this.mInstanceDirs)
				{
					IDictionary<string, string> filesOpenForEdit = this.mRCS.GetFilesOpenForEdit(fileRoot);
					foreach (KeyValuePair<string, string> keyValuePair in filesOpenForEdit)
					{
						dictionary.Add(Path.GetFullPath(keyValuePair.Key).ToLower(), keyValuePair.Value);
					}
				}
			}
			ReadOnlyCollection<ItemKey> allSKUItemKeys = SKUManagerHelper.GetAllSKUItemKeys();
			List<DBItemInfo> list = new List<DBItemInfo>();
			foreach (ItemKey thisItem in allSKUItemKeys)
			{
				DBItemInfo dbitemInfo = new DBItemInfo();
				dbitemInfo.thisItem = thisItem;
				List<ItemKey> classesList = this.GetClassesList();
				List<DBItemInfo> list2 = new List<DBItemInfo>();
				foreach (ItemKey itemKey in classesList)
				{
					DBItemInfo dbitemInfo2 = new DBItemInfo();
					dbitemInfo2.thisItem = itemKey;
					List<DBItemInfo> list3 = new List<DBItemInfo>();
					foreach (ItemKey itemKey2 in this.GetPrototypeKeysOfClass(itemKey))
					{
						DBItemInfo dbitemInfo3 = new DBItemInfo();
						dbitemInfo3.thisItem = itemKey2;
						List<DBItemInfo> list4 = new List<DBItemInfo>();
						List<ItemKey> list5 = this.GetInstanceKeysOfPrototype(itemKey2);
						list5 = this.FilterInstances(list5, (uint)dbitemInfo.thisItem.GroupId);
						foreach (ItemKey itemKey3 in list5)
						{
							DBItemInfo dbitemInfo4 = new DBItemInfo();
							dbitemInfo4.thisItem = itemKey3;
							if (this.mRCS != null && this.mRCS.Connected)
							{
								string text = this.GetFilePathFromInstanceKeyPrototypeKey(itemKey3, itemKey2);
								text = Path.GetFullPath(this.mRCS.GetPhysicalPath(text)).ToLower();
								if (dictionary.ContainsKey(text))
								{
									dbitemInfo4.checkoutUser = FileDataSource.BaseUsername(dictionary[text]);
								}
							}
							dbitemInfo4.childrenItems = new DBItemInfo[0];
							list4.Add(dbitemInfo4);
						}
						dbitemInfo3.childrenItems = list4.ToArray();
						list3.Add(dbitemInfo3);
					}
					dbitemInfo2.childrenItems = list3.ToArray();
					list2.Add(dbitemInfo2);
				}
				dbitemInfo.childrenItems = list2.ToArray();
				list.Add(dbitemInfo);
			}
			DateTime now2 = DateTime.Now;
			now2 - now;
			return list.ToArray();
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0000E0D0 File Offset: 0x0000D0D0
		public List<ItemKey> GetClassesList()
		{
			return new List<ItemKey>(this.mClassManager.GetAllClassKeys());
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0000E0E2 File Offset: 0x0000D0E2
		public List<ItemKey> GetPrototypesList()
		{
			return new List<ItemKey>(this.mPrototypeManager.GetAllPrototypeKeys());
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0000E0F4 File Offset: 0x0000D0F4
		public List<ObjectInstance> GetInstancesOfPrototype(ItemKey prototype)
		{
			List<ItemKey> instanceKeysFromPrototypeId = this.mInstanceManager.GetInstanceKeysFromPrototypeId(prototype.Id);
			List<ObjectInstance> list = new List<ObjectInstance>();
			foreach (ItemKey instanceKey in instanceKeysFromPrototypeId)
			{
				list.Add(this.GetInstance(instanceKey));
			}
			return list;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0000E164 File Offset: 0x0000D164
		public List<ItemKey> GetInstanceKeysOfPrototype(ItemKey prototypeKey)
		{
			if (prototypeKey == null)
			{
				return null;
			}
			return this.mInstanceManager.GetInstanceKeysFromPrototypeId(prototypeKey.Id);
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0000E17C File Offset: 0x0000D17C
		public List<ObjectInstance> GetInstancesForClassKey(ItemKey classKey)
		{
			List<ItemKey> prototypeKeysFromClassId = this.mPrototypeManager.GetPrototypeKeysFromClassId(classKey.Id);
			List<ObjectInstance> list = new List<ObjectInstance>();
			foreach (ItemKey prototype in prototypeKeysFromClassId)
			{
				list.AddRange(this.GetInstancesOfPrototype(prototype));
			}
			return list;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0000E1EC File Offset: 0x0000D1EC
		public ItemKey GetInstancePrototypeKey(ItemKey instanceKey)
		{
			long prototypeIdFromInstanceId = this.mInstanceManager.GetPrototypeIdFromInstanceId(instanceKey.Id);
			return this.mPrototypeManager.GetPrototypeKeyFromPrototypeId(prototypeIdFromInstanceId);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0000E217 File Offset: 0x0000D217
		public List<ItemKey> GetPrototypeKeysOfClass(ItemKey classKey)
		{
			return this.mPrototypeManager.GetPrototypeKeysFromClassId(classKey.Id);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x0000E22A File Offset: 0x0000D22A
		public string GetPrototypeData(ItemKey item)
		{
			return this.mPrototypeManager.GetXmlDataFromPrototypeId(item.Id);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0000E240 File Offset: 0x0000D240
		public ObjectClass GetObjectClassByPrototype(ItemKey prototypeKey)
		{
			ItemKey classKeyFromPrototypeId = this.GetClassKeyFromPrototypeId(prototypeKey.Id);
			return new ObjectClass
			{
				AssemblyName = this.mClassManager.GetAssemblyNameFromId(classKeyFromPrototypeId.Id),
				ClassName = this.mClassManager.GetCodeClassNameFromId(classKeyFromPrototypeId.Id),
				ResourceType = classKeyFromPrototypeId.ResourceType
			};
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0000E29C File Offset: 0x0000D29C
		public string GetClassNameByPrototype(ItemKey prototypeKey)
		{
			long classIdFromPrototypeId = this.mPrototypeManager.GetClassIdFromPrototypeId(prototypeKey.Id);
			return this.mClassManager.GetCodeClassNameFromId(classIdFromPrototypeId);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0000E2C8 File Offset: 0x0000D2C8
		public long GetClassResourceTypeFromPrototype(ItemKey prototypeKey)
		{
			ItemKey classKeyFromPrototypeId = this.GetClassKeyFromPrototypeId(prototypeKey.Id);
			return classKeyFromPrototypeId.ResourceType;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0000E2E8 File Offset: 0x0000D2E8
		public ObjectClass GetObjectClass(ItemKey classKey)
		{
			if (classKey.Id == -1L)
			{
				throw new Exception(string.Format("GetObjectClass: Class Key '{0}' has invalid id", classKey.Name));
			}
			return new ObjectClass
			{
				Id = classKey.Id,
				Name = classKey.Name,
				GroupId = classKey.GroupId,
				ResourceType = classKey.ResourceType,
				Deleted = classKey.Deleted,
				AssemblyName = this.mClassManager.GetAssemblyNameFromId(classKey.Id),
				ClassName = this.mClassManager.GetCodeClassNameFromId(classKey.Id),
				KeyType = ItemType.CLASS
			};
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0000E390 File Offset: 0x0000D390
		public ObjectPrototype GetPrototype(ItemKey prototypeKey)
		{
			ObjectPrototype objectPrototype = new ObjectPrototype();
			objectPrototype.Id = prototypeKey.Id;
			objectPrototype.Name = prototypeKey.Name;
			objectPrototype.GroupId = prototypeKey.GroupId;
			objectPrototype.ResourceType = prototypeKey.ResourceType;
			objectPrototype.Deleted = prototypeKey.Deleted;
			objectPrototype.KeyType = ItemType.PROTOTYPE;
			objectPrototype.XmlData = this.mPrototypeManager.GetXmlDataFromPrototypeId(prototypeKey.Id);
			long classIdFromPrototypeId = this.mPrototypeManager.GetClassIdFromPrototypeId((long)((ulong)((uint)prototypeKey.Id)));
			ItemKey classKeyFromClassId = this.mClassManager.GetClassKeyFromClassId(classIdFromPrototypeId);
			objectPrototype.DbClass = this.GetObjectClass(classKeyFromClassId);
			return objectPrototype;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x0000E42C File Offset: 0x0000D42C
		public ObjectInstance GetInstance(ItemKey instanceKey)
		{
			if (instanceKey.Id == -1L)
			{
				throw new Exception(string.Format("GetInstance: Instance Key '{0}' has invalid id", instanceKey.Name));
			}
			string filePathFromInstanceKey = this.GetFilePathFromInstanceKey(instanceKey);
			ObjectInstance objectInstance = new ObjectInstance();
			objectInstance.Id = instanceKey.Id;
			objectInstance.Name = instanceKey.Name;
			objectInstance.GroupId = instanceKey.GroupId;
			objectInstance.ResourceType = instanceKey.ResourceType;
			objectInstance.XmlData = this.mInstanceManager.GetXmlDataFromInstanceId(instanceKey.Id, filePathFromInstanceKey);
			objectInstance.Deleted = instanceKey.Deleted;
			long prototypeIdFromInstanceId = this.mInstanceManager.GetPrototypeIdFromInstanceId((long)((ulong)((uint)instanceKey.Id)));
			ItemKey prototypeKeyFromPrototypeId = this.mPrototypeManager.GetPrototypeKeyFromPrototypeId(prototypeIdFromInstanceId);
			objectInstance.DbPrototype = this.GetPrototype(prototypeKeyFromPrototypeId);
			objectInstance.Deleted = instanceKey.Deleted;
			return objectInstance;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0000E4F8 File Offset: 0x0000D4F8
		public string GetInstanceData(ItemKey itemKey)
		{
			string filePathFromInstanceKey = this.GetFilePathFromInstanceKey(itemKey);
			return this.mInstanceManager.GetXmlDataFromInstanceId(itemKey.Id, filePathFromInstanceKey);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0000E520 File Offset: 0x0000D520
		public List<ObjectInstance> GetAllInstances()
		{
			List<ObjectInstance> list = new List<ObjectInstance>();
			foreach (ItemKey instanceKey in this.mInstanceManager.GetAllInstanceKeys())
			{
				list.Add(this.GetInstance(instanceKey));
			}
			return list;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0000E55F File Offset: 0x0000D55F
		public List<ObjectInstance> GetAllInstancesByDate(DateTime dateTime)
		{
			return this.GetAllInstances();
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x0000E567 File Offset: 0x0000D567
		public List<ItemKey> GetInstancesByReference(ItemKey instanceKey)
		{
			return this.mInstanceManager.GetInstanceKeysByReference(instanceKey);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0000E578 File Offset: 0x0000D578
		public bool DoesItemKeyExist(string name, long groupId, long resourceType, ItemType itemType)
		{
			if (itemType == ItemType.INSTANCE)
			{
				return this.mInstanceManager.FindItemKey(name, groupId, resourceType) != null;
			}
			if (itemType == ItemType.PROTOTYPE)
			{
				return this.mPrototypeManager.FindItemKey(name, groupId, resourceType) != null;
			}
			if (itemType == ItemType.CLASS)
			{
				return this.mClassManager.FindItemKey(name, groupId, resourceType) != null;
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0000E5D8 File Offset: 0x0000D5D8
		public ItemKey FindItemKey(string name, long groupId, long resourceType, ItemType itemType)
		{
			if (itemType == ItemType.INSTANCE)
			{
				return this.mInstanceManager.FindItemKey(name, groupId, resourceType);
			}
			if (itemType == ItemType.PROTOTYPE)
			{
				return this.mPrototypeManager.FindItemKey(name, groupId, resourceType);
			}
			if (itemType == ItemType.CLASS)
			{
				return this.mClassManager.FindItemKey(name, groupId, resourceType);
			}
			throw new NotImplementedException();
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0000E625 File Offset: 0x0000D625
		public string GetInstanceFilePath(ItemKey instanceKey)
		{
			if (instanceKey.KeyType == ItemType.INSTANCE)
			{
				return this.GetFilePathFromInstanceKey(instanceKey);
			}
			return string.Empty;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0000E640 File Offset: 0x0000D640
		public Guid CheckOutInstance(ItemKey instanceKey)
		{
			if (instanceKey.KeyType != ItemType.INSTANCE)
			{
				throw new Exception("CheckOutInstance: Item not of type instance");
			}
			string filePathFromInstanceKey = this.GetFilePathFromInstanceKey(instanceKey);
			try
			{
				this.mInstanceManager.SyncInstanceForCheckout(filePathFromInstanceKey);
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format("Could not sync file '{0}'.\n{1}", filePathFromInstanceKey, ex.Message));
			}
			try
			{
				this.mRCS.OpenForEdit(this.ChangelistId, filePathFromInstanceKey);
			}
			catch (Exception ex2)
			{
				throw new Exception(string.Format("Could not open file '{0}'.\n{1}", filePathFromInstanceKey, ex2.Message));
			}
			return Guid.NewGuid();
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0000E6DC File Offset: 0x0000D6DC
		public void CheckInInstance(ItemKey instanceKey)
		{
			if (instanceKey.KeyType != ItemType.INSTANCE)
			{
				throw new Exception("CheckInInstance: Item not of type instance");
			}
			string filePathFromInstanceKey = this.GetFilePathFromInstanceKey(instanceKey);
			int changeListNumber = this.mRCS.GetChangeListNumber(filePathFromInstanceKey);
			int num = this.mRCS.CreateChangeList("Edit via DB Instances");
			try
			{
				this.mRCS.Reopen(filePathFromInstanceKey, num);
				if (changeListNumber != 0)
				{
					this.mRCS.DeleteEmptyChangeList(changeListNumber);
				}
			}
			catch (Exception ex)
			{
				this.mRCS.DeleteEmptyChangeList(num);
				throw ex;
			}
			this.mRCS.SubmitChangeList(num);
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0000E770 File Offset: 0x0000D770
		public bool IsInstanceCheckOut(ItemKey instanceKey)
		{
			string filePathFromInstanceKey = this.GetFilePathFromInstanceKey(instanceKey);
			return this.mRCS.IsEditByUserHere(filePathFromInstanceKey) || this.mRCS.IsEditByOther(filePathFromInstanceKey);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0000E7A4 File Offset: 0x0000D7A4
		public string GetInstanceCheckoutUser(ItemKey instanceKey)
		{
			if (instanceKey.Id == -1L)
			{
				return string.Empty;
			}
			string filePathFromInstanceKey = this.GetFilePathFromInstanceKey(instanceKey);
			IList<string> usersOpenForEdit = this.mRCS.GetUsersOpenForEdit(filePathFromInstanceKey);
			if (usersOpenForEdit.Count > 0)
			{
				return usersOpenForEdit[0];
			}
			return string.Empty;
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0000E7EC File Offset: 0x0000D7EC
		public ItemKey[][] ListCheckedOutChildrenForKey(ItemKey prototypeKey)
		{
			List<ItemKey> list = new List<ItemKey>();
			List<ItemKey> list2 = new List<ItemKey>();
			List<ItemKey> instanceKeysFromPrototypeId = this.mInstanceManager.GetInstanceKeysFromPrototypeId(prototypeKey.Id);
			foreach (ItemKey itemKey in instanceKeysFromPrototypeId)
			{
				string filePathFromInstanceKeyPrototypeKey = this.GetFilePathFromInstanceKeyPrototypeKey(itemKey, prototypeKey);
				if (this.mRCS.IsEditByUserHere(filePathFromInstanceKeyPrototypeKey))
				{
					list.Add(itemKey);
				}
				if (this.mRCS.IsEditByOther(filePathFromInstanceKeyPrototypeKey))
				{
					list2.Add(itemKey);
				}
			}
			List<List<ItemKey>> list3 = new List<List<ItemKey>>();
			list3.Add(list);
			list3.Add(list2);
			return new ItemKey[][]
			{
				list.ToArray(),
				list2.ToArray()
			};
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x0000E8C0 File Offset: 0x0000D8C0
		// (set) Token: 0x06000464 RID: 1124 RVA: 0x0000E8FC File Offset: 0x0000D8FC
		private int ChangelistId
		{
			get
			{
				this.mChangelistId = this.mRCS.GetChangeListByDescription("Edit via DB Instances");
				if (this.mChangelistId == 0)
				{
					this.mChangelistId = this.mRCS.CreateChangeList("Edit via DB Instances");
				}
				return this.mChangelistId;
			}
			set
			{
				this.mChangelistId = value;
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0000E908 File Offset: 0x0000D908
		public int DeleteInstance(ItemKey instanceKey)
		{
			string filePathFromInstanceKey = this.GetFilePathFromInstanceKey(instanceKey);
			if (!this.mRCS.IsFileUnderAnyClientSpec(filePathFromInstanceKey))
			{
				File.Delete(filePathFromInstanceKey);
				this.mInstanceManager.DeleteById(instanceKey.Id);
				return 1;
			}
			int changeListId = this.mRCS.CreateChangeList(this.kDeletingInstance + instanceKey.Name);
			try
			{
				this.mRCS.OpenForDelete(changeListId, filePathFromInstanceKey);
			}
			catch (Exception ex)
			{
				this.mRCS.DeleteEmptyChangeList(changeListId);
				throw ex;
			}
			try
			{
				this.mRCS.SubmitChangeList(changeListId);
			}
			catch (Exception ex2)
			{
				this.mRCS.RevertChangeList(changeListId);
				throw ex2;
			}
			this.mInstanceManager.DeleteById(instanceKey.Id);
			return 1;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0000E9CC File Offset: 0x0000D9CC
		public bool RevertInstance(ItemKey instanceKey)
		{
			if (instanceKey.Id == -1L)
			{
				return true;
			}
			string filePathFromInstanceKey = this.GetFilePathFromInstanceKey(instanceKey);
			int num = 0;
			try
			{
				num = this.mRCS.GetChangeListNumber(filePathFromInstanceKey);
			}
			catch (Exception)
			{
			}
			this.mRCS.RevertFile(filePathFromInstanceKey);
			if (num != 0)
			{
				this.mRCS.DeleteEmptyChangeList(num);
			}
			return true;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0000EA30 File Offset: 0x0000DA30
		public bool RevertPrototype(ItemKey prototypeKey)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0000EA38 File Offset: 0x0000DA38
		public int InsertInstance(string name, long groupId, long resourceType, ItemKey prototypeKey, string instanceXml)
		{
			ItemKey itemKey = new ItemKey(name, groupId, resourceType, ItemType.INSTANCE);
			long num = this.mInstanceManager.GenerateInstanceId();
			if (num == -1L)
			{
				throw new Exception(string.Format("Cannot generate instance Id and cannot insert instance '{0}'.", name));
			}
			itemKey.Id = num;
			string filePathFromInstanceKeyPrototypeKey = this.GetFilePathFromInstanceKeyPrototypeKey(itemKey, prototypeKey);
			this.mInstanceManager.AddInstance(itemKey, prototypeKey, instanceXml);
			this.mInstanceManager.SaveInstanceToFile(itemKey.Id, filePathFromInstanceKeyPrototypeKey);
			this.mRCS.OpenForAddTextExclusive(this.ChangelistId, filePathFromInstanceKeyPrototypeKey);
			return 1;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0000EAB8 File Offset: 0x0000DAB8
		public int SpecialInsertInstanceForMigrate(ItemKey instanceKey, ItemKey prototypeKey, string instanceXml)
		{
			string filePathFromInstanceKeyPrototypeKey = this.GetFilePathFromInstanceKeyPrototypeKey(instanceKey, prototypeKey);
			if (!this.mInstanceManager.FindForMigrate(instanceKey.Id))
			{
				this.mInstanceManager.AddInstance(instanceKey, prototypeKey, instanceXml);
				this.mInstanceManager.SaveInstanceToFile(instanceKey.Id, filePathFromInstanceKeyPrototypeKey);
				this.mRCS.OpenForAddForMigrate(this.ChangelistId, filePathFromInstanceKeyPrototypeKey);
			}
			return 1;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0000EB18 File Offset: 0x0000DB18
		public int UpdateInstance(ItemKey updatedKey, ItemKey originalKey, ItemKey updatedPrototypeKey, ItemKey originalPrototypeKey, string instanceXml)
		{
			if (updatedKey.Id != originalKey.Id)
			{
				throw new Exception(string.Format("Original id is not the same as updated id. {0} != {1}", originalKey.Id, updatedKey.Id));
			}
			string filePathFromInstanceKeyPrototypeKey = this.GetFilePathFromInstanceKeyPrototypeKey(updatedKey, updatedPrototypeKey);
			if (!updatedPrototypeKey.Equals(originalPrototypeKey))
			{
				string filePathFromInstanceKeyPrototypeKey2 = this.GetFilePathFromInstanceKeyPrototypeKey(originalKey, originalPrototypeKey);
				this.mRCS.RevertFile(filePathFromInstanceKeyPrototypeKey2);
				int changeListId = this.mRCS.CreateChangeList(string.Format("Moving instance '{0}'", updatedKey.Name));
				try
				{
					this.mRCS.OpenForRename(changeListId, filePathFromInstanceKeyPrototypeKey2, filePathFromInstanceKeyPrototypeKey, true);
				}
				catch (Exception ex)
				{
					this.mRCS.DeleteEmptyChangeList(changeListId);
					throw ex;
				}
			}
			this.mInstanceManager.UpdateInstance(updatedKey, updatedPrototypeKey, originalPrototypeKey, instanceXml, filePathFromInstanceKeyPrototypeKey);
			this.mInstanceManager.SaveInstanceToFile(updatedKey.Id, filePathFromInstanceKeyPrototypeKey);
			return 1;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0000EBF4 File Offset: 0x0000DBF4
		public int InsertPrototype(string name, long groupId, long resourceType, ItemKey classKey, string prototypeXml)
		{
			ItemKey itemKey = new ItemKey(name, groupId, resourceType, ItemType.PROTOTYPE);
			itemKey.Id = this.mPrototypeManager.GeneratePrototypeId();
			int changeListId = this.mRCS.CreateChangeList(this.kCreatingPrototype + itemKey.Name);
			this.mRCS.OpenForEdit(changeListId, this.mPrototypesFile);
			this.mPrototypeManager.AddPrototype(itemKey, classKey, prototypeXml);
			this.mPrototypeManager.SavePrototypes();
			return 1;
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0000EC68 File Offset: 0x0000DC68
		public int UpdatePrototype(ItemKey updatedKey, ItemKey originalKey, ItemKey classKey, string prototypeXml)
		{
			if (updatedKey.Id != originalKey.Id)
			{
				throw new Exception(string.Format("Original id is not the same as updated id. {0} != {1}", originalKey.Id, updatedKey.Id));
			}
			this.mPrototypeManager.UpdatePrototype(updatedKey, classKey, prototypeXml);
			int changeListId = this.mRCS.CreateChangeList(this.kUpdatingPrototype + updatedKey.Name);
			this.mRCS.OpenForEdit(changeListId, this.mPrototypesFile);
			this.mPrototypeManager.SavePrototypes();
			this.mRCS.SubmitChangeList(changeListId);
			return 1;
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0000ED01 File Offset: 0x0000DD01
		public void SaveInstances(SerializableDictionary<ItemKey, PersistedObject> objects)
		{
			this.mIntermediatePersister.SaveInstances(objects);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0000ED0F File Offset: 0x0000DD0F
		public void SavePrototypes(SerializableDictionary<ItemKey, PersistedPrototype> prototypes)
		{
			this.mIntermediatePersister.SavePrototypes(prototypes);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0000ED20 File Offset: 0x0000DD20
		public SerializableDictionary<ItemKey, PersistedObject> LoadInstances()
		{
			SerializableDictionary<ItemKey, PersistedObject> serializableDictionary = this.mIntermediatePersister.LoadInstances();
			List<ItemKey> list = new List<ItemKey>();
			foreach (ItemKey itemKey in serializableDictionary.Keys)
			{
				PersistedObject persistedObject = serializableDictionary[itemKey];
				if (!persistedObject.NewInstance)
				{
					string filePathFromInstanceKeyPrototypeKey = this.GetFilePathFromInstanceKeyPrototypeKey(persistedObject.OriginalInstanceKey, persistedObject.OriginalPrototypeKey);
					if (!this.mRCS.IsEditByUserHere(filePathFromInstanceKeyPrototypeKey))
					{
						list.Add(itemKey);
					}
				}
			}
			foreach (ItemKey key in list)
			{
				serializableDictionary.Remove(key);
			}
			return serializableDictionary;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0000EDFC File Offset: 0x0000DDFC
		public SerializableDictionary<ItemKey, PersistedPrototype> LoadPrototypes()
		{
			return this.mIntermediatePersister.LoadPrototypes();
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0000EE09 File Offset: 0x0000DE09
		public bool IsLocked()
		{
			return false;
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0000EE0C File Offset: 0x0000DE0C
		public string GetLockAdmin()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x0000EE13 File Offset: 0x0000DE13
		// (set) Token: 0x06000474 RID: 1140 RVA: 0x0000EE1A File Offset: 0x0000DE1A
		public string DataPath
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0000EE21 File Offset: 0x0000DE21
		public IList<ObjectPrototype> GetAllPrototypes()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0000EE28 File Offset: 0x0000DE28
		public List<ItemKey> GetInstanceKeysOfClassKey(ItemKey classKey)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0000EE2F File Offset: 0x0000DE2F
		public string GetAllInstancesXml()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0000EE36 File Offset: 0x0000DE36
		public Guid[] CheckoutsForCurrentUser()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0000EE3D File Offset: 0x0000DE3D
		public int DeletePrototype(ItemKey theInstance)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0000EE44 File Offset: 0x0000DE44
		public void CheckInPrototype(ItemKey item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0000EE4B File Offset: 0x0000DE4B
		public Guid CheckOutPrototype(ItemKey prototypeKey)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000EE54 File Offset: 0x0000DE54
		private ItemKey GetClassKeyFromPrototypeId(long prototypeId)
		{
			long classIdFromPrototypeId = this.mPrototypeManager.GetClassIdFromPrototypeId(prototypeId);
			return this.mClassManager.GetClassKeyFromClassId(classIdFromPrototypeId);
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0000EE7C File Offset: 0x0000DE7C
		private string GetDirectoryFromPrototypeKeyGroupId(ItemKey prototypeKey, long groupId)
		{
			string folderFromGroupId = this.GetFolderFromGroupId((uint)groupId);
			string text = folderFromGroupId;
			ItemKey classKeyFromPrototypeId = this.GetClassKeyFromPrototypeId(prototypeKey.Id);
			text = Path.Combine(text, classKeyFromPrototypeId.Name);
			text = Path.Combine(text, prototypeKey.Name);
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0000EECC File Offset: 0x0000DECC
		private string GetFolderFromGroupId(uint groupId)
		{
			SKU skuFromGroupId = SKUManager.GetSkuFromGroupId(groupId);
			return SKUManager.GetSKUInstanceDirectory(skuFromGroupId);
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0000EEE8 File Offset: 0x0000DEE8
		private string GetFilePathFromInstanceKey(ItemKey instanceKey)
		{
			long prototypeIdFromInstanceId = this.mInstanceManager.GetPrototypeIdFromInstanceId(instanceKey.Id);
			ItemKey prototypeKeyFromPrototypeId = this.mPrototypeManager.GetPrototypeKeyFromPrototypeId(prototypeIdFromInstanceId);
			return this.GetFilePathFromInstanceKeyPrototypeKey(instanceKey, prototypeKeyFromPrototypeId);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0000EF1C File Offset: 0x0000DF1C
		private string GetFilePathFromInstanceKeyPrototypeKey(ItemKey instanceKey, ItemKey prototypeKey)
		{
			return Path.GetFullPath(Path.Combine(this.GetDirectoryFromPrototypeKeyGroupId(prototypeKey, instanceKey.GroupId), this.mInstanceManager.GetFilenameById(instanceKey.Id)));
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0000EF48 File Offset: 0x0000DF48
		public List<ItemKey> FilterInstances(List<ItemKey> instanceKeys, uint groupId)
		{
			List<ItemKey> list = new List<ItemKey>();
			foreach (ItemKey itemKey in instanceKeys)
			{
				if (itemKey.GroupId == (long)((ulong)groupId))
				{
					list.Add(itemKey);
				}
			}
			return list;
		}

		// Token: 0x04000114 RID: 276
		private const int kNoChangelistId = 0;

		// Token: 0x04000115 RID: 277
		private const string kDefaultChangelistDescription = "Edit via DB Instances";

		// Token: 0x04000117 RID: 279
		private RCS mRCS;

		// Token: 0x04000118 RID: 280
		private string mAssetRoot = string.Empty;

		// Token: 0x04000119 RID: 281
		private ClassManager mClassManager;

		// Token: 0x0400011A RID: 282
		private PrototypeManager mPrototypeManager;

		// Token: 0x0400011B RID: 283
		private InstanceManager mInstanceManager;

		// Token: 0x0400011C RID: 284
		private List<string> mInstanceDirs = new List<string>();

		// Token: 0x0400011D RID: 285
		private string mIdCounterFile = string.Empty;

		// Token: 0x0400011E RID: 286
		private string mClassesFile = string.Empty;

		// Token: 0x0400011F RID: 287
		private string mPrototypesFile = string.Empty;

		// Token: 0x04000120 RID: 288
		private int mChangelistId;

		// Token: 0x04000121 RID: 289
		private string kCreatingPrototype = "Creating new prototype: ";

		// Token: 0x04000122 RID: 290
		private string kUpdatingPrototype = "Updating prototype: ";

		// Token: 0x04000123 RID: 291
		private string kDeletingInstance = "Deleting instance: ";

		// Token: 0x04000124 RID: 292
		private IntermediatePersister mIntermediatePersister;
	}
}
