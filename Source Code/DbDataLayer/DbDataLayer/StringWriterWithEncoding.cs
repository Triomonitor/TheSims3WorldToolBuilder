using System;
using System.IO;
using System.Text;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200001D RID: 29
	public class StringWriterWithEncoding : StringWriter
	{
		// Token: 0x060001C6 RID: 454 RVA: 0x00008548 File Offset: 0x00007548
		public StringWriterWithEncoding(StringBuilder builder, Encoding encoding) : base(builder)
		{
			this.mEncoding = encoding;
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00008558 File Offset: 0x00007558
		public override Encoding Encoding
		{
			get
			{
				return this.mEncoding;
			}
		}

		// Token: 0x0400006F RID: 111
		private Encoding mEncoding;
	}
}
