using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000039 RID: 57
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class BasicSearchCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600018B RID: 395 RVA: 0x00005D8F File Offset: 0x00004D8F
		internal BasicSearchCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00005DA2 File Offset: 0x00004DA2
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00005DB7 File Offset: 0x00004DB7
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00005DCC File Offset: 0x00004DCC
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x0400005B RID: 91
		private object[] results;
	}
}
