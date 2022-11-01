using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000028 RID: 40
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	public class UpdateClassCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060002FE RID: 766 RVA: 0x0000B248 File Offset: 0x0000A248
		internal UpdateClassCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0000B25B File Offset: 0x0000A25B
		public int Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[0];
			}
		}

		// Token: 0x040000D3 RID: 211
		private object[] results;
	}
}
