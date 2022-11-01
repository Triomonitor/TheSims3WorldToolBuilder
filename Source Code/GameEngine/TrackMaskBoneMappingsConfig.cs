using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Sims3;

namespace SACS
{
	// Token: 0x02000002 RID: 2
	public class TrackMaskBoneMappingsConfig
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public bool IsInitialized
		{
			get
			{
				return this.mInitialized;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00001058
		public string ConfigFile
		{
			get
			{
				return this.mConfigFile;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002060 File Offset: 0x00001060
		public string[] BoneGroupNames
		{
			get
			{
				if (this.mInitialized)
				{
					string[] array = new string[this.mBoneMappings.Count];
					this.mBoneMappings.Keys.CopyTo(array, 0);
					return array;
				}
				return null;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000004 RID: 4 RVA: 0x0000209B File Offset: 0x0000109B
		public static string FakeBoneNameForPetFacialExpressions
		{
			get
			{
				return "PetFacialExpression";
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020A2 File Offset: 0x000010A2
		public bool Init(string filename)
		{
			this.mInitialized = false;
			if (File.Exists(filename))
			{
				this.mConfigFile = filename;
				if (!this.LoadConfig())
				{
					this.mInitialized = false;
				}
				this.mInitialized = true;
			}
			return this.mInitialized;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020D8 File Offset: 0x000010D8
		public string[] GetBones(string groupName)
		{
			string[] result;
			if (groupName != null && this.mBoneMappings.TryGetValue(groupName, out result))
			{
				return result;
			}
			return new string[0];
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002100 File Offset: 0x00001100
		public bool GetLabelLocation(string groupName, ref int xPos, ref int yPos)
		{
			if (this.mLabelLocations.ContainsKey(groupName))
			{
				xPos = this.mLabelLocations[groupName].mXPos;
				yPos = this.mLabelLocations[groupName].mYPos;
				return true;
			}
			return false;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002139 File Offset: 0x00001139
		public int GetBoneIndex(string boneName)
		{
			if (this.mBoneNameIndex.ContainsKey(boneName))
			{
				return this.mBoneNameIndex[boneName];
			}
			return -1;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002158 File Offset: 0x00001158
		public string GetGroupNameForBone(string boneName)
		{
			foreach (KeyValuePair<string, string[]> keyValuePair in this.mBoneMappings)
			{
				foreach (string b in keyValuePair.Value)
				{
					if (boneName == b)
					{
						return keyValuePair.Key;
					}
				}
			}
			return null;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000021DC File Offset: 0x000011DC
		public string[] GetGroupForBone(string boneName)
		{
			foreach (KeyValuePair<string, string[]> keyValuePair in this.mBoneMappings)
			{
				foreach (string b in keyValuePair.Value)
				{
					if (boneName == b)
					{
						return keyValuePair.Value;
					}
				}
			}
			return new string[0];
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002268 File Offset: 0x00001268
		public void SetBoneIndex(string boneName, int index)
		{
			this.mBoneNameIndex[boneName] = index;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002278 File Offset: 0x00001278
		private bool LoadConfig()
		{
			if (File.Exists(this.mConfigFile))
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(this.mConfigFile);
					XmlElement documentElement = xmlDocument.DocumentElement;
					XmlNodeList xmlNodeList = documentElement.SelectNodes("BoneGroup");
					foreach (object obj in xmlNodeList)
					{
						XmlElement xmlElement = (XmlElement)obj;
						string attribute = xmlElement.GetAttribute("name");
						if (!this.mBoneMappings.ContainsKey(attribute))
						{
							XmlNodeList xmlNodeList2 = xmlElement.SelectNodes("Bone");
							List<string> list = new List<string>();
							foreach (object obj2 in xmlNodeList2)
							{
								XmlElement xmlNode = (XmlElement)obj2;
								string empty = string.Empty;
								Utils.Parse(xmlNode, "name", ref empty);
								if (empty != string.Empty)
								{
									list.Add(empty);
									int num = -1;
									Utils.Parse<int>(xmlNode, "index", ref num);
									if (num != -1)
									{
										this.mBoneNameIndex[empty] = num;
									}
								}
							}
							this.mBoneMappings[attribute] = list.ToArray();
							TrackMaskBoneMappingsConfig.LabelLocation value = default(TrackMaskBoneMappingsConfig.LabelLocation);
							value.mXPos = 0;
							value.mYPos = 0;
							Utils.Parse<int>(xmlElement, "xPos", ref value.mXPos);
							Utils.Parse<int>(xmlElement, "yPos", ref value.mYPos);
							if (value.mXPos != 0 || value.mXPos != 0)
							{
								this.mLabelLocations[attribute] = value;
							}
						}
					}
					return true;
				}
				catch (Exception ex)
				{
					throw new Exception("Could not load track mask bone mappings config. Exception:" + ex.Message);
				}
				return true;
			}
			return true;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002498 File Offset: 0x00001498
		public bool SaveConfig()
		{
			bool result;
			try
			{
				if (File.Exists(this.mConfigFile))
				{
					bool flag = false;
					while (!flag)
					{
						FileAttributes attributes = File.GetAttributes(this.mConfigFile);
						if ((FileAttributes.ReadOnly & attributes) != (FileAttributes)0)
						{
							return false;
						}
						flag = true;
					}
				}
				XmlTextWriter xmlTextWriter = new XmlTextWriter(this.mConfigFile, Encoding.UTF8);
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.Namespaces = false;
				xmlTextWriter.WriteStartDocument();
				xmlTextWriter.WriteStartElement("BoneMappings");
				foreach (string text in this.BoneGroupNames)
				{
					xmlTextWriter.WriteStartElement("BoneGroup");
					xmlTextWriter.WriteAttributeString("name", text);
					if (this.mLabelLocations.ContainsKey(text))
					{
						XmlWriter xmlWriter = xmlTextWriter;
						string localName = "xPos";
						int mXPos = this.mLabelLocations[text].mXPos;
						xmlWriter.WriteAttributeString(localName, mXPos.ToString());
						XmlWriter xmlWriter2 = xmlTextWriter;
						string localName2 = "yPos";
						int mYPos = this.mLabelLocations[text].mYPos;
						xmlWriter2.WriteAttributeString(localName2, mYPos.ToString());
					}
					string[] bones = this.GetBones(text);
					foreach (string text2 in bones)
					{
						xmlTextWriter.WriteStartElement("Bone");
						xmlTextWriter.WriteAttributeString("name", text2);
						if (this.mBoneNameIndex.ContainsKey(text2))
						{
							xmlTextWriter.WriteAttributeString("index", this.mBoneNameIndex[text2].ToString());
						}
						xmlTextWriter.WriteEndElement();
					}
					xmlTextWriter.WriteEndElement();
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteEndDocument();
				xmlTextWriter.Close();
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002650 File Offset: 0x00001650
		public static TrackMaskBoneMappingsConfig Pet
		{
			get
			{
				return TrackMaskBoneMappingsConfig.mPetConfig;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002657 File Offset: 0x00001657
		public static TrackMaskBoneMappingsConfig Sim
		{
			get
			{
				return TrackMaskBoneMappingsConfig.mSimConfig;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000010 RID: 16 RVA: 0x0000265E File Offset: 0x0000165E
		public static bool Initialized
		{
			get
			{
				return TrackMaskBoneMappingsConfig.mPetConfig.IsInitialized && TrackMaskBoneMappingsConfig.mSimConfig.IsInitialized;
			}
		}

		// Token: 0x04000001 RID: 1
		private string mConfigFile = string.Empty;

		// Token: 0x04000002 RID: 2
		private Dictionary<string, string[]> mBoneMappings = new Dictionary<string, string[]>();

		// Token: 0x04000003 RID: 3
		private Dictionary<string, int> mBoneNameIndex = new Dictionary<string, int>();

		// Token: 0x04000004 RID: 4
		private Dictionary<string, TrackMaskBoneMappingsConfig.LabelLocation> mLabelLocations = new Dictionary<string, TrackMaskBoneMappingsConfig.LabelLocation>();

		// Token: 0x04000005 RID: 5
		private bool mInitialized;

		// Token: 0x04000006 RID: 6
		private static TrackMaskBoneMappingsConfig mPetConfig = new TrackMaskBoneMappingsConfig();

		// Token: 0x04000007 RID: 7
		private static TrackMaskBoneMappingsConfig mSimConfig = new TrackMaskBoneMappingsConfig();

		// Token: 0x02000003 RID: 3
		private struct LabelLocation
		{
			// Token: 0x04000008 RID: 8
			public int mXPos;

			// Token: 0x04000009 RID: 9
			public int mYPos;
		}
	}
}
