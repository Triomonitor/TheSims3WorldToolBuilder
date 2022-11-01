using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200004C RID: 76
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	public class GetCheckoutsForCurrentUserCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600036C RID: 876 RVA: 0x0000B4F0 File Offset: 0x0000A4F0
		internal GetCheckoutsForCurrentUserCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600036D RID: 877 RVA: 0x0000B503 File Offset: 0x0000A503
		public Guid[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (Guid[])this.results[0];
			}
		}

		// Token: 0x040000E4 RID: 228
		private object[] results;
	}
}
