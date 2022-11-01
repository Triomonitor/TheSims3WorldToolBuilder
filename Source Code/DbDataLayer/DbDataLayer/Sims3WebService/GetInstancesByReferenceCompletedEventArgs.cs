using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000044 RID: 68
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	public class GetInstancesByReferenceCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000352 RID: 850 RVA: 0x0000B478 File Offset: 0x0000A478
		internal GetInstancesByReferenceCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000353 RID: 851 RVA: 0x0000B48B File Offset: 0x0000A48B
		public ItemKey[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ItemKey[])this.results[0];
			}
		}

		// Token: 0x040000E1 RID: 225
		private object[] results;
	}
}
