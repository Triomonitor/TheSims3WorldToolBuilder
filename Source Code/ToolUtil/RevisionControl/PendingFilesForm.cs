using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Crownwood.DotNetMagic.Common;
using Crownwood.DotNetMagic.Controls;
using Sims3.RevisionControl;

namespace ToolUtil.RevisionControl
{
	// Token: 0x0200000E RID: 14
	public class PendingFilesForm : UserControl
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00003A88 File Offset: 0x00002A88
		private void InitializeComponent()
		{
			this.mRCSTreeControl = new TreeControl();
			base.SuspendLayout();
			this.mRCSTreeControl.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.mRCSTreeControl.ExtendToRight = true;
			this.mRCSTreeControl.FocusNode = null;
			this.mRCSTreeControl.HotBackColor = Color.Empty;
			this.mRCSTreeControl.HotForeColor = Color.Empty;
			this.mRCSTreeControl.Location = new Point(0, 0);
			this.mRCSTreeControl.Name = "mRCSTreeControl";
			this.mRCSTreeControl.SelectedNode = null;
			this.mRCSTreeControl.SelectedNoFocusBackColor = SystemColors.Control;
			this.mRCSTreeControl.Size = new Size(234, 383);
			this.mRCSTreeControl.TabIndex = 0;
			this.mRCSTreeControl.AutoEdit = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.mRCSTreeControl);
			base.Name = "PendingFilesForm";
			base.Size = new Size(234, 383);
			base.ResumeLayout(false);
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00003BAF File Offset: 0x00002BAF
		public string CurrentChangeList
		{
			get
			{
				return this.mCurrentChangeList;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003BB8 File Offset: 0x00002BB8
		public PendingFilesForm()
		{
			this.mIconList = ResourceHelper.LoadBitmapStrip(base.GetType(), "ToolUtil.RevisionControl.DbInstancesIcons.bmp", new Size(16, 16));
			this.InitializeComponent();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003C08 File Offset: 0x00002C08
		public void Init(RCS rcsProvider, string changeList, string fileFilter, ValidateChangeList validateMethod)
		{
			if (rcsProvider == null)
			{
				throw new ArgumentNullException("rcsProvider", Resource.kError_RCSNull);
			}
			if (string.IsNullOrEmpty(changeList))
			{
				throw new ArgumentNullException("changeList", Resource.kError_ChangeListEmpty);
			}
			this.Shutdown();
			if (!this.mbInited)
			{
				this.mCurrentChangeList = changeList;
				if (!string.IsNullOrEmpty(fileFilter))
				{
					this.mFileFilter = fileFilter;
				}
				this.mRCSProvider = rcsProvider;
				this.mRCSProvider.Connect();
				this.mValidateChangeList = new ValidateChangeList(validateMethod.Invoke);
				this.InitUI();
				this.mbInited = true;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003C96 File Offset: 0x00002C96
		public void Shutdown()
		{
			if (this.mbInited)
			{
				this.mRCSTreeControl.Nodes.Clear();
				this.mValidateChangeList = null;
				this.mbInited = false;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00003CBE File Offset: 0x00002CBE
		public RCS RCSProvider
		{
			get
			{
				return this.mRCSProvider;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00003CC6 File Offset: 0x00002CC6
		public TreeControl RCSTreeControl
		{
			get
			{
				return this.mRCSTreeControl;
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003CD0 File Offset: 0x00002CD0
		public void RevertAllFiles(string changeList)
		{
			if (this.mbInited && this.mRCSProvider != null && !string.IsNullOrEmpty(changeList) && MessageBox.Show(Resource.kQuery_Revert, Resource.kRevert_Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				int changeListByDescription = this.mRCSProvider.GetChangeListByDescription(changeList);
				Node nodeFromKey = this.mRCSTreeControl.GetNodeFromKey(changeListByDescription);
				if (nodeFromKey != null)
				{
					string[] openFiles = this.mRCSProvider.GetOpenFiles(changeListByDescription);
					string empty = string.Empty;
					if (!this.mValidateChangeList(ref changeList, openFiles, RCSFileSubmitEventType.kRevert, out empty))
					{
						MessageBox.Show(empty, Resource.kValidationError_Caption, MessageBoxButtons.OK);
						return;
					}
					this.mRCSProvider.RevertChangeList(changeListByDescription);
					nodeFromKey.Remove();
				}
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003D78 File Offset: 0x00002D78
		public bool SubmitAllFiles(string changeList)
		{
			if (this.mbInited && this.mRCSProvider != null && !string.IsNullOrEmpty(changeList))
			{
				int changeListByDescription = this.mRCSProvider.GetChangeListByDescription(changeList);
				Node nodeFromKey = this.mRCSTreeControl.GetNodeFromKey(changeListByDescription);
				if (nodeFromKey != null)
				{
					string[] openFiles = this.mRCSProvider.GetOpenFiles(changeListByDescription);
					string empty = string.Empty;
					if (!this.mValidateChangeList(ref changeList, openFiles, RCSFileSubmitEventType.kSubmit, out empty))
					{
						MessageBox.Show(empty, Resource.kValidationError_Caption, MessageBoxButtons.OK);
						return false;
					}
					string description = changeList;
					if (this.ShowSubmitForm(changeListByDescription, openFiles, Resource.kSubmit_Caption, ref description) == DialogResult.OK && this.mRCSProvider.SubmitChangeList(changeListByDescription, description) != 0)
					{
						nodeFromKey.Remove();
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00003E2C File Offset: 0x00002E2C
		public bool HasFilesToSubmit
		{
			get
			{
				return this.mbInited && this.mRCSProvider != null && this.mRCSTreeControl != null && this.mRCSTreeControl.Nodes.Count != 0 && this.mRCSTreeControl.Nodes[0].Nodes.Count > 0;
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003E84 File Offset: 0x00002E84
		private void InitUI()
		{
			this.mRCSTreeControl.Nodes.Clear();
			if (this.mRCSProvider.IsRCSAvailable)
			{
				this.mRCSTreeControl.SuspendLayout();
				this.mRCSTreeControl.ContextMenuNode = new ContextMenu();
				this.mRCSTreeControl.ShowContextMenuNode += this.OnShowContextMenuNode;
				RCS.RCSFileOpenedEvent += this.OnRCSFileOpened;
				int changeListByDescription = this.mRCSProvider.GetChangeListByDescription(this.mCurrentChangeList);
				if (changeListByDescription != 0)
				{
					string[] openFilesEx = this.mRCSProvider.GetOpenFilesEx(changeListByDescription);
					string[] array = openFilesEx;
					int i = 0;
					while (i < array.Length)
					{
						string text = array[i];
						string[] array2 = text.Split(new char[]
						{
							'|'
						});
						string fileName = array2[1];
						switch ((RCSFileStatusType)Enum.Parse(typeof(RCSFileStatusType), array2[3]))
						{
						case RCSFileStatusType.kOpenForAdd:
							this.AddNode(this.mCurrentChangeList, changeListByDescription, fileName, 3);
							break;
						case RCSFileStatusType.kOpenForEdit:
							goto IL_10D;
						case RCSFileStatusType.kOpenForDelete:
							this.AddNode(this.mCurrentChangeList, changeListByDescription, fileName, 4);
							break;
						default:
							goto IL_10D;
						}
						IL_11D:
						i++;
						continue;
						IL_10D:
						this.AddNode(this.mCurrentChangeList, changeListByDescription, fileName, 1);
						goto IL_11D;
					}
				}
				this.mRCSTreeControl.ResumeLayout();
				if (this.mRCSTreeControl.Nodes.Count > 0)
				{
					this.mRCSTreeControl.Nodes[0].Select();
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003FF4 File Offset: 0x00002FF4
		private void AddNode(string changeList, int changeListId, string fileName, int imageIndex)
		{
			if (changeListId == 0 || string.IsNullOrEmpty(fileName))
			{
				return;
			}
			Node node = this.mRCSTreeControl.GetNodeFromKey(changeListId);
			bool flag = false;
			if (node == null)
			{
				node = new Node(changeList);
				node.Key = changeListId;
				flag = true;
			}
			FileInfo fileInfo = new FileInfo(fileName);
			if (this.mFileFilter.Contains(fileInfo.Extension) && this.mRCSTreeControl.GetNodeFromKey(fileName) == null)
			{
				Node node2 = new Node(fileName);
				node2.Key = fileName;
				node2.Image = this.mIconList.Images[imageIndex];
				node.Nodes.Add(node2);
			}
			if (flag)
			{
				this.mRCSTreeControl.Nodes.Add(node);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000040AC File Offset: 0x000030AC
		private DialogResult ShowSubmitForm(int changeListId, string[] openFiles, string submitButtonName, ref string description)
		{
			SubmitForm submitForm = new SubmitForm();
			if (string.IsNullOrEmpty(description))
			{
				description = this.mRCSProvider.GetDescription(changeListId).TrimEnd(new char[]
				{
					'\n'
				});
			}
			submitForm.Description = description;
			submitForm.FileList = openFiles;
			submitForm.SubmitButtonName = submitButtonName;
			DialogResult result = submitForm.ShowDialog();
			description = submitForm.Description;
			return result;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004114 File Offset: 0x00003114
		private void OnShowContextMenuNode(TreeControl tc, CancelNodeEventArgs e)
		{
			Node node = e.Node;
			if (node.Parent == null)
			{
				this.mRCSTreeControl.ContextMenuNode.MenuItems.Clear();
				if (this.mRCSTreeControl.Nodes[0] != null && this.mRCSTreeControl.Nodes[0].Nodes.Count > 0)
				{
					MenuItem[] items = new MenuItem[]
					{
						new MenuItem(Resource.kSubmit_Caption, new EventHandler(this.OnSubmitChangeList)),
						new MenuItem(Resource.kRevert_Caption, new EventHandler(this.OnRevertChangeList))
					};
					this.mRCSTreeControl.ContextMenuNode.MenuItems.AddRange(items);
					e.Cancel = false;
					this.mContextMenuNode = node;
					return;
				}
			}
			e.Cancel = true;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000041E0 File Offset: 0x000031E0
		private void OnSubmitChangeList(object sender, EventArgs e)
		{
			if (this.mContextMenuNode != null)
			{
				string text = this.mContextMenuNode.Text;
				if (this.SubmitAllFiles(text))
				{
					MessageBox.Show(Resource.kSuccess_AllFilesSubmitted, Resource.kSubmit_Caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show(Resource.kError_UnableToSubmitFiles, Resource.kSubmit_Caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				this.mContextMenuNode = null;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000423C File Offset: 0x0000323C
		private void OnRevertChangeList(object sender, EventArgs e)
		{
			if (this.mContextMenuNode != null)
			{
				string text = this.mContextMenuNode.Text;
				this.RevertAllFiles(text);
				this.mContextMenuNode = null;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000426C File Offset: 0x0000326C
		private void OnRCSFileOpened(object sender, RCSFileOpenedEventArgs e)
		{
			foreach (string fileName in e.FileNames)
			{
				switch (e.EventType)
				{
				case RCSFileOpenEventType.kEdit:
					this.AddNode(e.ChangeList, e.ChangeListId, fileName, 1);
					break;
				case RCSFileOpenEventType.kAdd:
				case RCSFileOpenEventType.kBranch:
					this.AddNode(e.ChangeList, e.ChangeListId, fileName, 3);
					break;
				case RCSFileOpenEventType.kRemove:
					this.AddNode(e.ChangeList, e.ChangeListId, fileName, 4);
					break;
				}
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000042F1 File Offset: 0x000032F1
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.Shutdown();
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x04000029 RID: 41
		private const int kNormalIndex = 0;

		// Token: 0x0400002A RID: 42
		private const int kOpenForEditIndex = 1;

		// Token: 0x0400002B RID: 43
		private const int kOpenForAddIndex = 3;

		// Token: 0x0400002C RID: 44
		private const int kOpenForRemoveIndex = 4;

		// Token: 0x0400002D RID: 45
		private IContainer components;

		// Token: 0x0400002E RID: 46
		private TreeControl mRCSTreeControl;

		// Token: 0x0400002F RID: 47
		private ImageList mIconList = new ImageList();

		// Token: 0x04000030 RID: 48
		private RCS mRCSProvider;

		// Token: 0x04000031 RID: 49
		private bool mbInited;

		// Token: 0x04000032 RID: 50
		private string mFileFilter = ".world|.lot|.layer";

		// Token: 0x04000033 RID: 51
		private string mCurrentChangeList;

		// Token: 0x04000034 RID: 52
		private Node mContextMenuNode;

		// Token: 0x04000035 RID: 53
		private ValidateChangeList mValidateChangeList;
	}
}
