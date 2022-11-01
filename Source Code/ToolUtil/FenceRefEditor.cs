using System;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x02000037 RID: 55
	public class FenceRefEditor : SearchableItemRefUIEditor
	{
		// Token: 0x0600022D RID: 557 RVA: 0x0000C3ED File Offset: 0x0000B3ED
		public FenceRefEditor()
		{
			this.PrototypeKey = DataStore.Instance.FindItemKey("Fence", 0L, 68746794L, ItemType.PROTOTYPE);
		}
	}
}
