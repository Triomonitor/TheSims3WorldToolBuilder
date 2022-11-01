using System;
using System.IO;
using Sims3.StringTableResources;

namespace ToolUtil
{
	// Token: 0x02000004 RID: 4
	public class StringTableFile : IStringTableWriter
	{
		// Token: 0x0600000F RID: 15 RVA: 0x0000240D File Offset: 0x0000140D
		public StringTableFile(string outputDirectory, string tableId)
		{
			this.mOutputDirectory = outputDirectory;
			this.mTableId = tableId;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002423 File Offset: 0x00001423
		public void WriteStringTableResource(string inputXmlFile)
		{
			StringTableResources.ReadXMLData(inputXmlFile);
			if (!Directory.Exists(this.mOutputDirectory))
			{
				Directory.CreateDirectory(this.mOutputDirectory);
			}
			StringTableResources.WriteStringTableResource(this.mOutputDirectory, this.mTableId);
		}

		// Token: 0x04000008 RID: 8
		private string mOutputDirectory;

		// Token: 0x04000009 RID: 9
		private string mTableId;
	}
}
