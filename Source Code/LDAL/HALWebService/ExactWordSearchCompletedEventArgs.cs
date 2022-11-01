using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x0200003B RID: 59
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class ExactWordSearchCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000193 RID: 403 RVA: 0x00005DE1 File Offset: 0x00004DE1
		internal ExactWordSearchCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00005DF4 File Offset: 0x00004DF4
		public DataSet Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (DataSet)this.results[0];
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00005E09 File Offset: 0x00004E09
		public string retCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[1];
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00005E1E File Offset: 0x00004E1E
		public string retString
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (string)this.results[2];
			}
		}

		// Token: 0x0400005C RID: 92
		private object[] results;
	}
}
