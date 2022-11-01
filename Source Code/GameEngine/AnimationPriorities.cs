using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Sims3;
using Sims3.SimIFace;

namespace SACS
{
	// Token: 0x0200000C RID: 12
	public static class AnimationPriorities
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00004646 File Offset: 0x00003646
		public static List<string> Labels
		{
			get
			{
				return AnimationPriorities.gAnimationPriorityLabels;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000464D File Offset: 0x0000364D
		public static Dictionary<string, AnimationPriority> LabelToEnumValue
		{
			get
			{
				return AnimationPriorities.gAnimationPriorityLabelToEnumValue;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00004654 File Offset: 0x00003654
		public static Dictionary<AnimationPriority, string> EnumValueToLabel
		{
			get
			{
				return AnimationPriorities.gAnimationPriorityEnumValueToLabel;
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000465C File Offset: 0x0000365C
		static AnimationPriorities()
		{
			foreach (object obj in Enum.GetValues(typeof(AnimationPriority)))
			{
				string text = Enum.GetName(typeof(AnimationPriority), obj);
				text = text.Replace("kAP", "");
				Regex regex = new Regex("(.)([A-Z])");
				text = regex.Replace(text, "$1 $2");
				AnimationPriorities.gAnimationPriorityLabels.Add(text);
				AnimationPriorities.gAnimationPriorityLabelToEnumValue[text] = (AnimationPriority)obj;
				AnimationPriorities.gAnimationPriorityEnumValueToLabel[(AnimationPriority)obj] = text;
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004750 File Offset: 0x00003750
		public static AnimationPriority Fixup(int pri)
		{
			if (pri >= 0 && pri < 1000)
			{
				if (pri == 0)
				{
					return AnimationPriority.kAPNormal;
				}
				if (pri <= 12)
				{
					return AnimationPriority.kAPHigh;
				}
				return AnimationPriority.kAPHighPlus;
			}
			else
			{
				if (Enum.IsDefined(typeof(AnimationPriority), pri))
				{
					return (AnimationPriority)pri;
				}
				Log.gWarn(AnimationPriorities.kLogCategory, "Unexpected priority value: " + pri, new object[0]);
				return AnimationPriority.kAPNormal;
			}
		}

		// Token: 0x04000024 RID: 36
		private static readonly string kLogCategory = "SocialControl";

		// Token: 0x04000025 RID: 37
		public static readonly string StateMachineDefaultPriorityLabel = "(state machine default)";

		// Token: 0x04000026 RID: 38
		private static List<string> gAnimationPriorityLabels = new List<string>();

		// Token: 0x04000027 RID: 39
		private static Dictionary<string, AnimationPriority> gAnimationPriorityLabelToEnumValue = new Dictionary<string, AnimationPriority>();

		// Token: 0x04000028 RID: 40
		private static Dictionary<AnimationPriority, string> gAnimationPriorityEnumValueToLabel = new Dictionary<AnimationPriority, string>();
	}
}
