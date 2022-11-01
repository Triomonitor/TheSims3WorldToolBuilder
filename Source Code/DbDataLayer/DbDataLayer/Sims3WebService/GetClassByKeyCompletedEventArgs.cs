using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000022 RID: 34
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class GetClassByKeyCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060002EC RID: 748 RVA: 0x0000B1D0 File Offset: 0x0000A1D0
		internal GetClassByKeyCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060002ED RID: 749 RVA: 0x0000B1E3 File Offset: 0x0000A1E3
		public ObjectClass Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ObjectClass)this.results[0];
			}
		}

		// Token: 0x040000D0 RID: 208
		private object[] results;
	}
}
