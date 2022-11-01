using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000066 RID: 102
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class TestConnectionCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003BA RID: 954 RVA: 0x0000B6F8 File Offset: 0x0000A6F8
		internal TestConnectionCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060003BB RID: 955 RVA: 0x0000B70B File Offset: 0x0000A70B
		public bool Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (bool)this.results[0];
			}
		}

		// Token: 0x040000F1 RID: 241
		private object[] results;
	}
}
