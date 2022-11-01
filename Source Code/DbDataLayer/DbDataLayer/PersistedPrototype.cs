using System;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200001C RID: 28
	[Serializable]
	public class PersistedPrototype
	{
		// Token: 0x060001C0 RID: 448 RVA: 0x000084FC File Offset: 0x000074FC
		public PersistedPrototype()
		{
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00008504 File Offset: 0x00007504
		public PersistedPrototype(ItemKey prototypeKey, string prototypeXml)
		{
			this.mPrototypeKey = prototypeKey;
			this.mPrototypeXml = prototypeXml;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000851A File Offset: 0x0000751A
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x00008522 File Offset: 0x00007522
		public ItemKey PrototypeKey
		{
			get
			{
				return this.mPrototypeKey;
			}
			set
			{
				this.mPrototypeKey = value;
				this.mPrototypeKey.KeyType = ItemType.PROTOTYPE;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00008537 File Offset: 0x00007537
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x0000853F File Offset: 0x0000753F
		public string PrototypeXml
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

		// Token: 0x0400006D RID: 109
		private ItemKey mPrototypeKey;

		// Token: 0x0400006E RID: 110
		private string mPrototypeXml;
	}
}
