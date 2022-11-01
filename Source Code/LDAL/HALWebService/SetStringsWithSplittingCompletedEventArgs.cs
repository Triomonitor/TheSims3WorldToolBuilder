using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000035 RID: 53
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class SetStringsWithSplittingCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600017D RID: 381 RVA: 0x00005D15 File Offset: 0x00004D15
		internal SetStringsWithSplittingCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00005D28 File Offset: 0x00004D28
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600017F RID: 383 RVA: 0x00005D3D File Offset: 0x00004D3D
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x04000059 RID: 89
		private object[] results;
	}
}
