using System;
using Sims3.CSHost;
using Sims3.CSHost.Animation;

namespace SACS
{
	// Token: 0x02000007 RID: 7
	public class Rig : Asset
	{
		// Token: 0x0600004C RID: 76 RVA: 0x000035FE File Offset: 0x000025FE
		public static explicit operator Rig(Rig me)
		{
			return new Rig(me.Key);
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600004D RID: 77 RVA: 0x0000360B File Offset: 0x0000260B
		public override uint Type
		{
			get
			{
				return 2393838558U;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00003612 File Offset: 0x00002612
		public override uint Group
		{
			get
			{
				return 0U;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003615 File Offset: 0x00002615
		public Rig(ResourceKey key) : base(key)
		{
		}
	}
}
