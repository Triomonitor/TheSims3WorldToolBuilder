using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000031 RID: 49
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DesignerCategory("code")]
	public class DeleteStringCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600016E RID: 366 RVA: 0x00005C86 File Offset: 0x00004C86
		internal DeleteStringCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600016F RID: 367 RVA: 0x00005C99 File Offset: 0x00004C99
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00005CAE File Offset: 0x00004CAE
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x04000057 RID: 87
		private object[] results;
	}
}
