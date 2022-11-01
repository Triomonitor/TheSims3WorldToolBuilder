using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ToolUtil.RevisionControl
{
	// Token: 0x02000026 RID: 38
	public partial class EditAddForm : Form
	{
		// Token: 0x060001BF RID: 447 RVA: 0x00009BFF File Offset: 0x00008BFF
		public EditAddForm()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x00009C10 File Offset: 0x00008C10
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x00009C7C File Offset: 0x00008C7C
		public string[] FileList
		{
			get
			{
				List<string> list = new List<string>();
				foreach (object obj in this.mFileList.CheckedItems)
				{
					string item = (string)obj;
					list.Add(item);
				}
				return list.ToArray();
			}
			set
			{
				this.mFileList.Items.Clear();
				for (int i = 0; i < value.Length; i++)
				{
					string item = value[i];
					this.mFileList.Items.Add(item, CheckState.Checked);
				}
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00009CC0 File Offset: 0x00008CC0
		public Label TextLabel
		{
			get
			{
				return this.mLabel;
			}
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00009CC8 File Offset: 0x00008CC8
		public void ShowDisableButton(bool value)
		{
			this.mDisableButton.Visible = value;
		}
	}
}
