using System;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000089 RID: 137
	public class ClassInfo
	{
		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x00010210 File Offset: 0x0000F210
		// (set) Token: 0x060004BA RID: 1210 RVA: 0x00010218 File Offset: 0x0000F218
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

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x00010221 File Offset: 0x0000F221
		// (set) Token: 0x060004BC RID: 1212 RVA: 0x00010229 File Offset: 0x0000F229
		public string ClassName
		{
			get
			{
				return this.mClassName;
			}
			set
			{
				this.mClassName = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x00010232 File Offset: 0x0000F232
		// (set) Token: 0x060004BE RID: 1214 RVA: 0x0001023A File Offset: 0x0000F23A
		public string AssemblyName
		{
			get
			{
				return this.mAssemblyName;
			}
			set
			{
				this.mAssemblyName = value;
			}
		}

		// Token: 0x04000152 RID: 338
		private ItemKey mItemKey;

		// Token: 0x04000153 RID: 339
		private string mClassName;

		// Token: 0x04000154 RID: 340
		private string mAssemblyName;
	}
}
