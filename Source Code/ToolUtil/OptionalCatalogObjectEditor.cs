using System;
using System.Collections.Generic;
using System.ComponentModel;
using CommonUIControls;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x0200003A RID: 58
	public class OptionalCatalogObjectEditor : SearchableItemRefUIEditor
	{
		// Token: 0x06000230 RID: 560 RVA: 0x0000C460 File Offset: 0x0000B460
		public OptionalCatalogObjectEditor()
		{
			DataStore instance = DataStore.Instance;
			this.ClassKey = instance.FindItemKey("GameObject", 0L, 329217425L, ItemType.CLASS);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000C494 File Offset: 0x0000B494
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			DbReference dbReference = base.EditValue(context, provider, value) as DbReference;
			return new OptionalDbReference
			{
				ResourceType = dbReference.ResourceType,
				Group = dbReference.Group,
				Instance = dbReference.Instance,
				DatabaseId = this.GetKeyForInstance(dbReference.Instance)
			};
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000C4F0 File Offset: 0x0000B4F0
		private ulong GetKeyForInstance(string instanceName)
		{
			DataStore instance = DataStore.Instance;
			List<ObjectInstance> list = new List<ObjectInstance>(instance.GetInstancesForClassKey(this.ClassKey));
			foreach (ObjectInstance objectInstance in list)
			{
				if (objectInstance.Name == instanceName)
				{
					return (ulong)objectInstance.Id;
				}
			}
			return 0UL;
		}
	}
}
