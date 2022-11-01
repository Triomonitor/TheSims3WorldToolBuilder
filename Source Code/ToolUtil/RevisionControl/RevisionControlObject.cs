using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Sims3;
using Sims3.RevisionControl;

namespace ToolUtil.RevisionControl
{
	// Token: 0x0200002C RID: 44
	public abstract class RevisionControlObject
	{
		// Token: 0x14000036 RID: 54
		// (add) Token: 0x060001F0 RID: 496 RVA: 0x0000AF76 File Offset: 0x00009F76
		// (remove) Token: 0x060001F1 RID: 497 RVA: 0x0000AF8D File Offset: 0x00009F8D
		private static event RevObjStatusChangedHandler sStatusChangedEvent;

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x060001F2 RID: 498 RVA: 0x0000AFA4 File Offset: 0x00009FA4
		// (remove) Token: 0x060001F3 RID: 499 RVA: 0x0000AFBB File Offset: 0x00009FBB
		public static event RevObjStatusChangedHandler StatusChangedEvent
		{
			add
			{
				RevisionControlObject.sStatusChangedEvent = (RevObjStatusChangedHandler)Delegate.Combine(RevisionControlObject.sStatusChangedEvent, value);
			}
			remove
			{
				RevisionControlObject.sStatusChangedEvent = (RevObjStatusChangedHandler)Delegate.Remove(RevisionControlObject.sStatusChangedEvent, value);
			}
		}

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x060001F4 RID: 500 RVA: 0x0000AFD2 File Offset: 0x00009FD2
		// (remove) Token: 0x060001F5 RID: 501 RVA: 0x0000AFE9 File Offset: 0x00009FE9
		private static event RevObjReloadedHandler sReloadedEvent;

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x060001F6 RID: 502 RVA: 0x0000B000 File Offset: 0x0000A000
		// (remove) Token: 0x060001F7 RID: 503 RVA: 0x0000B017 File Offset: 0x0000A017
		public static event RevObjReloadedHandler ReloadedEvent
		{
			add
			{
				RevisionControlObject.sReloadedEvent = (RevObjReloadedHandler)Delegate.Combine(RevisionControlObject.sReloadedEvent, value);
			}
			remove
			{
				RevisionControlObject.sReloadedEvent = (RevObjReloadedHandler)Delegate.Remove(RevisionControlObject.sReloadedEvent, value);
			}
		}

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x060001F8 RID: 504 RVA: 0x0000B02E File Offset: 0x0000A02E
		// (remove) Token: 0x060001F9 RID: 505 RVA: 0x0000B045 File Offset: 0x0000A045
		private static event RevObjOutofSyncHandler sOutofSyncEvent;

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x060001FA RID: 506 RVA: 0x0000B05C File Offset: 0x0000A05C
		// (remove) Token: 0x060001FB RID: 507 RVA: 0x0000B073 File Offset: 0x0000A073
		public static event RevObjOutofSyncHandler OutofSyncEvent
		{
			add
			{
				RevisionControlObject.sOutofSyncEvent = (RevObjOutofSyncHandler)Delegate.Combine(RevisionControlObject.sOutofSyncEvent, value);
			}
			remove
			{
				RevisionControlObject.sOutofSyncEvent = (RevObjOutofSyncHandler)Delegate.Remove(RevisionControlObject.sOutofSyncEvent, value);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001FC RID: 508 RVA: 0x0000B08A File Offset: 0x0000A08A
		public RCSFileStatusType Status
		{
			get
			{
				return this.mStatus;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001FD RID: 509 RVA: 0x0000B092 File Offset: 0x0000A092
		[Browsable(false)]
		public bool IsRCSInited
		{
			get
			{
				return this.mbRCSInited;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001FE RID: 510 RVA: 0x0000B09A File Offset: 0x0000A09A
		// (set) Token: 0x060001FF RID: 511 RVA: 0x0000B0A2 File Offset: 0x0000A0A2
		[Browsable(false)]
		public string[] SourceFiles
		{
			get
			{
				return this.mSourceFiles;
			}
			set
			{
				this.mSourceFiles = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000200 RID: 512 RVA: 0x0000B0AB File Offset: 0x0000A0AB
		// (set) Token: 0x06000201 RID: 513 RVA: 0x0000B0B3 File Offset: 0x0000A0B3
		[Browsable(false)]
		public RCS RCSControl
		{
			get
			{
				return this.mRevControl;
			}
			set
			{
				this.mRevControl = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000202 RID: 514 RVA: 0x0000B0BC File Offset: 0x0000A0BC
		// (set) Token: 0x06000203 RID: 515 RVA: 0x0000B0C4 File Offset: 0x0000A0C4
		[Browsable(false)]
		public string ChangeListDesc
		{
			get
			{
				return this.mChangeListDesc;
			}
			set
			{
				this.mChangeListDesc = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000B0CD File Offset: 0x0000A0CD
		[Browsable(false)]
		public bool IsEditable
		{
			get
			{
				return this.mbEditable;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000205 RID: 517 RVA: 0x0000B0D5 File Offset: 0x0000A0D5
		// (set) Token: 0x06000206 RID: 518 RVA: 0x0000B0DD File Offset: 0x0000A0DD
		[Browsable(false)]
		public bool EnableRCS
		{
			get
			{
				return this.mbEnableRCS;
			}
			set
			{
				if (this.mbEnableRCS == value)
				{
					return;
				}
				this.mbEnableRCS = value;
				if (this.mbRCSInited && this.mbEnableRCS)
				{
					Log.gInfo("RevControl", "RCS reanbled: Updating status", new object[0]);
					this.UpdateRCS();
				}
			}
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000B11C File Offset: 0x0000A11C
		public bool IsPartofOpenChangeList()
		{
			if (this.mbRCSInited && this.mbEnableRCS)
			{
				switch (this.mStatus)
				{
				case RCSFileStatusType.kOpenForAdd:
				case RCSFileStatusType.kOpenForEdit:
				case RCSFileStatusType.kOpenForDelete:
				case RCSFileStatusType.kOpenForRename:
				case RCSFileStatusType.kOpenForBranch:
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000208 RID: 520
		public abstract void InitRCS();

		// Token: 0x06000209 RID: 521
		public abstract void UpdateRCS();

		// Token: 0x0600020A RID: 522 RVA: 0x0000B164 File Offset: 0x0000A164
		public void CopyRCS(RevisionControlObject source)
		{
			Log.gInfo("RevControl", "Copying RCS info", new object[0]);
			this.mbEnableRCS = source.mbEnableRCS;
			this.mbRCSInited = source.mbRCSInited;
			this.mChangeListDesc = source.mChangeListDesc;
			this.mSourceFiles = source.mSourceFiles;
			this.mStatus = source.mStatus;
			this.mbEditable = source.mbEditable;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000B1D0 File Offset: 0x0000A1D0
		protected void InitRCS(RCS revControl, string[] fileNames, string changeList)
		{
			Log.gInfo("RevControl", "Initializing RCS for files {0} and changelist {1}", new object[]
			{
				RevisionControlObject.GetStringArrayAsString(fileNames),
				changeList
			});
			this.ShutdownRCS();
			if (!this.mbEditable && !this.mbRCSInited)
			{
				this.mRevControl = revControl;
				this.mSourceFiles = fileNames;
				this.mChangeListDesc = changeList;
				if (!this.mbEnableRCS || revControl == null || fileNames == null || fileNames.Length <= 0 || string.IsNullOrEmpty(changeList))
				{
					this.mbEditable = true;
					this.mbRCSInited = true;
					this.mStatus = RCSFileStatusType.kNotUnderAnyClientSpec;
					return;
				}
				this.mStatus = this.mRevControl.GetStatus(this.mSourceFiles[0]);
				if (this.mStatus == RCSFileStatusType.kOpenForAdd || this.mStatus == RCSFileStatusType.kOpenForEdit)
				{
					this.mbEditable = true;
				}
				this.mbRCSInited = true;
				if (RevisionControlObject.sStatusChangedEvent != null)
				{
					RevisionControlObject.sStatusChangedEvent(this, new EventArgs());
				}
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000B2B4 File Offset: 0x0000A2B4
		protected void UpdateRCS(RCS revControl, string[] fileNames, string changeList)
		{
			if (revControl == null || string.IsNullOrEmpty(changeList) || fileNames == null || fileNames.Length <= 0)
			{
				throw new ArgumentException(Resource.InvalidArguments);
			}
			Log.gInfo("RevControl", "Updating RCS for files {0} and changelist {1}", new object[]
			{
				RevisionControlObject.GetStringArrayAsString(fileNames),
				changeList
			});
			if (this.mbRCSInited)
			{
				this.mRevControl = revControl;
				this.mSourceFiles = fileNames;
				this.mChangeListDesc = changeList;
				if (!this.mbEnableRCS)
				{
					return;
				}
				RCSFileStatusType rcsfileStatusType = this.mStatus;
				this.mStatus = this.mRevControl.GetStatus(this.mSourceFiles[0]);
				if (this.mStatus == RCSFileStatusType.kOpenForAdd || this.mStatus == RCSFileStatusType.kOpenForEdit)
				{
					this.mbEditable = true;
				}
				else
				{
					this.mbEditable = false;
				}
				if (rcsfileStatusType != this.mStatus && RevisionControlObject.sStatusChangedEvent != null)
				{
					RevisionControlObject.sStatusChangedEvent(this, new EventArgs());
				}
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000B38F File Offset: 0x0000A38F
		public virtual void ShutdownRCS()
		{
			if (this.mbRCSInited)
			{
				this.mbRCSInited = false;
				this.mSourceFiles = null;
				this.mChangeListDesc = null;
				this.mRevControl = null;
				this.mStatus = RCSFileStatusType.kNotUnderAnyClientSpec;
				this.mbEditable = false;
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000B3C4 File Offset: 0x0000A3C4
		protected virtual bool SyncToHead()
		{
			if (this.mbRCSInited && this.mbEnableRCS)
			{
				Log.gInfo("RevControl", "Syncing files {0}", new object[]
				{
					RevisionControlObject.GetStringArrayAsString(this.mSourceFiles)
				});
				return this.mRevControl != null && this.mSourceFiles != null && this.mSourceFiles.Length > 0 && this.mRevControl.SyncToHead(this.mSourceFiles);
			}
			return true;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000B436 File Offset: 0x0000A436
		public virtual void OnRevertChangeList()
		{
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000B438 File Offset: 0x0000A438
		public virtual void OnChangeListReverted()
		{
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000B43A File Offset: 0x0000A43A
		public virtual bool Reload()
		{
			return true;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000B43D File Offset: 0x0000A43D
		protected virtual void ReleaseFilesLock()
		{
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000B43F File Offset: 0x0000A43F
		protected virtual void RegainFilesLock()
		{
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000B444 File Offset: 0x0000A444
		public virtual void RefreshRCS()
		{
			if (this.mbEnableRCS && this.mbRCSInited)
			{
				RCSFileStatusType rcsfileStatusType = this.mStatus;
				this.mStatus = ((this.mSourceFiles != null) ? this.mRevControl.GetStatus(this.mSourceFiles[0]) : RCSFileStatusType.kNotOpened);
				if (this.mStatus == RCSFileStatusType.kOpenForAdd || this.mStatus == RCSFileStatusType.kOpenForEdit)
				{
					this.mbEditable = true;
				}
				else if (this.mStatus == RCSFileStatusType.kNotOpened)
				{
					this.mbEditable = false;
				}
				if (RevisionControlObject.sStatusChangedEvent != null && rcsfileStatusType != this.mStatus)
				{
					RevisionControlObject.sStatusChangedEvent(this, new EventArgs());
				}
			}
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000B4D8 File Offset: 0x0000A4D8
		public virtual bool TryEdit()
		{
			if (!this.mbEnableRCS)
			{
				return true;
			}
			if (!this.mbRCSInited)
			{
				return true;
			}
			if (this.mbEditable || this.mStatus == RCSFileStatusType.kNotUnderAnyClientSpec)
			{
				return true;
			}
			if (this.mRevControl != null && this.mRevControl.IsRCSAvailable)
			{
				return this.mSourceFiles != null && this.mSourceFiles.Length > 0 && this.OpenFilesForEdit();
			}
			this.mbEditable = true;
			return this.mbEditable;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000B54C File Offset: 0x0000A54C
		public virtual bool TryAdd()
		{
			return !this.mbEnableRCS || !this.mbRCSInited || this.mRevControl == null || !this.mRevControl.IsRCSAvailable || (this.mSourceFiles != null && this.mSourceFiles.Length > 0 && this.OpenFilesForAdd());
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000B5A0 File Offset: 0x0000A5A0
		public virtual bool TryRemove()
		{
			return !this.mbEnableRCS || !this.mbRCSInited || this.mRevControl == null || !this.mRevControl.IsRCSAvailable || this.mSourceFiles == null || this.mSourceFiles.Length <= 0 || this.OpenFilesForRemove();
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000B5F4 File Offset: 0x0000A5F4
		public virtual bool TryRename(string[] newfileNames)
		{
			if (!this.mbEnableRCS)
			{
				throw new RCSException(newfileNames, Resource.ErrorRename_RCSDisabled, string.Empty);
			}
			if (!this.mbRCSInited || this.mRevControl == null || !this.mRevControl.IsRCSAvailable)
			{
				return true;
			}
			if (this.mSourceFiles != null && this.mSourceFiles.Length > 0 && newfileNames != null && newfileNames.Length > 0)
			{
				for (int i = 0; i < this.mSourceFiles.Length; i++)
				{
					if (string.IsNullOrEmpty(newfileNames[i]) || this.mSourceFiles[i].CompareTo(newfileNames[i]) == 0)
					{
						Log.gWarn("RevControl", "TryRename failed, Invalid filenames ", new object[0]);
						return false;
					}
				}
				return this.OpenFilesForRename(newfileNames);
			}
			return false;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000B6A8 File Offset: 0x0000A6A8
		private bool OpenFilesForEdit()
		{
			if (!this.mbRCSInited || !this.mbEnableRCS)
			{
				return false;
			}
			if (!this.ShowEditForm(RevisionControlObject.Operation.kEdit))
			{
				return false;
			}
			Log.gInfo("RevControl", "Opening files for edit {0} in CL {1}", new object[]
			{
				new object[]
				{
					RevisionControlObject.GetStringArrayAsString(this.mSourceFiles)
				},
				this.mChangeListDesc
			});
			if (string.IsNullOrEmpty(this.mChangeListDesc))
			{
				this.mChangeListDesc = this.mRevControl.DefaultChangeListDescription;
			}
			int num = this.mRevControl.GetChangeListByDescription(this.mChangeListDesc);
			if (num == 0)
			{
				num = this.mRevControl.CreateChangeList(this.mChangeListDesc);
			}
			if (!this.mRevControl.AreFilesInSync(this.mSourceFiles) && !this.OnFilesOutofSync())
			{
				return false;
			}
			this.mRevControl.OpenForEdit(num, this.mSourceFiles);
			this.mStatus = this.mRevControl.GetStatus(this.mSourceFiles[0]);
			if (this.mStatus != RCSFileStatusType.kOpenForEdit)
			{
				Log.gWarn("RevControl", "Failed to Edit files {0}", new object[]
				{
					RevisionControlObject.GetStringArrayAsString(this.mSourceFiles)
				});
				throw new RCSException(this.mSourceFiles, Resource.Error_Edit, this.mChangeListDesc);
			}
			this.mbEditable = true;
			if (RevisionControlObject.sStatusChangedEvent != null)
			{
				RevisionControlObject.sStatusChangedEvent(this, new EventArgs());
			}
			return this.mbEditable;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000B808 File Offset: 0x0000A808
		private bool OpenFilesForAdd()
		{
			if (!this.mbRCSInited || !this.mbEnableRCS)
			{
				return false;
			}
			if (!this.ShowEditForm(RevisionControlObject.Operation.kAdd))
			{
				return false;
			}
			Log.gInfo("RevControl", "Opening files for Add {0} in CL {1}", new object[]
			{
				new object[]
				{
					RevisionControlObject.GetStringArrayAsString(this.mSourceFiles)
				},
				this.mChangeListDesc
			});
			if (string.IsNullOrEmpty(this.mChangeListDesc))
			{
				this.mChangeListDesc = this.mRevControl.DefaultChangeListDescription;
			}
			if (RevisionControlObject.mDefaultChangeListDesc != this.mChangeListDesc)
			{
				RevisionControlObject.mDefaultChangeListDesc = this.mChangeListDesc;
				RevisionControlObject.mDefaultChangeListId = this.mRevControl.GetChangeListByDescription(RevisionControlObject.mDefaultChangeListDesc);
			}
			if (RevisionControlObject.mDefaultChangeListId == 0)
			{
				RevisionControlObject.mDefaultChangeListId = this.mRevControl.CreateChangeList(RevisionControlObject.mDefaultChangeListDesc);
			}
			this.mRevControl.OpenForAdd(RevisionControlObject.mDefaultChangeListId, this.mSourceFiles);
			this.mStatus = this.mRevControl.GetStatus(this.mSourceFiles[0]);
			if (this.mStatus != RCSFileStatusType.kOpenForAdd)
			{
				Log.gWarn("RevControl", "Failed to Add files {0}", new object[]
				{
					RevisionControlObject.GetStringArrayAsString(this.mSourceFiles)
				});
				throw new RCSException(this.mSourceFiles, Resource.Error_Add, RevisionControlObject.mDefaultChangeListDesc);
			}
			this.mbEditable = true;
			if (RevisionControlObject.sStatusChangedEvent != null)
			{
				RevisionControlObject.sStatusChangedEvent(this, new EventArgs());
			}
			return this.mbEditable;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000B974 File Offset: 0x0000A974
		private bool OpenFilesForRemove()
		{
			if (!this.mbRCSInited || !this.mbEnableRCS)
			{
				return false;
			}
			if (!this.ShowEditForm(RevisionControlObject.Operation.kDelete))
			{
				return false;
			}
			Log.gInfo("RevControl", "Opening files for remove {0} in CL {1}", new object[]
			{
				new object[]
				{
					RevisionControlObject.GetStringArrayAsString(this.mSourceFiles)
				},
				this.mChangeListDesc
			});
			if (string.IsNullOrEmpty(this.mChangeListDesc))
			{
				this.mChangeListDesc = this.mRevControl.DefaultChangeListDescription;
			}
			int num = this.mRevControl.GetChangeListByDescription(this.mChangeListDesc);
			if (num == 0)
			{
				num = this.mRevControl.CreateChangeList(this.mChangeListDesc);
			}
			if (!this.mRevControl.AreFilesInSync(this.mSourceFiles) && !this.OnFilesOutofSync())
			{
				return false;
			}
			this.mRevControl.OpenForDelete(num, this.mSourceFiles);
			this.mStatus = this.mRevControl.GetStatus(this.mSourceFiles[0]);
			if (this.mStatus != RCSFileStatusType.kOpenForDelete)
			{
				Log.gWarn("RevControl", "Failed to Delete files {0}", new object[]
				{
					RevisionControlObject.GetStringArrayAsString(this.mSourceFiles)
				});
				throw new RCSException(this.mSourceFiles, Resource.Error_Delete, this.mChangeListDesc);
			}
			this.mbEditable = false;
			return true;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000BAB8 File Offset: 0x0000AAB8
		private bool OpenFilesForRename(string[] newFileNames)
		{
			if (!this.mbRCSInited || !this.mbEnableRCS)
			{
				return false;
			}
			if (!this.ShowEditForm(RevisionControlObject.Operation.kRename))
			{
				return false;
			}
			Log.gInfo("RevControl", "Opening files for rename {0} in CL {1}", new object[]
			{
				new object[]
				{
					RevisionControlObject.GetStringArrayAsString(this.mSourceFiles)
				},
				this.mChangeListDesc
			});
			if (string.IsNullOrEmpty(this.mChangeListDesc))
			{
				this.mChangeListDesc = this.mRevControl.DefaultChangeListDescription;
			}
			int num = this.mRevControl.GetChangeListByDescription(this.mChangeListDesc);
			if (num == 0)
			{
				num = this.mRevControl.CreateChangeList(this.mChangeListDesc);
			}
			for (int i = 0; i < this.mSourceFiles.Length; i++)
			{
				RCSFileStatusType status = this.mRevControl.GetStatus(this.mSourceFiles[i]);
				if (status == RCSFileStatusType.kOpenForAdd || status == RCSFileStatusType.kOpenForBranch || status == RCSFileStatusType.kOpenForRename)
				{
					Log.gWarn("RevControl", "Failed to Rename files {0}. Already open", new object[]
					{
						RevisionControlObject.GetStringArrayAsString(this.mSourceFiles)
					});
					throw new RCSException(this.mSourceFiles, Resource.kError_RenameOpenFile, this.mChangeListDesc);
				}
			}
			if (!this.mRevControl.AreFilesInSync(this.mSourceFiles) && !this.OnFilesOutofSync())
			{
				return false;
			}
			this.mRevControl.OpenForRename(num, this.mSourceFiles, newFileNames, true);
			Array.Copy(newFileNames, this.mSourceFiles, this.mSourceFiles.Length);
			this.mStatus = this.mRevControl.GetStatus(this.mSourceFiles[0]);
			if (this.mStatus == RCSFileStatusType.kOpenForBranch || this.mStatus == RCSFileStatusType.kOpenForAdd || this.mStatus == RCSFileStatusType.kOpenForRename)
			{
				this.mbEditable = true;
				if (RevisionControlObject.sStatusChangedEvent != null)
				{
					RevisionControlObject.sStatusChangedEvent(this, new EventArgs());
				}
				return true;
			}
			Log.gWarn("RevControl", "Failed to Rename files {0}.", new object[]
			{
				RevisionControlObject.GetStringArrayAsString(this.mSourceFiles)
			});
			throw new RCSException(this.mSourceFiles, Resource.Error_Rename, this.mChangeListDesc);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000BCB4 File Offset: 0x0000ACB4
		private bool OnFilesOutofSync()
		{
			if (!this.mbEnableRCS || !this.mbRCSInited)
			{
				return false;
			}
			Log.gInfo("RevControl", "Syncing files to head {0}", new object[]
			{
				RevisionControlObject.GetStringArrayAsString(this.mSourceFiles)
			});
			bool flag = true;
			if (RevisionControlObject.sOutofSyncEvent != null)
			{
				flag = RevisionControlObject.sOutofSyncEvent(this, new EventArgs());
			}
			if (flag)
			{
				this.ReleaseFilesLock();
				flag &= this.SyncToHead();
				this.RegainFilesLock();
				flag &= this.Reload();
				if (flag && RevisionControlObject.sReloadedEvent != null)
				{
					RevisionControlObject.sReloadedEvent(this, new EventArgs());
				}
			}
			return flag;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000BD50 File Offset: 0x0000AD50
		protected static string GetStringArrayAsString(string[] strings)
		{
			if (strings == null || strings.Length < 1)
			{
				return string.Empty;
			}
			int num = strings.Length - 1;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < num; i++)
			{
				stringBuilder.Append(strings[i]);
				stringBuilder.Append(",");
			}
			stringBuilder.Append(strings[num]);
			return stringBuilder.ToString();
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000BDAC File Offset: 0x0000ADAC
		private bool ShowEditForm(RevisionControlObject.Operation operationType)
		{
			if (!RevisionControlObject.sbDisableEditForm)
			{
				EditAddForm editAddForm = new EditAddForm();
				editAddForm.ShowDisableButton(true);
				switch (operationType)
				{
				case RevisionControlObject.Operation.kAdd:
					editAddForm.TextLabel.Text = Resource.kRCS_OpenForAddQuery;
					break;
				case RevisionControlObject.Operation.kEdit:
					editAddForm.TextLabel.Text = Resource.kRCS_OpenForEditQuery;
					break;
				case RevisionControlObject.Operation.kDelete:
					editAddForm.TextLabel.Text = Resource.kRCS_OpenForDeleteQuery;
					break;
				case RevisionControlObject.Operation.kRename:
					editAddForm.TextLabel.Text = Resource.kRCS_OpenForRenameQuery;
					break;
				}
				editAddForm.FileList = this.mSourceFiles;
				DialogResult dialogResult = editAddForm.ShowDialog();
				DialogResult dialogResult2 = dialogResult;
				if (dialogResult2 == DialogResult.Cancel)
				{
					return false;
				}
				if (dialogResult2 == DialogResult.Ignore)
				{
					RevisionControlObject.sbDisableEditForm = true;
				}
			}
			return true;
		}

		// Token: 0x040000F6 RID: 246
		private const string kLogCategory = "RevControl";

		// Token: 0x040000FA RID: 250
		private static bool sbDisableEditForm;

		// Token: 0x040000FB RID: 251
		private RCS mRevControl;

		// Token: 0x040000FC RID: 252
		private bool mbEditable;

		// Token: 0x040000FD RID: 253
		private string[] mSourceFiles;

		// Token: 0x040000FE RID: 254
		private string mChangeListDesc;

		// Token: 0x040000FF RID: 255
		private static string mDefaultChangeListDesc;

		// Token: 0x04000100 RID: 256
		private static int mDefaultChangeListId;

		// Token: 0x04000101 RID: 257
		private bool mbRCSInited;

		// Token: 0x04000102 RID: 258
		private RCSFileStatusType mStatus = RCSFileStatusType.kNotUnderAnyClientSpec;

		// Token: 0x04000103 RID: 259
		private bool mbEnableRCS = true;

		// Token: 0x0200002D RID: 45
		private enum Operation
		{
			// Token: 0x04000105 RID: 261
			kAdd,
			// Token: 0x04000106 RID: 262
			kEdit,
			// Token: 0x04000107 RID: 263
			kDelete,
			// Token: 0x04000108 RID: 264
			kRename
		}
	}
}
