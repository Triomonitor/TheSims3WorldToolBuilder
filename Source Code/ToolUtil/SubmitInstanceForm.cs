using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sims3.DbDataLayer;

namespace ToolUtil
{
	// Token: 0x02000012 RID: 18
	public partial class SubmitInstanceForm : Form
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600007B RID: 123 RVA: 0x0000486E File Offset: 0x0000386E
		public string Comment
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00004878 File Offset: 0x00003878
		public List<ItemKey> SelectedInstances
		{
			get
			{
				List<ItemKey> list = new List<ItemKey>();
				for (int i = 0; i < this.mInstances.Items.Count; i++)
				{
					if (this.mInstances.GetItemChecked(i))
					{
						list.Add((ItemKey)this.mInstances.Items[i]);
					}
				}
				return list;
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000048D1 File Offset: 0x000038D1
		public SubmitInstanceForm(SubmitInstanceForm.OnUndoEditDelegate onUndo)
		{
			this.InitializeComponent();
			this.mOnUndoEdit = onUndo;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000048E6 File Offset: 0x000038E6
		private void Instances_ItemCheck(object sender, ItemCheckEventArgs e)
		{
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000048E8 File Offset: 0x000038E8
		private void SubmitInstanceForm_Load(object sender, EventArgs e)
		{
			Dictionary<ItemKey, OpenObject> openObjects = DataStore.Instance.OpenObjects;
			foreach (OpenObject openObject in openObjects.Values)
			{
				int index = this.mInstances.Items.Add(openObject.InstanceKey);
				this.mInstances.SetItemChecked(index, true);
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00004964 File Offset: 0x00003964
		private void Submit_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00004974 File Offset: 0x00003974
		private void UndoEdit_Click(object sender, EventArgs e)
		{
			List<ItemKey> selectedInstances = this.SelectedInstances;
			if (selectedInstances.Count == 0)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder("Revert these instances?\r\n");
			foreach (ItemKey itemKey in selectedInstances)
			{
				stringBuilder.AppendFormat("{0}\r\n", itemKey.Name);
			}
			DialogResult dialogResult = MessageBox.Show(stringBuilder.ToString(), "Revert these instances?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				foreach (ItemKey itemKey2 in selectedInstances)
				{
					try
					{
						ItemKey revertedOriginalPrototypeKey;
						DataStore.Instance.UndoEdit(itemKey2, out revertedOriginalPrototypeKey);
						if (this.mOnUndoEdit != null)
						{
							this.mOnUndoEdit(itemKey2, revertedOriginalPrototypeKey);
						}
					}
					catch (DataStoreLockedOutException ex)
					{
						MessageBox.Show(string.Format("Unable to revert: {0}", ex.Message, "Unable to Revert", MessageBoxButtons.OK));
						break;
					}
					catch (Exception ex2)
					{
						MessageBox.Show(string.Format("Unable to revert: {0}", ex2.Message, "Unable to Revert", MessageBoxButtons.OK));
						break;
					}
					this.mInstances.Items.Remove(itemKey2);
				}
			}
		}

		// Token: 0x04000043 RID: 67
		private SubmitInstanceForm.OnUndoEditDelegate mOnUndoEdit;

		// Token: 0x02000013 RID: 19
		// (Invoke) Token: 0x06000085 RID: 133
		public delegate void OnUndoEditDelegate(ItemKey revertedInstanceKey, ItemKey revertedOriginalPrototypeKey);
	}
}
