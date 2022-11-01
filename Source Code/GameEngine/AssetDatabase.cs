using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Sims3;
using Sims3.CSHost;
using Sims3.DbDataLayer;

namespace SACS
{
	// Token: 0x02000004 RID: 4
	public class AssetDatabase
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000026C2 File Offset: 0x000016C2
		// (set) Token: 0x06000014 RID: 20 RVA: 0x000026D6 File Offset: 0x000016D6
		public static Log Log
		{
			get
			{
				if (AssetDatabase.sLog == null)
				{
					return Log.Instance;
				}
				return AssetDatabase.sLog;
			}
			set
			{
				AssetDatabase.sLog = value;
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000026DE File Offset: 0x000016DE
		private AssetDatabase()
		{
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000026E6 File Offset: 0x000016E6
		public static void PreInitApp()
		{
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000026E8 File Offset: 0x000016E8
		public static void PostInitApp(bool requireSimTrackMaskBoneMapping, bool validateSimTrackMaskBoneMapping)
		{
			SacsTrackMask.CheckRigMappingFile = validateSimTrackMaskBoneMapping;
			AssetDatabase.gTrackMaskManager = new TrackMaskManager();
			if (!AssetDatabase.GlobalTrackMaskManager.InitSimAndPetTrackMaskBoneMappingFile() && requireSimTrackMaskBoneMapping)
			{
				throw new ApplicationException(string.Concat(new string[]
				{
					"Cannot continue without access to the track mask bone mappings files (",
					TrackMaskManager.SimTrackMaskBoneMappingsFile,
					") and (",
					TrackMaskManager.PetTrackMaskBoneMappingsFile,
					").  Make sure you have X: mapped and JazzData from your asset tree synced in Perforce."
				}));
			}
			AssetDatabase.GlobalTrackMaskManager.LoadFromXml();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000275B File Offset: 0x0000175B
		public static void PreShutdown()
		{
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000275D File Offset: 0x0000175D
		public static void PostShutdown()
		{
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000275F File Offset: 0x0000175F
		public static void ReloadTempDataResourceNames()
		{
			AssetDatabase.AddDirectoryContentsToKeyNameMap(App.AssetsLocalWorkPath, "LocalWork", true);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002771 File Offset: 0x00001771
		public static void AddDirectoryContentsToKeyNameMap(string directory, bool recurse)
		{
			AssetDatabase.AddDirectoryContentsToKeyNameMap(directory, "Unspecified Group", recurse);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000277F File Offset: 0x0000177F
		public static void AddDirectoryContentsToKeyNameMap(string directory, string groupName, bool recurse)
		{
			AssetDatabase.c_directories[directory] = recurse;
			AssetDatabase.c_directoryGroups[directory] = groupName;
			AssetDatabase.AddDirectoryContentsToKeyNameMap0(directory, groupName, recurse);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000027A8 File Offset: 0x000017A8
		private static void AddDirectoryContentsToKeyNameMap0(string directory, string groupName, bool recurse)
		{
			if (!Directory.Exists(directory))
			{
				return;
			}
			string[] files = Directory.GetFiles(directory);
			foreach (string path in files)
			{
				string text = Path.GetFileNameWithoutExtension(path);
				string extension = Path.GetExtension(path);
				if (extension == ".clip")
				{
					ulong i2 = 0UL;
					string text2 = text;
					uint g = 0U;
					KeyNameMap.ParseInstanceName(text, ref i2, ref text2, ref g);
					ResourceKey resourceKey = new ResourceKey(1797309683U, g, i2);
					int num = text.LastIndexOf("_0x");
					if (num > 0)
					{
						text = text.Substring(0, num);
					}
					AssetDatabase.c_keyNames[resourceKey] = text;
					AssetDatabase.c_keyGroups[resourceKey] = groupName;
				}
			}
			if (recurse)
			{
				foreach (string directory2 in Directory.GetDirectories(directory))
				{
					AssetDatabase.AddDirectoryContentsToKeyNameMap0(directory2, groupName, true);
				}
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002898 File Offset: 0x00001898
		public static void RebuildKeyNameMap()
		{
			AssetDatabase.c_keyNames.Clear();
			foreach (object obj in AssetDatabase.c_directories)
			{
				string text = (string)obj;
				AssetDatabase.AddDirectoryContentsToKeyNameMap(text, (string)AssetDatabase.c_directoryGroups[text], (bool)AssetDatabase.c_directories[text]);
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000291C File Offset: 0x0000191C
		public static void AddPackage(string filename)
		{
			if (!File.Exists(filename))
			{
				throw new FileNotFoundException("Can't find package: " + filename, filename);
			}
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
			uint num = ResourceMgr.OpenPackage(filename, fileNameWithoutExtension, FileAccess.Read);
			if (num == 4294967295U)
			{
				throw new ApplicationException("Error opening package:  " + filename);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000296A File Offset: 0x0000196A
		public static bool AssetExists(Asset asset)
		{
			return ResourceMgr.RecordExists(asset.Key);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002977 File Offset: 0x00001977
		public static string GetAssetName(Asset asset)
		{
			return AssetDatabase.GetAssetName(asset.Key);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002984 File Offset: 0x00001984
		public static string GetAssetGroup(Asset asset)
		{
			return AssetDatabase.GetAssetGroup(asset.Key);
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002991 File Offset: 0x00001991
		public static string UnknownName
		{
			get
			{
				return "[name unknown]";
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002998 File Offset: 0x00001998
		public static string GetAssetName(ResourceKey key)
		{
			string text = null;
			if (AssetDatabase.c_keyNames.ContainsKey(key))
			{
				text = (AssetDatabase.c_keyNames[key] as string);
			}
			else
			{
				text = ResourceMgr.GetFilenameForKey(key);
			}
			if (text == null)
			{
				return key.ToString();
			}
			uint num = 0U;
			KeyNameMap.ParseInstanceName(text, ref key.mInstance, ref text, ref num);
			AssetDatabase.c_keyNames[key] = text;
			return text;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002A10 File Offset: 0x00001A10
		public static string GetAssetGroup(ResourceKey key)
		{
			return AssetDatabase.c_keyGroups[key] as string;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002A34 File Offset: 0x00001A34
		public static bool Pipeline
		{
			get
			{
				if (!AssetDatabase.sIsInPipelineTriedAssets)
				{
					AssetDatabase.sIsInPipelineTriedAssets = true;
					AssetDatabase.sIsInPipeline = (AssetDatabase.GetAllRigs().Count == 0);
					if (AssetDatabase.sIsInPipeline)
					{
						AssetDatabase.Log.Debug("AssetDatabase", "Running in pipeline mode.", new object[0]);
					}
				}
				return AssetDatabase.sIsInPipeline;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002A86 File Offset: 0x00001A86
		public static bool AssetsAreAvailable
		{
			get
			{
				return !AssetDatabase.Pipeline;
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002A90 File Offset: 0x00001A90
		public static ArrayList GetAllRigs()
		{
			ArrayList arrayList = new ArrayList();
			ResourceKey[] keyList = ResourceMgr.GetKeyList(0U, 2393838558U, 0U);
			foreach (ResourceKey key in keyList)
			{
				arrayList.Add(new Rig(key));
			}
			return arrayList;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002AE0 File Offset: 0x00001AE0
		public static ArrayList GetAllModels()
		{
			ArrayList arrayList = new ArrayList();
			ResourceKey[] keyList = ResourceMgr.GetKeyList(0U, 23466547U, 0U);
			foreach (ResourceKey key in keyList)
			{
				arrayList.Add(new Model(key));
			}
			return arrayList;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002B30 File Offset: 0x00001B30
		public static ArrayList GetAllMotions()
		{
			ArrayList arrayList = new ArrayList();
			ResourceKey[] keyList = ResourceMgr.GetKeyList(0U, 1797309683U, 0U);
			foreach (ResourceKey key in keyList)
			{
				Motion value = new Motion(key);
				arrayList.Add(value);
			}
			return arrayList;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002B88 File Offset: 0x00001B88
		public static ResourceKey CreateResourceKey(ItemKey instanceKey)
		{
			if (instanceKey == null || !DataStore.Instance.Initialized)
			{
				return default(ResourceKey);
			}
			if (instanceKey.KeyType != ItemType.INSTANCE)
			{
				throw new ArgumentException("instanceKey isn't an instance key.  It's type is " + instanceKey.KeyType);
			}
			ItemKey instancePrototypeKey = DataStore.Instance.GetInstancePrototypeKey(instanceKey);
			uint type = (uint)DataStore.Instance.GetClassResourceIdByPrototype(instancePrototypeKey);
			return ResourceMgr.CreateKeyFromName(instanceKey.Name, type, (uint)instanceKey.GroupId);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002C00 File Offset: 0x00001C00
		public static GameObject CreateGameObject(ItemKey instanceKey)
		{
			if (instanceKey == null)
			{
				return null;
			}
			if (instanceKey.ResourceType == 329217425L)
			{
				ResourceKey metadataKey = new ResourceKey((uint)instanceKey.ResourceType, (uint)instanceKey.GroupId, (ulong)instanceKey.Id);
				return GameObjectFactory.CreateFromMetadata(metadataKey);
			}
			return AssetDatabase.CreateGameObject(AssetDatabase.CreateResourceKey(instanceKey));
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002C50 File Offset: 0x00001C50
		public static GameObject CreateGameObject(ResourceKey instanceResourceKey)
		{
			if (instanceResourceKey.IsZero)
			{
				return null;
			}
			ulong id = SimulationObject.CreateGameObject(instanceResourceKey);
			return new GameObject(id);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002C78 File Offset: 0x00001C78
		public static string[] GetListOfSourceFiles(Motion[] clips)
		{
			Hashtable hashtable = AssetDatabase.BuildSourceFileToClipMap(clips);
			string[] array = new string[hashtable.Keys.Count];
			hashtable.Keys.CopyTo(array, 0);
			return array;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002CAC File Offset: 0x00001CAC
		public static Hashtable BuildSourceFileToClipMap(Motion[] clips)
		{
			Hashtable hashtable = new Hashtable();
			foreach (Motion motion in clips)
			{
				string sourceFile = motion.SourceFile;
				if (hashtable[sourceFile] == null)
				{
					hashtable[sourceFile] = new ArrayList();
				}
				(hashtable[sourceFile] as ArrayList).Add(motion);
			}
			return hashtable;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002D08 File Offset: 0x00001D08
		public static SacsTrackMask GetTrackMask(ulong instanceId)
		{
			foreach (SacsTrackMask sacsTrackMask in AssetDatabase.TrackMasks)
			{
				if (sacsTrackMask.ExternalKeyInstance == instanceId)
				{
					return sacsTrackMask;
				}
			}
			return null;
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002D60 File Offset: 0x00001D60
		public static IEnumerable<SacsTrackMask> TrackMasks
		{
			get
			{
				return AssetDatabase.GlobalTrackMaskManager.TrackMasks;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002D6C File Offset: 0x00001D6C
		public static TrackMaskManager GlobalTrackMaskManager
		{
			get
			{
				return AssetDatabase.gTrackMaskManager;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002D74 File Offset: 0x00001D74
		public static void CopyUsingResourceKeyInstanceForName(string sourceDirectory, string destinationDirectory, string extension, bool recurse)
		{
			if (!Directory.Exists(sourceDirectory))
			{
				return;
			}
			if (!Directory.Exists(destinationDirectory))
			{
				return;
			}
			if (recurse)
			{
				foreach (string sourceDirectory2 in Directory.GetDirectories(sourceDirectory))
				{
					AssetDatabase.CopyUsingResourceKeyInstanceForName(sourceDirectory2, destinationDirectory, extension, true);
				}
			}
			string[] files = Directory.GetFiles(sourceDirectory);
			foreach (string text in files)
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
				string extension2 = Path.GetExtension(text);
				if (extension == null || !(extension2 != extension))
				{
					ResourceKey resourceKey = new ResourceKey(0U, 0U, 0UL);
					ResourceMgr.CreateKeyFromName(ref resourceKey, fileNameWithoutExtension, 0U, 0U);
					ulong mInstance = resourceKey.mInstance;
					string text2 = fileNameWithoutExtension.ToLower();
					if (text2.Length > 17)
					{
						text2 = text2.Replace("loop", "L");
					}
					if (text2.Length > 17)
					{
						text2 = text2.Replace("join", "J");
					}
					if (text2.Length > 17)
					{
						text2 = text2.Replace("reject", "N");
					}
					if (text2.Length > 17)
					{
						text2 = text2.Replace("accept", "Y");
					}
					if (text2.Length > 17)
					{
						text2 = text2.Replace("start", "G");
					}
					if (text2.Length > 17)
					{
						text2 = text2.Replace("stop", "X");
					}
					Regex regex;
					if (text2.Length > 17)
					{
						regex = new Regex("^.(2.)?-(soc-)?");
						text2 = regex.Replace(text2, "");
					}
					regex = new Regex("(?=.)[aeiou](?=.)");
					while (text2.Length > 17)
					{
						MatchCollection matchCollection = regex.Matches(text2);
						if (matchCollection.Count <= 0)
						{
							break;
						}
						text2 = regex.Replace(text2, "", 1, matchCollection[matchCollection.Count - 1].Index);
					}
					int num = 2;
					int num2 = text2.Length - num;
					while (num2 > 0 && text2.Length > 17)
					{
						if (text2[num2] == '-')
						{
							num2--;
						}
						if (num2 > 0)
						{
							text2 = text2.Substring(0, num2) + text2.Substring(num2 + 1);
						}
						num2 -= num;
					}
					if (text2.Length > 17)
					{
						text2 = text2.Substring(0, 17);
					}
					text2 = text2.Replace(' ', '_').PadRight(17, '_');
					string path = string.Format("{0}_0x{1:x16}{2}", text2, mInstance, extension2);
					string text3 = Path.Combine(destinationDirectory, path);
					if (File.Exists(text3) && File.GetLastWriteTime(text3) < File.GetLastWriteTime(text))
					{
						try
						{
							AssetDatabase.MakeWriteable(text3);
							File.Delete(text3);
						}
						catch (Exception)
						{
						}
					}
					if (!File.Exists(text3))
					{
						try
						{
							File.Copy(text, text3, true);
							AssetDatabase.MakeWriteable(text3);
						}
						catch (Exception)
						{
						}
					}
				}
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003078 File Offset: 0x00002078
		private static void MakeWriteable(string file)
		{
			FileAttributes fileAttributes = File.GetAttributes(file);
			fileAttributes &= ~FileAttributes.ReadOnly;
			File.SetAttributes(file, fileAttributes);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003098 File Offset: 0x00002098
		public static string GetAssetGroup(Asset m, string resultForUnknownGroup)
		{
			string assetGroup = AssetDatabase.GetAssetGroup(m);
			if (assetGroup == null)
			{
				return resultForUnknownGroup;
			}
			return assetGroup;
		}

		// Token: 0x0400000A RID: 10
		private const string kLogCategory = "AssetDatabase";

		// Token: 0x0400000B RID: 11
		private static Log sLog = null;

		// Token: 0x0400000C RID: 12
		private static Hashtable c_keyNames = new Hashtable();

		// Token: 0x0400000D RID: 13
		private static Hashtable c_keyGroups = new Hashtable();

		// Token: 0x0400000E RID: 14
		private static Hashtable c_directories = new Hashtable();

		// Token: 0x0400000F RID: 15
		private static Hashtable c_directoryGroups = new Hashtable();

		// Token: 0x04000010 RID: 16
		private static bool sIsInPipeline = false;

		// Token: 0x04000011 RID: 17
		private static bool sIsInPipelineTriedAssets = false;

		// Token: 0x04000012 RID: 18
		private static TrackMaskManager gTrackMaskManager;
	}
}
