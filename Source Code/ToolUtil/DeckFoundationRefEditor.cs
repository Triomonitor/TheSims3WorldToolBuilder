using System;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x02000034 RID: 52
	public class DeckFoundationRefEditor : SearchableItemRefUIEditor
	{
		// Token: 0x0600022A RID: 554 RVA: 0x0000C37B File Offset: 0x0000B37B
		public DeckFoundationRefEditor()
		{
			this.ClassKey = DataStore.Instance.FindItemKey("CatalogProductDeckFoundation", 0L, 829192434L, ItemType.CLASS);
		}
	}
}
