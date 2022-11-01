using System;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x02000033 RID: 51
	public class WallRefEditor : SearchableItemRefUIEditor
	{
		// Token: 0x06000229 RID: 553 RVA: 0x0000C355 File Offset: 0x0000B355
		public WallRefEditor()
		{
			this.PrototypeKey = DataStore.Instance.FindItemKey("Wall", 0L, (long)((ulong)-1856903492), ItemType.PROTOTYPE);
		}
	}
}
