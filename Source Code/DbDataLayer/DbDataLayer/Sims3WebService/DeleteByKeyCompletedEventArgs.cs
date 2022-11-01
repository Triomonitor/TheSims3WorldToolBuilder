using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200005A RID: 90
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	public class DeleteByKeyCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000396 RID: 918 RVA: 0x0000B608 File Offset: 0x0000A608
		internal DeleteByKeyCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000397 RID: 919 RVA: 0x0000B61B File Offset: 0x0000A61B
		public int Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[0];
			}
		}

		// Token: 0x040000EB RID: 235
		private object[] results;
	}
}
