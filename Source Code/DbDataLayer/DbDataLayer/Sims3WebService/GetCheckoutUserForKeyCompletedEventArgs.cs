using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200004E RID: 78
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	public class GetCheckoutUserForKeyCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000372 RID: 882 RVA: 0x0000B518 File Offset: 0x0000A518
		internal GetCheckoutUserForKeyCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000373 RID: 883 RVA: 0x0000B52B File Offset: 0x0000A52B
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x040000E5 RID: 229
		private object[] results;
	}
}
