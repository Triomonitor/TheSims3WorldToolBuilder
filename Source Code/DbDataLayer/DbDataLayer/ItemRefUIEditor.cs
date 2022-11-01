using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CommonUIControls;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000077 RID: 119
	public class ItemRefUIEditor : UITypeEditor
	{
		// Token: 0x060003EC RID: 1004 RVA: 0x0000B860 File Offset: 0x0000A860
		public ItemRefUIEditor()
		{
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0000B868 File Offset: 0x0000A868
		public ItemRefUIEditor(ItemKey key)
		{
			this.mPrototypeKey = key;
			this.mClassKey = null;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0000B87E File Offset: 0x0000A87E
		public ItemRefUIEditor(string name, uint group, long resourcetype)
		{
			this.mPrototypeKey = new ItemKey(name, (long)((ulong)group), resourcetype, ItemType.PROTOTYPE);
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x0000B896 File Offset: 0x0000A896
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x0000B89E File Offset: 0x0000A89E
		public virtual ItemKey PrototypeKey
		{
			get
			{
				return this.mPrototypeKey;
			}
			set
			{
				this.mPrototypeKey = value;
				if (value != null)
				{
					this.mClassKey = null;
				}
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x0000B8B1 File Offset: 0x0000A8B1
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x0000B8B9 File Offset: 0x0000A8B9
		public virtual ItemKey ClassKey
		{
			get
			{
				return this.mClassKey;
			}
			set
			{
				this.mClassKey = value;
				if (value != null)
				{
					this.mPrototypeKey = null;
				}
			}
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000B8CC File Offset: 0x0000A8CC
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000B8D0 File Offset: 0x0000A8D0
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
			if (this.PrototypeKey != null)
			{
				List<ItemKey> instanceKeysOfPrototype = instance.GetInstanceKeysOfPrototype(this.PrototypeKey);
				foreach (OpenObject openObject in instance.OpenObjects.Values)
				{
					if (openObject.NewInstance && openObject.PrototypeKey.Equals(this.PrototypeKey))
					{
						instanceKeysOfPrototype.Add(openObject.InstanceKey);
					}
				}
				instanceKeysOfPrototype.Sort(new Comparison<ItemKey>(ItemRefUIEditor.CompareItemKeys));
				return this.SetupListBox(context, provider, value, windowsFormsEditorService, instanceKeysOfPrototype);
			}
			if (this.ClassKey != null)
			{
				List<ObjectInstance> instancesForClassKey = instance.GetInstancesForClassKey(this.ClassKey);
				List<ItemKey> prototypeKeysOfClass = instance.GetPrototypeKeysOfClass(this.ClassKey);
				List<ItemKey> list = new List<ItemKey>();
				foreach (ObjectInstance item in instancesForClassKey)
				{
					list.Add(item);
				}
				foreach (OpenObject openObject2 in instance.OpenObjects.Values)
				{
					if (openObject2.NewInstance && prototypeKeysOfClass.Contains(openObject2.PrototypeKey))
					{
						list.Add(openObject2.InstanceKey);
					}
				}
				list.Sort(new Comparison<ItemKey>(ItemRefUIEditor.CompareItemKeys));
				return this.SetupListBox(context, provider, value, windowsFormsEditorService, list);
			}
			List<ItemKey> prototypesList = instance.GetPrototypesList();
			if (prototypesList.Count == 0)
			{
				return base.EditValue(context, provider, value);
			}
			TreeView treeView = new TreeView();
			foreach (ItemKey itemKey in prototypesList)
			{
				List<ItemKey> instanceKeysOfPrototype2 = instance.GetInstanceKeysOfPrototype(itemKey);
				foreach (OpenObject openObject3 in instance.OpenObjects.Values)
				{
					if (openObject3.NewInstance && openObject3.PrototypeKey.Equals(itemKey))
					{
						instanceKeysOfPrototype2.Add(openObject3.InstanceKey);
					}
				}
				if (instanceKeysOfPrototype2.Count != 0)
				{
					instanceKeysOfPrototype2.Sort(new Comparison<ItemKey>(ItemRefUIEditor.CompareItemKeys));
					string text = itemKey.Name;
					if (itemKey.GroupId != 0L)
					{
						text = text + " [0x" + itemKey.GroupId.ToString("x") + "]";
					}
					TreeNode treeNode = new TreeNode(text);
					treeNode.Tag = itemKey;
					treeView.Nodes.Add(treeNode);
					foreach (ItemKey itemKey2 in instanceKeysOfPrototype2)
					{
						text = itemKey2.Name;
						if (itemKey2.GroupId != 0L)
						{
							text = text + " [0x" + itemKey2.GroupId.ToString("x") + "]";
						}
						TreeNode treeNode2 = new TreeNode(text);
						treeNode2.Tag = itemKey2;
						treeNode.Nodes.Add(treeNode2);
					}
				}
			}
			treeView.DoubleClick += this.TreeView_DoubleClick;
			treeView.Tag = windowsFormsEditorService;
			treeView.Width = 300;
			treeView.Height = 400;
			windowsFormsEditorService.DropDownControl(treeView);
			if (treeView.SelectedNode != null)
			{
				ItemKey itemKey3 = (ItemKey)treeView.SelectedNode.Tag;
				if (itemKey3.KeyType == ItemType.INSTANCE)
				{
					return new DbReference
					{
						Instance = itemKey3.Name,
						Group = (uint)itemKey3.GroupId,
						ResourceType = itemKey3.ResourceType
					};
				}
			}
			return value;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000BD78 File Offset: 0x0000AD78
		private object SetupListBox(ITypeDescriptorContext context, IServiceProvider provider, object value, IWindowsFormsEditorService editor, List<ItemKey> itemKeys)
		{
			if (itemKeys.Count == 0)
			{
				return base.EditValue(context, provider, value);
			}
			ListBox listBox = new ListBox();
			listBox.SelectionMode = SelectionMode.One;
			ItemKey k = new ItemKey("<none>", 0L, 55242443L, ItemType.INSTANCE);
			listBox.Items.Add(new ItemRefUIEditor.ItemKeyFormatter(k));
			foreach (ItemKey k2 in itemKeys)
			{
				ItemRefUIEditor.ItemKeyFormatter item = new ItemRefUIEditor.ItemKeyFormatter(k2);
				listBox.Items.Add(item);
			}
			listBox.Tag = editor;
			listBox.Width = 300;
			listBox.Height = 400;
			listBox.DoubleClick += this.ListBox_DoubleClick;
			editor.DropDownControl(listBox);
			if (listBox.SelectedItem != null)
			{
				ItemRefUIEditor.ItemKeyFormatter itemKeyFormatter = (ItemRefUIEditor.ItemKeyFormatter)listBox.SelectedItem;
				ItemKey mItemKey = itemKeyFormatter.mItemKey;
				DbReference dbReference = new DbReference();
				if (mItemKey.Name == "<none>")
				{
					dbReference.Instance = string.Empty;
				}
				else
				{
					dbReference.Instance = mItemKey.Name;
				}
				dbReference.Group = (uint)mItemKey.GroupId;
				dbReference.ResourceType = mItemKey.ResourceType;
				return dbReference;
			}
			return base.EditValue(context, provider, value);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000BED0 File Offset: 0x0000AED0
		private static int CompareItemKeys(ItemKey key1, ItemKey key2)
		{
			return key1.Name.CompareTo(key2.Name);
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000BEE4 File Offset: 0x0000AEE4
		private void ListBox_DoubleClick(object sender, EventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)listBox.Tag;
			windowsFormsEditorService.CloseDropDown();
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000BF0C File Offset: 0x0000AF0C
		private void TreeView_DoubleClick(object sender, EventArgs e)
		{
			TreeView treeView = (TreeView)sender;
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)treeView.Tag;
			windowsFormsEditorService.CloseDropDown();
		}

		// Token: 0x040000FA RID: 250
		protected ItemKey mPrototypeKey;

		// Token: 0x040000FB RID: 251
		protected ItemKey mClassKey;

		// Token: 0x02000078 RID: 120
		public class ItemKeyFormatter
		{
			// Token: 0x060003F9 RID: 1017 RVA: 0x0000BF32 File Offset: 0x0000AF32
			public ItemKeyFormatter(ItemKey k)
			{
				this.mItemKey = k;
			}

			// Token: 0x060003FA RID: 1018 RVA: 0x0000BF44 File Offset: 0x0000AF44
			public override string ToString()
			{
				if (this.mItemKey == null)
				{
					return "";
				}
				string result;
				if (this.mItemKey.GroupId != 0L)
				{
					result = string.Format("{0}  [Group:{1}]", this.mItemKey.Name, this.mItemKey.GroupId);
				}
				else
				{
					result = this.mItemKey.Name;
				}
				return result;
			}

			// Token: 0x040000FC RID: 252
			public ItemKey mItemKey;
		}
	}
}
