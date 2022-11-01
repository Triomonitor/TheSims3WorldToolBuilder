namespace Sims3.DbDataLayer
{
	// Token: 0x02000004 RID: 4
	public partial class LoginForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002B63 File Offset: 0x00001B63
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002B84 File Offset: 0x00001B84
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Sims3.DbDataLayer.LoginForm));
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.mPassword = new global::System.Windows.Forms.MaskedTextBox();
			this.mUsername = new global::System.Windows.Forms.TextBox();
			this.mDomain = new global::System.Windows.Forms.TextBox();
			this.mOk = new global::System.Windows.Forms.Button();
			this.mCancel = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.label1.Location = new global::System.Drawing.Point(31, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(72, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Domain:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label2.Location = new global::System.Drawing.Point(31, 32);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(72, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "UserName:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.label3.Location = new global::System.Drawing.Point(31, 55);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(72, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Password:";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.mPassword.Location = new global::System.Drawing.Point(110, 57);
			this.mPassword.Name = "mPassword";
			this.mPassword.Size = new global::System.Drawing.Size(141, 20);
			this.mPassword.TabIndex = 2;
			this.mPassword.UseSystemPasswordChar = true;
			this.mUsername.Location = new global::System.Drawing.Point(110, 34);
			this.mUsername.Name = "mUsername";
			this.mUsername.Size = new global::System.Drawing.Size(141, 20);
			this.mUsername.TabIndex = 1;
			this.mDomain.Location = new global::System.Drawing.Point(110, 11);
			this.mDomain.Name = "mDomain";
			this.mDomain.Size = new global::System.Drawing.Size(141, 20);
			this.mDomain.TabIndex = 0;
			this.mOk.Location = new global::System.Drawing.Point(37, 92);
			this.mOk.Name = "mOk";
			this.mOk.Size = new global::System.Drawing.Size(91, 26);
			this.mOk.TabIndex = 3;
			this.mOk.Text = "Ok";
			this.mOk.UseVisualStyleBackColor = true;
			this.mOk.Click += new global::System.EventHandler(this.mOk_Click);
			this.mCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.mCancel.Location = new global::System.Drawing.Point(155, 92);
			this.mCancel.Name = "mCancel";
			this.mCancel.Size = new global::System.Drawing.Size(91, 26);
			this.mCancel.TabIndex = 4;
			this.mCancel.Text = "Cancel";
			this.mCancel.UseVisualStyleBackColor = true;
			this.mCancel.Click += new global::System.EventHandler(this.mCancel_Click);
			base.AcceptButton = this.mOk;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.mCancel;
			base.ClientSize = new global::System.Drawing.Size(283, 133);
			base.Controls.Add(this.mCancel);
			base.Controls.Add(this.mOk);
			base.Controls.Add(this.mDomain);
			base.Controls.Add(this.mUsername);
			base.Controls.Add(this.mPassword);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "LoginForm";
			this.Text = "Log in to database...";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000D RID: 13
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.MaskedTextBox mPassword;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.TextBox mUsername;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.TextBox mDomain;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Button mOk;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Button mCancel;
	}
}
