using System;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x02000038 RID: 56
	public class ModularStairsRefEditor : SearchableItemRefUIEditor
	{
		// Token: 0x0600022E RID: 558 RVA: 0x0000C413 File Offset: 0x0000B413
		public ModularStairsRefEditor()
		{
			this.PrototypeKey = DataStore.Instance.FindItemKey("ModularStairs", 0L, 77374669L, ItemType.PROTOTYPE);
		}
	}
}
