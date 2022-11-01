using System;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200001A RID: 26
	public class OpenObject
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x000082F4 File Offset: 0x000072F4
		public OpenObject(ItemKey prototypeKey, ItemKey originalPrototypeKey, ItemKey instanceKey, ItemKey originalInstanceKey, object instanceObject, bool newInstance)
		{
			this.mOrigPrototypeKey = new ItemKey(originalPrototypeKey);
			this.mPrototypeKey = new ItemKey(prototypeKey);
			this.mOrigInstanceKey = new ItemKey(originalInstanceKey);
			this.mInstanceKey = new ItemKey(instanceKey);
			this.mInstanceObject = instanceObject;
			this.mNew = newInstance;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00008348 File Offset: 0x00007348
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x00008350 File Offset: 0x00007350
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

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00008359 File Offset: 0x00007359
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x00008361 File Offset: 0x00007361
		public ItemKey OriginalInstanceKey
		{
			get
			{
				return this.mOrigInstanceKey;
			}
			set
			{
				this.mOrigInstanceKey = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x0000836A File Offset: 0x0000736A
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x00008372 File Offset: 0x00007372
		public ItemKey PrototypeKey
		{
			get
			{
				return this.mPrototypeKey;
			}
			set
			{
				this.mPrototypeKey = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060001AA RID: 426 RVA: 0x0000837B File Offset: 0x0000737B
		// (set) Token: 0x060001AB RID: 427 RVA: 0x00008383 File Offset: 0x00007383
		public ItemKey OriginalPrototypeKey
		{
			get
			{
				return this.mOrigPrototypeKey;
			}
			set
			{
				this.mOrigPrototypeKey = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060001AC RID: 428 RVA: 0x0000838C File Offset: 0x0000738C
		// (set) Token: 0x060001AD RID: 429 RVA: 0x00008394 File Offset: 0x00007394
		public object InstanceObject
		{
			get
			{
				return this.mInstanceObject;
			}
			set
			{
				this.mInstanceObject = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0000839D File Offset: 0x0000739D
		// (set) Token: 0x060001AF RID: 431 RVA: 0x000083A5 File Offset: 0x000073A5
		public bool NewInstance
		{
			get
			{
				return this.mNew;
			}
			set
			{
				this.mNew = value;
			}
		}

		// Token: 0x04000061 RID: 97
		private ItemKey mOrigInstanceKey;

		// Token: 0x04000062 RID: 98
		private ItemKey mInstanceKey;

		// Token: 0x04000063 RID: 99
		private ItemKey mOrigPrototypeKey;

		// Token: 0x04000064 RID: 100
		private ItemKey mPrototypeKey;

		// Token: 0x04000065 RID: 101
		private object mInstanceObject;

		// Token: 0x04000066 RID: 102
		private bool mNew;
	}
}
