using System;
using System.Xml;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200007B RID: 123
	public class XmlString
	{
		// Token: 0x06000400 RID: 1024 RVA: 0x0000C13E File Offset: 0x0000B13E
		public XmlString()
		{
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0000C151 File Offset: 0x0000B151
		public XmlString(string xmlString)
		{
			this.mXmlString = xmlString;
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x0000C16C File Offset: 0x0000B16C
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x0000C18C File Offset: 0x0000B18C
		public XmlDocument XmlData
		{
			get
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(this.mXmlString);
				return xmlDocument;
			}
			set
			{
				this.mXmlString = value.InnerXml;
			}
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000C19A File Offset: 0x0000B19A
		public override string ToString()
		{
			if (this.mXmlString != null)
			{
				return this.mXmlString;
			}
			return "Null";
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0000C1B0 File Offset: 0x0000B1B0
		public void SetXmlString(string xmlString)
		{
			this.mXmlString = xmlString;
		}

		// Token: 0x04000102 RID: 258
		private string mXmlString = string.Empty;
	}
}
