using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms.Design;
using CommonUIControls;
using Crownwood.DotNetMagic.Controls;
using Sims3;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x0200002E RID: 46
	public class SearchableItemRefUIEditor : ItemRefUIEditor
	{
		// Token: 0x06000221 RID: 545 RVA: 0x0000BE70 File Offset: 0x0000AE70
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context == null || provider == null)
			{
				return base.EditValue(context, provider, value);
			}
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (windowsFormsEditorService == null)
			{
				return base.EditValue(context, provider, value);
			}
			DataStore instance = DataStore.Instance;
			if (this.ClassKey == null && this.PrototypeKey == null)
			{
				return base.EditValue(context, provider, value);
			}
			SearchableTreeControl searchableTreeControl = new SearchableTreeControl();
			ItemKey itemKey = new ItemKey("<none>", 0L, 55242443L, ItemType.INSTANCE);
			Node node = new Node(itemKey.Name);
			node.Tag = itemKey;
			searchableTreeControl.TreeControl.Nodes.Add(node);
			List<ItemKey> list = new List<ItemKey>();
			if (this.ClassKey != null)
			{
				list = instance.GetPrototypeKeysOfClass(this.ClassKey);
			}
			if (this.PrototypeKey != null)
			{
				list.Add(this.PrototypeKey);
			}
			foreach (ItemKey itemKey2 in list)
			{
				List<ItemKey> instanceKeysOfPrototype = instance.GetInstanceKeysOfPrototype(itemKey2);
				foreach (OpenObject openObject in instance.OpenObjects.Values)
				{
					if (openObject.NewInstance && openObject.PrototypeKey.Equals(itemKey2))
					{
						instanceKeysOfPrototype.Add(openObject.InstanceKey);
					}
				}
				string text = itemKey2.Name;
				if (itemKey2.GroupId != 0L)
				{
					text = text + " [0x" + itemKey2.GroupId.ToString("x") + "]";
				}
				Node node2 = new Node(text);
				node2.Tag = itemKey2;
				searchableTreeControl.TreeControl.Nodes.Add(node2);
				searchableTreeControl.Tag = windowsFormsEditorService;
				foreach (ItemKey itemKey3 in instanceKeysOfPrototype)
				{
					text = itemKey3.Name;
					if (itemKey3.GroupId != 0L)
					{
						try
						{
							SKU skuFromGroupId = SKUManager.GetSkuFromGroupId((uint)itemKey3.GroupId);
							text += string.Format(" [{0}]", skuFromGroupId);
						}
						catch (Exception)
						{
							text = text + " [0x" + itemKey3.GroupId.ToString("x") + "]";
						}
					}
					Node node3 = new Node(text);
					node3.Tag = itemKey3;
					node2.Nodes.Add(node3);
				}
			}
			searchableTreeControl.Width = 300;
			searchableTreeControl.Height = 300;
			searchableTreeControl.TreeControl.ExpandAll();
			searchableTreeControl.TreeControl.SelectMode = SelectMode.Single;
			searchableTreeControl.TreeControl.DoubleClick += this.SearchableTreeControl_DoubleClick;
			searchableTreeControl.TreeControl.Tag = windowsFormsEditorService;
			windowsFormsEditorService.DropDownControl(searchableTreeControl);
			if (searchableTreeControl.TreeControl.SelectedNode != null)
			{
				ItemKey itemKey4 = (ItemKey)searchableTreeControl.TreeControl.SelectedNode.Tag;
				DbReference dbReference = new DbReference();
				if (itemKey4.Name == "<none>")
				{
					dbReference.Instance = string.Empty;
				}
				else
				{
					if (itemKey4.KeyType != ItemType.INSTANCE)
					{
						return value;
					}
					dbReference.Instance = itemKey4.Name;
					dbReference.Group = (uint)itemKey4.GroupId;
					dbReference.ResourceType = itemKey4.ResourceType;
				}
				return dbReference;
			}
			return value;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000C248 File Offset: 0x0000B248
		private void SearchableTreeControl_DoubleClick(object sender, EventArgs e)
		{
			TreeControl treeControl = sender as TreeControl;
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)treeControl.Tag;
			windowsFormsEditorService.CloseDropDown();
		}
	}
}
