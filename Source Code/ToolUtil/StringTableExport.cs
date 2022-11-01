using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using Sims3.LDAL;
using Sims3.Metadata;

namespace ToolUtil
{
	// Token: 0x0200000C RID: 12
	public class StringTableExport
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00003784 File Offset: 0x00002784
		public StringTableExport(bool allLanguages)
		{
			if (allLanguages)
			{
				ILDAL instance = StringDataSource.Instance;
				this.mLanguages = instance.GetLanguagesShortNames();
				return;
			}
			this.mLanguages = new string[1];
			this.mLanguages[0] = "ENG_US";
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000037C8 File Offset: 0x000027C8
		public bool Export(string[] stringKeys, IStringTableWriter writer, StringTableLog log)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			return this.Export(stringKeys, writer, string.Empty, string.Empty, ref dictionary, ref dictionary, log);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000037F4 File Offset: 0x000027F4
		public bool Export(string[] stringKeys, IStringTableWriter writer, string nameKey, string descriptionKey, ref Dictionary<string, string> names, ref Dictionary<string, string> descriptions, StringTableLog log)
		{
			ILDAL instance = StringDataSource.Instance;
			Platform currentPlatform = LocalizationDataCache.CurrentPlatform;
			int num = 1;
			foreach (string text in this.mLanguages)
			{
				log(string.Format("    Language {0} of {1}: {2}", num, this.mLanguages.Length, text));
				num++;
				string text2 = string.Format("{0}Strings_{1}_{2}.strxml", Path.GetTempPath(), text, currentPlatform);
				try
				{
					this.SaveStringsAsXML(text, currentPlatform, text2, stringKeys);
				}
				catch (SecurityException ex)
				{
					log("Could not save XML string table (SecurityException): " + ex.Message);
					return false;
				}
				catch (DataSourceException ex2)
				{
					log("Could not save XML string table (DataSourceException): " + ex2.Message);
					return false;
				}
				try
				{
					writer.WriteStringTableResource(text2);
				}
				catch (Exception ex3)
				{
					log(string.Format("Could not write string table from XML file {0}: {1}", text2, ex3.Message));
					return false;
				}
				try
				{
					File.Delete(text2);
				}
				catch (Exception ex4)
				{
					log(string.Format("Could not delete temp file {0}: {1}", text2, ex4.Message));
					return false;
				}
				string value;
				if (!string.IsNullOrEmpty(nameKey) && instance.FindStringEntry(nameKey, text, currentPlatform, out value))
				{
					names[text] = value;
				}
				string value2;
				if (!string.IsNullOrEmpty(descriptionKey) && instance.FindStringEntry(descriptionKey, text, currentPlatform, out value2))
				{
					descriptions[text] = value2;
				}
			}
			return true;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003998 File Offset: 0x00002998
		protected virtual void SaveStringsAsXML(string language, Platform platform, string outputFile, string[] stringKeys)
		{
			StringDataSource.Instance.SaveStringsAsXML(language, platform, outputFile, stringKeys);
		}

		// Token: 0x04000026 RID: 38
		public const string en_us = "ENG_US";

		// Token: 0x04000027 RID: 39
		protected readonly string[] mLanguages;
	}
}
