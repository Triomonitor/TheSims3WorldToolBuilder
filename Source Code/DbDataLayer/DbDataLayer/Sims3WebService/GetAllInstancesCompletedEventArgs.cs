using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200003C RID: 60
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class GetAllInstancesCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600033A RID: 826 RVA: 0x0000B3D8 File Offset: 0x0000A3D8
		internal GetAllInstancesCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600033B RID: 827 RVA: 0x0000B3EB File Offset: 0x0000A3EB
		public ObjectInstance[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ObjectInstance[])this.results[0];
			}
		}

		// Token: 0x040000DD RID: 221
		private object[] results;
	}
}
