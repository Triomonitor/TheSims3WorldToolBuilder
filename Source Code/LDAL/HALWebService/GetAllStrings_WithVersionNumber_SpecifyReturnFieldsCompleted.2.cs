using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200001D RID: 29
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	public class GetAllStrings_WithVersionNumber_SpecifyReturnFieldsCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000125 RID: 293 RVA: 0x000059E5 File Offset: 0x000049E5
		internal GetAllStrings_WithVersionNumber_SpecifyReturnFieldsCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000126 RID: 294 RVA: 0x000059F8 File Offset: 0x000049F8
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00005A0D File Offset: 0x00004A0D
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00005A22 File Offset: 0x00004A22
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x0400004D RID: 77
		private object[] results;
	}
}
