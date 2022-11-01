using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000038 RID: 56
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class UpdateInstanceCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600032E RID: 814 RVA: 0x0000B388 File Offset: 0x0000A388
		internal UpdateInstanceCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0000B39B File Offset: 0x0000A39B
		public int Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[0];
			}
		}

		// Token: 0x040000DB RID: 219
		private object[] results;
	}
}
