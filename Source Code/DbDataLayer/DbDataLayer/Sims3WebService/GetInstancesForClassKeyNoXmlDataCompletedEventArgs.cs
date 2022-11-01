using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000040 RID: 64
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	public class GetInstancesForClassKeyNoXmlDataCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000346 RID: 838 RVA: 0x0000B428 File Offset: 0x0000A428
		internal GetInstancesForClassKeyNoXmlDataCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000347 RID: 839 RVA: 0x0000B43B File Offset: 0x0000A43B
		public ObjectInstance[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ObjectInstance[])this.results[0];
			}
		}

		// Token: 0x040000DF RID: 223
		private object[] results;
	}
}
