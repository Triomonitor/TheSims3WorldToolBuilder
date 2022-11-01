using System;
using Sims3.CSHost;
using Sims3.CSHost.Animation;
using Sims3.SimIFace;

namespace SACS
{
	// Token: 0x02000009 RID: 9
	public class Motion : Asset
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000054 RID: 84 RVA: 0x0000363A File Offset: 0x0000263A
		public override uint Type
		{
			get
			{
				return 1797309683U;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00003641 File Offset: 0x00002641
		public string SourceFile
		{
			get
			{
				return AnimationComponent.GetSourceFileName(this.Key);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000056 RID: 86 RVA: 0x0000364E File Offset: 0x0000264E
		public string Namespace
		{
			get
			{
				return AnimationComponent.GetNamespace(this.Key);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000057 RID: 87 RVA: 0x0000365C File Offset: 0x0000265C
		public bool IsSocial
		{
			get
			{
				string name = this.Name;
				int length = name.Length;
				if (name == null || length < 6)
				{
					return false;
				}
				switch (name.IndexOf('_'))
				{
				case 0:
				case 1:
				case 2:
					return false;
				case 3:
					return name[1] == '2' && name[2] != 'o';
				case 4:
					return name[1] == '2' || (name[2] == '2' && name[3] != 'o');
				case 5:
					return name[2] == '2';
				default:
					return false;
				}
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00003700 File Offset: 0x00002700
		public bool IsObjectOnly
		{
			get
			{
				string name = this.Name;
				return name != null && name.Length >= 3 && name[0] == 'o' && name[1] == '_';
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000373A File Offset: 0x0000273A
		public Motion()
		{
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003742 File Offset: 0x00002742
		public Motion(Sims3.CSHost.ResourceKey key) : base(key)
		{
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000374B File Offset: 0x0000274B
		public Motion(string name) : base(name)
		{
			this.m_key.mInstance = Manager.GetInstanceIdForClipName(name);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003765 File Offset: 0x00002765
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000376D File Offset: 0x0000276D
		public void AddMotionNow(GameObject gameObject, AnimationPriority track, float blendDuration)
		{
			this.AddMotionNow(gameObject, track, blendDuration, 0U);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003779 File Offset: 0x00002779
		public void AddMotionNow(GameObject gameObject, AnimationPriority track, float blendDuration, uint userData)
		{
			this.AddMotionNow(gameObject, track, blendDuration, userData, false, false);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003788 File Offset: 0x00002788
		public void AddMotionNowWithIK(GameObject gameObject, AnimationPriority track, float blendDuration, uint userData)
		{
			this.AddMotionNow(gameObject, track, blendDuration, userData, false, true);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003797 File Offset: 0x00002797
		public void AddMotionNowMirror(GameObject gameObject, AnimationPriority track, float blendDuration, uint userData, bool bIK)
		{
			this.AddMotionNow(gameObject, track, blendDuration, userData, true, bIK);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000037A7 File Offset: 0x000027A7
		private void AddMotionNow(GameObject gameObject, AnimationPriority track, float blendDuration, uint userData, bool bMirror, bool bIK)
		{
			if (this.Exists)
			{
				gameObject.AnimationComponent.PlayAnimationNow(this.m_key, (uint)track, blendDuration, bMirror, bIK);
				return;
			}
			if (Motion.MissingAnimation.Exists)
			{
				Motion.MissingAnimation.AddMotionNow(gameObject, track, blendDuration, userData);
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000037E4 File Offset: 0x000027E4
		public IkSetup AddMotionAtEnd(GameObject gameObject, AnimationPriority track, float blendDuration, uint userData)
		{
			if (gameObject.AnimationComponent != null)
			{
				if (this.Exists)
				{
					gameObject.AnimationComponent.PlayAnimationAtEnd(this.m_key, (uint)track, blendDuration, false, true);
				}
				else if (Motion.MissingAnimation.Exists)
				{
					return Motion.MissingAnimation.AddMotionAtEnd(gameObject, track, blendDuration, userData);
				}
			}
			return null;
		}

		// Token: 0x04000016 RID: 22
		public static readonly Motion MissingAnimation = new Motion("a_missingAnimation");
	}
}
