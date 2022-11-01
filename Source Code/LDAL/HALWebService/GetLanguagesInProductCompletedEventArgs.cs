using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000009 RID: 9
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	public class GetLanguagesInProductCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x000056B1 File Offset: 0x000046B1
		internal GetLanguagesInProductCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x000056C4 File Offset: 0x000046C4
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x000056D9 File Offset: 0x000046D9
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x000056EE File Offset: 0x000046EE
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x04000043 RID: 67
		private object[] results;
	}
}
