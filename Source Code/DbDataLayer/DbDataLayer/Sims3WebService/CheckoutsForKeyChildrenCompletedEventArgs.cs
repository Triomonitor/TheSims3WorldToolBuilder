using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000050 RID: 80
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class CheckoutsForKeyChildrenCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000378 RID: 888 RVA: 0x0000B540 File Offset: 0x0000A540
		internal CheckoutsForKeyChildrenCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000379 RID: 889 RVA: 0x0000B553 File Offset: 0x0000A553
		public Guid[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (Guid[])this.results[0];
			}
		}

		// Token: 0x040000E6 RID: 230
		private object[] results;
	}
}
