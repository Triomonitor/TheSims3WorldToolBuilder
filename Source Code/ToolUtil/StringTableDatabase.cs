using System;
using System.IO;
using System.Text;
using Sims3.CSHost;
using Sims3.StringTableResources;

namespace ToolUtil
{
	// Token: 0x02000005 RID: 5
	public class StringTableDatabase : IStringTableWriter
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00002455 File Offset: 0x00001455
		public StringTableDatabase(uint outputDB, string tableId)
		{
			this.mOutputDB = outputDB;
			this.mTableId = tableId;
			this.mGroupId = 0U;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002472 File Offset: 0x00001472
		public StringTableDatabase(uint outputDB, string tableId, uint groupId)
		{
			this.mOutputDB = outputDB;
			this.mTableId = tableId;
			this.mGroupId = groupId;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002490 File Offset: 0x00001490
		public void WriteStringTableResource(string inputXmlFile)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.Unicode))
				{
					StringTableResources.ReadXMLData(inputXmlFile);
					StringTableResources.WriteStringTableResource(binaryWriter);
					ulong i = StringTableResources.GenerateInstanceId(this.mTableId);
					ResourceKey key = new ResourceKey(570775514U, this.mGroupId, i);
					if (!ResourceMgr.SaveRecord(this.mOutputDB, key, memoryStream.GetBuffer(), (int)memoryStream.Length))
					{
						throw new ApplicationException(string.Format("Unable to save string table resource for \"{0}\"", this.mTableId));
					}
				}
			}
		}

		// Token: 0x0400000A RID: 10
		private uint mOutputDB;

		// Token: 0x0400000B RID: 11
		private string mTableId;

		// Token: 0x0400000C RID: 12
		private uint mGroupId;
	}
}
