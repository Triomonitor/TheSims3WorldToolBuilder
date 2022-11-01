using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ToolUtil.RevisionControl
{
	// Token: 0x0200001B RID: 27
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
	internal class Resource
	{
		// Token: 0x06000187 RID: 391 RVA: 0x00009647 File Offset: 0x00008647
		internal Resource()
		{
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00009650 File Offset: 0x00008650
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resource.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("ToolUtil.RevisionControl.Resource", typeof(Resource).Assembly);
					Resource.resourceMan = resourceManager;
				}
				return Resource.resourceMan;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000189 RID: 393 RVA: 0x0000968F File Offset: 0x0000868F
		// (set) Token: 0x0600018A RID: 394 RVA: 0x00009696 File Offset: 0x00008696
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resource.resourceCulture;
			}
			set
			{
				Resource.resourceCulture = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600018B RID: 395 RVA: 0x0000969E File Offset: 0x0000869E
		internal static string Error_Add
		{
			get
			{
				return Resource.ResourceManager.GetString("Error_Add", Resource.resourceCulture);
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600018C RID: 396 RVA: 0x000096B4 File Offset: 0x000086B4
		internal static string Error_Delete
		{
			get
			{
				return Resource.ResourceManager.GetString("Error_Delete", Resource.resourceCulture);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600018D RID: 397 RVA: 0x000096CA File Offset: 0x000086CA
		internal static string Error_Edit
		{
			get
			{
				return Resource.ResourceManager.GetString("Error_Edit", Resource.resourceCulture);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600018E RID: 398 RVA: 0x000096E0 File Offset: 0x000086E0
		internal static string Error_Rename
		{
			get
			{
				return Resource.ResourceManager.GetString("Error_Rename", Resource.resourceCulture);
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600018F RID: 399 RVA: 0x000096F6 File Offset: 0x000086F6
		internal static string ErrorRename_RCSDisabled
		{
			get
			{
				return Resource.ResourceManager.GetString("ErrorRename_RCSDisabled", Resource.resourceCulture);
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000190 RID: 400 RVA: 0x0000970C File Offset: 0x0000870C
		internal static string InvalidArguments
		{
			get
			{
				return Resource.ResourceManager.GetString("InvalidArguments", Resource.resourceCulture);
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000191 RID: 401 RVA: 0x00009722 File Offset: 0x00008722
		internal static string kError_ChangeListEmpty
		{
			get
			{
				return Resource.ResourceManager.GetString("kError_ChangeListEmpty", Resource.resourceCulture);
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00009738 File Offset: 0x00008738
		internal static string kError_RCSNull
		{
			get
			{
				return Resource.ResourceManager.GetString("kError_RCSNull", Resource.resourceCulture);
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000193 RID: 403 RVA: 0x0000974E File Offset: 0x0000874E
		internal static string kError_RenameOpenFile
		{
			get
			{
				return Resource.ResourceManager.GetString("kError_RenameOpenFile", Resource.resourceCulture);
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00009764 File Offset: 0x00008764
		internal static string kError_UnableToSubmitFiles
		{
			get
			{
				return Resource.ResourceManager.GetString("kError_UnableToSubmitFiles", Resource.resourceCulture);
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000977A File Offset: 0x0000877A
		internal static string kQuery_Revert
		{
			get
			{
				return Resource.ResourceManager.GetString("kQuery_Revert", Resource.resourceCulture);
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00009790 File Offset: 0x00008790
		internal static string kRCS_OpenForAddQuery
		{
			get
			{
				return Resource.ResourceManager.GetString("kRCS_OpenForAddQuery", Resource.resourceCulture);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000197 RID: 407 RVA: 0x000097A6 File Offset: 0x000087A6
		internal static string kRCS_OpenForDeleteQuery
		{
			get
			{
				return Resource.ResourceManager.GetString("kRCS_OpenForDeleteQuery", Resource.resourceCulture);
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000198 RID: 408 RVA: 0x000097BC File Offset: 0x000087BC
		internal static string kRCS_OpenForEditQuery
		{
			get
			{
				return Resource.ResourceManager.GetString("kRCS_OpenForEditQuery", Resource.resourceCulture);
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000199 RID: 409 RVA: 0x000097D2 File Offset: 0x000087D2
		internal static string kRCS_OpenForRenameQuery
		{
			get
			{
				return Resource.ResourceManager.GetString("kRCS_OpenForRenameQuery", Resource.resourceCulture);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600019A RID: 410 RVA: 0x000097E8 File Offset: 0x000087E8
		internal static string kRenameWarning
		{
			get
			{
				return Resource.ResourceManager.GetString("kRenameWarning", Resource.resourceCulture);
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600019B RID: 411 RVA: 0x000097FE File Offset: 0x000087FE
		internal static string kRevert_Caption
		{
			get
			{
				return Resource.ResourceManager.GetString("kRevert_Caption", Resource.resourceCulture);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600019C RID: 412 RVA: 0x00009814 File Offset: 0x00008814
		internal static string kSubmit_Caption
		{
			get
			{
				return Resource.ResourceManager.GetString("kSubmit_Caption", Resource.resourceCulture);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600019D RID: 413 RVA: 0x0000982A File Offset: 0x0000882A
		internal static string kSuccess_AllFilesSubmitted
		{
			get
			{
				return Resource.ResourceManager.GetString("kSuccess_AllFilesSubmitted", Resource.resourceCulture);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00009840 File Offset: 0x00008840
		internal static string kValidationError_Caption
		{
			get
			{
				return Resource.ResourceManager.GetString("kValidationError_Caption", Resource.resourceCulture);
			}
		}

		// Token: 0x040000CB RID: 203
		private static ResourceManager resourceMan;

		// Token: 0x040000CC RID: 204
		private static CultureInfo resourceCulture;
	}
}
