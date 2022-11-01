using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200005E RID: 94
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	public class GetRevisionDatesForKeyCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003A2 RID: 930 RVA: 0x0000B658 File Offset: 0x0000A658
		internal GetRevisionDatesForKeyCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x0000B66B File Offset: 0x0000A66B
		public DateTime[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DateTime[])this.results[0];
			}
		}

		// Token: 0x040000ED RID: 237
		private object[] results;
	}
}
