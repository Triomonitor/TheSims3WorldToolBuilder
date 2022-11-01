using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Crownwood.DotNetMagic.Controls;

namespace ToolUtil
{
	// Token: 0x02000014 RID: 20
	public class SearchableTreeControl : UserControl
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00004E94 File Offset: 0x00003E94
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004EB4 File Offset: 0x00003EB4
		private void InitializeComponent()
		{
			this.mLayoutPanel = new TableLayoutPanel();
			this.mSearchTextBox = new TextBox();
			this.mLabelLeft = new Label();
			this.mLabelSearch = new Label();
			this.mTreeControl = new TreeControl();
			this.mFilterText = new TextBox();
			this.mButtonRight = new ButtonWithStyle();
			this.mBackgroundPanel = new Panel();
			this.mLayoutPanel.SuspendLayout();
			this.mBackgroundPanel.SuspendLayout();
			base.SuspendLayout();
			this.mLayoutPanel.ColumnCount = 3;
			this.mLayoutPanel.ColumnStyles.Add(new ColumnStyle());
			this.mLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.mLayoutPanel.ColumnStyles.Add(new ColumnStyle());
			this.mLayoutPanel.Controls.Add(this.mSearchTextBox, 1, 2);
			this.mLayoutPanel.Controls.Add(this.mLabelLeft, 0, 0);
			this.mLayoutPanel.Controls.Add(this.mLabelSearch, 0, 2);
			this.mLayoutPanel.Controls.Add(this.mTreeControl, 0, 1);
			this.mLayoutPanel.Controls.Add(this.mFilterText, 1, 0);
			this.mLayoutPanel.Controls.Add(this.mButtonRight, 2, 0);
			this.mLayoutPanel.Dock = DockStyle.Fill;
			this.mLayoutPanel.Location = new Point(0, 0);
			this.mLayoutPanel.Margin = new Padding(1);
			this.mLayoutPanel.Name = "mLayoutPanel";
			this.mLayoutPanel.RowCount = 3;
			this.mLayoutPanel.RowStyles.Add(new RowStyle());
			this.mLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.mLayoutPanel.RowStyles.Add(new RowStyle());
			this.mLayoutPanel.Size = new Size(362, 468);
			this.mLayoutPanel.TabIndex = 0;
			this.mSearchTextBox.BorderStyle = BorderStyle.FixedSingle;
			this.mLayoutPanel.SetColumnSpan(this.mSearchTextBox, 2);
			this.mSearchTextBox.Dock = DockStyle.Fill;
			this.mSearchTextBox.Location = new Point(50, 446);
			this.mSearchTextBox.Margin = new Padding(2);
			this.mSearchTextBox.Name = "mSearchTextBox";
			this.mSearchTextBox.Size = new Size(310, 20);
			this.mSearchTextBox.TabIndex = 7;
			this.mSearchTextBox.KeyDown += this.SearchTextBox_KeyDown;
			this.mLabelLeft.AutoSize = true;
			this.mLabelLeft.Dock = DockStyle.Left;
			this.mLabelLeft.Location = new Point(2, 3);
			this.mLabelLeft.Margin = new Padding(2, 3, 2, 2);
			this.mLabelLeft.Name = "mLabelLeft";
			this.mLabelLeft.Size = new Size(32, 20);
			this.mLabelLeft.TabIndex = 0;
			this.mLabelLeft.Text = "Filter:";
			this.mLabelLeft.TextAlign = ContentAlignment.MiddleCenter;
			this.mLabelSearch.AutoSize = true;
			this.mLabelSearch.Dock = DockStyle.Left;
			this.mLabelSearch.Location = new Point(2, 446);
			this.mLabelSearch.Margin = new Padding(2);
			this.mLabelSearch.Name = "mLabelSearch";
			this.mLabelSearch.Size = new Size(44, 20);
			this.mLabelSearch.TabIndex = 6;
			this.mLabelSearch.Text = "Search:";
			this.mLabelSearch.TextAlign = ContentAlignment.MiddleCenter;
			this.mLayoutPanel.SetColumnSpan(this.mTreeControl, 3);
			this.mTreeControl.Dock = DockStyle.Fill;
			this.mTreeControl.FocusNode = null;
			this.mTreeControl.HotBackColor = Color.Empty;
			this.mTreeControl.HotForeColor = Color.Empty;
			this.mTreeControl.Location = new Point(2, 27);
			this.mTreeControl.Margin = new Padding(2);
			this.mTreeControl.Name = "mTreeControl";
			this.mTreeControl.SelectedNode = null;
			this.mTreeControl.SelectedNoFocusBackColor = SystemColors.Control;
			this.mTreeControl.Size = new Size(358, 415);
			this.mTreeControl.TabIndex = 2;
			this.mTreeControl.Text = "treeControl1";
			this.mFilterText.BorderStyle = BorderStyle.FixedSingle;
			this.mFilterText.Dock = DockStyle.Top;
			this.mFilterText.Location = new Point(50, 3);
			this.mFilterText.Margin = new Padding(2, 3, 2, 2);
			this.mFilterText.MinimumSize = new Size(100, 20);
			this.mFilterText.Name = "mFilterText";
			this.mFilterText.Size = new Size(288, 20);
			this.mFilterText.TabIndex = 0;
			this.mButtonRight.Dock = DockStyle.Fill;
			this.mButtonRight.Location = new Point(342, 3);
			this.mButtonRight.Margin = new Padding(2, 3, 2, 2);
			this.mButtonRight.Name = "mButtonRight";
			this.mButtonRight.Size = new Size(18, 20);
			this.mButtonRight.TabIndex = 1;
			this.mButtonRight.Text = "X";
			this.mButtonRight.Click += this.mButtonRight_Click;
			this.mBackgroundPanel.BorderStyle = BorderStyle.FixedSingle;
			this.mBackgroundPanel.Controls.Add(this.mLayoutPanel);
			this.mBackgroundPanel.Dock = DockStyle.Fill;
			this.mBackgroundPanel.Location = new Point(0, 0);
			this.mBackgroundPanel.Name = "mBackgroundPanel";
			this.mBackgroundPanel.Size = new Size(364, 470);
			this.mBackgroundPanel.TabIndex = 7;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.mBackgroundPanel);
			base.Name = "SearchableTreeControl";
			base.Size = new Size(364, 470);
			this.mLayoutPanel.ResumeLayout(false);
			this.mLayoutPanel.PerformLayout();
			this.mBackgroundPanel.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600008A RID: 138 RVA: 0x00005555 File Offset: 0x00004555
		// (remove) Token: 0x0600008B RID: 139 RVA: 0x0000556E File Offset: 0x0000456E
		public event EventHandler FilterChanged;

