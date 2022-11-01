using System;
using System.Runtime.Serialization;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200000E RID: 14
	[Serializable]
	public class DataSourceException : Exception
	{
		// Token: 0x060000FC RID: 252 RVA: 0x00005862 File Offset: 0x00004862
		public DataSourceException()
		{
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000586A File Offset: 0x0000486A
		public DataSourceException(string message) : base(message)
		{
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00005873 File Offset: 0x00004873
		public DataSourceException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000587D File Offset: 0x0000487D
		protected DataSourceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
