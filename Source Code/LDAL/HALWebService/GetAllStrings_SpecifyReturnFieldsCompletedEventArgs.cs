using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200001B RID: 27
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class GetAllStrings_SpecifyReturnFieldsCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600011D RID: 285 RVA: 0x00005993 File Offset: 0x00004993
		internal GetAllStrings_SpecifyReturnFieldsCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600011E RID: 286 RVA: 0x000059A6 File Offset: 0x000049A6
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600011F RID: 287 RVA: 0x000059BB File Offset: 0x000049BB
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000120 RID: 288 RVA: 0x000059D0 File Offset: 0x000049D0
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x0400004C RID: 76
		private object[] results;
	}
}