		// Token: 0x0600008C RID: 140 RVA: 0x000055A4 File Offset: 0x000045A4
		public SearchableTreeControl()
		{
			this.InitializeComponent();
			this.mTreeSearchHelper = new TreeSearchHelper(this.mTreeControl, this.mFilterText);
			this.mTreeSearchHelper.SearchChanged += this.SearchChanged;
			this.mTreeSearchHelper.SearchEnd += this.SearchEnd;
			ContextMenu contextMenu = new ContextMenu();
			contextMenu.MenuItems.Add(this.mMenuItemRegex);
			contextMenu.Popup += this.LabelContextMenu_Popup;
			this.mLabelLeft.ContextMenu = contextMenu;
			this.mMenuItemRegex.Click += this.mMenuItemRegex_Click;
			this.mSearchTextBox.GotFocus += this.SearchTextBox_GotFocus;
			this.mFilterText.TextChanged += delegate(object sender, EventArgs e)
			{
				if (this.FilterChanged != null)
				{
					this.FilterChanged(this, EventArgs.Empty);
				}
			};
			this.SetSearchUIVisibility(false);
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600008D RID: 141 RVA: 0x0000569B File Offset: 0x0000469B
		public TreeControl TreeControl
		{
			get
			{
				return this.mTreeControl;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600008E RID: 142 RVA: 0x000056A3 File Offset: 0x000046A3
		// (set) Token: 0x0600008F RID: 143 RVA: 0x000056B0 File Offset: 0x000046B0
		public string FilterLabelName
		{
			get
			{
				return this.mLabelLeft.Text;
			}
			set
			{
				this.mLabelLeft.Text = value;
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000056BE File Offset: 0x000046BE
		public void ClearFilter()
		{
			this.mTreeSearchHelper.Reset(null);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000056CC File Offset: 0x000046CC
		private void LabelContextMenu_Popup(object sender, EventArgs e)
		{
			this.mMenuItemRegex.Checked = this.mTreeSearchHelper.UseRegularExpressions;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000056E4 File Offset: 0x000046E4
		private void mMenuItemRegex_Click(object sender, EventArgs e)
		{
			this.mTreeSearchHelper.UseRegularExpressions = !this.mMenuItemRegex.Checked;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000056FF File Offset: 0x000046FF
		private void mMenuItemTreeCollapse_Click(object sender, EventArgs e)
		{
			this.mTreeControl.CollapseAll();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000570C File Offset: 0x0000470C
		private void mButtonRight_Click(object sender, EventArgs e)
		{
			this.mTreeSearchHelper.Reset(this.mTreeControl.SelectedNode);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00005724 File Offset: 0x00004724
		private void SearchChanged(SearchEventArgs e)
		{
			this.SetSearchUIVisibility(true);
			if (!this.mTextChangedHandled)
			{
				this.mTextChangedHandled = true;
				this.mSearchTextBox.TextChanged += this.SearchTextBox_TextChanged;
			}
			this.mSkipCurrent = e.mSkipCurrent;
			this.mBackwards = e.mBackwards;
			if (this.mSearchTextBox.Text == e.mSearchString)
			{
				this.SearchTextBox_TextChanged(null, EventArgs.Empty);
				return;
			}
			this.mSearchTextBox.Text = e.mSearchString;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000057AC File Offset: 0x000047AC
		private void SearchEnd()
		{
			if (this.mTextChangedHandled)
			{
				this.mSearchTextBox.TextChanged -= this.SearchTextBox_TextChanged;
				this.mTextChangedHandled = false;
			}
			this.SetSearchUIVisibility(false);
			this.mSearchTextBox.Text = string.Empty;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000057EC File Offset: 0x000047EC
		private void SearchTextBox_GotFocus(object sender, EventArgs e)
		{
			if (!this.mTextChangedHandled)
			{
				this.mTextChangedHandled = true;
				this.mSearchTextBox.TextChanged += this.SearchTextBox_TextChanged;
			}
			this.mSearchTextBox.SelectionStart = this.mSearchTextBox.Text.Length;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000583A File Offset: 0x0000483A
		private void SearchTextBox_TextChanged(object sender, EventArgs e)
		{
			this.mTreeSearchHelper.SetIncrementalSearchString(this.mSearchTextBox.Text);
			this.mTreeSearchHelper.FindNextIncrementalSearchMatch(this.mSkipCurrent, this.mBackwards);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00005869 File Offset: 0x00004869
		private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.F3)
			{
				this.mTreeSearchHelper.mTree_KeyDown(sender, e);
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000588C File Offset: 0x0000488C
		private void SetSearchUIVisibility(bool bVisible)
		{
			if (bVisible)
			{
				this.mLayoutPanel.Controls.Add(this.mLabelSearch, 0, 2);
				this.mLayoutPanel.Controls.Add(this.mSearchTextBox, 1, 2);
				return;
			}
			this.mLayoutPanel.Controls.Remove(this.mLabelSearch);
			this.mLayoutPanel.Controls.Remove(this.mSearchTextBox);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000058FC File Offset: 0x000048FC
		public MenuItem[] GetPopupMenuItems()
		{
			MenuItem menuItem = new MenuItem("Collapse all nodes");
			menuItem.Click += this.mMenuItemTreeCollapse_Click;
			return new MenuItem[]
			{
				menuItem
			};
		}

		// Token: 0x0400004A RID: 74
		private IContainer components;

		// Token: 0x0400004B RID: 75
		private TableLayoutPanel mLayoutPanel;

		// Token: 0x0400004C RID: 76
		private Label mLabelLeft;

		// Token: 0x0400004D RID: 77
		private TreeControl mTreeControl;

		// Token: 0x0400004E RID: 78
		private TextBox mFilterText;

		// Token: 0x0400004F RID: 79
		private ButtonWithStyle mButtonRight;

		// Token: 0x04000050 RID: 80
		private Panel mBackgroundPanel;

		// Token: 0x04000051 RID: 81
		private Label mLabelSearch;

		// Token: 0x04000052 RID: 82
		private TextBox mSearchTextBox;

		// Token: 0x04000054 RID: 84
		private TreeSearchHelper mTreeSearchHelper;

		// Token: 0x04000055 RID: 85
		private MenuItem mMenuItemRegex = new MenuItem("Use Regular Expressions");

		// Token: 0x04000056 RID: 86
		private bool mTextChangedHandled;

		// Token: 0x04000057 RID: 87
		private bool mSkipCurrent;

		// Token: 0x04000058 RID: 88
		private bool mBackwards;
	}
}
