using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000027 RID: 39
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class RenameStringIdCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600014B RID: 331 RVA: 0x00005B55 File Offset: 0x00004B55
		internal RenameStringIdCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00005B68 File Offset: 0x00004B68
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00005B7D File Offset: 0x00004B7D
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x04000052 RID: 82
		private object[] results;
	}
}
