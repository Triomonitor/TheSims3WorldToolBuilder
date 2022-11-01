using System;
using System.Data;
using System.Xml.Serialization;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000004 RID: 4
	[XmlType(TypeName = "DBClass")]
	[Serializable]
	public class ObjectClass : ItemKey
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00002404 File Offset: 0x00001404
		public new static ObjectClass Parse(IDataReader sqlrdr)
		{
			return new ObjectClass
			{
				Name = (string)sqlrdr["ClassName"],
				GroupId = (long)sqlrdr["ClassGroupId"],
				ResourceType = (long)sqlrdr["ResourceType"],
				Id = (long)sqlrdr["ClassId"],
				Deleted = (sqlrdr["ClassDeleted"] != DBNull.Value && (bool)sqlrdr["ClassDeleted"]),
				AssemblyName = (string)sqlrdr["ClassAssemblyName"],
				ClassName = (string)sqlrdr["ClassDef"],
				KeyType = ItemType.CLASS
			};
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000024CE File Offset: 0x000014CE
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000024D6 File Offset: 0x000014D6
		public string AssemblyName
		{
			get
			{
				return this.mAssemblyNameField;
			}
			set
			{
				this.mAssemblyNameField = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000024DF File Offset: 0x000014DF
		// (set) Token: 0x0600001D RID: 29 RVA: 0x000024E7 File Offset: 0x000014E7
		public string ClassName
		{
			get
			{
				return this.mClassNameField;
			}
			set
			{
				this.mClassNameField = value;
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000024F0 File Offset: 0x000014F0
		public ObjectClass() : base(ItemType.CLASS)
		{
		}

		// Token: 0x0400000E RID: 14
		private string mAssemblyNameField;

		// Token: 0x0400000F RID: 15
		private string mClassNameField;
	}
}
