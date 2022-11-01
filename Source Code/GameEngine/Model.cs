using System;
using Sims3.CSHost;

namespace SACS
{
	// Token: 0x02000008 RID: 8
	public class Model : Asset
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000050 RID: 80 RVA: 0x0000361E File Offset: 0x0000261E
		public override uint Type
		{
			get
			{
				return 23466547U;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00003625 File Offset: 0x00002625
		public override uint Group
		{
			get
			{
				return 0U;
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003628 File Offset: 0x00002628
		public Model(ResourceKey key) : base(key)
		{
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003631 File Offset: 0x00002631
		public Model(string name) : base(name)
		{
		}
	}
}
