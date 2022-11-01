using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Sims3;
using Sims3.CSHost;

namespace ToolUtil
{
	// Token: 0x02000002 RID: 2
	public class XmlConfigFile
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public XmlDocument Document
		{
			get
			{
				return this.mConfigDoc;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00001058
		public string AssetRoot
		{
			get
			{
				return this.mAssetRoot;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002060 File Offset: 0x00001060
		public string[] AutoBuilderPaths
		{
			get
			{
				return this.mAutoBuilderPaths.ToArray();
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000004 RID: 4 RVA: 0x0000206D File Offset: 0x0000106D
		public string SKUDefintions
		{
			get
			{
				return this.mSKUDefinitions;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002075 File Offset: 0x00001075
		public string CurrentSKU
		{
			get
			{
				return this.mCurrentSKU;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002080 File Offset: 0x00001080
		public bool Init(string filename)
		{
			bool result = false;
			this.mStartupPath = App.ExePath;
			if (filename != null && filename.Length > 0)
			{
				string text = XmlConfigFile.CreateFullPath(filename, this.mStartupPath);
				FileInfo fileInfo = new FileInfo(text);
				if (fileInfo.Exists)
				{
					this.mConfigDoc = new XmlDocument();
					this.mConfigDoc.Load(text);
					result = this.LoadConfig(this.mConfigDoc);
				}
			}
			return result;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020E8 File Offset: 0x000010E8
		public static void ProcessConfigData(XmlConfigFile config)
		{
			string empty = string.Empty;
			if (config.Document != null)
			{
				XmlElement documentElement = config.Document.DocumentElement;
				XmlNode xmlNode = documentElement.SelectSingleNode("pipelineConfig/AssetRoot");
				if (xmlNode != null)
				{
					Utils.Parse(xmlNode, "default", ref empty);
				}
				XmlNodeList xmlNodeList = documentElement.SelectNodes("pipelineConfig/Autobuilder/address");
				foreach (object obj in xmlNodeList)
				{
					XmlElement xmlNode2 = (XmlElement)obj;
					string empty2 = string.Empty;
					Utils.Parse(xmlNode2, "value", ref empty2);
					config.mAutoBuilderPaths.Add(empty2);
				}
				xmlNodeList = documentElement.SelectNodes("global");
				foreach (object obj2 in xmlNodeList)
				{
					XmlElement xmlNode3 = (XmlElement)obj2;
					string empty3 = string.Empty;
					string empty4 = string.Empty;
					if (Utils.Parse(xmlNode3, "key", ref empty3) && Utils.Parse(xmlNode3, "value", ref empty4))
					{
						AppDomain.CurrentDomain.SetData(XmlConfigFile.GlobalDataPrefix + empty3, empty4);
					}
				}
				string empty5 = string.Empty;
				XmlNode xmlNode4 = documentElement.SelectSingleNode("pipelineConfig/SKUDefinitions");
				if (xmlNode4 != null)
				{
					Utils.Parse(xmlNode4, "path", ref config.mSKUDefinitions);
				}
				XmlNode xmlNode5 = documentElement.SelectSingleNode("pipelineConfig/Sku");
				if (xmlNode5 != null)
				{
					Utils.Parse(xmlNode5, "value", ref config.mCurrentSKU);
				}
			}
			AppDomain.CurrentDomain.SetData("ASSETROOT", empty);
			config.mAssetRoot = empty;
			Utils.FilePath.EnsureTrailingPathSeparator(ref config.mAssetRoot);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000022AC File Offset: 0x000012AC
		public static object GetGlobal(string key)
		{
			string name = XmlConfigFile.GlobalDataPrefix + key;
			return AppDomain.CurrentDomain.GetData(name);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000022D0 File Offset: 0x000012D0
		private static string CreateFullPath(string filename, string startupPath)
		{
			string text = filename;
			try
			{
				if (!Path.IsPathRooted(filename))
				{
					text = Path.Combine(startupPath, filename);
				}
				text = Path.GetFullPath(text);
			}
			catch (ArgumentException)
			{
			}
			return text;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000230C File Offset: 0x0000130C
		private bool LoadConfig(XmlDocument configDoc)
		{
			XmlNodeList elementsByTagName = configDoc.GetElementsByTagName("include");
			if (elementsByTagName != null)
			{
				for (int i = 0; i < elementsByTagName.Count; i++)
				{
					XmlNode xmlNode = elementsByTagName[i];
					XmlAttribute xmlAttribute = xmlNode.Attributes["filename"];
					if (xmlAttribute != null && !this.ReplaceNodeByFileContent(configDoc, xmlNode, xmlAttribute.InnerText))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002368 File Offset: 0x00001368
		private bool ReplaceNodeByFileContent(XmlDocument doc, XmlNode node, string filename)
		{
			bool result = false;
			string text = XmlConfigFile.CreateFullPath(filename, this.mStartupPath);
			FileInfo fileInfo = new FileInfo(text);
			if (fileInfo.Exists)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(text);
				XmlNode parentNode = node.ParentNode;
				if (parentNode != null)
				{
					parentNode.AppendChild(doc.ImportNode(xmlDocument.FirstChild, true));
					parentNode.RemoveChild(node);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x04000001 RID: 1
		private XmlDocument mConfigDoc;

		// Token: 0x04000002 RID: 2
		private string mStartupPath;

		// Token: 0x04000003 RID: 3
		private string mAssetRoot = string.Empty;

		// Token: 0x04000004 RID: 4
		private string mSKUDefinitions = string.Empty;

		// Token: 0x04000005 RID: 5
		private string mCurrentSKU = string.Empty;

		// Token: 0x04000006 RID: 6
		private List<string> mAutoBuilderPaths = new List<string>();

		// Token: 0x04000007 RID: 7
		public static readonly string GlobalDataPrefix = "Global/";
	}
}
