using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000005 RID: 5
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	public class GetServerTimeCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060000C7 RID: 199 RVA: 0x00005637 File Offset: 0x00004637
		internal GetServerTimeCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x0000564A File Offset: 0x0000464A
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x04000041 RID: 65
		private object[] results;
	}
}
