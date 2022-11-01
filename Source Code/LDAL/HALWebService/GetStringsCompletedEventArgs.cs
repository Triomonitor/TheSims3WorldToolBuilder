using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000021 RID: 33
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class GetStringsCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000135 RID: 309 RVA: 0x00005A89 File Offset: 0x00004A89
		internal GetStringsCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00005A9C File Offset: 0x00004A9C
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00005AB1 File Offset: 0x00004AB1
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00005AC6 File Offset: 0x00004AC6
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x0400004F RID: 79
		private object[] results;
	}
}
