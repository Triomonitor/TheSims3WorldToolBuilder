using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Crownwood.DotNetMagic.Common;
using Crownwood.DotNetMagic.Controls;
using Sims3.DbDataLayer;

namespace ToolUtil.Database
{
	// Token: 0x02000018 RID: 24
	public class PendingInstanceBrowser : UserControl
	{
		// Token: 0x06000169 RID: 361 RVA: 0x000089CE File Offset: 0x000079CE
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000089F0 File Offset: 0x000079F0
		private void InitializeComponent()
		{
			this.mTreeView = new TreeControl();
			base.SuspendLayout();
			this.mTreeView.AutoEdit = false;
			this.mTreeView.Dock = DockStyle.Fill;
			this.mTreeView.FocusNode = null;
			this.mTreeView.HotBackColor = Color.Empty;
			this.mTreeView.HotForeColor = Color.Empty;
			this.mTreeView.Location = new Point(0, 0);
			this.mTreeView.Name = "mTreeView";
			this.mTreeView.SelectedNode = null;
			this.mTreeView.SelectedNoFocusBackColor = SystemColors.Control;
			this.mTreeView.Size = new Size(498, 244);
			this.mTreeView.TabIndex = 0;
			this.mTreeView.Text = "treeControl1";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(498, 244);
			base.Controls.Add(this.mTreeView);
			base.Name = "PendingInstanceBrowser";
			this.Text = "PendingInstanceBrowser";
			base.Load += this.PendingInstanceBrowser_Load;
			base.ResumeLayout(false);
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00008B37 File Offset: 0x00007B37
		public MenuItem UndoEdit
		{
			get
			{
				return this.mUndoEdit;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00008B3F File Offset: 0x00007B3F
		public MenuItem Submit
		{
			get
			{
				return this.mSubmit;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00008B47 File Offset: 0x00007B47
		public MenuItem Export
		{
			get
			{
				return this.mExport;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00008B4F File Offset: 0x00007B4F
		public TreeControl TreeView
		{
			get
			{
				return this.mTreeView;
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00008B98 File Offset: 0x00007B98
		public PendingInstanceBrowser()
		{
			this.InitializeComponent();
			this.mImageList = ResourceHelper.LoadBitmapStrip(base.GetType(), "ToolUtil.icons.bmp", new Size(16, 16));
			this.mContextMenu = new ContextMenu();
			this.mUndoEdit = new MenuItem("&Undo Edit");
			this.mExport = new MenuItem("&Export");
			this.mSubmit = new MenuItem("&Submit...");
			this.mContextMenu.MenuItems.Add(this.mUndoEdit);
			this.mContextMenu.MenuItems.Add(this.mExport);
			this.mContextMenu.MenuItems.Add(this.mSubmit);
			this.mTreeView.ContextMenuNode = this.mContextMenu;
			this.mTreeView.ContextMenuSpace = this.mContextMenu;
			DataStore.Instance.InstancesCleared += delegate(object o, EventArgs e)
			{
				this.mTreeView.Nodes.Clear();
			};
			DataStore.Instance.InstanceAdded += delegate(object o, InstanceEventArgs e)
			{
				this.AddInstance(e.PrototypeKey, e.InstanceKey);
			};
			DataStore.Instance.InstanceRemoved += delegate(object o, InstanceEventArgs e)
			{
				this.RemoveInstance(e.PrototypeKey.Name, e.InstanceKey);
			};
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00008CCC File Offset: 0x00007CCC
		private void UpdateList()
		{
			this.mTreeView.Nodes.Clear();
			Dictionary<ItemKey, OpenObject> openObjects = DataStore.Instance.OpenObjects;
			foreach (OpenObject openObject in openObjects.Values)
			{
				this.AddInstance(openObject.PrototypeKey, openObject.InstanceKey);
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00008D48 File Offset: 0x00007D48
		private void AddInstance(ItemKey prototypeKey, ItemKey instanceKey)
		{
			Node node = null;
			foreach (object obj in this.mTreeView.Nodes)
			{
				Node node2 = (Node)obj;
				if (node2.Text == prototypeKey.Name)
				{
					node = node2;
					break;
				}
			}
			if (node == null)
			{
				node = new Node(prototypeKey.Name);
				node.Tag = prototypeKey;
				this.mTreeView.Nodes.Add(node);
			}
			foreach (object obj2 in node.Nodes)
			{
				Node node3 = (Node)obj2;
				ItemKey itemKey = node3.Tag as ItemKey;
				if (itemKey != null && itemKey.Equals(instanceKey))
				{
					return;
				}
			}
			Node node4 = new Node(instanceKey.Name);
			node4.Tag = instanceKey;
			node4.Image = this.mImageList.Images[1];
			node.Nodes.Add(node4);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00008E84 File Offset: 0x00007E84
		private void RemoveInstance(string prototype, ItemKey instanceKey)
		{
			Node node = null;
			foreach (object obj in this.mTreeView.Nodes)
			{
				Node node2 = (Node)obj;
				if (node2.Text == prototype)
				{
					node = node2;
					break;
				}
			}
			if (node != null)
			{
				foreach (object obj2 in node.Nodes)
				{
					Node node3 = (Node)obj2;
					if (node3.Tag != null && node3.Tag is ItemKey)
					{
						ItemKey itemKey = node3.Tag as ItemKey;
						if (itemKey.Equals(instanceKey))
						{
							node.Nodes.Remove(node3);
							if (node.Nodes.Count == 0)
							{
								this.mTreeView.Nodes.Remove(node);
							}
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00008F9C File Offset: 0x00007F9C
		public void RemoveExportMenuItem()
		{
			this.mContextMenu.MenuItems.Remove(this.mExport);
			this.mExport = null;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00008FBB File Offset: 0x00007FBB
		private void PendingInstanceBrowser_Load(object sender, EventArgs e)
		{
			this.UpdateList();
		}

		// Token: 0x040000B9 RID: 185
		private IContainer components;

		// Token: 0x040000BA RID: 186
		private TreeControl mTreeView;

		// Token: 0x040000BB RID: 187
		private MenuItem mUndoEdit;

		// Token: 0x040000BC RID: 188
		private MenuItem mSubmit;

		// Token: 0x040000BD RID: 189
		private MenuItem mExport;

		// Token: 0x040000BE RID: 190
		private ImageList mImageList;

		// Token: 0x040000BF RID: 191
		private ContextMenu mContextMenu;
	}
}
