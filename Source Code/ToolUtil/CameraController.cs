using System;
using System.Drawing;
using System.Windows.Forms;
using Sims3.Math;

namespace ToolUtil
{
	// Token: 0x02000028 RID: 40
	public class CameraController
	{
		// Token: 0x14000035 RID: 53
		// (add) Token: 0x060001D7 RID: 471 RVA: 0x0000AA88 File Offset: 0x00009A88
		// (remove) Token: 0x060001D8 RID: 472 RVA: 0x0000AAA1 File Offset: 0x00009AA1
		public event EventHandler CameraMove;

		// Token: 0x060001D9 RID: 473 RVA: 0x0000AABA File Offset: 0x00009ABA
		public CameraController()
		{
			this.mCameraPanel = null;
			this.mbDragging = false;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000AAD0 File Offset: 0x00009AD0
		public CameraController(CameraPanel cameraPanel)
		{
			this.mCameraPanel = null;
			this.mbDragging = false;
			this.SetCameraPanel(cameraPanel);
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001DB RID: 475 RVA: 0x0000AAED File Offset: 0x00009AED
		public bool Dragging
		{
			get
			{
				return this.mbDragging;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001DC RID: 476 RVA: 0x0000AAF5 File Offset: 0x00009AF5
		// (set) Token: 0x060001DD RID: 477 RVA: 0x0000AAFD File Offset: 0x00009AFD
		public Point Anchor
		{
			get
			{
				return this.mAnchor;
			}
			set
			{
				this.mAnchor = value;
			}
		}

		// Token: 0x060001DE RID: 478 RVA: 0x0000AB08 File Offset: 0x00009B08
		public void SetCameraPanel(CameraPanel cameraPanel)
		{
			if (this.mCameraPanel != null)
			{
				this.mCameraPanel.CameraMouseDown -= this.CameraPanel_MouseDown;
				this.mCameraPanel.MouseWheel -= this.CameraPanel_MouseWheel;
			}
			this.mCameraPanel = cameraPanel;
			if (this.mCameraPanel != null)
			{
				this.mCameraPanel.CameraMouseDown += this.CameraPanel_MouseDown;
				this.mCameraPanel.MouseWheel += this.CameraPanel_MouseWheel;
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000AB8C File Offset: 0x00009B8C
		protected static float PlusMinusPi(float value)
		{
			while (value < -3.1415927f)
			{
				value += 6.2831855f;
			}
			while (value > 3.1415927f)
			{
				value -= 6.2831855f;
			}
			return value;
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000ABB8 File Offset: 0x00009BB8
		protected virtual void CameraPanel_MouseDown(object sender, CameraMouseDownEventArgs cmde)
		{
			if (!this.mbDragging)
			{
				this.mbDragging = true;
				this.mAnchor = this.mCameraPanel.PointToClient(Cursor.Position);
				this.mOrigPan = this.mCameraPanel.Pan;
				this.mOrigEulerRotation = this.mCameraPanel.EulerRotation;
				this.mOrigTruck = this.mCameraPanel.Truck;
				this.mCameraPanel.Capture = true;
				Cursor.Hide();
				this.mCameraPanel.MouseMove += this.CameraPanel_MouseMove;
				this.mCameraPanel.MouseUp += this.CameraPanel_MouseUp;
			}
			this.mCameraPanel.Focus();
			this.mCameraPanel.Invalidate();
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000AC78 File Offset: 0x00009C78
		protected virtual void CameraPanel_MouseMove(object sender, MouseEventArgs e)
		{
			Point point = this.mCameraPanel.PointToClient(Cursor.Position);
			if (this.mbDragging)
			{
				float num = (float)(point.X - this.mAnchor.X) / ((float)this.mCameraPanel.Width / 2f);
				float num2 = (float)(point.Y - this.mAnchor.Y) / ((float)this.mCameraPanel.Width / 2f);
				if ((e.Button & MouseButtons.Middle) == MouseButtons.Middle)
				{
					float degrees = this.mCameraPanel.FOV / 2f;
					float scalar = (float)Math.Tan((double)Geometry.Radians(degrees));
					Matrix44 transform = this.mCameraPanel.Transform;
					this.mCameraPanel.Pan = this.mOrigPan - transform.right.ToVector3() * num * this.mCameraPanel.Truck * scalar + transform.up.ToVector3() * num2 * this.mCameraPanel.Truck * scalar;
				}
				else if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
				{
					Vector3 eulerRotation = this.mOrigEulerRotation;
					eulerRotation.y = CameraController.PlusMinusPi(eulerRotation.y - num * 3.1415927f);
					eulerRotation.x = CameraController.PlusMinusPi(eulerRotation.x - num2 * 3.1415927f);
					this.mCameraPanel.EulerRotation = eulerRotation;
				}
				else if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
				{
					if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
					{
						num2 *= 10f;
					}
					else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
					{
						num2 /= 10f;
					}
					this.mCameraPanel.Truck = this.mOrigTruck * (float)Math.Pow(3.0, (double)num);
				}
				if (this.CameraMove != null)
				{
					this.CameraMove(this, new EventArgs());
				}
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000AE8C File Offset: 0x00009E8C
		protected virtual void CameraPanel_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.mbDragging)
			{
				this.mbDragging = false;
				this.mCameraPanel.MouseMove -= this.CameraPanel_MouseMove;
				this.mCameraPanel.MouseUp -= this.CameraPanel_MouseUp;
				Cursor.Show();
				this.mCameraPanel.Invalidate();
			}
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000AEE8 File Offset: 0x00009EE8
		protected virtual void CameraPanel_MouseWheel(object sender, MouseEventArgs e)
		{
			int num = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
			float num2 = 0.1f;
			if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
			{
				num2 *= 10f;
			}
			if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
			{
				num2 /= 10f;
			}
			if (num != 0)
			{
				this.mCameraPanel.Truck = this.mCameraPanel.Truck - (float)num * num2;
			}
			if (this.CameraMove != null)
			{
				this.CameraMove(this, new EventArgs());
			}
		}

		// Token: 0x040000EE RID: 238
		protected const float kPI = 3.1415927f;

		// Token: 0x040000EF RID: 239
		protected CameraPanel mCameraPanel;

		// Token: 0x040000F0 RID: 240
		protected bool mbDragging;

		// Token: 0x040000F1 RID: 241
		protected Point mAnchor;

		// Token: 0x040000F2 RID: 242
		protected Vector3 mOrigPan;

		// Token: 0x040000F3 RID: 243
		protected Vector3 mOrigEulerRotation;

		// Token: 0x040000F4 RID: 244
		protected float mOrigTruck;
	}
}
