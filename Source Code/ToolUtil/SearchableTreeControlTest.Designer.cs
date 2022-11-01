namespace ToolUtil
{
	// Token: 0x02000006 RID: 6
	public partial class SearchableTreeControlTest : global::System.Windows.Forms.Form
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002540 File Offset: 0x00001540
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002560 File Offset: 0x00001560
		private void InitializeComponent()
		{
			this.mSearchableTreeControl1 = new global::ToolUtil.SearchableTreeControl();
			base.SuspendLayout();
			this.mSearchableTreeControl1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.mSearchableTreeControl1.Location = new global::System.Drawing.Point(0, 0);
			this.mSearchableTreeControl1.Name = "mSearchableTreeControl1";
			this.mSearchableTreeControl1.Size = new global::System.Drawing.Size(315, 211);
			this.mSearchableTreeControl1.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(315, 211);
			base.Controls.Add(this.mSearchableTreeControl1);
			base.Name = "SearchableTreeControlTest";
			this.Text = "SearchableTreeControlTest";
			base.ResumeLayout(false);
		}

		// Token: 0x0400000D RID: 13
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000E RID: 14
		private global::ToolUtil.SearchableTreeControl mSearchableTreeControl1;
	}
}
