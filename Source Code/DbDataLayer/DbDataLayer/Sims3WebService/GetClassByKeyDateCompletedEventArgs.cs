using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000024 RID: 36
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	public class GetClassByKeyDateCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x0000B1F8 File Offset: 0x0000A1F8
		internal GetClassByKeyDateCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x0000B20B File Offset: 0x0000A20B
		public ObjectClass Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ObjectClass)this.results[0];
			}
		}

		// Token: 0x040000D1 RID: 209
		private object[] results;
	}
}
