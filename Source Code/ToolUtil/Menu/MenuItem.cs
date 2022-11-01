using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ToolUtil.Menu
{
	// Token: 0x0200001D RID: 29
	public class MenuItem
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00009856 File Offset: 0x00008856
		public string Name
		{
			get
			{
				return this.mName;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x0000985E File Offset: 0x0000885E
		public EventHandler ClickHandler
		{
			get
			{
				return this.mClickHandler;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00009866 File Offset: 0x00008866
		public EventHandler UpdateHandler
		{
			get
			{
				return this.mUpdateHandler;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x0000986E File Offset: 0x0000886E
		public bool Check
		{
			get
			{
				return this.mCheck;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00009876 File Offset: 0x00008876
		public bool RadioCheck
		{
			get
			{
				return this.mRadioCheck;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x0000987E File Offset: 0x0000887E
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x00009886 File Offset: 0x00008886
		public object Tag
		{
			get
			{
				return this.mTag;
			}
			set
			{
				this.mTag = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001AA RID: 426 RVA: 0x0000988F File Offset: 0x0000888F
		// (set) Token: 0x060001AB RID: 427 RVA: 0x00009897 File Offset: 0x00008897
		public Shortcut Shortcut
		{
			get
			{
				return this.mShortcut;
			}
			set
			{
				this.mShortcut = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001AC RID: 428 RVA: 0x000098A0 File Offset: 0x000088A0
		public List<MenuItem> MenuItems
		{
			get
			{
				return this.mMenuItems;
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000098A8 File Offset: 0x000088A8
		public MenuItem(string itemName, EventHandler clickHandler, EventHandler updateHandler, bool check, bool radioCheck)
		{
			this.mName = itemName;
			this.mClickHandler = clickHandler;
			this.mUpdateHandler = updateHandler;
			this.mCheck = check;
			this.mRadioCheck = radioCheck;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000098E0 File Offset: 0x000088E0
		public MenuItem(string itemName, EventHandler clickHandler) : this(itemName, clickHandler, null, false, false)
		{
		}

		// Token: 0x060001AF RID: 431 RVA: 0x000098ED File Offset: 0x000088ED
		public MenuItem(string itemName, EventHandler clickHandler, EventHandler updateHandler, bool check, bool radioCheck, object tag) : this(itemName, clickHandler, updateHandler, check, radioCheck)
		{
			this.mTag = tag;
		}

		// Token: 0x040000CD RID: 205
		private string mName;

		// Token: 0x040000CE RID: 206
		private bool mCheck;

		// Token: 0x040000CF RID: 207
		private bool mRadioCheck;

		// Token: 0x040000D0 RID: 208
		private object mTag;

		// Token: 0x040000D1 RID: 209
		private EventHandler mClickHandler;

		// Token: 0x040000D2 RID: 210
		private EventHandler mUpdateHandler;

		// Token: 0x040000D3 RID: 211
		private List<MenuItem> mMenuItems = new List<MenuItem>();

		// Token: 0x040000D4 RID: 212
		private Shortcut mShortcut;
	}
}
