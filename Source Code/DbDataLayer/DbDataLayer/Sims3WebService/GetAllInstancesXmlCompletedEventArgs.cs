using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000074 RID: 116
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	public class GetAllInstancesXmlCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003E4 RID: 996 RVA: 0x0000B810 File Offset: 0x0000A810
		internal GetAllInstancesXmlCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x0000B823 File Offset: 0x0000A823
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x040000F8 RID: 248
		private object[] results;
	}
}
