using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Crownwood.DotNetMagic.Controls;
using Sims3;

namespace ToolUtil
{
	// Token: 0x02000006 RID: 6
	public partial class SearchableTreeControlTest : Form
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002631 File Offset: 0x00001631
		public SearchableTreeControlTest()
		{
			this.InitializeComponent();
			base.VisibleChanged += this.StartFill;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002654 File Offset: 0x00001654
		[STAThread]
		public static void Main(string[] args)
		{
			SearchableTreeControlTest searchableTreeControlTest = new SearchableTreeControlTest();
			searchableTreeControlTest.Show();
			Application.Run();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002672 File Offset: 0x00001672
		private void StartFill(object sender, EventArgs e)
		{
			new Thread(new ThreadStart(this.Fill)).Start();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000268A File Offset: 0x0000168A
		private void Fill()
		{
			this.AddToTree(this.mSearchableTreeControl1.TreeControl.Nodes, "C:\\");
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000026A8 File Offset: 0x000016A8
		private void AddToTree(NodeCollection nodes, string directory)
		{
			foreach (string text in Directory.GetDirectories(directory))
			{
				Node node = new Node(Path.GetFileName(text));
				node.Tag = text;
				node.CheckStates = NodeCheckStates.TwoStateCheck;
				node.CheckState = Crownwood.DotNetMagic.Controls.CheckState.Unchecked;
				lock (this.mSearchableTreeControl1.TreeControl)
				{
					Utils.Forms.InvokeMethod(this, nodes, "Add", new object[]
					{
						node
					});
				}
				this.AddToTree(node.Nodes, (string)node.Tag);
				Thread.Sleep(1000);
			}
			foreach (string text2 in Directory.GetFiles(directory))
			{
				Node node2 = new Node(Path.GetFileName(text2));
				node2.Tag = text2;
				node2.CheckStates = NodeCheckStates.TwoStateCheck;
				node2.CheckState = Crownwood.DotNetMagic.Controls.CheckState.Unchecked;
				lock (this.mSearchableTreeControl1.TreeControl)
				{
					Utils.Forms.InvokeMethod(this, nodes, "Add", new object[]
					{
						node2
					});
				}
			}
			Thread.Sleep(1000);
		}
	}
}
