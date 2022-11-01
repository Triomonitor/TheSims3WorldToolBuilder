using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200000B RID: 11
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	public class GetPlatformsInProductCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060000DD RID: 221 RVA: 0x00005703 File Offset: 0x00004703
		internal GetPlatformsInProductCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00005716 File Offset: 0x00004716
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000DF RID: 223 RVA: 0x0000572B File Offset: 0x0000472B
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00005740 File Offset: 0x00004740
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x04000044 RID: 68
		private object[] results;
	}
}
