namespace ToolUtil.RevisionControl
{
	// Token: 0x02000019 RID: 25
	public partial class ManualP4LoginForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000182 RID: 386 RVA: 0x0000904D File Offset: 0x0000804D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000906C File Offset: 0x0000806C
		private void InitializeComponent()
		{
			this.mCancel = new global::System.Windows.Forms.Button();
			this.mOK = new global::System.Windows.Forms.Button();
			this.serverTextBox = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.userNameTextBox = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.clientSpecTextBox = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.passwordTextBox = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.mCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.mCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.mCancel.Location = new global::System.Drawing.Point(96, 156);
			this.mCancel.Name = "mCancel";
			this.mCancel.Size = new global::System.Drawing.Size(75, 23);
			this.mCancel.TabIndex = 14;
			this.mCancel.Text = "Cancel";
			this.mCancel.UseVisualStyleBackColor = true;
			this.mCancel.Click += new global::System.EventHandler(this.mCancel_Click);
			this.mOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.mOK.Location = new global::System.Drawing.Point(15, 156);
			this.mOK.Name = "mOK";
			this.mOK.Size = new global::System.Drawing.Size(75, 23);
			this.mOK.TabIndex = 13;
			this.mOK.Text = "OK";
			this.mOK.UseVisualStyleBackColor = true;
			this.mOK.Click += new global::System.EventHandler(this.mOK_Click);
			this.serverTextBox.Location = new global::System.Drawing.Point(96, 12);
			this.serverTextBox.Name = "serverTextBox";
			this.serverTextBox.Size = new global::System.Drawing.Size(260, 20);
			this.serverTextBox.TabIndex = 15;
			this.serverTextBox.Text = "devo.rws.ad.ea.com:1666";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(10, 15);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(60, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Server:Port";
			this.userNameTextBox.Location = new global::System.Drawing.Point(96, 45);
			this.userNameTextBox.Name = "userNameTextBox";
			this.userNameTextBox.Size = new global::System.Drawing.Size(259, 20);
			this.userNameTextBox.TabIndex = 17;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(11, 46);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(60, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "User Name";
			this.clientSpecTextBox.Location = new global::System.Drawing.Point(96, 80);
			this.clientSpecTextBox.Name = "clientSpecTextBox";
			this.clientSpecTextBox.Size = new global::System.Drawing.Size(259, 20);
			this.clientSpecTextBox.TabIndex = 19;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(12, 80);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(61, 13);
			this.label3.TabIndex = 20;
			this.label3.Text = "Client Spec";
			this.passwordTextBox.Location = new global::System.Drawing.Point(96, 115);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new global::System.Drawing.Size(259, 20);
			this.passwordTextBox.TabIndex = 21;
			this.passwordTextBox.UseSystemPasswordChar = true;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(13, 115);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(53, 13);
			this.label4.TabIndex = 22;
			this.label4.Text = "Password";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(377, 191);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.passwordTextBox);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.clientSpecTextBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.userNameTextBox);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.serverTextBox);
			base.Controls.Add(this.mCancel);
			base.Controls.Add(this.mOK);
			base.Name = "ManualP4LoginForm";
			this.Text = "Manual P4 Login (bypasses default login)";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000C0 RID: 192
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.Button mCancel;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Button mOK;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.TextBox serverTextBox;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.TextBox userNameTextBox;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.TextBox clientSpecTextBox;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.TextBox passwordTextBox;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.Label label4;
	}
}
