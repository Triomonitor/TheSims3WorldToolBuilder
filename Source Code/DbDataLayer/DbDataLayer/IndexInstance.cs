using System;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200007D RID: 125
	public class IndexInstance
	{
		// Token: 0x06000415 RID: 1045 RVA: 0x0000CD15 File Offset: 0x0000BD15
		public IndexInstance()
		{
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0000CD1D File Offset: 0x0000BD1D
		public IndexInstance(ItemKey instanceKey, long prototypeId, DateTime timestamp) : this()
		{
			this.mInstanceKey = instanceKey;
			this.mPrototypeId = prototypeId;
			this.mTimeStamp = timestamp;
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0000CD3A File Offset: 0x0000BD3A
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x0000CD42 File Offset: 0x0000BD42
		public ItemKey InstanceKey
		{
			get
			{
				return this.mInstanceKey;
			}
			set
			{
				this.mInstanceKey = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000CD4B File Offset: 0x0000BD4B
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x0000CD53 File Offset: 0x0000BD53
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

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600041B RID: 1051 RVA: 0x0000CD5C File Offset: 0x0000BD5C
		// (set) Token: 0x0600041C RID: 1052 RVA: 0x0000CD64 File Offset: 0x0000BD64
		public DateTime TimeStamp
		{
			get
			{
				return this.mTimeStamp;
			}
			set
			{
				this.mTimeStamp = value;
			}
		}

		// Token: 0x04000108 RID: 264
		private ItemKey mInstanceKey;

		// Token: 0x04000109 RID: 265
		private long mPrototypeId;

		// Token: 0x0400010A RID: 266
		private DateTime mTimeStamp;
	}
}
