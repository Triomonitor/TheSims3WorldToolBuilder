using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000036 RID: 54
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	public class InsertInstanceCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000328 RID: 808 RVA: 0x0000B360 File Offset: 0x0000A360
		internal InsertInstanceCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000329 RID: 809 RVA: 0x0000B373 File Offset: 0x0000A373
		public int Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[0];
			}
		}

		// Token: 0x040000DA RID: 218
		private object[] results;
	}
}
