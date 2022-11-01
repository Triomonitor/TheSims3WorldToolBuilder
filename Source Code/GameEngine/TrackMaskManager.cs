using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Sims3;
using Sims3.CSHost;
using Sims3.Serialization;

namespace SACS
{
	// Token: 0x0200000A RID: 10
	public class TrackMaskManager
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00003846 File Offset: 0x00002846
		public static Log Log
		{
			get
			{
				return AssetDatabase.Log;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000065 RID: 101 RVA: 0x0000384D File Offset: 0x0000284D
		public IEnumerable<SacsTrackMask> TrackMasks
		{
			get
			{
				return this.mTrackMasks;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00003868 File Offset: 0x00002868
		public string TrackMaskFile
		{
			get
			{
				return this.mTrackMaskFile;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00003870 File Offset: 0x00002870
		public static string GlobalTrackMaskDir
		{
			get
			{
				return Path.Combine(App.AssetsJazzSourcePath, "InGame\\GlobalTrackMasks");
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00003881 File Offset: 0x00002881
		public static string DefaultTrackMaskFilename
		{
			get
			{
				return "global.trackmasks";
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00003888 File Offset: 0x00002888
		public static string SimTrackMaskBoneMappingFilename
		{
			get
			{
				return "simtrackmaskbonemappings.config.xml";
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600006B RID: 107 RVA: 0x0000388F File Offset: 0x0000288F
		public static string PetTrackMaskBoneMappingFilename
		{
			get
			{
				return "pettrackmaskbonemappings.config.xml";
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00003896 File Offset: 0x00002896
		public static string DefaultGlobalTrackMaskSourceFile
		{
			get
			{
				return Path.Combine(TrackMaskManager.GlobalTrackMaskDir, TrackMaskManager.DefaultTrackMaskFilename);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600006D RID: 109 RVA: 0x000038A7 File Offset: 0x000028A7
		public static string SimTrackMaskBoneMappingsFile
		{
			get
			{
				return Path.Combine(TrackMaskManager.GlobalTrackMaskDir, TrackMaskManager.SimTrackMaskBoneMappingFilename);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600006E RID: 110 RVA: 0x000038B8 File Offset: 0x000028B8
		public static string PetTrackMaskBoneMappingsFile
		{
			get
			{
				return Path.Combine(TrackMaskManager.GlobalTrackMaskDir, TrackMaskManager.PetTrackMaskBoneMappingFilename);
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000038C9 File Offset: 0x000028C9
		public bool InitSimAndPetTrackMaskBoneMappingFile()
		{
			TrackMaskBoneMappingsConfig.Pet.Init(TrackMaskManager.PetTrackMaskBoneMappingsFile);
			return TrackMaskBoneMappingsConfig.Sim.Init(TrackMaskManager.SimTrackMaskBoneMappingsFile);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000038EA File Offset: 0x000028EA
		public void LoadFromXml()
		{
			if (this.mTrackMaskFile == null)
			{
				this.mTrackMaskFile = TrackMaskManager.DefaultGlobalTrackMaskSourceFile;
			}
			this.LoadFromXml(this.mTrackMaskFile);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000390C File Offset: 0x0000290C
		public void LoadFromXml(string filename)
		{
			if (!File.Exists(filename))
			{
				TrackMaskManager.Log.Warn("TrackMaskManager", "File not found: " + filename, new object[0]);
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(filename);
			XmlElement documentElement = xmlDocument.DocumentElement;
			this.LoadFromXml(new SimpleRegistry(), documentElement);
			this.mTrackMaskFile = filename;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003969 File Offset: 0x00002969
		public void SaveToXml()
		{
			if (this.mTrackMaskFile == null)
			{
				this.mTrackMaskFile = TrackMaskManager.DefaultTrackMaskFilename;
			}
			this.SaveToXml(this.mTrackMaskFile);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000398C File Offset: 0x0000298C
		public void SaveToXml(string filename)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.AppendChild(this.SaveToXml(xmlDocument, new SimpleRegistry()));
			try
			{
				xmlDocument.Save(filename);
				TrackMaskManager.Log.Info("TrackMaskManager", string.Concat(new object[]
				{
					"Saved: ",
					filename,
					" at ",
					DateTime.Now.TimeOfDay
				}), new object[0]);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003A1C File Offset: 0x00002A1C
		public XmlElement SaveToXml(XmlDocument doc, SimpleRegistry registry)
		{
			XmlElement xmlElement = doc.CreateElement("trackmasklist");
			foreach (SacsTrackMask sacsTrackMask in this.TrackMasks)
			{
				XmlElement newChild = sacsTrackMask.SaveToXml(doc);
				xmlElement.AppendChild(newChild);
				registry.Register(sacsTrackMask, "" + sacsTrackMask.ExternalKeyInstance);
			}
			return xmlElement;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003A9C File Offset: 0x00002A9C
		public void LoadFromXml(SimpleRegistry registry, XmlElement tcn)
		{
			this.mTrackMasks.Clear();
			foreach (object obj in tcn)
			{
				XmlElement xmlElement = (XmlElement)obj;
				if (xmlElement.Name == "trackmask")
				{
					SacsTrackMask sacsTrackMask = SacsTrackMask.LoadFromXml(xmlElement);
					this.mTrackMasks.Add(sacsTrackMask);
					registry.Register(sacsTrackMask, "" + sacsTrackMask.ExternalKeyInstance);
				}
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003B38 File Offset: 0x00002B38
		public void RemoveTrackMask(SacsTrackMask doomed)
		{
			this.mTrackMasks.Remove(doomed);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003B47 File Offset: 0x00002B47
		public void AddTrackMask(SacsTrackMask mask)
		{
			if (this.mTrackMasks.Contains(mask))
			{
				return;
			}
			this.mTrackMasks.Add(mask);
		}

		// Token: 0x04000017 RID: 23
		private const string kLogCategory = "TrackMaskManager";

		// Token: 0x04000018 RID: 24
		private List<SacsTrackMask> mTrackMasks = new List<SacsTrackMask>();

		// Token: 0x04000019 RID: 25
		private string mTrackMaskFile;
	}
}
