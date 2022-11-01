using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using Sims3.LDAL.HALWebService;

namespace Sims3.LDAL
{
	// Token: 0x02000041 RID: 65
	internal class HALLayer : ILDAL
	{
		// Token: 0x14000020 RID: 32
		// (add) Token: 0x060001BA RID: 442 RVA: 0x00005EC2 File Offset: 0x00004EC2
		// (remove) Token: 0x060001BB RID: 443 RVA: 0x00005EDB File Offset: 0x00004EDB
		public event QueryStringCompletedHandler OnQueryStringCompleted;

		// Token: 0x060001BC RID: 444 RVA: 0x00005EF4 File Offset: 0x00004EF4
		public HALLayer()
		{
			this.Setup(HALConfiguration.LatestVersionConfigFileName);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00005F2B File Offset: 0x00004F2B
		public HALLayer(string versionFileName)
		{
			this.Setup(versionFileName);
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00005F5E File Offset: 0x00004F5E
		public string GetServerName()
		{
			return HALConfiguration.MainConfiguration.ServerName;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00005F6C File Offset: 0x00004F6C
		public string[] GetLanguagesLongNames()
		{
			List<string> list = new List<string>();
			string a = null;
			string text = null;
			DataSet dataSet = null;
			try
			{
				dataSet = this.m_HALWebService.GetLanguagesInProduct(HALConfiguration.MainConfiguration.ProductCode, ref a, ref text);
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Could not retrieve languages from HAL.\n\nHAL returned message - '{0}'", ex.Message));
			}
			if (a == "0" && dataSet.Tables.Count == 1)
			{
				using (IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DataRow dataRow = (DataRow)obj;
						list.Add((string)dataRow["LANGUAGENAME"]);
					}
					goto IL_C6;
				}
				goto IL_BB;
				IL_C6:
				return list.ToArray();
			}
			IL_BB:
			throw new DataSourceException("Could not retrieve languages from HAL");
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00006064 File Offset: 0x00005064
		public string[] GetLanguagesShortNames()
		{
			List<string> list = new List<string>();
			string a = null;
			string text = null;
			DataSet dataSet = null;
			try
			{
				dataSet = this.m_HALWebService.GetLanguagesInProduct(HALConfiguration.MainConfiguration.ProductCode, ref a, ref text);
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Could not retrieve language short names from HAL.\n\nHAL returned message - '{0}'", ex.Message));
			}
			if (a == "0" && dataSet.Tables.Count == 1)
			{
				using (IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DataRow dataRow = (DataRow)obj;
						list.Add((string)dataRow["LANGUAGESHORTNAME"]);
					}
					goto IL_C6;
				}
				goto IL_BB;
				IL_C6:
				return list.ToArray();
			}
			IL_BB:
			throw new DataSourceException("Could not retrieve language short names from HAL");
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000615C File Offset: 0x0000515C
		public string[] GetPlatformsLongNames()
		{
			List<string> list = new List<string>();
			string a = null;
			string text = null;
			DataSet dataSet = null;
			try
			{
				dataSet = this.m_HALWebService.GetPlatformsInProduct(HALConfiguration.MainConfiguration.ProductCode, ref a, ref text);
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Could not retrieve platforms from HAL.\n\nHAL returned message - '{0}'", ex.Message));
			}
			if (a == "0" && text == "Success" && dataSet.Tables.Count == 1)
			{
				using (IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DataRow dataRow = (DataRow)obj;
						list.Add((string)dataRow["PLATFORMNAME"]);
					}
					goto IL_D9;
				}
				goto IL_C8;
				IL_D9:
				return list.ToArray();
			}
			IL_C8:
			throw new DataSourceException(string.Format("Could not retrieve platforms from HAL. {0}", text));
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00006264 File Offset: 0x00005264
		public DataTable GetAllStringsForLanguageAndPlatforms(string langCode, Platform platforms)
		{
			string a = null;
			string text = null;
			DataSet dataSet = null;
			string text2 = string.Empty;
			if ((platforms & Platform.COMMON) == Platform.COMMON)
			{
				text2 = text2 + Platform.COMMON.ToString() + ",";
			}
			if ((platforms & Platform.PC) == Platform.PC)
			{
				text2 = text2 + Platform.PC.ToString() + ",";
			}
			if ((platforms & Platform.XBOX360) == Platform.XBOX360)
			{
				text2 = text2 + Platform.XBOX360.ToString() + ",";
			}
			if ((platforms & Platform.PS3) == Platform.PS3)
			{
				text2 = text2 + Platform.PS3.ToString() + ",";
			}
			text2 = text2.TrimEnd(new char[]
			{
				','
			});
			if (text2 == string.Empty)
			{
				throw new DataSourceException("Cannot query for strings. No platform specified");
			}
			try
			{
				dataSet = this.m_HALWebService.GetAllStrings_WithProductionStatuses_SIMS3(HALConfiguration.MainConfiguration.ProductCode, langCode, text2, string.Empty, ref a, ref text);
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Could not get strings.\n\nError Message from HAL: {0}", ex.Message));
			}
			try
			{
				foreach (HALConfiguration halconfiguration in HALConfiguration.ReadOnlyConfigurations)
				{
					DataSet allStrings_WithProductionStatuses_SIMS = this.m_HALWebService.GetAllStrings_WithProductionStatuses_SIMS3(HALConfiguration.MainConfiguration.ProductCode, langCode, text2, string.Empty, ref a, ref text);
					dataSet.Merge(allStrings_WithProductionStatuses_SIMS);
				}
			}
			catch (Exception ex2)
			{
				throw new DataSourceException(string.Format("Could not get strings for readonly product.\n\nError Message from HAL: {0}", ex2.Message));
			}
			if (a == "0" && text == "Success" && dataSet.Tables.Count >= 1)
			{
				DataTable dataTable = dataSet.Tables[0].Clone();
				foreach (DataRow row in dataSet.Tables[0].Select(HALConfiguration.MainConfiguration.KeyFilter, HALLayer.HALTableColumns.STRINGID.ToString() + " ASC"))
				{
					dataTable.ImportRow(row);
				}
				this.DeleteUnusedColumnHeaders(dataTable);
				this.RenameColumnHeaders(dataTable);
				return dataTable;
			}
			throw new DataSourceException(string.Format("Could not retrieve strings.\n\nError Message from HAL: {0}", text));
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000064B4 File Offset: 0x000054B4
		public void GetAllStringsForLanguageAndPlatformsAsync(string langCode, Platform platforms)
		{
			string retCode = null;
			string retString = null;
			string text = string.Empty;
			if ((platforms & Platform.COMMON) == Platform.COMMON)
			{
				text = text + Platform.COMMON.ToString() + ",";
			}
			if ((platforms & Platform.PC) == Platform.PC)
			{
				text = text + Platform.PC.ToString() + ",";
			}
			if ((platforms & Platform.XBOX360) == Platform.XBOX360)
			{
				text = text + Platform.XBOX360.ToString() + ",";
			}
			if ((platforms & Platform.PS3) == Platform.PS3)
			{
				text = text + Platform.PS3.ToString() + ",";
			}
			text = text.TrimEnd(new char[]
			{
				','
			});
			this.m_HALWebService.GetAllStrings_WithProductionStatuses_SIMS3Completed += this.GetAllStringsForLanguageAndPlatformsASyncCompleted;
			this.m_HALWebService.GetAllStrings_WithProductionStatuses_SIMS3Async(HALConfiguration.MainConfiguration.ProductCode, langCode, text, string.Empty, retCode, retString);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00006588 File Offset: 0x00005588
		public bool FindStringEntry(string stringKey, string locale, Platform platform, out string text, out string comment, out ProductionStatus status, out int versionNumber)
		{
			comment = string.Empty;
			status = ProductionStatus.Placeholder;
			text = string.Empty;
			versionNumber = -1;
			bool flag = false;
			string a = null;
			string a2 = null;
			DataSet dataSet = this.m_HALWebService.ExactWordSearch(HALConfiguration.MainConfiguration.ProductCode, locale, platform.ToString(), "-1", "1", stringKey, ref a, ref a2);
			if (a == "0" && a2 == "Success" && dataSet.Tables.Count == 1 && dataSet.Tables[0].Rows.Count > 0)
			{
				DataRow dataRow = dataSet.Tables[0].Rows[0];
				text = (string)dataRow["SOURCETEXT"];
				comment = (string)dataRow["LANGUAGETEXT"];
				status = (ProductionStatus)Enum.Parse(typeof(ProductionStatus), ((string)dataRow["PRODUCTIONSTATUSNAME"]).Replace(" ", ""));
				versionNumber = (int)dataRow["VersionNumber"];
				flag = true;
			}
			int num = 0;
			while (num < HALConfiguration.ReadOnlyConfigurations.Count && !flag)
			{
				HALConfiguration halconfiguration = HALConfiguration.ReadOnlyConfigurations[num];
				dataSet = this.m_HALWebService.ExactWordSearch(halconfiguration.ProductCode, locale, platform.ToString(), "-1", "1", stringKey, ref a, ref a2);
				if (a == "0" && a2 == "Success" && dataSet.Tables.Count == 1 && dataSet.Tables[0].Rows.Count > 0)
				{
					DataRow dataRow2 = dataSet.Tables[0].Rows[0];
					text = (string)dataRow2["SOURCETEXT"];
					comment = (string)dataRow2["LANGUAGETEXT"];
					status = (ProductionStatus)Enum.Parse(typeof(ProductionStatus), ((string)dataRow2["PRODUCTIONSTATUSNAME"]).Replace(" ", ""));
					versionNumber = (int)dataRow2["VersionNumber"];
					flag = true;
				}
				num++;
			}
			return flag;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00006800 File Offset: 0x00005800
		public bool FindStringEntry(string stringKey, string locale, Platform platform, out string resultText)
		{
			string text;
			string text2;
			ProductionStatus productionStatus;
			int num;
			if (this.FindStringEntry(stringKey, locale, platform, out text, out text2, out productionStatus, out num))
			{
				if (locale == "ENG_US")
				{
					resultText = text;
				}
				else if (!string.IsNullOrEmpty(text2))
				{
					resultText = text2;
				}
				else
				{
					resultText = stringKey;
				}
				return true;
			}
			resultText = stringKey;
			return false;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000684C File Offset: 0x0000584C
		public bool FindAllStringEntries(string stringKey, string locale, Platform platform, out List<string> text, out List<string> comment, out List<ProductionStatus> status, out List<int> versionNumber, out List<string> fullKey)
		{
			comment = new List<string>();
			status = new List<ProductionStatus>();
			text = new List<string>();
			versionNumber = new List<int>();
			fullKey = new List<string>();
			bool result = false;
			string a = null;
			string a2 = null;
			DataSet dataSet = this.m_HALWebService.BasicSearch(HALConfiguration.MainConfiguration.ProductCode, locale, platform.ToString(), "-1", "1", stringKey, ref a, ref a2);
			if (a == "0" && a2 == "Success" && dataSet.Tables.Count == 1 && dataSet.Tables[0].Rows.Count > 0)
			{
				foreach (object obj in dataSet.Tables[0].Rows)
				{
					DataRow dataRow = (DataRow)obj;
					text.Add((string)dataRow["SOURCETEXT"]);
					comment.Add((string)dataRow["LANGUAGETEXT"]);
					status.Add((ProductionStatus)Enum.Parse(typeof(ProductionStatus), ((string)dataRow["PRODUCTIONSTATUSNAME"]).Replace(" ", "")));
					versionNumber.Add((int)dataRow["VersionNumber"]);
					fullKey.Add((string)dataRow["STRINGID"]);
				}
				result = true;
			}
			foreach (HALConfiguration halconfiguration in HALConfiguration.ReadOnlyConfigurations)
			{
				dataSet = this.m_HALWebService.BasicSearch(halconfiguration.ProductCode, locale, platform.ToString(), "-1", "1", stringKey, ref a, ref a2);
				if (a == "0" && a2 == "Success" && dataSet.Tables.Count == 1 && dataSet.Tables[0].Rows.Count > 0)
				{
					foreach (object obj2 in dataSet.Tables[0].Rows)
					{
						DataRow dataRow2 = (DataRow)obj2;
						text.Add((string)dataRow2["SOURCETEXT"]);
						comment.Add((string)dataRow2["LANGUAGETEXT"]);
						status.Add((ProductionStatus)Enum.Parse(typeof(ProductionStatus), ((string)dataRow2["PRODUCTIONSTATUSNAME"]).Replace(" ", "")));
						versionNumber.Add((int)dataRow2["VersionNumber"]);
						fullKey.Add((string)dataRow2["STRINGID"]);
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00006BE8 File Offset: 0x00005BE8
		public DataTable FindAllStringEntries(string stringKey, string locale, Platform platform)
		{
			string a = null;
			string a2 = null;
			DataTable dataTable = null;
			DataSet dataSet = this.m_HALWebService.BasicSearch(HALConfiguration.MainConfiguration.ProductCode, locale, platform.ToString(), "-1", "1", stringKey, ref a, ref a2);
			if (a == "0" && a2 == "Success" && dataSet.Tables.Count == 1 && dataSet.Tables[0].Rows.Count > 0)
			{
				dataTable = dataSet.Tables[0];
				foreach (object obj in dataTable.Columns)
				{
					DataColumn dataColumn = (DataColumn)obj;
					dataColumn.ColumnName = dataColumn.ColumnName.ToUpper();
				}
				this.DeleteUnusedColumnHeaders(dataTable);
				this.RenameColumnHeaders(dataTable);
				foreach (HALConfiguration halconfiguration in HALConfiguration.ReadOnlyConfigurations)
				{
					DataSet dataSet2 = this.m_HALWebService.BasicSearch(halconfiguration.ProductCode, locale, platform.ToString(), "-1", "1", stringKey, ref a, ref a2);
					if (!(a == "0") || !(a2 == "Success") || dataSet.Tables.Count != 1 || dataSet.Tables[0].Rows.Count <= 0)
					{
						return null;
					}
					DataTable dataTable2 = dataSet2.Tables[0];
					foreach (object obj2 in dataTable2.Columns)
					{
						DataColumn dataColumn2 = (DataColumn)obj2;
						dataColumn2.ColumnName = dataColumn2.ColumnName.ToUpper();
					}
					this.DeleteUnusedColumnHeaders(dataTable2);
					this.RenameColumnHeaders(dataTable2);
					HALLayer.MergeStrings(dataTable, dataTable2, "StringId");
				}
				return dataTable;
			}
			return null;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00006E68 File Offset: 0x00005E68
		private static void MergeStrings(DataTable baseTable, DataTable toAdd, string comparisonColumnName)
		{
			foreach (object obj in toAdd.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				string text = dataRow[comparisonColumnName].ToString();
				text = text.Replace("'", "''");
				if (baseTable.Select(string.Format("{0} LIKE '{1}'", comparisonColumnName, text)).Length == 0)
				{
					baseTable.ImportRow(dataRow);
				}
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00006EF8 File Offset: 0x00005EF8
		public void CreateNewStringEntry(string stringKey, string stringText, string comment, Platform platform, ProductionStatus productionStatus, bool bDNT)
		{
			if (stringKey == null)
			{
				throw new DataSourceException("Specified string key is null.");
			}
			if (stringText == null)
			{
				stringText = string.Empty;
			}
			if (comment == null)
			{
				comment = string.Empty;
			}
			string a = string.Empty;
			string empty = string.Empty;
			try
			{
				a = this.m_HALWebService.CreateNewString(HALConfiguration.MainConfiguration.ProductCode, HALConfiguration.MainConfiguration.CategoryCode, stringKey, stringText, platform.ToString(), ",", "", "", comment, false, ref empty);
				if (productionStatus != ProductionStatus.Placeholder)
				{
					this.EditStringEntry(stringKey, stringText, comment, productionStatus, bDNT, platform, 1);
				}
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Could not create source string - {0}.\n\nError Message from HAL: {1}", stringKey, ex.Message));
			}
			if (a != "0" || empty != "Success")
			{
				throw new DataSourceException(string.Format("Could not create source string - {0}.\n\nError Message from HAL: {1}", stringKey, empty));
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00006FE0 File Offset: 0x00005FE0
		public void EditStringEntry(string stringKey, string stringText, string comment, ProductionStatus productionStatus, bool bDNT, Platform platform, int versionNumber)
		{
			if (stringKey == null)
			{
				throw new DataSourceException("Specified string key is null.");
			}
			if (stringText == null)
			{
				stringText = string.Empty;
			}
			if (comment == null)
			{
				comment = string.Empty;
			}
			string a = string.Empty;
			string empty = string.Empty;
			try
			{
				a = this.m_HALWebService.UpdateSourceString_IncludingDNT(HALConfiguration.MainConfiguration.ProductCode, HALConfiguration.MainConfiguration.CategoryCode, stringKey, stringText, platform.ToString(), ",", "", "", comment, false, false, (int)productionStatus, versionNumber, bDNT, ref empty);
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Could not update source string - {0}.\n\nError Message from HAL: {1}", stringKey, ex.Message));
			}
			if (a != "0" || empty != "Success")
			{
				throw new DataSourceException(string.Format("Could not update source string - {0}.\n\nError Message from HAL: {1}", stringKey, empty));
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000070BC File Offset: 0x000060BC
		public void DeleteStringEntry(string stringKey, Platform platform)
		{
			if (stringKey == null)
			{
				throw new DataSourceException("Specified string key is null.");
			}
			string a = string.Empty;
			string empty = string.Empty;
			try
			{
				a = this.m_HALWebService.DeleteString(HALConfiguration.MainConfiguration.ProductCode, HALConfiguration.MainConfiguration.CategoryCode, stringKey, platform.ToString(), ",", ref empty);
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Could not delete source string - {0}.\n\nError Message from HAL: {1}", stringKey, ex.Message));
			}
			if (a != "0" || empty != "Success")
			{
				throw new DataSourceException(string.Format("Could not delete source string - {0}.\n\nError Message from HAL: {1}", stringKey, empty));
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000716C File Offset: 0x0000616C
		public void RenameStringEntry(string oldStringKey, string newStringKey, Platform platform)
		{
			if (string.IsNullOrEmpty(oldStringKey))
			{
				throw new DataSourceException("Specified old string key is null or empty.");
			}
			if (string.IsNullOrEmpty(newStringKey))
			{
				throw new DataSourceException("Specified new string key is null or empty.");
			}
			string a = string.Empty;
			string empty = string.Empty;
			try
			{
				a = this.m_HALWebService.RenameStringId(HALConfiguration.MainConfiguration.ProductCode, platform.ToString(), ",", oldStringKey, newStringKey, ref empty);
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Could not rename string  entry with string key - {0}.\n\nError Message from HAL: {1}", oldStringKey, ex.Message));
			}
			if (a != "0" || empty != "Success")
			{
				throw new DataSourceException(string.Format("Could not rename string  entry with string key - {0}.\n\nError Message from HAL: {1}", oldStringKey, empty));
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000722C File Offset: 0x0000622C
		public void SetColumnOptions(bool bRetStatus, bool bRetComment, bool bRetLegal, bool bRetGuideline, bool bRetMaxLength)
		{
			this.m_bReturnStatus = bRetStatus;
			this.m_bReturnComment = bRetComment;
			this.m_bReturnLegal = bRetLegal;
			this.m_bReturnGuideline = bRetGuideline;
			this.m_bReturnMaxLength = bRetMaxLength;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00007254 File Offset: 0x00006254
		public void SaveStringsAsXML(string langCode, Platform platform, string outputFile)
		{
			DataTable allStringsForLanguageAndPlatforms = this.GetAllStringsForLanguageAndPlatforms(langCode, platform);
			this.SaveStringsAsXML(langCode, platform, outputFile, allStringsForLanguageAndPlatforms);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00007274 File Offset: 0x00006274
		public void SaveStringsAsXML(string langCode, Platform platform, string outputFile, DataTable table)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(outputFile);
				if (!fileInfo.Directory.Exists)
				{
					throw new DataSourceException(string.Format("Directory '{0}' does not exist", Path.GetFullPath(outputFile)));
				}
				TableColHeader tableColHeader = HALLayer.GetTableColHeader(platform, outputFile);
				this.WriteXMLFile(langCode, tableColHeader, table, outputFile, true);
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Trying to save strings as XML. {0}", ex.Message));
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x000072EC File Offset: 0x000062EC
		public void SaveStringsAsXML(string langCode, Platform platform, string outputFile, string[] stringKeys)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(outputFile);
				if (!fileInfo.Directory.Exists)
				{
					throw new DataSourceException(string.Format("Directory '{0}' does not exist", Path.GetFullPath(outputFile)));
				}
				TableColHeader tableColHeader = HALLayer.GetTableColHeader(platform, outputFile);
				string columnName = StringDataSource.HeadersDict[TableColHeader.StringKey];
				string columnName2 = StringDataSource.HeadersDict[tableColHeader];
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn(columnName, typeof(string)));
				dataTable.Columns.Add(new DataColumn(columnName2, typeof(string)));
				foreach (string text in stringKeys)
				{
					if (!string.IsNullOrEmpty(text))
					{
						string value;
						if (!this.FindStringEntry(text, langCode, platform, out value))
						{
							throw new DataSourceException(string.Format("String not found for key \"{0}\".", text));
						}
						DataRow dataRow = dataTable.NewRow();
						dataRow[columnName] = text;
						dataRow[columnName2] = value;
						dataTable.Rows.Add(dataRow);
					}
				}
				this.WriteXMLFile(langCode, tableColHeader, dataTable, outputFile, false);
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Trying to save strings as XML. {0}", ex.Message));
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000743C File Offset: 0x0000643C
		private void Setup(string versionFileName)
		{
			string text = "-halconfig:";
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			string configFilename = string.Empty;
			foreach (string text2 in commandLineArgs)
			{
				if (text2.ToLower().Contains(text))
				{
					configFilename = text2.Substring(text2.ToLower().IndexOf(text) + text.Length);
					break;
				}
			}
			if (HALConfiguration.ReadConfigurationFile(configFilename, versionFileName))
			{
				this.m_HALWebService = new HALLOKIWebService();
				Authentication authentication = new Authentication();
				authentication.User = HALConfiguration.MainConfiguration.Username;
				authentication.Password = HALConfiguration.MainConfiguration.Password;
				this.m_HALWebService.AuthenticationValue = authentication;
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.STRINGID.ToString(), "StringKey");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.COMMENT.ToString(), "Comment");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.STATUS.ToString(), "Status");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.LEGAL.ToString(), "Legal");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.GUIDELINE.ToString(), "Guideline");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.MAXLENGTH.ToString(), "MaxLength");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.COMMON.ToString(), "Text [Common]");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.PC.ToString(), "Text [PC]");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.XBOX360.ToString(), "Text [Xbox360]");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.PS3.ToString(), "Text [PS3]");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.VERSIONNUMBER.ToString(), "VersionNumber");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.PRODUCTIONSTATUS.ToString(), "ProdStatus");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.DONOTTRANSLATE.ToString(), "DNT");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.SOURCETEXT.ToString(), "Text [Common]");
				this.m_ColumnDictionary.Add(HALLayer.HALTableColumns.PRODUCTIONSTATUSNAME.ToString(), "ProdStatus");
				this.mReservedPrefixes.Add("Download");
				this.mReservedPrefixes.Add("Sims3Launcher");
				this.mReservedPrefixes.Add("Medator");
				this.mReservedPrefixes.Add("Jazz");
				this.mReservedPrefixes.Add("WorldBuilder");
				this.mReservedPrefixes.Add("Sims3Mac");
				return;
			}
			throw new DataSourceException("Cannot read HAL configuration file");
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x000076F4 File Offset: 0x000066F4
		private void RenameColumnHeaders(DataTable table)
		{
			foreach (object obj in table.Columns)
			{
				DataColumn dataColumn = (DataColumn)obj;
				if (this.m_ColumnDictionary.ContainsKey(dataColumn.ColumnName))
				{
					dataColumn.ColumnName = this.m_ColumnDictionary[dataColumn.ColumnName];
				}
			}
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00007770 File Offset: 0x00006770
		private void DeleteUnusedColumnHeaders(DataTable table)
		{
			if (!this.m_bReturnComment && table.Columns.Contains(HALLayer.HALTableColumns.COMMENT.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.COMMENT.ToString());
			}
			if (!this.m_bReturnStatus && table.Columns.Contains(HALLayer.HALTableColumns.STATUS.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.STATUS.ToString());
			}
			if (!this.m_bReturnLegal && table.Columns.Contains(HALLayer.HALTableColumns.LEGAL.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.LEGAL.ToString());
			}
			if (!this.m_bReturnGuideline && table.Columns.Contains(HALLayer.HALTableColumns.GUIDELINE.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.GUIDELINE.ToString());
			}
			if (!this.m_bReturnMaxLength && table.Columns.Contains(HALLayer.HALTableColumns.MAXLENGTH.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.MAXLENGTH.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.SCREENNAME.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.SCREENNAME.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.CATEGORYNAME.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.CATEGORYNAME.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.SUBCATEGORYNAME.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.SUBCATEGORYNAME.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.STRINGIDCODE.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.STRINGIDCODE.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.SOURCESTATUSNAME.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.SOURCESTATUSNAME.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.LANGUAGESHORTNAME.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.LANGUAGESHORTNAME.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.LANGUAGETEXT.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.LANGUAGETEXT.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.CATEGORYCODE.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.CATEGORYCODE.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.LANGUAGECODE.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.LANGUAGECODE.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.LANGUAGETEXTCODE.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.LANGUAGETEXTCODE.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.STATUSCODE.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.STATUSCODE.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.PLATFORMNAME.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.PLATFORMNAME.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.ISAUDIOSCRIPT.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.ISAUDIOSCRIPT.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.CBOX.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.CBOX.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.STRINGIDTEXTPART.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.STRINGIDTEXTPART.ToString());
			}
			if (table.Columns.Contains(HALLayer.HALTableColumns.STRINGIDNUMERICPART.ToString()))
			{
				table.Columns.Remove(HALLayer.HALTableColumns.STRINGIDNUMERICPART.ToString());
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00007B8C File Offset: 0x00006B8C
		private HALLayer.HALPlatform[] GetPlatformCodes()
		{
			List<HALLayer.HALPlatform> list = new List<HALLayer.HALPlatform>();
			string a = null;
			string text = null;
			DataSet dataSet = null;
			try
			{
				dataSet = this.m_HALWebService.GetPlatformsInProduct(HALConfiguration.MainConfiguration.ProductCode, ref a, ref text);
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Could not retrieve platforms from HAL.\n\nHAL returned message - '{0}'", ex.Message));
			}
			if (a == "0" && text == "Success" && dataSet.Tables.Count == 1)
			{
				using (IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DataRow dataRow = (DataRow)obj;
						list.Add(new HALLayer.HALPlatform((string)dataRow["PLATFORMNAME"], Convert.ToInt32(dataRow["PLATFORMCODE"])));
					}
					goto IL_F5;
				}
				goto IL_E4;
				IL_F5:
				return list.ToArray();
			}
			IL_E4:
			throw new DataSourceException(string.Format("Could not retrieve platforms from HAL. {0}", text));
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00007CB0 File Offset: 0x00006CB0
		private string WriteXMLFile(string langCode, TableColHeader platform, DataTable table, string outputFile, bool skipDownloadStrings)
		{
			XmlTextWriter xmlTextWriter = null;
			try
			{
				xmlTextWriter = new XmlTextWriter(outputFile, Encoding.BigEndianUnicode);
			}
			catch (Exception ex)
			{
				throw new DataSourceException(string.Format("Could not open XML file '{0}'. Error Message {1}", outputFile, ex.Message));
			}
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.Namespaces = false;
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("StringTable");
			xmlTextWriter.WriteAttributeString("", "Version", "", XmlConvert.ToString(2.0));
			xmlTextWriter.WriteStartElement("Platform");
			xmlTextWriter.WriteAttributeString("", "Platform", "", platform.ToString());
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("LanguageID");
			xmlTextWriter.WriteAttributeString("Language", langCode);
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("PackageName");
			xmlTextWriter.WriteAttributeString("Name", HALConfiguration.MainConfiguration.PackageName);
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteStartElement("Strings");
			foreach (object obj in table.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				string text = dataRow[StringDataSource.HeadersDict[TableColHeader.StringKey]] as string;
				if (skipDownloadStrings)
				{
					bool flag = false;
					foreach (string value in this.mReservedPrefixes)
					{
						if (text.StartsWith(value))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
				}
				xmlTextWriter.WriteStartElement("String");
				xmlTextWriter.WriteAttributeString("", "Key", "", text);
				xmlTextWriter.WriteStartElement("Content");
				xmlTextWriter.WriteAttributeString("", "Text", "", dataRow[StringDataSource.HeadersDict[platform]].ToString());
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteEndElement();
			}
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			try
			{
				xmlTextWriter.Close();
			}
			catch (InvalidOperationException ex2)
			{
				throw new DataSourceException(string.Format("Could not write XML file. Invalid operation exception", ex2.Message));
			}
			return outputFile;
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00007F18 File Offset: 0x00006F18
		private void GetAllStringsForLanguageAndPlatformsASyncCompleted(object sender, GetAllStrings_WithProductionStatuses_SIMS3CompletedEventArgs e)
		{
			StringQueryResult stringQueryResult = new StringQueryResult();
			if (e.Error != null)
			{
				stringQueryResult.error = e.Error.Message;
			}
			else if (e.retCode == "0" && e.Result.Tables.Count >= 1)
			{
				stringQueryResult.table = e.Result.Tables[0].Clone();
				foreach (DataRow row in e.Result.Tables[0].Select(string.Empty, HALLayer.HALTableColumns.STRINGID.ToString() + " ASC"))
				{
					stringQueryResult.table.ImportRow(row);
				}
				this.DeleteUnusedColumnHeaders(stringQueryResult.table);
				this.RenameColumnHeaders(stringQueryResult.table);
			}
			if (this.OnQueryStringCompleted != null)
			{
				this.OnQueryStringCompleted(stringQueryResult);
			}
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000800C File Offset: 0x0000700C
		private static TableColHeader GetTableColHeader(Platform platform, string outputFile)
		{
			TableColHeader result = TableColHeader.PC;
			if (platform == Platform.COMMON)
			{
				result = TableColHeader.Common;
			}
			else if (platform == Platform.PC)
			{
				result = TableColHeader.PC;
			}
			else if (platform == Platform.XBOX360)
			{
				result = TableColHeader.Xbox360;
			}
			else if (platform == Platform.PS3)
			{
				result = TableColHeader.PS3;
			}
			return result;
		}

		// Token: 0x0400005F RID: 95
		private const double XML_VERSION = 2.0;

		// Token: 0x04000060 RID: 96
		private const bool m_bReturnCategoryNames = false;

		// Token: 0x04000061 RID: 97
		private bool m_bReturnComment = true;

		// Token: 0x04000062 RID: 98
		private bool m_bReturnStatus = true;

		// Token: 0x04000063 RID: 99
		private bool m_bReturnLegal;

		// Token: 0x04000064 RID: 100
		private bool m_bReturnGuideline;

		// Token: 0x04000065 RID: 101
		private bool m_bReturnMaxLength;

		// Token: 0x04000066 RID: 102
		private Dictionary<string, string> m_ColumnDictionary = new Dictionary<string, string>();

		// Token: 0x04000067 RID: 103
		private List<string> mReservedPrefixes = new List<string>();

		// Token: 0x04000068 RID: 104
		private HALLOKIWebService m_HALWebService;

		// Token: 0x02000042 RID: 66
		private struct HALPlatform
		{
			// Token: 0x060001D8 RID: 472 RVA: 0x0000803B File Offset: 0x0000703B
			public HALPlatform(string name, int code)
			{
				this.platformName = name;
				this.platformCode = code;
			}

			// Token: 0x0400006A RID: 106
			public string platformName;

			// Token: 0x0400006B RID: 107
			public int platformCode;
		}

		// Token: 0x02000043 RID: 67
		private struct GetAllStringsParameters
		{
			// Token: 0x060001D9 RID: 473 RVA: 0x0000804B File Offset: 0x0000704B
			public GetAllStringsParameters(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, string retCode, string retString)
			{
				this.GameProductCode = GameProductCode;
				this.LanguageList = LanguageList;
				this.PlatformList = PlatformList;
				this.CategoryNames = CategoryNames;
				this.RetCode = retCode;
				this.RetString = retString;
			}

			// Token: 0x0400006C RID: 108
			public int GameProductCode;

			// Token: 0x0400006D RID: 109
			public string LanguageList;

			// Token: 0x0400006E RID: 110
			public string PlatformList;

			// Token: 0x0400006F RID: 111
			public string CategoryNames;

			// Token: 0x04000070 RID: 112
			public string RetCode;

			// Token: 0x04000071 RID: 113
			public string RetString;
		}

		// Token: 0x02000044 RID: 68
		private enum HALTableColumns
		{
			// Token: 0x04000073 RID: 115
			STRINGID,
			// Token: 0x04000074 RID: 116
			COMMENT,
			// Token: 0x04000075 RID: 117
			STATUS,
			// Token: 0x04000076 RID: 118
			LEGAL,
			// Token: 0x04000077 RID: 119
			GUIDELINE,
			// Token: 0x04000078 RID: 120
			MAXLENGTH,
			// Token: 0x04000079 RID: 121
			COMMON,
			// Token: 0x0400007A RID: 122
			PC,
			// Token: 0x0400007B RID: 123
			XBOX360,
			// Token: 0x0400007C RID: 124
			PS3,
			// Token: 0x0400007D RID: 125
			CATEGORYNAME,
			// Token: 0x0400007E RID: 126
			SUBCATEGORYNAME,
			// Token: 0x0400007F RID: 127
			SCREENNAME,
			// Token: 0x04000080 RID: 128
			VERSIONNUMBER,
			// Token: 0x04000081 RID: 129
			DONOTTRANSLATE,
			// Token: 0x04000082 RID: 130
			PRODUCTIONSTATUS,
			// Token: 0x04000083 RID: 131
			SOURCETEXT,
			// Token: 0x04000084 RID: 132
			PRODUCTIONSTATUSNAME,
			// Token: 0x04000085 RID: 133
			STRINGIDCODE,
			// Token: 0x04000086 RID: 134
			SOURCESTATUSNAME,
			// Token: 0x04000087 RID: 135
			LANGUAGETEXT,
			// Token: 0x04000088 RID: 136
			CATEGORYCODE,
			// Token: 0x04000089 RID: 137
			LANGUAGESHORTNAME,
			// Token: 0x0400008A RID: 138
			LANGUAGECODE,
			// Token: 0x0400008B RID: 139
			LANGUAGETEXTCODE,
			// Token: 0x0400008C RID: 140
			STATUSCODE,
			// Token: 0x0400008D RID: 141
			PLATFORMNAME,
			// Token: 0x0400008E RID: 142
			ISAUDIOSCRIPT,
			// Token: 0x0400008F RID: 143
			CBOX,
			// Token: 0x04000090 RID: 144
			STRINGIDTEXTPART,
			// Token: 0x04000091 RID: 145
			STRINGIDNUMERICPART
		}
	}
}
