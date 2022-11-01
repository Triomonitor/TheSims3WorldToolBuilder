using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EA.Perforce.Common;
using Sims3.RevisionControl;

namespace ToolUtil.RevisionControl
{
	// Token: 0x02000027 RID: 39
	public partial class ClientSpecForm : Form
	{
		// Token: 0x060001C8 RID: 456 RVA: 0x0000A6D6 File Offset: 0x000096D6
		public ClientSpecForm(RCS rcs)
		{
			this.InitializeComponent();
			this.Init(rcs);
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x0000A6F6 File Offset: 0x000096F6
		// (set) Token: 0x060001CA RID: 458 RVA: 0x0000A703 File Offset: 0x00009703
		public string ServerName
		{
			get
			{
				return this.mServer.Text;
			}
			set
			{
				this.mServer.Text = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001CB RID: 459 RVA: 0x0000A711 File Offset: 0x00009711
		// (set) Token: 0x060001CC RID: 460 RVA: 0x0000A71E File Offset: 0x0000971E
		public string UserName
		{
			get
			{
				return this.mUserName.Text;
			}
			set
			{
				this.mUserName.Text = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001CD RID: 461 RVA: 0x0000A72C File Offset: 0x0000972C
		// (set) Token: 0x060001CE RID: 462 RVA: 0x0000A79C File Offset: 0x0000979C
		public string[] ClientNames
		{
			get
			{
				List<string> list = new List<string>();
				foreach (object obj in this.mClientNameList.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					list.Add(listViewItem.Text);
				}
				return list.ToArray();
			}
			set
			{
				this.mClientNameList.Items.Clear();
				for (int i = 0; i < value.Length; i++)
				{
					string text = value[i];
					ListViewItem listViewItem = this.mClientNameList.Items.Add(new ListViewItem(text));
					listViewItem.Selected = (listViewItem.Text == this.mRCS.ClientName);
				}
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001CF RID: 463 RVA: 0x0000A800 File Offset: 0x00009800
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x0000A808 File Offset: 0x00009808
		public string SelectedClient
		{
			get
			{
				return this.mSelectedClient;
			}
			set
			{
				this.mSelectedClient = value;
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000A814 File Offset: 0x00009814
		private void OK_Click(object sender, EventArgs e)
		{
			if (this.mClientNameList.SelectedItems.Count > 0)
			{
				base.DialogResult = DialogResult.OK;
				this.SelectedClient = this.mClientNameList.SelectedItems[0].Text;
				base.Close();
				return;
			}
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000A86B File Offset: 0x0000986B
		private void Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000A87C File Offset: 0x0000987C
		private void Refresh_Click(object sender, EventArgs e)
		{
			this.mClientNameList.Items.Clear();
			try
			{
				this.mRCS.Disconnect();
				this.mRCS.Connect(this.ServerName, this.mRCS.ClientName, this.UserName, "");
				if (this.mRCS.Connected)
				{
					this.ClientNames = this.mRCS.GetClientsByUserName(this.UserName);
				}
			}
			catch (RcsException e2)
			{
				throw new RCSException(e2);
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000A90C File Offset: 0x0000990C
		private void ClientNameList_DoubleClick(object sender, EventArgs e)
		{
			if (this.mClientNameList.SelectedItems.Count > 0)
			{
				base.DialogResult = DialogResult.OK;
				this.SelectedClient = this.mClientNameList.SelectedItems[0].Text;
				base.Close();
			}
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000A94C File Offset: 0x0000994C
		private void Init(RCS rcs)
		{
			try
			{
				this.mRCS = rcs;
				this.ServerName = rcs.ServerName;
				this.UserName = rcs.UserName;
				this.ClientNames = rcs.GetClientsByUserName(rcs.UserName);
			}
			catch (RcsException e)
			{
				throw new RCSException(e);
			}
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000A9A4 File Offset: 0x000099A4
		private void mLoginButton_Click(object sender, EventArgs e)
		{
			ManualP4LoginForm manualP4LoginForm = new ManualP4LoginForm();
			manualP4LoginForm.ClientSpec = this.SelectedClient;
			manualP4LoginForm.UserName = this.UserName;
			manualP4LoginForm.Server = this.ServerName;
			try
			{
				if (manualP4LoginForm.ShowDialog(this) == DialogResult.OK)
				{
					this.mRCS.Disconnect();
					this.mRCS.Connect(manualP4LoginForm.Server, manualP4LoginForm.ClientSpec, manualP4LoginForm.UserName, manualP4LoginForm.Password);
					if (this.mRCS.Connected)
					{
						this.ClientNames = this.mRCS.GetClientsByUserName(this.UserName);
					}
					this.ServerName = manualP4LoginForm.Server;
					this.UserName = manualP4LoginForm.UserName;
					this.SelectedClient = manualP4LoginForm.ClientSpec;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error trying to login to P4:\n" + ex.Message);
			}
		}

		// Token: 0x040000EC RID: 236
		private RCS mRCS;

		// Token: 0x040000ED RID: 237
		private string mSelectedClient = "";
	}
}
