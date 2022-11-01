using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200002F RID: 47
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class UpdateAudioScript_IncludingDNTCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000167 RID: 359 RVA: 0x00005C49 File Offset: 0x00004C49
		internal UpdateAudioScript_IncludingDNTCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00005C5C File Offset: 0x00004C5C
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00005C71 File Offset: 0x00004C71
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x04000056 RID: 86
		private object[] results;
	}
}
