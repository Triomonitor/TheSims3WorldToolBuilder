using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Sims3.DbDataLayer.Properties
{
	// Token: 0x0200000B RID: 11
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x0000582B File Offset: 0x0000482B
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00005832 File Offset: 0x00004832
		[DebuggerNonUserCode]
		[SpecialSetting(SpecialSetting.WebServiceUrl)]
		[DefaultSettingValue("http://ears-simssql.rws.ad.ea.com/Sims3MetaDev/Sims3DBWS.asmx")]
		[ApplicationScopedSetting]
		public string DbDataLayer_Sims3WebService_Sims3DBWS
		{
			get
			{
				return (string)this["DbDataLayer_Sims3WebService_Sims3DBWS"];
			}
		}

		// Token: 0x0400002F RID: 47
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
