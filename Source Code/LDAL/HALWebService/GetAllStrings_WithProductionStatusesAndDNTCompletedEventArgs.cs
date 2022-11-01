using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000013 RID: 19
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class GetAllStrings_WithProductionStatusesAndDNTCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060000FD RID: 253 RVA: 0x0000584B File Offset: 0x0000484B
		internal GetAllStrings_WithProductionStatusesAndDNTCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000FE RID: 254 RVA: 0x0000585E File Offset: 0x0000485E
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00005873 File Offset: 0x00004873
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00005888 File Offset: 0x00004888
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x04000048 RID: 72
		private object[] results;
	}
}
