using System;
using System.Collections.Generic;
using System.Data;
using Sims3.LDAL;

namespace ToolUtil
{
	// Token: 0x0200000D RID: 13
	public class WorldStringTableExport : StringTableExport
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000039AC File Offset: 0x000029AC
		public WorldStringTableExport(bool allLanguages) : base(allLanguages)
		{
			ILDAL instance = StringDataSource.Instance;
			foreach (string text in this.mLanguages)
			{
				DataTable allStringsForLanguageAndPlatforms = instance.GetAllStringsForLanguageAndPlatforms(text, Platform.COMMON);
				this.mStringTables[text] = allStringsForLanguageAndPlatforms;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003A08 File Offset: 0x00002A08
		protected override void SaveStringsAsXML(string language, Platform platform, string outputFile, string[] stringKeys)
		{
			DataTable table = this.mStringTables[language];
			DataRowCollection rows = this.mStringTables[language].Rows;
			List<string> list = new List<string>(stringKeys);
			for (int i = rows.Count - 1; i >= 0; i--)
			{
				DataRow dataRow = rows[i];
				if (!list.Contains(dataRow["StringKey"].ToString()))
				{
					rows.Remove(dataRow);
				}
			}
			StringDataSource.Instance.SaveStringsAsXML(language, platform, outputFile, table);
		}

		// Token: 0x04000028 RID: 40
		private Dictionary<string, DataTable> mStringTables = new Dictionary<string, DataTable>();
	}
}
