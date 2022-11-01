using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000052 RID: 82
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	public class ListCheckedOutCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x0600037E RID: 894 RVA: 0x0000B568 File Offset: 0x0000A568
		internal ListCheckedOutCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600037F RID: 895 RVA: 0x0000B57B File Offset: 0x0000A57B
		public ItemKey[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ItemKey[])this.results[0];
			}
		}

		// Token: 0x040000E7 RID: 231
		private object[] results;
	}
}
