using System;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200000F RID: 15
	public class IdCounter
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00005887 File Offset: 0x00004887
		// (set) Token: 0x06000101 RID: 257 RVA: 0x0000588F File Offset: 0x0000488F
		public long InstanceIdCount
		{
			get
			{
				return this.mLastInstanceId;
			}
			set
			{
				this.mLastInstanceId = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00005898 File Offset: 0x00004898
		// (set) Token: 0x06000103 RID: 259 RVA: 0x000058A0 File Offset: 0x000048A0
		public long PrototypeIdCount
		{
			get
			{
				return this.mLastPrototypeId;
			}
			set
			{
				this.mLastPrototypeId = value;
			}
		}

		// Token: 0x04000035 RID: 53
		private long mLastInstanceId = long.MaxValue;

		// Token: 0x04000036 RID: 54
		private long mLastPrototypeId = long.MaxValue;
	}
}
