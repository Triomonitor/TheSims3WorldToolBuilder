using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000076 RID: 118
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class XmlBulkExportForDateCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003EA RID: 1002 RVA: 0x0000B838 File Offset: 0x0000A838
		internal XmlBulkExportForDateCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x0000B84B File Offset: 0x0000A84B
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x040000F9 RID: 249
		private object[] results;
	}
}
