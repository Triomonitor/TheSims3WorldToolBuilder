using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000017 RID: 23
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DesignerCategory("code")]
	public class GetAllStrings_WithVersionNumber_SIMS3CompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600010D RID: 269 RVA: 0x000058EF File Offset: 0x000048EF
		internal GetAllStrings_WithVersionNumber_SIMS3CompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00005902 File Offset: 0x00004902
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00005917 File Offset: 0x00004917
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000110 RID: 272 RVA: 0x0000592C File Offset: 0x0000492C
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x0400004A RID: 74
		private object[] results;
	}
}
