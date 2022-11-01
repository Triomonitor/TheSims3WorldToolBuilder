using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace Sims3.LDAL.HALWebService
{
	// Token: 0x02000003 RID: 3
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Xml", "2.0.50727.3082")]
	[XmlType(Namespace = "http://tempuri.org/")]
	[XmlRoot(Namespace = "http://tempuri.org/", IsNullable = false)]
	[Serializable]
	public class Authentication : SoapHeader
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000BE RID: 190 RVA: 0x0000560D File Offset: 0x0000460D
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00005615 File Offset: 0x00004615
		public string User
		{
			get
			{
				return this.userField;
			}
			set
			{
				this.userField = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x0000561E File Offset: 0x0000461E
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00005626 File Offset: 0x00004626
		public string Password
		{
			get
			{
				return this.passwordField;
			}
			set
			{
				this.passwordField = value;
			}
		}

		// Token: 0x0400003F RID: 63
		private string userField;

		// Token: 0x04000040 RID: 64
		private string passwordField;
	}
}
