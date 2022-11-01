using System;
using System.Collections.Generic;
using System.Data;

namespace Sims3.LDAL
{
	// Token: 0x02000040 RID: 64
	public interface ILDAL
	{
		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060001A6 RID: 422
		// (remove) Token: 0x060001A7 RID: 423
		event QueryStringCompletedHandler OnQueryStringCompleted;

		// Token: 0x060001A8 RID: 424
		string GetServerName();

		// Token: 0x060001A9 RID: 425
		string[] GetLanguagesLongNames();

		// Token: 0x060001AA RID: 426
		string[] GetLanguagesShortNames();

		// Token: 0x060001AB RID: 427
		string[] GetPlatformsLongNames();

		// Token: 0x060001AC RID: 428
		DataTable GetAllStringsForLanguageAndPlatforms(string langCode, Platform platforms);

		// Token: 0x060001AD RID: 429
		void GetAllStringsForLanguageAndPlatformsAsync(string langCode, Platform platforms);

		// Token: 0x060001AE RID: 430
		bool FindStringEntry(string stringKey, string locale, Platform platform, out string text, out string comment, out ProductionStatus status, out int versionNumber);

		// Token: 0x060001AF RID: 431
		bool FindStringEntry(string stringKey, string locale, Platform platform, out string text);

		// Token: 0x060001B0 RID: 432
		bool FindAllStringEntries(string stringKey, string locale, Platform platform, out List<string> text, out List<string> comment, out List<ProductionStatus> status, out List<int> versionNumber, out List<string> fullKey);

		// Token: 0x060001B1 RID: 433
		DataTable FindAllStringEntries(string stringKey, string locale, Platform platform);

		// Token: 0x060001B2 RID: 434
		void SetColumnOptions(bool bRetStatus, bool bRetComment, bool bRetLegal, bool bRetGuideline, bool bRetMaxLength);

		// Token: 0x060001B3 RID: 435
		void CreateNewStringEntry(string stringKey, string stringText, string comment, Platform platform, ProductionStatus productionStatus, bool bDNT);

		// Token: 0x060001B4 RID: 436
		void EditStringEntry(string stringKey, string stringText, string comment, ProductionStatus productionStatus, bool bDNT, Platform platform, int versionNumber);

		// Token: 0x060001B5 RID: 437
		void DeleteStringEntry(string stringKey, Platform platform);

		// Token: 0x060001B6 RID: 438
		void RenameStringEntry(string oldStringKey, string newStringKey, Platform platform);

		// Token: 0x060001B7 RID: 439
		void SaveStringsAsXML(string langCode, Platform platform, string outputFile, string[] stringKeys);

		// Token: 0x060001B8 RID: 440
		void SaveStringsAsXML(string langCode, Platform platform, string outputFile);

		// Token: 0x060001B9 RID: 441
		void SaveStringsAsXML(string langCode, Platform platform, string outputFile, DataTable table);
	}
}
