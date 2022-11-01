using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200002B RID: 43
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class UpdateSourceString_IncludingDNTCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000159 RID: 345 RVA: 0x00005BCF File Offset: 0x00004BCF
		internal UpdateSourceString_IncludingDNTCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600015A RID: 346 RVA: 0x00005BE2 File Offset: 0x00004BE2
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600015B RID: 347 RVA: 0x00005BF7 File Offset: 0x00004BF7
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x04000054 RID: 84
		private object[] results;
	}
}
