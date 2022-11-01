using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200003E RID: 62
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	public class GetInstanceKeysForClassKeyCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000340 RID: 832 RVA: 0x0000B400 File Offset: 0x0000A400
		internal GetInstanceKeysForClassKeyCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000341 RID: 833 RVA: 0x0000B413 File Offset: 0x0000A413
		public ItemKey[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ItemKey[])this.results[0];
			}
		}

		// Token: 0x040000DE RID: 222
		private object[] results;
	}
}
