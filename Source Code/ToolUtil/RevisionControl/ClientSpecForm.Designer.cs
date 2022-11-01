namespace ToolUtil.RevisionControl
{
	// Token: 0x02000027 RID: 39
	public partial class ClientSpecForm : global::System.Windows.Forms.Form
	{
		// Token: 0x060001C6 RID: 454 RVA: 0x0000A07A File Offset: 0x0000907A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000A09C File Offset: 0x0000909C
		private void InitializeComponent()
		{
			this.mServer = new global::System.Windows.Forms.TextBox();
			this.mUserName = new global::System.Windows.Forms.TextBox();
			this.mClientNameList = new global::System.Windows.Forms.ListView();
			this.mRefresh = new global::System.Windows.Forms.Button();
			this.mLblServer = new global::System.Windows.Forms.Label();
			this.mLblUserName = new global::System.Windows.Forms.Label();
			this.mOK = new global::System.Windows.Forms.Button();
			this.mCancel = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.mLoginButton = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.mServer.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.mServer.Location = new global::System.Drawing.Point(76, 13);
			this.mServer.Name = "mServer";
			this.mServer.Size = new global::System.Drawing.Size(332, 20);
			this.mServer.TabIndex = 2;
			this.mUserName.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.mUserName.Location = new global::System.Drawing.Point(76, 39);
			this.mUserName.Name = "mUserName";
			this.mUserName.ReadOnly = true;
			this.mUserName.Size = new global::System.Drawing.Size(332, 20);
			this.mUserName.TabIndex = 4;
			this.mClientNameList.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.mClientNameList.Location = new global::System.Drawing.Point(13, 92);
			this.mClientNameList.MultiSelect = false;
			this.mClientNameList.Name = "mClientNameList";
			this.mClientNameList.Size = new global::System.Drawing.Size(478, 175);
			this.mClientNameList.TabIndex = 0;
			this.mClientNameList.UseCompatibleStateImageBehavior = false;
			this.mClientNameList.View = global::System.Windows.Forms.View.List;
			this.mClientNameList.DoubleClick += new global::System.EventHandler(this.ClientNameList_DoubleClick);
			this.mRefresh.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.mRefresh.Location = new global::System.Drawing.Point(416, 36);
			this.mRefresh.Name = "mRefresh";
			this.mRefresh.Size = new global::System.Drawing.Size(75, 23);
			this.mRefresh.TabIndex = 5;
			this.mRefresh.Text = "Refresh";
			this.mRefresh.UseVisualStyleBackColor = true;
			this.mRefresh.Click += new global::System.EventHandler(this.Refresh_Click);
			this.mLblServer.AutoSize = true;
			this.mLblServer.Location = new global::System.Drawing.Point(12, 20);
			this.mLblServer.Name = "mLblServer";
			this.mLblServer.Size = new global::System.Drawing.Size(38, 13);
			this.mLblServer.TabIndex = 1;
			this.mLblServer.Text = "Server";
			this.mLblUserName.AutoSize = true;
			this.mLblUserName.Location = new global::System.Drawing.Point(10, 46);
			this.mLblUserName.Name = "mLblUserName";
			this.mLblUserName.Size = new global::System.Drawing.Size(60, 13);
			this.mLblUserName.TabIndex = 3;
			this.mLblUserName.Text = "User Name";
			this.mOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.mOK.Location = new global::System.Drawing.Point(12, 273);
			this.mOK.Name = "mOK";
			this.mOK.Size = new global::System.Drawing.Size(75, 23);
			this.mOK.TabIndex = 7;
			this.mOK.Text = "OK";
			this.mOK.UseVisualStyleBackColor = true;
			this.mOK.Click += new global::System.EventHandler(this.OK_Click);
			this.mCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.mCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.mCancel.Location = new global::System.Drawing.Point(93, 273);
			this.mCancel.Name = "mCancel";
			this.mCancel.Size = new global::System.Drawing.Size(75, 23);
			this.mCancel.TabIndex = 8;
			this.mCancel.Text = "Cancel";
			this.mCancel.UseVisualStyleBackColor = true;
			this.mCancel.Click += new global::System.EventHandler(this.Cancel_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 72);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(66, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Client Specs";
			this.mLoginButton.Location = new global::System.Drawing.Point(416, 11);
			this.mLoginButton.Name = "mLoginButton";
			this.mLoginButton.Size = new global::System.Drawing.Size(75, 23);
			this.mLoginButton.TabIndex = 9;
			this.mLoginButton.Text = "Login";
			this.mLoginButton.UseVisualStyleBackColor = true;
			this.mLoginButton.Click += new global::System.EventHandler(this.mLoginButton_Click);
			base.AcceptButton = this.mOK;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.mCancel;
			base.ClientSize = new global::System.Drawing.Size(503, 306);
			base.Controls.Add(this.mLoginButton);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.mCancel);
			base.Controls.Add(this.mOK);
			base.Controls.Add(this.mLblUserName);
			base.Controls.Add(this.mLblServer);
			base.Controls.Add(this.mRefresh);
			base.Controls.Add(this.mClientNameList);
			base.Controls.Add(this.mUserName);
			base.Controls.Add(this.mServer);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ClientSpecForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "Set Client Specification";
			base.TopMost = true;
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000E1 RID: 225
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.TextBox mServer;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.TextBox mUserName;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.ListView mClientNameList;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.Button mRefresh;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.Label mLblServer;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.Label mLblUserName;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.Button mOK;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.Button mCancel;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.Button mLoginButton;
	}
}
