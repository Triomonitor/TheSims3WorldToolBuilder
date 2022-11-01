using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000068 RID: 104
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class IsDatabaseLockedCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003C0 RID: 960 RVA: 0x0000B720 File Offset: 0x0000A720
		internal IsDatabaseLockedCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x0000B733 File Offset: 0x0000A733
		public bool Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (bool)this.results[0];
			}
		}

		// Token: 0x040000F2 RID: 242
		private object[] results;
	}
}
