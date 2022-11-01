using System;
using System.Data;
using System.Xml.Serialization;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000005 RID: 5
	[XmlType(TypeName = "DBInstance")]
	[Serializable]
	public class ObjectInstance : ItemKey
	{
		// Token: 0x0600001F RID: 31 RVA: 0x000024FC File Offset: 0x000014FC
		public static ObjectInstance Parse(IDataReader sqlrdr, bool HasXml, bool Joined)
		{
			ObjectInstance objectInstance = new ObjectInstance();
			objectInstance.Name = (string)sqlrdr["InstanceName"];
			objectInstance.GroupId = (long)sqlrdr["InstanceGroupId"];
			objectInstance.ResourceType = (long)sqlrdr["ResourceType"];
			objectInstance.Id = (long)sqlrdr["InstanceId"];
			objectInstance.Deleted = (sqlrdr["InstanceDeleted"] != DBNull.Value && (bool)sqlrdr["InstanceDeleted"]);
			objectInstance.KeyType = ItemType.INSTANCE;
			object obj = sqlrdr["InstanceCheckoutId"];
			if (obj == DBNull.Value)
			{
				objectInstance.CheckoutId = Guid.Empty;
			}
			else
			{
				objectInstance.CheckoutId = (Guid)sqlrdr["InstanceCheckoutId"];
			}
			if (HasXml)
			{
				objectInstance.XmlData = (string)sqlrdr["InstanceXmlData"];
			}
			if (Joined)
			{
				objectInstance.DbPrototype = ObjectPrototype.Parse(sqlrdr, HasXml, true);
			}
			else
			{
				ObjectPrototype objectPrototype = new ObjectPrototype();
				objectInstance.DbPrototype = objectPrototype;
				objectPrototype.Name = (string)sqlrdr["PrototypeName"];
				objectPrototype.GroupId = (long)sqlrdr["PrototypeGroupId"];
			}
			return objectInstance;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002636 File Offset: 0x00001636
		// (set) Token: 0x06000021 RID: 33 RVA: 0x0000263E File Offset: 0x0000163E
		[XmlElement(ElementName = "DBPrototype")]
		public ObjectPrototype DbPrototype
		{
			get
			{
				return this.dBPrototypeField;
			}
			set
			{
				this.dBPrototypeField = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002647 File Offset: 0x00001647
		// (set) Token: 0x06000023 RID: 35 RVA: 0x0000264F File Offset: 0x0000164F
		public string XmlData
		{
			get
			{
				return this.mXmlDataField;
			}
			set
			{
				this.mXmlDataField = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002658 File Offset: 0x00001658
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002660 File Offset: 0x00001660
		public Guid CheckoutId
		{
			get
			{
				return this.mCheckoutId;
			}
			set
			{
				this.mCheckoutId = value;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002669 File Offset: 0x00001669
		public ObjectInstance() : base(ItemType.INSTANCE)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002672 File Offset: 0x00001672
		public ObjectInstance(ItemKey instanceKey) : base(instanceKey)
		{
		}

		// Token: 0x04000010 RID: 16
		private ObjectPrototype dBPrototypeField;

		// Token: 0x04000011 RID: 17
		private string mXmlDataField;

		// Token: 0x04000012 RID: 18
		private Guid mCheckoutId;
	}
}
