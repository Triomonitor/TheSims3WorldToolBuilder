using System;
using System.Windows.Forms;

namespace ToolUtil
{
	// Token: 0x02000010 RID: 16
	public class CameraMouseDownEventArgs : MouseEventArgs
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00004830 File Offset: 0x00003830
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00004838 File Offset: 0x00003838
		public bool Handled
		{
			get
			{
				return this.mHandled;
			}
			set
			{
				this.mHandled = value;
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004841 File Offset: 0x00003841
		public CameraMouseDownEventArgs(MouseEventArgs e) : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
		{
			this.Handled = false;
		}

		// Token: 0x04000042 RID: 66
		private bool mHandled;
	}
}
