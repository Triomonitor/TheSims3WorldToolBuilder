using System;

namespace ToolUtil.Menu
{
	// Token: 0x0200001C RID: 28
	public interface IMainMenu
	{
		// Token: 0x0600019F RID: 415
		object AddMenuItem(string menuName, string itemName, EventHandler clickHandler);

		// Token: 0x060001A0 RID: 416
		object AddMenuItem(string menuName, string itemName, EventHandler clickHandler, EventHandler updateHandler, bool check, bool radioCheck);

		// Token: 0x060001A1 RID: 417
		object AddMenuItem(string menuName, MenuItem item);

		// Token: 0x060001A2 RID: 418
		object AddSeperator(string menuName);
	}
}
