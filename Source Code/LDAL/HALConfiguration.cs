using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Sims3.LDAL
{
	// Token: 0x0200004E RID: 78
	internal class HALConfiguration
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001EF RID: 495 RVA: 0x000083BC File Offset: 0x000073BC
		public static string LatestVersionConfigFileName
		{
			get
			{
				return "hal.config.xml";
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x000083C3 File Offset: 0x000073C3
		public static string EP01ConfigFileName
		{
			get
			{
				return "ep1Hal.config.xml";
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x000083CA File Offset: 0x000073CA
		public static string BaseConfigFileName
		{
			get
			{
				return "bgHAL.config.xml";
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x000083D1 File Offset: 0x000073D1
		public static string StoreConfigFileName
		{
			get
			{
				return "storeHAL.config.xml";
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x000083D8 File Offset: 0x000073D8
		public static string Sims3ToolsConfigFileName
		{
			get
			{
				return "sims3toolsHAL.config.xml";
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x000083DF File Offset: 0x000073DF
		public static HALConfiguration MainConfiguration
		{
			get
			{
				return HALConfiguration.mMainConfiguration;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x000083E6 File Offset: 0x000073E6
		public static List<HALConfiguration> ReadOnlyConfigurations
		{
			get
			{
				return HALConfiguration.mReadOnlyConfigurations;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x000083ED File Offset: 0x000073ED
		public int ProductCode
		{
			get
			{
				return this.m_productCode;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x000083F5 File Offset: 0x000073F5
		public int CategoryCode
		{
			get
			{
				return this.m_categoryCode;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x000083FD File Offset: 0x000073FD
		public string Username
		{
			get
			{
				return this.m_username;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00008405 File Offset: 0x00007405
		public string Password
		{
			get
			{
				return this.m_password;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001FA RID: 506 RVA: 0x0000840D File Offset: 0x0000740D
		public string PackageName
		{
			get
			{
				return this.m_packageName;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00008415 File Offset: 0x00007415
		public string ServerName
		{
			get
			{
				return this.m_serverName;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001FC RID: 508 RVA: 0x0000841D File Offset: 0x0000741D
		public string KeyFilter
		{
			get
			{
				return this.m_keyFilter;
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00008428 File Offset: 0x00007428
		public HALConfiguration(int productCode, int categoryCode, string userName, string password, string packageName, string serverName, string keyFilter)
		{
			this.m_categoryCode = categoryCode;
			this.m_productCode = productCode;
			this.m_username = userName;
			this.m_password = password;
			this.m_packageName = packageName;
			this.m_serverName = serverName;
			this.m_keyFilter = keyFilter;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x000084A7 File Offset: 0x000074A7
		public HALConfiguration(int productCode, int categoryCode, string userName, string password, string packageName, string serverName) : this(productCode, categoryCode, userName, password, packageName, serverName, string.Empty)
		{
		}

		// Token: 0x060001FF RID: 511 RVA: 0x000084BD File Offset: 0x000074BD
		public static void OverrideMainHalConfig(Dictionary<ConfigProperty, string> overrides)
		{
			HALConfiguration.mMainConfiguration = HALConfiguration.CreateNewConfigFromValues(overrides);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x000084CA File Offset: 0x000074CA
		public static void AddReadOnlyConfiguration(Dictionary<ConfigProperty, string> configValues)
		{
			HALConfiguration.mReadOnlyConfigurations.Add(HALConfiguration.CreateNewConfigFromValues(configValues));
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000084DC File Offset: 0x000074DC
		private static HALConfiguration CreateNewConfigFromValues(Dictionary<ConfigProperty, string> configValues)
		{
			int categoryCode = 0;
			string password = string.Empty;
			int productCode = 0;
			string userName = string.Empty;
			string packageName = string.Empty;
			string serverName = string.Empty;
			string empty = string.Empty;
			if (configValues.ContainsKey(ConfigProperty.HALCategoryCode))
			{
				categoryCode = int.Parse(configValues[ConfigProperty.HALCategoryCode]);
			}
			if (configValues.ContainsKey(ConfigProperty.HALPassword))
			{
				password = configValues[ConfigProperty.HALPassword];
			}
			if (configValues.ContainsKey(ConfigProperty.HALProductCode))
			{
				productCode = int.Parse(configValues[ConfigProperty.HALProductCode]);
			}
			if (configValues.ContainsKey(ConfigProperty.HALUsername))
			{
				userName = configValues[ConfigProperty.HALUsername];
			}
			if (configValues.ContainsKey(ConfigProperty.PackageName))
			{
				packageName = configValues[ConfigProperty.PackageName];
			}
			if (configValues.ContainsKey(ConfigProperty.ServerName))
			{
				serverName = configValues[ConfigProperty.ServerName];
			}
			if (configValues.ContainsKey(ConfigProperty.KeyFilter))
			{
				string text = configValues[ConfigProperty.KeyFilter];
			}
			return new HALConfiguration(productCode, categoryCode, userName, password, packageName, serverName);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x000085A0 File Offset: 0x000075A0
		public static bool ReadConfigurationFile(string configFilename, string versionFileName)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			string packageName = string.Empty;
			string serverName = string.Empty;
			try
			{
				if (string.IsNullOrEmpty(configFilename))
				{
					path = Path.GetFullPath(Path.GetDirectoryName(path) + Path.DirectorySeparatorChar + versionFileName);
				}
				else
				{
					path = Path.GetFullPath(Path.GetDirectoryName(path) + Path.DirectorySeparatorChar + configFilename);
				}
			}
			catch (Exception)
			{
				return false;
			}
			if (File.Exists(path))
			{
				XmlTextReader xmlTextReader = null;
				try
				{
					xmlTextReader = new XmlTextReader(Path.GetFullPath(path));
					xmlTextReader.ReadStartElement("HALCongifurationSettings");
					xmlTextReader.MoveToContent();
					if (xmlTextReader.LocalName == "HALProductCode")
					{
						int productCode = xmlTextReader.ReadElementContentAsInt();
						xmlTextReader.MoveToContent();
						if (xmlTextReader.LocalName == "HALCategoryCode")
						{
							int categoryCode = xmlTextReader.ReadElementContentAsInt();
							string userName = xmlTextReader.ReadElementString("HALUsername");
							string password = xmlTextReader.ReadElementString("HALPassword");
							xmlTextReader.MoveToContent();
							if (xmlTextReader.LocalName == "ServerName")
							{
								serverName = xmlTextReader.ReadElementContentAsString();
							}
							xmlTextReader.MoveToContent();
							if (xmlTextReader.LocalName == "PackageName")
							{
								packageName = xmlTextReader.ReadElementContentAsString();
							}
							xmlTextReader.ReadEndElement();
							xmlTextReader.Close();
							HALConfiguration.mMainConfiguration = new HALConfiguration(productCode, categoryCode, userName, password, packageName, serverName);
							return true;
						}
					}
					xmlTextReader.Close();
					return false;
				}
				catch (XmlException)
				{
					xmlTextReader.Close();
					return false;
				}
			}
			return false;
		}

		// Token: 0x040000BB RID: 187
		private const string kBaseFileName = "Sims3_Base_Strings";

		// Token: 0x040000BC RID: 188
		private const string kLatestVersionConfigFileName = "hal.config.xml";

		// Token: 0x040000BD RID: 189
		private const string kEP01ConfigFileName = "ep1Hal.config.xml";

		// Token: 0x040000BE RID: 190
		private const string kBaseConfigFileName = "bgHAL.config.xml";

		// Token: 0x040000BF RID: 191
		private const string kStoreConfigFileName = "storeHAL.config.xml";

		// Token: 0x040000C0 RID: 192
		private const string kSims3ToolsConfigFileName = "sims3toolsHAL.config.xml";

		// Token: 0x040000C1 RID: 193
		private static HALConfiguration mMainConfiguration;

		// Token: 0x040000C2 RID: 194
		private static List<HALConfiguration> mReadOnlyConfigurations = new List<HALConfiguration>();

		// Token: 0x040000C3 RID: 195
		private int m_productCode;

		// Token: 0x040000C4 RID: 196
		private int m_categoryCode;

		// Token: 0x040000C5 RID: 197
		private string m_username = string.Empty;

		// Token: 0x040000C6 RID: 198
		private string m_password = string.Empty;

		// Token: 0x040000C7 RID: 199
		private string m_packageName = "Sims3_Base_Strings";

		// Token: 0x040000C8 RID: 200
		private string m_serverName = string.Empty;

		// Token: 0x040000C9 RID: 201
		private string m_keyFilter = string.Empty;
	}
}
