using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000019 RID: 25
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DesignerCategory("code")]
	public class GetAllStrings_WithProductionStatuses_SIMS3CompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000115 RID: 277 RVA: 0x00005941 File Offset: 0x00004941
		internal GetAllStrings_WithProductionStatuses_SIMS3CompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00005954 File Offset: 0x00004954
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00005969 File Offset: 0x00004969
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000118 RID: 280 RVA: 0x0000597E File Offset: 0x0000497E
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x0400004B RID: 75
		private object[] results;
	}
}
