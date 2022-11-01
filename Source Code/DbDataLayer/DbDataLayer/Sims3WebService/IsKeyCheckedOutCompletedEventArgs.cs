using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000056 RID: 86
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DesignerCategory("code")]
	public class IsKeyCheckedOutCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600038A RID: 906 RVA: 0x0000B5B8 File Offset: 0x0000A5B8
		internal IsKeyCheckedOutCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600038B RID: 907 RVA: 0x0000B5CB File Offset: 0x0000A5CB
		public bool Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (bool)this.results[0];
			}
		}

		// Token: 0x040000E9 RID: 233
		private object[] results;
	}
}
