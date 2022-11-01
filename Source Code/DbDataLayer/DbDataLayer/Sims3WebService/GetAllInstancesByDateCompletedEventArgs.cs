using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000072 RID: 114
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DesignerCategory("code")]
	public class GetAllInstancesByDateCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003DE RID: 990 RVA: 0x0000B7E8 File Offset: 0x0000A7E8
		internal GetAllInstancesByDateCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060003DF RID: 991 RVA: 0x0000B7FB File Offset: 0x0000A7FB
		public ObjectInstance[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ObjectInstance[])this.results[0];
			}
		}

		// Token: 0x040000F7 RID: 247
		private object[] results;
	}
}
