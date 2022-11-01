using System;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x02000032 RID: 50
	public class FloorEdgePatternRefEditor : SearchableItemRefUIEditor
	{
		// Token: 0x06000228 RID: 552 RVA: 0x0000C32F File Offset: 0x0000B32F
		public FloorEdgePatternRefEditor()
		{
			this.PrototypeKey = DataStore.Instance.FindItemKey("FloorEdge Pattern", 0L, 1365025997L, ItemType.PROTOTYPE);
		}
	}
}
