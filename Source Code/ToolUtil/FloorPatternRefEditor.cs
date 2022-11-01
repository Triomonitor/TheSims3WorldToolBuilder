using System;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x02000030 RID: 48
	public class FloorPatternRefEditor : SearchableItemRefUIEditor
	{
		// Token: 0x06000226 RID: 550 RVA: 0x0000C2E3 File Offset: 0x0000B2E3
		public FloorPatternRefEditor()
		{
			this.PrototypeKey = DataStore.Instance.FindItemKey("Floor Pattern", 0L, 1365025997L, ItemType.PROTOTYPE);
		}
	}
}
