using System;
using System.Collections.Generic;
using System.Xml;
using Sims3.Collections;
using Sims3.DbDataLayer.Sims3WebService;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000005 RID: 5
	internal interface IDataSource
	{
		// Token: 0x0600002B RID: 43
		void LoadConfig(XmlElement element, string assetRoot);

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002C RID: 44
		// (set) Token: 0x0600002D RID: 45
		string DataPath { get; set; }

		// Token: 0x0600002E RID: 46
		bool Connect(params object[] args);

		// Token: 0x0600002F RID: 47
		void Initialize();

		// Token: 0x06000030 RID: 48
		bool Disconnect();

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000031 RID: 49
		string ConnectionInfo { get; }

		// Token: 0x06000032 RID: 50
		bool Sync();

		// Token: 0x06000033 RID: 51
		bool IsSyncable();

		// Token: 0x06000034 RID: 52
		bool IsOnline();

		// Token: 0x06000035 RID: 53
		DateTime LastSync();

		// Token: 0x06000036 RID: 54
		DBItemInfo[] GetDatabaseItemTree();

		// Token: 0x06000037 RID: 55
		DBItemInfo[] GetSKUBasedDatabaseItemTree();

		// Token: 0x06000038 RID: 56
		List<ItemKey> GetClassesList();

		// Token: 0x06000039 RID: 57
		List<ItemKey> GetPrototypesList();

		// Token: 0x0600003A RID: 58
		List<ObjectInstance> GetInstancesOfPrototype(ItemKey prototype);

		// Token: 0x0600003B RID: 59
		List<ItemKey> GetInstanceKeysOfPrototype(ItemKey key);

		// Token: 0x0600003C RID: 60
		List<ItemKey> GetInstanceKeysOfClassKey(ItemKey classKey);

		// Token: 0x0600003D RID: 61
		List<ObjectInstance> GetInstancesForClassKey(ItemKey classKey);

		// Token: 0x0600003E RID: 62
		ItemKey GetInstancePrototypeKey(ItemKey instanceKey);

		// Token: 0x0600003F RID: 63
		List<ItemKey> GetPrototypeKeysOfClass(ItemKey classKey);

		// Token: 0x06000040 RID: 64
		string GetPrototypeData(ItemKey item);

		// Token: 0x06000041 RID: 65
		ObjectClass GetObjectClassByPrototype(ItemKey prototypeKey);

		// Token: 0x06000042 RID: 66
		string GetClassNameByPrototype(ItemKey key);

		// Token: 0x06000043 RID: 67
		long GetClassResourceTypeFromPrototype(ItemKey key);

		// Token: 0x06000044 RID: 68
		ObjectClass GetObjectClass(ItemKey classKey);

		// Token: 0x06000045 RID: 69
		ObjectInstance GetInstance(ItemKey instanceKey);

		// Token: 0x06000046 RID: 70
		string GetInstanceData(ItemKey item);

		// Token: 0x06000047 RID: 71
		string GetAllInstancesXml();

		// Token: 0x06000048 RID: 72
		List<ObjectInstance> GetAllInstances();

		// Token: 0x06000049 RID: 73
		List<ObjectInstance> GetAllInstancesByDate(DateTime dateTime);

		// Token: 0x0600004A RID: 74
		IList<ObjectPrototype> GetAllPrototypes();

		// Token: 0x0600004B RID: 75
		List<ItemKey> GetInstancesByReference(ItemKey instanceKey);

		// Token: 0x0600004C RID: 76
		bool DoesItemKeyExist(string name, long groupId, long resourceType, ItemType itemType);

		// Token: 0x0600004D RID: 77
		ItemKey FindItemKey(string name, long groupId, long resourceType, ItemType itemType);

		// Token: 0x0600004E RID: 78
		string GetInstanceFilePath(ItemKey instanceKey);

		// Token: 0x0600004F RID: 79
		Guid CheckOutInstance(ItemKey item);

		// Token: 0x06000050 RID: 80
		Guid CheckOutPrototype(ItemKey item);

		// Token: 0x06000051 RID: 81
		void CheckInInstance(ItemKey item);

		// Token: 0x06000052 RID: 82
		Guid[] CheckoutsForCurrentUser();

		// Token: 0x06000053 RID: 83
		void CheckInPrototype(ItemKey item);

		// Token: 0x06000054 RID: 84
		bool IsInstanceCheckOut(ItemKey instanceKey);

		// Token: 0x06000055 RID: 85
		string GetInstanceCheckoutUser(ItemKey instanceKey);

		// Token: 0x06000056 RID: 86
		ItemKey[][] ListCheckedOutChildrenForKey(ItemKey key);

		// Token: 0x06000057 RID: 87
		int DeleteInstance(ItemKey theInstance);

		// Token: 0x06000058 RID: 88
		int DeletePrototype(ItemKey theInstance);

		// Token: 0x06000059 RID: 89
		bool RevertInstance(ItemKey instanceKey);

		// Token: 0x0600005A RID: 90
		bool RevertPrototype(ItemKey prototypeKey);

		// Token: 0x0600005B RID: 91
		int InsertInstance(string name, long groupId, long resourceType, ItemKey prototypeKey, string instanceXml);

		// Token: 0x0600005C RID: 92
		int UpdateInstance(ItemKey updatedKey, ItemKey originalKey, ItemKey updatedPrototypeKey, ItemKey originalPrototypeKey, string instanceXml);

		// Token: 0x0600005D RID: 93
		int InsertPrototype(string name, long groupId, long resourceType, ItemKey classKey, string prototypeXml);

		// Token: 0x0600005E RID: 94
		int UpdatePrototype(ItemKey updatedKey, ItemKey originalKey, ItemKey classKey, string prototypeXml);

		// Token: 0x0600005F RID: 95
		void SaveInstances(SerializableDictionary<ItemKey, PersistedObject> objects);

		// Token: 0x06000060 RID: 96
		void SavePrototypes(SerializableDictionary<ItemKey, PersistedPrototype> prototypes);

		// Token: 0x06000061 RID: 97
		SerializableDictionary<ItemKey, PersistedObject> LoadInstances();

		// Token: 0x06000062 RID: 98
		SerializableDictionary<ItemKey, PersistedPrototype> LoadPrototypes();

		// Token: 0x06000063 RID: 99
		bool IsLocked();

		// Token: 0x06000064 RID: 100
		string GetLockAdmin();
	}
}
