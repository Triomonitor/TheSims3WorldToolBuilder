using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.XPath;
using Sims3.Collections;
using Sims3.DbDataLayer.Sims3WebService;
using Sims3.Metadata;
using Sims3.RevisionControl;
using Sims3.SimIFace;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000017 RID: 23
	public class DataStore
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000123 RID: 291 RVA: 0x00005C1D File Offset: 0x00004C1D
		// (remove) Token: 0x06000124 RID: 292 RVA: 0x00005C36 File Offset: 0x00004C36
		public event DataStore.GetItemKeyListCompletedHandler GetPrototypeListCompleted;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000125 RID: 293 RVA: 0x00005C4F File Offset: 0x00004C4F
		// (remove) Token: 0x06000126 RID: 294 RVA: 0x00005C68 File Offset: 0x00004C68
		public event InstanceEventHandler InstanceAdded;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000127 RID: 295 RVA: 0x00005C81 File Offset: 0x00004C81
		// (remove) Token: 0x06000128 RID: 296 RVA: 0x00005C9A File Offset: 0x00004C9A
		public event InstanceEventHandler InstanceRemoved;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000129 RID: 297 RVA: 0x00005CB3 File Offset: 0x00004CB3
		// (remove) Token: 0x0600012A RID: 298 RVA: 0x00005CCC File Offset: 0x00004CCC
		public event EventHandler InstancesCleared;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600012B RID: 299 RVA: 0x00005CE5 File Offset: 0x00004CE5
		// (remove) Token: 0x0600012C RID: 300 RVA: 0x00005CFE File Offset: 0x00004CFE
		public event ClassNotFoundHandler ClassNotFound;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600012D RID: 301 RVA: 0x00005D17 File Offset: 0x00004D17
		// (remove) Token: 0x0600012E RID: 302 RVA: 0x00005D30 File Offset: 0x00004D30
		public event EventHandler AsyncInstancesLoaded;

		// Token: 0x0600012F RID: 303 RVA: 0x00005D4C File Offset: 0x00004D4C
		private DataStore()
		{
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00005DD0 File Offset: 0x00004DD0
		public void LoadConfig(XmlDocument configDoc)
		{
			this.mConfigDoc = configDoc;
			string text;
			XPathNavigator xpathNavigator;
			XPathNodeIterator xpathNodeIterator;
			this.LoadClassDefConfig(configDoc, out text, out xpathNavigator, out xpathNodeIterator);
			this.LoadDataSourceConfig(configDoc, ref text, ref xpathNavigator, ref xpathNodeIterator);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00005E00 File Offset: 0x00004E00
		private void MigrateDBToP4()
		{
			FileDataSource fileDataSource = new FileDataSource();
			string xml = "<DataSource name=\"FileDataSource\">  \r\n                                    <InstanceIdCounter>($AssetRoot)\\IdCounterFile_DL.xml</InstanceIdCounter>\r\n                                    <ClassesFile>($AssetRoot)\\Classes.xml</ClassesFile>\r\n                                    <PrototypesFile>($AssetRoot)\\Prototypes.xml</PrototypesFile>\r\n                                    <IntermediateInstancesDir>..\\..\\..\\MetaData\\Instances</IntermediateInstancesDir>\r\n                                    <IntermediatePrototypesDir>..\\..\\..\\MetaData\\Prototypes</IntermediatePrototypesDir>\r\n                                    <Branch>DL</Branch>\r\n                                 </DataSource>";
			if (SKUManager.IsStoreMode)
			{
				xml = "<DataSource name=\"FileDataSource\">  \r\n                                <InstanceIdCounter>($AssetRoot)\\IdCounterFile_DL_Store.xml</InstanceIdCounter>\r\n                                <ClassesFile>($AssetRoot)\\Classes.xml</ClassesFile>\r\n                                <PrototypesFile>($AssetRoot)\\Prototypes.xml</PrototypesFile>\r\n                                <IntermediateInstancesDir>..\\..\\..\\MetaData\\Instances</IntermediateInstancesDir>\r\n                                <IntermediatePrototypesDir>..\\..\\..\\MetaData\\Prototypes</IntermediatePrototypesDir>\r\n                                <Branch>Store</Branch>\r\n                             </DataSource>";
			}
			else if (SKUManager.IsStoreStagingMode)
			{
				xml = "<DataSource name=\"FileDataSource\">  \r\n                                <InstanceIdCounter>($AssetRoot)\\IdCounterFile_DL_StoreStaging.xml</InstanceIdCounter>\r\n                                <ClassesFile>($AssetRoot)\\Classes.xml</ClassesFile>\r\n                                <PrototypesFile>($AssetRoot)\\Prototypes.xml</PrototypesFile>\r\n                                <IntermediateInstancesDir>..\\..\\..\\MetaData\\Instances</IntermediateInstancesDir>\r\n                                <IntermediatePrototypesDir>..\\..\\..\\MetaData\\Prototypes</IntermediatePrototypesDir>\r\n                                <Branch>Store</Branch>\r\n                             </DataSource>";
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			fileDataSource.LoadConfig(xmlDocument.DocumentElement, "X:");
			fileDataSource.Connect(new object[0]);
			fileDataSource.Initialize();
			List<ItemKey> classesList = this.mDataSource.GetClassesList();
			foreach (ItemKey classKey in classesList)
			{
				List<ItemKey> prototypeKeysOfClass = this.mDataSource.GetPrototypeKeysOfClass(classKey);
				foreach (ItemKey itemKey in prototypeKeysOfClass)
				{
					List<ItemKey> instanceKeysOfPrototype = this.mDataSource.GetInstanceKeysOfPrototype(itemKey);
					foreach (ItemKey itemKey2 in instanceKeysOfPrototype)
					{
						if (!fileDataSource.DoesItemKeyExist(itemKey2.Name, 0L, itemKey2.ResourceType, ItemType.INSTANCE))
						{
							string instanceData = this.mDataSource.GetInstanceData(itemKey2);
							itemKey2.GroupId = 0L;
							if (SKUManager.IsStoreMode)
							{
								itemKey2.GroupId = 16777216L;
							}
							else if (SKUManager.IsStoreStagingMode)
							{
								itemKey2.GroupId = 16777216L;
							}
							fileDataSource.SpecialInsertInstanceForMigrate(itemKey2, itemKey, instanceData);
						}
					}
				}
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00005FD8 File Offset: 0x00004FD8
		private void LoadClassDefConfig(XmlDocument configDoc, out string xpath, out XPathNavigator nav, out XPathNodeIterator ti)
		{
			string typeName = Assembly.CreateQualifiedName("SimIFace", "Sims3.SimIFace.ICustomXMLHandler");
			Type.GetType(typeName);
			xpath = "//pipelineConfig/DataStore/ClassDef/source";
			nav = configDoc.CreateNavigator();
			ti = nav.Select(xpath);
			if (ti == null)
			{
				throw new WrongConfigFileException();
			}
			while (ti.MoveNext())
			{
				XmlElement xmlElement = ((IHasXmlNode)ti.Current).GetNode() as XmlElement;
				string text = xmlElement.GetAttribute("filename");
				Assembly assembly = null;
				AssemblyName assemblyName = new AssemblyName();
				assemblyName.Name = Path.GetFileNameWithoutExtension(text);
				try
				{
					assembly = Assembly.Load(assemblyName);
				}
				catch (Exception)
				{
					text = Path.GetFullPath(text);
					FileInfo fileInfo = new FileInfo(text);
					if (fileInfo.Exists)
					{
						try
						{
							assembly = Assembly.LoadFile(text);
						}
						catch (Exception)
						{
						}
					}
				}
				this.LoadClassDefinition(assembly);
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000060D4 File Offset: 0x000050D4
		private void LoadDataSourceConfig(XmlDocument configDoc, ref string xpath, ref XPathNavigator nav, ref XPathNodeIterator ti)
		{
			xpath = "//pipelineConfig/DataStore/DataSource";
			nav = configDoc.CreateNavigator();
			string xpath2 = "//pipelineConfig/AssetRoot[@default]";
			XmlNode xmlNode = configDoc.SelectSingleNode(xpath2);
			string assetRoot = string.Empty;
			if (xmlNode == null)
			{
				throw new WrongConfigFileException();
			}
			XmlElement xmlElement = xmlNode as XmlElement;
			assetRoot = xmlElement.GetAttribute("default");
			ti = nav.Select(xpath);
			if (ti == null)
			{
				throw new WrongConfigFileException();
			}
			while (ti.MoveNext())
			{
				XmlElement xmlElement2 = ((IHasXmlNode)ti.Current).GetNode() as XmlElement;
				string attribute = xmlElement2.GetAttribute("name");
				if (attribute == "FileDataSource")
				{
					FileDataSource fileDataSource = new FileDataSource();
					fileDataSource.AsyncInstancesLoaded += delegate(object o, EventArgs e)
					{
						if (this.AsyncInstancesLoaded != null)
						{
							this.AsyncInstancesLoaded(this, e);
						}
					};
					this.mDataSource = fileDataSource;
					this.mIsFileDataSource = true;
				}
				else if (!(attribute == "SQLDataSource"))
				{
					if (attribute == "SqlCEDataSource")
					{
						this.mDataSource = new SqlCEDataSource();
					}
					else
					{
						if (!(attribute == "WebServiceDataSource"))
						{
							throw new DataSourceException("Unknown datasource type in configuration file.");
						}
						this.mDataSource = new WebServerDataSource();
					}
				}
				if (this.mDataSource != null)
				{
					this.mDataSource.LoadConfig(xmlElement2, assetRoot);
				}
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00006219 File Offset: 0x00005219
		public void SaveConfig(XmlDocument configDoc)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00006220 File Offset: 0x00005220
		public static DataStore Instance
		{
			get
			{
				if (DataStore.mDataStore == null)
				{
					DataStore.mDataStore = new DataStore();
				}
				return DataStore.mDataStore;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00006238 File Offset: 0x00005238
		public bool Initialized
		{
			get
			{
				return this.mInitialized;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00006240 File Offset: 0x00005240
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00006248 File Offset: 0x00005248
		public uint AsyncTimeOut
		{
			get
			{
				return this.mAsyncTimeOut;
			}
			set
			{
				this.mAsyncTimeOut = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00006251 File Offset: 0x00005251
		public Dictionary<ItemKey, OpenObject> OpenObjects
		{
			get
			{
				return this.mObjects;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00006259 File Offset: 0x00005259
		public XmlDocument ConfigDoc
		{
			get
			{
				return this.mConfigDoc;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00006261 File Offset: 0x00005261
		public bool IsFileDataSource
		{
			get
			{
				return this.mIsFileDataSource;
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00006269 File Offset: 0x00005269
		public bool EstablishConnection(params object[] args)
		{
			return this.mDataSource.Connect(args);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00006277 File Offset: 0x00005277
		public void Initialize()
		{
			this.mDataSource.Initialize();
			this.mInitialized = true;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000628C File Offset: 0x0000528C
		public bool TerminateConnection()
		{
			bool result = false;
			if (this.mDataSource != null)
			{
				result = this.mDataSource.Disconnect();
			}
			this.mInitialized = false;
			return result;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600013F RID: 319 RVA: 0x000062B7 File Offset: 0x000052B7
		public string ConnectionInfo
		{
			get
			{
				return this.mDataSource.ConnectionInfo;
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000062C4 File Offset: 0x000052C4
		public bool IsSyncable()
		{
			return this.mDataSource.IsSyncable();
		}

		// Token: 0x06000141 RID: 321 RVA: 0x000062D1 File Offset: 0x000052D1
		public bool IsOnline()
		{
			return this.mDataSource.IsOnline();
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000062DE File Offset: 0x000052DE
		public DateTime LastSync()
		{
			return this.mDataSource.LastSync();
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000062EB File Offset: 0x000052EB
		public bool Sync()
		{
			return this.IsSyncable() && this.mDataSource.Sync();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00006304 File Offset: 0x00005304
		private void StartAsyncTask(DoWorkEventHandler doWork, RunWorkerCompletedEventHandler workCompleted, bool async)
		{
			if (async)
			{
				DateTime now = DateTime.Now;
				int i;
				for (;;)
				{
					for (i = 0; i < this.backgroundWorkersList.Length; i++)
					{
						if (!this.backgroundWorkersList[i].Busy)
						{
							goto Block_2;
						}
					}
					Thread.Sleep(0);
					if ((DateTime.Now - now).TotalMilliseconds > this.AsyncTimeOut)
					{
						goto Block_4;
					}
				}
				Block_2:
				this.backgroundWorkersList[i].StartAsyncTask(doWork, workCompleted);
				return;
				Block_4:
				throw new TimeoutException("Timed out while waiting for background workers to become available");
			}
			doWork(this, null);
			if (workCompleted != null)
			{
				workCompleted(this, null);
			}
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00006390 File Offset: 0x00005390
		public ItemKey[] PerformInitialization(bool asynchronous)
		{
			this.Initialize();
			if (asynchronous)
			{
				try
				{
					this.StartAsyncTask(new DoWorkEventHandler(this.LoadPrototypesListProxy), new RunWorkerCompletedEventHandler(this.BackgroundWorker_GetPrototypesCompleted), asynchronous);
					goto IL_68;
				}
				catch (DataSourceException)
				{
					this.Load();
					this.OnGetPrototypeListCompleted(new List<ItemKey>());
					goto IL_68;
				}
			}
			List<ItemKey> prototypes = null;
			try
			{
				prototypes = this.GetPrototypesList();
			}
			catch (DataSourceException)
			{
				prototypes = new List<ItemKey>();
			}
			catch (Exception)
			{
				prototypes = new List<ItemKey>();
			}
			this.Load();
			this.OnGetPrototypeListCompleted(prototypes);
			IL_68:
			List<ItemKey> list = null;
			try
			{
				list = this.mDataSource.GetClassesList();
			}
			catch (DataSourceException)
			{
				list = new List<ItemKey>();
			}
			return list.ToArray();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00006458 File Offset: 0x00005458
		private void OnGetPrototypeListCompleted(List<ItemKey> prototypes)
		{
			if (this.GetPrototypeListCompleted != null)
			{
				this.GetPrototypeListCompleted(this, prototypes);
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000646F File Offset: 0x0000546F
		private void LoadPrototypesListProxy(object sender, DoWorkEventArgs e)
		{
			e.Result = this.GetPrototypesList();
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00006480 File Offset: 0x00005480
		private void BackgroundWorker_GetPrototypesCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			bool flag = true;
			if (e != null)
			{
				if (e.Error != null)
				{
					flag = false;
				}
				else if (e.Cancelled)
				{
					flag = false;
				}
			}
			this.Load();
			if (this.GetPrototypeListCompleted != null && flag)
			{
				this.GetPrototypeListCompleted(this, (List<ItemKey>)e.Result);
			}
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000064D0 File Offset: 0x000054D0
		public ItemKey GetInstancePrototypeKey(ItemKey instanceKey)
		{
			ItemKey result;
			if (this.mObjects.ContainsKey(instanceKey))
			{
				OpenObject openObject = this.mObjects[instanceKey];
				result = openObject.PrototypeKey;
			}
			else
			{
				result = this.mDataSource.GetInstancePrototypeKey(instanceKey);
			}
			return result;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000650F File Offset: 0x0000550F
		public DBItemInfo[] GetDatabaseItemTree()
		{
			return this.mDataSource.GetDatabaseItemTree();
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000651C File Offset: 0x0000551C
		public DBItemInfo[] GetSKUBasedDatabaseItemTree()
		{
			return this.mDataSource.GetSKUBasedDatabaseItemTree();
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00006529 File Offset: 0x00005529
		public List<ItemKey> GetClassesList()
		{
			return this.mDataSource.GetClassesList();
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00006536 File Offset: 0x00005536
		public List<ItemKey> GetPrototypesList()
		{
			return this.mDataSource.GetPrototypesList();
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00006543 File Offset: 0x00005543
		public List<ItemKey> GetInstanceKeysOfPrototype(ItemKey prototypekey)
		{
			return this.mDataSource.GetInstanceKeysOfPrototype(prototypekey);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00006551 File Offset: 0x00005551
		public List<ObjectInstance> GetInstancesOfPrototype(ItemKey prototype)
		{
			return this.mDataSource.GetInstancesOfPrototype(prototype);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000655F File Offset: 0x0000555F
		public List<ObjectInstance> GetInstancesForClassKey(ItemKey inClass)
		{
			return this.mDataSource.GetInstancesForClassKey(inClass);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000656D File Offset: 0x0000556D
		public List<ItemKey> GetPrototypeKeysOfClass(ItemKey classKey)
		{
			return this.mDataSource.GetPrototypeKeysOfClass(classKey);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000657B File Offset: 0x0000557B
		public string GetPrototypeData(ItemKey item)
		{
			return this.mDataSource.GetPrototypeData(item);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00006589 File Offset: 0x00005589
		public string GetInstanceData(ItemKey item)
		{
			return this.mDataSource.GetInstanceData(item);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00006597 File Offset: 0x00005597
		public ObjectClass GetObjectClassByPrototype(ItemKey prototypeKey)
		{
			return this.mDataSource.GetObjectClassByPrototype(prototypeKey);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000065A5 File Offset: 0x000055A5
		public string GetClassNameByPrototype(ItemKey key)
		{
			return this.mDataSource.GetClassNameByPrototype(key);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000065B3 File Offset: 0x000055B3
		public long GetClassResourceIdByPrototype(ItemKey key)
		{
			return this.mDataSource.GetClassResourceTypeFromPrototype(key);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x000065C1 File Offset: 0x000055C1
		public List<ObjectInstance> GetAllInstances()
		{
			return this.mDataSource.GetAllInstances();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000065CE File Offset: 0x000055CE
		public List<ObjectInstance> GetAllInstancesByDate(DateTime dateTime)
		{
			return this.mDataSource.GetAllInstancesByDate(dateTime);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000065DC File Offset: 0x000055DC
		public IList<ObjectPrototype> GetAllPrototypes()
		{
			return this.mDataSource.GetAllPrototypes();
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000065E9 File Offset: 0x000055E9
		public List<ItemKey> GetInstancesByReference(ItemKey instanceKey)
		{
			return this.mDataSource.GetInstancesByReference(instanceKey);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000065F7 File Offset: 0x000055F7
		public ObjectInstance GetInstance(ItemKey instanceKey)
		{
			return this.mDataSource.GetInstance(instanceKey);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00006605 File Offset: 0x00005605
		public bool DoesItemKeyExist(string name, long groupId, long resourceType, ItemType itemType)
		{
			return this.mDataSource.DoesItemKeyExist(name, groupId, resourceType, itemType);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00006617 File Offset: 0x00005617
		public ItemKey FindItemKey(string name, long groupId, long resourceType, ItemType itemType)
		{
			return this.mDataSource.FindItemKey(name, groupId, resourceType, itemType);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000662C File Offset: 0x0000562C
		public ItemKey FindOpenItemKey(string name, long groupId, long resourceType, ItemType itemType)
		{
			ItemKey itemKey = new ItemKey(name, groupId, resourceType, itemType);
			foreach (ItemKey itemKey2 in this.OpenObjects.Keys)
			{
				if (itemKey.Equals(itemKey2))
				{
					return itemKey2;
				}
			}
			return null;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00006698 File Offset: 0x00005698
		public string GetInstanceFilePath(ItemKey instanceKey)
		{
			if (this.IsFileDataSource)
			{
				return this.mDataSource.GetInstanceFilePath(instanceKey);
			}
			return string.Empty;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x000066B4 File Offset: 0x000056B4
		public int InsertInstance(string name, long groupId, long resourceType, ItemKey prototypeKey, object instance)
		{
			this.CheckDBLock();
			string instanceXml = this.GenerateXml(instance);
			return this.mDataSource.InsertInstance(name, groupId, resourceType, prototypeKey, instanceXml);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x000066E4 File Offset: 0x000056E4
		public int UpdateInstance(ItemKey updatedKey, ItemKey originalKey, ItemKey updatedPrototypeKey, ItemKey originalPrototypeKey, object instance)
		{
			this.CheckDBLock();
			string instanceXml = this.GenerateXml(instance);
			return this.mDataSource.UpdateInstance(updatedKey, originalKey, updatedPrototypeKey, originalPrototypeKey, instanceXml);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00006714 File Offset: 0x00005714
		public int InsertPrototype(string name, long groupId, long resourceType, ItemKey classKey, object prototype)
		{
			this.CheckDBLock();
			string prototypeXml = this.GenerateXml(prototype);
			return this.mDataSource.InsertPrototype(name, groupId, resourceType, classKey, prototypeXml);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00006744 File Offset: 0x00005744
		public int UpdatePrototype(ItemKey updatedKey, ItemKey originalKey, ItemKey classKey, object prototype)
		{
			this.CheckDBLock();
			string prototypeXml = this.GenerateXml(prototype);
			return this.mDataSource.UpdatePrototype(updatedKey, originalKey, classKey, prototypeXml);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000676F File Offset: 0x0000576F
		public int DeleteInstance(ItemKey instanceKey)
		{
			this.CheckDBLock();
			return this.mDataSource.DeleteInstance(instanceKey);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00006783 File Offset: 0x00005783
		public ItemKey[][] ListCheckedOutChildrenForKey(ItemKey key)
		{
			return this.mDataSource.ListCheckedOutChildrenForKey(key);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00006791 File Offset: 0x00005791
		public Guid[] GetCurrentUserCheckouts()
		{
			return this.mDataSource.CheckoutsForCurrentUser();
		}

		// Token: 0x06000167 RID: 359 RVA: 0x000067A0 File Offset: 0x000057A0
		public string GetInstanceCheckoutUser(ItemKey instanceKey)
		{
			string instanceCheckoutUser = this.mDataSource.GetInstanceCheckoutUser(instanceKey);
			int num = instanceCheckoutUser.IndexOf("\\");
			if (num != -1)
			{
				return instanceCheckoutUser.Substring(num + 1);
			}
			return instanceCheckoutUser;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000067D5 File Offset: 0x000057D5
		public bool IsInstanceCheckedOut(ItemKey instanceKey)
		{
			return this.mDataSource.IsInstanceCheckOut(instanceKey);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000067E3 File Offset: 0x000057E3
		public DataStore.ErrorType SubmitItem(ItemKey item, string comment)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000067EC File Offset: 0x000057EC
		public List<ItemKey> SubmitInstances(List<ItemKey> instanceKeys, string comment)
		{
			List<ItemKey> list = new List<ItemKey>();
			foreach (ItemKey key in instanceKeys)
			{
				OpenObject openObject;
				if (this.mObjects.TryGetValue(key, out openObject) && this.Submit(openObject, comment))
				{
					list.Add(openObject.InstanceKey);
					this.mObjects.Remove(key);
					this.TryRemovePrototypes(openObject);
					this.OnInstanceRemoved(openObject.PrototypeKey, openObject.InstanceKey);
				}
			}
			if (list.Count > 0)
			{
				this.Save();
			}
			return list;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00006898 File Offset: 0x00005898
		public List<ItemKey> SubmitEverything(string comment)
		{
			List<ItemKey> list = new List<ItemKey>();
			foreach (OpenObject openObject in this.mObjects.Values)
			{
				if (this.Submit(openObject, comment))
				{
					list.Add(openObject.InstanceKey);
				}
			}
			if (list.Count == this.mObjects.Count)
			{
				this.mObjects.Clear();
				this.mPrototypes.Clear();
				this.OnInstancesCleared();
			}
			this.Save();
			return list;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000693C File Offset: 0x0000593C
		private bool Submit(OpenObject obj, string comment)
		{
			this.CheckDBLock();
			if (obj.InstanceObject is IPackageable)
			{
				IPackageable packageable = obj.InstanceObject as IPackageable;
				if (packageable.PackagerInfo.PackageId == Guid.Empty)
				{
					packageable.PackagerInfo.PackageId = Guid.NewGuid();
				}
			}
			if (obj.NewInstance)
			{
				if (this.InsertInstance(obj.InstanceKey.Name, obj.InstanceKey.GroupId, obj.InstanceKey.ResourceType, obj.PrototypeKey, obj.InstanceObject) > 0)
				{
					obj.InstanceKey = this.mDataSource.FindItemKey(obj.InstanceKey.Name, obj.InstanceKey.GroupId, obj.InstanceKey.ResourceType, ItemType.INSTANCE);
					try
					{
						this.mDataSource.CheckInInstance(obj.InstanceKey);
					}
					catch (RCSException ex)
					{
						this.mDataSource.RevertInstance(obj.InstanceKey);
						this.DeleteInstance(obj.InstanceKey);
						throw ex;
					}
					return true;
				}
			}
			else if (this.UpdateInstance(obj.InstanceKey, obj.OriginalInstanceKey, obj.PrototypeKey, obj.OriginalPrototypeKey, obj.InstanceObject) > 0)
			{
				this.mDataSource.CheckInInstance(obj.InstanceKey);
				return true;
			}
			return false;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00006A88 File Offset: 0x00005A88
		public void LoadClassDefinition(Assembly assembly)
		{
			if (assembly != null)
			{
				Type type = assembly.GetType(DataStore.kXmlAttributeType);
				if (type != null)
				{
					this.mXmlAttributeType = type;
				}
				Type type2 = assembly.GetType(DataStore.kCustomXmlInterface);
				if (type2 != null)
				{
					this.mCustomXmlInterface = type2;
				}
				Type[] exportedTypes = assembly.GetExportedTypes();
				foreach (Type type3 in exportedTypes)
				{
					ConstructorInfo constructor = type3.GetConstructor(Type.EmptyTypes);
					this.mMetadataTypes[type3] = constructor;
					this.mTypesByName[type3.FullName] = type3;
				}
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00006B14 File Offset: 0x00005B14
		public object CreateInstance(ItemKey prototypeKey)
		{
			return this.CreateInstance(prototypeKey, null);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00006B1E File Offset: 0x00005B1E
		public object CreateInstance(ItemKey prototypeKey, ItemKey instanceKey)
		{
			return this.CreateInstance(prototypeKey, instanceKey, null, null);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00006B2C File Offset: 0x00005B2C
		public object CreateInstance(ItemKey prototypeKey, ItemKey instanceKey, string protoXml, string instXml)
		{
			string classNameByPrototype = this.GetClassNameByPrototype(prototypeKey);
			Type metadataType;
			if (!this.mTypesByName.TryGetValue(classNameByPrototype, out metadataType))
			{
				this.OnClassNotFound(classNameByPrototype);
				return null;
			}
			string text = protoXml;
			if (text == null)
			{
				text = this.GetPrototypeData(prototypeKey);
			}
			if (instanceKey != null)
			{
				string text2 = instXml;
				if (text2 == null)
				{
					text2 = this.GetInstanceData(instanceKey);
				}
				return this.CreateInstanceInternal(metadataType, text, text2);
			}
			return this.CreateInstanceInternal(metadataType, text);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00006B8C File Offset: 0x00005B8C
		public object CreateInstanceFast(ObjectInstance instance)
		{
			Type metadataType;
			if (this.mTypesByName.TryGetValue(instance.DbPrototype.DbClass.ClassName, out metadataType))
			{
				return this.CreateInstanceInternal(metadataType, instance.DbPrototype.XmlData, instance.XmlData);
			}
			this.OnClassNotFound(instance.DbPrototype.DbClass.ClassName);
			return null;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00006BE8 File Offset: 0x00005BE8
		public object CreatePrototype(ItemKey key)
		{
			string text = "";
			string prototypeXml = "";
			if (key.KeyType == ItemType.PROTOTYPE)
			{
				text = this.GetClassNameByPrototype(key);
				prototypeXml = this.GetPrototypeData(key);
			}
			else if (key.KeyType == ItemType.CLASS)
			{
				ObjectClass objectClass = this.mDataSource.GetObjectClass(key);
				text = objectClass.ClassName;
				prototypeXml = "<data/>";
			}
			Type metadataType;
			if (this.mTypesByName.TryGetValue(text, out metadataType))
			{
				return this.CreatePrototypeInternal(metadataType, prototypeXml);
			}
			this.OnClassNotFound(text);
			return null;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00006C60 File Offset: 0x00005C60
		public object CreatePrototypeFast(ObjectPrototype prototype)
		{
			Type metadataType;
			if (this.mTypesByName.TryGetValue(prototype.DbClass.ClassName, out metadataType))
			{
				return this.CreatePrototypeInternal(metadataType, prototype.XmlData);
			}
			this.OnClassNotFound(prototype.DbClass.ClassName);
			return null;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00006CA8 File Offset: 0x00005CA8
		public object CreateInstance(ItemKey prototypeKey, string instanceXml)
		{
			string classNameByPrototype = this.GetClassNameByPrototype(prototypeKey);
			Type metadataType;
			if (this.mTypesByName.TryGetValue(classNameByPrototype, out metadataType))
			{
				string prototypeData = this.GetPrototypeData(prototypeKey);
				return this.CreateInstanceInternal(metadataType, prototypeData, instanceXml);
			}
			this.OnClassNotFound(classNameByPrototype);
			return null;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00006CE8 File Offset: 0x00005CE8
		public string GenerateXml(object instance)
		{
			Type type = instance.GetType();
			object[] customAttributes = type.GetCustomAttributes(this.mXmlAttributeType, true);
			if (customAttributes == null || customAttributes.Length == 0)
			{
				throw new ApplicationException("No XmlElementNameAttribute found.");
			}
			object prototypeProperty = DataStore.GetPrototypeProperty(instance, type);
			return this.GenerateXml(instance, customAttributes[0], prototypeProperty);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00006D30 File Offset: 0x00005D30
		public object CreateInstanceByInstanceKey(ItemKey instanceKey)
		{
			object result = null;
			ItemKey instancePrototypeKey = this.GetInstancePrototypeKey(instanceKey);
			bool flag = this.IsOpen(instanceKey);
			if (flag)
			{
				return this.OpenObjects[instanceKey].InstanceObject;
			}
			if (ContentCategoryHandler.GroupIdFlags((uint)instanceKey.GroupId) != 0U)
			{
				ItemKey itemKey = new ItemKey(instanceKey);
				itemKey.GroupId = (long)((ulong)ContentCategoryHandler.ClearGroupIdFlags((uint)itemKey.GroupId));
				flag = this.IsOpen(itemKey);
				if (flag)
				{
					return this.OpenObjects[itemKey].InstanceObject;
				}
			}
			if (!flag)
			{
				result = this.CreateInstance(instancePrototypeKey, instanceKey);
			}
			return result;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00006DBC File Offset: 0x00005DBC
		private object CreateInstanceInternal(Type metadataType, string prototypeXml, string instanceXml)
		{
			object obj = this.CreateInstanceInternal(metadataType, prototypeXml);
			if (obj != null && instanceXml != null)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(instanceXml);
				this.SetFromXml(obj, xmlDocument);
				return obj;
			}
			return null;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00006DF0 File Offset: 0x00005DF0
		private object CreateInstanceInternal(ItemKey prototypeKey, string prototypeXml, string instanceXml)
		{
			string classNameByPrototype = this.GetClassNameByPrototype(prototypeKey);
			Type metadataType;
			if (this.mTypesByName.TryGetValue(classNameByPrototype, out metadataType))
			{
				return this.CreateInstanceInternal(metadataType, prototypeXml, instanceXml);
			}
			this.OnClassNotFound(classNameByPrototype);
			return null;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00006E28 File Offset: 0x00005E28
		private object CreatePrototypeInternal(Type metadataType, string prototypeXml)
		{
			ConstructorInfo constructorInfo;
			if (this.mMetadataTypes.TryGetValue(metadataType, out constructorInfo))
			{
				object obj = constructorInfo.Invoke(Type.EmptyTypes);
				constructorInfo.Invoke(Type.EmptyTypes);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(prototypeXml);
				this.SetFromXml(obj, xmlDocument);
				return obj;
			}
			return null;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00006E78 File Offset: 0x00005E78
		private object CreateInstanceInternal(Type metadataType, string prototypeXml)
		{
			ConstructorInfo constructorInfo;
			if (this.mMetadataTypes.TryGetValue(metadataType, out constructorInfo))
			{
				object obj = constructorInfo.Invoke(Type.EmptyTypes);
				object obj2 = constructorInfo.Invoke(Type.EmptyTypes);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(prototypeXml);
				this.SetFromXml(obj, xmlDocument);
				this.SetFromXml(obj2, xmlDocument);
				this.SetPrototypeProperty(obj2, obj, metadataType);
				return obj2;
			}
			return null;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00006ED8 File Offset: 0x00005ED8
		private void SetFromXml(object obj, XmlDocument xmlDoc)
		{
			XmlElement documentElement = xmlDoc.DocumentElement;
			Type type = obj.GetType();
			object[] customAttributes = type.GetCustomAttributes(this.mXmlAttributeType, true);
			if (customAttributes != null && customAttributes.Length > 0)
			{
				string elementName = this.GetElementName(customAttributes[0]);
				if (elementName == documentElement.Name)
				{
					this.ReadXmlTree(obj, documentElement);
				}
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00006F2C File Offset: 0x00005F2C
		private string GetElementName(object attribute)
		{
			PropertyInfo property = attribute.GetType().GetProperty(DataStore.kXmlNameProperty, typeof(string));
			if (property != null)
			{
				return (string)property.GetValue(attribute, null);
			}
			return string.Empty;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00006F6C File Offset: 0x00005F6C
		private PropertyDescriptor FindPropertyDescriptor(object obj, XmlNode node)
		{
			Type type = obj.GetType();
			if (type == this.mCustomXmlInterface)
			{
				MethodInfo method = this.mCustomXmlInterface.GetMethod("GetPropertyDescriptor", BindingFlags.Instance | BindingFlags.Public);
				if (method != null)
				{
					return (PropertyDescriptor)method.Invoke(obj, new object[]
					{
						node
					});
				}
			}
			PropertyDescriptorCollection propertyDescriptorCollection = null;
			object[] customAttributes = type.GetCustomAttributes(typeof(TypeConverterAttribute), true);
			if (customAttributes != null && customAttributes.Length > 0)
			{
				TypeConverter converter = TypeDescriptor.GetConverter(type);
				if (converter != null && converter.GetPropertiesSupported())
				{
					propertyDescriptorCollection = converter.GetProperties(null, obj, null);
				}
			}
			if (propertyDescriptorCollection == null)
			{
				propertyDescriptorCollection = TypeDescriptor.GetProperties(obj);
			}
			foreach (object obj2 in propertyDescriptorCollection)
			{
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj2;
				foreach (object obj3 in propertyDescriptor.Attributes)
				{
					Attribute attribute = (Attribute)obj3;
					if (attribute.GetType() == this.mXmlAttributeType && this.GetElementName(attribute) == node.Name)
					{
						return propertyDescriptor;
					}
				}
			}
			return null;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000070C4 File Offset: 0x000060C4
		private Hashtable GetPropertyHashtable(object obj)
		{
			Hashtable hashtable = new Hashtable();
			Type type = obj.GetType();
			PropertyDescriptorCollection propertyDescriptorCollection = null;
			object[] customAttributes = type.GetCustomAttributes(typeof(TypeConverterAttribute), true);
			if (customAttributes != null && customAttributes.Length > 0)
			{
				TypeConverter converter = TypeDescriptor.GetConverter(type);
				if (converter != null && converter.GetPropertiesSupported())
				{
					propertyDescriptorCollection = converter.GetProperties(null, obj, null);
				}
			}
			if (propertyDescriptorCollection == null)
			{
				propertyDescriptorCollection = TypeDescriptor.GetProperties(obj);
			}
			foreach (object obj2 in propertyDescriptorCollection)
			{
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj2;
				hashtable[propertyDescriptor.DisplayName] = propertyDescriptor.GetValue(obj);
			}
			return hashtable;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00007184 File Offset: 0x00006184
		private object ReadXmlTree(object obj, XmlElement elem)
		{
			XmlNode xmlNode = elem.FirstChild;
			while (xmlNode != null)
			{
				PropertyDescriptor propertyDescriptor = this.FindPropertyDescriptor(obj, xmlNode);
				if (propertyDescriptor == null)
				{
					xmlNode = xmlNode.NextSibling;
				}
				else
				{
					Type propertyType = propertyDescriptor.PropertyType;
					TypeCode typeCode = Type.GetTypeCode(propertyType);
					DbDataLayerTypeDescriptorContext context = new DbDataLayerTypeDescriptorContext(obj);
					if (!propertyType.IsEnum)
					{
						goto IL_B5;
					}
					TypeConverter converter = TypeDescriptor.GetConverter(obj.GetType());
					if (converter == null || !converter.GetCreateInstanceSupported(context))
					{
						try
						{
							propertyDescriptor.SetValue(obj, Enum.Parse(propertyType, xmlNode.InnerText));
							goto IL_3DA;
						}
						catch (ArgumentException)
						{
							goto IL_3DA;
						}
						goto IL_B5;
					}
					Hashtable propertyHashtable = this.GetPropertyHashtable(obj);
					try
					{
						propertyHashtable[propertyDescriptor.DisplayName] = Enum.Parse(propertyType, xmlNode.InnerText);
					}
					catch (ArgumentException)
					{
					}
					obj = converter.CreateInstance(context, propertyHashtable);
					IL_3DA:
					xmlNode = xmlNode.NextSibling;
					continue;
					IL_B5:
					if (propertyType.IsPrimitive)
					{
						TypeConverter converter2 = TypeDescriptor.GetConverter(obj.GetType());
						if (converter2 != null && converter2.GetCreateInstanceSupported(context))
						{
							Hashtable propertyHashtable2 = this.GetPropertyHashtable(obj);
							propertyHashtable2[propertyDescriptor.DisplayName] = Convert.ChangeType(xmlNode.InnerText, propertyType);
							obj = converter2.CreateInstance(context, propertyHashtable2);
							goto IL_3DA;
						}
						propertyDescriptor.SetValue(obj, Convert.ChangeType(xmlNode.InnerText, propertyType));
						goto IL_3DA;
					}
					else
					{
						if (propertyType.Equals(typeof(Rect)))
						{
							SimIFaceRectConverter simIFaceRectConverter = new SimIFaceRectConverter();
							propertyDescriptor.SetValue(obj, simIFaceRectConverter.ConvertFrom(context, null, xmlNode.InnerText));
							goto IL_3DA;
						}
						if (typeCode == TypeCode.String)
						{
							propertyDescriptor.SetValue(obj, xmlNode.InnerText);
							goto IL_3DA;
						}
						if (propertyType.Equals(typeof(Guid)))
						{
							propertyDescriptor.SetValue(obj, new Guid(xmlNode.InnerText));
							goto IL_3DA;
						}
						if (propertyType.IsArray)
						{
							int num = (xmlNode.Attributes[DataStore.kCountAttribute] == null) ? 0 : int.Parse(xmlNode.Attributes[DataStore.kCountAttribute].Value);
							Type elementType = propertyType.GetElementType();
							TypeCode typeCode2 = Type.GetTypeCode(elementType);
							Array array = (Array)propertyDescriptor.GetValue(obj);
							if (array == null || array.Length < num)
							{
								Array array2 = Array.CreateInstance(elementType, num);
								if (array != null)
								{
									Array.Copy(array, array2, array.Length);
									int length = array.Length;
								}
								array = array2;
							}
							for (XmlNode xmlNode2 = xmlNode.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
							{
								Type type = elementType;
								if (xmlNode2.Attributes[DataStore.kCtorTypeAttribute] != null)
								{
									type = Type.GetType(xmlNode2.Attributes[DataStore.kCtorTypeAttribute].Value);
								}
								int index = int.Parse(xmlNode2.Attributes[DataStore.kIndexAttribute].Value);
								bool flag = bool.Parse(xmlNode2.Attributes[DataStore.kIsNullAttribute].Value);
								if (flag)
								{
									array.SetValue(null, index);
								}
								else if (elementType.IsEnum)
								{
									array.SetValue(Enum.Parse(elementType, xmlNode2.InnerText), index);
								}
								else if (elementType.IsPrimitive)
								{
									array.SetValue(Convert.ChangeType(xmlNode2.InnerText, elementType), index);
								}
								else if (typeCode2 == TypeCode.String)
								{
									array.SetValue(xmlNode2.InnerText, index);
								}
								else if (elementType.Equals(typeof(Guid)))
								{
									array.SetValue(new Guid(xmlNode2.InnerText), index);
								}
								else
								{
									try
									{
										object obj2 = array.GetValue(index);
										if (obj2 == null)
										{
											obj2 = Activator.CreateInstance(type, new object[0]);
										}
										array.SetValue(obj2, index);
										obj2 = this.ReadXmlTree(obj2, xmlNode2 as XmlElement);
										array.SetValue(obj2, index);
									}
									catch (Exception)
									{
									}
								}
							}
							propertyDescriptor.SetValue(obj, array);
							goto IL_3DA;
						}
						object value = propertyDescriptor.GetValue(obj);
						object value2 = this.ReadXmlTree(value, xmlNode as XmlElement);
						propertyDescriptor.SetValue(obj, value2);
						goto IL_3DA;
					}
				}
			}
			return obj;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000075A4 File Offset: 0x000065A4
		private void BuildXmlTreeForArray(XmlElement elem, XmlElement propElem, Array array, Array protoArray, string elementName, Type elemType, TypeCode elemTypeCode)
		{
			if (elementName.Length == 0)
			{
				return;
			}
			XmlAttribute xmlAttribute = elem.OwnerDocument.CreateAttribute(DataStore.kCountAttribute);
			xmlAttribute.Value = array.Length.ToString();
			propElem.Attributes.Append(xmlAttribute);
			for (int i = 0; i < array.Length; i++)
			{
				object value = array.GetValue(i);
				object obj = (protoArray == null) ? null : ((protoArray.Length > i) ? protoArray.GetValue(i) : null);
				if (value != obj && (value == null || !value.Equals(obj)))
				{
					XmlElement xmlElement = elem.OwnerDocument.CreateElement(elementName);
					XmlAttribute xmlAttribute2 = elem.OwnerDocument.CreateAttribute(DataStore.kIndexAttribute);
					XmlAttribute xmlAttribute3 = elem.OwnerDocument.CreateAttribute(DataStore.kIsNullAttribute);
					if (value.GetType() != elemType)
					{
						Type type = value.GetType();
						XmlAttribute xmlAttribute4 = elem.OwnerDocument.CreateAttribute(DataStore.kCtorTypeAttribute);
						xmlAttribute4.Value = type.AssemblyQualifiedName;
						xmlElement.Attributes.Append(xmlAttribute4);
					}
					xmlAttribute2.Value = i.ToString();
					xmlElement.Attributes.Append(xmlAttribute2);
					xmlElement.Attributes.Append(xmlAttribute3);
					propElem.AppendChild(xmlElement);
					if (value == null)
					{
						xmlAttribute3.Value = true.ToString();
					}
					else if (elemType.Equals(typeof(Guid)) || elemType.IsEnum || elemType.IsPrimitive || elemTypeCode == TypeCode.String)
					{
						xmlAttribute3.Value = false.ToString();
						xmlElement.InnerText = value.ToString();
					}
					else
					{
						xmlAttribute3.Value = false.ToString();
						this.BuildXmlTree(value, obj, xmlElement);
					}
				}
			}
			if (propElem.ChildNodes.Count == 0)
			{
				elem.RemoveChild(propElem);
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000777C File Offset: 0x0000677C
		private void BuildXmlTree(object instanceObj, object prototypeObj, XmlElement elem)
		{
			Type type = instanceObj.GetType();
			PropertyDescriptorCollection propertyDescriptorCollection = null;
			object[] customAttributes = type.GetCustomAttributes(typeof(TypeConverterAttribute), true);
			if (customAttributes != null && customAttributes.Length > 0)
			{
				TypeConverter converter = TypeDescriptor.GetConverter(type);
				if (converter != null && converter.GetPropertiesSupported())
				{
					propertyDescriptorCollection = converter.GetProperties(null, instanceObj, null);
				}
			}
			if (propertyDescriptorCollection == null)
			{
				propertyDescriptorCollection = TypeDescriptor.GetProperties(instanceObj);
			}
			if (propertyDescriptorCollection != null)
			{
				foreach (object obj in propertyDescriptorCollection)
				{
					PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
					Attribute attribute = null;
					foreach (object obj2 in propertyDescriptor.Attributes)
					{
						Attribute attribute2 = (Attribute)obj2;
						if (attribute2.GetType() == this.mXmlAttributeType)
						{
							attribute = attribute2;
							break;
						}
					}
					if (attribute != null)
					{
						Type propertyType = propertyDescriptor.PropertyType;
						object value = propertyDescriptor.GetValue(instanceObj);
						object obj3 = null;
						if (prototypeObj != null && propertyDescriptor.ComponentType == prototypeObj.GetType())
						{
							obj3 = propertyDescriptor.GetValue(prototypeObj);
						}
						if (value == null)
						{
							if (obj3 == null)
							{
								continue;
							}
						}
						else if (value.Equals(obj3))
						{
							continue;
						}
						TypeCode typeCode = Type.GetTypeCode(propertyType);
						XmlElement xmlElement = elem.OwnerDocument.CreateElement(this.GetElementName(attribute));
						elem.AppendChild(xmlElement);
						if (value != null)
						{
							if (propertyType.Equals(typeof(Guid)) || propertyType.Equals(typeof(Rect)) || propertyType.IsEnum || propertyType.IsPrimitive || typeCode == TypeCode.String)
							{
								xmlElement.InnerText = value.ToString();
							}
							else if (propertyType.IsArray)
							{
								Array array = (Array)value;
								Array protoArray = (Array)obj3;
								Type elementType = propertyType.GetElementType();
								TypeCode typeCode2 = Type.GetTypeCode(elementType);
								object[] customAttributes2 = propertyType.GetElementType().GetCustomAttributes(this.mXmlAttributeType, true);
								if (customAttributes2 != null && customAttributes2.Length > 0)
								{
									string elementName = this.GetElementName(customAttributes2[0]);
									if (elementName.Length != 0)
									{
										this.BuildXmlTreeForArray(elem, xmlElement, array, protoArray, elementName, elementType, typeCode2);
									}
								}
								else if (array != null && array.Length > 0 && (elementType.Equals(typeof(Guid)) || elementType.IsEnum || elementType.IsPrimitive || typeCode2 == TypeCode.String))
								{
									string elementName2 = elementType.ToString();
									this.BuildXmlTreeForArray(elem, xmlElement, array, protoArray, elementName2, elementType, typeCode2);
								}
								else
								{
									this.BuildXmlTree(value, obj3, xmlElement);
								}
							}
							else if (typeCode == TypeCode.Object)
							{
								this.BuildXmlTree(value, obj3, xmlElement);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00007A68 File Offset: 0x00006A68
		private string GenerateXml(object instance, object attr, object prototype)
		{
			XmlDocument xmlDocument = new XmlDocument();
			string elementName = this.GetElementName(attr);
			xmlDocument.LoadXml("<" + elementName + "/>");
			this.BuildXmlTree(instance, prototype, xmlDocument.DocumentElement);
			StringBuilder stringBuilder = new StringBuilder();
			StringWriterWithEncoding stringWriterWithEncoding = new StringWriterWithEncoding(stringBuilder, Encoding.UTF8);
			xmlDocument.Save(stringWriterWithEncoding);
			stringWriterWithEncoding.Close();
			return stringBuilder.ToString();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00007ACC File Offset: 0x00006ACC
		private static object GetPrototypeProperty(object instance, Type objType)
		{
			object result = null;
			PropertyInfo property = objType.GetProperty("Prototype", BindingFlags.Instance | BindingFlags.Public);
			if (property != null)
			{
				result = property.GetValue(instance, null);
			}
			return result;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00007AF8 File Offset: 0x00006AF8
		private void SetPrototypeProperty(object instanceObj, object prototypeObj, Type classType)
		{
			PropertyInfo property = classType.GetProperty(DataStore.kPrototypeProperty, BindingFlags.Instance | BindingFlags.Public);
			if (property != null)
			{
				property.SetValue(instanceObj, prototypeObj, new object[0]);
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00007B24 File Offset: 0x00006B24
		public bool IsLocked()
		{
			return this.mDataSource.IsLocked();
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00007B31 File Offset: 0x00006B31
		public string GetLockAdmin()
		{
			return this.mDataSource.GetLockAdmin();
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00007B3E File Offset: 0x00006B3E
		private void CheckDBLock()
		{
			if (this.mDataSource.IsLocked())
			{
				throw new DataStoreLockedOutException(this.mDataSource.GetLockAdmin());
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00007B60 File Offset: 0x00006B60
		public ItemKey Rename(ItemKey key, string newName)
		{
			OpenObject openObject;
			if (!this.mObjects.TryGetValue(key, out openObject))
			{
				return null;
			}
			ItemKey itemKey = new ItemKey(key);
			ItemKey itemKey2 = new ItemKey(key);
			itemKey2.Name = newName;
			bool flag = this.mObjects.TryGetValue(itemKey2, out openObject);
			bool flag2 = this.mDataSource.DoesItemKeyExist(itemKey2.Name, itemKey2.GroupId, itemKey2.ResourceType, itemKey2.KeyType);
			if (!flag && !flag2)
			{
				ItemKey prototypeKey = this.mObjects[key].PrototypeKey;
				this.mObjects[itemKey2] = this.mObjects[key];
				this.mObjects[itemKey2].InstanceKey.Name = newName;
				this.mObjects.Remove(itemKey);
				this.OnInstanceRemoved(prototypeKey, itemKey);
				this.OnInstanceAdded(prototypeKey, itemKey2);
				return itemKey2;
			}
			return null;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00007C34 File Offset: 0x00006C34
		public ItemKey Rename(ItemKey key, long newGroupId)
		{
			OpenObject openObject;
			if (!this.mObjects.TryGetValue(key, out openObject))
			{
				return null;
			}
			ItemKey itemKey = new ItemKey(key);
			ItemKey itemKey2 = new ItemKey(key);
			itemKey2.GroupId = newGroupId;
			bool flag = this.mObjects.TryGetValue(itemKey2, out openObject);
			bool flag2 = this.mDataSource.GetInstance(itemKey2) != null;
			if (!flag && !flag2)
			{
				ItemKey prototypeKey = this.mObjects[key].PrototypeKey;
				this.mObjects[itemKey2] = this.mObjects[key];
				this.mObjects[itemKey2].InstanceKey.GroupId = newGroupId;
				this.mObjects.Remove(itemKey);
				this.OnInstanceRemoved(prototypeKey, itemKey);
				this.OnInstanceAdded(prototypeKey, itemKey2);
				return itemKey2;
			}
			return null;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00007CF8 File Offset: 0x00006CF8
		public bool ChangePrototype(ItemKey key, ItemKey newPrototype, object newInstanceObject)
		{
			OpenObject openObject;
			if (!this.mObjects.TryGetValue(key, out openObject))
			{
				return false;
			}
			if (!openObject.PrototypeKey.Equals(openObject.OriginalPrototypeKey))
			{
				return false;
			}
			string prototypeData = this.GetPrototypeData(newPrototype);
			PersistedPrototype persistedPrototype;
			if (!this.mPrototypes.TryGetValue(newPrototype, out persistedPrototype))
			{
				this.mPrototypes.Add(newPrototype, new PersistedPrototype(newPrototype, prototypeData));
			}
			this.mObjects[key].PrototypeKey = newPrototype;
			this.mObjects[key].InstanceObject = newInstanceObject;
			this.OnInstanceRemoved(this.mObjects[key].OriginalPrototypeKey, key);
			this.OnInstanceAdded(this.mObjects[key].PrototypeKey, key);
			return true;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00007DAC File Offset: 0x00006DAC
		private void SaveInstances()
		{
			SerializableDictionary<ItemKey, PersistedObject> serializableDictionary = new SerializableDictionary<ItemKey, PersistedObject>();
			foreach (OpenObject openObject in this.mObjects.Values)
			{
				serializableDictionary[openObject.InstanceKey] = new PersistedObject(openObject, this);
			}
			this.mDataSource.SaveInstances(serializableDictionary);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00007E24 File Offset: 0x00006E24
		public void SyncEntireDatabaseToDisk()
		{
			try
			{
				string allInstancesXml = this.mDataSource.GetAllInstancesXml();
				StreamWriter streamWriter = new StreamWriter("C:\\DbOnDisk.xml", false);
				if (streamWriter != null)
				{
					streamWriter.Write(allInstancesXml);
					streamWriter.Close();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00007E70 File Offset: 0x00006E70
		private void LoadInstances()
		{
			Dictionary<ItemKey, PersistedObject> dictionary = this.mDataSource.LoadInstances();
			this.mObjects.Clear();
			this.OnInstancesCleared();
			foreach (PersistedObject persistedObject in dictionary.Values)
			{
				PersistedPrototype persistedPrototype = this.mPrototypes[persistedObject.PrototypeKey];
				object obj;
				if (persistedPrototype != null)
				{
					obj = this.CreateInstanceInternal(persistedObject.PrototypeKey, persistedPrototype.PrototypeXml, persistedObject.InstanceXml.InnerXml);
				}
				else
				{
					obj = this.CreateInstance(persistedObject.PrototypeKey, persistedObject.InstanceXmlString);
				}
				if (obj != null)
				{
					OpenObject value = new OpenObject(persistedObject.PrototypeKey, persistedObject.OriginalPrototypeKey, persistedObject.InstanceKey, persistedObject.OriginalInstanceKey, obj, persistedObject.NewInstance);
					this.mObjects[persistedObject.InstanceKey] = value;
					this.OnInstanceAdded(persistedObject.PrototypeKey, persistedObject.InstanceKey);
				}
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00007F78 File Offset: 0x00006F78
		public void Save()
		{
			this.SavePrototypes();
			this.SaveInstances();
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00007F86 File Offset: 0x00006F86
		public void Load()
		{
			this.LoadPrototypes();
			this.LoadInstances();
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00007F94 File Offset: 0x00006F94
		private void SavePrototypes()
		{
			this.mDataSource.SavePrototypes(this.mPrototypes);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00007FA7 File Offset: 0x00006FA7
		private void LoadPrototypes()
		{
			this.mPrototypes = this.mDataSource.LoadPrototypes();
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00007FBC File Offset: 0x00006FBC
		public bool IsOpen(ItemKey instanceKey)
		{
			ItemKey itemKey;
			return this.IsOpen(instanceKey, out itemKey);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00007FD4 File Offset: 0x00006FD4
		public bool IsOpen(ItemKey instanceKey, out ItemKey currentKey)
		{
			OpenObject openObject;
			if (this.mObjects.TryGetValue(instanceKey, out openObject))
			{
				currentKey = instanceKey;
				return true;
			}
			foreach (OpenObject openObject2 in this.mObjects.Values)
			{
				if (openObject2.OriginalInstanceKey.Equals(instanceKey))
				{
					currentKey = openObject2.InstanceKey;
					return true;
				}
			}
			currentKey = null;
			return false;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000805C File Offset: 0x0000705C
		public bool IsNew(ItemKey instanceKey)
		{
			OpenObject openObject;
			return this.mObjects.TryGetValue(instanceKey, out openObject) && openObject.NewInstance;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00008084 File Offset: 0x00007084
		public DataStore.ErrorType OpenInstance(ItemKey prototypeKey, ItemKey instanceKey, object instance, bool newInstance, bool checkout)
		{
			if (checkout)
			{
				this.CheckDBLock();
			}
			object obj = instance;
			if (checkout && !newInstance)
			{
				this.mDataSource.CheckOutInstance(instanceKey);
				obj = this.CreateInstanceByInstanceKey(instanceKey);
				instance = obj;
			}
			this.mObjects[instanceKey] = new OpenObject(prototypeKey, prototypeKey, instanceKey, instanceKey, obj, newInstance);
			string prototypeData = this.GetPrototypeData(prototypeKey);
			PersistedPrototype persistedPrototype;
			if (!this.mPrototypes.TryGetValue(prototypeKey, out persistedPrototype))
			{
				this.mPrototypes.Add(prototypeKey, new PersistedPrototype(prototypeKey, prototypeData));
			}
			this.OnInstanceAdded(prototypeKey, instanceKey);
			this.Save();
			return DataStore.ErrorType.ERR_OK;
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00008110 File Offset: 0x00007110
		public DataStore.ErrorType UndoEdit(ItemKey instanceKey, out ItemKey originalPrototypeKey)
		{
			originalPrototypeKey = null;
			this.CheckDBLock();
			OpenObject openObject;
			if (this.mObjects.TryGetValue(instanceKey, out openObject))
			{
				originalPrototypeKey = openObject.OriginalPrototypeKey;
				this.mDataSource.RevertInstance(openObject.OriginalInstanceKey);
				this.mObjects.Remove(instanceKey);
				this.TryRemovePrototypes(openObject);
				this.OnInstanceRemoved(openObject.PrototypeKey, instanceKey);
				this.Save();
			}
			return DataStore.ErrorType.ERR_OK;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00008178 File Offset: 0x00007178
		private void TryRemovePrototypes(OpenObject owner)
		{
			this.TryRemovePrototype(owner.PrototypeKey);
			if (!owner.PrototypeKey.Equals(owner.OriginalPrototypeKey))
			{
				this.TryRemovePrototype(owner.OriginalPrototypeKey);
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x000081A8 File Offset: 0x000071A8
		private void TryRemovePrototype(ItemKey prototypeKey)
		{
			foreach (OpenObject openObject in this.mObjects.Values)
			{
				if (openObject.PrototypeKey.Equals(prototypeKey) || openObject.OriginalPrototypeKey.Equals(prototypeKey))
				{
					return;
				}
			}
			this.mPrototypes.Remove(prototypeKey);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00008224 File Offset: 0x00007224
		private void OnInstanceAdded(ItemKey prototypeKey, ItemKey instanceKey)
		{
			if (this.InstanceAdded != null)
			{
				this.InstanceAdded(this, new InstanceEventArgs(prototypeKey, instanceKey));
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00008241 File Offset: 0x00007241
		private void OnInstanceRemoved(ItemKey prototypeKey, ItemKey instanceKey)
		{
			if (this.InstanceRemoved != null)
			{
				this.InstanceRemoved(this, new InstanceEventArgs(prototypeKey, instanceKey));
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000825E File Offset: 0x0000725E
		private void OnInstancesCleared()
		{
			if (this.InstancesCleared != null)
			{
				this.InstancesCleared(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00008279 File Offset: 0x00007279
		private void OnClassNotFound(string className)
		{
			if (this.ClassNotFound != null)
			{
				this.ClassNotFound(this, className);
			}
		}

		// Token: 0x04000040 RID: 64
		private static DataStore mDataStore = null;

		// Token: 0x04000041 RID: 65
		private Dictionary<ItemKey, ObjectClass> mClassesDict = new Dictionary<ItemKey, ObjectClass>();

		// Token: 0x04000042 RID: 66
		private Dictionary<ItemKey, ObjectPrototype> mPrototypesDict = new Dictionary<ItemKey, ObjectPrototype>();

		// Token: 0x04000043 RID: 67
		private Dictionary<ItemKey, ObjectInstance> mInstanceDict = new Dictionary<ItemKey, ObjectInstance>();

		// Token: 0x04000044 RID: 68
		private Dictionary<ItemKey, OpenObject> mObjects = new Dictionary<ItemKey, OpenObject>();

		// Token: 0x04000045 RID: 69
		private SerializableDictionary<ItemKey, PersistedPrototype> mPrototypes = new SerializableDictionary<ItemKey, PersistedPrototype>();

		// Token: 0x04000046 RID: 70
		private bool mInitialized;

		// Token: 0x04000047 RID: 71
		private bool mIsFileDataSource;

		// Token: 0x04000048 RID: 72
		private IDataSource mDataSource;

		// Token: 0x04000049 RID: 73
		private AsyncWorker[] backgroundWorkersList = new AsyncWorker[]
		{
			new AsyncWorker()
		};

		// Token: 0x0400004A RID: 74
		private uint mAsyncTimeOut = 15000U;

		// Token: 0x0400004B RID: 75
		private XmlDocument mConfigDoc;

		// Token: 0x0400004C RID: 76
		private Type mXmlAttributeType;

		// Token: 0x0400004D RID: 77
		private Type mCustomXmlInterface;

		// Token: 0x0400004E RID: 78
		private Dictionary<Type, ConstructorInfo> mMetadataTypes = new Dictionary<Type, ConstructorInfo>();

		// Token: 0x0400004F RID: 79
		private Dictionary<string, Type> mTypesByName = new Dictionary<string, Type>();

		// Token: 0x04000050 RID: 80
		private static readonly string kCountAttribute = "count";

		// Token: 0x04000051 RID: 81
		private static readonly string kCtorTypeAttribute = "ctorType";

		// Token: 0x04000052 RID: 82
		private static readonly string kIndexAttribute = "index";

		// Token: 0x04000053 RID: 83
		private static readonly string kIsNullAttribute = "isnull";

		// Token: 0x04000054 RID: 84
		private static readonly string kPrototypeProperty = "Prototype";

		// Token: 0x04000055 RID: 85
		private static readonly string kXmlNameProperty = "XmlName";

		// Token: 0x04000056 RID: 86
		private static readonly string kXmlAttributeType = "Sims3.SimIFace.XmlElementNameAttribute";

		// Token: 0x04000057 RID: 87
		private static readonly string kCustomXmlInterface = "Sims3.SimIFace.ICustomXMLHandler";

		// Token: 0x02000018 RID: 24
		public enum ErrorType
		{
			// Token: 0x0400005F RID: 95
			ERR_OK,
			// Token: 0x04000060 RID: 96
			ERR_ALREADY_CHECKED_OUT
		}

		// Token: 0x02000019 RID: 25
		// (Invoke) Token: 0x060001A0 RID: 416
		public delegate void GetItemKeyListCompletedHandler(object source, List<ItemKey> args);
	}
}
