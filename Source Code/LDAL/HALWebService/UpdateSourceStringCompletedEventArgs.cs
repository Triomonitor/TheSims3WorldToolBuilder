using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000029 RID: 41
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	public class UpdateSourceStringCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000152 RID: 338 RVA: 0x00005B92 File Offset: 0x00004B92
		internal UpdateSourceStringCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00005BA5 File Offset: 0x00004BA5
		public string Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000154 RID: 340 RVA: 0x00005BBA File Offset: 0x00004BBA
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x04000053 RID: 83
		private object[] results;
	}
}
