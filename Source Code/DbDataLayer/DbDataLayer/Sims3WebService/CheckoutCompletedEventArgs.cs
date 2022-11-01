using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000048 RID: 72
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class CheckoutCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000360 RID: 864 RVA: 0x0000B4A0 File Offset: 0x0000A4A0
		internal CheckoutCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000361 RID: 865 RVA: 0x0000B4B3 File Offset: 0x0000A4B3
		public Guid Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (Guid)this.results[0];
			}
		}

		// Token: 0x040000E2 RID: 226
		private object[] results;
	}
}
