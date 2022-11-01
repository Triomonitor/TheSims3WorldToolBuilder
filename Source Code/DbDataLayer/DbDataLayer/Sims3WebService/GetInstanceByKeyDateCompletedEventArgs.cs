using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000034 RID: 52
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DesignerCategory("code")]
	public class GetInstanceByKeyDateCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000322 RID: 802 RVA: 0x0000B338 File Offset: 0x0000A338
		internal GetInstanceByKeyDateCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000323 RID: 803 RVA: 0x0000B34B File Offset: 0x0000A34B
		public ObjectInstance Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ObjectInstance)this.results[0];
			}
		}

		// Token: 0x040000D9 RID: 217
		private object[] results;
	}
}
