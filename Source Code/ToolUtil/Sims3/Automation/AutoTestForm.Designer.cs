namespace Sims3.Automation
{
	// Token: 0x02000008 RID: 8
	public partial class AutoTestForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000027 RID: 39 RVA: 0x000030E0 File Offset: 0x000020E0
		protected override void Dispose(bool disposing)
		{
			if (!this.mCleared)
			{
				try
				{
					foreach (object obj in this.mTreeView.Nodes)
					{
						global::Crownwood.DotNetMagic.Controls.Node node = (global::Crownwood.DotNetMagic.Controls.Node)obj;
						global::Sims3.Automation.AutoTestForm.TestFixture testFixture = node.Tag as global::Sims3.Automation.AutoTestForm.TestFixture;
						if (testFixture != null && testFixture.TeardownMethod != null)
						{
							testFixture.TeardownMethod.Invoke(testFixture.Object, null);
						}
					}
				}
				catch (global::System.Exception ex)
				{
					global::Sims3.Log.Instance.Error("AutoTestForm", "Error during teardown: " + ex.ToString(), new object[0]);
				}
				this.mCleared = true;
			}
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003380 File Offset: 0x00002380
		private void InitializeComponent()
		{
			this.mPlay = new global::System.Windows.Forms.Button();
			this.mSplitContainer = new global::System.Windows.Forms.SplitContainer();
			this.mTreeView = new global::Crownwood.DotNetMagic.Controls.TreeControl();
			this.mTextBox = new global::System.Windows.Forms.RichTextBox();
			this.mSplitContainer.Panel1.SuspendLayout();
			this.mSplitContainer.Panel2.SuspendLayout();
			this.mSplitContainer.SuspendLayout();
			base.SuspendLayout();
			this.mPlay.Location = new global::System.Drawing.Point(12, 12);
			this.mPlay.Name = "mPlay";
			this.mPlay.Size = new global::System.Drawing.Size(75, 23);
			this.mPlay.TabIndex = 0;
			this.mPlay.Text = "Play";
			this.mPlay.UseVisualStyleBackColor = true;
			this.mPlay.Click += new global::System.EventHandler(this.Play_Click);
			this.mSplitContainer.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.mSplitContainer.Location = new global::System.Drawing.Point(13, 42);
			this.mSplitContainer.Name = "mSplitContainer";
			this.mSplitContainer.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.mSplitContainer.Panel1.Controls.Add(this.mTreeView);
			this.mSplitContainer.Panel2.Controls.Add(this.mTextBox);
			this.mSplitContainer.Size = new global::System.Drawing.Size(725, 364);
			this.mSplitContainer.SplitterDistance = 190;
			this.mSplitContainer.TabIndex = 2;
			this.mTreeView.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.mTreeView.FocusNode = null;
			this.mTreeView.HotBackColor = global::System.Drawing.Color.Empty;
			this.mTreeView.HotForeColor = global::System.Drawing.Color.Empty;
			this.mTreeView.LabelEdit = false;
			this.mTreeView.Location = new global::System.Drawing.Point(0, 0);
			this.mTreeView.Name = "mTreeView";
			this.mTreeView.SelectedNode = null;
			this.mTreeView.SelectedNoFocusBackColor = global::System.Drawing.SystemColors.Control;
			this.mTreeView.SelectMode = global::Crownwood.DotNetMagic.Controls.SelectMode.Single;
			this.mTreeView.Size = new global::System.Drawing.Size(725, 190);
			this.mTreeView.TabIndex = 2;
			this.mTreeView.Text = "treeControl1";
			this.mTextBox.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.mTextBox.Location = new global::System.Drawing.Point(0, 0);
			this.mTextBox.Name = "mTextBox";
			this.mTextBox.ReadOnly = true;
			this.mTextBox.Size = new global::System.Drawing.Size(725, 170);
			this.mTextBox.TabIndex = 0;
			this.mTextBox.Text = "";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(750, 418);
			base.Controls.Add(this.mSplitContainer);
			base.Controls.Add(this.mPlay);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AutoTestForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "AutoTestForm";
			this.mSplitContainer.Panel1.ResumeLayout(false);
			this.mSplitContainer.Panel2.ResumeLayout(false);
			this.mSplitContainer.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400001A RID: 26
		private bool mCleared;

		// Token: 0x0400001B RID: 27
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Button mPlay;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.SplitContainer mSplitContainer;

		// Token: 0x0400001E RID: 30
		private global::Crownwood.DotNetMagic.Controls.TreeControl mTreeView;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.RichTextBox mTextBox;
	}
}
