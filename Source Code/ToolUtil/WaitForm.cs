using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ToolUtil
{
	// Token: 0x0200001E RID: 30
	public partial class WaitForm : Form
	{
		// Token: 0x060001B0 RID: 432 RVA: 0x00009904 File Offset: 0x00008904
		public WaitForm(string label)
		{
			this.InitializeComponent();
			if (!string.IsNullOrEmpty(label))
			{
				this.mLabel.Text = label;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00009926 File Offset: 0x00008926
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x00009933 File Offset: 0x00008933
		public string Label
		{
			get
			{
				return this.mLabel.Text;
			}
			set
			{
				this.mLabel.Text = value;
			}
		}
	}
}
