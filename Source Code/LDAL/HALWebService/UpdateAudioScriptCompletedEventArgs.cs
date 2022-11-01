using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200002D RID: 45
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	public class UpdateAudioScriptCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000160 RID: 352 RVA: 0x00005C0C File Offset: 0x00004C0C
		internal UpdateAudioScriptCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00005C1F File Offset: 0x00004C1F
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00005C34 File Offset: 0x00004C34
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x04000055 RID: 85
		private object[] results;
	}
}
