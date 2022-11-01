using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000033 RID: 51
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	public class GetCategoriesInProductCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000175 RID: 373 RVA: 0x00005CC3 File Offset: 0x00004CC3
		internal GetCategoriesInProductCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000176 RID: 374 RVA: 0x00005CD6 File Offset: 0x00004CD6
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000177 RID: 375 RVA: 0x00005CEB File Offset: 0x00004CEB
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00005D00 File Offset: 0x00004D00
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x04000058 RID: 88
		private object[] results;
	}
}
