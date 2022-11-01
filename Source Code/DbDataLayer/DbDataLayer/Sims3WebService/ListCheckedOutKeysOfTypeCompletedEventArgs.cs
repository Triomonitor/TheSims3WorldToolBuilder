using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000054 RID: 84
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class ListCheckedOutKeysOfTypeCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000384 RID: 900 RVA: 0x0000B590 File Offset: 0x0000A590
		internal ListCheckedOutKeysOfTypeCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000385 RID: 901 RVA: 0x0000B5A3 File Offset: 0x0000A5A3
		public ItemKey[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ItemKey[])this.results[0];
			}
		}

		// Token: 0x040000E8 RID: 232
		private object[] results;
	}
}
