using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using Sims3;
using Sims3.CSHost;
using Sims3.CSHost.Animation;
using Sims3.Serialization;
using Sims3.SimIFace.CAS;

namespace SACS
{
	// Token: 0x0200000B RID: 11
	public class SacsTrackMask : TrackMask
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00003B64 File Offset: 0x00002B64
		public static Log Log
		{
			get
			{
				return AssetDatabase.Log;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000079 RID: 121 RVA: 0x00003B6B File Offset: 0x00002B6B
		// (remove) Token: 0x0600007A RID: 122 RVA: 0x00003B84 File Offset: 0x00002B84
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x0600007B RID: 123 RVA: 0x00003B9D File Offset: 0x00002B9D
		public SacsTrackMask()
		{
			this.Name = "Identity Mask";
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003BCA File Offset: 0x00002BCA
		public SacsTrackMask(Rig rig) : base(rig)
		{
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003BED File Offset: 0x00002BED
		public SacsTrackMask(int count) : base(count)
		{
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003C10 File Offset: 0x00002C10
		public SacsTrackMask(int count, string rigName, ResourceKey rigKey) : base(count)
		{
			this.mNameOfNonLoadedRig = rigName;
			base.KeyForNonLoadedRig = rigKey;
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00003C41 File Offset: 0x00002C41
		public int Count
		{
			get
			{
				return this.mBoneCount;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00003C49 File Offset: 0x00002C49
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00003C54 File Offset: 0x00002C54
		public new string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				string name = base.Name;
				base.Name = value;
				if (name != base.Name && this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
				}
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00003C9B File Offset: 0x00002C9B
		public string RigName
		{
			get
			{
				if (base.Rig != null)
				{
					return AssetDatabase.GetAssetName(base.Rig.Key);
				}
				if (this.mNameOfNonLoadedRig != null)
				{
					return this.mNameOfNonLoadedRig;
				}
				return AssetDatabase.UnknownName;
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003CCA File Offset: 0x00002CCA
		public override string ToString()
		{
			return this.RigName + ":" + this.Name;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003CE4 File Offset: 0x00002CE4
		public XmlElement SaveToXml(XmlDocument doc)
		{
			XmlElement xmlElement = doc.CreateElement("trackmask");
			xmlElement.SetAttribute("formatversion", "" + SacsTrackMask.kFormatVersion);
			xmlElement.SetAttribute("count", "" + this.Count);
			xmlElement.SetAttribute("name", "" + this.Name);
			xmlElement.SetAttribute("id", "" + base.ExternalKeyInstance);
			xmlElement.SetAttribute("externalIndices", this.IsHumanOrPetSim.ToString());
			if (base.Rig != null)
			{
				Rig rig = new Rig(base.Rig.Key);
				XmlElement xmlElement2 = doc.CreateElement("rig");
				rig.SaveToXml(doc, new SimpleRegistry(), xmlElement2);
				xmlElement.AppendChild(xmlElement2);
			}
			for (int i = 0; i < this.Count; i++)
			{
				float boneWeight = base.GetBoneWeight(i);
				if (boneWeight != 1f)
				{
					XmlElement xmlElement3 = doc.CreateElement("bone");
					xmlElement3.SetAttribute("index", "" + i);
					if (base.Rig != null)
					{
						xmlElement3.SetAttribute("name", "" + base.Rig.JointNames[i]);
					}
					xmlElement3.SetAttribute("weight", "" + boneWeight);
					xmlElement.AppendChild(xmlElement3);
				}
			}
			if (this.IsHumanOrPetSim)
			{
				TrackMaskBoneMappingsConfig boneMappingsConfig = this.BoneMappingsConfig;
				foreach (string text in boneMappingsConfig.BoneGroupNames)
				{
					bool flag = true;
					float num = -1f;
					string[] bones = boneMappingsConfig.GetBones(text);
					foreach (string name in bones)
					{
						int idForName = base.Rig.GetIdForName(name);
						if (idForName != -1)
						{
							float boneWeight2 = base.GetBoneWeight(idForName);
							if (num != boneWeight2)
							{
								if (num >= 0f)
								{
									flag = false;
									break;
								}
								num = boneWeight2;
							}
						}
					}
					if (flag)
					{
						XmlElement xmlElement4 = doc.CreateElement("group");
						xmlElement4.SetAttribute("name", text);
						xmlElement4.SetAttribute("weight", "" + num);
						xmlElement.AppendChild(xmlElement4);
					}
				}
			}
			return xmlElement;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003F60 File Offset: 0x00002F60
		public static SacsTrackMask LoadFromXml(XmlElement node)
		{
			SacsTrackMask sacsTrackMask = null;
			string text = null;
			Utils.Parse(node, "name", ref text);
			decimal d = 0m;
			Utils.Parse<decimal>(node, "formatversion", ref d);
			bool flag = d < SacsTrackMask.kFormatVersion;
			if (flag)
			{
				SacsTrackMask.Log.Debug("SacsTrackMask", "{0}: This mask is saved in an older format.  Some features may be unavailable.", new object[]
				{
					text
				});
			}
			ResourceKey key = new ResourceKey(0U, 0U, 0UL);
			string rigName = null;
			XmlNode xmlNode = (node != null) ? node.SelectSingleNode("rig") : null;
			if (xmlNode != null)
			{
				Utils.Parse(xmlNode, "name", ref rigName);
				Asset asset = new Asset();
				asset.LoadFromXml(node.OwnerDocument, new SimpleRegistry(), xmlNode);
				key = asset.Key;
				if (AssetDatabase.AssetsAreAvailable)
				{
					Rig rig = new Rig(asset.Key);
					if (rig.IsValid)
					{
						sacsTrackMask = new SacsTrackMask(rig);
					}
					else
					{
						SacsTrackMask.Log.Warn("SacsTrackMask", "{0}: Couldn't find the rig this mask was built on.", new object[]
						{
							text
						});
					}
				}
			}
			if (sacsTrackMask == null)
			{
				int count = 0;
				if (!Utils.Parse<int>(node, "count", ref count))
				{
					SacsTrackMask.Log.Error("SacsTrackMask", "{0}: Mask is missing bone count and will be discarded.", new object[]
					{
						text
					});
					return null;
				}
				sacsTrackMask = new SacsTrackMask(count, rigName, key);
			}
			if (text != null)
			{
				sacsTrackMask.Name = text;
			}
			bool rigAvailable = sacsTrackMask.Rig != null && sacsTrackMask.Rig.IsValid;
			bool flag2 = false;
			Utils.Parse<bool>(node, "externalIndices", ref flag2);
			List<string> list = new List<string>();
			TrackMaskBoneMappingsConfig boneMappingsConfig = sacsTrackMask.BoneMappingsConfig;
			foreach (object obj in node)
			{
				XmlElement xmlElement = (XmlElement)obj;
				if (xmlElement != null && xmlElement.Name == "group")
				{
					float num = 0f;
					Utils.Parse<float>(xmlElement, "weight", ref num);
					string attribute = xmlElement.GetAttribute("name");
					string[] bones = boneMappingsConfig.GetBones(attribute);
					foreach (string text2 in bones)
					{
						int boneIdForName = SacsTrackMask.GetBoneIdForName(sacsTrackMask, rigAvailable, attribute, text2);
						if (boneIdForName != -1)
						{
							sacsTrackMask.SetBoneWeight(boneIdForName, num);
							list.Add(text2);
						}
						else if (text2 == TrackMaskBoneMappingsConfig.FakeBoneNameForPetFacialExpressions)
						{
							sacsTrackMask.SetVertexAnimBlendWeight(num);
							list.Add(text2);
						}
						else
						{
							SacsTrackMask.Log.Error("SacsTrackMask", attribute + ": " + text2 + " : couldn't find bone.", new object[0]);
						}
					}
				}
			}
			if (d <= 1.2m && flag2)
			{
				SacsTrackMask.Log.Warn("SacsTrackMask", "Track mask \"{0}\" needs to be opened and re-saved to automatically track rig changes.", new object[]
				{
					text
				});
			}
			foreach (object obj2 in node)
			{
				XmlElement xmlElement2 = (XmlElement)obj2;
				if (xmlElement2 != null && xmlElement2.Name == "bone")
				{
					string attribute2 = xmlElement2.GetAttribute("name");
					if (!list.Contains(attribute2))
					{
						float num2 = 1f;
						Utils.Parse<float>(xmlElement2, "weight", ref num2);
						if (!flag2)
						{
							int boneIndex = -1;
							if (Utils.Parse<int>(xmlElement2, "index", ref boneIndex))
							{
								sacsTrackMask.SetBoneWeight(boneIndex, num2);
							}
						}
						else if (d > 1.2m)
						{
							int boneIdForName2 = SacsTrackMask.GetBoneIdForName(sacsTrackMask, rigAvailable, "", attribute2);
							if (boneIdForName2 != -1)
							{
								sacsTrackMask.SetBoneWeight(boneIdForName2, num2);
							}
							else if (attribute2 == TrackMaskBoneMappingsConfig.FakeBoneNameForPetFacialExpressions)
							{
								sacsTrackMask.SetVertexAnimBlendWeight(num2);
							}
						}
						else
						{
							string groupNameForBone = boneMappingsConfig.GetGroupNameForBone(attribute2);
							foreach (string text3 in boneMappingsConfig.GetBones(groupNameForBone))
							{
								int boneIdForName3 = SacsTrackMask.GetBoneIdForName(sacsTrackMask, rigAvailable, groupNameForBone, text3);
								if (boneIdForName3 != -1)
								{
									sacsTrackMask.SetBoneWeight(boneIdForName3, num2);
								}
								else if (text3 == TrackMaskBoneMappingsConfig.FakeBoneNameForPetFacialExpressions)
								{
									sacsTrackMask.SetVertexAnimBlendWeight(num2);
								}
							}
						}
					}
				}
			}
			TrackMask.CacheTrackMask(sacsTrackMask);
			return sacsTrackMask;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000043EC File Offset: 0x000033EC
		private static int GetBoneIdForName(SacsTrackMask result, bool rigAvailable, string groupName, string boneName)
		{
			int num = -1;
			if (SacsTrackMask.CheckRigMappingFile && rigAvailable)
			{
				num = result.Rig.GetIdForName(boneName);
				if (!SacsTrackMask.sBoneMappingWarningGiven && groupName != null && groupName != "")
				{
					int boneIndex = result.BoneMappingsConfig.GetBoneIndex(boneName);
					if ((num != -1 || boneIndex != -1) && num != boneIndex)
					{
						SacsTrackMask.Log.Warn("SacsTrackMask", string.Concat(new string[]
						{
							"The track mask bone mapping file doesn't match the rig.  Contact Art Help for assistance. (",
							groupName,
							"/",
							boneName,
							" is the first mismatch.  Further errors will not be reported.)"
						}), new object[0]);
						SacsTrackMask.sBoneMappingWarningGiven = true;
					}
				}
			}
			if (num == -1)
			{
				num = result.BoneMappingsConfig.GetBoneIndex(boneName);
			}
			return num;
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000087 RID: 135 RVA: 0x000044A2 File Offset: 0x000034A2
		public bool IsHumanSim
		{
			get
			{
				return this.SimSpecies == Sims3.SimIFace.CAS.CASAgeGenderFlags.Human;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000088 RID: 136 RVA: 0x000044B1 File Offset: 0x000034B1
		public bool IsHumanOrPetSim
		{
			get
			{
				return this.SimSpecies != Sims3.SimIFace.CAS.CASAgeGenderFlags.None && this.SimSpecies != Sims3.SimIFace.CAS.CASAgeGenderFlags.SpeciesMask;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000089 RID: 137 RVA: 0x000044CD File Offset: 0x000034CD
		public bool IsPetSim
		{
			get
			{
				return this.IsHumanOrPetSim && !this.IsHumanSim;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000044E2 File Offset: 0x000034E2
		public TrackMaskBoneMappingsConfig BoneMappingsConfig
		{
			get
			{
				if (!this.IsHumanSim && this.IsHumanOrPetSim)
				{
					return TrackMaskBoneMappingsConfig.Pet;
				}
				return TrackMaskBoneMappingsConfig.Sim;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000044FF File Offset: 0x000034FF
		public Sims3.SimIFace.CAS.CASAgeGenderFlags SimSpecies
		{
			get
			{
				if (this.mbSpeciesAgeGenderDirty)
				{
					this.UpdateSimSpeciesAgeAndGender();
				}
				return this.mSimSpecies;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00004515 File Offset: 0x00003515
		public Sims3.SimIFace.CAS.CASAgeGenderFlags SimAge
		{
			get
			{
				if (this.mbSpeciesAgeGenderDirty)
				{
					this.UpdateSimSpeciesAgeAndGender();
				}
				return this.mSimAge;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600008D RID: 141 RVA: 0x0000452B File Offset: 0x0000352B
		public Sims3.SimIFace.CAS.CASAgeGenderFlags SimGender
		{
			get
			{
				if (this.mbSpeciesAgeGenderDirty)
				{
					this.UpdateSimSpeciesAgeAndGender();
				}
				return this.mSimGender;
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004544 File Offset: 0x00003544
		private void UpdateSimSpeciesAgeAndGender()
		{
			this.mbSpeciesAgeGenderDirty = false;
			this.mSimSpecies = Sims3.SimIFace.CAS.CASAgeGenderFlags.None;
			this.mSimAge = Sims3.SimIFace.CAS.CASAgeGenderFlags.AgeMask;
			this.mSimGender = Sims3.SimIFace.CAS.CASAgeGenderFlags.GenderMask;
			if (!base.HasRig)
			{
				if (this.mNameOfNonLoadedRig != null)
				{
					Sims3.SimIFace.CAS.CASUtils.CalculateAgeGenderSpeciesFromAssetName(this.mNameOfNonLoadedRig, out this.mSimAge, out this.mSimGender, out this.mSimSpecies, false);
					if (!this.IsHumanOrPetSim)
					{
						this.mSimSpecies = Sims3.SimIFace.CAS.CASAgeGenderFlags.Human;
					}
				}
				return;
			}
			bool flag = false;
			for (int i = 0; i < this.mBoneCount; i++)
			{
				if (base.Rig.JointNames[i].ToLower() == "b__l_pinky2__")
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				Sims3.SimIFace.CAS.CASUtils.CalculateAgeGenderSpeciesFromAssetName(base.Rig.SkeletonName, out this.mSimAge, out this.mSimGender, out this.mSimSpecies, false);
				if (!this.IsHumanOrPetSim)
				{
					this.mSimSpecies = Sims3.SimIFace.CAS.CASAgeGenderFlags.Human;
				}
			}
		}

		// Token: 0x0400001A RID: 26
		private const string kLogCategory = "SacsTrackMask";

		// Token: 0x0400001C RID: 28
		private string mNameOfNonLoadedRig;

		// Token: 0x0400001D RID: 29
		private static readonly decimal kFormatVersion = 1.3m;

		// Token: 0x0400001E RID: 30
		public static bool CheckRigMappingFile = false;

		// Token: 0x0400001F RID: 31
		private static bool sBoneMappingWarningGiven = false;

		// Token: 0x04000020 RID: 32
		private bool mbSpeciesAgeGenderDirty = true;

		// Token: 0x04000021 RID: 33
		private Sims3.SimIFace.CAS.CASAgeGenderFlags mSimSpecies;

		// Token: 0x04000022 RID: 34
		private Sims3.SimIFace.CAS.CASAgeGenderFlags mSimAge = Sims3.SimIFace.CAS.CASAgeGenderFlags.AgeMask;

		// Token: 0x04000023 RID: 35
		private Sims3.SimIFace.CAS.CASAgeGenderFlags mSimGender = Sims3.SimIFace.CAS.CASAgeGenderFlags.GenderMask;
	}
}
