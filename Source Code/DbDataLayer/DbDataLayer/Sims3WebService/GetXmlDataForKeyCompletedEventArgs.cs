using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000060 RID: 96
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class GetXmlDataForKeyCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003A8 RID: 936 RVA: 0x0000B680 File Offset: 0x0000A680
		internal GetXmlDataForKeyCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x0000B693 File Offset: 0x0000A693
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x040000EE RID: 238
		private object[] results;
	}
}
