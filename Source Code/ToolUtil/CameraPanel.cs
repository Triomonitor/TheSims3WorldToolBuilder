using System;
using System.Windows.Forms;
using Sims3.CSHost;
using Sims3.Math;

namespace ToolUtil
{
	// Token: 0x0200000F RID: 15
	public class CameraPanel : RenderPanel
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000051 RID: 81 RVA: 0x00004316 File Offset: 0x00003316
		// (remove) Token: 0x06000052 RID: 82 RVA: 0x0000432F File Offset: 0x0000332F
		public event CameraMouseDownHandler CameraMouseDown;

		// Token: 0x06000053 RID: 83 RVA: 0x00004348 File Offset: 0x00003348
		public CameraPanel(string name) : base(name)
		{
			this.mBoundingBox.min = new Vector3(-0.5f, 0f, -0.5f);
			this.mBoundingBox.max = new Vector3(0.5f, 1f, 0.5f);
			this.SetSceneCOIFromBBox();
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000043DA File Offset: 0x000033DA
		// (set) Token: 0x06000055 RID: 85 RVA: 0x000043E2 File Offset: 0x000033E2
		public float Truck
		{
			get
			{
				return this.mTruck;
			}
			set
			{
				this.mTruck = Math.Max(value, CameraPanel.kMinTruck);
				if (this.mScene == null)
				{
					return;
				}
				if (this.mScene.MainCamera == null)
				{
					return;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00004414 File Offset: 0x00003414
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00004452 File Offset: 0x00003452
		public Vector3 SceneCOI
		{
			get
			{
				if (this.FollowObject != null && !this.DisableCameraFollow)
				{
					TransformComponent transformComponent = this.FollowObject.TransformComponent;
					if (transformComponent != null)
					{
						this.SceneCOI = transformComponent.AbsolutePosition;
					}
				}
				return this.mSceneCOI;
			}
			set
			{
				if (!this.mSceneCOI.Equals(value))
				{
					this.mSceneCOI = value;
					base.Invalidate();
				}
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000058 RID: 88 RVA: 0x0000447A File Offset: 0x0000347A
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00004482 File Offset: 0x00003482
		public GameObject FollowObject
		{
			get
			{
				return this.mFollowObject;
			}
			set
			{
				this.mFollowObject = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000448B File Offset: 0x0000348B
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00004493 File Offset: 0x00003493
		public bool DisableCameraFollow
		{
			get
			{
				return this.mDisableCameraFollow;
			}
			set
			{
				this.mDisableCameraFollow = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005C RID: 92 RVA: 0x0000449C File Offset: 0x0000349C
		// (set) Token: 0x0600005D RID: 93 RVA: 0x000044A4 File Offset: 0x000034A4
		public Vector3 EulerRotation
		{
			get
			{
				return this.mEulerRotation;
			}
			set
			{
				this.mEulerRotation = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005E RID: 94 RVA: 0x000044B3 File Offset: 0x000034B3
		// (set) Token: 0x0600005F RID: 95 RVA: 0x000044C0 File Offset: 0x000034C0
		public float Pitch
		{
			get
			{
				return this.mEulerRotation.x;
			}
			set
			{
				this.mEulerRotation.x = value;
				this.EulerRotation = this.mEulerRotation;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000060 RID: 96 RVA: 0x000044DA File Offset: 0x000034DA
		// (set) Token: 0x06000061 RID: 97 RVA: 0x000044E7 File Offset: 0x000034E7
		public float Yaw
		{
			get
			{
				return this.mEulerRotation.y;
			}
			set
			{
				this.mEulerRotation.y = value;
				this.EulerRotation = this.mEulerRotation;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00004501 File Offset: 0x00003501
		// (set) Token: 0x06000063 RID: 99 RVA: 0x0000450E File Offset: 0x0000350E
		public float Roll
		{
			get
			{
				return this.mEulerRotation.z;
			}
			set
			{
				this.mEulerRotation.z = value;
				this.EulerRotation = this.mEulerRotation;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00004528 File Offset: 0x00003528
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00004530 File Offset: 0x00003530
		public Vector3 Pan
		{
			get
			{
				return this.mPan;
			}
			set
			{
				this.mPan = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000066 RID: 102 RVA: 0x0000453F File Offset: 0x0000353F
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00004547 File Offset: 0x00003547
		public virtual bool AutoZoom
		{
			get
			{
				return this.mAutoZoom;
			}
			set
			{
				this.mAutoZoom = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00004550 File Offset: 0x00003550
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00004558 File Offset: 0x00003558
		public virtual bool AutoCenter
		{
			get
			{
				return this.mAutoCenter;
			}
			set
			{
				this.mAutoCenter = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00004564 File Offset: 0x00003564
		public static BoundingBox DefaultBBox
		{
			get
			{
				return new BoundingBox
				{
					min = new Vector3(-0.75, 0.0, -0.25),
					max = new Vector3(0.75, 2.0, 0.25)
				};
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000045C8 File Offset: 0x000035C8
		private void InitializeComponent()
		{
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000045CC File Offset: 0x000035CC
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			CameraMouseDownEventArgs e2 = new CameraMouseDownEventArgs(e);
			if (this.CameraMouseDown != null)
			{
				this.CameraMouseDown(this, e2);
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000045FC File Offset: 0x000035FC
		public override void Draw()
		{
			if (!this.DrawingEnabled)
			{
				return;
			}
			this.UpdateTransform();
			base.Draw();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00004613 File Offset: 0x00003613
		public void SetSceneBBox(BoundingBox bbox, bool moveCamera)
		{
			this.mBoundingBox = bbox;
			if (moveCamera)
			{
				this.SetSceneCOIFromBBox();
				this.SetZoomFromBBox();
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000462C File Offset: 0x0000362C
		public void SetZoomFromBBox()
		{
			if (!this.mAutoZoom)
			{
				return;
			}
			float num = CameraPanel.OffsetForBBox(this.Scene.MainCamera, this.mBoundingBox);
			if (Math.Abs(num - this.mTruck) < this.kEpsilon)
			{
				return;
			}
			this.Truck = num;
			base.Invalidate();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000467C File Offset: 0x0000367C
		protected static float OffsetForBBox(Camera camera, BoundingBox bbox)
		{
			float width = camera.Width;
			float num = width / camera.AspectRatio;
			float num2 = Math.Max(bbox.max.x - bbox.min.x, bbox.max.z - bbox.min.z);
			float num3 = bbox.max.y - bbox.min.y;
			float num4 = (float)Math.Atan((double)(width * 0.5f));
			float num5 = (float)Math.Atan((double)(num * 0.5f));
			float num6 = (float)Math.Sin((double)num4);
			float num7 = (float)Math.Sin((double)num5);
			float val = num2 / num6;
			float val2 = num3 / num7;
			return Math.Max(val, val2);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004738 File Offset: 0x00003738
		protected void UpdateTransform()
		{
			if (!this.mGraphicsInitialized)
			{
				return;
			}
			Quaternion q = Quaternion.MakeFromEulerAngles(this.mEulerRotation.x, this.mEulerRotation.y, this.mEulerRotation.z);
			Matrix44 transform = q.ToMatrix();
			Vector3 a = Quaternion.VRotate(q, new Vector3(0f, 0f, this.mTruck));
			transform.pos = (a + this.SceneCOI + this.mPan).ToVector4();
			base.Transform = transform;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000047C8 File Offset: 0x000037C8
		protected void SetSceneCOIFromBBox()
		{
			if (!this.mAutoCenter)
			{
				return;
			}
			this.mPan = Vector3.gZero;
			this.mSceneCOI = (this.mBoundingBox.min + this.mBoundingBox.max) / 2f;
			base.Invalidate();
		}

		// Token: 0x04000036 RID: 54
		protected static readonly float kMinTruck = 0.01f;

		// Token: 0x04000037 RID: 55
		protected static readonly float kDefaultTruck = 3f;

		// Token: 0x04000038 RID: 56
		protected float mTruck = CameraPanel.kDefaultTruck;

		// Token: 0x04000039 RID: 57
		protected Vector3 mEulerRotation = Vector3.gZero;

		// Token: 0x0400003A RID: 58
		protected Vector3 mPan = Vector3.gZero;

		// Token: 0x0400003B RID: 59
		protected Vector3 mSceneCOI = Vector3.gZero;

		// Token: 0x0400003C RID: 60
		private bool mAutoZoom = true;

		// Token: 0x0400003D RID: 61
		private bool mAutoCenter = true;

		// Token: 0x0400003E RID: 62
		private BoundingBox mBoundingBox;

		// Token: 0x0400003F RID: 63
		private GameObject mFollowObject;

		// Token: 0x04000040 RID: 64
		private bool mDisableCameraFollow;
	}
}
