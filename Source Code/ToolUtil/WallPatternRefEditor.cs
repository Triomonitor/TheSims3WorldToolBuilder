using System;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x02000031 RID: 49
	public class WallPatternRefEditor : SearchableItemRefUIEditor
	{
		// Token: 0x06000227 RID: 551 RVA: 0x0000C309 File Offset: 0x0000B309
		public WallPatternRefEditor()
		{
			this.PrototypeKey = DataStore.Instance.FindItemKey("Wall Pattern", 0L, 1365025997L, ItemType.PROTOTYPE);
		}
	}
}
