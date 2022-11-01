using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200006A RID: 106
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	public class GetDatabaseLockInformationCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003C6 RID: 966 RVA: 0x0000B748 File Offset: 0x0000A748
		internal GetDatabaseLockInformationCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x0000B75B File Offset: 0x0000A75B
		public DatabaseLock Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DatabaseLock)this.results[0];
			}
		}

		// Token: 0x040000F3 RID: 243
		private object[] results;
	}
}
