using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200002A RID: 42
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	public class InsertPrototypeCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000304 RID: 772 RVA: 0x0000B270 File Offset: 0x0000A270
		internal InsertPrototypeCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000305 RID: 773 RVA: 0x0000B283 File Offset: 0x0000A283
		public int Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[0];
			}
		}

		// Token: 0x040000D4 RID: 212
		private object[] results;
	}
}
