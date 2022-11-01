using System;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x02000035 RID: 53
	public class RoofPatternRefEditor : SearchableItemRefUIEditor
	{
		// Token: 0x0600022B RID: 555 RVA: 0x0000C3A1 File Offset: 0x0000B3A1
		public RoofPatternRefEditor()
		{
			this.PrototypeKey = DataStore.Instance.FindItemKey("Roof Pattern", 0L, (long)((ulong)-236077690), ItemType.PROTOTYPE);
		}
	}
}
