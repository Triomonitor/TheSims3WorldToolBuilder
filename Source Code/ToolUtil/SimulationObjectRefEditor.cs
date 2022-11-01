using System;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x02000036 RID: 54
	public class SimulationObjectRefEditor : SearchableItemRefUIEditor
	{
		// Token: 0x0600022C RID: 556 RVA: 0x0000C3C7 File Offset: 0x0000B3C7
		public SimulationObjectRefEditor()
		{
			this.ClassKey = DataStore.Instance.FindItemKey("SimulationObject", 0L, 47985727L, ItemType.CLASS);
		}
	}
}
