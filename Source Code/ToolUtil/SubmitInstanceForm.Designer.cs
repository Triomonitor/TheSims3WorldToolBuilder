namespace ToolUtil
{
	// Token: 0x02000012 RID: 18
	public partial class SubmitInstanceForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00004AE0 File Offset: 0x00003AE0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004B00 File Offset: 0x00003B00
		private void InitializeComponent()
		{
			this.mInstancesLabel = new global::System.Windows.Forms.Label();
			this.mSubmit = new global::System.Windows.Forms.Button();
			this.mCancel = new global::System.Windows.Forms.Button();
			this.mInstances = new global::System.Windows.Forms.CheckedListBox();
			this.mUndoEdit = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.mInstancesLabel.AutoSize = true;
			this.mInstancesLabel.Location = new global::System.Drawing.Point(9, 9);
			this.mInstancesLabel.Name = "mInstancesLabel";
			this.mInstancesLabel.Size = new global::System.Drawing.Size(53, 13);
			this.mInstancesLabel.TabIndex = 0;
			this.mInstancesLabel.Text = "Instances";
			this.mSubmit.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.mSubmit.Location = new global::System.Drawing.Point(366, 178);
			this.mSubmit.Name = "mSubmit";
			this.mSubmit.Size = new global::System.Drawing.Size(75, 23);
			this.mSubmit.TabIndex = 3;
			this.mSubmit.Text = "Submit";
			this.mSubmit.UseVisualStyleBackColor = true;
			this.mSubmit.Click += new global::System.EventHandler(this.Submit_Click);
			this.mCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.mCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.mCancel.Location = new global::System.Drawing.Point(447, 178);
			this.mCancel.Name = "mCancel";
			this.mCancel.Size = new global::System.Drawing.Size(75, 23);
			this.mCancel.TabIndex = 4;
			this.mCancel.Text = "Cancel";
			this.mCancel.UseVisualStyleBackColor = true;
			this.mInstances.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.mInstances.FormattingEnabled = true;
			this.mInstances.Location = new global::System.Drawing.Point(12, 30);
			this.mInstances.Name = "mInstances";
			this.mInstances.Size = new global::System.Drawing.Size(510, 139);
			this.mInstances.TabIndex = 1;
			this.mInstances.ItemCheck += new global::System.Windows.Forms.ItemCheckEventHandler(this.Instances_ItemCheck);
			this.mUndoEdit.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.mUndoEdit.Location = new global::System.Drawing.Point(12, 178);
			this.mUndoEdit.Name = "mUndoEdit";
			this.mUndoEdit.Size = new global::System.Drawing.Size(75, 23);
			this.mUndoEdit.TabIndex = 2;
			this.mUndoEdit.Text = "Undo Edit";
			this.mUndoEdit.UseVisualStyleBackColor = true;
			this.mUndoEdit.Click += new global::System.EventHandler(this.UndoEdit_Click);
			base.AcceptButton = this.mSubmit;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.mCancel;
			base.ClientSize = new global::System.Drawing.Size(534, 213);
			base.Controls.Add(this.mUndoEdit);
			base.Controls.Add(this.mInstancesLabel);
			base.Controls.Add(this.mInstances);
			base.Controls.Add(this.mSubmit);
			base.Controls.Add(this.mCancel);
			base.Name = "SubmitInstanceForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "Submit Instances";
			base.Load += new global::System.EventHandler(this.SubmitInstanceForm_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000044 RID: 68
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.Label mInstancesLabel;

		// Token: 0x04000046 RID: 70
		private global::System.Windows.Forms.Button mSubmit;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.Button mCancel;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.CheckedListBox mInstances;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.Button mUndoEdit;
	}
}
