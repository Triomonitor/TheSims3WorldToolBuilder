using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000007 RID: 7
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DesignerCategory("code")]
	public class GetAllProductsCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000565F File Offset: 0x0000465F
		internal GetAllProductsCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00005672 File Offset: 0x00004672
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00005687 File Offset: 0x00004687
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x0000569C File Offset: 0x0000469C
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x04000042 RID: 66
		private object[] results;
	}
}
