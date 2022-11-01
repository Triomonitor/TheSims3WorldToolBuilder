using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Crownwood.DotNetMagic.Menus;
using Sims3.CSHost;
using Sims3.CSHost.Animation;
using Sims3.CSHost.Renderer;
using Sims3.Math;
using ToolUtil.Lighting;
using ToolUtil.Menu;

namespace ToolUtil
{
	// Token: 0x02000017 RID: 23
	public class LightCameraPanel : CameraPanel
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600009D RID: 157 RVA: 0x00005932 File Offset: 0x00004932
		// (remove) Token: 0x0600009E RID: 158 RVA: 0x0000594B File Offset: 0x0000494B
		public event EventHandler DrawGuidesClick;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600009F RID: 159 RVA: 0x00005964 File Offset: 0x00004964
		// (remove) Token: 0x060000A0 RID: 160 RVA: 0x0000597D File Offset: 0x0000497D
		public event EventHandler WireframeClick;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060000A1 RID: 161 RVA: 0x00005996 File Offset: 0x00004996
		// (remove) Token: 0x060000A2 RID: 162 RVA: 0x000059AF File Offset: 0x000049AF
		public event EventHandler OccludersVisibleClick;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060000A3 RID: 163 RVA: 0x000059C8 File Offset: 0x000049C8
		// (remove) Token: 0x060000A4 RID: 164 RVA: 0x000059E1 File Offset: 0x000049E1
		public event EventHandler DisplaySlotClick;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060000A5 RID: 165 RVA: 0x000059FA File Offset: 0x000049FA
		// (remove) Token: 0x060000A6 RID: 166 RVA: 0x00005A13 File Offset: 0x00004A13
		public event EventHandler DisplayRigClick;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060000A7 RID: 167 RVA: 0x00005A2C File Offset: 0x00004A2C
		// (remove) Token: 0x060000A8 RID: 168 RVA: 0x00005A45 File Offset: 0x00004A45
		public event EventHandler BoundingBoxesClick;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060000A9 RID: 169 RVA: 0x00005A5E File Offset: 0x00004A5E
		// (remove) Token: 0x060000AA RID: 170 RVA: 0x00005A77 File Offset: 0x00004A77
		public event EventHandler CustomBoundingBoxesClick;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060000AB RID: 171 RVA: 0x00005A90 File Offset: 0x00004A90
		// (remove) Token: 0x060000AC RID: 172 RVA: 0x00005AA9 File Offset: 0x00004AA9
		public event EventHandler BackfaceCullingClick;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060000AD RID: 173 RVA: 0x00005AC2 File Offset: 0x00004AC2
		// (remove) Token: 0x060000AE RID: 174 RVA: 0x00005ADB File Offset: 0x00004ADB
		public event EventHandler ForceRenderClick;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060000AF RID: 175 RVA: 0x00005AF4 File Offset: 0x00004AF4
		// (remove) Token: 0x060000B0 RID: 176 RVA: 0x00005B0D File Offset: 0x00004B0D
		public event EventHandler TextureLiveUpdateClick;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060000B1 RID: 177 RVA: 0x00005B26 File Offset: 0x00004B26
		// (remove) Token: 0x060000B2 RID: 178 RVA: 0x00005B3F File Offset: 0x00004B3F
		public event EventHandler CenterAroundOriginClick;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060000B3 RID: 179 RVA: 0x00005B58 File Offset: 0x00004B58
		// (remove) Token: 0x060000B4 RID: 180 RVA: 0x00005B71 File Offset: 0x00004B71
		public event EventHandler CenterOnBoundingBoxClick;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060000B5 RID: 181 RVA: 0x00005B8A File Offset: 0x00004B8A
		// (remove) Token: 0x060000B6 RID: 182 RVA: 0x00005BA3 File Offset: 0x00004BA3
		public event EventHandler AutoZoomCameraClick;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060000B7 RID: 183 RVA: 0x00005BBC File Offset: 0x00004BBC
		// (remove) Token: 0x060000B8 RID: 184 RVA: 0x00005BD5 File Offset: 0x00004BD5
		public event EventHandler ResetCameraClick;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060000B9 RID: 185 RVA: 0x00005BEE File Offset: 0x00004BEE
		// (remove) Token: 0x060000BA RID: 186 RVA: 0x00005C07 File Offset: 0x00004C07
		public event EventHandler LightGrayClick;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060000BB RID: 187 RVA: 0x00005C20 File Offset: 0x00004C20
		// (remove) Token: 0x060000BC RID: 188 RVA: 0x00005C39 File Offset: 0x00004C39
		public event EventHandler DarkGrayClick;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060000BD RID: 189 RVA: 0x00005C52 File Offset: 0x00004C52
		// (remove) Token: 0x060000BE RID: 190 RVA: 0x00005C6B File Offset: 0x00004C6B
		public event EventHandler ForestGreenClick;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x060000BF RID: 191 RVA: 0x00005C84 File Offset: 0x00004C84
		// (remove) Token: 0x060000C0 RID: 192 RVA: 0x00005C9D File Offset: 0x00004C9D
		public event EventHandler LightBlueClick;

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060000C1 RID: 193 RVA: 0x00005CB6 File Offset: 0x00004CB6
		// (remove) Token: 0x060000C2 RID: 194 RVA: 0x00005CCF File Offset: 0x00004CCF
		public event EventHandler SetBackgroundColorClick;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060000C3 RID: 195 RVA: 0x00005CE8 File Offset: 0x00004CE8
		// (remove) Token: 0x060000C4 RID: 196 RVA: 0x00005D01 File Offset: 0x00004D01
		public event EventHandler ShowSunlightCursorClick;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060000C5 RID: 197 RVA: 0x00005D1A File Offset: 0x00004D1A
		// (remove) Token: 0x060000C6 RID: 198 RVA: 0x00005D33 File Offset: 0x00004D33
		public event EventHandler DrawShadowsClick;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060000C7 RID: 199 RVA: 0x00005D4C File Offset: 0x00004D4C
		// (remove) Token: 0x060000C8 RID: 200 RVA: 0x00005D65 File Offset: 0x00004D65
		public event EventHandler SetSunlightColorClick;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060000C9 RID: 201 RVA: 0x00005D7E File Offset: 0x00004D7E
		// (remove) Token: 0x060000CA RID: 202 RVA: 0x00005D97 File Offset: 0x00004D97
		public event EventHandler ResetSunlightClick;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060000CB RID: 203 RVA: 0x00005DB0 File Offset: 0x00004DB0
		// (remove) Token: 0x060000CC RID: 204 RVA: 0x00005DC9 File Offset: 0x00004DC9
		public event EventHandler ShaderVisualizerModeClick;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x060000CD RID: 205 RVA: 0x00005DE2 File Offset: 0x00004DE2
		// (remove) Token: 0x060000CE RID: 206 RVA: 0x00005DFB File Offset: 0x00004DFB
		public event EventHandler DropShadowsClick;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x060000CF RID: 207 RVA: 0x00005E14 File Offset: 0x00004E14
		// (remove) Token: 0x060000D0 RID: 208 RVA: 0x00005E2D File Offset: 0x00004E2D
		public event EventHandler DrawGuidesUpdate;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x060000D1 RID: 209 RVA: 0x00005E46 File Offset: 0x00004E46
		// (remove) Token: 0x060000D2 RID: 210 RVA: 0x00005E5F File Offset: 0x00004E5F
		public event EventHandler WireframeUpdate;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060000D3 RID: 211 RVA: 0x00005E78 File Offset: 0x00004E78
		// (remove) Token: 0x060000D4 RID: 212 RVA: 0x00005E91 File Offset: 0x00004E91
		public event EventHandler OccludersVisibleUpdate;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060000D5 RID: 213 RVA: 0x00005EAA File Offset: 0x00004EAA
		// (remove) Token: 0x060000D6 RID: 214 RVA: 0x00005EC3 File Offset: 0x00004EC3
		public event EventHandler DisplayFXStatsUpdate;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x060000D7 RID: 215 RVA: 0x00005EDC File Offset: 0x00004EDC
		// (remove) Token: 0x060000D8 RID: 216 RVA: 0x00005EF5 File Offset: 0x00004EF5
		public event EventHandler DisplayRenderingStatsUpdate;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060000D9 RID: 217 RVA: 0x00005F0E File Offset: 0x00004F0E
		// (remove) Token: 0x060000DA RID: 218 RVA: 0x00005F27 File Offset: 0x00004F27
		public event EventHandler DisplaySlotUpdate;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060000DB RID: 219 RVA: 0x00005F40 File Offset: 0x00004F40
		// (remove) Token: 0x060000DC RID: 220 RVA: 0x00005F59 File Offset: 0x00004F59
		public event EventHandler DisplayRigUpdate;

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060000DD RID: 221 RVA: 0x00005F72 File Offset: 0x00004F72
		// (remove) Token: 0x060000DE RID: 222 RVA: 0x00005F8B File Offset: 0x00004F8B
		public event EventHandler BoundingBoxesUpdate;

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x060000DF RID: 223 RVA: 0x00005FA4 File Offset: 0x00004FA4
		// (remove) Token: 0x060000E0 RID: 224 RVA: 0x00005FBD File Offset: 0x00004FBD
		public event EventHandler CustomBoundingBoxesUpdate;

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x060000E1 RID: 225 RVA: 0x00005FD6 File Offset: 0x00004FD6
		// (remove) Token: 0x060000E2 RID: 226 RVA: 0x00005FEF File Offset: 0x00004FEF
		public event EventHandler BackfaceCullingUpdate;

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x060000E3 RID: 227 RVA: 0x00006008 File Offset: 0x00005008
		// (remove) Token: 0x060000E4 RID: 228 RVA: 0x00006021 File Offset: 0x00005021
		public event EventHandler ForceRenderUpdate;

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x060000E5 RID: 229 RVA: 0x0000603A File Offset: 0x0000503A
		// (remove) Token: 0x060000E6 RID: 230 RVA: 0x00006053 File Offset: 0x00005053
		public event EventHandler TextureLiveUpdate;

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x060000E7 RID: 231 RVA: 0x0000606C File Offset: 0x0000506C
		// (remove) Token: 0x060000E8 RID: 232 RVA: 0x00006085 File Offset: 0x00005085
		public event EventHandler CenterAroundOriginUpdate;

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x060000E9 RID: 233 RVA: 0x0000609E File Offset: 0x0000509E
		// (remove) Token: 0x060000EA RID: 234 RVA: 0x000060B7 File Offset: 0x000050B7
		public event EventHandler CenterOnBoundingBoxUpdate;

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x060000EB RID: 235 RVA: 0x000060D0 File Offset: 0x000050D0
		// (remove) Token: 0x060000EC RID: 236 RVA: 0x000060E9 File Offset: 0x000050E9
		public event EventHandler AutoZoomCameraUpdate;

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x060000ED RID: 237 RVA: 0x00006102 File Offset: 0x00005102
		// (remove) Token: 0x060000EE RID: 238 RVA: 0x0000611B File Offset: 0x0000511B
		public event EventHandler LightGrayUpdate;

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x060000EF RID: 239 RVA: 0x00006134 File Offset: 0x00005134
		// (remove) Token: 0x060000F0 RID: 240 RVA: 0x0000614D File Offset: 0x0000514D
		public event EventHandler DarkGrayUpdate;

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x060000F1 RID: 241 RVA: 0x00006166 File Offset: 0x00005166
		// (remove) Token: 0x060000F2 RID: 242 RVA: 0x0000617F File Offset: 0x0000517F
		public event EventHandler ForestGreenUpdate;

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x060000F3 RID: 243 RVA: 0x00006198 File Offset: 0x00005198
		// (remove) Token: 0x060000F4 RID: 244 RVA: 0x000061B1 File Offset: 0x000051B1
		public event EventHandler LightBlueUpdate;

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x060000F5 RID: 245 RVA: 0x000061CA File Offset: 0x000051CA
		// (remove) Token: 0x060000F6 RID: 246 RVA: 0x000061E3 File Offset: 0x000051E3
		public event EventHandler ShowSunlightCursorUpdate;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x060000F7 RID: 247 RVA: 0x000061FC File Offset: 0x000051FC
		// (remove) Token: 0x060000F8 RID: 248 RVA: 0x00006215 File Offset: 0x00005215
		public event EventHandler DrawShadowsUpdate;

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x060000F9 RID: 249 RVA: 0x0000622E File Offset: 0x0000522E
		// (remove) Token: 0x060000FA RID: 250 RVA: 0x00006247 File Offset: 0x00005247
		public event EventHandler ShaderVisualizerModeUpdate;

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x060000FB RID: 251 RVA: 0x00006260 File Offset: 0x00005260
		// (remove) Token: 0x060000FC RID: 252 RVA: 0x00006279 File Offset: 0x00005279
		public event EventHandler DropShadowsUpdate;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x060000FD RID: 253 RVA: 0x00006292 File Offset: 0x00005292
		// (remove) Token: 0x060000FE RID: 254 RVA: 0x000062AB File Offset: 0x000052AB
		public event EventHandler LightProbeBeginUpdate;

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x060000FF RID: 255 RVA: 0x000062C4 File Offset: 0x000052C4
		// (remove) Token: 0x06000100 RID: 256 RVA: 0x000062DD File Offset: 0x000052DD
		public event EventHandler LightProbeEndUpdate;

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000101 RID: 257 RVA: 0x000062F6 File Offset: 0x000052F6
		// (set) Token: 0x06000102 RID: 258 RVA: 0x000062FE File Offset: 0x000052FE
		[Browsable(false)]
		public bool DrawGuides
		{
			get
			{
				return this.mDrawGuides;
			}
			set
			{
				this.mDrawGuides = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00006307 File Offset: 0x00005307
		// (set) Token: 0x06000104 RID: 260 RVA: 0x0000630F File Offset: 0x0000530F
		[Browsable(false)]
		public bool DisplaySlot
		{
			get
			{
				return this.mDisplaySlot;
			}
			set
			{
				this.mDisplaySlot = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00006318 File Offset: 0x00005318
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00006320 File Offset: 0x00005320
		[Browsable(false)]
		public bool DisplayRig
		{
			get
			{
				return this.mDisplayRig;
			}
			set
			{
				this.mDisplayRig = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00006329 File Offset: 0x00005329
		// (set) Token: 0x06000108 RID: 264 RVA: 0x00006331 File Offset: 0x00005331
		[Browsable(false)]
		public bool DisplayFXStats
		{
			get
			{
				return this.mDisplayFXStats;
			}
			set
			{
				this.mDisplayFXStats = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000109 RID: 265 RVA: 0x0000633A File Offset: 0x0000533A
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00006342 File Offset: 0x00005342
		[Browsable(false)]
		public bool DisplayRenderingStats
		{
			get
			{
				return this.mDisplayRenderingStats;
			}
			set
			{
				this.mDisplayRenderingStats = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600010B RID: 267 RVA: 0x0000634B File Offset: 0x0000534B
		[Browsable(false)]
		public LineSet LineSet
		{
			get
			{
				if (this.mLineSet == null)
				{
					this.mLineSet = new LineSet();
				}
				return this.mLineSet;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00006366 File Offset: 0x00005366
		// (set) Token: 0x0600010D RID: 269 RVA: 0x0000636E File Offset: 0x0000536E
		public virtual bool TextureLive
		{
			get
			{
				return this.mTextureLive;
			}
			set
			{
				if (this.mTextureLive == value)
				{
					return;
				}
				this.mTextureLive = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00006388 File Offset: 0x00005388
		[Browsable(false)]
		public GameObject LightObject
		{
			get
			{
				if (this.mLightObject == null)
				{
					uint[] components = new uint[]
					{
						1422622395U
					};
					GameObjectSpec spec = new GameObjectSpec();
					this.mLightObject = new GameObject(spec, components);
				}
				return this.mLightObject;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600010F RID: 271 RVA: 0x000063C7 File Offset: 0x000053C7
		// (set) Token: 0x06000110 RID: 272 RVA: 0x000063CF File Offset: 0x000053CF
		[Browsable(false)]
		public GameObject GameObject
		{
			get
			{
				return this.mGameObject;
			}
			set
			{
				this.mGameObject = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000111 RID: 273 RVA: 0x000063D8 File Offset: 0x000053D8
		// (set) Token: 0x06000112 RID: 274 RVA: 0x000063E0 File Offset: 0x000053E0
		[Browsable(false)]
		public bool LightVisible
		{
			get
			{
				return this.mLightVisible;
			}
			set
			{
				if (this.mLightVisible != value)
				{
					if (value)
					{
						if (this.mLightObject != null)
						{
							this.mScene.AddObject(this.mLightObject.ObjectId);
						}
					}
					else if (this.mLightObject != null)
					{
						this.mScene.RemoveObject(this.mLightObject.ObjectId);
					}
					this.mLightVisible = value;
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000113 RID: 275 RVA: 0x0000643E File Offset: 0x0000543E
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00006446 File Offset: 0x00005446
		[Browsable(false)]
		public float LightPitch
		{
			get
			{
				return this.mLightPitch;
			}
			set
			{
				this.mLightPitch = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000115 RID: 277 RVA: 0x0000644F File Offset: 0x0000544F
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00006457 File Offset: 0x00005457
		[Browsable(false)]
		public float LightYaw
		{
			get
			{
				return this.mLightYaw;
			}
			set
			{
				this.mLightYaw = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00006460 File Offset: 0x00005460
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00006468 File Offset: 0x00005468
		[Browsable(false)]
		public float TurntableYaw
		{
			get
			{
				return this.mTurntableYaw;
			}
			set
			{
				this.mTurntableYaw = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00006471 File Offset: 0x00005471
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00006479 File Offset: 0x00005479
		[Browsable(false)]
		public Vector3 LightCOI
		{
			get
			{
				return this.mLightCOI;
			}
			set
			{
				this.mLightCOI = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00006482 File Offset: 0x00005482
		// (set) Token: 0x0600011C RID: 284 RVA: 0x0000648A File Offset: 0x0000548A
		[Browsable(false)]
		public Color LightColor
		{
			get
			{
				return this.mLightColor;
			}
			set
			{
				this.mLightColor = value;
				if (this.mScene != null)
				{
					this.mScene.SetSunColor(value.ToArgb());
				}
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600011D RID: 285 RVA: 0x000064AD File Offset: 0x000054AD
		// (set) Token: 0x0600011E RID: 286 RVA: 0x000064B5 File Offset: 0x000054B5
		[Browsable(false)]
		public override SceneManager Scene
		{
			get
			{
				return base.Scene;
			}
			set
			{
				base.Scene = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600011F RID: 287 RVA: 0x000064BE File Offset: 0x000054BE
		[Browsable(false)]
		public bool BackgroundEnabled
		{
			get
			{
				return this.mBackgroundSceneEnabled;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000120 RID: 288 RVA: 0x000064C6 File Offset: 0x000054C6
		[Browsable(false)]
		public LightRigType ActiveBackground
		{
			get
			{
				return this.mActiveBackground;
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000064D0 File Offset: 0x000054D0
		public LightCameraPanel(string name) : base(name)
		{
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00006528 File Offset: 0x00005528
		protected override void DrawExtras()
		{
			base.DrawExtras();
			RenderDataArray.SetObjectToWorldSpaceMatrix(Matrix44.gIdentity);
			this.DrawLineSetExtras();
			this.LineSet.Draw();
			this.LineSet.Clear();
			if (this.LightObject != null)
			{
				Quaternion q = Quaternion.MakeFromEulerAngles(this.mLightPitch, this.mLightYaw, 0f);
				Matrix44 absoluteTransform = q.ToMatrix();
				Vector3 v = new Vector3(0f, 0f, 3f);
				Vector3 a = Quaternion.VRotate(q, v);
				absoluteTransform.pos = (a + this.mLightCOI).ToVector4();
				this.mLightObject.TransformComponent.AbsoluteTransform = absoluteTransform;
				this.mScene.SetSunDirection(absoluteTransform.at.x, absoluteTransform.at.y, absoluteTransform.at.z);
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00006604 File Offset: 0x00005604
		protected virtual void DrawLineSetExtras()
		{
			if (this.DrawGuides)
			{
				this.DrawGuidesIntoLineset();
			}
			if (this.mGameObject != null)
			{
				if (this.DisplaySlot)
				{
					using (SlotComponent slotComponent = this.mGameObject.SlotComponent)
					{
						if (slotComponent != null)
						{
							BoundingBox bbox = this.Scene.GetBBox();
							foreach (SlotComponent.Slot slot in slotComponent.GetSlotEnumerator())
							{
								Matrix44 a = Matrix44.gIdentity;
								try
								{
									a = slot.GetSlotMatrixFromRenderer(this.mGameObject);
								}
								catch (InvalidOperationException)
								{
									continue;
								}
								Matrix44 absoluteTransform = this.mGameObject.TransformComponent.AbsoluteTransform;
								a *= absoluteTransform;
								Vector3 vector = a.pos.ToVector3();
								if (vector.x < bbox.min.x)
								{
									bbox.min.x = vector.x;
								}
								else if (vector.x > bbox.max.x)
								{
									bbox.max.x = vector.x;
								}
								if (vector.y < bbox.min.y)
								{
									bbox.min.y = vector.y;
								}
								else if (vector.y > bbox.max.y)
								{
									bbox.max.y = vector.y;
								}
								if (vector.z < bbox.min.z)
								{
									bbox.min.z = vector.z;
								}
								else if (vector.z > bbox.max.z)
								{
									bbox.max.z = vector.z;
								}
							}
							float num = 0f;
							if (bbox.max.x - bbox.min.x > num)
							{
								num = bbox.max.x - bbox.min.x;
							}
							if (bbox.max.y - bbox.min.y > num)
							{
								num = bbox.max.y - bbox.min.y;
							}
							if (bbox.max.z - bbox.min.z > num)
							{
								num = bbox.max.z - bbox.min.z;
							}
							foreach (SlotComponent.Slot slot2 in slotComponent.GetSlotEnumerator())
							{
								Matrix44 a2 = Matrix44.gIdentity;
								try
								{
									a2 = slot2.GetSlotMatrixFromRenderer(this.mGameObject);
								}
								catch (InvalidOperationException)
								{
									continue;
								}
								Matrix44 absoluteTransform2 = this.mGameObject.TransformComponent.AbsoluteTransform;
								a2 *= absoluteTransform2;
								Vector3 vector2 = a2.pos.ToVector3();
								double scalar = 0.05 * (double)num;
								this.LineSet.AddSegment(vector2, vector2 + scalar * a2.right.ToVector3(), Color.Red);
								this.LineSet.AddSegment(vector2, vector2 + scalar * a2.up.ToVector3(), Color.Green);
								this.LineSet.AddSegment(vector2, vector2 + scalar * a2.at.ToVector3(), Color.Blue);
								if (slot2.IsConeSlot())
								{
									float coneSlotRadius = slot2.GetConeSlotRadius();
									float num2 = slot2.GetConeSlotAngle();
									num2 *= 0.5f;
									float num3 = coneSlotRadius * (float)Math.Sin((double)num2);
									float z = coneSlotRadius * (float)Math.Cos((double)num2);
									Vector3 vector3 = new Vector3(num3, 0f, z);
									vector3 = a2.TransformVector(vector3);
									vector3 = vector2 + vector3;
									this.LineSet.AddSegment(vector2, vector3, Color.Blue);
									Vector3 vector4 = new Vector3(-num3, 0f, z);
									vector4 = a2.TransformVector(vector4);
									vector4 = vector2 + vector4;
									this.LineSet.AddSegment(vector2, vector4, Color.Blue);
									float num4 = Geometry.Radians(10f);
									float num5 = num4;
									Vector3 vector5 = new Vector3(0f, 0f, coneSlotRadius);
									vector5 = vector2 + a2.TransformVector(vector5);
									Vector3 from = vector5;
									while (num5 < num2)
									{
										float num6 = coneSlotRadius * (float)Math.Sin((double)num5);
										float z2 = coneSlotRadius * (float)Math.Cos((double)num5);
										Vector3 vector6 = new Vector3(num6, 0f, z2);
										Vector3 vector7 = new Vector3(-num6, 0f, z2);
										vector6 = vector2 + a2.TransformVector(vector6);
										vector7 = vector2 + a2.TransformVector(vector7);
										this.LineSet.AddSegment(vector5, vector6, Color.Blue);
										this.LineSet.AddSegment(from, vector7, Color.Blue);
										vector5 = vector6;
										from = vector7;
										num5 += num4;
									}
									this.LineSet.AddSegment(vector5, vector3, Color.Blue);
									this.LineSet.AddSegment(from, vector4, Color.Blue);
								}
								float x;
								float y;
								if (this.ComputeScreenCoords(vector2, out x, out y))
								{
									KeyNameMap nameHash2StringMap = slotComponent.NameHash2StringMap;
									if (nameHash2StringMap != null)
									{
										string text = nameHash2StringMap.Find((ulong)slot2.NameHash);
										App.DrawText(text, x, y);
									}
								}
							}
						}
					}
				}
				if (this.DisplayRig)
				{
					AnimationComponent animationComponent = this.mGameObject.AnimationComponent;
					Rig rig = (animationComponent != null) ? animationComponent.Rig : null;
					if (rig != null && rig.IsValid)
					{
						Rig.JointNode jointTreeRoot = rig.JointTreeRoot;
						this.DrawRigSkeleton(jointTreeRoot);
					}
				}
			}
			if (this.LightVisible)
			{
				Matrix44 absoluteTransform3 = this.mLightObject.TransformComponent.AbsoluteTransform;
				this.DrawSkeletonJoint(absoluteTransform3);
			}
			float x2 = 5f;
			float num7 = 5f;
			if (this.DisplayRenderingStats)
			{
				StatsManager.DrawStats(x2, num7);
				num7 += 13f;
			}
			if (this.DisplayFXStats)
			{
				EffectsManager.DrawStats(x2, num7, 13f);
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00006CAC File Offset: 0x00005CAC
		protected void DrawRigSkeleton(Rig.JointNode root)
		{
			TransformComponent transformComponent = this.mGameObject.TransformComponent;
			Matrix44 item = Matrix44.gIdentity;
			if (transformComponent != null)
			{
				item = transformComponent.AbsoluteTransform;
			}
			Stack<Matrix44> stack = new Stack<Matrix44>();
			stack.Push(item);
			this.DrawRigSkeletonRecurse(stack, root);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00006CEC File Offset: 0x00005CEC
		protected void DrawRigSkeletonRecurse(Stack<Matrix44> trans, Rig.JointNode joint)
		{
			Matrix44 matrix = trans.Peek();
			matrix = joint.LocalMatrix * matrix;
			this.DrawSkeletonJoint(matrix);
			foreach (Rig.JointNode jointNode in joint.Children)
			{
				this.DrawSkeletonBone(matrix, jointNode);
				trans.Push(matrix);
				this.DrawRigSkeletonRecurse(trans, jointNode);
				trans.Pop();
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00006D4C File Offset: 0x00005D4C
		protected void DrawSkeletonBone(Matrix44 mat, Rig.JointNode child)
		{
			Vector4 pos = child.LocalMatrix.pos;
			Vector3 vec = pos.ToVector3();
			float num = vec.Normalize();
			if (num == 0f)
			{
				return;
			}
			num = 1f / num;
			Matrix44 matrix = mat;
			if (Math.Abs(vec.x) > 1E-05f)
			{
				float angleRadians = (float)Math.Atan2((double)vec.x, (double)vec.z);
				Vector3 axis = new Vector3(0f, 1f, 0f);
				Matrix44 a = Quaternion.MakeFromAxisAngle(axis, angleRadians).ToMatrix();
				vec = a.InverseTransformVector(vec);
				matrix = a * mat;
			}
			float num2 = (float)Math.Atan2((double)(-(double)vec.y), (double)vec.z);
			if (num2 != 0f)
			{
				Vector3 axis2 = new Vector3(1f, 0f, 0f);
				Matrix44 a2 = Quaternion.MakeFromAxisAngle(axis2, num2).ToMatrix();
				matrix = a2 * matrix;
			}
			Vector3 vec2 = new Vector3(LightCameraPanel.kJointRadius, 0f, LightCameraPanel.kJointRadius);
			Vector3 vec3 = new Vector3(0f, LightCameraPanel.kJointRadius, LightCameraPanel.kJointRadius);
			Vector3 vec4 = new Vector3(-LightCameraPanel.kJointRadius, 0f, LightCameraPanel.kJointRadius);
			Vector3 vec5 = new Vector3(0f, -LightCameraPanel.kJointRadius, LightCameraPanel.kJointRadius);
			Vector3 vec6 = new Vector3(0f, 0f, num - LightCameraPanel.kJointRadius);
			Vector3[] array = new Vector3[]
			{
				matrix * vec2,
				matrix * vec3,
				matrix * vec4,
				matrix * vec5,
				matrix * vec6
			};
			this.LineSet.AddSegment(array[0], array[1], Color.Black);
			this.LineSet.AddSegment(array[1], array[2], Color.Black);
			this.LineSet.AddSegment(array[2], array[3], Color.Black);
			this.LineSet.AddSegment(array[3], array[0], Color.Black);
			this.LineSet.AddSegment(array[0], array[4], Color.Black);
			this.LineSet.AddSegment(array[1], array[4], Color.Black);
			this.LineSet.AddSegment(array[2], array[4], Color.Black);
			this.LineSet.AddSegment(array[3], array[4], Color.Black);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000707C File Offset: 0x0000607C
		protected void DrawSkeletonJoint(Matrix44 mat)
		{
			Vector3 vec = new Vector3(LightCameraPanel.kJointRadius, 0f, 0f);
			Vector3 vec2 = new Vector3(LightCameraPanel.kJointRadius * 0.866025f, LightCameraPanel.kJointRadius * 0.5f, 0f);
			Vector3 vec3 = new Vector3(LightCameraPanel.kJointRadius * 0.5f, LightCameraPanel.kJointRadius * 0.866025f, 0f);
			Vector3 vec4 = new Vector3(0f, LightCameraPanel.kJointRadius, 0f);
			Vector3 vec5 = new Vector3(-vec3.x, vec3.y, 0f);
			Vector3 vec6 = new Vector3(-vec2.x, vec2.y, 0f);
			Vector3 vec7 = new Vector3(-LightCameraPanel.kJointRadius, 0f, 0f);
			Vector3 vec8 = new Vector3(vec6.x, -vec6.y, 0f);
			Vector3 vec9 = new Vector3(vec5.x, -vec5.y, 0f);
			Vector3 vec10 = new Vector3(0f, -LightCameraPanel.kJointRadius, 0f);
			Vector3 vec11 = new Vector3(vec3.x, -vec3.y, --0f);
			Vector3 vec12 = new Vector3(vec2.x, -vec2.y, --0f);
			Vector3[] array = new Vector3[]
			{
				mat * vec,
				mat * vec2,
				mat * vec3,
				mat * vec4,
				mat * vec5,
				mat * vec6,
				mat * vec7,
				mat * vec8,
				mat * vec9,
				mat * vec10,
				mat * vec11,
				mat * vec12
			};
			for (int i = 0; i < 12; i++)
			{
				this.LineSet.AddSegment(array[i], array[(i + 1) % 12], Color.Blue);
			}
			Matrix44 xf = mat;
			xf.at = mat.up;
			xf.up = -1f * mat.at;
			array[0] = xf * vec;
			array[1] = xf * vec2;
			array[2] = xf * vec3;
			array[3] = xf * vec4;
			array[4] = xf * vec5;
			array[5] = xf * vec6;
			array[6] = xf * vec7;
			array[7] = xf * vec8;
			array[8] = xf * vec9;
			array[9] = xf * vec10;
			array[10] = xf * vec11;
			array[11] = xf * vec12;
			for (int j = 0; j < 12; j++)
			{
				this.LineSet.AddSegment(array[j], array[(j + 1) % 12], Color.Green);
			}
			xf = mat;
			xf.at = mat.right;
			xf.right = -1f * mat.at;
			array[0] = xf * vec;
			array[1] = xf * vec2;
			array[2] = xf * vec3;
			array[3] = xf * vec4;
			array[4] = xf * vec5;
			array[5] = xf * vec6;
			array[6] = xf * vec7;
			array[7] = xf * vec8;
			array[8] = xf * vec9;
			array[9] = xf * vec10;
			array[10] = xf * vec11;
			array[11] = xf * vec12;
			for (int k = 0; k < 12; k++)
			{
				this.LineSet.AddSegment(array[k], array[(k + 1) % 12], Color.Red);
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000075F8 File Offset: 0x000065F8
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.mLineSet != null)
				{
					this.mLineSet.Dispose();
					this.mLineSet = null;
				}
				if (this.mLightObject != null)
				{
					this.mLightObject.Dispose();
					this.mLightObject = null;
				}
				if (this.mActiveBackgroundObject != null)
				{
					this.mActiveBackgroundObject.Dispose();
					if (this.mActiveBackgroundObject.ObjectId != GameObject.kBadObjectId)
					{
						GameObjectFactory.Destroy(this.mActiveBackgroundObject.ObjectId);
					}
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00007678 File Offset: 0x00006678
		public virtual void RegisterMenus(IMainMenu menu)
		{
			this.PreRegisterMenus(menu);
			this.PostRegisterMenus(menu);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00007688 File Offset: 0x00006688
		protected virtual void PreRegisterMenus(IMainMenu menu)
		{
			menu.AddMenuItem(LightCameraPanel.kMenuName, "&Grid Lines", new EventHandler(this.DrawGuide_Click), new EventHandler(this.DrawGuide_Update), false, false);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "&Wireframe", new EventHandler(this.Wireframe_Click), new EventHandler(this.Wireframe_Update), false, false);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "&Bounding Boxes", new EventHandler(this.BoundingBoxes_Click), new EventHandler(this.BoundingBoxes_Update), false, false);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "&Custom Bounding Boxes", new EventHandler(this.CustomBoundingBoxes_Click), new EventHandler(this.CustomBoundingBoxes_Update), false, false);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "Back&face Culling", new EventHandler(this.BackfaceCulling_Click), new EventHandler(this.BackfaceCulling_Update), false, false);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "Force Render", new EventHandler(this.ForceRender_Click), new EventHandler(this.ForceRender_Update), false, false);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "Texture Live Update", new EventHandler(this.TextureLiveUpdate_Click), new EventHandler(this.TextureLiveUpdate_Update), false, false);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "&Drop Shadows", new EventHandler(this.DropShadows_Click), new EventHandler(this.DropShadows_Update), false, false);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "&Occluders", new EventHandler(this.OccludersVisible_Click), new EventHandler(this.OccludersVisible_Update), false, false);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "Display F&X Stats", new EventHandler(this.DisplayFXStats_Click), new EventHandler(this.DisplayFXStats_Update), false, false);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "Display Rendering &Stats", new EventHandler(this.DisplayRenderingStats_Click), new EventHandler(this.DisplayRenderingStats_Update), false, false);
			menu.AddSeperator(LightCameraPanel.kMenuName);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000787C File Offset: 0x0000687C
		protected virtual void PostRegisterMenus(IMainMenu menu)
		{
			menu.AddMenuItem(LightCameraPanel.kMenuName, "Center Around &Origin", new EventHandler(this.CenterAroundOrigin_Click), new EventHandler(this.CenterAroundOrigin_Update), false, true);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "Center On Bounding Bo&x", new EventHandler(this.CenterOnBBox_Click), new EventHandler(this.CenterOnBBox_Update), false, true);
			menu.AddSeperator(LightCameraPanel.kMenuName);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "Auto-&zoom Camera", new EventHandler(this.AutoZoomCamera_Click), new EventHandler(this.AutoZoomCamera_Update), false, false);
			menu.AddMenuItem(LightCameraPanel.kMenuName, "&Reset Camera", new EventHandler(this.ResetCamera_Click));
			menu.AddSeperator(LightCameraPanel.kMenuName);
			ToolUtil.Menu.MenuItem menuItem = new ToolUtil.Menu.MenuItem("Background &Color", null);
			menuItem.MenuItems.Add(new ToolUtil.Menu.MenuItem("&Light Gray", new EventHandler(this.LightGray_Click), new EventHandler(this.LightGray_Update), false, true));
			menuItem.MenuItems.Add(new ToolUtil.Menu.MenuItem("&Dark Gray", new EventHandler(this.DarkGray_Click), new EventHandler(this.DarkGray_Update), false, true));
			menuItem.MenuItems.Add(new ToolUtil.Menu.MenuItem("&Forest Green", new EventHandler(this.ForestGreen_Click)));
			menuItem.MenuItems.Add(new ToolUtil.Menu.MenuItem("&Light Blue", new EventHandler(this.LightBlue_Click)));
			menuItem.MenuItems.Add(new ToolUtil.Menu.MenuItem("&Set...", new EventHandler(this.SetBackgroundColor_Click)));
			menu.AddMenuItem(LightCameraPanel.kMenuName, menuItem);
			menu.AddSeperator(LightCameraPanel.kMenuName);
			Shortcut[] array = new Shortcut[]
			{
				Shortcut.CtrlShift0,
				Shortcut.CtrlShift1,
				Shortcut.CtrlShift2,
				Shortcut.CtrlShift3,
				Shortcut.CtrlShift4,
				Shortcut.CtrlShift5,
				Shortcut.CtrlShift6,
				Shortcut.CtrlShift7,
				Shortcut.CtrlShift8,
				Shortcut.CtrlShift9,
				Shortcut.CtrlShiftA,
				Shortcut.CtrlShiftB,
				Shortcut.CtrlShiftC,
				Shortcut.CtrlShiftD,
				Shortcut.CtrlShiftE,
				Shortcut.CtrlShiftF
			};
			Array values = Enum.GetValues(typeof(VisualizerModes));
			ToolUtil.Menu.MenuItem menuItem2 = new ToolUtil.Menu.MenuItem("&Visualizers", null);
			foreach (object obj in values)
			{
				VisualizerModes visualizerModes = (VisualizerModes)obj;
				int num = (int)visualizerModes;
				ToolUtil.Menu.MenuItem menuItem3 = new ToolUtil.Menu.MenuItem(visualizerModes.ToString(), new EventHandler(this.VisualizerMode_Click), new EventHandler(this.VisualizerMode_Update), false, false, num);
				if (num < array.Length)
				{
					menuItem3.Shortcut = array[num];
				}
				menuItem2.MenuItems.Add(menuItem3);
			}
			menu.AddMenuItem(LightCameraPanel.kMenuName, menuItem2);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00007B90 File Offset: 0x00006B90
		public void SetActiveBackgroundObject(GameObject obj)
		{
			this.mActiveBackgroundObject = obj;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00007B9C File Offset: 0x00006B9C
		public void UpdateLightProbes()
		{
			if (this.LightProbeBeginUpdate != null)
			{
				this.LightProbeBeginUpdate(null, EventArgs.Empty);
			}
			bool visible = true;
			if (this.mGameObject != null && this.mGameObject.ModelComponent != null)
			{
				visible = this.mGameObject.ModelComponent.Visible;
				this.mGameObject.ModelComponent.Visible = false;
			}
			bool flag = this.mBackgroundSceneEnabled;
			this.ShowBackgroundScene();
			uint fence = this.mScene.InsertFence();
			while (!this.mScene.IsFencePassed(fence) || this.mScene.IsLoading)
			{
				App.Update(0.001f, 0.001f);
			}
			if (GfxDevice.BeginScene())
			{
				this.mScene.BeginFrame();
				this.mScene.DrawScene();
				GfxDevice.EndScene();
			}
			this.mScene.SetExteriorProbePosition(0f, 1f, 0f);
			this.mScene.UpdateLightProbes();
			if (GfxDevice.BeginScene())
			{
				for (int i = 0; i < 8; i++)
				{
					this.mScene.BeginFrame();
					this.mScene.DrawScene();
				}
				GfxDevice.EndScene();
			}
			if (this.mGameObject != null && this.mGameObject.ModelComponent != null)
			{
				this.mGameObject.ModelComponent.Visible = visible;
			}
			for (int j = 0; j < 30; j++)
			{
				App.Update(0.001f, 0.001f);
			}
			if (GfxDevice.BeginScene())
			{
				for (int k = 0; k < 8; k++)
				{
					this.mScene.BeginFrame();
					this.mScene.DrawScene();
				}
				GfxDevice.EndScene();
			}
			for (int l = 0; l < 30; l++)
			{
				App.Update(0.001f, 0.001f);
			}
			if (!flag)
			{
				this.HideBackgroundScene();
			}
			if (this.LightProbeEndUpdate != null)
			{
				this.LightProbeEndUpdate(null, EventArgs.Empty);
			}
			base.Invalidate(true);
			Application.DoEvents();
			base.Invalidate(true);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00007D84 File Offset: 0x00006D84
		private void DrawGuidesIntoLineset()
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			if (base.FollowObject != null && !base.DisableCameraFollow)
			{
				Vector3 sceneCOI = base.SceneCOI;
				num = sceneCOI.x;
				num2 = sceneCOI.z;
				num3 = (float)decimal.Round((decimal)sceneCOI.x);
				num4 = (float)decimal.Round((decimal)sceneCOI.z);
			}
			for (int i = -3; i <= 3; i++)
			{
				if (i == 0)
				{
					this.LineSet.AddSegment(new Vector3(num - 3f, 0f, num4), new Vector3(num3, 0f, num4), Color.Black);
					this.LineSet.AddSegment(new Vector3(num3, 0f, num2 - 3f), new Vector3(num3, 0f, num4), Color.Black);
					this.LineSet.AddSegment(new Vector3(num3 + 1f, 0f, num4), new Vector3(num + 3f, 0f, num4), Color.Black);
					this.LineSet.AddSegment(new Vector3(num3, 0f, num4 + 1f), new Vector3(num3, 0f, num2 + 3f), Color.Black);
				}
				else
				{
					this.LineSet.AddSegment(new Vector3(num - 3f, 0f, num4 + (float)i), new Vector3(num + 3f, 0f, num4 + (float)i), Color.Black);
					this.LineSet.AddSegment(new Vector3(num3 + (float)i, 0f, num2 - 3f), new Vector3(num3 + (float)i, 0f, num2 + 3f), Color.Black);
				}
			}
			for (int j = -3; j <= 3; j++)
			{
				if (j != 0)
				{
					this.LineSet.AddSegment(new Vector3(num - 3f, 0f, num4 + 0.7f * (float)j), new Vector3(num + 3f, 0f, num4 + 0.7f * (float)j), Color.LightGray);
					this.LineSet.AddSegment(new Vector3(num3 + 0.7f * (float)j, 0f, num2 - 3f), new Vector3(num3 + 0.7f * (float)j, 0f, num2 + 3f), Color.LightGray);
				}
			}
			this.LineSet.AddSegment(new Vector3(num3, 0f, num4), new Vector3(num3 + 1f, 0f, num4), Color.Red);
			this.LineSet.AddSegment(new Vector3(num3, 0f, num4), new Vector3(num3, 1f, num4), Color.Green);
			this.LineSet.AddSegment(new Vector3(num3, 0f, num4), new Vector3(num3, 0f, num4 + 1f), Color.Blue);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00008091 File Offset: 0x00007091
		public void HideBackgroundScene(ulong objectID)
		{
			this.mScene.RemoveObject(objectID);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000080A0 File Offset: 0x000070A0
		protected bool ComputeScreenCoords(Vector3 pointWorld, out float sx, out float sy)
		{
			Camera mainCamera = this.Scene.MainCamera;
			Matrix44 worldProjection = mainCamera.WorldProjection;
			GfxDevice.RectInt viewport = GfxDevice.GetViewport();
			Vector3 vector = worldProjection.TransformVector(pointWorld) + worldProjection.pos.ToVector3();
			float num = pointWorld.x * worldProjection.right.w + pointWorld.y * worldProjection.up.w + pointWorld.z * worldProjection.at.w + worldProjection.pos.w;
			float num2 = vector.x / num;
			float num3 = vector.y / num;
			float num4 = vector.z / num;
			if (mainCamera.NearClip <= num4 && num4 < mainCamera.FarClip && -1f <= num2 && num2 <= 1f && -1f <= num3 && num3 <= 1f)
			{
				sx = 0.5f * (1f + num2) * (float)(viewport.right - viewport.left);
				sy = (1f - 0.5f * (1f + num3)) * (float)(viewport.bottom - viewport.top);
				return true;
			}
			sx = 0f;
			sy = 0f;
			return false;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x000081E4 File Offset: 0x000071E4
		private void UseBackgroundForProbe_Update(object sender, EventArgs e)
		{
			MenuCommand menuCommand = sender as MenuCommand;
			if (menuCommand != null)
			{
				menuCommand.Checked = this.mUseBackgroundObjectsForProbe;
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00008207 File Offset: 0x00007207
		private void DrawGuide_Click(object sender, EventArgs e)
		{
			this.DrawGuides = !this.DrawGuides;
			base.Invalidate();
			if (this.DrawGuidesClick != null)
			{
				this.DrawGuidesClick(sender, e);
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00008233 File Offset: 0x00007233
		private void DrawGuide_Update(object sender, EventArgs e)
		{
			if (this.DrawGuidesUpdate != null)
			{
				this.DrawGuidesUpdate(sender, e);
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000824A File Offset: 0x0000724A
		private void Wireframe_Click(object sender, EventArgs e)
		{
			this.Wireframe = !this.Wireframe;
			base.Invalidate();
			if (this.WireframeClick != null)
			{
				this.WireframeClick(sender, e);
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00008276 File Offset: 0x00007276
		private void Wireframe_Update(object sender, EventArgs e)
		{
			if (this.WireframeUpdate != null)
			{
				this.WireframeUpdate(sender, e);
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000828D File Offset: 0x0000728D
		private void OccludersVisible_Click(object sender, EventArgs e)
		{
			this.OccludersVisible = !this.OccludersVisible;
			base.Invalidate();
			if (this.OccludersVisibleClick != null)
			{
				this.OccludersVisibleClick(sender, e);
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000082B9 File Offset: 0x000072B9
		private void OccludersVisible_Update(object sender, EventArgs e)
		{
			if (this.OccludersVisibleUpdate != null)
			{
				this.OccludersVisibleUpdate(sender, e);
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000082D0 File Offset: 0x000072D0
		private void DropShadows_Click(object sender, EventArgs e)
		{
			this.DropShadows = !this.DropShadows;
			base.Invalidate();
			if (this.DropShadowsClick != null)
			{
				this.DropShadowsClick(sender, e);
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000082FC File Offset: 0x000072FC
		private void DropShadows_Update(object sender, EventArgs e)
		{
			if (this.DropShadowsUpdate != null)
			{
				this.DropShadowsUpdate(sender, e);
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00008313 File Offset: 0x00007313
		private void DisplaySlot_Click(object sender, EventArgs e)
		{
			this.DisplaySlot = !this.DisplaySlot;
			base.Invalidate();
			if (this.DisplaySlotClick != null)
			{
				this.DisplaySlotClick(sender, e);
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000833F File Offset: 0x0000733F
		private void DisplaySlot_Update(object sender, EventArgs e)
		{
			if (this.DisplaySlotUpdate != null)
			{
				this.DisplaySlotUpdate(sender, e);
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00008356 File Offset: 0x00007356
		private void DisplayRig_Click(object sender, EventArgs e)
		{
			this.DisplayRig = !this.DisplayRig;
			base.Invalidate();
			if (this.DisplayRigClick != null)
			{
				this.DisplayRigClick(sender, e);
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00008382 File Offset: 0x00007382
		private void DisplayRig_Update(object sender, EventArgs e)
		{
			if (this.DisplayRigUpdate != null)
			{
				this.DisplayRigUpdate(sender, e);
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00008399 File Offset: 0x00007399
		private void BoundingBoxes_Click(object sender, EventArgs e)
		{
			this.BBoxes = !this.BBoxes;
			base.Invalidate();
			if (this.BoundingBoxesClick != null)
			{
				this.BoundingBoxesClick(sender, e);
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000083C5 File Offset: 0x000073C5
		private void CustomBoundingBoxes_Click(object sender, EventArgs e)
		{
			this.CustomBBoxes = !this.CustomBBoxes;
			base.Invalidate();
			if (this.CustomBoundingBoxesClick != null)
			{
				this.CustomBoundingBoxesClick(sender, e);
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000083F1 File Offset: 0x000073F1
		private void BoundingBoxes_Update(object sender, EventArgs e)
		{
			if (this.BoundingBoxesUpdate != null)
			{
				this.BoundingBoxesUpdate(sender, e);
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00008408 File Offset: 0x00007408
		private void CustomBoundingBoxes_Update(object sender, EventArgs e)
		{
			if (this.CustomBoundingBoxesUpdate != null)
			{
				this.CustomBoundingBoxesUpdate(sender, e);
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000841F File Offset: 0x0000741F
		private void BackfaceCulling_Click(object sender, EventArgs e)
		{
			this.Backface = !this.Backface;
			base.Invalidate();
			if (this.BackfaceCullingClick != null)
			{
				this.BackfaceCullingClick(sender, e);
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000844B File Offset: 0x0000744B
		private void TextureLiveUpdate_Click(object sender, EventArgs e)
		{
			this.TextureLive = !this.TextureLive;
			base.Invalidate();
			if (this.TextureLiveUpdateClick != null)
			{
				this.TextureLiveUpdateClick(sender, e);
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00008477 File Offset: 0x00007477
		private void ForceRender_Click(object sender, EventArgs e)
		{
			this.ForceRender = !this.ForceRender;
			base.Invalidate();
			if (this.ForceRenderClick != null)
			{
				this.ForceRenderClick(sender, e);
			}
		}

		// Token: 0x06000145 RID: 325 RVA: 0x000084A3 File Offset: 0x000074A3
		private void BackfaceCulling_Update(object sender, EventArgs e)
		{
			if (this.BackfaceCullingUpdate != null)
			{
				this.BackfaceCullingUpdate(sender, e);
			}
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000084BA File Offset: 0x000074BA
		private void ForceRender_Update(object sender, EventArgs e)
		{
			if (this.ForceRenderUpdate != null)
			{
				this.ForceRenderUpdate(sender, e);
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000084D1 File Offset: 0x000074D1
		private void TextureLiveUpdate_Update(object sender, EventArgs e)
		{
			if (this.TextureLiveUpdate != null)
			{
				this.TextureLiveUpdate(sender, e);
			}
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000084E8 File Offset: 0x000074E8
		private void CenterAroundOrigin_Click(object sender, EventArgs e)
		{
			this.AutoCenter = false;
			base.Pan = Vector3.gZero;
			base.SceneCOI = Vector3.gZero;
			base.Invalidate();
			if (this.CenterAroundOriginClick != null)
			{
				this.CenterAroundOriginClick(sender, e);
			}
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00008522 File Offset: 0x00007522
		private void CenterAroundOrigin_Update(object sender, EventArgs e)
		{
			if (this.CenterAroundOriginUpdate != null)
			{
				this.CenterAroundOriginUpdate(sender, e);
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00008539 File Offset: 0x00007539
		private void CenterOnBBox_Click(object sender, EventArgs e)
		{
			this.AutoCenter = true;
			base.SetSceneCOIFromBBox();
			base.Invalidate();
			if (this.CenterOnBoundingBoxClick != null)
			{
				this.CenterOnBoundingBoxClick(sender, e);
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00008563 File Offset: 0x00007563
		private void CenterOnBBox_Update(object sender, EventArgs e)
		{
			if (this.CenterOnBoundingBoxUpdate != null)
			{
				this.CenterOnBoundingBoxUpdate(sender, e);
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000857A File Offset: 0x0000757A
		private void AutoZoomCamera_Click(object sender, EventArgs e)
		{
			this.AutoZoom = !this.AutoZoom;
			base.SetZoomFromBBox();
			base.Invalidate();
			if (this.AutoZoomCameraClick != null)
			{
				this.AutoZoomCameraClick(sender, e);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000085AC File Offset: 0x000075AC
		private void AutoZoomCamera_Update(object sender, EventArgs e)
		{
			if (this.AutoZoomCameraUpdate != null)
			{
				this.AutoZoomCameraUpdate(sender, e);
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000085C4 File Offset: 0x000075C4
		private void ResetCamera_Click(object sender, EventArgs e)
		{
			base.Truck = CameraPanel.kDefaultTruck;
			base.EulerRotation = Vector3.gZero;
			base.Pan = Vector3.gZero;
			base.SceneCOI = new Vector3(0f, 0.5f, 0f);
			base.Invalidate();
			if (this.ResetCameraClick != null)
			{
				this.ResetCameraClick(sender, e);
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00008627 File Offset: 0x00007627
		private void LightGray_Click(object sender, EventArgs e)
		{
			base.DefaultBackColor = Color.LightGray;
			base.Invalidate();
			if (this.LightGrayClick != null)
			{
				this.LightGrayClick(sender, e);
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000864F File Offset: 0x0000764F
		private void LightGray_Update(object sender, EventArgs e)
		{
			if (this.LightGrayUpdate != null)
			{
				this.LightGrayUpdate(sender, e);
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00008666 File Offset: 0x00007666
		private void DarkGray_Click(object sender, EventArgs e)
		{
			base.DefaultBackColor = Color.DarkGray;
			base.Invalidate();
			if (this.DarkGrayClick != null)
			{
				this.DarkGrayClick(sender, e);
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000868E File Offset: 0x0000768E
		private void DarkGray_Update(object sender, EventArgs e)
		{
			if (this.DarkGrayUpdate != null)
			{
				this.DarkGrayUpdate(sender, e);
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000086A5 File Offset: 0x000076A5
		private void ForestGreen_Click(object sender, EventArgs e)
		{
			base.DefaultBackColor = Color.ForestGreen;
			base.Invalidate();
			if (this.ForestGreenClick != null)
			{
				this.ForestGreenClick(sender, e);
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000086CD File Offset: 0x000076CD
		private void ForestGreen_Update(object sender, EventArgs e)
		{
			if (this.ForestGreenUpdate != null)
			{
				this.ForestGreenUpdate(sender, e);
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000086E4 File Offset: 0x000076E4
		private void LightBlue_Click(object sender, EventArgs e)
		{
			base.DefaultBackColor = Color.LightBlue;
			base.Invalidate();
			if (this.LightBlueClick != null)
			{
				this.LightBlueClick(sender, e);
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000870C File Offset: 0x0000770C
		private void LightBlue_Update(object sender, EventArgs e)
		{
			if (this.LightBlueUpdate != null)
			{
				this.LightBlueUpdate(sender, e);
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00008723 File Offset: 0x00007723
		private void SetBackgroundColor_Click(object sender, EventArgs e)
		{
			if (this.SetBackgroundColorClick != null)
			{
				this.SetBackgroundColorClick(sender, e);
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000873A File Offset: 0x0000773A
		private void TurntableLighting_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000873C File Offset: 0x0000773C
		public void DisplayBackground(bool bDisplay)
		{
			if (bDisplay)
			{
				this.ShowBackgroundScene();
				return;
			}
			this.HideBackgroundScene();
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00008750 File Offset: 0x00007750
		private void ShowBackgroundScene()
		{
			if (this.mActiveBackgroundObject == null)
			{
				return;
			}
			this.mBackgroundSceneEnabled = true;
			Vector3 absolutePosition = new Vector3(0f, 0f, 0f);
			Matrix44 absoluteTransform = default(Matrix44);
			absoluteTransform.SetIdentity();
			this.mActiveBackgroundObject.TransformComponent.AbsoluteTransform = absoluteTransform;
			this.mActiveBackgroundObject.TransformComponent.AbsolutePosition = absolutePosition;
			this.mScene.AddObject(this.mActiveBackgroundObject.ObjectId);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000087CA File Offset: 0x000077CA
		private void HideBackgroundScene()
		{
			this.mBackgroundSceneEnabled = false;
			if (this.mActiveBackgroundObject != null)
			{
				this.mScene.RemoveObject(this.mActiveBackgroundObject.ObjectId);
			}
		}

		// Token: 0x0600015C RID: 348 RVA: 0x000087F1 File Offset: 0x000077F1
		private void VisualizerMode_Click(object sender, EventArgs args)
		{
			if (this.ShaderVisualizerModeClick != null)
			{
				this.ShaderVisualizerModeClick(sender, args);
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00008808 File Offset: 0x00007808
		private void VisualizerMode_Update(object sender, EventArgs args)
		{
			if (this.ShaderVisualizerModeUpdate != null)
			{
				this.ShaderVisualizerModeUpdate(sender, args);
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000881F File Offset: 0x0000781F
		public void ShowSunlightCursor_Click(object sender, EventArgs e)
		{
			this.LightVisible = !this.LightVisible;
			base.Invalidate();
			if (this.ShowSunlightCursorClick != null)
			{
				this.ShowSunlightCursorClick(sender, e);
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000884B File Offset: 0x0000784B
		private void ShowSunlightCursor_Update(object sender, EventArgs e)
		{
			if (this.ShowSunlightCursorUpdate != null)
			{
				this.ShowSunlightCursorUpdate(sender, e);
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00008862 File Offset: 0x00007862
		public void DrawShadows_Click(object sender, EventArgs e)
		{
			this.mScene.SetShadowsEnabled(!this.mScene.GetShadowsEnabled());
			base.Invalidate();
			if (this.DrawShadowsClick != null)
			{
				this.DrawShadowsClick(sender, e);
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00008898 File Offset: 0x00007898
		private void DrawShadows_Update(object sender, EventArgs e)
		{
			if (this.DrawShadowsUpdate != null)
			{
				this.DrawShadowsUpdate(sender, e);
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x000088AF File Offset: 0x000078AF
		public void SetSunlightColor_Click(object sender, EventArgs e)
		{
			if (this.SetSunlightColorClick != null)
			{
				this.SetSunlightColorClick(sender, e);
			}
			base.Invalidate();
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000088CC File Offset: 0x000078CC
		public void ResetSunlight_Click(object sender, EventArgs e)
		{
			this.LightCOI = new Vector3(0f, 0f, 0f);
			this.LightPitch = 0f;
			this.LightYaw = 0f;
			this.LightColor = Color.FromArgb(255, 255, 255);
			this.mScene.SetShadowsEnabled(true);
			base.Invalidate();
			if (this.ResetSunlightClick != null)
			{
				this.ResetSunlightClick(sender, e);
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000894A File Offset: 0x0000794A
		private void DisplayFXStats_Click(object sender, EventArgs e)
		{
			this.DisplayFXStats = !this.DisplayFXStats;
			if (this.DisplayFXStats)
			{
				this.ForceRender = true;
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000896A File Offset: 0x0000796A
		private void DisplayFXStats_Update(object sender, EventArgs e)
		{
			if (this.DisplayFXStatsUpdate != null)
			{
				this.DisplayFXStatsUpdate(sender, e);
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00008981 File Offset: 0x00007981
		private void DisplayRenderingStats_Click(object sender, EventArgs e)
		{
			this.DisplayRenderingStats = !this.DisplayRenderingStats;
			if (this.DisplayRenderingStats)
			{
				this.ForceRender = true;
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x000089A1 File Offset: 0x000079A1
		private void DisplayRenderingStats_Update(object sender, EventArgs e)
		{
			if (this.DisplayRenderingStatsUpdate != null)
			{
				this.DisplayRenderingStatsUpdate(sender, e);
			}
		}

		// Token: 0x040000A4 RID: 164
		private LineSet mLineSet;

		// Token: 0x040000A5 RID: 165
		private bool mDrawGuides = true;

		// Token: 0x040000A6 RID: 166
		private bool mDisplaySlot;

		// Token: 0x040000A7 RID: 167
		private bool mDisplayRig;

		// Token: 0x040000A8 RID: 168
		private bool mDisplayFXStats;

		// Token: 0x040000A9 RID: 169
		private bool mDisplayRenderingStats;

		// Token: 0x040000AA RID: 170
		private bool mTextureLive;

		// Token: 0x040000AB RID: 171
		private float mLightPitch;

		// Token: 0x040000AC RID: 172
		private float mLightYaw;

		// Token: 0x040000AD RID: 173
		private float mTurntableYaw;

		// Token: 0x040000AE RID: 174
		private GameObject mLightObject;

		// Token: 0x040000AF RID: 175
		private GameObject mGameObject;

		// Token: 0x040000B0 RID: 176
		private Vector3 mLightCOI = new Vector3(0f, 0f, 0f);

		// Token: 0x040000B1 RID: 177
		private bool mLightVisible;

		// Token: 0x040000B2 RID: 178
		private Color mLightColor = Color.FromArgb(255, 255, 255);

		// Token: 0x040000B3 RID: 179
		private bool mBackgroundSceneEnabled;

		// Token: 0x040000B4 RID: 180
		private LightRigType mActiveBackground = LightRigType.kNone;

		// Token: 0x040000B5 RID: 181
		private bool mUseBackgroundObjectsForProbe;

		// Token: 0x040000B6 RID: 182
		private GameObject mActiveBackgroundObject;

		// Token: 0x040000B7 RID: 183
		protected static readonly string kMenuName = "&Render Panel";

		// Token: 0x040000B8 RID: 184
		private static readonly float kJointRadius = 0.03f;
	}
}
