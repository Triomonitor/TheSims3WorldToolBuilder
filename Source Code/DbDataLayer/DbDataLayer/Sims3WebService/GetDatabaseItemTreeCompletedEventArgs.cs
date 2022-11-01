using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000070 RID: 112
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	public class GetDatabaseItemTreeCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003D8 RID: 984 RVA: 0x0000B7C0 File Offset: 0x0000A7C0
		internal GetDatabaseItemTreeCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x0000B7D3 File Offset: 0x0000A7D3
		public DBItemInfo[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DBItemInfo[])this.results[0];
			}
		}

		// Token: 0x040000F6 RID: 246
		private object[] results;
	}
}
