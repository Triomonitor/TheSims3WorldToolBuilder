using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200006C RID: 108
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	public class GetAllPrototypesNoXmlDataCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x060003CC RID: 972 RVA: 0x0000B770 File Offset: 0x0000A770
		internal GetAllPrototypesNoXmlDataCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060003CD RID: 973 RVA: 0x0000B783 File Offset: 0x0000A783
		public ObjectPrototype[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ObjectPrototype[])this.results[0];
			}
		}

		// Token: 0x040000F4 RID: 244
		private object[] results;
	}
}
