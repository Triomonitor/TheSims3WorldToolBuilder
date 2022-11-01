using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200001F RID: 31
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600012D RID: 301 RVA: 0x00005A37 File Offset: 0x00004A37
		internal GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00005A4A File Offset: 0x00004A4A
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00005A5F File Offset: 0x00004A5F
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00005A74 File Offset: 0x00004A74
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x0400004E RID: 78
		private object[] results;
	}
}
