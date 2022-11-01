using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200000F RID: 15
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060000ED RID: 237 RVA: 0x000057A7 File Offset: 0x000047A7
		internal GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000EE RID: 238 RVA: 0x000057BA File Offset: 0x000047BA
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000EF RID: 239 RVA: 0x000057CF File Offset: 0x000047CF
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x000057E4 File Offset: 0x000047E4
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x04000046 RID: 70
		private object[] results;
	}
}
