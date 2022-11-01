using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000058 RID: 88
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	public class ListCheckedOutChildrenForKeyCompletedEventArgs : AsyncCompletedEventArgs
	{
		// Token: 0x06000390 RID: 912 RVA: 0x0000B5E0 File Offset: 0x0000A5E0
		internal ListCheckedOutChildrenForKeyCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000391 RID: 913 RVA: 0x0000B5F3 File Offset: 0x0000A5F3
		public ItemKey[][] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (ItemKey[][])this.results[0];
			}
		}

		// Token: 0x040000EA RID: 234
		private object[] results;
	}
}
