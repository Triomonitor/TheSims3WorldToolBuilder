using System;
using System.Xml;
using System.Xml.Serialization;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200001B RID: 27
	[Serializable]
	public class PersistedObject
	{
		// Token: 0x060001B0 RID: 432 RVA: 0x000083B0 File Offset: 0x000073B0
		public PersistedObject(OpenObject obj, DataStore db)
		{
			this.mInstanceKey = new ItemKey(obj.InstanceKey);
			this.mOrigInstanceKey = new ItemKey(obj.OriginalInstanceKey);
			this.mPrototypeKey = new ItemKey(obj.PrototypeKey);
			this.mOrigPrototypeKey = new ItemKey(obj.OriginalPrototypeKey);
			this.mInstanceXml = db.GenerateXml(obj.InstanceObject);
			this.mNew = obj.NewInstance;
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00008425 File Offset: 0x00007425
		public PersistedObject()
		{
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x0000842D File Offset: 0x0000742D
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x00008435 File Offset: 0x00007435
		public ItemKey InstanceKey
		{
			get
			{
				return this.mInstanceKey;
			}
			set
			{
				this.mInstanceKey = value;
				this.mInstanceKey.KeyType = ItemType.INSTANCE;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000844A File Offset: 0x0000744A
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00008452 File Offset: 0x00007452
		public ItemKey OriginalInstanceKey
		{
			get
			{
				return this.mOrigInstanceKey;
			}
			set
			{
				this.mOrigInstanceKey = value;
				this.mOrigInstanceKey.KeyType = ItemType.INSTANCE;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x00008467 File Offset: 0x00007467
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x0000846F File Offset: 0x0000746F
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

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x00008484 File Offset: 0x00007484
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x000084A0 File Offset: 0x000074A0
		public ItemKey OriginalPrototypeKey
		{
			get
			{
				if (this.mOrigPrototypeKey == null)
				{
					this.mOrigPrototypeKey = this.mPrototypeKey;
				}
				return this.mOrigPrototypeKey;
			}
			set
			{
				this.mOrigPrototypeKey = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060001BA RID: 442 RVA: 0x000084AC File Offset: 0x000074AC
		// (set) Token: 0x060001BB RID: 443 RVA: 0x000084CC File Offset: 0x000074CC
		public XmlDocument InstanceXml
		{
			get
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(this.mInstanceXml);
				return xmlDocument;
			}
			set
			{
				this.mInstanceXml = value.InnerXml;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060001BC RID: 444 RVA: 0x000084DA File Offset: 0x000074DA
		// (set) Token: 0x060001BD RID: 445 RVA: 0x000084E2 File Offset: 0x000074E2
		[XmlIgnore]
		public string InstanceXmlString
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

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060001BE RID: 446 RVA: 0x000084EB File Offset: 0x000074EB
		// (set) Token: 0x060001BF RID: 447 RVA: 0x000084F3 File Offset: 0x000074F3
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

		// Token: 0x04000067 RID: 103
		private ItemKey mOrigInstanceKey;

		// Token: 0x04000068 RID: 104
		private ItemKey mInstanceKey;

		// Token: 0x04000069 RID: 105
		private ItemKey mOrigPrototypeKey;

		// Token: 0x0400006A RID: 106
		private ItemKey mPrototypeKey;

		// Token: 0x0400006B RID: 107
		private string mInstanceXml;

		// Token: 0x0400006C RID: 108
		private bool mNew;
	}
}
