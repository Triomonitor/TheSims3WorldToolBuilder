using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000032 RID: 50
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	public class GetInstanceByKeyCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600031C RID: 796 RVA: 0x0000B310 File Offset: 0x0000A310
		internal GetInstanceByKeyCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0000B323 File Offset: 0x0000A323
		public ObjectInstance Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ObjectInstance)this.results[0];
			}
		}

		// Token: 0x040000D8 RID: 216
		private object[] results;
	}
}
