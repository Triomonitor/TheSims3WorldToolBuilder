using System;
using System.Threading;
using System.Windows.Forms;

namespace ToolUtil
{
	// Token: 0x0200001F RID: 31
	public sealed class StartupWaitForm
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x00009AF4 File Offset: 0x00008AF4
		private StartupWaitForm()
		{
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00009AFC File Offset: 0x00008AFC
		public static void ShowWaitForm(string label)
		{
			if (StartupWaitForm.mWaitForm != null)
			{
				return;
			}
			StartupWaitForm.mLabel = label;
			StartupWaitForm.mThread = new Thread(new ThreadStart(StartupWaitForm.ShowForm));
			StartupWaitForm.mThread.IsBackground = true;
			StartupWaitForm.mThread.Name = "Wait Form Thread";
			StartupWaitForm.mThread.Start();
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00009B51 File Offset: 0x00008B51
		private static void ShowForm()
		{
			StartupWaitForm.mWaitForm = new WaitForm(StartupWaitForm.mLabel);
			StartupWaitForm.mWaitForm.ShowInTaskbar = true;
			Application.Run(StartupWaitForm.mWaitForm);
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00009B78 File Offset: 0x00008B78
		public static void CloseForm()
		{
			if (StartupWaitForm.mThread == null)
			{
				return;
			}
			if (StartupWaitForm.mWaitForm == null)
			{
				return;
			}
			if (StartupWaitForm.mWaitForm.InvokeRequired)
			{
				StartupWaitForm.mWaitForm.Invoke(new MethodInvoker(StartupWaitForm.CloseForm));
				return;
			}
			StartupWaitForm.mThread = null;
			StartupWaitForm.mWaitForm.Close();
			StartupWaitForm.mWaitForm = null;
		}

		// Token: 0x040000D8 RID: 216
		private static WaitForm mWaitForm;

		// Token: 0x040000D9 RID: 217
		private static Thread mThread;

		// Token: 0x040000DA RID: 218
		private static string mLabel;
	}
}
