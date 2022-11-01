using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x0200001F RID: 31
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("System.Xml", "2.0.50727.832")]
	[XmlType(Namespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta")]
	[Serializable]
	public class DBItemInfo
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x0000B149 File Offset: 0x0000A149
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x0000B151 File Offset: 0x0000A151
		public ItemKey thisItem
		{
			get
			{
				return this.thisItemField;
			}
			set
			{
				this.thisItemField = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060002DA RID: 730 RVA: 0x0000B15A File Offset: 0x0000A15A
		// (set) Token: 0x060002DB RID: 731 RVA: 0x0000B162 File Offset: 0x0000A162
		public DBItemInfo[] childrenItems
		{
			get
			{
				return this.childrenItemsField;
			}
			set
			{
				this.childrenItemsField = value;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060002DC RID: 732 RVA: 0x0000B16B File Offset: 0x0000A16B
		// (set) Token: 0x060002DD RID: 733 RVA: 0x0000B173 File Offset: 0x0000A173
		public string checkoutUser
		{
			get
			{
				return this.checkoutUserField;
			}
			set
			{
				this.checkoutUserField = value;
			}
		}

		// Token: 0x040000C9 RID: 201
		private ItemKey thisItemField;

		// Token: 0x040000CA RID: 202
		private DBItemInfo[] childrenItemsField;

		// Token: 0x040000CB RID: 203
		private string checkoutUserField;
	}
}
