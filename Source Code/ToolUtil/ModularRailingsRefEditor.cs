using System;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x02000039 RID: 57
	public class ModularRailingsRefEditor : SearchableItemRefUIEditor
	{
		// Token: 0x0600022F RID: 559 RVA: 0x0000C439 File Offset: 0x0000B439
		public ModularRailingsRefEditor()
		{
			this.PrototypeKey = DataStore.Instance.FindItemKey("ModularRailings", 0L, 80052483L, ItemType.PROTOTYPE);
		}
	}
}
