using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000037 RID: 55
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DesignerCategory("code")]
	public class SetStringsWithSplittingAndMergingCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000184 RID: 388 RVA: 0x00005D52 File Offset: 0x00004D52
		internal SetStringsWithSplittingAndMergingCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00005D65 File Offset: 0x00004D65
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00005D7A File Offset: 0x00004D7A
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x0400005A RID: 90
		private object[] results;
	}
}
