using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Sims3.RevisionControl;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000010 RID: 16
	internal class IdGenerator
	{
		// Token: 0x06000105 RID: 261 RVA: 0x000058CF File Offset: 0x000048CF
		private IdGenerator(string idCounterFile)
		{
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000058D7 File Offset: 0x000048D7
		public static void SetRCSProvider(RCS rcsProvider)
		{
			if (rcsProvider == null)
			{
				throw new Exception("rcsProvider is null");
			}
			IdGenerator.mRCSProvider = rcsProvider;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000058ED File Offset: 0x000048ED
		public static void SetIdCounterFile(string idCounterFile)
		{
			if (IdGenerator.mRCSProvider != null && IdGenerator.mRCSProvider.Connected)
			{
				IdGenerator.mRCSProvider.SyncToHead(idCounterFile);
			}
			if (!File.Exists(idCounterFile))
			{
				throw new FileNotFoundException(string.Format("Cannot find file '{0}'", idCounterFile));
			}
			IdGenerator.mIdCounterFile = idCounterFile;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000592D File Offset: 0x0000492D
		public static long GenerateInstanceId()
		{
			return IdGenerator.GenerateId(false);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00005935 File Offset: 0x00004935
		public static long GeneratePrototypeId()
		{
			return IdGenerator.GenerateId(true);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00005940 File Offset: 0x00004940
		private static long GenerateId(bool prototype)
		{
			int num = IdGenerator.kNumRetries;
			int changeListId;
			if (!prototype)
			{
				changeListId = IdGenerator.mRCSProvider.CreateChangeList(IdGenerator.kInstanceIdDescription);
			}
			else
			{
				changeListId = IdGenerator.mRCSProvider.CreateChangeList(IdGenerator.kPrototypeIdDescription);
			}
			while (num != 0)
			{
				IdGenerator.mRCSProvider.SyncToHead(IdGenerator.mIdCounterFile);
				try
				{
					IdGenerator.mRCSProvider.OpenForEdit(changeListId, IdGenerator.mIdCounterFile);
				}
				catch (Exception)
				{
					Thread.Sleep(3000);
					num--;
					continue;
				}
				IdCounter idCounter = IdGenerator.DeserializeIdCounterFile();
				if (!prototype)
				{
					idCounter.InstanceIdCount += 1L;
				}
				else
				{
					idCounter.PrototypeIdCount += 1L;
				}
				IdGenerator.SerializeIdCounterFile(idCounter);
				IdGenerator.mRCSProvider.SubmitChangeList(changeListId);
				if (!prototype)
				{
					return idCounter.InstanceIdCount;
				}
				return idCounter.PrototypeIdCount;
			}
			IdGenerator.mRCSProvider.DeleteEmptyChangeList(changeListId);
			return -1L;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00005A20 File Offset: 0x00004A20
		private static IdCounter DeserializeIdCounterFile()
		{
			IdCounter result;
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(IdCounter));
				XmlTextReader xmlTextReader = new XmlTextReader(IdGenerator.mIdCounterFile);
				IdCounter idCounter = xmlSerializer.Deserialize(xmlTextReader) as IdCounter;
				xmlTextReader.Close();
				result = idCounter;
			}
			catch (Exception)
			{
				throw new Exception(string.Format("Unable to deserialize file '{0}'", IdGenerator.mIdCounterFile));
			}
			return result;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00005A8C File Offset: 0x00004A8C
		private static void SerializeIdCounterFile(IdCounter idCounter)
		{
			try
			{
				FileStream fileStream = File.Open(IdGenerator.mIdCounterFile, FileMode.Truncate);
				if (fileStream == null)
				{
					throw new Exception(string.Format("Unable to serialize file '{0}'. Stream is null.", IdGenerator.mIdCounterFile));
				}
				XmlTextWriter xmlTextWriter = new XmlTextWriter(fileStream, Encoding.UTF8);
				xmlTextWriter.Formatting = Formatting.Indented;
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(IdCounter));
				XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
				xmlSerializerNamespaces.Add("", "");
				xmlSerializer.Serialize(xmlTextWriter, idCounter, xmlSerializerNamespaces);
				try
				{
					xmlTextWriter.Flush();
					fileStream.Close();
				}
				catch (InvalidOperationException)
				{
					throw new Exception(string.Format("Unable to serialize file '{0}'", IdGenerator.mIdCounterFile));
				}
			}
			catch (Exception)
			{
				throw new Exception(string.Format("Unable to serialize file '{0}'", IdGenerator.mIdCounterFile));
			}
		}

		// Token: 0x04000037 RID: 55
		private static string mIdCounterFile = string.Empty;

		// Token: 0x04000038 RID: 56
		private static RCS mRCSProvider = null;

		// Token: 0x04000039 RID: 57
		private static string kInstanceIdDescription = "Creating a new instance id";

		// Token: 0x0400003A RID: 58
		private static string kPrototypeIdDescription = "Creating a new prototype id";

		// Token: 0x0400003B RID: 59
		private static int kNumRetries = 3;
	}
}
