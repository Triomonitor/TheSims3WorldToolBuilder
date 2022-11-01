using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000062 RID: 98
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class GetXmlDataForKeyDateCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003AE RID: 942 RVA: 0x0000B6A8 File Offset: 0x0000A6A8
		internal GetXmlDataForKeyDateCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060003AF RID: 943 RVA: 0x0000B6BB File Offset: 0x0000A6BB
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x040000EF RID: 239
		private object[] results;
	}
}
