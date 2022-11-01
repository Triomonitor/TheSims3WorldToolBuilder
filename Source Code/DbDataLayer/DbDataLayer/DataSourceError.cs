using System;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200000C RID: 12
	public class DataSourceError
	{
		// Token: 0x0200000D RID: 13
		public enum Error
		{
			// Token: 0x04000031 RID: 49
			ERR_OK,
			// Token: 0x04000032 RID: 50
			ERR_ALREADY_CHECKED_OUT,
			// Token: 0x04000033 RID: 51
			ERR_LOST_CONNECTION_TO_DATASOURCE,
			// Token: 0x04000034 RID: 52
			ERR_OPERATION_TIMEOUT
		}
	}
}
