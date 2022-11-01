using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000042 RID: 66
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	public class GetReferencesByInstanceCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600034C RID: 844 RVA: 0x0000B450 File Offset: 0x0000A450
		internal GetReferencesByInstanceCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600034D RID: 845 RVA: 0x0000B463 File Offset: 0x0000A463
		public ItemKey[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ItemKey[])this.results[0];
			}
		}

		// Token: 0x040000E0 RID: 224
		private object[] results;
	}
}
