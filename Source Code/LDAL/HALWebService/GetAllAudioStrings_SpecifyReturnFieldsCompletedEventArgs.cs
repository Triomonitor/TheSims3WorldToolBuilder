using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200000D RID: 13
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	public class GetAllAudioStrings_SpecifyReturnFieldsCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060000E5 RID: 229 RVA: 0x00005755 File Offset: 0x00004755
		internal GetAllAudioStrings_SpecifyReturnFieldsCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00005768 File Offset: 0x00004768
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x0000577D File Offset: 0x0000477D
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00005792 File Offset: 0x00004792
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x04000045 RID: 69
		private object[] results;
	}
}
