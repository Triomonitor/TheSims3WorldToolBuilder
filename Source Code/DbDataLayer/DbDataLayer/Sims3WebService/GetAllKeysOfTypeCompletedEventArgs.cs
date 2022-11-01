using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200005C RID: 92
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class GetAllKeysOfTypeCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600039C RID: 924 RVA: 0x0000B630 File Offset: 0x0000A630
		internal GetAllKeysOfTypeCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600039D RID: 925 RVA: 0x0000B643 File Offset: 0x0000A643
		public ItemKey[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ItemKey[])this.results[0];
			}
		}

		// Token: 0x040000EC RID: 236
		private object[] results;
	}
}
