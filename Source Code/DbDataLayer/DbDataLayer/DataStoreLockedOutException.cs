using System;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000013 RID: 19
	public class DataStoreLockedOutException : Exception
	{
		// Token: 0x06000116 RID: 278 RVA: 0x00005BD5 File Offset: 0x00004BD5
		public DataStoreLockedOutException(string byWhom) : base(string.Format("Database has been locked out by {0}.", byWhom))
		{
			this.mAdmin = byWhom;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00005BEF File Offset: 0x00004BEF
		public string Admin
		{
			get
			{
				return this.mAdmin;
			}
		}

		// Token: 0x0400003D RID: 61
		private string mAdmin;
	}
}
