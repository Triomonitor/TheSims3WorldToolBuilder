using System;

namespace ToolUtil
{
	// Token: 0x0200003B RID: 59
	public class SearchEventArgs
	{
		// Token: 0x06000233 RID: 563 RVA: 0x0000C56C File Offset: 0x0000B56C
		public SearchEventArgs(string searchString, bool skipCurrent, bool backwards)
		{
			this.mSearchString = searchString;
			this.mSkipCurrent = skipCurrent;
			this.mBackwards = backwards;
		}

		// Token: 0x04000109 RID: 265
		public string mSearchString;

		// Token: 0x0400010A RID: 266
		public bool mSkipCurrent;

		// Token: 0x0400010B RID: 267
		public bool mBackwards;
	}
}
