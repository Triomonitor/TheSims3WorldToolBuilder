using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200003D RID: 61
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	public class BasicSearch_TextAndAudioCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600019B RID: 411 RVA: 0x00005E33 File Offset: 0x00004E33
		internal BasicSearch_TextAndAudioCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00005E46 File Offset: 0x00004E46
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00005E5B File Offset: 0x00004E5B
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00005E70 File Offset: 0x00004E70
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x0400005D RID: 93
		private object[] results;
	}
}
