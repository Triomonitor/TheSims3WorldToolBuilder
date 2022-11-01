using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Crownwood.DotNetMagic.Controls;

namespace ToolUtil
{
	// Token: 0x0200003E RID: 62
	public class TreeSearchHelper
	{
		// Token: 0x1400003C RID: 60
		// (add) Token: 0x0600023C RID: 572 RVA: 0x0000C589 File Offset: 0x0000B589
		// (remove) Token: 0x0600023D RID: 573 RVA: 0x0000C5A2 File Offset: 0x0000B5A2
		public event SearchEventHandler SearchChanged;

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x0600023E RID: 574 RVA: 0x0000C5BB File Offset: 0x0000B5BB
		// (remove) Token: 0x0600023F RID: 575 RVA: 0x0000C5D4 File Offset: 0x0000B5D4
		public event ZeroArgsDelegate SearchEnd;

		// Token: 0x06000240 RID: 576 RVA: 0x0000C5F0 File Offset: 0x0000B5F0
		public TreeSearchHelper(TreeControl tree, TextBox searchBox)
		{
			this.mTree = tree;
			this.mFilterBox = searchBox;
			this.InitializeTimers();
			this.AttatchEventHandlers();
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000C63E File Offset: 0x0000B63E
		private void InitializeTimers()
		{
			this.mFilterBoxTimer = new Timer();
			this.mFilterBoxTimer.Interval = 200;
			this.mIncrementalSearchTimer = new Timer();
			this.mIncrementalSearchTimer.Interval = 5000;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000C678 File Offset: 0x0000B678
		private void AttatchEventHandlers()
		{
			this.mTree.Nodes.Inserted += this.mTree_Nodes_Inserted;
			this.mFilterBox.KeyPress += this.mFilterBox_KeyPress;
			this.mTree.KeyDown += this.mTree_KeyDown;
			this.mFilterBoxTimer.Tick += this.mFilterBoxTimer_Tick;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000C6E8 File Offset: 0x0000B6E8
		private void mTree_Nodes_Inserted(int index, object value)
		{
			if (this.IsFiltered)
			{
				Node currentNode = value as Node;
				if (value != null)
				{
					this.ShowNodeIfMatching(currentNode, true);
				}
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000244 RID: 580 RVA: 0x0000C70F File Offset: 0x0000B70F
		// (set) Token: 0x06000245 RID: 581 RVA: 0x0000C717 File Offset: 0x0000B717
		public bool UseRegularExpressions
		{
			get
			{
				return this.mUseRegularExpressions;
			}
			set
			{
				this.mUseRegularExpressions = value;
				if (!this.mUseRegularExpressions)
				{
					this.mFilterBoxRegex = null;
				}
				this.ShowOnlyMatchingNodes(this.mTree.SelectedNode);
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000246 RID: 582 RVA: 0x0000C740 File Offset: 0x0000B740
		public bool IsFiltered
		{
			get
			{
				return this.mFilterBox.Text != "";
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000247 RID: 583 RVA: 0x0000C757 File Offset: 0x0000B757
		// (set) Token: 0x06000248 RID: 584 RVA: 0x0000C75F File Offset: 0x0000B75F
		public bool IncrementalSearchUsesContains
		{
			get
			{
				return this.mIncrementalSearchUsesContains;
			}
			set
			{
				this.mIncrementalSearchUsesContains = value;
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000C768 File Offset: 0x0000B768
		public void SetIncrementalSearchString(string incrementalString)
		{
			this.mIncrementalSearchString = incrementalString;
			if (!this.mIncrementalSearchTickHandled)
			{
				this.mIncrementalSearchTimer.Tick += this.mIncrementalSearchTimer_Tick;
				this.mIncrementalSearchTickHandled = true;
			}
			this.mIncrementalSearchTimer.Stop();
			this.mIncrementalSearchTimer.Start();
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000C7B8 File Offset: 0x0000B7B8
		public void mTree_KeyDown(object sender, KeyEventArgs e)
		{
			this.mIncrementalSearchTimer.Stop();
			e.Handled = true;
			Keys keyCode = e.KeyCode;
			if (keyCode <= Keys.Escape)
			{
				if (keyCode != Keys.Back)
				{
					if (keyCode != Keys.Escape)
					{
						goto IL_109;
					}
					if (this.mIncrementalSearchTickHandled)
					{
						this.mIncrementalSearchTimer.Tick -= this.mIncrementalSearchTimer_Tick;
						this.mIncrementalSearchTickHandled = false;
					}
					this.mLastSearchedString = this.mIncrementalSearchString;
					this.mIncrementalSearchString = string.Empty;
					if (this.SearchEnd != null)
					{
						this.SearchEnd();
						return;
					}
					return;
				}
			}
			else if (keyCode != Keys.Delete)
			{
				if (keyCode != Keys.F3)
				{
					goto IL_109;
				}
				if (this.mIncrementalSearchString == string.Empty && this.mLastSearchedString != string.Empty)
				{
					this.mIncrementalSearchString = this.mLastSearchedString;
				}
				this.DoIncrementalSearch(true, e.Shift);
				return;
			}
			if (this.mIncrementalSearchString.Length > 0)
			{
				this.mIncrementalSearchString = this.mIncrementalSearchString.Substring(0, this.mIncrementalSearchString.Length - 1);
				this.DoIncrementalSearch(false, false);
				return;
			}
			return;
			IL_109:
			if (!char.IsLetterOrDigit((char)e.KeyValue))
			{
				this.mIncrementalSearchTimer.Stop();
				this.mIncrementalSearchTimer.Start();
				return;
			}
			this.mIncrementalSearchString = (this.mIncrementalSearchString + (char)e.KeyValue).ToLower();
			this.DoIncrementalSearch(false, false);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000C920 File Offset: 0x0000B920
		private void DoIncrementalSearch(bool skipCurrent, bool bBackwards)
		{
			if (this.SearchChanged != null)
			{
				this.SearchChanged(new SearchEventArgs(this.mIncrementalSearchString, skipCurrent, bBackwards));
			}
			if (!this.mIncrementalSearchTickHandled)
			{
				this.mIncrementalSearchTimer.Tick += this.mIncrementalSearchTimer_Tick;
				this.mIncrementalSearchTickHandled = true;
			}
			this.mIncrementalSearchTimer.Stop();
			this.mIncrementalSearchTimer.Start();
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000C989 File Offset: 0x0000B989
		private void mFilterBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.mFilterBoxTimer.Start();
			this.mFilterBoxRegex = null;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000C9A0 File Offset: 0x0000B9A0
		private void mFilterBoxTimer_Tick(object sender, EventArgs e)
		{
			this.mFilterBoxTimer.Stop();
			if (this.UseRegularExpressions)
			{
				try
				{
					this.mFilterBoxRegex = new Regex(this.mFilterBox.Text);
					this.mToolTip.SetToolTip(this.mFilterBox, null);
					this.mFilterBox.ForeColor = Color.Black;
				}
				catch (ArgumentException ex)
				{
					this.mToolTip.SetToolTip(this.mFilterBox, ex.Message);
					this.mFilterBox.ForeColor = Color.Red;
				}
			}
			this.ShowOnlyMatchingNodes(this.mTree.SelectedNode);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000CA48 File Offset: 0x0000BA48
		private void mIncrementalSearchTimer_Tick(object sender, EventArgs e)
		{
			this.mLastSearchedString = this.mIncrementalSearchString;
			this.mIncrementalSearchString = string.Empty;
			if (this.mIncrementalSearchTickHandled)
			{
				this.mIncrementalSearchTimer.Tick -= this.mIncrementalSearchTimer_Tick;
				this.mIncrementalSearchTickHandled = false;
			}
			if (this.SearchEnd != null)
			{
				this.SearchEnd();
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000CAA8 File Offset: 0x0000BAA8
		public void FindNextIncrementalSearchMatch(bool skipCurrent, bool backwards)
		{
			if (this.mTree.SelectedNode == null)
			{
				this.mTree.SelectedNode = this.FindNextIncrementalSearchMatch(null, this.mTree.GetFirstNode(), backwards);
				return;
			}
			if (this.mIncrementalSearchString == string.Empty)
			{
				this.mTree.SelectedNode = this.mTree.GetFirstNode();
				return;
			}
			if (skipCurrent || !this.MatchesIncrementalSearch(this.mTree.SelectedNode))
			{
				Node currentNode;
				if (!backwards)
				{
					currentNode = this.mTree.SelectedNode.NextNode;
				}
				else
				{
					currentNode = this.mTree.SelectedNode.PreviousNode;
				}
				Node node = this.FindNextIncrementalSearchMatch(this.mTree.SelectedNode, currentNode, backwards);
				if (node != null)
				{
					this.mTree.SelectedNode = node;
					return;
				}
				this.mTree.SelectedNode = this.mTree.GetFirstNode();
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000CB84 File Offset: 0x0000BB84
		private Node FindNextIncrementalSearchMatch(Node startNode, Node currentNode, bool backwards)
		{
			for (;;)
			{
				if (currentNode == null)
				{
					if (!backwards)
					{
						currentNode = this.mTree.GetFirstNode();
					}
					else
					{
						currentNode = this.mTree.GetLastNode();
					}
				}
				if (this.MatchesIncrementalSearch(currentNode))
				{
					break;
				}
				if (currentNode == startNode)
				{
					goto Block_3;
				}
				if (!backwards)
				{
					currentNode = currentNode.NextNode;
				}
				else
				{
					currentNode = currentNode.PreviousNode;
				}
				if (currentNode == null)
				{
					goto Block_5;
				}
			}
			return currentNode;
			Block_3:
			return null;
			Block_5:
			return null;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000CBE0 File Offset: 0x0000BBE0
		private bool MatchesIncrementalSearch(Node currentNode)
		{
			if (this.IncrementalSearchUsesContains)
			{
				return currentNode.Text.ToLower().Contains(this.mIncrementalSearchString.ToLower());
			}
			return currentNode.Text.ToLower().StartsWith(this.mIncrementalSearchString.ToLower());
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000CC2C File Offset: 0x0000BC2C
		private void ShowOnlyMatchingNodes(Node currentSelection)
		{
			lock (this.mTree)
			{
				this.mTree.SuspendLayout();
				if (this.IsFiltered)
				{
					for (Node node = this.mTree.GetFirstNode(); node != null; node = node.NextNode)
					{
						this.ShowNodeIfMatching(node, true);
					}
				}
				else
				{
					this.MakeAllNodesVisible();
				}
				this.mTree.ResumeLayout();
				if (currentSelection != null && currentSelection.IsVisible)
				{
					this.mTree.SelectedNode = currentSelection;
				}
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000CCBC File Offset: 0x0000BCBC
		private void ShowNodeIfMatching(Node currentNode, bool expandParents)
		{
			if (currentNode == null)
			{
				return;
			}
			if (this.MatchesSearchText(currentNode))
			{
				TreeSearchHelper.ShowNode(currentNode, expandParents);
				return;
			}
			currentNode.Visible = false;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000CCDC File Offset: 0x0000BCDC
		private static void ShowNode(Node currentNode, bool expandParents)
		{
			bool flag = false;
			Node node = currentNode;
			while (node != null)
			{
				node.Visible = true;
				if (expandParents && flag)
				{
					node.Expanded = true;
				}
				node = node.Parent;
				flag = true;
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000CD10 File Offset: 0x0000BD10
		private void MakeAllNodesVisible()
		{
			for (Node node = this.mTree.GetFirstNode(); node != null; node = node.NextNode)
			{
				node.Visible = true;
			}
			this.mTree.CollapseAll();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000CD48 File Offset: 0x0000BD48
		private bool MatchesSearchText(Node currentNode)
		{
			if (this.UseRegularExpressions && this.mFilterBoxRegex != null)
			{
				Match match = this.mFilterBoxRegex.Match(currentNode.Text);
				return match.Success;
			}
			return currentNode.Text.ToLower().Contains(this.mFilterBox.Text.ToLower());
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000CD9E File Offset: 0x0000BD9E
		public void Reset(Node currentSelection)
		{
			this.mFilterBox.Text = "";
			this.ShowOnlyMatchingNodes(currentSelection);
		}

		// Token: 0x0400010E RID: 270
		private TreeControl mTree;

		// Token: 0x0400010F RID: 271
		private TextBox mFilterBox;

		// Token: 0x04000110 RID: 272
		private Timer mFilterBoxTimer;

		// Token: 0x04000111 RID: 273
		private Timer mIncrementalSearchTimer;

		// Token: 0x04000112 RID: 274
		private ToolTip mToolTip = new ToolTip();

		// Token: 0x04000113 RID: 275
		private string mIncrementalSearchString = "";

		// Token: 0x04000114 RID: 276
		private string mLastSearchedString = "";

		// Token: 0x04000115 RID: 277
		private Regex mFilterBoxRegex;

		// Token: 0x04000116 RID: 278
		private bool mIncrementalSearchTickHandled;

		// Token: 0x04000117 RID: 279
		private bool mUseRegularExpressions;

		// Token: 0x04000118 RID: 280
		private bool mIncrementalSearchUsesContains;
	}
}
