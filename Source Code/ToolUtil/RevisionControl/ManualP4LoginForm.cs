using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ToolUtil.RevisionControl
{
	// Token: 0x02000019 RID: 25
	public partial class ManualP4LoginForm : Form
	{
		// Token: 0x06000178 RID: 376 RVA: 0x00008FC3 File Offset: 0x00007FC3
		public ManualP4LoginForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000179 RID: 377 RVA: 0x00008FD1 File Offset: 0x00007FD1
		// (set) Token: 0x0600017A RID: 378 RVA: 0x00008FDE File Offset: 0x00007FDE
		public string Server
		{
			get
			{
				return this.serverTextBox.Text;
			}
			set
			{
				this.serverTextBox.Text = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600017B RID: 379 RVA: 0x00008FEC File Offset: 0x00007FEC
		// (set) Token: 0x0600017C RID: 380 RVA: 0x00008FF9 File Offset: 0x00007FF9
		public string UserName
		{
			get
			{
				return this.userNameTextBox.Text;
			}
			set
			{
				this.userNameTextBox.Text = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00009007 File Offset: 0x00008007
		// (set) Token: 0x0600017E RID: 382 RVA: 0x00009014 File Offset: 0x00008014
		public string ClientSpec
		{
			get
			{
				return this.clientSpecTextBox.Text;
			}
			set
			{
				this.clientSpecTextBox.Text = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600017F RID: 383 RVA: 0x00009022 File Offset: 0x00008022
		public string Password
		{
			get
			{
				return this.passwordTextBox.Text;
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000902F File Offset: 0x0000802F
		private void mOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000903E File Offset: 0x0000803E
		private void mCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}
	}
}
