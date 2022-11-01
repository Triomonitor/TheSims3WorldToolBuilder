using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000004 RID: 4
	public partial class LoginForm : Form
	{
		// Token: 0x06000027 RID: 39 RVA: 0x00003011 File Offset: 0x00002011
		public LoginForm()
		{
			this.InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			this.mDomain.Focus();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003032 File Offset: 0x00002032
		private void mOk_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003041 File Offset: 0x00002041
		private void mCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00003050 File Offset: 0x00002050
		public NetworkCredential Credentials
		{
			get
			{
				return new NetworkCredential(this.mUsername.Text, this.mPassword.Text, this.mDomain.Text);
			}
		}
	}
}
