using System;
using System.Windows.Forms;
using Sims3.CSHost;

namespace ToolUtil
{
	// Token: 0x0200001A RID: 26
	public sealed class BuildVersion
	{
		// Token: 0x06000184 RID: 388 RVA: 0x000095C8 File Offset: 0x000085C8
		public static void ShowVersionInfo(string caption)
		{
			string caption2 = (caption.Length > 0) ? caption : "Build Info";
			MessageBox.Show(BuildVersion.Info, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000185 RID: 389 RVA: 0x000095F8 File Offset: 0x000085F8
		public static string Info
		{
			get
			{
				return string.Format("Version: {0}\r\nUser: {1}\r\nHost: {2}\r\nTimeStamp: {3}\r\nConfig: {4}", new object[]
				{
					App.BuildVersion,
					App.BuildUser,
					App.BuildHostName,
					App.BuildTimeStamp,
					App.BuildConfig
				});
			}
		}
	}
}
