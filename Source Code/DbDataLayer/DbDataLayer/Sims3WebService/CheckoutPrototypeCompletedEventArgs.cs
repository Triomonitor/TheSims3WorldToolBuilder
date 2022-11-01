using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200006E RID: 110
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class CheckoutPrototypeCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003D2 RID: 978 RVA: 0x0000B798 File Offset: 0x0000A798
		internal CheckoutPrototypeCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x0000B7AB File Offset: 0x0000A7AB
		public Guid Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (Guid)this.results[0];
			}
		}

		// Token: 0x040000F5 RID: 245
		private object[] results;
	}
}
