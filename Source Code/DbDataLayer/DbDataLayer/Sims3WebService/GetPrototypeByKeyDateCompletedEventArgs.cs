using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000030 RID: 48
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DesignerCategory("code")]
	public class GetPrototypeByKeyDateCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000316 RID: 790 RVA: 0x0000B2E8 File Offset: 0x0000A2E8
		internal GetPrototypeByKeyDateCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000317 RID: 791 RVA: 0x0000B2FB File Offset: 0x0000A2FB
		public ObjectPrototype Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ObjectPrototype)this.results[0];
			}
		}

		// Token: 0x040000D7 RID: 215
		private object[] results;
	}
}
