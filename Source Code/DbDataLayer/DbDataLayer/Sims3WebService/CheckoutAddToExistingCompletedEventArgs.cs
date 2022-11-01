using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200004A RID: 74
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class CheckoutAddToExistingCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000366 RID: 870 RVA: 0x0000B4C8 File Offset: 0x0000A4C8
		internal CheckoutAddToExistingCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000367 RID: 871 RVA: 0x0000B4DB File Offset: 0x0000A4DB
		public Guid Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (Guid)this.results[0];
			}
		}

		// Token: 0x040000E3 RID: 227
		private object[] results;
	}
}
