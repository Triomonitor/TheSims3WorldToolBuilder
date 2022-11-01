namespace ToolUtil.RevisionControl
{
	// Token: 0x02000026 RID: 38
	public partial class EditAddForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060001C4 RID: 452 RVA: 0x00009CD6 File Offset: 0x00008CD6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00009CF8 File Offset: 0x00008CF8
		private void InitializeComponent()
		{
			this.mCancel = new global::System.Windows.Forms.Button();
			this.mOK = new global::System.Windows.Forms.Button();
			this.mLabel = new global::System.Windows.Forms.Label();
			this.mFileList = new global::System.Windows.Forms.CheckedListBox();
			this.mDisableButton = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.mCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.mCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.mCancel.Location = new global::System.Drawing.Point(628, 199);
			this.mCancel.Name = "mCancel";
			this.mCancel.Size = new global::System.Drawing.Size(75, 23);
			this.mCancel.TabIndex = 3;
			this.mCancel.Text = "No";
			this.mCancel.UseVisualStyleBackColor = true;
			this.mOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.mOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.mOK.Location = new global::System.Drawing.Point(547, 199);
			this.mOK.Name = "mOK";
			this.mOK.Size = new global::System.Drawing.Size(75, 23);
			this.mOK.TabIndex = 2;
			this.mOK.Text = "Yes";
			this.mOK.UseVisualStyleBackColor = true;
			this.mLabel.AutoSize = true;
			this.mLabel.Location = new global::System.Drawing.Point(13, 13);
			this.mLabel.Name = "mLabel";
			this.mLabel.Size = new global::System.Drawing.Size(170, 13);
			this.mLabel.TabIndex = 0;
			this.mLabel.Text = "Select files to open for Edit or Add:";
			this.mFileList.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.mFileList.CheckOnClick = true;
			this.mFileList.FormattingEnabled = true;
			this.mFileList.Location = new global::System.Drawing.Point(16, 30);
			this.mFileList.Name = "mFileList";
			this.mFileList.Size = new global::System.Drawing.Size(687, 154);
			this.mFileList.TabIndex = 1;
			this.mDisableButton.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.mDisableButton.DialogResult = global::System.Windows.Forms.DialogResult.Ignore;
			this.mDisableButton.Location = new global::System.Drawing.Point(466, 199);
			this.mDisableButton.Name = "mDisableButton";
			this.mDisableButton.Size = new global::System.Drawing.Size(75, 23);
			this.mDisableButton.TabIndex = 4;
			this.mDisableButton.Text = "Yes to All";
			this.mDisableButton.UseVisualStyleBackColor = true;
			this.mDisableButton.Visible = false;
			base.AcceptButton = this.mOK;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.mCancel;
			base.ClientSize = new global::System.Drawing.Size(715, 234);
			base.Controls.Add(this.mDisableButton);
			base.Controls.Add(this.mFileList);
			base.Controls.Add(this.mLabel);
			base.Controls.Add(this.mOK);
			base.Controls.Add(this.mCancel);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "EditAddForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "Check-out Files From Perforce";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000DB RID: 219
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.Button mCancel;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Button mOK;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.Label mLabel;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.CheckedListBox mFileList;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.Button mDisableButton;
	}
}
