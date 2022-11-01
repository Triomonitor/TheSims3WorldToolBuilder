using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Sims3.LDAL.Properties
{
	// Token: 0x02000045 RID: 69
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001DA RID: 474 RVA: 0x0000807A File Offset: 0x0000707A
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00008081 File Offset: 0x00007081
		[DefaultSettingValue("http://eahq-wwhalweb1/webservicehalloki/hallokiwebservice.asmx")]
		[DebuggerNonUserCode]
		[SpecialSetting(SpecialSetting.WebServiceUrl)]
		[ApplicationScopedSetting]
		public string DataSource
		{
			get
			{
				return (string)this["DataSource"];
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00008093 File Offset: 0x00007093
		// (set) Token: 0x060001DD RID: 477 RVA: 0x000080A5 File Offset: 0x000070A5
		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("18")]
		public int ProductCode
		{
			get
			{
				return (int)this["ProductCode"];
			}
			set
			{
				this["ProductCode"] = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001DE RID: 478 RVA: 0x000080B8 File Offset: 0x000070B8
		// (set) Token: 0x060001DF RID: 479 RVA: 0x000080CA File Offset: 0x000070CA
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("64")]
		public int CategoryCode
		{
			get
			{
				return (int)this["CategoryCode"];
			}
			set
			{
				this["CategoryCode"] = value;
			}
		}

		// Token: 0x04000092 RID: 146
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
