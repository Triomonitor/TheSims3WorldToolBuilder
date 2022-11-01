using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000011 RID: 17
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	public class GetAllStringsCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x000057F9 File Offset: 0x000047F9
		internal GetAllStringsCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000580C File Offset: 0x0000480C
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00005821 File Offset: 0x00004821
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00005836 File Offset: 0x00004836
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x04000047 RID: 71
		private object[] results;
	}
}
