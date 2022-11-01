using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000015 RID: 21
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	public class GetAllStrings_WithVersionNumberCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000105 RID: 261 RVA: 0x0000589D File Offset: 0x0000489D
		internal GetAllStrings_WithVersionNumberCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000106 RID: 262 RVA: 0x000058B0 File Offset: 0x000048B0
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000107 RID: 263 RVA: 0x000058C5 File Offset: 0x000048C5
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000108 RID: 264 RVA: 0x000058DA File Offset: 0x000048DA
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x04000049 RID: 73
		private object[] results;
	}
}
