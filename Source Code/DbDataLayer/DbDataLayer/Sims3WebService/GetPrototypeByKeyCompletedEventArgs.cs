using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200002E RID: 46
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	public class GetPrototypeByKeyCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000310 RID: 784 RVA: 0x0000B2C0 File Offset: 0x0000A2C0
		internal GetPrototypeByKeyCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0000B2D3 File Offset: 0x0000A2D3
		public ObjectPrototype Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ObjectPrototype)this.results[0];
			}
		}

		// Token: 0x040000D6 RID: 214
		private object[] results;
	}
}
