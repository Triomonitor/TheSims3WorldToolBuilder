using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200003A RID: 58
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	public class BulkInsertInstancesCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000334 RID: 820 RVA: 0x0000B3B0 File Offset: 0x0000A3B0
		internal BulkInsertInstancesCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000335 RID: 821 RVA: 0x0000B3C3 File Offset: 0x0000A3C3
		public int Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[0];
			}
		}

		// Token: 0x040000DC RID: 220
		private object[] results;
	}
}
