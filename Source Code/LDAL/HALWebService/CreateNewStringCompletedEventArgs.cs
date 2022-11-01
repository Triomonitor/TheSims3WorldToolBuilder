using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000023 RID: 35
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	public class CreateNewStringCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600013D RID: 317 RVA: 0x00005ADB File Offset: 0x00004ADB
		internal CreateNewStringCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00005AEE File Offset: 0x00004AEE
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00005B03 File Offset: 0x00004B03
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x04000050 RID: 80
		private object[] results;
	}
}
