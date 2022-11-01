using System;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000014 RID: 20
	public class InstanceEventArgs : EventArgs
	{
		// Token: 0x06000118 RID: 280 RVA: 0x00005BF7 File Offset: 0x00004BF7
		public InstanceEventArgs(ItemKey prototypeKey, ItemKey instanceKey)
		{
			this.mPrototypeKey = prototypeKey;
			this.mInstanceKey = instanceKey;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00005C0D File Offset: 0x00004C0D
		public ItemKey PrototypeKey
		{
			get
			{
				return this.mPrototypeKey;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00005C15 File Offset: 0x00004C15
		public ItemKey InstanceKey
		{
			get
			{
				return this.mInstanceKey;
			}
		}

		// Token: 0x0400003E RID: 62
		private ItemKey mPrototypeKey;

		// Token: 0x0400003F RID: 63
		private ItemKey mInstanceKey;
	}
}
