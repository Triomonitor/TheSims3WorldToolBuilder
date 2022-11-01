using System;
using System.Data;
using System.Xml.Serialization;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000006 RID: 6
	[XmlType(TypeName = "DBPrototype")]
	[Serializable]
	public class ObjectPrototype : ItemKey
	{
		// Token: 0x06000028 RID: 40 RVA: 0x0000267C File Offset: 0x0000167C
		public static ObjectPrototype Parse(IDataReader sqlrdr, bool HasXml, bool Joined)
		{
			ObjectPrototype objectPrototype = new ObjectPrototype();
			objectPrototype.Name = (string)sqlrdr["PrototypeName"];
			objectPrototype.GroupId = (long)sqlrdr["PrototypeGroupId"];
			objectPrototype.ResourceType = (long)sqlrdr["ResourceType"];
			objectPrototype.KeyType = ItemType.PROTOTYPE;
			objectPrototype.Deleted = (sqlrdr["PrototypeDeleted"] != DBNull.Value && (bool)sqlrdr["PrototypeDeleted"]);
			objectPrototype.Id = (long)sqlrdr["PrototypeId"];
			if (HasXml)
			{
				objectPrototype.XmlData = (string)sqlrdr["PrototypeXmlData"];
			}
			if (Joined)
			{
				objectPrototype.DbClass = ObjectClass.Parse(sqlrdr);
			}
			return objectPrototype;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002742 File Offset: 0x00001742
		// (set) Token: 0x0600002A RID: 42 RVA: 0x0000274A File Offset: 0x0000174A
		[XmlElement(ElementName = "DBClass")]
		public ObjectClass DbClass
		{
			get
			{
				return this.mDbClassField;
			}
			set
			{
				this.mDbClassField = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002753 File Offset: 0x00001753
		// (set) Token: 0x0600002C RID: 44 RVA: 0x0000275B File Offset: 0x0000175B
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

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002764 File Offset: 0x00001764
		// (set) Token: 0x0600002E RID: 46 RVA: 0x0000276C File Offset: 0x0000176C
		public bool CheckedOut
		{
			get
			{
				return this.mCheckedOut;
			}
			set
			{
				this.mCheckedOut = value;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002775 File Offset: 0x00001775
		public ObjectPrototype() : base(ItemType.PROTOTYPE)
		{
		}

		// Token: 0x04000013 RID: 19
		private ObjectClass mDbClassField;

		// Token: 0x04000014 RID: 20
		private string mXmlDataField;

		// Token: 0x04000015 RID: 21
		private bool mCheckedOut;
	}
}
