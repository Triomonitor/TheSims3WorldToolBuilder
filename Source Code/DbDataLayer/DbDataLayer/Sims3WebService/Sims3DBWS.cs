using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Sims3.DbDataLayer.Properties;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200001E RID: 30
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.42")]
	[WebServiceBinding(Name = "Sims3DBWSSoap", Namespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta")]
	public class Sims3DBWS : SoapHttpClientProtocol
	{
		// Token: 0x060001C8 RID: 456 RVA: 0x00008560 File Offset: 0x00007560
		public Sims3DBWS()
		{
			this.Url = Settings.Default.DbDataLayer_Sims3WebService_Sims3DBWS;
			if (this.IsLocalFileSystemWebService(this.Url))
			{
				this.UseDefaultCredentials = true;
				this.useDefaultCredentialsSetExplicitly = false;
				return;
			}
			this.useDefaultCredentialsSetExplicitly = true;
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x0000859C File Offset: 0x0000759C
		// (set) Token: 0x060001CA RID: 458 RVA: 0x000085A4 File Offset: 0x000075A4
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

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060001CB RID: 459 RVA: 0x000085D3 File Offset: 0x000075D3
		// (set) Token: 0x060001CC RID: 460 RVA: 0x000085DB File Offset: 0x000075DB
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

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060001CD RID: 461 RVA: 0x000085EB File Offset: 0x000075EB
		// (remove) Token: 0x060001CE RID: 462 RVA: 0x00008604 File Offset: 0x00007604
		public event GetClassByKeyCompletedEventHandler GetClassByKeyCompleted;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060001CF RID: 463 RVA: 0x0000861D File Offset: 0x0000761D
		// (remove) Token: 0x060001D0 RID: 464 RVA: 0x00008636 File Offset: 0x00007636
		public event GetClassByKeyDateCompletedEventHandler GetClassByKeyDateCompleted;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060001D1 RID: 465 RVA: 0x0000864F File Offset: 0x0000764F
		// (remove) Token: 0x060001D2 RID: 466 RVA: 0x00008668 File Offset: 0x00007668
		public event InsertClassCompletedEventHandler InsertClassCompleted;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060001D3 RID: 467 RVA: 0x00008681 File Offset: 0x00007681
		// (remove) Token: 0x060001D4 RID: 468 RVA: 0x0000869A File Offset: 0x0000769A
		public event UpdateClassCompletedEventHandler UpdateClassCompleted;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060001D5 RID: 469 RVA: 0x000086B3 File Offset: 0x000076B3
		// (remove) Token: 0x060001D6 RID: 470 RVA: 0x000086CC File Offset: 0x000076CC
		public event InsertPrototypeCompletedEventHandler InsertPrototypeCompleted;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060001D7 RID: 471 RVA: 0x000086E5 File Offset: 0x000076E5
		// (remove) Token: 0x060001D8 RID: 472 RVA: 0x000086FE File Offset: 0x000076FE
		public event UpdatePrototypeCompletedEventHandler UpdatePrototypeCompleted;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060001D9 RID: 473 RVA: 0x00008717 File Offset: 0x00007717
		// (remove) Token: 0x060001DA RID: 474 RVA: 0x00008730 File Offset: 0x00007730
		public event GetPrototypeByKeyCompletedEventHandler GetPrototypeByKeyCompleted;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060001DB RID: 475 RVA: 0x00008749 File Offset: 0x00007749
		// (remove) Token: 0x060001DC RID: 476 RVA: 0x00008762 File Offset: 0x00007762
		public event GetPrototypeByKeyDateCompletedEventHandler GetPrototypeByKeyDateCompleted;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060001DD RID: 477 RVA: 0x0000877B File Offset: 0x0000777B
		// (remove) Token: 0x060001DE RID: 478 RVA: 0x00008794 File Offset: 0x00007794
		public event GetInstanceByKeyCompletedEventHandler GetInstanceByKeyCompleted;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060001DF RID: 479 RVA: 0x000087AD File Offset: 0x000077AD
		// (remove) Token: 0x060001E0 RID: 480 RVA: 0x000087C6 File Offset: 0x000077C6
		public event GetInstanceByKeyDateCompletedEventHandler GetInstanceByKeyDateCompleted;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060001E1 RID: 481 RVA: 0x000087DF File Offset: 0x000077DF
		// (remove) Token: 0x060001E2 RID: 482 RVA: 0x000087F8 File Offset: 0x000077F8
		public event InsertInstanceCompletedEventHandler InsertInstanceCompleted;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060001E3 RID: 483 RVA: 0x00008811 File Offset: 0x00007811
		// (remove) Token: 0x060001E4 RID: 484 RVA: 0x0000882A File Offset: 0x0000782A
		public event UpdateInstanceCompletedEventHandler UpdateInstanceCompleted;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x060001E5 RID: 485 RVA: 0x00008843 File Offset: 0x00007843
		// (remove) Token: 0x060001E6 RID: 486 RVA: 0x0000885C File Offset: 0x0000785C
		public event BulkInsertInstancesCompletedEventHandler BulkInsertInstancesCompleted;

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060001E7 RID: 487 RVA: 0x00008875 File Offset: 0x00007875
		// (remove) Token: 0x060001E8 RID: 488 RVA: 0x0000888E File Offset: 0x0000788E
		public event GetAllInstancesCompletedEventHandler GetAllInstancesCompleted;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060001E9 RID: 489 RVA: 0x000088A7 File Offset: 0x000078A7
		// (remove) Token: 0x060001EA RID: 490 RVA: 0x000088C0 File Offset: 0x000078C0
		public event GetInstanceKeysForClassKeyCompletedEventHandler GetInstanceKeysForClassKeyCompleted;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060001EB RID: 491 RVA: 0x000088D9 File Offset: 0x000078D9
		// (remove) Token: 0x060001EC RID: 492 RVA: 0x000088F2 File Offset: 0x000078F2
		public event GetInstancesForClassKeyNoXmlDataCompletedEventHandler GetInstancesForClassKeyNoXmlDataCompleted;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060001ED RID: 493 RVA: 0x0000890B File Offset: 0x0000790B
		// (remove) Token: 0x060001EE RID: 494 RVA: 0x00008924 File Offset: 0x00007924
		public event GetReferencesByInstanceCompletedEventHandler GetReferencesByInstanceCompleted;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060001EF RID: 495 RVA: 0x0000893D File Offset: 0x0000793D
		// (remove) Token: 0x060001F0 RID: 496 RVA: 0x00008956 File Offset: 0x00007956
		public event GetInstancesByReferenceCompletedEventHandler GetInstancesByReferenceCompleted;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060001F1 RID: 497 RVA: 0x0000896F File Offset: 0x0000796F
		// (remove) Token: 0x060001F2 RID: 498 RVA: 0x00008988 File Offset: 0x00007988
		public event CheckinCompletedEventHandler CheckinCompleted;

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x060001F3 RID: 499 RVA: 0x000089A1 File Offset: 0x000079A1
		// (remove) Token: 0x060001F4 RID: 500 RVA: 0x000089BA File Offset: 0x000079BA
		public event CheckinKeyCompletedEventHandler CheckinKeyCompleted;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x060001F5 RID: 501 RVA: 0x000089D3 File Offset: 0x000079D3
		// (remove) Token: 0x060001F6 RID: 502 RVA: 0x000089EC File Offset: 0x000079EC
		public event CheckoutCompletedEventHandler CheckoutCompleted;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x060001F7 RID: 503 RVA: 0x00008A05 File Offset: 0x00007A05
		// (remove) Token: 0x060001F8 RID: 504 RVA: 0x00008A1E File Offset: 0x00007A1E
		public event CheckoutAddToExistingCompletedEventHandler CheckoutAddToExistingCompleted;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060001F9 RID: 505 RVA: 0x00008A37 File Offset: 0x00007A37
		// (remove) Token: 0x060001FA RID: 506 RVA: 0x00008A50 File Offset: 0x00007A50
		public event GetCheckoutsForCurrentUserCompletedEventHandler GetCheckoutsForCurrentUserCompleted;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060001FB RID: 507 RVA: 0x00008A69 File Offset: 0x00007A69
		// (remove) Token: 0x060001FC RID: 508 RVA: 0x00008A82 File Offset: 0x00007A82
		public event GetCheckoutUserForKeyCompletedEventHandler GetCheckoutUserForKeyCompleted;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x060001FD RID: 509 RVA: 0x00008A9B File Offset: 0x00007A9B
		// (remove) Token: 0x060001FE RID: 510 RVA: 0x00008AB4 File Offset: 0x00007AB4
		public event CheckoutsForKeyChildrenCompletedEventHandler CheckoutsForKeyChildrenCompleted;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060001FF RID: 511 RVA: 0x00008ACD File Offset: 0x00007ACD
		// (remove) Token: 0x06000200 RID: 512 RVA: 0x00008AE6 File Offset: 0x00007AE6
		public event ListCheckedOutCompletedEventHandler ListCheckedOutCompleted;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06000201 RID: 513 RVA: 0x00008AFF File Offset: 0x00007AFF
		// (remove) Token: 0x06000202 RID: 514 RVA: 0x00008B18 File Offset: 0x00007B18
		public event ListCheckedOutKeysOfTypeCompletedEventHandler ListCheckedOutKeysOfTypeCompleted;

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06000203 RID: 515 RVA: 0x00008B31 File Offset: 0x00007B31
		// (remove) Token: 0x06000204 RID: 516 RVA: 0x00008B4A File Offset: 0x00007B4A
		public event IsKeyCheckedOutCompletedEventHandler IsKeyCheckedOutCompleted;

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000205 RID: 517 RVA: 0x00008B63 File Offset: 0x00007B63
		// (remove) Token: 0x06000206 RID: 518 RVA: 0x00008B7C File Offset: 0x00007B7C
		public event ListCheckedOutChildrenForKeyCompletedEventHandler ListCheckedOutChildrenForKeyCompleted;

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000207 RID: 519 RVA: 0x00008B95 File Offset: 0x00007B95
		// (remove) Token: 0x06000208 RID: 520 RVA: 0x00008BAE File Offset: 0x00007BAE
		public event DeleteByKeyCompletedEventHandler DeleteByKeyCompleted;

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000209 RID: 521 RVA: 0x00008BC7 File Offset: 0x00007BC7
		// (remove) Token: 0x0600020A RID: 522 RVA: 0x00008BE0 File Offset: 0x00007BE0
		public event GetAllKeysOfTypeCompletedEventHandler GetAllKeysOfTypeCompleted;

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x0600020B RID: 523 RVA: 0x00008BF9 File Offset: 0x00007BF9
		// (remove) Token: 0x0600020C RID: 524 RVA: 0x00008C12 File Offset: 0x00007C12
		public event GetRevisionDatesForKeyCompletedEventHandler GetRevisionDatesForKeyCompleted;

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x0600020D RID: 525 RVA: 0x00008C2B File Offset: 0x00007C2B
		// (remove) Token: 0x0600020E RID: 526 RVA: 0x00008C44 File Offset: 0x00007C44
		public event GetXmlDataForKeyCompletedEventHandler GetXmlDataForKeyCompleted;

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x0600020F RID: 527 RVA: 0x00008C5D File Offset: 0x00007C5D
		// (remove) Token: 0x06000210 RID: 528 RVA: 0x00008C76 File Offset: 0x00007C76
		public event GetXmlDataForKeyDateCompletedEventHandler GetXmlDataForKeyDateCompleted;

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06000211 RID: 529 RVA: 0x00008C8F File Offset: 0x00007C8F
		// (remove) Token: 0x06000212 RID: 530 RVA: 0x00008CA8 File Offset: 0x00007CA8
		public event GetChildrenForKeyCompletedEventHandler GetChildrenForKeyCompleted;

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06000213 RID: 531 RVA: 0x00008CC1 File Offset: 0x00007CC1
		// (remove) Token: 0x06000214 RID: 532 RVA: 0x00008CDA File Offset: 0x00007CDA
		public event TestConnectionCompletedEventHandler TestConnectionCompleted;

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000215 RID: 533 RVA: 0x00008CF3 File Offset: 0x00007CF3
		// (remove) Token: 0x06000216 RID: 534 RVA: 0x00008D0C File Offset: 0x00007D0C
		public event IsDatabaseLockedCompletedEventHandler IsDatabaseLockedCompleted;

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06000217 RID: 535 RVA: 0x00008D25 File Offset: 0x00007D25
		// (remove) Token: 0x06000218 RID: 536 RVA: 0x00008D3E File Offset: 0x00007D3E
		public event GetDatabaseLockInformationCompletedEventHandler GetDatabaseLockInformationCompleted;

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x06000219 RID: 537 RVA: 0x00008D57 File Offset: 0x00007D57
		// (remove) Token: 0x0600021A RID: 538 RVA: 0x00008D70 File Offset: 0x00007D70
		public event GetAllPrototypesNoXmlDataCompletedEventHandler GetAllPrototypesNoXmlDataCompleted;

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x0600021B RID: 539 RVA: 0x00008D89 File Offset: 0x00007D89
		// (remove) Token: 0x0600021C RID: 540 RVA: 0x00008DA2 File Offset: 0x00007DA2
		public event CheckoutPrototypeCompletedEventHandler CheckoutPrototypeCompleted;

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x0600021D RID: 541 RVA: 0x00008DBB File Offset: 0x00007DBB
		// (remove) Token: 0x0600021E RID: 542 RVA: 0x00008DD4 File Offset: 0x00007DD4
		public event GetDatabaseItemTreeCompletedEventHandler GetDatabaseItemTreeCompleted;

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x0600021F RID: 543 RVA: 0x00008DED File Offset: 0x00007DED
		// (remove) Token: 0x06000220 RID: 544 RVA: 0x00008E06 File Offset: 0x00007E06
		public event GetAllInstancesByDateCompletedEventHandler GetAllInstancesByDateCompleted;

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x06000221 RID: 545 RVA: 0x00008E1F File Offset: 0x00007E1F
		// (remove) Token: 0x06000222 RID: 546 RVA: 0x00008E38 File Offset: 0x00007E38
		public event GetAllInstancesXmlCompletedEventHandler GetAllInstancesXmlCompleted;

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x06000223 RID: 547 RVA: 0x00008E51 File Offset: 0x00007E51
		// (remove) Token: 0x06000224 RID: 548 RVA: 0x00008E6A File Offset: 0x00007E6A
		public event XmlBulkExportForDateCompletedEventHandler XmlBulkExportForDateCompleted;

		// Token: 0x06000225 RID: 549 RVA: 0x00008E84 File Offset: 0x00007E84
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetClassByKey", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ObjectClass GetClassByKey(ItemKey theKey)
		{
			object[] array = base.Invoke("GetClassByKey", new object[]
			{
				theKey
			});
			return (ObjectClass)array[0];
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00008EB1 File Offset: 0x00007EB1
		public void GetClassByKeyAsync(ItemKey theKey)
		{
			this.GetClassByKeyAsync(theKey, null);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00008EBC File Offset: 0x00007EBC
		public void GetClassByKeyAsync(ItemKey theKey, object userState)
		{
			if (this.GetClassByKeyOperationCompleted == null)
			{
				this.GetClassByKeyOperationCompleted = new SendOrPostCallback(this.OnGetClassByKeyOperationCompleted);
			}
			base.InvokeAsync("GetClassByKey", new object[]
			{
				theKey
			}, this.GetClassByKeyOperationCompleted, userState);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00008F04 File Offset: 0x00007F04
		private void OnGetClassByKeyOperationCompleted(object arg)
		{
			if (this.GetClassByKeyCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetClassByKeyCompleted(this, new GetClassByKeyCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00008F4C File Offset: 0x00007F4C
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetClassByKeyDate", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ObjectClass GetClassByKeyDate(ItemKey theKey, DateTime DateBeforeWhich)
		{
			object[] array = base.Invoke("GetClassByKeyDate", new object[]
			{
				theKey,
				DateBeforeWhich
			});
			return (ObjectClass)array[0];
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00008F82 File Offset: 0x00007F82
		public void GetClassByKeyDateAsync(ItemKey theKey, DateTime DateBeforeWhich)
		{
			this.GetClassByKeyDateAsync(theKey, DateBeforeWhich, null);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00008F90 File Offset: 0x00007F90
		public void GetClassByKeyDateAsync(ItemKey theKey, DateTime DateBeforeWhich, object userState)
		{
			if (this.GetClassByKeyDateOperationCompleted == null)
			{
				this.GetClassByKeyDateOperationCompleted = new SendOrPostCallback(this.OnGetClassByKeyDateOperationCompleted);
			}
			base.InvokeAsync("GetClassByKeyDate", new object[]
			{
				theKey,
				DateBeforeWhich
			}, this.GetClassByKeyDateOperationCompleted, userState);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00008FE0 File Offset: 0x00007FE0
		private void OnGetClassByKeyDateOperationCompleted(object arg)
		{
			if (this.GetClassByKeyDateCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetClassByKeyDateCompleted(this, new GetClassByKeyDateCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00009028 File Offset: 0x00008028
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/InsertClass", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public int InsertClass(ObjectClass theClass)
		{
			object[] array = base.Invoke("InsertClass", new object[]
			{
				theClass
			});
			return (int)array[0];
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00009055 File Offset: 0x00008055
		public void InsertClassAsync(ObjectClass theClass)
		{
			this.InsertClassAsync(theClass, null);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00009060 File Offset: 0x00008060
		public void InsertClassAsync(ObjectClass theClass, object userState)
		{
			if (this.InsertClassOperationCompleted == null)
			{
				this.InsertClassOperationCompleted = new SendOrPostCallback(this.OnInsertClassOperationCompleted);
			}
			base.InvokeAsync("InsertClass", new object[]
			{
				theClass
			}, this.InsertClassOperationCompleted, userState);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x000090A8 File Offset: 0x000080A8
		private void OnInsertClassOperationCompleted(object arg)
		{
			if (this.InsertClassCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.InsertClassCompleted(this, new InsertClassCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x000090F0 File Offset: 0x000080F0
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/UpdateClass", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public int UpdateClass(ObjectClass theClass, ItemKey originalClassKey)
		{
			object[] array = base.Invoke("UpdateClass", new object[]
			{
				theClass,
				originalClassKey
			});
			return (int)array[0];
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00009121 File Offset: 0x00008121
		public void UpdateClassAsync(ObjectClass theClass, ItemKey originalClassKey)
		{
			this.UpdateClassAsync(theClass, originalClassKey, null);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000912C File Offset: 0x0000812C
		public void UpdateClassAsync(ObjectClass theClass, ItemKey originalClassKey, object userState)
		{
			if (this.UpdateClassOperationCompleted == null)
			{
				this.UpdateClassOperationCompleted = new SendOrPostCallback(this.OnUpdateClassOperationCompleted);
			}
			base.InvokeAsync("UpdateClass", new object[]
			{
				theClass,
				originalClassKey
			}, this.UpdateClassOperationCompleted, userState);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00009178 File Offset: 0x00008178
		private void OnUpdateClassOperationCompleted(object arg)
		{
			if (this.UpdateClassCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.UpdateClassCompleted(this, new UpdateClassCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000235 RID: 565 RVA: 0x000091C0 File Offset: 0x000081C0
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/InsertPrototype", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public int InsertPrototype(ObjectPrototype thePrototype)
		{
			object[] array = base.Invoke("InsertPrototype", new object[]
			{
				thePrototype
			});
			return (int)array[0];
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000091ED File Offset: 0x000081ED
		public void InsertPrototypeAsync(ObjectPrototype thePrototype)
		{
			this.InsertPrototypeAsync(thePrototype, null);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000091F8 File Offset: 0x000081F8
		public void InsertPrototypeAsync(ObjectPrototype thePrototype, object userState)
		{
			if (this.InsertPrototypeOperationCompleted == null)
			{
				this.InsertPrototypeOperationCompleted = new SendOrPostCallback(this.OnInsertPrototypeOperationCompleted);
			}
			base.InvokeAsync("InsertPrototype", new object[]
			{
				thePrototype
			}, this.InsertPrototypeOperationCompleted, userState);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00009240 File Offset: 0x00008240
		private void OnInsertPrototypeOperationCompleted(object arg)
		{
			if (this.InsertPrototypeCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.InsertPrototypeCompleted(this, new InsertPrototypeCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00009288 File Offset: 0x00008288
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/UpdatePrototype", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public int UpdatePrototype(ObjectPrototype thePrototype, ObjectPrototype originalPrototype)
		{
			object[] array = base.Invoke("UpdatePrototype", new object[]
			{
				thePrototype,
				originalPrototype
			});
			return (int)array[0];
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000092B9 File Offset: 0x000082B9
		public void UpdatePrototypeAsync(ObjectPrototype thePrototype, ObjectPrototype originalPrototype)
		{
			this.UpdatePrototypeAsync(thePrototype, originalPrototype, null);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000092C4 File Offset: 0x000082C4
		public void UpdatePrototypeAsync(ObjectPrototype thePrototype, ObjectPrototype originalPrototype, object userState)
		{
			if (this.UpdatePrototypeOperationCompleted == null)
			{
				this.UpdatePrototypeOperationCompleted = new SendOrPostCallback(this.OnUpdatePrototypeOperationCompleted);
			}
			base.InvokeAsync("UpdatePrototype", new object[]
			{
				thePrototype,
				originalPrototype
			}, this.UpdatePrototypeOperationCompleted, userState);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00009310 File Offset: 0x00008310
		private void OnUpdatePrototypeOperationCompleted(object arg)
		{
			if (this.UpdatePrototypeCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.UpdatePrototypeCompleted(this, new UpdatePrototypeCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00009358 File Offset: 0x00008358
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetPrototypeByKey", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ObjectPrototype GetPrototypeByKey(ItemKey theKey)
		{
			object[] array = base.Invoke("GetPrototypeByKey", new object[]
			{
				theKey
			});
			return (ObjectPrototype)array[0];
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00009385 File Offset: 0x00008385
		public void GetPrototypeByKeyAsync(ItemKey theKey)
		{
			this.GetPrototypeByKeyAsync(theKey, null);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00009390 File Offset: 0x00008390
		public void GetPrototypeByKeyAsync(ItemKey theKey, object userState)
		{
			if (this.GetPrototypeByKeyOperationCompleted == null)
			{
				this.GetPrototypeByKeyOperationCompleted = new SendOrPostCallback(this.OnGetPrototypeByKeyOperationCompleted);
			}
			base.InvokeAsync("GetPrototypeByKey", new object[]
			{
				theKey
			}, this.GetPrototypeByKeyOperationCompleted, userState);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x000093D8 File Offset: 0x000083D8
		private void OnGetPrototypeByKeyOperationCompleted(object arg)
		{
			if (this.GetPrototypeByKeyCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetPrototypeByKeyCompleted(this, new GetPrototypeByKeyCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00009420 File Offset: 0x00008420
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetPrototypeByKeyDate", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ObjectPrototype GetPrototypeByKeyDate(ItemKey theKey, DateTime DateBeforeWhich)
		{
			object[] array = base.Invoke("GetPrototypeByKeyDate", new object[]
			{
				theKey,
				DateBeforeWhich
			});
			return (ObjectPrototype)array[0];
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00009456 File Offset: 0x00008456
		public void GetPrototypeByKeyDateAsync(ItemKey theKey, DateTime DateBeforeWhich)
		{
			this.GetPrototypeByKeyDateAsync(theKey, DateBeforeWhich, null);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00009464 File Offset: 0x00008464
		public void GetPrototypeByKeyDateAsync(ItemKey theKey, DateTime DateBeforeWhich, object userState)
		{
			if (this.GetPrototypeByKeyDateOperationCompleted == null)
			{
				this.GetPrototypeByKeyDateOperationCompleted = new SendOrPostCallback(this.OnGetPrototypeByKeyDateOperationCompleted);
			}
			base.InvokeAsync("GetPrototypeByKeyDate", new object[]
			{
				theKey,
				DateBeforeWhich
			}, this.GetPrototypeByKeyDateOperationCompleted, userState);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x000094B4 File Offset: 0x000084B4
		private void OnGetPrototypeByKeyDateOperationCompleted(object arg)
		{
			if (this.GetPrototypeByKeyDateCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetPrototypeByKeyDateCompleted(this, new GetPrototypeByKeyDateCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000094FC File Offset: 0x000084FC
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetInstanceByKey", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ObjectInstance GetInstanceByKey(ItemKey theKey)
		{
			object[] array = base.Invoke("GetInstanceByKey", new object[]
			{
				theKey
			});
			return (ObjectInstance)array[0];
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00009529 File Offset: 0x00008529
		public void GetInstanceByKeyAsync(ItemKey theKey)
		{
			this.GetInstanceByKeyAsync(theKey, null);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00009534 File Offset: 0x00008534
		public void GetInstanceByKeyAsync(ItemKey theKey, object userState)
		{
			if (this.GetInstanceByKeyOperationCompleted == null)
			{
				this.GetInstanceByKeyOperationCompleted = new SendOrPostCallback(this.OnGetInstanceByKeyOperationCompleted);
			}
			base.InvokeAsync("GetInstanceByKey", new object[]
			{
				theKey
			}, this.GetInstanceByKeyOperationCompleted, userState);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000957C File Offset: 0x0000857C
		private void OnGetInstanceByKeyOperationCompleted(object arg)
		{
			if (this.GetInstanceByKeyCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetInstanceByKeyCompleted(this, new GetInstanceByKeyCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000249 RID: 585 RVA: 0x000095C4 File Offset: 0x000085C4
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetInstanceByKeyDate", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ObjectInstance GetInstanceByKeyDate(ItemKey theKey, DateTime DateBeforeWhich)
		{
			object[] array = base.Invoke("GetInstanceByKeyDate", new object[]
			{
				theKey,
				DateBeforeWhich
			});
			return (ObjectInstance)array[0];
		}

		// Token: 0x0600024A RID: 586 RVA: 0x000095FA File Offset: 0x000085FA
		public void GetInstanceByKeyDateAsync(ItemKey theKey, DateTime DateBeforeWhich)
		{
			this.GetInstanceByKeyDateAsync(theKey, DateBeforeWhich, null);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00009608 File Offset: 0x00008608
		public void GetInstanceByKeyDateAsync(ItemKey theKey, DateTime DateBeforeWhich, object userState)
		{
			if (this.GetInstanceByKeyDateOperationCompleted == null)
			{
				this.GetInstanceByKeyDateOperationCompleted = new SendOrPostCallback(this.OnGetInstanceByKeyDateOperationCompleted);
			}
			base.InvokeAsync("GetInstanceByKeyDate", new object[]
			{
				theKey,
				DateBeforeWhich
			}, this.GetInstanceByKeyDateOperationCompleted, userState);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00009658 File Offset: 0x00008658
		private void OnGetInstanceByKeyDateOperationCompleted(object arg)
		{
			if (this.GetInstanceByKeyDateCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetInstanceByKeyDateCompleted(this, new GetInstanceByKeyDateCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x000096A0 File Offset: 0x000086A0
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/InsertInstance", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public int InsertInstance(ObjectInstance theInstance)
		{
			object[] array = base.Invoke("InsertInstance", new object[]
			{
				theInstance
			});
			return (int)array[0];
		}

		// Token: 0x0600024E RID: 590 RVA: 0x000096CD File Offset: 0x000086CD
		public void InsertInstanceAsync(ObjectInstance theInstance)
		{
			this.InsertInstanceAsync(theInstance, null);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000096D8 File Offset: 0x000086D8
		public void InsertInstanceAsync(ObjectInstance theInstance, object userState)
		{
			if (this.InsertInstanceOperationCompleted == null)
			{
				this.InsertInstanceOperationCompleted = new SendOrPostCallback(this.OnInsertInstanceOperationCompleted);
			}
			base.InvokeAsync("InsertInstance", new object[]
			{
				theInstance
			}, this.InsertInstanceOperationCompleted, userState);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00009720 File Offset: 0x00008720
		private void OnInsertInstanceOperationCompleted(object arg)
		{
			if (this.InsertInstanceCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.InsertInstanceCompleted(this, new InsertInstanceCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00009768 File Offset: 0x00008768
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/UpdateInstance", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public int UpdateInstance(ObjectInstance theInstance, ObjectInstance originalInstance)
		{
			object[] array = base.Invoke("UpdateInstance", new object[]
			{
				theInstance,
				originalInstance
			});
			return (int)array[0];
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00009799 File Offset: 0x00008799
		public void UpdateInstanceAsync(ObjectInstance theInstance, ObjectInstance originalInstance)
		{
			this.UpdateInstanceAsync(theInstance, originalInstance, null);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x000097A4 File Offset: 0x000087A4
		public void UpdateInstanceAsync(ObjectInstance theInstance, ObjectInstance originalInstance, object userState)
		{
			if (this.UpdateInstanceOperationCompleted == null)
			{
				this.UpdateInstanceOperationCompleted = new SendOrPostCallback(this.OnUpdateInstanceOperationCompleted);
			}
			base.InvokeAsync("UpdateInstance", new object[]
			{
				theInstance,
				originalInstance
			}, this.UpdateInstanceOperationCompleted, userState);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x000097F0 File Offset: 0x000087F0
		private void OnUpdateInstanceOperationCompleted(object arg)
		{
			if (this.UpdateInstanceCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.UpdateInstanceCompleted(this, new UpdateInstanceCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00009838 File Offset: 0x00008838
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/BulkInsertInstances", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public int BulkInsertInstances(ObjectInstance[] instList)
		{
			object[] array = base.Invoke("BulkInsertInstances", new object[]
			{
				instList
			});
			return (int)array[0];
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00009865 File Offset: 0x00008865
		public void BulkInsertInstancesAsync(ObjectInstance[] instList)
		{
			this.BulkInsertInstancesAsync(instList, null);
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00009870 File Offset: 0x00008870
		public void BulkInsertInstancesAsync(ObjectInstance[] instList, object userState)
		{
			if (this.BulkInsertInstancesOperationCompleted == null)
			{
				this.BulkInsertInstancesOperationCompleted = new SendOrPostCallback(this.OnBulkInsertInstancesOperationCompleted);
			}
			base.InvokeAsync("BulkInsertInstances", new object[]
			{
				instList
			}, this.BulkInsertInstancesOperationCompleted, userState);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x000098B8 File Offset: 0x000088B8
		private void OnBulkInsertInstancesOperationCompleted(object arg)
		{
			if (this.BulkInsertInstancesCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.BulkInsertInstancesCompleted(this, new BulkInsertInstancesCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00009900 File Offset: 0x00008900
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetAllInstances", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ObjectInstance[] GetAllInstances()
		{
			object[] array = base.Invoke("GetAllInstances", new object[0]);
			return (ObjectInstance[])array[0];
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00009927 File Offset: 0x00008927
		public void GetAllInstancesAsync()
		{
			this.GetAllInstancesAsync(null);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00009930 File Offset: 0x00008930
		public void GetAllInstancesAsync(object userState)
		{
			if (this.GetAllInstancesOperationCompleted == null)
			{
				this.GetAllInstancesOperationCompleted = new SendOrPostCallback(this.OnGetAllInstancesOperationCompleted);
			}
			base.InvokeAsync("GetAllInstances", new object[0], this.GetAllInstancesOperationCompleted, userState);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00009964 File Offset: 0x00008964
		private void OnGetAllInstancesOperationCompleted(object arg)
		{
			if (this.GetAllInstancesCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllInstancesCompleted(this, new GetAllInstancesCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000099AC File Offset: 0x000089AC
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetInstanceKeysForClassKey", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ItemKey[] GetInstanceKeysForClassKey(ItemKey inClass)
		{
			object[] array = base.Invoke("GetInstanceKeysForClassKey", new object[]
			{
				inClass
			});
			return (ItemKey[])array[0];
		}

		// Token: 0x0600025E RID: 606 RVA: 0x000099D9 File Offset: 0x000089D9
		public void GetInstanceKeysForClassKeyAsync(ItemKey inClass)
		{
			this.GetInstanceKeysForClassKeyAsync(inClass, null);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000099E4 File Offset: 0x000089E4
		public void GetInstanceKeysForClassKeyAsync(ItemKey inClass, object userState)
		{
			if (this.GetInstanceKeysForClassKeyOperationCompleted == null)
			{
				this.GetInstanceKeysForClassKeyOperationCompleted = new SendOrPostCallback(this.OnGetInstanceKeysForClassKeyOperationCompleted);
			}
			base.InvokeAsync("GetInstanceKeysForClassKey", new object[]
			{
				inClass
			}, this.GetInstanceKeysForClassKeyOperationCompleted, userState);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00009A2C File Offset: 0x00008A2C
		private void OnGetInstanceKeysForClassKeyOperationCompleted(object arg)
		{
			if (this.GetInstanceKeysForClassKeyCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetInstanceKeysForClassKeyCompleted(this, new GetInstanceKeysForClassKeyCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00009A74 File Offset: 0x00008A74
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetInstancesForClassKeyNoXmlData", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ObjectInstance[] GetInstancesForClassKeyNoXmlData(ItemKey inClass)
		{
			object[] array = base.Invoke("GetInstancesForClassKeyNoXmlData", new object[]
			{
				inClass
			});
			return (ObjectInstance[])array[0];
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00009AA1 File Offset: 0x00008AA1
		public void GetInstancesForClassKeyNoXmlDataAsync(ItemKey inClass)
		{
			this.GetInstancesForClassKeyNoXmlDataAsync(inClass, null);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00009AAC File Offset: 0x00008AAC
		public void GetInstancesForClassKeyNoXmlDataAsync(ItemKey inClass, object userState)
		{
			if (this.GetInstancesForClassKeyNoXmlDataOperationCompleted == null)
			{
				this.GetInstancesForClassKeyNoXmlDataOperationCompleted = new SendOrPostCallback(this.OnGetInstancesForClassKeyNoXmlDataOperationCompleted);
			}
			base.InvokeAsync("GetInstancesForClassKeyNoXmlData", new object[]
			{
				inClass
			}, this.GetInstancesForClassKeyNoXmlDataOperationCompleted, userState);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00009AF4 File Offset: 0x00008AF4
		private void OnGetInstancesForClassKeyNoXmlDataOperationCompleted(object arg)
		{
			if (this.GetInstancesForClassKeyNoXmlDataCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetInstancesForClassKeyNoXmlDataCompleted(this, new GetInstancesForClassKeyNoXmlDataCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00009B3C File Offset: 0x00008B3C
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetReferencesByInstance", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ItemKey[] GetReferencesByInstance(ItemKey instanceKey)
		{
			object[] array = base.Invoke("GetReferencesByInstance", new object[]
			{
				instanceKey
			});
			return (ItemKey[])array[0];
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00009B69 File Offset: 0x00008B69
		public void GetReferencesByInstanceAsync(ItemKey instanceKey)
		{
			this.GetReferencesByInstanceAsync(instanceKey, null);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00009B74 File Offset: 0x00008B74
		public void GetReferencesByInstanceAsync(ItemKey instanceKey, object userState)
		{
			if (this.GetReferencesByInstanceOperationCompleted == null)
			{
				this.GetReferencesByInstanceOperationCompleted = new SendOrPostCallback(this.OnGetReferencesByInstanceOperationCompleted);
			}
			base.InvokeAsync("GetReferencesByInstance", new object[]
			{
				instanceKey
			}, this.GetReferencesByInstanceOperationCompleted, userState);
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00009BBC File Offset: 0x00008BBC
		private void OnGetReferencesByInstanceOperationCompleted(object arg)
		{
			if (this.GetReferencesByInstanceCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetReferencesByInstanceCompleted(this, new GetReferencesByInstanceCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00009C04 File Offset: 0x00008C04
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetInstancesByReference", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ItemKey[] GetInstancesByReference(ItemKey instanceKey)
		{
			object[] array = base.Invoke("GetInstancesByReference", new object[]
			{
				instanceKey
			});
			return (ItemKey[])array[0];
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00009C31 File Offset: 0x00008C31
		public void GetInstancesByReferenceAsync(ItemKey instanceKey)
		{
			this.GetInstancesByReferenceAsync(instanceKey, null);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00009C3C File Offset: 0x00008C3C
		public void GetInstancesByReferenceAsync(ItemKey instanceKey, object userState)
		{
			if (this.GetInstancesByReferenceOperationCompleted == null)
			{
				this.GetInstancesByReferenceOperationCompleted = new SendOrPostCallback(this.OnGetInstancesByReferenceOperationCompleted);
			}
			base.InvokeAsync("GetInstancesByReference", new object[]
			{
				instanceKey
			}, this.GetInstancesByReferenceOperationCompleted, userState);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00009C84 File Offset: 0x00008C84
		private void OnGetInstancesByReferenceOperationCompleted(object arg)
		{
			if (this.GetInstancesByReferenceCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetInstancesByReferenceCompleted(this, new GetInstancesByReferenceCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00009CCC File Offset: 0x00008CCC
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/Checkin", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public void Checkin(Guid CheckinId)
		{
			base.Invoke("Checkin", new object[]
			{
				CheckinId
			});
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00009CF6 File Offset: 0x00008CF6
		public void CheckinAsync(Guid CheckinId)
		{
			this.CheckinAsync(CheckinId, null);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00009D00 File Offset: 0x00008D00
		public void CheckinAsync(Guid CheckinId, object userState)
		{
			if (this.CheckinOperationCompleted == null)
			{
				this.CheckinOperationCompleted = new SendOrPostCallback(this.OnCheckinOperationCompleted);
			}
			base.InvokeAsync("Checkin", new object[]
			{
				CheckinId
			}, this.CheckinOperationCompleted, userState);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00009D4C File Offset: 0x00008D4C
		private void OnCheckinOperationCompleted(object arg)
		{
			if (this.CheckinCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.CheckinCompleted(this, new AsyncCompletedEventArgs(invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00009D8C File Offset: 0x00008D8C
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/CheckinKey", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public void CheckinKey(ItemKey theKey)
		{
			base.Invoke("CheckinKey", new object[]
			{
				theKey
			});
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00009DB1 File Offset: 0x00008DB1
		public void CheckinKeyAsync(ItemKey theKey)
		{
			this.CheckinKeyAsync(theKey, null);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00009DBC File Offset: 0x00008DBC
		public void CheckinKeyAsync(ItemKey theKey, object userState)
		{
			if (this.CheckinKeyOperationCompleted == null)
			{
				this.CheckinKeyOperationCompleted = new SendOrPostCallback(this.OnCheckinKeyOperationCompleted);
			}
			base.InvokeAsync("CheckinKey", new object[]
			{
				theKey
			}, this.CheckinKeyOperationCompleted, userState);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00009E04 File Offset: 0x00008E04
		private void OnCheckinKeyOperationCompleted(object arg)
		{
			if (this.CheckinKeyCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.CheckinKeyCompleted(this, new AsyncCompletedEventArgs(invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00009E44 File Offset: 0x00008E44
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/Checkout", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public Guid Checkout(ItemKey theKey)
		{
			object[] array = base.Invoke("Checkout", new object[]
			{
				theKey
			});
			return (Guid)array[0];
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00009E71 File Offset: 0x00008E71
		public void CheckoutAsync(ItemKey theKey)
		{
			this.CheckoutAsync(theKey, null);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00009E7C File Offset: 0x00008E7C
		public void CheckoutAsync(ItemKey theKey, object userState)
		{
			if (this.CheckoutOperationCompleted == null)
			{
				this.CheckoutOperationCompleted = new SendOrPostCallback(this.OnCheckoutOperationCompleted);
			}
			base.InvokeAsync("Checkout", new object[]
			{
				theKey
			}, this.CheckoutOperationCompleted, userState);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00009EC4 File Offset: 0x00008EC4
		private void OnCheckoutOperationCompleted(object arg)
		{
			if (this.CheckoutCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.CheckoutCompleted(this, new CheckoutCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00009F0C File Offset: 0x00008F0C
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/CheckoutAddToExisting", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public Guid CheckoutAddToExisting(ItemKey theKey, Guid existingCheckout)
		{
			object[] array = base.Invoke("CheckoutAddToExisting", new object[]
			{
				theKey,
				existingCheckout
			});
			return (Guid)array[0];
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00009F42 File Offset: 0x00008F42
		public void CheckoutAddToExistingAsync(ItemKey theKey, Guid existingCheckout)
		{
			this.CheckoutAddToExistingAsync(theKey, existingCheckout, null);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00009F50 File Offset: 0x00008F50
		public void CheckoutAddToExistingAsync(ItemKey theKey, Guid existingCheckout, object userState)
		{
			if (this.CheckoutAddToExistingOperationCompleted == null)
			{
				this.CheckoutAddToExistingOperationCompleted = new SendOrPostCallback(this.OnCheckoutAddToExistingOperationCompleted);
			}
			base.InvokeAsync("CheckoutAddToExisting", new object[]
			{
				theKey,
				existingCheckout
			}, this.CheckoutAddToExistingOperationCompleted, userState);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00009FA0 File Offset: 0x00008FA0
		private void OnCheckoutAddToExistingOperationCompleted(object arg)
		{
			if (this.CheckoutAddToExistingCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.CheckoutAddToExistingCompleted(this, new CheckoutAddToExistingCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00009FE8 File Offset: 0x00008FE8
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetCheckoutsForCurrentUser", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public Guid[] GetCheckoutsForCurrentUser()
		{
			object[] array = base.Invoke("GetCheckoutsForCurrentUser", new object[0]);
			return (Guid[])array[0];
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000A00F File Offset: 0x0000900F
		public void GetCheckoutsForCurrentUserAsync()
		{
			this.GetCheckoutsForCurrentUserAsync(null);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000A018 File Offset: 0x00009018
		public void GetCheckoutsForCurrentUserAsync(object userState)
		{
			if (this.GetCheckoutsForCurrentUserOperationCompleted == null)
			{
				this.GetCheckoutsForCurrentUserOperationCompleted = new SendOrPostCallback(this.OnGetCheckoutsForCurrentUserOperationCompleted);
			}
			base.InvokeAsync("GetCheckoutsForCurrentUser", new object[0], this.GetCheckoutsForCurrentUserOperationCompleted, userState);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000A04C File Offset: 0x0000904C
		private void OnGetCheckoutsForCurrentUserOperationCompleted(object arg)
		{
			if (this.GetCheckoutsForCurrentUserCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetCheckoutsForCurrentUserCompleted(this, new GetCheckoutsForCurrentUserCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000A094 File Offset: 0x00009094
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetCheckoutUserForKey", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string GetCheckoutUserForKey(ItemKey theKey)
		{
			object[] array = base.Invoke("GetCheckoutUserForKey", new object[]
			{
				theKey
			});
			return (string)array[0];
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000A0C1 File Offset: 0x000090C1
		public void GetCheckoutUserForKeyAsync(ItemKey theKey)
		{
			this.GetCheckoutUserForKeyAsync(theKey, null);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000A0CC File Offset: 0x000090CC
		public void GetCheckoutUserForKeyAsync(ItemKey theKey, object userState)
		{
			if (this.GetCheckoutUserForKeyOperationCompleted == null)
			{
				this.GetCheckoutUserForKeyOperationCompleted = new SendOrPostCallback(this.OnGetCheckoutUserForKeyOperationCompleted);
			}
			base.InvokeAsync("GetCheckoutUserForKey", new object[]
			{
				theKey
			}, this.GetCheckoutUserForKeyOperationCompleted, userState);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000A114 File Offset: 0x00009114
		private void OnGetCheckoutUserForKeyOperationCompleted(object arg)
		{
			if (this.GetCheckoutUserForKeyCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetCheckoutUserForKeyCompleted(this, new GetCheckoutUserForKeyCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000A15C File Offset: 0x0000915C
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/CheckoutsForKeyChildren", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public Guid[] CheckoutsForKeyChildren(ItemKey theKey)
		{
			object[] array = base.Invoke("CheckoutsForKeyChildren", new object[]
			{
				theKey
			});
			return (Guid[])array[0];
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000A189 File Offset: 0x00009189
		public void CheckoutsForKeyChildrenAsync(ItemKey theKey)
		{
			this.CheckoutsForKeyChildrenAsync(theKey, null);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000A194 File Offset: 0x00009194
		public void CheckoutsForKeyChildrenAsync(ItemKey theKey, object userState)
		{
			if (this.CheckoutsForKeyChildrenOperationCompleted == null)
			{
				this.CheckoutsForKeyChildrenOperationCompleted = new SendOrPostCallback(this.OnCheckoutsForKeyChildrenOperationCompleted);
			}
			base.InvokeAsync("CheckoutsForKeyChildren", new object[]
			{
				theKey
			}, this.CheckoutsForKeyChildrenOperationCompleted, userState);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000A1DC File Offset: 0x000091DC
		private void OnCheckoutsForKeyChildrenOperationCompleted(object arg)
		{
			if (this.CheckoutsForKeyChildrenCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.CheckoutsForKeyChildrenCompleted(this, new CheckoutsForKeyChildrenCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000A224 File Offset: 0x00009224
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/ListCheckedOut", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ItemKey[] ListCheckedOut(Guid CheckoutId)
		{
			object[] array = base.Invoke("ListCheckedOut", new object[]
			{
				CheckoutId
			});
			return (ItemKey[])array[0];
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000A256 File Offset: 0x00009256
		public void ListCheckedOutAsync(Guid CheckoutId)
		{
			this.ListCheckedOutAsync(CheckoutId, null);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000A260 File Offset: 0x00009260
		public void ListCheckedOutAsync(Guid CheckoutId, object userState)
		{
			if (this.ListCheckedOutOperationCompleted == null)
			{
				this.ListCheckedOutOperationCompleted = new SendOrPostCallback(this.OnListCheckedOutOperationCompleted);
			}
			base.InvokeAsync("ListCheckedOut", new object[]
			{
				CheckoutId
			}, this.ListCheckedOutOperationCompleted, userState);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000A2AC File Offset: 0x000092AC
		private void OnListCheckedOutOperationCompleted(object arg)
		{
			if (this.ListCheckedOutCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.ListCheckedOutCompleted(this, new ListCheckedOutCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000A2F4 File Offset: 0x000092F4
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/ListCheckedOutKeysOfType", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ItemKey[] ListCheckedOutKeysOfType(ItemType theType)
		{
			object[] array = base.Invoke("ListCheckedOutKeysOfType", new object[]
			{
				theType
			});
			return (ItemKey[])array[0];
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000A326 File Offset: 0x00009326
		public void ListCheckedOutKeysOfTypeAsync(ItemType theType)
		{
			this.ListCheckedOutKeysOfTypeAsync(theType, null);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000A330 File Offset: 0x00009330
		public void ListCheckedOutKeysOfTypeAsync(ItemType theType, object userState)
		{
			if (this.ListCheckedOutKeysOfTypeOperationCompleted == null)
			{
				this.ListCheckedOutKeysOfTypeOperationCompleted = new SendOrPostCallback(this.OnListCheckedOutKeysOfTypeOperationCompleted);
			}
			base.InvokeAsync("ListCheckedOutKeysOfType", new object[]
			{
				theType
			}, this.ListCheckedOutKeysOfTypeOperationCompleted, userState);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000A37C File Offset: 0x0000937C
		private void OnListCheckedOutKeysOfTypeOperationCompleted(object arg)
		{
			if (this.ListCheckedOutKeysOfTypeCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.ListCheckedOutKeysOfTypeCompleted(this, new ListCheckedOutKeysOfTypeCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000A3C4 File Offset: 0x000093C4
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/IsKeyCheckedOut", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public bool IsKeyCheckedOut(ItemKey theKey)
		{
			object[] array = base.Invoke("IsKeyCheckedOut", new object[]
			{
				theKey
			});
			return (bool)array[0];
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000A3F1 File Offset: 0x000093F1
		public void IsKeyCheckedOutAsync(ItemKey theKey)
		{
			this.IsKeyCheckedOutAsync(theKey, null);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000A3FC File Offset: 0x000093FC
		public void IsKeyCheckedOutAsync(ItemKey theKey, object userState)
		{
			if (this.IsKeyCheckedOutOperationCompleted == null)
			{
				this.IsKeyCheckedOutOperationCompleted = new SendOrPostCallback(this.OnIsKeyCheckedOutOperationCompleted);
			}
			base.InvokeAsync("IsKeyCheckedOut", new object[]
			{
				theKey
			}, this.IsKeyCheckedOutOperationCompleted, userState);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000A444 File Offset: 0x00009444
		private void OnIsKeyCheckedOutOperationCompleted(object arg)
		{
			if (this.IsKeyCheckedOutCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.IsKeyCheckedOutCompleted(this, new IsKeyCheckedOutCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000A48C File Offset: 0x0000948C
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/ListCheckedOutChildrenForKey", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		[return: XmlArrayItem(NestingLevel = 1)]
		[return: XmlArrayItem("ArrayOfItemKey")]
		public ItemKey[][] ListCheckedOutChildrenForKey(ItemKey theKey)
		{
			object[] array = base.Invoke("ListCheckedOutChildrenForKey", new object[]
			{
				theKey
			});
			return (ItemKey[][])array[0];
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000A4B9 File Offset: 0x000094B9
		public void ListCheckedOutChildrenForKeyAsync(ItemKey theKey)
		{
			this.ListCheckedOutChildrenForKeyAsync(theKey, null);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000A4C4 File Offset: 0x000094C4
		public void ListCheckedOutChildrenForKeyAsync(ItemKey theKey, object userState)
		{
			if (this.ListCheckedOutChildrenForKeyOperationCompleted == null)
			{
				this.ListCheckedOutChildrenForKeyOperationCompleted = new SendOrPostCallback(this.OnListCheckedOutChildrenForKeyOperationCompleted);
			}
			base.InvokeAsync("ListCheckedOutChildrenForKey", new object[]
			{
				theKey
			}, this.ListCheckedOutChildrenForKeyOperationCompleted, userState);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000A50C File Offset: 0x0000950C
		private void OnListCheckedOutChildrenForKeyOperationCompleted(object arg)
		{
			if (this.ListCheckedOutChildrenForKeyCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.ListCheckedOutChildrenForKeyCompleted(this, new ListCheckedOutChildrenForKeyCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000A554 File Offset: 0x00009554
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/DeleteByKey", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public int DeleteByKey(ItemKey theKey)
		{
			object[] array = base.Invoke("DeleteByKey", new object[]
			{
				theKey
			});
			return (int)array[0];
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000A581 File Offset: 0x00009581
		public void DeleteByKeyAsync(ItemKey theKey)
		{
			this.DeleteByKeyAsync(theKey, null);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000A58C File Offset: 0x0000958C
		public void DeleteByKeyAsync(ItemKey theKey, object userState)
		{
			if (this.DeleteByKeyOperationCompleted == null)
			{
				this.DeleteByKeyOperationCompleted = new SendOrPostCallback(this.OnDeleteByKeyOperationCompleted);
			}
			base.InvokeAsync("DeleteByKey", new object[]
			{
				theKey
			}, this.DeleteByKeyOperationCompleted, userState);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000A5D4 File Offset: 0x000095D4
		private void OnDeleteByKeyOperationCompleted(object arg)
		{
			if (this.DeleteByKeyCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.DeleteByKeyCompleted(this, new DeleteByKeyCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000A61C File Offset: 0x0000961C
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetAllKeysOfType", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ItemKey[] GetAllKeysOfType(ItemType theType)
		{
			object[] array = base.Invoke("GetAllKeysOfType", new object[]
			{
				theType
			});
			return (ItemKey[])array[0];
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000A64E File Offset: 0x0000964E
		public void GetAllKeysOfTypeAsync(ItemType theType)
		{
			this.GetAllKeysOfTypeAsync(theType, null);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000A658 File Offset: 0x00009658
		public void GetAllKeysOfTypeAsync(ItemType theType, object userState)
		{
			if (this.GetAllKeysOfTypeOperationCompleted == null)
			{
				this.GetAllKeysOfTypeOperationCompleted = new SendOrPostCallback(this.OnGetAllKeysOfTypeOperationCompleted);
			}
			base.InvokeAsync("GetAllKeysOfType", new object[]
			{
				theType
			}, this.GetAllKeysOfTypeOperationCompleted, userState);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000A6A4 File Offset: 0x000096A4
		private void OnGetAllKeysOfTypeOperationCompleted(object arg)
		{
			if (this.GetAllKeysOfTypeCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllKeysOfTypeCompleted(this, new GetAllKeysOfTypeCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000A6EC File Offset: 0x000096EC
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetRevisionDatesForKey", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public DateTime[] GetRevisionDatesForKey(ItemKey theKey)
		{
			object[] array = base.Invoke("GetRevisionDatesForKey", new object[]
			{
				theKey
			});
			return (DateTime[])array[0];
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000A719 File Offset: 0x00009719
		public void GetRevisionDatesForKeyAsync(ItemKey theKey)
		{
			this.GetRevisionDatesForKeyAsync(theKey, null);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000A724 File Offset: 0x00009724
		public void GetRevisionDatesForKeyAsync(ItemKey theKey, object userState)
		{
			if (this.GetRevisionDatesForKeyOperationCompleted == null)
			{
				this.GetRevisionDatesForKeyOperationCompleted = new SendOrPostCallback(this.OnGetRevisionDatesForKeyOperationCompleted);
			}
			base.InvokeAsync("GetRevisionDatesForKey", new object[]
			{
				theKey
			}, this.GetRevisionDatesForKeyOperationCompleted, userState);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000A76C File Offset: 0x0000976C
		private void OnGetRevisionDatesForKeyOperationCompleted(object arg)
		{
			if (this.GetRevisionDatesForKeyCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetRevisionDatesForKeyCompleted(this, new GetRevisionDatesForKeyCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000A7B4 File Offset: 0x000097B4
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetXmlDataForKey", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string GetXmlDataForKey(ItemKey theKey)
		{
			object[] array = base.Invoke("GetXmlDataForKey", new object[]
			{
				theKey
			});
			return (string)array[0];
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000A7E1 File Offset: 0x000097E1
		public void GetXmlDataForKeyAsync(ItemKey theKey)
		{
			this.GetXmlDataForKeyAsync(theKey, null);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000A7EC File Offset: 0x000097EC
		public void GetXmlDataForKeyAsync(ItemKey theKey, object userState)
		{
			if (this.GetXmlDataForKeyOperationCompleted == null)
			{
				this.GetXmlDataForKeyOperationCompleted = new SendOrPostCallback(this.OnGetXmlDataForKeyOperationCompleted);
			}
			base.InvokeAsync("GetXmlDataForKey", new object[]
			{
				theKey
			}, this.GetXmlDataForKeyOperationCompleted, userState);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000A834 File Offset: 0x00009834
		private void OnGetXmlDataForKeyOperationCompleted(object arg)
		{
			if (this.GetXmlDataForKeyCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetXmlDataForKeyCompleted(this, new GetXmlDataForKeyCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000A87C File Offset: 0x0000987C
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetXmlDataForKeyDate", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string GetXmlDataForKeyDate(ItemKey theKey, DateTime theDate)
		{
			object[] array = base.Invoke("GetXmlDataForKeyDate", new object[]
			{
				theKey,
				theDate
			});
			return (string)array[0];
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000A8B2 File Offset: 0x000098B2
		public void GetXmlDataForKeyDateAsync(ItemKey theKey, DateTime theDate)
		{
			this.GetXmlDataForKeyDateAsync(theKey, theDate, null);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000A8C0 File Offset: 0x000098C0
		public void GetXmlDataForKeyDateAsync(ItemKey theKey, DateTime theDate, object userState)
		{
			if (this.GetXmlDataForKeyDateOperationCompleted == null)
			{
				this.GetXmlDataForKeyDateOperationCompleted = new SendOrPostCallback(this.OnGetXmlDataForKeyDateOperationCompleted);
			}
			base.InvokeAsync("GetXmlDataForKeyDate", new object[]
			{
				theKey,
				theDate
			}, this.GetXmlDataForKeyDateOperationCompleted, userState);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000A910 File Offset: 0x00009910
		private void OnGetXmlDataForKeyDateOperationCompleted(object arg)
		{
			if (this.GetXmlDataForKeyDateCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetXmlDataForKeyDateCompleted(this, new GetXmlDataForKeyDateCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000A958 File Offset: 0x00009958
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetChildrenForKey", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ItemKey[] GetChildrenForKey(ItemKey theKey)
		{
			object[] array = base.Invoke("GetChildrenForKey", new object[]
			{
				theKey
			});
			return (ItemKey[])array[0];
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000A985 File Offset: 0x00009985
		public void GetChildrenForKeyAsync(ItemKey theKey)
		{
			this.GetChildrenForKeyAsync(theKey, null);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000A990 File Offset: 0x00009990
		public void GetChildrenForKeyAsync(ItemKey theKey, object userState)
		{
			if (this.GetChildrenForKeyOperationCompleted == null)
			{
				this.GetChildrenForKeyOperationCompleted = new SendOrPostCallback(this.OnGetChildrenForKeyOperationCompleted);
			}
			base.InvokeAsync("GetChildrenForKey", new object[]
			{
				theKey
			}, this.GetChildrenForKeyOperationCompleted, userState);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000A9D8 File Offset: 0x000099D8
		private void OnGetChildrenForKeyOperationCompleted(object arg)
		{
			if (this.GetChildrenForKeyCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetChildrenForKeyCompleted(this, new GetChildrenForKeyCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000AA20 File Offset: 0x00009A20
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/TestConnection", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public bool TestConnection()
		{
			object[] array = base.Invoke("TestConnection", new object[0]);
			return (bool)array[0];
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000AA47 File Offset: 0x00009A47
		public void TestConnectionAsync()
		{
			this.TestConnectionAsync(null);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000AA50 File Offset: 0x00009A50
		public void TestConnectionAsync(object userState)
		{
			if (this.TestConnectionOperationCompleted == null)
			{
				this.TestConnectionOperationCompleted = new SendOrPostCallback(this.OnTestConnectionOperationCompleted);
			}
			base.InvokeAsync("TestConnection", new object[0], this.TestConnectionOperationCompleted, userState);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000AA84 File Offset: 0x00009A84
		private void OnTestConnectionOperationCompleted(object arg)
		{
			if (this.TestConnectionCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.TestConnectionCompleted(this, new TestConnectionCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000AACC File Offset: 0x00009ACC
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/IsDatabaseLocked", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public bool IsDatabaseLocked()
		{
			object[] array = base.Invoke("IsDatabaseLocked", new object[0]);
			return (bool)array[0];
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000AAF3 File Offset: 0x00009AF3
		public void IsDatabaseLockedAsync()
		{
			this.IsDatabaseLockedAsync(null);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000AAFC File Offset: 0x00009AFC
		public void IsDatabaseLockedAsync(object userState)
		{
			if (this.IsDatabaseLockedOperationCompleted == null)
			{
				this.IsDatabaseLockedOperationCompleted = new SendOrPostCallback(this.OnIsDatabaseLockedOperationCompleted);
			}
			base.InvokeAsync("IsDatabaseLocked", new object[0], this.IsDatabaseLockedOperationCompleted, userState);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000AB30 File Offset: 0x00009B30
		private void OnIsDatabaseLockedOperationCompleted(object arg)
		{
			if (this.IsDatabaseLockedCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.IsDatabaseLockedCompleted(this, new IsDatabaseLockedCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000AB78 File Offset: 0x00009B78
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetDatabaseLockInformation", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public DatabaseLock GetDatabaseLockInformation()
		{
			object[] array = base.Invoke("GetDatabaseLockInformation", new object[0]);
			return (DatabaseLock)array[0];
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000AB9F File Offset: 0x00009B9F
		public void GetDatabaseLockInformationAsync()
		{
			this.GetDatabaseLockInformationAsync(null);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000ABA8 File Offset: 0x00009BA8
		public void GetDatabaseLockInformationAsync(object userState)
		{
			if (this.GetDatabaseLockInformationOperationCompleted == null)
			{
				this.GetDatabaseLockInformationOperationCompleted = new SendOrPostCallback(this.OnGetDatabaseLockInformationOperationCompleted);
			}
			base.InvokeAsync("GetDatabaseLockInformation", new object[0], this.GetDatabaseLockInformationOperationCompleted, userState);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000ABDC File Offset: 0x00009BDC
		private void OnGetDatabaseLockInformationOperationCompleted(object arg)
		{
			if (this.GetDatabaseLockInformationCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetDatabaseLockInformationCompleted(this, new GetDatabaseLockInformationCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000AC24 File Offset: 0x00009C24
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetAllPrototypesNoXmlData", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ObjectPrototype[] GetAllPrototypesNoXmlData()
		{
			object[] array = base.Invoke("GetAllPrototypesNoXmlData", new object[0]);
			return (ObjectPrototype[])array[0];
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000AC4B File Offset: 0x00009C4B
		public void GetAllPrototypesNoXmlDataAsync()
		{
			this.GetAllPrototypesNoXmlDataAsync(null);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000AC54 File Offset: 0x00009C54
		public void GetAllPrototypesNoXmlDataAsync(object userState)
		{
			if (this.GetAllPrototypesNoXmlDataOperationCompleted == null)
			{
				this.GetAllPrototypesNoXmlDataOperationCompleted = new SendOrPostCallback(this.OnGetAllPrototypesNoXmlDataOperationCompleted);
			}
			base.InvokeAsync("GetAllPrototypesNoXmlData", new object[0], this.GetAllPrototypesNoXmlDataOperationCompleted, userState);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000AC88 File Offset: 0x00009C88
		private void OnGetAllPrototypesNoXmlDataOperationCompleted(object arg)
		{
			if (this.GetAllPrototypesNoXmlDataCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllPrototypesNoXmlDataCompleted(this, new GetAllPrototypesNoXmlDataCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000ACD0 File Offset: 0x00009CD0
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/CheckoutPrototype", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public Guid CheckoutPrototype(string PrototypeName, long GroupId, Guid CheckoutId)
		{
			object[] array = base.Invoke("CheckoutPrototype", new object[]
			{
				PrototypeName,
				GroupId,
				CheckoutId
			});
			return (Guid)array[0];
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000AD0F File Offset: 0x00009D0F
		public void CheckoutPrototypeAsync(string PrototypeName, long GroupId, Guid CheckoutId)
		{
			this.CheckoutPrototypeAsync(PrototypeName, GroupId, CheckoutId, null);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000AD1C File Offset: 0x00009D1C
		public void CheckoutPrototypeAsync(string PrototypeName, long GroupId, Guid CheckoutId, object userState)
		{
			if (this.CheckoutPrototypeOperationCompleted == null)
			{
				this.CheckoutPrototypeOperationCompleted = new SendOrPostCallback(this.OnCheckoutPrototypeOperationCompleted);
			}
			base.InvokeAsync("CheckoutPrototype", new object[]
			{
				PrototypeName,
				GroupId,
				CheckoutId
			}, this.CheckoutPrototypeOperationCompleted, userState);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0000AD74 File Offset: 0x00009D74
		private void OnCheckoutPrototypeOperationCompleted(object arg)
		{
			if (this.CheckoutPrototypeCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.CheckoutPrototypeCompleted(this, new CheckoutPrototypeCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000ADBC File Offset: 0x00009DBC
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetDatabaseItemTree", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public DBItemInfo[] GetDatabaseItemTree()
		{
			object[] array = base.Invoke("GetDatabaseItemTree", new object[0]);
			return (DBItemInfo[])array[0];
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000ADE3 File Offset: 0x00009DE3
		public void GetDatabaseItemTreeAsync()
		{
			this.GetDatabaseItemTreeAsync(null);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000ADEC File Offset: 0x00009DEC
		public void GetDatabaseItemTreeAsync(object userState)
		{
			if (this.GetDatabaseItemTreeOperationCompleted == null)
			{
				this.GetDatabaseItemTreeOperationCompleted = new SendOrPostCallback(this.OnGetDatabaseItemTreeOperationCompleted);
			}
			base.InvokeAsync("GetDatabaseItemTree", new object[0], this.GetDatabaseItemTreeOperationCompleted, userState);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000AE20 File Offset: 0x00009E20
		private void OnGetDatabaseItemTreeOperationCompleted(object arg)
		{
			if (this.GetDatabaseItemTreeCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetDatabaseItemTreeCompleted(this, new GetDatabaseItemTreeCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0000AE68 File Offset: 0x00009E68
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetAllInstancesByDate", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public ObjectInstance[] GetAllInstancesByDate(DateTime DateOnWhich)
		{
			object[] array = base.Invoke("GetAllInstancesByDate", new object[]
			{
				DateOnWhich
			});
			return (ObjectInstance[])array[0];
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000AE9A File Offset: 0x00009E9A
		public void GetAllInstancesByDateAsync(DateTime DateOnWhich)
		{
			this.GetAllInstancesByDateAsync(DateOnWhich, null);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000AEA4 File Offset: 0x00009EA4
		public void GetAllInstancesByDateAsync(DateTime DateOnWhich, object userState)
		{
			if (this.GetAllInstancesByDateOperationCompleted == null)
			{
				this.GetAllInstancesByDateOperationCompleted = new SendOrPostCallback(this.OnGetAllInstancesByDateOperationCompleted);
			}
			base.InvokeAsync("GetAllInstancesByDate", new object[]
			{
				DateOnWhich
			}, this.GetAllInstancesByDateOperationCompleted, userState);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000AEF0 File Offset: 0x00009EF0
		private void OnGetAllInstancesByDateOperationCompleted(object arg)
		{
			if (this.GetAllInstancesByDateCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllInstancesByDateCompleted(this, new GetAllInstancesByDateCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000AF38 File Offset: 0x00009F38
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/GetAllInstancesXml", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string GetAllInstancesXml()
		{
			object[] array = base.Invoke("GetAllInstancesXml", new object[0]);
			return (string)array[0];
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000AF5F File Offset: 0x00009F5F
		public void GetAllInstancesXmlAsync()
		{
			this.GetAllInstancesXmlAsync(null);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000AF68 File Offset: 0x00009F68
		public void GetAllInstancesXmlAsync(object userState)
		{
			if (this.GetAllInstancesXmlOperationCompleted == null)
			{
				this.GetAllInstancesXmlOperationCompleted = new SendOrPostCallback(this.OnGetAllInstancesXmlOperationCompleted);
			}
			base.InvokeAsync("GetAllInstancesXml", new object[0], this.GetAllInstancesXmlOperationCompleted, userState);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000AF9C File Offset: 0x00009F9C
		private void OnGetAllInstancesXmlOperationCompleted(object arg)
		{
			if (this.GetAllInstancesXmlCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.GetAllInstancesXmlCompleted(this, new GetAllInstancesXmlCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000AFE4 File Offset: 0x00009FE4
		[SoapDocumentMethod("http://ctrimble-0269.rws.ad.ea.com/Sims3Meta/XmlBulkExportForDate", RequestNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", ResponseNamespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
		public string XmlBulkExportForDate(ItemType theType, DateTime DateOnWhich)
		{
			object[] array = base.Invoke("XmlBulkExportForDate", new object[]
			{
				theType,
				DateOnWhich
			});
			return (string)array[0];
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000B01F File Offset: 0x0000A01F
		public void XmlBulkExportForDateAsync(ItemType theType, DateTime DateOnWhich)
		{
			this.XmlBulkExportForDateAsync(theType, DateOnWhich, null);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000B02C File Offset: 0x0000A02C
		public void XmlBulkExportForDateAsync(ItemType theType, DateTime DateOnWhich, object userState)
		{
			if (this.XmlBulkExportForDateOperationCompleted == null)
			{
				this.XmlBulkExportForDateOperationCompleted = new SendOrPostCallback(this.OnXmlBulkExportForDateOperationCompleted);
			}
			base.InvokeAsync("XmlBulkExportForDate", new object[]
			{
				theType,
				DateOnWhich
			}, this.XmlBulkExportForDateOperationCompleted, userState);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000B080 File Offset: 0x0000A080
		private void OnXmlBulkExportForDateOperationCompleted(object arg)
		{
			if (this.XmlBulkExportForDateCompleted != null)
			{
				InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
				this.XmlBulkExportForDateCompleted(this, new XmlBulkExportForDateCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
			}
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000B0C5 File Offset: 0x0000A0C5
		public new void CancelAsync(object userState)
		{
			base.CancelAsync(userState);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000B0D0 File Offset: 0x0000A0D0
		private bool IsLocalFileSystemWebService(string url)
		{
			if (url == null || url == string.Empty)
			{
				return false;
			}
			Uri uri = new Uri(url);
			return uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000B11C File Offset: 0x0000A11C
		protected override WebRequest GetWebRequest(Uri uri)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)base.GetWebRequest(uri);
			httpWebRequest.KeepAlive = false;
			httpWebRequest.ProtocolVersion = HttpVersion.Version10;
			return httpWebRequest;
		}

		// Token: 0x04000070 RID: 112
		private SendOrPostCallback GetClassByKeyOperationCompleted;

		// Token: 0x04000071 RID: 113
		private SendOrPostCallback GetClassByKeyDateOperationCompleted;

		// Token: 0x04000072 RID: 114
		private SendOrPostCallback InsertClassOperationCompleted;

		// Token: 0x04000073 RID: 115
		private SendOrPostCallback UpdateClassOperationCompleted;

		// Token: 0x04000074 RID: 116
		private SendOrPostCallback InsertPrototypeOperationCompleted;

		// Token: 0x04000075 RID: 117
		private SendOrPostCallback UpdatePrototypeOperationCompleted;

		// Token: 0x04000076 RID: 118
		private SendOrPostCallback GetPrototypeByKeyOperationCompleted;

		// Token: 0x04000077 RID: 119
		private SendOrPostCallback GetPrototypeByKeyDateOperationCompleted;

		// Token: 0x04000078 RID: 120
		private SendOrPostCallback GetInstanceByKeyOperationCompleted;

		// Token: 0x04000079 RID: 121
		private SendOrPostCallback GetInstanceByKeyDateOperationCompleted;

		// Token: 0x0400007A RID: 122
		private SendOrPostCallback InsertInstanceOperationCompleted;

		// Token: 0x0400007B RID: 123
		private SendOrPostCallback UpdateInstanceOperationCompleted;

		// Token: 0x0400007C RID: 124
		private SendOrPostCallback BulkInsertInstancesOperationCompleted;

		// Token: 0x0400007D RID: 125
		private SendOrPostCallback GetAllInstancesOperationCompleted;

		// Token: 0x0400007E RID: 126
		private SendOrPostCallback GetInstanceKeysForClassKeyOperationCompleted;

		// Token: 0x0400007F RID: 127
		private SendOrPostCallback GetInstancesForClassKeyNoXmlDataOperationCompleted;

		// Token: 0x04000080 RID: 128
		private SendOrPostCallback GetReferencesByInstanceOperationCompleted;

		// Token: 0x04000081 RID: 129
		private SendOrPostCallback GetInstancesByReferenceOperationCompleted;

		// Token: 0x04000082 RID: 130
		private SendOrPostCallback CheckinOperationCompleted;

		// Token: 0x04000083 RID: 131
		private SendOrPostCallback CheckinKeyOperationCompleted;

		// Token: 0x04000084 RID: 132
		private SendOrPostCallback CheckoutOperationCompleted;

		// Token: 0x04000085 RID: 133
		private SendOrPostCallback CheckoutAddToExistingOperationCompleted;

		// Token: 0x04000086 RID: 134
		private SendOrPostCallback GetCheckoutsForCurrentUserOperationCompleted;

		// Token: 0x04000087 RID: 135
		private SendOrPostCallback GetCheckoutUserForKeyOperationCompleted;

		// Token: 0x04000088 RID: 136
		private SendOrPostCallback CheckoutsForKeyChildrenOperationCompleted;

		// Token: 0x04000089 RID: 137
		private SendOrPostCallback ListCheckedOutOperationCompleted;

		// Token: 0x0400008A RID: 138
		private SendOrPostCallback ListCheckedOutKeysOfTypeOperationCompleted;

		// Token: 0x0400008B RID: 139
		private SendOrPostCallback IsKeyCheckedOutOperationCompleted;

		// Token: 0x0400008C RID: 140
		private SendOrPostCallback ListCheckedOutChildrenForKeyOperationCompleted;

		// Token: 0x0400008D RID: 141
		private SendOrPostCallback DeleteByKeyOperationCompleted;

		// Token: 0x0400008E RID: 142
		private SendOrPostCallback GetAllKeysOfTypeOperationCompleted;

		// Token: 0x0400008F RID: 143
		private SendOrPostCallback GetRevisionDatesForKeyOperationCompleted;

		// Token: 0x04000090 RID: 144
		private SendOrPostCallback GetXmlDataForKeyOperationCompleted;

		// Token: 0x04000091 RID: 145
		private SendOrPostCallback GetXmlDataForKeyDateOperationCompleted;

		// Token: 0x04000092 RID: 146
		private SendOrPostCallback GetChildrenForKeyOperationCompleted;

		// Token: 0x04000093 RID: 147
		private SendOrPostCallback TestConnectionOperationCompleted;

		// Token: 0x04000094 RID: 148
		private SendOrPostCallback IsDatabaseLockedOperationCompleted;

		// Token: 0x04000095 RID: 149
		private SendOrPostCallback GetDatabaseLockInformationOperationCompleted;

		// Token: 0x04000096 RID: 150
		private SendOrPostCallback GetAllPrototypesNoXmlDataOperationCompleted;

		// Token: 0x04000097 RID: 151
		private SendOrPostCallback CheckoutPrototypeOperationCompleted;

		// Token: 0x04000098 RID: 152
		private SendOrPostCallback GetDatabaseItemTreeOperationCompleted;

		// Token: 0x04000099 RID: 153
		private SendOrPostCallback GetAllInstancesByDateOperationCompleted;

		// Token: 0x0400009A RID: 154
		private SendOrPostCallback GetAllInstancesXmlOperationCompleted;

		// Token: 0x0400009B RID: 155
		private SendOrPostCallback XmlBulkExportForDateOperationCompleted;

		// Token: 0x0400009C RID: 156
		private bool useDefaultCredentialsSetExplicitly;
	}
}
