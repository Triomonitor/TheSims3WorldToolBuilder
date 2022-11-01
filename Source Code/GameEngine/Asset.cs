using System;
using System.Globalization;
using System.Xml;
using Sims3;
using Sims3.CSHost;
using Sims3.CSHost.Animation;
using Sims3.Serialization;
using Sims3.SimIFace;

namespace SACS
{
	// Token: 0x02000005 RID: 5
	public class Asset
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000030EE File Offset: 0x000020EE
		public static Log Log
		{
			get
			{
				return AssetDatabase.Log;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000030F5 File Offset: 0x000020F5
		public Asset()
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000310C File Offset: 0x0000210C
		public Asset(Sims3.CSHost.ResourceKey key)
		{
			this.m_key.mType = key.mType;
			this.m_key.mGroup = key.mGroup;
			this.m_key.mInstance = key.mInstance;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003164 File Offset: 0x00002164
		public Asset(string name)
		{
			this.m_name = name;
			this.m_key = new Sims3.CSHost.ResourceKey(this.Type, this.Group, Utils.HashString64(name));
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003B RID: 59 RVA: 0x0000319F File Offset: 0x0000219F
		public virtual Sims3.CSHost.ResourceKey Key
		{
			get
			{
				return this.m_key;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003C RID: 60 RVA: 0x000031A7 File Offset: 0x000021A7
		public virtual string Name
		{
			get
			{
				if (this.m_name == null)
				{
					this.m_name = AssetDatabase.GetAssetName(this);
				}
				return this.m_name;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000031C3 File Offset: 0x000021C3
		public virtual bool Exists
		{
			get
			{
				return AssetDatabase.AssetExists(this);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000031CB File Offset: 0x000021CB
		public virtual uint Type
		{
			get
			{
				return this.m_key.mType;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000031D8 File Offset: 0x000021D8
		public virtual uint Group
		{
			get
			{
				return this.m_key.mGroup;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000031E5 File Offset: 0x000021E5
		public virtual ulong Instance
		{
			get
			{
				return this.m_key.mInstance;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000031F4 File Offset: 0x000021F4
		public override bool Equals(object obj)
		{
			if (obj is Asset)
			{
				return this.m_key.Equals((obj as Asset).m_key);
			}
			if (obj is Sims3.CSHost.ResourceKey)
			{
				return this.m_key.Equals(obj);
			}
			return base.Equals(obj);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003242 File Offset: 0x00002242
		public override int GetHashCode()
		{
			return this.m_key.GetHashCode();
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003258 File Offset: 0x00002258
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				base.GetType().Name,
				":",
				this.Instance,
				":",
				this.Name
			});
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000032A7 File Offset: 0x000022A7
		public virtual void SaveToXml(XmlDocument doc, SimpleRegistry registry, XmlElement xmlNode)
		{
			this.SaveToXml(xmlNode);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000032B0 File Offset: 0x000022B0
		public virtual void SaveToXml(XmlElement xmlNode)
		{
			xmlNode.SetAttribute("type", "", "0x" + this.Type.ToString("x8"));
			xmlNode.SetAttribute("group", "", "0x" + this.Group.ToString("x8"));
			xmlNode.SetAttribute("instance", "", "0x" + this.Instance.ToString("x16"));
			if (this.Name != AssetDatabase.UnknownName)
			{
				xmlNode.SetAttribute("name", "", this.Name);
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003370 File Offset: 0x00002370
		private uint uintParse(string s)
		{
			if (s.StartsWith("0x"))
			{
				return uint.Parse(s.Substring(2), NumberStyles.HexNumber);
			}
			return uint.Parse(s);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003397 File Offset: 0x00002397
		private ulong ulongParse(string s)
		{
			if (s.StartsWith("0x"))
			{
				return ulong.Parse(s.Substring(2), NumberStyles.HexNumber);
			}
			return ulong.Parse(s);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000033C0 File Offset: 0x000023C0
		public virtual void LoadFromXml(XmlDocument doc, SimpleRegistry registry, XmlNode xmlNode)
		{
			Sims3.CSHost.ResourceKey resourceKey = default(Sims3.CSHost.ResourceKey);
			string text = null;
			if (Utils.Parse(xmlNode, "name", ref text) && Sims3.CSHost.ResourceKey.Parse(text, ref resourceKey))
			{
				text = null;
			}
			Sims3.CSHost.ResourceKey resourceKey2 = default(Sims3.CSHost.ResourceKey);
			resourceKey2.mType = this.uintParse(xmlNode.Attributes["type"].Value);
			resourceKey2.mGroup = this.uintParse(xmlNode.Attributes["group"].Value);
			if (text != null && text.Length > 0)
			{
				this.m_name = text;
				if (this is Motion)
				{
					resourceKey = resourceKey2;
					resourceKey.mInstance = Manager.GetInstanceIdForClipName(this.m_name);
				}
				else
				{
					resourceKey = ResourceMgr.CreateKeyFromName(this.m_name, resourceKey2.mType, resourceKey2.mGroup);
				}
			}
			if (xmlNode.Attributes["instance"] != null)
			{
				resourceKey2.mInstance = this.ulongParse(xmlNode.Attributes["instance"].Value);
			}
			if (text != null && text.Length > 0 && !resourceKey2.Equals(resourceKey))
			{
				Asset.Log.Debug("Asset", "ResourceKey: name/key mismatch; trusting name. ({0} vs {1})", new object[]
				{
					this.m_name,
					resourceKey2
				});
				resourceKey2 = resourceKey;
			}
			if (!ResourceMgr.RecordExists(resourceKey2))
			{
				uint mGroup = resourceKey2.mGroup;
				foreach (object obj in Enum.GetValues(typeof(ProductVersion)))
				{
					ProductVersion productVersion = (ProductVersion)obj;
					if (Utils.CountSetBits((uint)productVersion) == 1 && productVersion != ProductVersion.EP1)
					{
						resourceKey2.mGroup = ResourceUtils.ProductVersionToGroupId(productVersion);
						if (resourceKey2.mGroup != mGroup && ResourceMgr.RecordExists(resourceKey2))
						{
							Asset.Log.Warn("Asset", "File needs to be re-saved: Found new product version ({0}) for resource {1}.", new object[]
							{
								productVersion,
								this.m_name
							});
							break;
						}
						resourceKey2.mGroup = mGroup;
					}
				}
			}
			this.m_key = resourceKey2;
		}

		// Token: 0x04000013 RID: 19
		private const string kLogCategory = "Asset";

		// Token: 0x04000014 RID: 20
		protected Sims3.CSHost.ResourceKey m_key = new Sims3.CSHost.ResourceKey(0U, 0U, 0UL);

		// Token: 0x04000015 RID: 21
		protected string m_name;
	}
}
