using System;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000003 RID: 3
	public class Instance
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002AEB File Offset: 0x00001AEB
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002AF3 File Offset: 0x00001AF3
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

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002AFC File Offset: 0x00001AFC
		// (set) Token: 0x0600001E RID: 30 RVA: 0x00002B04 File Offset: 0x00001B04
		public string PrototypeName
		{
			get
			{
				return this.mPrototypeName;
			}
			set
			{
				this.mPrototypeName = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002B0D File Offset: 0x00001B0D
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00002B15 File Offset: 0x00001B15
		public long PrototypeId
		{
			get
			{
				return this.mPrototypeId;
			}
			set
			{
				this.mPrototypeId = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002B1E File Offset: 0x00001B1E
		// (set) Token: 0x06000022 RID: 34 RVA: 0x00002B26 File Offset: 0x00001B26
		public XmlString InstanceXml
		{
			get
			{
				return this.mInstanceXml;
			}
			set
			{
				this.mInstanceXml = value;
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002B2F File Offset: 0x00001B2F
		public void SetXmlString(string xmlString)
		{
			this.mInstanceXml.SetXmlString(xmlString);
		}

		// Token: 0x04000009 RID: 9
		private ItemKey mItemKey;

		// Token: 0x0400000A RID: 10
		private string mPrototypeName = string.Empty;

		// Token: 0x0400000B RID: 11
		private long mPrototypeId = -1L;

		// Token: 0x0400000C RID: 12
		private XmlString mInstanceXml = new XmlString();
	}
}
