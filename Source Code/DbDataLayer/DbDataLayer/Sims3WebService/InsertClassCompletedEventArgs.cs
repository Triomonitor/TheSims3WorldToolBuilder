using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000026 RID: 38
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	public class InsertClassCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060002F8 RID: 760 RVA: 0x0000B220 File Offset: 0x0000A220
		internal InsertClassCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0000B233 File Offset: 0x0000A233
		public int Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[0];
			}
		}

		// Token: 0x040000D2 RID: 210
		private object[] results;
	}
}
