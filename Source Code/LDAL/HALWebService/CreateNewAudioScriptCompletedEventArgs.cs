using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000025 RID: 37
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	public class CreateNewAudioScriptCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000144 RID: 324 RVA: 0x00005B18 File Offset: 0x00004B18
		internal CreateNewAudioScriptCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00005B2B File Offset: 0x00004B2B
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00005B40 File Offset: 0x00004B40
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x04000051 RID: 81
		private object[] results;
	}
}
