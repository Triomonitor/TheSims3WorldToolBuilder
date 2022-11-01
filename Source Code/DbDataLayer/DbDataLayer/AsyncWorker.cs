using System;
using System.ComponentModel;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000009 RID: 9
	public class AsyncWorker : BackgroundWorker
	{
		// Token: 0x060000B2 RID: 178 RVA: 0x0000464C File Offset: 0x0000364C
		public void StartAsyncTask(DoWorkEventHandler doWork, RunWorkerCompletedEventHandler workCompleted)
		{
			if (this.mBusy)
			{
				throw new Exception("Error, AsyncWorker is busy. Cannot perform multiple tasks");
			}
			this.mBusy = true;
			this.mDoWork = doWork;
			this.mWorkCompleted = workCompleted;
			base.RunWorkerCompleted += workCompleted.Invoke;
			base.DoWork += doWork.Invoke;
			base.RunWorkerAsync();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000046AB File Offset: 0x000036AB
		private void WorkDone(object sender, RunWorkerCompletedEventArgs e)
		{
			base.RunWorkerCompleted -= this.WorkDone;
			base.DoWork -= this.mDoWork;
			if (this.mWorkCompleted != null)
			{
				this.mWorkCompleted(sender, e);
			}
			this.mBusy = false;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x000046E7 File Offset: 0x000036E7
		public bool Busy
		{
			get
			{
				return this.mBusy;
			}
		}

		// Token: 0x04000021 RID: 33
		private DoWorkEventHandler mDoWork;

		// Token: 0x04000022 RID: 34
		private RunWorkerCompletedEventHandler mWorkCompleted;

		// Token: 0x04000023 RID: 35
		private bool mBusy;
	}
}
