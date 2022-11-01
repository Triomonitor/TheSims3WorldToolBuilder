namespace ToolUtil
{
	// Token: 0x0200001E RID: 30
	public partial class WaitForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x00009941 File Offset: 0x00008941
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00009960 File Offset: 0x00008960
		private void InitializeComponent()
		{
			this.mLabel = new global::System.Windows.Forms.Label();
			this.mProgressBar = new global::System.Windows.Forms.ProgressBar();
			base.SuspendLayout();
			this.mLabel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.mLabel.Location = new global::System.Drawing.Point(7, 9);
			this.mLabel.Name = "mLabel";
			this.mLabel.Size = new global::System.Drawing.Size(441, 19);
			this.mLabel.TabIndex = 0;
			this.mLabel.Text = "Loading, please wait...";
			this.mLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.mProgressBar.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.mProgressBar.Location = new global::System.Drawing.Point(12, 31);
			this.mProgressBar.Name = "mProgressBar";
			this.mProgressBar.Size = new global::System.Drawing.Size(436, 18);
			this.mProgressBar.Style = global::System.Windows.Forms.ProgressBarStyle.Marquee;
			this.mProgressBar.TabIndex = 1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.InactiveCaptionText;
			base.ClientSize = new global::System.Drawing.Size(460, 63);
			base.ControlBox = false;
			base.Controls.Add(this.mProgressBar);
			base.Controls.Add(this.mLabel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "WaitForm";
			base.ShowInTaskbar = false;
			base.SizeGripStyle = global::System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Loading, please wait...";
			base.ResumeLayout(false);
		}

		// Token: 0x040000D5 RID: 213
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.Label mLabel;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.ProgressBar mProgressBar;
	}
}
