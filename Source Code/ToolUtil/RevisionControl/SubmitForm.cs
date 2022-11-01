using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ToolUtil.RevisionControl
{
	// Token: 0x02000007 RID: 7
	public partial class SubmitForm : Form
	{
		// Token: 0x0600001B RID: 27 RVA: 0x000027F8 File Offset: 0x000017F8
		public SubmitForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002806 File Offset: 0x00001806
		// (set) Token: 0x0600001D RID: 29 RVA: 0x00002813 File Offset: 0x00001813
		public string Description
		{
			get
			{
				return this.mDescription.Text;
			}
			set
			{
				this.mDescription.Text = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002824 File Offset: 0x00001824
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002894 File Offset: 0x00001894
		public string[] FileList
		{
			get
			{
				List<string> list = new List<string>();
				foreach (object obj in this.mFileList.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					list.Add(listViewItem.Text);
				}
				return list.ToArray();
			}
			set
			{
				this.mFileList.Items.Clear();
				for (int i = 0; i < value.Length; i++)
				{
					string text = value[i];
					this.mFileList.Items.Add(text);
				}
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000028D7 File Offset: 0x000018D7
		// (set) Token: 0x06000021 RID: 33 RVA: 0x000028E4 File Offset: 0x000018E4
		public string SubmitButtonName
		{
			get
			{
				return this.mSubmit.Text;
			}
			set
			{
				this.mSubmit.Text = value;
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000028F2 File Offset: 0x000018F2
		private void Submit_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002901 File Offset: 0x00001901
		private void Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}
	}
}
