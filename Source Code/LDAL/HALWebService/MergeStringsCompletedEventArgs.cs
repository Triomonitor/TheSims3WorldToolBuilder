using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200003F RID: 63
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	public class MergeStringsCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x00005E85 File Offset: 0x00004E85
		internal MergeStringsCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00005E98 File Offset: 0x00004E98
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00005EAD File Offset: 0x00004EAD
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x0400005E RID: 94
		private object[] results;
	}
}
