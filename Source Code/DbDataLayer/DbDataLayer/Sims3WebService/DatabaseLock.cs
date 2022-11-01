using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Sims3.DbDataLayer.Sims3WebService
{
	// Token: 0x02000020 RID: 32
	[DesignerCategory("code")]
	[GeneratedCode("System.Xml", "2.0.50727.832")]
	[XmlType(Namespace = "http://ctrimble-0269.rws.ad.ea.com/Sims3Meta")]
	[DebuggerStepThrough]
	[Serializable]
	public class DatabaseLock
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060002DF RID: 735 RVA: 0x0000B184 File Offset: 0x0000A184
		// (set) Token: 0x060002E0 RID: 736 RVA: 0x0000B18C File Offset: 0x0000A18C
		public long Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x0000B195 File Offset: 0x0000A195
		// (set) Token: 0x060002E2 RID: 738 RVA: 0x0000B19D File Offset: 0x0000A19D
		public DateTime LockedAt
		{
			get
			{
				return this.lockedAtField;
			}
			set
			{
				this.lockedAtField = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x0000B1A6 File Offset: 0x0000A1A6
		// (set) Token: 0x060002E4 RID: 740 RVA: 0x0000B1AE File Offset: 0x0000A1AE
		public DateTime UnlockedAt
		{
			get
			{
				return this.unlockedAtField;
			}
			set
			{
				this.unlockedAtField = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x0000B1B7 File Offset: 0x0000A1B7
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x0000B1BF File Offset: 0x0000A1BF
		public string Username
		{
			get
			{
				return this.usernameField;
			}
			set
			{
				this.usernameField = value;
			}
		}

		// Token: 0x040000CC RID: 204
		private long idField;

		// Token: 0x040000CD RID: 205
		private DateTime lockedAtField;

		// Token: 0x040000CE RID: 206
		private DateTime unlockedAtField;

		// Token: 0x040000CF RID: 207
		private string usernameField;
	}
}
