using System;
using System.Collections.Generic;

namespace Sims3.LDAL
{
	// Token: 0x0200004C RID: 76
	public class StringDataSource
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x0000810E File Offset: 0x0000710E
		public static void SetDataSource(StringDataSourceType lsds)
		{
			if (lsds == StringDataSourceType.kHAL)
			{
				StringDataSource.m_dataSource = new HALLayer();
			}
			StringDataSource.SetupDictionaries();
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00008122 File Offset: 0x00007122
		public static void AddReadOnlyConfiguration(Dictionary<ConfigProperty, string> overrides)
		{
			HALConfiguration.AddReadOnlyConfiguration(overrides);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000812A File Offset: 0x0000712A
		public static void OverrideMainHalConfig(Dictionary<ConfigProperty, string> overrides)
		{
			HALConfiguration.OverrideMainHalConfig(overrides);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00008132 File Offset: 0x00007132
		public static void SetDataSource(StringDataSourceType lsds, string versionFileName)
		{
			if (lsds == StringDataSourceType.kHAL)
			{
				StringDataSource.m_dataSource = new HALLayer(versionFileName);
			}
			StringDataSource.SetupDictionaries();
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00008148 File Offset: 0x00007148
		private static void SetupDictionaries()
		{
			StringDataSource.HeadersDict[TableColHeader.StringKey] = "StringKey";
			StringDataSource.HeadersDict[TableColHeader.Comment] = "Comment";
			StringDataSource.HeadersDict[TableColHeader.Status] = "Status";
			StringDataSource.HeadersDict[TableColHeader.Legal] = "Legal";
			StringDataSource.HeadersDict[TableColHeader.Guideline] = "Guideline";
			StringDataSource.HeadersDict[TableColHeader.MaxLength] = "MaxLength";
			StringDataSource.HeadersDict[TableColHeader.Common] = "Text [Common]";
			StringDataSource.HeadersDict[TableColHeader.PC] = "Text [PC]";
			StringDataSource.HeadersDict[TableColHeader.Xbox360] = "Text [Xbox360]";
			StringDataSource.HeadersDict[TableColHeader.PS3] = "Text [PS3]";
			StringDataSource.HeadersDict[TableColHeader.VersionNumber] = "VersionNumber";
			StringDataSource.HeadersDict[TableColHeader.ProductionStatus] = "ProdStatus";
			StringDataSource.HeadersDict[TableColHeader.DoNotTranslate] = "DNT";
			StringDataSource.ProdStatusToStringsDict[ProductionStatus.Placeholder] = "Placeholder";
			StringDataSource.ProdStatusToStringsDict[ProductionStatus.InReview] = "In Review";
			StringDataSource.ProdStatusToStringsDict[ProductionStatus.Active] = "Active";
			StringDataSource.StringsToProdStatusDict["Placeholder"] = ProductionStatus.Placeholder;
			StringDataSource.StringsToProdStatusDict["In Review"] = ProductionStatus.InReview;
			StringDataSource.StringsToProdStatusDict["Active"] = ProductionStatus.Active;
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x0000828F File Offset: 0x0000728F
		public static ILDAL Instance
		{
			get
			{
				return StringDataSource.m_dataSource;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x00008296 File Offset: 0x00007296
		public static char GroupSeparator
		{
			get
			{
				return '/';
			}
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000829C File Offset: 0x0000729C
		public static void SplitKey(string key, out string group, out string descriptor)
		{
			group = string.Empty;
			descriptor = string.Empty;
			if (key == null)
			{
				return;
			}
			int num = key.IndexOf(":");
			if (num >= 0)
			{
				group = key.Substring(0, num);
				descriptor = key.Substring(num + 1);
			}
		}

		// Token: 0x060001EB RID: 491 RVA: 0x000082E0 File Offset: 0x000072E0
		public static bool IsKeyValid(string key, out string reason)
		{
			reason = string.Empty;
			if (key.Contains("\\") || key.Contains(".") || key.Contains(";") || key.Contains(" "))
			{
				reason = "String Key cannot contain the following characters - '\\' (back slash), '.' (period), ';' (semi-colon), ' ' (space).";
				return false;
			}
			string[] array = key.Split(new char[]
			{
				':'
			});
			if (array.Length != 2)
			{
				reason = "String Key needs to have a ':' (colon) character.";
				return false;
			}
			if (array[0] == string.Empty)
			{
				reason = "String Key needs an object group specified before the ':' (colon) character.";
				return false;
			}
			if (array[1] == string.Empty)
			{
				reason = "String Key needs an object descriptor specified after the ':' (colon) character.";
				return false;
			}
			return true;
		}

		// Token: 0x040000B7 RID: 183
		private static ILDAL m_dataSource = null;

		// Token: 0x040000B8 RID: 184
		public static Dictionary<TableColHeader, string> HeadersDict = new Dictionary<TableColHeader, string>();

		// Token: 0x040000B9 RID: 185
		public static Dictionary<string, ProductionStatus> StringsToProdStatusDict = new Dictionary<string, ProductionStatus>();

		// Token: 0x040000BA RID: 186
		public static Dictionary<ProductionStatus, string> ProdStatusToStringsDict = new Dictionary<ProductionStatus, string>();
	}
}
