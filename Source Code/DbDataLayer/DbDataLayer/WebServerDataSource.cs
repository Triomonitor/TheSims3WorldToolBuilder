using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Sims3.Collections;
using Sims3.DbDataLayer.Sims3WebService;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000006 RID: 6
	internal class WebServerDataSource : IDataSource
	{
		// Token: 0x06000065 RID: 101 RVA: 0x00003078 File Offset: 0x00002078
		public WebServerDataSource()
		{
			this.mService = null;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000309C File Offset: 0x0000209C
		private void InitWebService(string url)
		{
			this.mService = new Sims3DBWS();
			this.mService.Url = url;
			this.mService.UseDefaultCredentials = true;
			this.mService.PreAuthenticate = true;
			this.SetUserAgentWithCallStack();
			try
			{
				this.mService.TestConnection();
			}
			catch (WebException ex)
			{
				bool flag = true;
				string text = "";
				if (ex.Response != null)
				{
					HttpStatusCode statusCode = ((HttpWebResponse)ex.Response).StatusCode;
					if (statusCode != HttpStatusCode.NotFound)
					{
						if (statusCode != HttpStatusCode.InternalServerError)
						{
							if (statusCode == HttpStatusCode.ServiceUnavailable)
							{
								text = "Service unavailable error for database.  Please report this to your TD or TAD.";
							}
						}
						else
						{
							text = "Internal server error on web server.  Database not available, contact your TD or TAD.";
						}
					}
					else
					{
						text = "URL invalid.  Check your pipeline.config.xml or URL config file for this app.";
					}
				}
				if (text == "")
				{
					if (flag)
					{
						LoginForm loginForm = new LoginForm();
						if (loginForm.ShowDialog() != DialogResult.OK)
						{
							goto IL_F5;
						}
						this.mService.UseDefaultCredentials = false;
						this.mService.Credentials = loginForm.Credentials;
						try
						{
							this.mService.TestConnection();
							goto IL_F5;
						}
						catch (WebException)
						{
							text = "Unable to log into database.  Please verify your password, then contact TD or TAD.";
							goto IL_F5;
						}
					}
					text = "Cannot supply database login information for this user in console mode.";
				}
				IL_F5:
				if (text != "")
				{
					if (flag)
					{
						MessageBox.Show(text, "Database login error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						Console.Write("DATABASE ERROR: ");
						Console.WriteLine(text);
					}
				}
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000031F0 File Offset: 0x000021F0
		public bool Connect(params object[] args)
		{
			return true;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000031F3 File Offset: 0x000021F3
		public void Initialize()
		{
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000031F5 File Offset: 0x000021F5
		public bool Disconnect()
		{
			return false;
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600006A RID: 106 RVA: 0x000031F8 File Offset: 0x000021F8
		public string ConnectionInfo
		{
			get
			{
				return string.Format("DB: using {0}", this.mService.Url.Substring(7));
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003218 File Offset: 0x00002218
		public void LoadConfig(XmlElement element, string assetRoot)
		{
			string instancesDir = string.Empty;
			string prototypesDir = string.Empty;
			string empty = string.Empty;
			string empty2 = string.Empty;
			try
			{
				foreach (object obj in element.ChildNodes)
				{
					XmlNode xmlNode = (XmlNode)obj;
					string a;
					if ((a = xmlNode.Name.ToLower()) != null)
					{
						if (!(a == "connection"))
						{
							if (!(a == "instancesdir"))
							{
								if (!(a == "prototypesdir"))
								{
									if (!(a == "previnstancesdir"))
									{
										if (!(a == "prevprototypesdir"))
										{
											if (a == "onlinemode")
											{
												this.mOnlineMode = bool.Parse(xmlNode.Attributes["value"].Value.ToString());
											}
										}
										else
										{
											xmlNode.Attributes["name"].Value.ToString();
										}
									}
									else
									{
										xmlNode.Attributes["name"].Value.ToString();
									}
								}
								else
								{
									prototypesDir = xmlNode.Attributes["name"].Value.ToString();
								}
							}
							else
							{
								instancesDir = xmlNode.Attributes["name"].Value.ToString();
							}
						}
						else
						{
							string url = xmlNode.Attributes["name"].Value.ToString();
							this.InitWebService(url);
						}
					}
				}
			}
			catch (NullReferenceException)
			{
				throw new NullReferenceException("FileDataSource configuration problem: At least one of the needed directories is not specified. Please check you medator.config.xml file.");
			}
			this.mIntermediatePersister = new IntermediatePersister(prototypesDir, instancesDir);
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00003404 File Offset: 0x00002404
		// (set) Token: 0x0600006D RID: 109 RVA: 0x0000340C File Offset: 0x0000240C
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

		// Token: 0x0600006E RID: 110 RVA: 0x00003415 File Offset: 0x00002415
		public bool Sync()
		{
			return false;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003418 File Offset: 0x00002418
		public bool IsSyncable()
		{
			return false;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000341B File Offset: 0x0000241B
		public bool IsOnline()
		{
			return this.mOnlineMode;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003423 File Offset: 0x00002423
		public DateTime LastSync()
		{
			return DateTime.Now;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000342A File Offset: 0x0000242A
		public DBItemInfo[] GetDatabaseItemTree()
		{
			this.SetUserAgentWithCallStack();
			return this.mService.GetDatabaseItemTree();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000343D File Offset: 0x0000243D
		public DBItemInfo[] GetSKUBasedDatabaseItemTree()
		{
			return this.GetDatabaseItemTree();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003448 File Offset: 0x00002448
		public List<ItemKey> GetClassesList()
		{
			this.SetUserAgentWithCallStack();
			List<ItemKey> result;
			try
			{
				ItemKey[] allKeysOfType = this.mService.GetAllKeysOfType(ItemType.CLASS);
				foreach (ItemKey itemKey in allKeysOfType)
				{
					itemKey.KeyType = ItemType.CLASS;
				}
				result = new List<ItemKey>(allKeysOfType);
			}
			catch (WebException inner)
			{
				throw new DataSourceException("Error getting object classes", inner);
			}
			return result;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000034B4 File Offset: 0x000024B4
		public List<ItemKey> GetPrototypesList()
		{
			this.SetUserAgentWithCallStack();
			List<ItemKey> result;
			try
			{
				ItemKey[] allKeysOfType = this.mService.GetAllKeysOfType(ItemType.PROTOTYPE);
				foreach (ItemKey itemKey in allKeysOfType)
				{
					itemKey.KeyType = ItemType.PROTOTYPE;
				}
				result = new List<ItemKey>(allKeysOfType);
			}
			catch (WebException inner)
			{
				throw new DataSourceException("Error getting object prototypes", inner);
			}
			return result;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003520 File Offset: 0x00002520
		public List<ItemKey> GetInstanceKeysOfPrototype(ItemKey prototypeKey)
		{
			this.SetUserAgentWithCallStack();
			if (prototypeKey == null)
			{
				throw new ArgumentNullException("prototypeKey");
			}
			if (prototypeKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			List<ItemKey> result;
			try
			{
				ItemKey[] childrenForKey = this.mService.GetChildrenForKey(prototypeKey);
				foreach (ItemKey itemKey in childrenForKey)
				{
					itemKey.KeyType = ItemType.INSTANCE;
				}
				result = new List<ItemKey>(childrenForKey);
			}
			catch (WebException inner)
			{
				throw new DataSourceException("Error getting object instances by prototype", inner);
			}
			return result;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000035B0 File Offset: 0x000025B0
		public List<ObjectInstance> GetInstancesOfPrototype(ItemKey prototype)
		{
			this.SetUserAgentWithCallStack();
			if (prototype == null)
			{
				throw new ArgumentNullException("prototype");
			}
			if (prototype.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			List<ObjectInstance> list = new List<ObjectInstance>();
			ItemKey[] childrenForKey = this.mService.GetChildrenForKey(prototype);
			foreach (ItemKey itemKey in childrenForKey)
			{
				itemKey.KeyType = ItemType.INSTANCE;
				ObjectInstance instanceByKey = this.mService.GetInstanceByKey(itemKey);
				list.Add(instanceByKey);
			}
			return list;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003634 File Offset: 0x00002634
		public List<ItemKey> GetPrototypeKeysOfClass(ItemKey classKey)
		{
			this.SetUserAgentWithCallStack();
			if (classKey == null)
			{
				throw new ArgumentNullException("classKey");
			}
			if (classKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ItemKey[] childrenForKey = this.mService.GetChildrenForKey(classKey);
			foreach (ItemKey itemKey in childrenForKey)
			{
				itemKey.KeyType = ItemType.PROTOTYPE;
			}
			return new List<ItemKey>(childrenForKey);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003698 File Offset: 0x00002698
		public List<ItemKey> GetInstanceKeysOfClassKey(ItemKey classKey)
		{
			this.SetUserAgentWithCallStack();
			if (classKey == null)
			{
				throw new ArgumentNullException("classKey");
			}
			if (classKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ItemKey[] instancesForClassKeyNoXmlData = this.mService.GetInstancesForClassKeyNoXmlData(classKey);
			List<ItemKey> list = new List<ItemKey>();
			foreach (ItemKey item in instancesForClassKeyNoXmlData)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003704 File Offset: 0x00002704
		public List<ObjectInstance> GetInstancesForClassKey(ItemKey classKey)
		{
			this.SetUserAgentWithCallStack();
			if (classKey == null)
			{
				throw new ArgumentNullException("classKey");
			}
			if (classKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ObjectInstance[] instancesForClassKeyNoXmlData = this.mService.GetInstancesForClassKeyNoXmlData(classKey);
			List<ObjectInstance> list = new List<ObjectInstance>();
			foreach (ObjectInstance item in instancesForClassKeyNoXmlData)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003770 File Offset: 0x00002770
		public ItemKey GetInstancePrototypeKey(ItemKey instanceKey)
		{
			this.SetUserAgentWithCallStack();
			if (instanceKey == null)
			{
				throw new ArgumentNullException("instanceKey");
			}
			if (instanceKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ObjectInstance instanceByKey = this.mService.GetInstanceByKey(instanceKey);
			ItemKey itemKey = null;
			if (instanceByKey != null)
			{
				itemKey = new ItemKey();
				itemKey.Name = instanceByKey.DbPrototype.Name;
				itemKey.GroupId = instanceByKey.DbPrototype.GroupId;
				itemKey.ResourceType = instanceByKey.ResourceType;
				itemKey.KeyType = ItemType.PROTOTYPE;
			}
			return itemKey;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000037F4 File Offset: 0x000027F4
		public string GetPrototypeData(ItemKey item)
		{
			this.SetUserAgentWithCallStack();
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (item.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			return this.mService.GetXmlDataForKey(item);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000382B File Offset: 0x0000282B
		public ObjectClass GetObjectClass(ItemKey classKey)
		{
			this.SetUserAgentWithCallStack();
			if (classKey == null)
			{
				throw new ArgumentNullException("classKey");
			}
			if (classKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			return this.mService.GetClassByKey(classKey);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003864 File Offset: 0x00002864
		public ObjectInstance GetInstance(ItemKey instanceKey)
		{
			this.SetUserAgentWithCallStack();
			if (instanceKey == null)
			{
				throw new ArgumentNullException("instanceKey");
			}
			if (instanceKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ObjectInstance instanceByKey = this.mService.GetInstanceByKey(instanceKey);
			if (instanceByKey != null)
			{
				return new ObjectInstance
				{
					KeyType = ItemType.INSTANCE,
					Name = instanceByKey.Name,
					GroupId = instanceByKey.GroupId,
					ResourceType = instanceByKey.ResourceType,
					XmlData = instanceByKey.XmlData,
					Id = instanceByKey.Id
				};
			}
			return null;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000038F6 File Offset: 0x000028F6
		public string GetInstanceData(ItemKey item)
		{
			this.SetUserAgentWithCallStack();
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (item.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			return this.mService.GetXmlDataForKey(item);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003930 File Offset: 0x00002930
		public ObjectClass GetObjectClassByPrototype(ItemKey prototypeKey)
		{
			this.SetUserAgentWithCallStack();
			if (prototypeKey == null)
			{
				throw new ArgumentNullException("prototypeKey");
			}
			if (prototypeKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ObjectPrototype prototypeByKey = this.mService.GetPrototypeByKey(prototypeKey);
			return new ObjectClass
			{
				AssemblyName = prototypeByKey.DbClass.AssemblyName,
				ClassName = prototypeByKey.DbClass.ClassName,
				ResourceType = prototypeByKey.DbClass.ResourceType
			};
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000039B0 File Offset: 0x000029B0
		public string GetClassNameByPrototype(ItemKey key)
		{
			this.SetUserAgentWithCallStack();
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (key.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ObjectPrototype prototypeByKey = this.mService.GetPrototypeByKey(key);
			if (prototypeByKey == null)
			{
				return string.Empty;
			}
			return prototypeByKey.DbClass.ClassName;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003A08 File Offset: 0x00002A08
		public long GetClassResourceTypeFromPrototype(ItemKey key)
		{
			this.SetUserAgentWithCallStack();
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (key.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ObjectPrototype prototypeByKey = this.mService.GetPrototypeByKey(key);
			return prototypeByKey.DbClass.ResourceType;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003A56 File Offset: 0x00002A56
		public string GetAllInstancesXml()
		{
			this.SetUserAgentWithCallStack();
			return this.mService.GetAllInstancesXml();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003A6C File Offset: 0x00002A6C
		public List<ObjectInstance> GetAllInstances()
		{
			this.SetUserAgentWithCallStack();
			ObjectInstance[] allInstances = this.mService.GetAllInstances();
			return new List<ObjectInstance>(allInstances);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003A94 File Offset: 0x00002A94
		public List<ObjectInstance> GetAllInstancesByDate(DateTime dateTime)
		{
			ObjectInstance[] allInstancesByDate = this.mService.GetAllInstancesByDate(dateTime);
			return new List<ObjectInstance>(allInstancesByDate);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003AB4 File Offset: 0x00002AB4
		public IList<ObjectPrototype> GetAllPrototypes()
		{
			this.SetUserAgentWithCallStack();
			ObjectPrototype[] allPrototypesNoXmlData = this.mService.GetAllPrototypesNoXmlData();
			List<ObjectPrototype> list = new List<ObjectPrototype>();
			foreach (ObjectPrototype item in allPrototypesNoXmlData)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003AFA File Offset: 0x00002AFA
		public List<ItemKey> GetInstancesByReference(ItemKey instanceKey)
		{
			if (instanceKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			return new List<ItemKey>(this.mService.GetInstancesByReference(instanceKey));
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003B24 File Offset: 0x00002B24
		public bool DoesItemKeyExist(string name, long groupId, long resourceType, ItemType itemType)
		{
			ItemKey item = new ItemKey(name, groupId, resourceType, itemType);
			if (itemType == ItemType.INSTANCE)
			{
				return !string.IsNullOrEmpty(this.GetInstanceData(item));
			}
			return itemType == ItemType.PROTOTYPE && !string.IsNullOrEmpty(this.GetPrototypeData(item));
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003B67 File Offset: 0x00002B67
		public ItemKey FindItemKey(string name, long groupId, long resourceType, ItemType itemType)
		{
			return new ItemKey(name, groupId, resourceType, itemType);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003B73 File Offset: 0x00002B73
		public string GetInstanceFilePath(ItemKey instanceKey)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003B7A File Offset: 0x00002B7A
		public ItemKey[][] ListCheckedOutChildrenForKey(ItemKey key)
		{
			return this.mService.ListCheckedOutChildrenForKey(key);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003B88 File Offset: 0x00002B88
		public string GetInstanceCheckoutUser(ItemKey instanceKey)
		{
			if (instanceKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			return this.mService.GetCheckoutUserForKey(instanceKey);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003BAB File Offset: 0x00002BAB
		public Guid[] CheckoutsForCurrentUser()
		{
			this.SetUserAgentWithCallStack();
			return this.mService.GetCheckoutsForCurrentUser();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003BBE File Offset: 0x00002BBE
		public Guid CheckOutInstance(ItemKey item)
		{
			this.SetUserAgentWithCallStack();
			if (item.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			return this.mService.Checkout(item);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003BE7 File Offset: 0x00002BE7
		public Guid CheckOutPrototype(ItemKey item)
		{
			this.SetUserAgentWithCallStack();
			if (item.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			return this.mService.Checkout(item);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003C10 File Offset: 0x00002C10
		public void CheckInInstance(ItemKey item)
		{
			this.SetUserAgentWithCallStack();
			if (item.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			this.mService.CheckinKey(item);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003C39 File Offset: 0x00002C39
		public void CheckInPrototype(ItemKey item)
		{
			this.SetUserAgentWithCallStack();
			if (item.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			this.mService.CheckinKey(item);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003C62 File Offset: 0x00002C62
		public bool IsInstanceCheckOut(ItemKey instanceKey)
		{
			this.SetUserAgentWithCallStack();
			if (instanceKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			return this.mService.IsKeyCheckedOut(instanceKey);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003C8C File Offset: 0x00002C8C
		public int DeleteInstance(ItemKey item)
		{
			this.SetUserAgentWithCallStack();
			if (item.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ObjectInstance objectInstance = new ObjectInstance();
			objectInstance.Name = item.Name;
			objectInstance.GroupId = item.GroupId;
			objectInstance.ResourceType = item.ResourceType;
			return this.mService.DeleteByKey(item);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003CEA File Offset: 0x00002CEA
		public int DeletePrototype(ItemKey item)
		{
			this.SetUserAgentWithCallStack();
			if (item.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			return this.mService.DeleteByKey(item);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003D13 File Offset: 0x00002D13
		public bool RevertInstance(ItemKey instanceKey)
		{
			this.CheckInInstance(instanceKey);
			return true;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003D1D File Offset: 0x00002D1D
		public bool RevertPrototype(ItemKey prototypeKey)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003D24 File Offset: 0x00002D24
		public int InsertInstance(string name, long groupId, long resourceType, ItemKey prototypeKey, string instanceXml)
		{
			this.SetUserAgentWithCallStack();
			if (prototypeKey.ResourceType == -1L || resourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ObjectPrototype prototypeByKey = this.mService.GetPrototypeByKey(prototypeKey);
			ObjectInstance objectInstance = new ObjectInstance();
			objectInstance.Name = name;
			objectInstance.GroupId = groupId;
			objectInstance.ResourceType = resourceType;
			objectInstance.DbPrototype = prototypeByKey;
			objectInstance.XmlData = instanceXml;
			return this.mService.InsertInstance(objectInstance);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003D98 File Offset: 0x00002D98
		public int UpdateInstance(ItemKey updatedKey, ItemKey originalKey, ItemKey updatedPrototypeKey, ItemKey originalPrototypeKey, string instanceXml)
		{
			this.SetUserAgentWithCallStack();
			if (originalKey.ResourceType == -1L || updatedKey.ResourceType == -1L || originalPrototypeKey.ResourceType == -1L || updatedPrototypeKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ObjectPrototype prototypeByKey = this.mService.GetPrototypeByKey(updatedPrototypeKey);
			ObjectPrototype prototypeByKey2 = this.mService.GetPrototypeByKey(originalPrototypeKey);
			ObjectInstance objectInstance = new ObjectInstance();
			objectInstance.Name = updatedKey.Name;
			objectInstance.GroupId = updatedKey.GroupId;
			objectInstance.ResourceType = updatedKey.ResourceType;
			objectInstance.DbPrototype = prototypeByKey;
			objectInstance.XmlData = instanceXml;
			ObjectInstance objectInstance2 = new ObjectInstance();
			objectInstance2.Name = originalKey.Name;
			objectInstance2.GroupId = originalKey.GroupId;
			objectInstance2.ResourceType = originalKey.ResourceType;
			objectInstance2.DbPrototype = prototypeByKey2;
			return this.mService.UpdateInstance(objectInstance, objectInstance2);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003E74 File Offset: 0x00002E74
		public int InsertPrototype(string name, long groupId, long resourceType, ItemKey classKey, string prototypeXml)
		{
			this.SetUserAgentWithCallStack();
			if (resourceType == -1L || classKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ObjectClass classByKey = this.mService.GetClassByKey(classKey);
			ObjectPrototype objectPrototype = new ObjectPrototype();
			objectPrototype.DbClass = classByKey;
			objectPrototype.GroupId = groupId;
			objectPrototype.KeyType = ItemType.PROTOTYPE;
			objectPrototype.Name = name;
			objectPrototype.ResourceType = resourceType;
			objectPrototype.XmlData = prototypeXml;
			return this.mService.InsertPrototype(objectPrototype);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00003EF0 File Offset: 0x00002EF0
		public int UpdatePrototype(ItemKey updatedKey, ItemKey originalKey, ItemKey classKey, string prototypeXml)
		{
			this.SetUserAgentWithCallStack();
			if (originalKey.ResourceType == -1L || updatedKey.ResourceType == -1L || classKey.ResourceType == -1L)
			{
				throw new NotSupportedException("-1 ResourceType no longer supported by DB");
			}
			ObjectClass classByKey = this.mService.GetClassByKey(classKey);
			ObjectPrototype objectPrototype = new ObjectPrototype();
			objectPrototype.DbClass = classByKey;
			objectPrototype.GroupId = updatedKey.GroupId;
			objectPrototype.KeyType = ItemType.PROTOTYPE;
			objectPrototype.Name = updatedKey.Name;
			objectPrototype.ResourceType = updatedKey.ResourceType;
			objectPrototype.XmlData = prototypeXml;
			ObjectPrototype objectPrototype2 = new ObjectPrototype();
			objectPrototype2.DbClass = classByKey;
			objectPrototype2.GroupId = originalKey.GroupId;
			objectPrototype2.KeyType = ItemType.PROTOTYPE;
			objectPrototype2.Name = originalKey.Name;
			objectPrototype2.ResourceType = originalKey.ResourceType;
			return this.mService.UpdatePrototype(objectPrototype, objectPrototype2);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00003FBE File Offset: 0x00002FBE
		public void SaveInstances(SerializableDictionary<ItemKey, PersistedObject> objects)
		{
			this.mIntermediatePersister.SaveInstances(objects);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00003FCC File Offset: 0x00002FCC
		public void SavePrototypes(SerializableDictionary<ItemKey, PersistedPrototype> prototypes)
		{
			this.mIntermediatePersister.SavePrototypes(prototypes);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00003FDA File Offset: 0x00002FDA
		public SerializableDictionary<ItemKey, PersistedObject> LoadInstances()
		{
			return this.mIntermediatePersister.LoadInstances();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003FE7 File Offset: 0x00002FE7
		public SerializableDictionary<ItemKey, PersistedPrototype> LoadPrototypes()
		{
			return this.mIntermediatePersister.LoadPrototypes();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00003FF4 File Offset: 0x00002FF4
		private void SetUserAgentWithCallStack()
		{
			string text = "WebServerDataSource: Undetermined call stack";
			StackTrace stackTrace = new StackTrace(1);
			if (stackTrace.FrameCount >= 3)
			{
				MethodBase method = stackTrace.GetFrame(0).GetMethod();
				text = method.Module + "|" + method.Name;
				method = stackTrace.GetFrame(2).GetMethod();
				text = string.Concat(new object[]
				{
					text,
					" > ",
					method.Module,
					"|",
					method.Name
				});
			}
			this.mService.UserAgent = text;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004088 File Offset: 0x00003088
		public bool IsLocked()
		{
			return this.mService.IsDatabaseLocked();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004098 File Offset: 0x00003098
		public string GetLockAdmin()
		{
			DatabaseLock databaseLockInformation = this.mService.GetDatabaseLockInformation();
			return databaseLockInformation.Username;
		}

		// Token: 0x04000016 RID: 22
		private Sims3DBWS mService;

		// Token: 0x04000017 RID: 23
		private string mDataPath = "";

		// Token: 0x04000018 RID: 24
		private bool mOnlineMode = true;

		// Token: 0x04000019 RID: 25
		private IntermediatePersister mIntermediatePersister;
	}
}
