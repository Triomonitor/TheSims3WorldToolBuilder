using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000002 RID: 2
	[WebServiceBinding(Name = "HALLOKIWebServiceSoap", Namespace = "http://tempuri.org/")]
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	public class HALLOKIWebService : SoapHttpClientProtocol
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		public HALLOKIWebService()
		{
			this.Url = "http://hal.ea.com/webservicehalloki/hallokiwebservice.asmx";
			if (this.IsLocalFileSystemWebService(this.Url))
			{
				this.UseDefaultCredentials = true;
				this.useDefaultCredentialsSetExplicitly = false;
				return;
			}
			this.useDefaultCredentialsSetExplicitly = true;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002087 File Offset: 0x00001087
		// (set) Token: 0x06000003 RID: 3 RVA: 0x0000208F File Offset: 0x0000108F
		public Authentication AuthenticationValue
		{
			get
			{
				return this.authenticationValueField;
			}
			set
			{
				this.authenticationValueField = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002098 File Offset: 0x00001098
		// (set) Token: 0x06000005 RID: 5 RVA: 0x000020A0 File Offset: 0x000010A0
		public new string Url
		{
			get
			{
				return base.Url;
			}
			set
			{
				if (this.IsLocalFileSystemWebService(base.Url) && !this.useDefaultCredentialsSetExplicitly && !this.IsLocalFileSystemWebService(value))
				{
					base.UseDefaultCredentials = false;
				}
				base.Url = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020CF File Offset: 0x000010CF
		// (set) Token: 0x06000007 RID: 7 RVA: 0x000020D7 File Offset: 0x000010D7
		public new bool UseDefaultCredentials
		{
			get
			{
				return base.UseDefaultCredentials;
			}
			set
			{
				base.UseDefaultCredentials = value;
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000008 RID: 8 RVA: 0x000020E7 File Offset: 0x000010E7
		// (remove) Token: 0x06000009 RID: 9 RVA: 0x00002100 File Offset: 0x00001100
		public event GetServerTimeCompletedEventHandler GetServerTimeCompleted;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600000A RID: 10 RVA: 0x00002119 File Offset: 0x00001119
		// (remove) Token: 0x0600000B RID: 11 RVA: 0x00002132 File Offset: 0x00001132
		public event GetAllProductsCompletedEventHandler GetAllProductsCompleted;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600000C RID: 12 RVA: 0x0000214B File Offset: 0x0000114B
		// (remove) Token: 0x0600000D RID: 13 RVA: 0x00002164 File Offset: 0x00001164
		public event GetLanguagesInProductCompletedEventHandler GetLanguagesInProductCompleted;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600000E RID: 14 RVA: 0x0000217D File Offset: 0x0000117D
		// (remove) Token: 0x0600000F RID: 15 RVA: 0x00002196 File Offset: 0x00001196
		public event GetPlatformsInProductCompletedEventHandler GetPlatformsInProductCompleted;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000010 RID: 16 RVA: 0x000021AF File Offset: 0x000011AF
		// (remove) Token: 0x06000011 RID: 17 RVA: 0x000021C8 File Offset: 0x000011C8
		public event GetAllAudioStrings_SpecifyReturnFieldsCompletedEventHandler GetAllAudioStrings_SpecifyReturnFieldsCompleted;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000012 RID: 18 RVA: 0x000021E1 File Offset: 0x000011E1
		// (remove) Token: 0x06000013 RID: 19 RVA: 0x000021FA File Offset: 0x000011FA
		public event GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTCompletedEventHandler GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTCompleted;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000014 RID: 20 RVA: 0x00002213 File Offset: 0x00001213
		// (remove) Token: 0x06000015 RID: 21 RVA: 0x0000222C File Offset: 0x0000122C
		public event GetAllStringsCompletedEventHandler GetAllStringsCompleted;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000016 RID: 22 RVA: 0x00002245 File Offset: 0x00001245
		// (remove) Token: 0x06000017 RID: 23 RVA: 0x0000225E File Offset: 0x0000125E
		public event GetAllStrings_WithProductionStatusesAndDNTCompletedEventHandler GetAllStrings_WithProductionStatusesAndDNTCompleted;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000018 RID: 24 RVA: 0x00002277 File Offset: 0x00001277
		// (remove) Token: 0x06000019 RID: 25 RVA: 0x00002290 File Offset: 0x00001290
		public event GetAllStrings_WithVersionNumberCompletedEventHandler GetAllStrings_WithVersionNumberCompleted;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x0600001A RID: 26 RVA: 0x000022A9 File Offset: 0x000012A9
		// (remove) Token: 0x0600001B RID: 27 RVA: 0x000022C2 File Offset: 0x000012C2
		public event GetAllStrings_WithVersionNumber_SIMS3CompletedEventHandler GetAllStrings_WithVersionNumber_SIMS3Completed;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600001C RID: 28 RVA: 0x000022DB File Offset: 0x000012DB
		// (remove) Token: 0x0600001D RID: 29 RVA: 0x000022F4 File Offset: 0x000012F4
		public event GetAllStrings_WithProductionStatuses_SIMS3CompletedEventHandler GetAllStrings_WithProductionStatuses_SIMS3Completed;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600001E RID: 30 RVA: 0x0000230D File Offset: 0x0000130D
		// (remove) Token: 0x0600001F RID: 31 RVA: 0x00002326 File Offset: 0x00001326
		public event GetAllStrings_SpecifyReturnFieldsCompletedEventHandler GetAllStrings_SpecifyReturnFieldsCompleted;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000020 RID: 32 RVA: 0x0000233F File Offset: 0x0000133F
		// (remove) Token: 0x06000021 RID: 33 RVA: 0x00002358 File Offset: 0x00001358
		public event GetAllStrings_WithVersionNumber_SpecifyReturnFieldsCompletedEventHandler GetAllStrings_WithVersionNumber_SpecifyReturnFieldsCompleted;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000022 RID: 34 RVA: 0x00002371 File Offset: 0x00001371
		// (remove) Token: 0x06000023 RID: 35 RVA: 0x0000238A File Offset: 0x0000138A
		public event GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsCompletedEventHandler GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsCompleted;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000024 RID: 36 RVA: 0x000023A3 File Offset: 0x000013A3
		// (remove) Token: 0x06000025 RID: 37 RVA: 0x000023BC File Offset: 0x000013BC
		public event GetStringsCompletedEventHandler GetStringsCompleted;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000026 RID: 38 RVA: 0x000023D5 File Offset: 0x000013D5
		// (remove) Token: 0x06000027 RID: 39 RVA: 0x000023EE File Offset: 0x000013EE
		public event CreateNewStringCompletedEventHandler CreateNewStringCompleted;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000028 RID: 40 RVA: 0x00002407 File Offset: 0x00001407
		// (remove) Token: 0x06000029 RID: 41 RVA: 0x00002420 File Offset: 0x00001420
		public event CreateNewAudioScriptCompletedEventHandler CreateNewAudioScriptCompleted;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600002A RID: 42 RVA: 0x00002439 File Offset: 0x00001439
		// (remove) Token: 0x0600002B RID: 43 RVA: 0x00002452 File Offset: 0x00001452
		public event RenameStringIdCompletedEventHandler RenameStringIdCompleted;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600002C RID: 44 RVA: 0x0000246B File Offset: 0x0000146B
		// (remove) Token: 0x0600002D RID: 45 RVA: 0x00002484 File Offset: 0x00001484
		public event UpdateSourceStringCompletedEventHandler UpdateSourceStringCompleted;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x0600002E RID: 46 RVA: 0x0000249D File Offset: 0x0000149D
		// (remove) Token: 0x0600002F RID: 47 RVA: 0x000024B6 File Offset: 0x000014B6
		public event UpdateSourceString_IncludingDNTCompletedEventHandler UpdateSourceString_IncludingDNTCompleted;

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000030 RID: 48 RVA: 0x000024CF File Offset: 0x000014CF
		// (remove) Token: 0x06000031 RID: 49 RVA: 0x000024E8 File Offset: 0x000014E8
		public event UpdateAudioScriptCompletedEventHandler UpdateAudioScriptCompleted;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000032 RID: 50 RVA: 0x00002501 File Offset: 0x00001501
		// (remove) Token: 0x06000033 RID: 51 RVA: 0x0000251A File Offset: 0x0000151A
		public event UpdateAudioScript_IncludingDNTCompletedEventHandler UpdateAudioScript_IncludingDNTCompleted;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000034 RID: 52 RVA: 0x00002533 File Offset: 0x00001533
		// (remove) Token: 0x06000035 RID: 53 RVA: 0x0000254C File Offset: 0x0000154C
		public event DeleteStringCompletedEventHandler DeleteStringCompleted;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000036 RID: 54 RVA: 0x00002565 File Offset: 0x00001565
		// (remove) Token: 0x06000037 RID: 55 RVA: 0x0000257E File Offset: 0x0000157E
		public event GetCategoriesInProductCompletedEventHandler GetCategoriesInProductCompleted;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x06000038 RID: 56 RVA: 0x00002597 File Offset: 0x00001597
		// (remove) Token: 0x06000039 RID: 57 RVA: 0x000025B0 File Offset: 0x000015B0
		public event SetStringsWithSplittingCompletedEventHandler SetStringsWithSplittingCompleted;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x0600003A RID: 58 RVA: 0x000025C9 File Offset: 0x000015C9
		// (remove) Token: 0x0600003B RID: 59 RVA: 0x000025E2 File Offset: 0x000015E2
		public event SetStringsWithSplittingAndMergingCompletedEventHandler SetStringsWithSplittingAndMergingCompleted;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x0600003C RID: 60 RVA: 0x000025FB File Offset: 0x000015FB
		// (remove) Token: 0x0600003D RID: 61 RVA: 0x00002614 File Offset: 0x00001614
		public event BasicSearchCompletedEventHandler BasicSearchCompleted;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x0600003E RID: 62 RVA: 0x0000262D File Offset: 0x0000162D
		// (remove) Token: 0x0600003F RID: 63 RVA: 0x00002646 File Offset: 0x00001646
		public event ExactWordSearchCompletedEventHandler ExactWordSearchCompleted;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000040 RID: 64 RVA: 0x0000265F File Offset: 0x0000165F
		// (remove) Token: 0x06000041 RID: 65 RVA: 0x00002678 File Offset: 0x00001678
		public event BasicSearch_TextAndAudioCompletedEventHandler BasicSearch_TextAndAudioCompleted;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06000042 RID: 66 RVA: 0x00002691 File Offset: 0x00001691
		// (remove) Token: 0x06000043 RID: 67 RVA: 0x000026AA File Offset: 0x000016AA
		public event MergeStringsCompletedEventHandler MergeStringsCompleted;

		// Token: 0x06000044 RID: 68 RVA: 0x000026C4 File Offset: 0x000016C4
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/GetServerTime", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string GetServerTime()
		{
			object[] array = base.Invoke("GetServerTime", new object[0]);
			return (string)array[0];
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000026EB File Offset: 0x000016EB
		public void GetServerTimeAsync()
		{
			this.GetServerTimeAsync(null);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000026F4 File Offset: 0x000016F4
		public void GetServerTimeAsync(object userState)
		{
			if (this.GetServerTimeOperationCompleted == null)
			{
				this.GetServerTimeOperationCompleted = new SendOrPostCallback(this.OnGetServerTimeOperationCompleted);
			}
			base.InvokeAsync("GetServerTime", new object[0], this.GetServerTimeOperationCompleted, userState);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002728 File Offset: 0x00001728
		private void OnGetServerTimeOperationCompleted(object arg)
		{
			if (this.GetServerTimeCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetServerTimeCompleted(this, new GetServerTimeCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002770 File Offset: 0x00001770
		[SoapDocumentMethod("http://tempuri.org/GetAllProducts", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public DataSet GetAllProducts(ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetAllProducts", new object[]
			{
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000027B7 File Offset: 0x000017B7
		public void GetAllProductsAsync(string retCode, string retString)
		{
			this.GetAllProductsAsync(retCode, retString, null);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000027C4 File Offset: 0x000017C4
		public void GetAllProductsAsync(string retCode, string retString, object userState)
		{
			if (this.GetAllProductsOperationCompleted == null)
			{
				this.GetAllProductsOperationCompleted = new SendOrPostCallback(this.OnGetAllProductsOperationCompleted);
			}
			base.InvokeAsync("GetAllProducts", new object[]
			{
				retCode,
				retString
			}, this.GetAllProductsOperationCompleted, userState);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002810 File Offset: 0x00001810
		private void OnGetAllProductsOperationCompleted(object arg)
		{
			if (this.GetAllProductsCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllProductsCompleted(this, new GetAllProductsCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002858 File Offset: 0x00001858
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/GetLanguagesInProduct", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public DataSet GetLanguagesInProduct(int GameProductCode, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetLanguagesInProduct", new object[]
			{
				GameProductCode,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000028A8 File Offset: 0x000018A8
		public void GetLanguagesInProductAsync(int GameProductCode, string retCode, string retString)
		{
			this.GetLanguagesInProductAsync(GameProductCode, retCode, retString, null);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000028B4 File Offset: 0x000018B4
		public void GetLanguagesInProductAsync(int GameProductCode, string retCode, string retString, object userState)
		{
			if (this.GetLanguagesInProductOperationCompleted == null)
			{
				this.GetLanguagesInProductOperationCompleted = new SendOrPostCallback(this.OnGetLanguagesInProductOperationCompleted);
			}
			base.InvokeAsync("GetLanguagesInProduct", new object[]
			{
				GameProductCode,
				retCode,
				retString
			}, this.GetLanguagesInProductOperationCompleted, userState);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002908 File Offset: 0x00001908
		private void OnGetLanguagesInProductOperationCompleted(object arg)
		{
			if (this.GetLanguagesInProductCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetLanguagesInProductCompleted(this, new GetLanguagesInProductCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002950 File Offset: 0x00001950
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/GetPlatformsInProduct", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public DataSet GetPlatformsInProduct(int GameProductCode, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetPlatformsInProduct", new object[]
			{
				GameProductCode,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000029A0 File Offset: 0x000019A0
		public void GetPlatformsInProductAsync(int GameProductCode, string retCode, string retString)
		{
			this.GetPlatformsInProductAsync(GameProductCode, retCode, retString, null);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000029AC File Offset: 0x000019AC
		public void GetPlatformsInProductAsync(int GameProductCode, string retCode, string retString, object userState)
		{
			if (this.GetPlatformsInProductOperationCompleted == null)
			{
				this.GetPlatformsInProductOperationCompleted = new SendOrPostCallback(this.OnGetPlatformsInProductOperationCompleted);
			}
			base.InvokeAsync("GetPlatformsInProduct", new object[]
			{
				GameProductCode,
				retCode,
				retString
			}, this.GetPlatformsInProductOperationCompleted, userState);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002A00 File Offset: 0x00001A00
		private void OnGetPlatformsInProductOperationCompleted(object arg)
		{
			if (this.GetPlatformsInProductCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetPlatformsInProductCompleted(this, new GetPlatformsInProductCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002A48 File Offset: 0x00001A48
		[SoapDocumentMethod("http://tempuri.org/GetAllAudioStrings_SpecifyReturnFields", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public DataSet GetAllAudioStrings_SpecifyReturnFields(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, bool AudioStatusCode, bool AudioRecordingType, bool ReturnAudioFileName, bool ReturnRecordingType, bool ReturnVoiceProfile, bool ReturnCharacterName, bool ReturnVoiceDirection, bool ReturnLineType, bool ReturnLineUsage, bool ReturnStitched, bool ReturnAudioProcessing, bool ReturnTimeCode, bool ReturnRecordingSetup, bool ReturnSpokenLanguage, bool ReturnSequenceOrder, bool InsertIntoSequence, bool ReturnAsRecorded, bool ReturnCustomField_1, bool ReturnCustomField_2, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetAllAudioStrings_SpecifyReturnFields", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				ReturnCategoryName,
				ReturnStatus,
				ReturnLegal,
				ReturnGuideline,
				ReturnMaxLength,
				ReturnScreenname,
				ReturnComment,
				ReturnVersionNumber,
				AudioStatusCode,
				AudioRecordingType,
				ReturnAudioFileName,
				ReturnRecordingType,
				ReturnVoiceProfile,
				ReturnCharacterName,
				ReturnVoiceDirection,
				ReturnLineType,
				ReturnLineUsage,
				ReturnStitched,
				ReturnAudioProcessing,
				ReturnTimeCode,
				ReturnRecordingSetup,
				ReturnSpokenLanguage,
				ReturnSequenceOrder,
				InsertIntoSequence,
				ReturnAsRecorded,
				ReturnCustomField_1,
				ReturnCustomField_2,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002BD0 File Offset: 0x00001BD0
		public void GetAllAudioStrings_SpecifyReturnFieldsAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, bool AudioStatusCode, bool AudioRecordingType, bool ReturnAudioFileName, bool ReturnRecordingType, bool ReturnVoiceProfile, bool ReturnCharacterName, bool ReturnVoiceDirection, bool ReturnLineType, bool ReturnLineUsage, bool ReturnStitched, bool ReturnAudioProcessing, bool ReturnTimeCode, bool ReturnRecordingSetup, bool ReturnSpokenLanguage, bool ReturnSequenceOrder, bool InsertIntoSequence, bool ReturnAsRecorded, bool ReturnCustomField_1, bool ReturnCustomField_2, string retCode, string retString)
		{
			this.GetAllAudioStrings_SpecifyReturnFieldsAsync(GameProductCode, LanguageList, PlatformList, CategoryNames, ReturnCategoryName, ReturnStatus, ReturnLegal, ReturnGuideline, ReturnMaxLength, ReturnScreenname, ReturnComment, ReturnVersionNumber, AudioStatusCode, AudioRecordingType, ReturnAudioFileName, ReturnRecordingType, ReturnVoiceProfile, ReturnCharacterName, ReturnVoiceDirection, ReturnLineType, ReturnLineUsage, ReturnStitched, ReturnAudioProcessing, ReturnTimeCode, ReturnRecordingSetup, ReturnSpokenLanguage, ReturnSequenceOrder, InsertIntoSequence, ReturnAsRecorded, ReturnCustomField_1, ReturnCustomField_2, retCode, retString, null);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002C24 File Offset: 0x00001C24
		public void GetAllAudioStrings_SpecifyReturnFieldsAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, bool AudioStatusCode, bool AudioRecordingType, bool ReturnAudioFileName, bool ReturnRecordingType, bool ReturnVoiceProfile, bool ReturnCharacterName, bool ReturnVoiceDirection, bool ReturnLineType, bool ReturnLineUsage, bool ReturnStitched, bool ReturnAudioProcessing, bool ReturnTimeCode, bool ReturnRecordingSetup, bool ReturnSpokenLanguage, bool ReturnSequenceOrder, bool InsertIntoSequence, bool ReturnAsRecorded, bool ReturnCustomField_1, bool ReturnCustomField_2, string retCode, string retString, object userState)
		{
			if (this.GetAllAudioStrings_SpecifyReturnFieldsOperationCompleted == null)
			{
				this.GetAllAudioStrings_SpecifyReturnFieldsOperationCompleted = new SendOrPostCallback(this.OnGetAllAudioStrings_SpecifyReturnFieldsOperationCompleted);
			}
			base.InvokeAsync("GetAllAudioStrings_SpecifyReturnFields", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				ReturnCategoryName,
				ReturnStatus,
				ReturnLegal,
				ReturnGuideline,
				ReturnMaxLength,
				ReturnScreenname,
				ReturnComment,
				ReturnVersionNumber,
				AudioStatusCode,
				AudioRecordingType,
				ReturnAudioFileName,
				ReturnRecordingType,
				ReturnVoiceProfile,
				ReturnCharacterName,
				ReturnVoiceDirection,
				ReturnLineType,
				ReturnLineUsage,
				ReturnStitched,
				ReturnAudioProcessing,
				ReturnTimeCode,
				ReturnRecordingSetup,
				ReturnSpokenLanguage,
				ReturnSequenceOrder,
				InsertIntoSequence,
				ReturnAsRecorded,
				ReturnCustomField_1,
				ReturnCustomField_2,
				retCode,
				retString
			}, this.GetAllAudioStrings_SpecifyReturnFieldsOperationCompleted, userState);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002DB0 File Offset: 0x00001DB0
		private void OnGetAllAudioStrings_SpecifyReturnFieldsOperationCompleted(object arg)
		{
			if (this.GetAllAudioStrings_SpecifyReturnFieldsCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllAudioStrings_SpecifyReturnFieldsCompleted(this, new GetAllAudioStrings_SpecifyReturnFieldsCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002DF8 File Offset: 0x00001DF8
		[SoapDocumentMethod("http://tempuri.org/GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNT", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public DataSet GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNT(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, bool ReturnProductionStatus, bool ReturnDNT, bool AudioStatusCode, bool AudioRecordingType, bool ReturnAudioFileName, bool ReturnRecordingType, bool ReturnVoiceProfile, bool ReturnCharacterName, bool ReturnVoiceDirection, bool ReturnLineType, bool ReturnLineUsage, bool ReturnStitched, bool ReturnAudioProcessing, bool ReturnTimeCode, bool ReturnRecordingSetup, bool ReturnSpokenLanguage, bool ReturnSequenceOrder, bool InsertIntoSequence, bool ReturnAsRecorded, bool ReturnCustomField_1, bool ReturnCustomField_2, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNT", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				ReturnCategoryName,
				ReturnStatus,
				ReturnLegal,
				ReturnGuideline,
				ReturnMaxLength,
				ReturnScreenname,
				ReturnComment,
				ReturnVersionNumber,
				ReturnProductionStatus,
				ReturnDNT,
				AudioStatusCode,
				AudioRecordingType,
				ReturnAudioFileName,
				ReturnRecordingType,
				ReturnVoiceProfile,
				ReturnCharacterName,
				ReturnVoiceDirection,
				ReturnLineType,
				ReturnLineUsage,
				ReturnStitched,
				ReturnAudioProcessing,
				ReturnTimeCode,
				ReturnRecordingSetup,
				ReturnSpokenLanguage,
				ReturnSequenceOrder,
				InsertIntoSequence,
				ReturnAsRecorded,
				ReturnCustomField_1,
				ReturnCustomField_2,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002F98 File Offset: 0x00001F98
		public void GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, bool ReturnProductionStatus, bool ReturnDNT, bool AudioStatusCode, bool AudioRecordingType, bool ReturnAudioFileName, bool ReturnRecordingType, bool ReturnVoiceProfile, bool ReturnCharacterName, bool ReturnVoiceDirection, bool ReturnLineType, bool ReturnLineUsage, bool ReturnStitched, bool ReturnAudioProcessing, bool ReturnTimeCode, bool ReturnRecordingSetup, bool ReturnSpokenLanguage, bool ReturnSequenceOrder, bool InsertIntoSequence, bool ReturnAsRecorded, bool ReturnCustomField_1, bool ReturnCustomField_2, string retCode, string retString)
		{
			this.GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTAsync(GameProductCode, LanguageList, PlatformList, CategoryNames, ReturnCategoryName, ReturnStatus, ReturnLegal, ReturnGuideline, ReturnMaxLength, ReturnScreenname, ReturnComment, ReturnVersionNumber, ReturnProductionStatus, ReturnDNT, AudioStatusCode, AudioRecordingType, ReturnAudioFileName, ReturnRecordingType, ReturnVoiceProfile, ReturnCharacterName, ReturnVoiceDirection, ReturnLineType, ReturnLineUsage, ReturnStitched, ReturnAudioProcessing, ReturnTimeCode, ReturnRecordingSetup, ReturnSpokenLanguage, ReturnSequenceOrder, InsertIntoSequence, ReturnAsRecorded, ReturnCustomField_1, ReturnCustomField_2, retCode, retString, null);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002FF0 File Offset: 0x00001FF0
		public void GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, bool ReturnProductionStatus, bool ReturnDNT, bool AudioStatusCode, bool AudioRecordingType, bool ReturnAudioFileName, bool ReturnRecordingType, bool ReturnVoiceProfile, bool ReturnCharacterName, bool ReturnVoiceDirection, bool ReturnLineType, bool ReturnLineUsage, bool ReturnStitched, bool ReturnAudioProcessing, bool ReturnTimeCode, bool ReturnRecordingSetup, bool ReturnSpokenLanguage, bool ReturnSequenceOrder, bool InsertIntoSequence, bool ReturnAsRecorded, bool ReturnCustomField_1, bool ReturnCustomField_2, string retCode, string retString, object userState)
		{
			if (this.GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTOperationCompleted == null)
			{
				this.GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTOperationCompleted = new SendOrPostCallback(this.OnGetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTOperationCompleted);
			}
			base.InvokeAsync("GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNT", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				ReturnCategoryName,
				ReturnStatus,
				ReturnLegal,
				ReturnGuideline,
				ReturnMaxLength,
				ReturnScreenname,
				ReturnComment,
				ReturnVersionNumber,
				ReturnProductionStatus,
				ReturnDNT,
				AudioStatusCode,
				AudioRecordingType,
				ReturnAudioFileName,
				ReturnRecordingType,
				ReturnVoiceProfile,
				ReturnCharacterName,
				ReturnVoiceDirection,
				ReturnLineType,
				ReturnLineUsage,
				ReturnStitched,
				ReturnAudioProcessing,
				ReturnTimeCode,
				ReturnRecordingSetup,
				ReturnSpokenLanguage,
				ReturnSequenceOrder,
				InsertIntoSequence,
				ReturnAsRecorded,
				ReturnCustomField_1,
				ReturnCustomField_2,
				retCode,
				retString
			}, this.GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTOperationCompleted, userState);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003190 File Offset: 0x00002190
		private void OnGetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTOperationCompleted(object arg)
		{
			if (this.GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTCompleted(this, new GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000031D8 File Offset: 0x000021D8
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/GetAllStrings", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public DataSet GetAllStrings(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetAllStrings", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003239 File Offset: 0x00002239
		public void GetAllStringsAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, string retCode, string retString)
		{
			this.GetAllStringsAsync(GameProductCode, LanguageList, PlatformList, CategoryNames, retCode, retString, null);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000324C File Offset: 0x0000224C
		public void GetAllStringsAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, string retCode, string retString, object userState)
		{
			if (this.GetAllStringsOperationCompleted == null)
			{
				this.GetAllStringsOperationCompleted = new SendOrPostCallback(this.OnGetAllStringsOperationCompleted);
			}
			base.InvokeAsync("GetAllStrings", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				retCode,
				retString
			}, this.GetAllStringsOperationCompleted, userState);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000032B0 File Offset: 0x000022B0
		private void OnGetAllStringsOperationCompleted(object arg)
		{
			if (this.GetAllStringsCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllStringsCompleted(this, new GetAllStringsCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000032F8 File Offset: 0x000022F8
		[SoapDocumentMethod("http://tempuri.org/GetAllStrings_WithProductionStatusesAndDNT", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public DataSet GetAllStrings_WithProductionStatusesAndDNT(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetAllStrings_WithProductionStatusesAndDNT", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003359 File Offset: 0x00002359
		public void GetAllStrings_WithProductionStatusesAndDNTAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, string retCode, string retString)
		{
			this.GetAllStrings_WithProductionStatusesAndDNTAsync(GameProductCode, LanguageList, PlatformList, CategoryNames, retCode, retString, null);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000336C File Offset: 0x0000236C
		public void GetAllStrings_WithProductionStatusesAndDNTAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, string retCode, string retString, object userState)
		{
			if (this.GetAllStrings_WithProductionStatusesAndDNTOperationCompleted == null)
			{
				this.GetAllStrings_WithProductionStatusesAndDNTOperationCompleted = new SendOrPostCallback(this.OnGetAllStrings_WithProductionStatusesAndDNTOperationCompleted);
			}
			base.InvokeAsync("GetAllStrings_WithProductionStatusesAndDNT", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				retCode,
				retString
			}, this.GetAllStrings_WithProductionStatusesAndDNTOperationCompleted, userState);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000033D0 File Offset: 0x000023D0
		private void OnGetAllStrings_WithProductionStatusesAndDNTOperationCompleted(object arg)
		{
			if (this.GetAllStrings_WithProductionStatusesAndDNTCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllStrings_WithProductionStatusesAndDNTCompleted(this, new GetAllStrings_WithProductionStatusesAndDNTCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003418 File Offset: 0x00002418
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/GetAllStrings_WithVersionNumber", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public DataSet GetAllStrings_WithVersionNumber(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetAllStrings_WithVersionNumber", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003479 File Offset: 0x00002479
		public void GetAllStrings_WithVersionNumberAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, string retCode, string retString)
		{
			this.GetAllStrings_WithVersionNumberAsync(GameProductCode, LanguageList, PlatformList, CategoryNames, retCode, retString, null);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000348C File Offset: 0x0000248C
		public void GetAllStrings_WithVersionNumberAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, string retCode, string retString, object userState)
		{
			if (this.GetAllStrings_WithVersionNumberOperationCompleted == null)
			{
				this.GetAllStrings_WithVersionNumberOperationCompleted = new SendOrPostCallback(this.OnGetAllStrings_WithVersionNumberOperationCompleted);
			}
			base.InvokeAsync("GetAllStrings_WithVersionNumber", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				retCode,
				retString
			}, this.GetAllStrings_WithVersionNumberOperationCompleted, userState);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000034F0 File Offset: 0x000024F0
		private void OnGetAllStrings_WithVersionNumberOperationCompleted(object arg)
		{
			if (this.GetAllStrings_WithVersionNumberCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllStrings_WithVersionNumberCompleted(this, new GetAllStrings_WithVersionNumberCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003538 File Offset: 0x00002538
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/GetAllStrings_WithVersionNumber_SIMS3", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public DataSet GetAllStrings_WithVersionNumber_SIMS3(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetAllStrings_WithVersionNumber_SIMS3", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003599 File Offset: 0x00002599
		public void GetAllStrings_WithVersionNumber_SIMS3Async(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, string retCode, string retString)
		{
			this.GetAllStrings_WithVersionNumber_SIMS3Async(GameProductCode, LanguageList, PlatformList, CategoryNames, retCode, retString, null);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000035AC File Offset: 0x000025AC
		public void GetAllStrings_WithVersionNumber_SIMS3Async(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, string retCode, string retString, object userState)
		{
			if (this.GetAllStrings_WithVersionNumber_SIMS3OperationCompleted == null)
			{
				this.GetAllStrings_WithVersionNumber_SIMS3OperationCompleted = new SendOrPostCallback(this.OnGetAllStrings_WithVersionNumber_SIMS3OperationCompleted);
			}
			base.InvokeAsync("GetAllStrings_WithVersionNumber_SIMS3", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				retCode,
				retString
			}, this.GetAllStrings_WithVersionNumber_SIMS3OperationCompleted, userState);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003610 File Offset: 0x00002610
		private void OnGetAllStrings_WithVersionNumber_SIMS3OperationCompleted(object arg)
		{
			if (this.GetAllStrings_WithVersionNumber_SIMS3Completed != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllStrings_WithVersionNumber_SIMS3Completed(this, new GetAllStrings_WithVersionNumber_SIMS3CompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003658 File Offset: 0x00002658
		[SoapDocumentMethod("http://tempuri.org/GetAllStrings_WithProductionStatuses_SIMS3", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public DataSet GetAllStrings_WithProductionStatuses_SIMS3(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetAllStrings_WithProductionStatuses_SIMS3", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000036B9 File Offset: 0x000026B9
		public void GetAllStrings_WithProductionStatuses_SIMS3Async(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, string retCode, string retString)
		{
			this.GetAllStrings_WithProductionStatuses_SIMS3Async(GameProductCode, LanguageList, PlatformList, CategoryNames, retCode, retString, null);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000036CC File Offset: 0x000026CC
		public void GetAllStrings_WithProductionStatuses_SIMS3Async(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, string retCode, string retString, object userState)
		{
			if (this.GetAllStrings_WithProductionStatuses_SIMS3OperationCompleted == null)
			{
				this.GetAllStrings_WithProductionStatuses_SIMS3OperationCompleted = new SendOrPostCallback(this.OnGetAllStrings_WithProductionStatuses_SIMS3OperationCompleted);
			}
			base.InvokeAsync("GetAllStrings_WithProductionStatuses_SIMS3", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				retCode,
				retString
			}, this.GetAllStrings_WithProductionStatuses_SIMS3OperationCompleted, userState);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003730 File Offset: 0x00002730
		private void OnGetAllStrings_WithProductionStatuses_SIMS3OperationCompleted(object arg)
		{
			if (this.GetAllStrings_WithProductionStatuses_SIMS3Completed != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllStrings_WithProductionStatuses_SIMS3Completed(this, new GetAllStrings_WithProductionStatuses_SIMS3CompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003778 File Offset: 0x00002778
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/GetAllStrings_SpecifyReturnFields", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public DataSet GetAllStrings_SpecifyReturnFields(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetAllStrings_SpecifyReturnFields", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				ReturnCategoryName,
				ReturnStatus,
				ReturnLegal,
				ReturnGuideline,
				ReturnMaxLength,
				ReturnScreenname,
				ReturnComment,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003824 File Offset: 0x00002824
		public void GetAllStrings_SpecifyReturnFieldsAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, string retCode, string retString)
		{
			this.GetAllStrings_SpecifyReturnFieldsAsync(GameProductCode, LanguageList, PlatformList, CategoryNames, ReturnCategoryName, ReturnStatus, ReturnLegal, ReturnGuideline, ReturnMaxLength, ReturnScreenname, ReturnComment, retCode, retString, null);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003850 File Offset: 0x00002850
		public void GetAllStrings_SpecifyReturnFieldsAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, string retCode, string retString, object userState)
		{
			if (this.GetAllStrings_SpecifyReturnFieldsOperationCompleted == null)
			{
				this.GetAllStrings_SpecifyReturnFieldsOperationCompleted = new SendOrPostCallback(this.OnGetAllStrings_SpecifyReturnFieldsOperationCompleted);
			}
			base.InvokeAsync("GetAllStrings_SpecifyReturnFields", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				ReturnCategoryName,
				ReturnStatus,
				ReturnLegal,
				ReturnGuideline,
				ReturnMaxLength,
				ReturnScreenname,
				ReturnComment,
				retCode,
				retString
			}, this.GetAllStrings_SpecifyReturnFieldsOperationCompleted, userState);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003900 File Offset: 0x00002900
		private void OnGetAllStrings_SpecifyReturnFieldsOperationCompleted(object arg)
		{
			if (this.GetAllStrings_SpecifyReturnFieldsCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllStrings_SpecifyReturnFieldsCompleted(this, new GetAllStrings_SpecifyReturnFieldsCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003948 File Offset: 0x00002948
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/GetAllStrings_WithVersionNumber_SpecifyReturnFields", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public DataSet GetAllStrings_WithVersionNumber_SpecifyReturnFields(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetAllStrings_WithVersionNumber_SpecifyReturnFields", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				ReturnCategoryName,
				ReturnStatus,
				ReturnLegal,
				ReturnGuideline,
				ReturnMaxLength,
				ReturnScreenname,
				ReturnComment,
				ReturnVersionNumber,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003A00 File Offset: 0x00002A00
		public void GetAllStrings_WithVersionNumber_SpecifyReturnFieldsAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, string retCode, string retString)
		{
			this.GetAllStrings_WithVersionNumber_SpecifyReturnFieldsAsync(GameProductCode, LanguageList, PlatformList, CategoryNames, ReturnCategoryName, ReturnStatus, ReturnLegal, ReturnGuideline, ReturnMaxLength, ReturnScreenname, ReturnComment, ReturnVersionNumber, retCode, retString, null);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003A30 File Offset: 0x00002A30
		public void GetAllStrings_WithVersionNumber_SpecifyReturnFieldsAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, string retCode, string retString, object userState)
		{
			if (this.GetAllStrings_WithVersionNumber_SpecifyReturnFieldsOperationCompleted == null)
			{
				this.GetAllStrings_WithVersionNumber_SpecifyReturnFieldsOperationCompleted = new SendOrPostCallback(this.OnGetAllStrings_WithVersionNumber_SpecifyReturnFieldsOperationCompleted);
			}
			base.InvokeAsync("GetAllStrings_WithVersionNumber_SpecifyReturnFields", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				ReturnCategoryName,
				ReturnStatus,
				ReturnLegal,
				ReturnGuideline,
				ReturnMaxLength,
				ReturnScreenname,
				ReturnComment,
				ReturnVersionNumber,
				retCode,
				retString
			}, this.GetAllStrings_WithVersionNumber_SpecifyReturnFieldsOperationCompleted, userState);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003AE8 File Offset: 0x00002AE8
		private void OnGetAllStrings_WithVersionNumber_SpecifyReturnFieldsOperationCompleted(object arg)
		{
			if (this.GetAllStrings_WithVersionNumber_SpecifyReturnFieldsCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllStrings_WithVersionNumber_SpecifyReturnFieldsCompleted(this, new GetAllStrings_WithVersionNumber_SpecifyReturnFieldsCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003B30 File Offset: 0x00002B30
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFields", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public DataSet GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFields(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, bool ReturnProductionStatus, bool ReturnDNT, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFields", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				ReturnCategoryName,
				ReturnStatus,
				ReturnLegal,
				ReturnGuideline,
				ReturnMaxLength,
				ReturnScreenname,
				ReturnComment,
				ReturnVersionNumber,
				ReturnProductionStatus,
				ReturnDNT,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003C00 File Offset: 0x00002C00
		public void GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, bool ReturnProductionStatus, bool ReturnDNT, string retCode, string retString)
		{
			this.GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsAsync(GameProductCode, LanguageList, PlatformList, CategoryNames, ReturnCategoryName, ReturnStatus, ReturnLegal, ReturnGuideline, ReturnMaxLength, ReturnScreenname, ReturnComment, ReturnVersionNumber, ReturnProductionStatus, ReturnDNT, retCode, retString, null);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003C34 File Offset: 0x00002C34
		public void GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsAsync(int GameProductCode, string LanguageList, string PlatformList, string CategoryNames, bool ReturnCategoryName, bool ReturnStatus, bool ReturnLegal, bool ReturnGuideline, bool ReturnMaxLength, bool ReturnScreenname, bool ReturnComment, bool ReturnVersionNumber, bool ReturnProductionStatus, bool ReturnDNT, string retCode, string retString, object userState)
		{
			if (this.GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsOperationCompleted == null)
			{
				this.GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsOperationCompleted = new SendOrPostCallback(this.OnGetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsOperationCompleted);
			}
			base.InvokeAsync("GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFields", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				CategoryNames,
				ReturnCategoryName,
				ReturnStatus,
				ReturnLegal,
				ReturnGuideline,
				ReturnMaxLength,
				ReturnScreenname,
				ReturnComment,
				ReturnVersionNumber,
				ReturnProductionStatus,
				ReturnDNT,
				retCode,
				retString
			}, this.GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsOperationCompleted, userState);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003D04 File Offset: 0x00002D04
		private void OnGetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsOperationCompleted(object arg)
		{
			if (this.GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsCompleted(this, new GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003D4C File Offset: 0x00002D4C
		[SoapDocumentMethod("http://tempuri.org/GetStrings", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public DataSet GetStrings(int GameProductCode, string LanguageList, string PlatformList, DateTime LastUpdated, string CategoryNames, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetStrings", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				LastUpdated,
				CategoryNames,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003DB8 File Offset: 0x00002DB8
		public void GetStringsAsync(int GameProductCode, string LanguageList, string PlatformList, DateTime LastUpdated, string CategoryNames, string retCode, string retString)
		{
			this.GetStringsAsync(GameProductCode, LanguageList, PlatformList, LastUpdated, CategoryNames, retCode, retString, null);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003DD8 File Offset: 0x00002DD8
		public void GetStringsAsync(int GameProductCode, string LanguageList, string PlatformList, DateTime LastUpdated, string CategoryNames, string retCode, string retString, object userState)
		{
			if (this.GetStringsOperationCompleted == null)
			{
				this.GetStringsOperationCompleted = new SendOrPostCallback(this.OnGetStringsOperationCompleted);
			}
			base.InvokeAsync("GetStrings", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				LastUpdated,
				CategoryNames,
				retCode,
				retString
			}, this.GetStringsOperationCompleted, userState);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003E44 File Offset: 0x00002E44
		private void OnGetStringsOperationCompleted(object arg)
		{
			if (this.GetStringsCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetStringsCompleted(this, new GetStringsCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003E8C File Offset: 0x00002E8C
		[SoapDocumentMethod("http://tempuri.org/CreateNewString", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public string CreateNewString(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, ref string retString)
		{
			object[] array = base.Invoke("CreateNewString", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				retString
			});
			retString = (string)array[1];
			return (string)array[0];
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003F08 File Offset: 0x00002F08
		public void CreateNewStringAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, string retString)
		{
			this.CreateNewStringAsync(GameProductCode, CategoryCode, stringid, sourceText, platforms, platformDelimiter, maxLength, screename, comment, guideline, retString, null);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003F30 File Offset: 0x00002F30
		public void CreateNewStringAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, string retString, object userState)
		{
			if (this.CreateNewStringOperationCompleted == null)
			{
				this.CreateNewStringOperationCompleted = new SendOrPostCallback(this.OnCreateNewStringOperationCompleted);
			}
			base.InvokeAsync("CreateNewString", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				retString
			}, this.CreateNewStringOperationCompleted, userState);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003FB8 File Offset: 0x00002FB8
		private void OnCreateNewStringOperationCompleted(object arg)
		{
			if (this.CreateNewStringCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.CreateNewStringCompleted(this, new CreateNewStringCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00004000 File Offset: 0x00003000
		[SoapDocumentMethod("http://tempuri.org/CreateNewAudioScript", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public string CreateNewAudioScript(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, string Status, string AudioFileName, string RecordingType, string VoiceProfile, string CharacterName, string VoiceDirection, string LineType, string LineUsage, string Stitched, string AudioProcessing, string TimeCode, string RecordingSetup, string SpokenLanguage, string AudioStatus, string SequenceOrder, bool InsertIntoSequence, string AsRecorded, string CustomField_1, string CustomField_2, ref string retString)
		{
			object[] array = base.Invoke("CreateNewAudioScript", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				Status,
				AudioFileName,
				RecordingType,
				VoiceProfile,
				CharacterName,
				VoiceDirection,
				LineType,
				LineUsage,
				Stitched,
				AudioProcessing,
				TimeCode,
				RecordingSetup,
				SpokenLanguage,
				AudioStatus,
				SequenceOrder,
				InsertIntoSequence,
				AsRecorded,
				CustomField_1,
				CustomField_2,
				retString
			});
			retString = (string)array[1];
			return (string)array[0];
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000040F4 File Offset: 0x000030F4
		public void CreateNewAudioScriptAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, string Status, string AudioFileName, string RecordingType, string VoiceProfile, string CharacterName, string VoiceDirection, string LineType, string LineUsage, string Stitched, string AudioProcessing, string TimeCode, string RecordingSetup, string SpokenLanguage, string AudioStatus, string SequenceOrder, bool InsertIntoSequence, string AsRecorded, string CustomField_1, string CustomField_2, string retString)
		{
			this.CreateNewAudioScriptAsync(GameProductCode, CategoryCode, stringid, sourceText, platforms, platformDelimiter, maxLength, screename, comment, guideline, Status, AudioFileName, RecordingType, VoiceProfile, CharacterName, VoiceDirection, LineType, LineUsage, Stitched, AudioProcessing, TimeCode, RecordingSetup, SpokenLanguage, AudioStatus, SequenceOrder, InsertIntoSequence, AsRecorded, CustomField_1, CustomField_2, retString, null);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004144 File Offset: 0x00003144
		public void CreateNewAudioScriptAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, string Status, string AudioFileName, string RecordingType, string VoiceProfile, string CharacterName, string VoiceDirection, string LineType, string LineUsage, string Stitched, string AudioProcessing, string TimeCode, string RecordingSetup, string SpokenLanguage, string AudioStatus, string SequenceOrder, bool InsertIntoSequence, string AsRecorded, string CustomField_1, string CustomField_2, string retString, object userState)
		{
			if (this.CreateNewAudioScriptOperationCompleted == null)
			{
				this.CreateNewAudioScriptOperationCompleted = new SendOrPostCallback(this.OnCreateNewAudioScriptOperationCompleted);
			}
			base.InvokeAsync("CreateNewAudioScript", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				Status,
				AudioFileName,
				RecordingType,
				VoiceProfile,
				CharacterName,
				VoiceDirection,
				LineType,
				LineUsage,
				Stitched,
				AudioProcessing,
				TimeCode,
				RecordingSetup,
				SpokenLanguage,
				AudioStatus,
				SequenceOrder,
				InsertIntoSequence,
				AsRecorded,
				CustomField_1,
				CustomField_2,
				retString
			}, this.CreateNewAudioScriptOperationCompleted, userState);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004244 File Offset: 0x00003244
		private void OnCreateNewAudioScriptOperationCompleted(object arg)
		{
			if (this.CreateNewAudioScriptCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.CreateNewAudioScriptCompleted(this, new CreateNewAudioScriptCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000428C File Offset: 0x0000328C
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/RenameStringId", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string RenameStringId(int GameProductCode, string platforms, string platformDelmiter, string oldStringId, string newStringId, ref string retString)
		{
			object[] array = base.Invoke("RenameStringId", new object[]
			{
				GameProductCode,
				platforms,
				platformDelmiter,
				oldStringId,
				newStringId,
				retString
			});
			retString = (string)array[1];
			return (string)array[0];
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000042E1 File Offset: 0x000032E1
		public void RenameStringIdAsync(int GameProductCode, string platforms, string platformDelmiter, string oldStringId, string newStringId, string retString)
		{
			this.RenameStringIdAsync(GameProductCode, platforms, platformDelmiter, oldStringId, newStringId, retString, null);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000042F4 File Offset: 0x000032F4
		public void RenameStringIdAsync(int GameProductCode, string platforms, string platformDelmiter, string oldStringId, string newStringId, string retString, object userState)
		{
			if (this.RenameStringIdOperationCompleted == null)
			{
				this.RenameStringIdOperationCompleted = new SendOrPostCallback(this.OnRenameStringIdOperationCompleted);
			}
			base.InvokeAsync("RenameStringId", new object[]
			{
				GameProductCode,
				platforms,
				platformDelmiter,
				oldStringId,
				newStringId,
				retString
			}, this.RenameStringIdOperationCompleted, userState);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00004358 File Offset: 0x00003358
		private void OnRenameStringIdOperationCompleted(object arg)
		{
			if (this.RenameStringIdCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.RenameStringIdCompleted(this, new RenameStringIdCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000043A0 File Offset: 0x000033A0
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/UpdateSourceString", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string UpdateSourceString(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, ref string retString)
		{
			object[] array = base.Invoke("UpdateSourceString", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				legal,
				Status,
				VersionNumber,
				retString
			});
			retString = (string)array[1];
			return (string)array[0];
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000443C File Offset: 0x0000343C
		public void UpdateSourceStringAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, string retString)
		{
			this.UpdateSourceStringAsync(GameProductCode, CategoryCode, stringid, sourceText, platforms, platformDelimiter, maxLength, screename, comment, guideline, legal, Status, VersionNumber, retString, null);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000446C File Offset: 0x0000346C
		public void UpdateSourceStringAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, string retString, object userState)
		{
			if (this.UpdateSourceStringOperationCompleted == null)
			{
				this.UpdateSourceStringOperationCompleted = new SendOrPostCallback(this.OnUpdateSourceStringOperationCompleted);
			}
			base.InvokeAsync("UpdateSourceString", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				legal,
				Status,
				VersionNumber,
				retString
			}, this.UpdateSourceStringOperationCompleted, userState);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004518 File Offset: 0x00003518
		private void OnUpdateSourceStringOperationCompleted(object arg)
		{
			if (this.UpdateSourceStringCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.UpdateSourceStringCompleted(this, new UpdateSourceStringCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004560 File Offset: 0x00003560
		[SoapDocumentMethod("http://tempuri.org/UpdateSourceString_IncludingDNT", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public string UpdateSourceString_IncludingDNT(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, bool DNT, ref string retString)
		{
			object[] array = base.Invoke("UpdateSourceString_IncludingDNT", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				legal,
				Status,
				VersionNumber,
				DNT,
				retString
			});
			retString = (string)array[1];
			return (string)array[0];
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004608 File Offset: 0x00003608
		public void UpdateSourceString_IncludingDNTAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, bool DNT, string retString)
		{
			this.UpdateSourceString_IncludingDNTAsync(GameProductCode, CategoryCode, stringid, sourceText, platforms, platformDelimiter, maxLength, screename, comment, guideline, legal, Status, VersionNumber, DNT, retString, null);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004638 File Offset: 0x00003638
		public void UpdateSourceString_IncludingDNTAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, bool DNT, string retString, object userState)
		{
			if (this.UpdateSourceString_IncludingDNTOperationCompleted == null)
			{
				this.UpdateSourceString_IncludingDNTOperationCompleted = new SendOrPostCallback(this.OnUpdateSourceString_IncludingDNTOperationCompleted);
			}
			base.InvokeAsync("UpdateSourceString_IncludingDNT", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				legal,
				Status,
				VersionNumber,
				DNT,
				retString
			}, this.UpdateSourceString_IncludingDNTOperationCompleted, userState);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000046EC File Offset: 0x000036EC
		private void OnUpdateSourceString_IncludingDNTOperationCompleted(object arg)
		{
			if (this.UpdateSourceString_IncludingDNTCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.UpdateSourceString_IncludingDNTCompleted(this, new UpdateSourceString_IncludingDNTCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004734 File Offset: 0x00003734
		[SoapDocumentMethod("http://tempuri.org/UpdateAudioScript", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public string UpdateAudioScript(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, string AudioFileName, string RecordingType, string VoiceProfile, string CharacterName, string VoiceDirection, string LineType, string LineUsage, string Stitched, string AudioProcessing, string TimeCode, string RecordingSetup, string SpokenLanguage, string SequenceOrder, bool InsertIntoSequence, string AudioStatus, string AsRecorded, string CustomField_1, string CustomField_2, ref string retString)
		{
			object[] array = base.Invoke("UpdateAudioScript", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				legal,
				Status,
				VersionNumber,
				AudioFileName,
				RecordingType,
				VoiceProfile,
				CharacterName,
				VoiceDirection,
				LineType,
				LineUsage,
				Stitched,
				AudioProcessing,
				TimeCode,
				RecordingSetup,
				SpokenLanguage,
				SequenceOrder,
				InsertIntoSequence,
				AudioStatus,
				AsRecorded,
				CustomField_1,
				CustomField_2,
				retString
			});
			retString = (string)array[1];
			return (string)array[0];
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00004844 File Offset: 0x00003844
		public void UpdateAudioScriptAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, string AudioFileName, string RecordingType, string VoiceProfile, string CharacterName, string VoiceDirection, string LineType, string LineUsage, string Stitched, string AudioProcessing, string TimeCode, string RecordingSetup, string SpokenLanguage, string SequenceOrder, bool InsertIntoSequence, string AudioStatus, string AsRecorded, string CustomField_1, string CustomField_2, string retString)
		{
			this.UpdateAudioScriptAsync(GameProductCode, CategoryCode, stringid, sourceText, platforms, platformDelimiter, maxLength, screename, comment, guideline, legal, Status, VersionNumber, AudioFileName, RecordingType, VoiceProfile, CharacterName, VoiceDirection, LineType, LineUsage, Stitched, AudioProcessing, TimeCode, RecordingSetup, SpokenLanguage, SequenceOrder, InsertIntoSequence, AudioStatus, AsRecorded, CustomField_1, CustomField_2, retString, null);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004898 File Offset: 0x00003898
		public void UpdateAudioScriptAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, string AudioFileName, string RecordingType, string VoiceProfile, string CharacterName, string VoiceDirection, string LineType, string LineUsage, string Stitched, string AudioProcessing, string TimeCode, string RecordingSetup, string SpokenLanguage, string SequenceOrder, bool InsertIntoSequence, string AudioStatus, string AsRecorded, string CustomField_1, string CustomField_2, string retString, object userState)
		{
			if (this.UpdateAudioScriptOperationCompleted == null)
			{
				this.UpdateAudioScriptOperationCompleted = new SendOrPostCallback(this.OnUpdateAudioScriptOperationCompleted);
			}
			base.InvokeAsync("UpdateAudioScript", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				legal,
				Status,
				VersionNumber,
				AudioFileName,
				RecordingType,
				VoiceProfile,
				CharacterName,
				VoiceDirection,
				LineType,
				LineUsage,
				Stitched,
				AudioProcessing,
				TimeCode,
				RecordingSetup,
				SpokenLanguage,
				SequenceOrder,
				InsertIntoSequence,
				AudioStatus,
				AsRecorded,
				CustomField_1,
				CustomField_2,
				retString
			}, this.UpdateAudioScriptOperationCompleted, userState);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000049B4 File Offset: 0x000039B4
		private void OnUpdateAudioScriptOperationCompleted(object arg)
		{
			if (this.UpdateAudioScriptCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.UpdateAudioScriptCompleted(this, new UpdateAudioScriptCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000049FC File Offset: 0x000039FC
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/UpdateAudioScript_IncludingDNT", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string UpdateAudioScript_IncludingDNT(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, string AudioFileName, string RecordingType, string VoiceProfile, string CharacterName, string VoiceDirection, string LineType, string LineUsage, string Stitched, string AudioProcessing, string TimeCode, string RecordingSetup, string SpokenLanguage, string SequenceOrder, bool InsertIntoSequence, string AudioStatus, string AsRecorded, string CustomField_1, string CustomField_2, bool DNT, ref string retString)
		{
			object[] array = base.Invoke("UpdateAudioScript_IncludingDNT", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				legal,
				Status,
				VersionNumber,
				AudioFileName,
				RecordingType,
				VoiceProfile,
				CharacterName,
				VoiceDirection,
				LineType,
				LineUsage,
				Stitched,
				AudioProcessing,
				TimeCode,
				RecordingSetup,
				SpokenLanguage,
				SequenceOrder,
				InsertIntoSequence,
				AudioStatus,
				AsRecorded,
				CustomField_1,
				CustomField_2,
				DNT,
				retString
			});
			retString = (string)array[1];
			return (string)array[0];
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004B14 File Offset: 0x00003B14
		public void UpdateAudioScript_IncludingDNTAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, string AudioFileName, string RecordingType, string VoiceProfile, string CharacterName, string VoiceDirection, string LineType, string LineUsage, string Stitched, string AudioProcessing, string TimeCode, string RecordingSetup, string SpokenLanguage, string SequenceOrder, bool InsertIntoSequence, string AudioStatus, string AsRecorded, string CustomField_1, string CustomField_2, bool DNT, string retString)
		{
			this.UpdateAudioScript_IncludingDNTAsync(GameProductCode, CategoryCode, stringid, sourceText, platforms, platformDelimiter, maxLength, screename, comment, guideline, legal, Status, VersionNumber, AudioFileName, RecordingType, VoiceProfile, CharacterName, VoiceDirection, LineType, LineUsage, Stitched, AudioProcessing, TimeCode, RecordingSetup, SpokenLanguage, SequenceOrder, InsertIntoSequence, AudioStatus, AsRecorded, CustomField_1, CustomField_2, DNT, retString, null);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004B68 File Offset: 0x00003B68
		public void UpdateAudioScript_IncludingDNTAsync(int GameProductCode, int CategoryCode, string stringid, string sourceText, string platforms, string platformDelimiter, string maxLength, string screename, string comment, bool guideline, bool legal, int Status, int VersionNumber, string AudioFileName, string RecordingType, string VoiceProfile, string CharacterName, string VoiceDirection, string LineType, string LineUsage, string Stitched, string AudioProcessing, string TimeCode, string RecordingSetup, string SpokenLanguage, string SequenceOrder, bool InsertIntoSequence, string AudioStatus, string AsRecorded, string CustomField_1, string CustomField_2, bool DNT, string retString, object userState)
		{
			if (this.UpdateAudioScript_IncludingDNTOperationCompleted == null)
			{
				this.UpdateAudioScript_IncludingDNTOperationCompleted = new SendOrPostCallback(this.OnUpdateAudioScript_IncludingDNTOperationCompleted);
			}
			base.InvokeAsync("UpdateAudioScript_IncludingDNT", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				sourceText,
				platforms,
				platformDelimiter,
				maxLength,
				screename,
				comment,
				guideline,
				legal,
				Status,
				VersionNumber,
				AudioFileName,
				RecordingType,
				VoiceProfile,
				CharacterName,
				VoiceDirection,
				LineType,
				LineUsage,
				Stitched,
				AudioProcessing,
				TimeCode,
				RecordingSetup,
				SpokenLanguage,
				SequenceOrder,
				InsertIntoSequence,
				AudioStatus,
				AsRecorded,
				CustomField_1,
				CustomField_2,
				DNT,
				retString
			}, this.UpdateAudioScript_IncludingDNTOperationCompleted, userState);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004C90 File Offset: 0x00003C90
		private void OnUpdateAudioScript_IncludingDNTOperationCompleted(object arg)
		{
			if (this.UpdateAudioScript_IncludingDNTCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.UpdateAudioScript_IncludingDNTCompleted(this, new UpdateAudioScript_IncludingDNTCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004CD8 File Offset: 0x00003CD8
		[SoapDocumentMethod("http://tempuri.org/DeleteString", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public string DeleteString(int GameProductCode, int CategoryCode, string stringid, string platforms, string platformDelimiter, ref string retString)
		{
			object[] array = base.Invoke("DeleteString", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				platforms,
				platformDelimiter,
				retString
			});
			retString = (string)array[1];
			return (string)array[0];
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004D32 File Offset: 0x00003D32
		public void DeleteStringAsync(int GameProductCode, int CategoryCode, string stringid, string platforms, string platformDelimiter, string retString)
		{
			this.DeleteStringAsync(GameProductCode, CategoryCode, stringid, platforms, platformDelimiter, retString, null);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00004D44 File Offset: 0x00003D44
		public void DeleteStringAsync(int GameProductCode, int CategoryCode, string stringid, string platforms, string platformDelimiter, string retString, object userState)
		{
			if (this.DeleteStringOperationCompleted == null)
			{
				this.DeleteStringOperationCompleted = new SendOrPostCallback(this.OnDeleteStringOperationCompleted);
			}
			base.InvokeAsync("DeleteString", new object[]
			{
				GameProductCode,
				CategoryCode,
				stringid,
				platforms,
				platformDelimiter,
				retString
			}, this.DeleteStringOperationCompleted, userState);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004DAC File Offset: 0x00003DAC
		private void OnDeleteStringOperationCompleted(object arg)
		{
			if (this.DeleteStringCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.DeleteStringCompleted(this, new DeleteStringCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004DF4 File Offset: 0x00003DF4
		[SoapDocumentMethod("http://tempuri.org/GetCategoriesInProduct", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public DataSet GetCategoriesInProduct(int GameProductCode, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("GetCategoriesInProduct", new object[]
			{
				GameProductCode,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004E44 File Offset: 0x00003E44
		public void GetCategoriesInProductAsync(int GameProductCode, string retCode, string retString)
		{
			this.GetCategoriesInProductAsync(GameProductCode, retCode, retString, null);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004E50 File Offset: 0x00003E50
		public void GetCategoriesInProductAsync(int GameProductCode, string retCode, string retString, object userState)
		{
			if (this.GetCategoriesInProductOperationCompleted == null)
			{
				this.GetCategoriesInProductOperationCompleted = new SendOrPostCallback(this.OnGetCategoriesInProductOperationCompleted);
			}
			base.InvokeAsync("GetCategoriesInProduct", new object[]
			{
				GameProductCode,
				retCode,
				retString
			}, this.GetCategoriesInProductOperationCompleted, userState);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004EA4 File Offset: 0x00003EA4
		private void OnGetCategoriesInProductOperationCompleted(object arg)
		{
			if (this.GetCategoriesInProductCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetCategoriesInProductCompleted(this, new GetCategoriesInProductCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00004EEC File Offset: 0x00003EEC
		[SoapDocumentMethod("http://tempuri.org/SetStringsWithSplitting", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public string SetStringsWithSplitting(int GameProductCode, DataSet dsStrings, ref string retString)
		{
			object[] array = base.Invoke("SetStringsWithSplitting", new object[]
			{
				GameProductCode,
				dsStrings,
				retString
			});
			retString = (string)array[1];
			return (string)array[0];
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00004F31 File Offset: 0x00003F31
		public void SetStringsWithSplittingAsync(int GameProductCode, DataSet dsStrings, string retString)
		{
			this.SetStringsWithSplittingAsync(GameProductCode, dsStrings, retString, null);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00004F40 File Offset: 0x00003F40
		public void SetStringsWithSplittingAsync(int GameProductCode, DataSet dsStrings, string retString, object userState)
		{
			if (this.SetStringsWithSplittingOperationCompleted == null)
			{
				this.SetStringsWithSplittingOperationCompleted = new SendOrPostCallback(this.OnSetStringsWithSplittingOperationCompleted);
			}
			base.InvokeAsync("SetStringsWithSplitting", new object[]
			{
				GameProductCode,
				dsStrings,
				retString
			}, this.SetStringsWithSplittingOperationCompleted, userState);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004F94 File Offset: 0x00003F94
		private void OnSetStringsWithSplittingOperationCompleted(object arg)
		{
			if (this.SetStringsWithSplittingCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.SetStringsWithSplittingCompleted(this, new SetStringsWithSplittingCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00004FDC File Offset: 0x00003FDC
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/SetStringsWithSplittingAndMerging", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string SetStringsWithSplittingAndMerging(int GameProductCode, DataSet dsStrings, ref string retString)
		{
			object[] array = base.Invoke("SetStringsWithSplittingAndMerging", new object[]
			{
				GameProductCode,
				dsStrings,
				retString
			});
			retString = (string)array[1];
			return (string)array[0];
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00005021 File Offset: 0x00004021
		public void SetStringsWithSplittingAndMergingAsync(int GameProductCode, DataSet dsStrings, string retString)
		{
			this.SetStringsWithSplittingAndMergingAsync(GameProductCode, dsStrings, retString, null);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00005030 File Offset: 0x00004030
		public void SetStringsWithSplittingAndMergingAsync(int GameProductCode, DataSet dsStrings, string retString, object userState)
		{
			if (this.SetStringsWithSplittingAndMergingOperationCompleted == null)
			{
				this.SetStringsWithSplittingAndMergingOperationCompleted = new SendOrPostCallback(this.OnSetStringsWithSplittingAndMergingOperationCompleted);
			}
			base.InvokeAsync("SetStringsWithSplittingAndMerging", new object[]
			{
				GameProductCode,
				dsStrings,
				retString
			}, this.SetStringsWithSplittingAndMergingOperationCompleted, userState);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00005084 File Offset: 0x00004084
		private void OnSetStringsWithSplittingAndMergingOperationCompleted(object arg)
		{
			if (this.SetStringsWithSplittingAndMergingCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.SetStringsWithSplittingAndMergingCompleted(this, new SetStringsWithSplittingAndMergingCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000050CC File Offset: 0x000040CC
		[SoapDocumentMethod("http://tempuri.org/BasicSearch", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public DataSet BasicSearch(int GameProductCode, string LanguageList, string PlatformList, string StatusList, string SearchFields, string SearchText, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("BasicSearch", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				StatusList,
				SearchFields,
				SearchText,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00005138 File Offset: 0x00004138
		public void BasicSearchAsync(int GameProductCode, string LanguageList, string PlatformList, string StatusList, string SearchFields, string SearchText, string retCode, string retString)
		{
			this.BasicSearchAsync(GameProductCode, LanguageList, PlatformList, StatusList, SearchFields, SearchText, retCode, retString, null);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000515C File Offset: 0x0000415C
		public void BasicSearchAsync(int GameProductCode, string LanguageList, string PlatformList, string StatusList, string SearchFields, string SearchText, string retCode, string retString, object userState)
		{
			if (this.BasicSearchOperationCompleted == null)
			{
				this.BasicSearchOperationCompleted = new SendOrPostCallback(this.OnBasicSearchOperationCompleted);
			}
			base.InvokeAsync("BasicSearch", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				StatusList,
				SearchFields,
				SearchText,
				retCode,
				retString
			}, this.BasicSearchOperationCompleted, userState);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000051C8 File Offset: 0x000041C8
		private void OnBasicSearchOperationCompleted(object arg)
		{
			if (this.BasicSearchCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.BasicSearchCompleted(this, new BasicSearchCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00005210 File Offset: 0x00004210
		[SoapDocumentMethod("http://tempuri.org/ExactWordSearch", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public DataSet ExactWordSearch(int GameProductCode, string LanguageList, string PlatformList, string StatusList, string SearchFields, string SearchText, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("ExactWordSearch", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				StatusList,
				SearchFields,
				SearchText,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000527C File Offset: 0x0000427C
		public void ExactWordSearchAsync(int GameProductCode, string LanguageList, string PlatformList, string StatusList, string SearchFields, string SearchText, string retCode, string retString)
		{
			this.ExactWordSearchAsync(GameProductCode, LanguageList, PlatformList, StatusList, SearchFields, SearchText, retCode, retString, null);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000052A0 File Offset: 0x000042A0
		public void ExactWordSearchAsync(int GameProductCode, string LanguageList, string PlatformList, string StatusList, string SearchFields, string SearchText, string retCode, string retString, object userState)
		{
			if (this.ExactWordSearchOperationCompleted == null)
			{
				this.ExactWordSearchOperationCompleted = new SendOrPostCallback(this.OnExactWordSearchOperationCompleted);
			}
			base.InvokeAsync("ExactWordSearch", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				StatusList,
				SearchFields,
				SearchText,
				retCode,
				retString
			}, this.ExactWordSearchOperationCompleted, userState);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000530C File Offset: 0x0000430C
		private void OnExactWordSearchOperationCompleted(object arg)
		{
			if (this.ExactWordSearchCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.ExactWordSearchCompleted(this, new ExactWordSearchCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00005354 File Offset: 0x00004354
		[SoapDocumentMethod("http://tempuri.org/BasicSearch_TextAndAudio", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[SoapHeader("AuthenticationValue")]
		public DataSet BasicSearch_TextAndAudio(int GameProductCode, string LanguageList, string PlatformList, string StatusList, string SearchFields, string SearchText, bool isExactSearch, bool isSearchAudioScripts, ref string retCode, ref string retString)
		{
			object[] array = base.Invoke("BasicSearch_TextAndAudio", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				StatusList,
				SearchFields,
				SearchText,
				isExactSearch,
				isSearchAudioScripts,
				retCode,
				retString
			});
			retCode = (string)array[1];
			retString = (string)array[2];
			return (DataSet)array[0];
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000053D8 File Offset: 0x000043D8
		public void BasicSearch_TextAndAudioAsync(int GameProductCode, string LanguageList, string PlatformList, string StatusList, string SearchFields, string SearchText, bool isExactSearch, bool isSearchAudioScripts, string retCode, string retString)
		{
			this.BasicSearch_TextAndAudioAsync(GameProductCode, LanguageList, PlatformList, StatusList, SearchFields, SearchText, isExactSearch, isSearchAudioScripts, retCode, retString, null);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00005400 File Offset: 0x00004400
		public void BasicSearch_TextAndAudioAsync(int GameProductCode, string LanguageList, string PlatformList, string StatusList, string SearchFields, string SearchText, bool isExactSearch, bool isSearchAudioScripts, string retCode, string retString, object userState)
		{
			if (this.BasicSearch_TextAndAudioOperationCompleted == null)
			{
				this.BasicSearch_TextAndAudioOperationCompleted = new SendOrPostCallback(this.OnBasicSearch_TextAndAudioOperationCompleted);
			}
			base.InvokeAsync("BasicSearch_TextAndAudio", new object[]
			{
				GameProductCode,
				LanguageList,
				PlatformList,
				StatusList,
				SearchFields,
				SearchText,
				isExactSearch,
				isSearchAudioScripts,
				retCode,
				retString
			}, this.BasicSearch_TextAndAudioOperationCompleted, userState);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00005484 File Offset: 0x00004484
		private void OnBasicSearch_TextAndAudioOperationCompleted(object arg)
		{
			if (this.BasicSearch_TextAndAudioCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.BasicSearch_TextAndAudioCompleted(this, new BasicSearch_TextAndAudioCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000054CC File Offset: 0x000044CC
		[SoapHeader("AuthenticationValue")]
		[SoapDocumentMethod("http://tempuri.org/MergeStrings", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string MergeStrings(int GameProductCode, DataSet dsStrings, ref string retString)
		{
			object[] array = base.Invoke("MergeStrings", new object[]
			{
				GameProductCode,
				dsStrings,
				retString
			});
			retString = (string)array[1];
			return (string)array[0];
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00005511 File Offset: 0x00004511
		public void MergeStringsAsync(int GameProductCode, DataSet dsStrings, string retString)
		{
			this.MergeStringsAsync(GameProductCode, dsStrings, retString, null);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00005520 File Offset: 0x00004520
		public void MergeStringsAsync(int GameProductCode, DataSet dsStrings, string retString, object userState)
		{
			if (this.MergeStringsOperationCompleted == null)
			{
				this.MergeStringsOperationCompleted = new SendOrPostCallback(this.OnMergeStringsOperationCompleted);
			}
			base.InvokeAsync("MergeStrings", new object[]
			{
				GameProductCode,
				dsStrings,
				retString
			}, this.MergeStringsOperationCompleted, userState);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00005574 File Offset: 0x00004574
		private void OnMergeStringsOperationCompleted(object arg)
		{
			if (this.MergeStringsCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.MergeStringsCompleted(this, new MergeStringsCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000055B9 File Offset: 0x000045B9
		public new void CancelAsync(object userState)
		{
			base.CancelAsync(userState);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000055C4 File Offset: 0x000045C4
		private bool IsLocalFileSystemWebService(string url)
		{
			if (url == null || url == string.Empty)
			{
				return false;
			}
			Uri uri = new Uri(url);
			return uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0;
		}

		// Token: 0x04000001 RID: 1
		private Authentication authenticationValueField;

		// Token: 0x04000002 RID: 2
		private SendOrPostCallback GetServerTimeOperationCompleted;

		// Token: 0x04000003 RID: 3
		private SendOrPostCallback GetAllProductsOperationCompleted;

		// Token: 0x04000004 RID: 4
		private SendOrPostCallback GetLanguagesInProductOperationCompleted;

		// Token: 0x04000005 RID: 5
		private SendOrPostCallback GetPlatformsInProductOperationCompleted;

		// Token: 0x04000006 RID: 6
		private SendOrPostCallback GetAllAudioStrings_SpecifyReturnFieldsOperationCompleted;

		// Token: 0x04000007 RID: 7
		private SendOrPostCallback GetAllAudioStrings_SpecifyReturnFields_IncludeProductionStatusAndDNTOperationCompleted;

		// Token: 0x04000008 RID: 8
		private SendOrPostCallback GetAllStringsOperationCompleted;

		// Token: 0x04000009 RID: 9
		private SendOrPostCallback GetAllStrings_WithProductionStatusesAndDNTOperationCompleted;

		// Token: 0x0400000A RID: 10
		private SendOrPostCallback GetAllStrings_WithVersionNumberOperationCompleted;

		// Token: 0x0400000B RID: 11
		private SendOrPostCallback GetAllStrings_WithVersionNumber_SIMS3OperationCompleted;

		// Token: 0x0400000C RID: 12
		private SendOrPostCallback GetAllStrings_WithProductionStatuses_SIMS3OperationCompleted;

		// Token: 0x0400000D RID: 13
		private SendOrPostCallback GetAllStrings_SpecifyReturnFieldsOperationCompleted;

		// Token: 0x0400000E RID: 14
		private SendOrPostCallback GetAllStrings_WithVersionNumber_SpecifyReturnFieldsOperationCompleted;

		// Token: 0x0400000F RID: 15
		private SendOrPostCallback GetAllStrings_WithProductionStatusAndDNT_SpecifyReturnFieldsOperationCompleted;

		// Token: 0x04000010 RID: 16
		private SendOrPostCallback GetStringsOperationCompleted;

		// Token: 0x04000011 RID: 17
		private SendOrPostCallback CreateNewStringOperationCompleted;

		// Token: 0x04000012 RID: 18
		private SendOrPostCallback CreateNewAudioScriptOperationCompleted;

		// Token: 0x04000013 RID: 19
		private SendOrPostCallback RenameStringIdOperationCompleted;

		// Token: 0x04000014 RID: 20
		private SendOrPostCallback UpdateSourceStringOperationCompleted;

		// Token: 0x04000015 RID: 21
		private SendOrPostCallback UpdateSourceString_IncludingDNTOperationCompleted;

		// Token: 0x04000016 RID: 22
		private SendOrPostCallback UpdateAudioScriptOperationCompleted;

		// Token: 0x04000017 RID: 23
		private SendOrPostCallback UpdateAudioScript_IncludingDNTOperationCompleted;

		// Token: 0x04000018 RID: 24
		private SendOrPostCallback DeleteStringOperationCompleted;

		// Token: 0x04000019 RID: 25
		private SendOrPostCallback GetCategoriesInProductOperationCompleted;

		// Token: 0x0400001A RID: 26
		private SendOrPostCallback SetStringsWithSplittingOperationCompleted;

		// Token: 0x0400001B RID: 27
		private SendOrPostCallback SetStringsWithSplittingAndMergingOperationCompleted;

		// Token: 0x0400001C RID: 28
		private SendOrPostCallback BasicSearchOperationCompleted;

		// Token: 0x0400001D RID: 29
		private SendOrPostCallback ExactWordSearchOperationCompleted;

		// Token: 0x0400001E RID: 30
		private SendOrPostCallback BasicSearch_TextAndAudioOperationCompleted;

		// Token: 0x0400001F RID: 31
		private SendOrPostCallback MergeStringsOperationCompleted;

		// Token: 0x04000020 RID: 32
		private bool useDefaultCredentialsSetExplicitly;
	}
}
