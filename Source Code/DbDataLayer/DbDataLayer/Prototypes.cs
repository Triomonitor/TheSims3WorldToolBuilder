using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200007F RID: 127
	public class Prototypes
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x0000D409 File Offset: 0x0000C409
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x0000D411 File Offset: 0x0000C411
		[XmlElement(ElementName = "Prototype", Type = typeof(Prototype))]
		public List<Prototype> PrototypeList
		{
			get
			{
				return this.mPrototypes;
			}
			set
			{
				this.mPrototypes = value;
			}
		}

		// Token: 0x0400010F RID: 271
		private List<Prototype> mPrototypes = new List<Prototype>();
	}
}
