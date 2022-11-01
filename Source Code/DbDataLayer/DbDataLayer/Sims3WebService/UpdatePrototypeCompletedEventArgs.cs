using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200002C RID: 44
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class UpdatePrototypeCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600030A RID: 778 RVA: 0x0000B298 File Offset: 0x0000A298
		internal UpdatePrototypeCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600030B RID: 779 RVA: 0x0000B2AB File Offset: 0x0000A2AB
		public int Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[0];
			}
		}

		// Token: 0x040000D5 RID: 213
		private object[] results;
	}
}
