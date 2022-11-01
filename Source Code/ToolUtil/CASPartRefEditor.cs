using System;
using System.ComponentModel;
using CommonUIControls;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x0200002F RID: 47
	public class CASPartRefEditor : SearchableItemRefUIEditor
	{
		// Token: 0x06000224 RID: 548 RVA: 0x0000C276 File Offset: 0x0000B276
		public CASPartRefEditor()
		{
			this.ClassKey = DataStore.Instance.FindItemKey("CASPartData", 0L, 55242443L, ItemType.CLASS);
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000C29C File Offset: 0x0000B29C
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			DbReference dbReference = base.EditValue(context, provider, value) as DbReference;
			return new OptionalDbReference
			{
				ResourceType = dbReference.ResourceType,
				Group = dbReference.Group,
				Instance = dbReference.Instance
			};
		}
	}
}
