namespace ToolUtil.RevisionControl
{
	// Token: 0x02000007 RID: 7
	public partial class SubmitForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00002910 File Offset: 0x00001910
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002930 File Offset: 0x00001930
		private void InitializeComponent()
		{
			this.mSplitContainer = new global::System.Windows.Forms.SplitContainer();
			this.mDescription = new global::System.Windows.Forms.TextBox();
			this.mLblDescription = new global::System.Windows.Forms.Label();
			this.mFileList = new global::System.Windows.Forms.ListView();
			this.mLblFiles = new global::System.Windows.Forms.Label();
			this.mCancel = new global::System.Windows.Forms.Button();
			this.mSubmit = new global::System.Windows.Forms.Button();
			this.mSplitContainer.Panel1.SuspendLayout();
			this.mSplitContainer.Panel2.SuspendLayout();
			this.mSplitContainer.SuspendLayout();
			base.SuspendLayout();
			this.mSplitContainer.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.mSplitContainer.Location = new global::System.Drawing.Point(0, 0);
			this.mSplitContainer.Name = "mSplitContainer";
			this.mSplitContainer.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.mSplitContainer.Panel1.Controls.Add(this.mDescription);
			this.mSplitContainer.Panel1.Controls.Add(this.mLblDescription);
			this.mSplitContainer.Panel2.Controls.Add(this.mFileList);
			this.mSplitContainer.Panel2.Controls.Add(this.mLblFiles);
			this.mSplitContainer.Panel2.Controls.Add(this.mCancel);
			this.mSplitContainer.Panel2.Controls.Add(this.mSubmit);
			this.mSplitContainer.Size = new global::System.Drawing.Size(492, 473);
			this.mSplitContainer.SplitterDistance = 150;
			this.mSplitContainer.TabIndex = 0;
			this.mDescription.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.mDescription.Location = new global::System.Drawing.Point(15, 25);
			this.mDescription.Multiline = true;
			this.mDescription.Name = "mDescription";
			this.mDescription.Size = new global::System.Drawing.Size(465, 102);
			this.mDescription.TabIndex = 0;
			this.mLblDescription.AutoSize = true;
			this.mLblDescription.Location = new global::System.Drawing.Point(12, 9);
			this.mLblDescription.Name = "mLblDescription";
			this.mLblDescription.Size = new global::System.Drawing.Size(60, 13);
			this.mLblDescription.TabIndex = 0;
			this.mLblDescription.Text = "Description";
			this.mFileList.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.mFileList.Location = new global::System.Drawing.Point(15, 27);
			this.mFileList.Name = "mFileList";
			this.mFileList.Size = new global::System.Drawing.Size(465, 251);
			this.mFileList.TabIndex = 0;
			this.mFileList.UseCompatibleStateImageBehavior = false;
			this.mFileList.View = global::System.Windows.Forms.View.List;
			this.mLblFiles.AutoSize = true;
			this.mLblFiles.Location = new global::System.Drawing.Point(12, 10);
			this.mLblFiles.Name = "mLblFiles";
			this.mLblFiles.Size = new global::System.Drawing.Size(28, 13);
			this.mLblFiles.TabIndex = 0;
			this.mLblFiles.Text = "Files";
			this.mCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.mCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.mCancel.Location = new global::System.Drawing.Point(405, 284);
			this.mCancel.Name = "mCancel";
			this.mCancel.Size = new global::System.Drawing.Size(75, 23);
			this.mCancel.TabIndex = 2;
			this.mCancel.Text = "Cancel";
			this.mCancel.UseVisualStyleBackColor = true;
			this.mCancel.Click += new global::System.EventHandler(this.Cancel_Click);
			this.mSubmit.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.mSubmit.Location = new global::System.Drawing.Point(324, 284);
			this.mSubmit.Name = "mSubmit";
			this.mSubmit.Size = new global::System.Drawing.Size(75, 23);
			this.mSubmit.TabIndex = 1;
			this.mSubmit.Text = "Submit";
			this.mSubmit.UseVisualStyleBackColor = true;
			this.mSubmit.Click += new global::System.EventHandler(this.Submit_Click);
			base.AcceptButton = this.mCancel;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.mCancel;
			base.ClientSize = new global::System.Drawing.Size(492, 473);
			base.Controls.Add(this.mSplitContainer);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SubmitForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "Check-in Files to Perforce";
			this.mSplitContainer.Panel1.ResumeLayout(false);
			this.mSplitContainer.Panel1.PerformLayout();
			this.mSplitContainer.Panel2.ResumeLayout(false);
			this.mSplitContainer.Panel2.PerformLayout();
			this.mSplitContainer.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400000F RID: 15
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.SplitContainer mSplitContainer;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.TextBox mDescription;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.Label mLblDescription;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Label mLblFiles;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Button mCancel;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Button mSubmit;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.ListView mFileList;
	}
}
