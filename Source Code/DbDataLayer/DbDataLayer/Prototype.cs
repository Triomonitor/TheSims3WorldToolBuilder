using System;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000080 RID: 128
	public class Prototype
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x0000D42D File Offset: 0x0000C42D
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x0000D435 File Offset: 0x0000C435
		public ItemKey ItemKey
		{
			get
			{
				return this.mItemKey;
			}
			set
			{
				this.mItemKey = value;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x0000D43E File Offset: 0x0000C43E
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x0000D446 File Offset: 0x0000C446
		public XmlString PrototypeXml
		{
			get
			{
				return this.mPrototypeXml;
			}
			set
			{
				this.mPrototypeXml = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0000D44F File Offset: 0x0000C44F
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x0000D457 File Offset: 0x0000C457
		public long ClassId
		{
			get
			{
				return this.mClassId;
			}
			set
			{
				this.mClassId = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x0000D460 File Offset: 0x0000C460
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x0000D468 File Offset: 0x0000C468
		public string ClassName
		{
			get
			{
				return this.mClassName;
			}
			set
			{
				this.mClassName = value;
			}
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0000D471 File Offset: 0x0000C471
		public void SetXmlString(string xmlString)
		{
			this.mPrototypeXml.SetXmlString(xmlString);
		}

		// Token: 0x04000110 RID: 272
		private ItemKey mItemKey;

		// Token: 0x04000111 RID: 273
		private string mClassName = string.Empty;

		// Token: 0x04000112 RID: 274
		private long mClassId = -1L;

		// Token: 0x04000113 RID: 275
		private XmlString mPrototypeXml = new XmlString();
	}
}
