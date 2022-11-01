using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000064 RID: 100
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DesignerCategory("code")]
	public class GetChildrenForKeyCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003B4 RID: 948 RVA: 0x0000B6D0 File Offset: 0x0000A6D0
		internal GetChildrenForKeyCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x0000B6E3 File Offset: 0x0000A6E3
		public ItemKey[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ItemKey[])this.results[0];
			}
		}

		// Token: 0x040000F0 RID: 240
		private object[] results;
	}
}
