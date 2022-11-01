using System;
using System.Data;
using System.Globalization;
using System.Xml.Serialization;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000003 RID: 3
	[XmlInclude(typeof(ObjectInstance))]
	[Serializable]
	public class ItemKey : IEquatable<ItemKey>
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00001058
		public string Name
		{
			get
			{
				return this.mName;
			}
			set
			{
				this.mName = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00001061
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00001069
		public long GroupId
		{
			get
			{
				return this.mGroupID;
			}
			set
			{
				this.mGroupID = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00001072
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000107A
		public ItemType KeyType
		{
			get
			{
				return this.mItemType;
			}
			set
			{
				this.mItemType = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002083 File Offset: 0x00001083
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000208B File Offset: 0x0000108B
		public long ResourceType
		{
			get
			{
				return this.mResourceTypeField;
			}
			set
			{
				this.mResourceTypeField = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002094 File Offset: 0x00001094
		// (set) Token: 0x0600000A RID: 10 RVA: 0x0000209C File Offset: 0x0000109C
		public bool Deleted
		{
			get
			{
				return this.mDeleted;
			}
			set
			{
				this.mDeleted = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020A5 File Offset: 0x000010A5
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020AD File Offset: 0x000010AD
		public long Id
		{
			get
			{
				return this.mId;
			}
			set
			{
				this.mId = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020B6 File Offset: 0x000010B6
		public bool Valid
		{
			get
			{
				return this.mId != -1L;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000020C5 File Offset: 0x000010C5
		public ItemKey(ItemType type)
		{
			this.mItemType = type;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000020F6 File Offset: 0x000010F6
		public ItemKey(ItemKey source) : this(source.Name, source.GroupId, source.mResourceTypeField, source.KeyType)
		{
			this.mId = source.Id;
			this.mDeleted = source.Deleted;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002130 File Offset: 0x00001130
		public ItemKey(string name, long groupId, long resourceType, ItemType type)
		{
			this.mName = name;
			this.mGroupID = groupId;
			this.mResourceTypeField = resourceType;
			this.mItemType = type;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002182 File Offset: 0x00001182
		public ItemKey()
		{
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000021AC File Offset: 0x000011AC
		public bool Equals(ItemKey other)
		{
			return other != null && (this.mItemType == other.KeyType && this.mName.ToLower() == other.Name.ToLower() && this.mGroupID == other.GroupId) && this.mResourceTypeField == other.mResourceTypeField;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002207 File Offset: 0x00001207
		public override int GetHashCode()
		{
			return (int)(this.mItemType + (int)this.mGroupID + this.mName.GetHashCode() + this.mResourceTypeField.GetHashCode());
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000222F File Offset: 0x0000122F
		public override bool Equals(object other)
		{
			if (other is ItemKey)
			{
				return this.Equals(other as ItemKey);
			}
			return base.Equals(other);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002250 File Offset: 0x00001250
		public override string ToString()
		{
			return string.Format("{0},{1}, 0x{2:x}, {3}", new object[]
			{
				this.mName,
				this.mGroupID,
				this.ResourceType,
				this.mId
			});
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000022A4 File Offset: 0x000012A4
		public static ItemKey Parse(string src)
		{
			ItemKey itemKey = new ItemKey();
			string[] array = src.Split(new char[]
			{
				','
			});
			if (array.Length == 3)
			{
				ItemKey.ParseVersion1(itemKey, array);
			}
			else
			{
				if (array.Length != 4)
				{
					throw new FormatException("Expected a string in the form '{0},{1}, 0x{2:x}', but got '" + src + "'");
				}
				ItemKey.ParseVersion1(itemKey, array);
				itemKey.Id = long.Parse(array[3].Trim());
			}
			return itemKey;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002314 File Offset: 0x00001314
		private static void ParseVersion1(ItemKey mykey, string[] items)
		{
			mykey.Name = items[0].Trim();
			mykey.GroupId = long.Parse(items[1].Trim());
			mykey.ResourceType = long.Parse(items[2].Trim().Replace("0x", ""), NumberStyles.HexNumber);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000236C File Offset: 0x0000136C
		public static ItemKey Parse(IDataReader sqlrdr)
		{
			return new ItemKey
			{
				Name = (string)sqlrdr["Name"],
				GroupId = (long)sqlrdr["GroupId"],
				ResourceType = (long)sqlrdr["ResourceType"],
				Deleted = (sqlrdr["Deleted"] != DBNull.Value && (bool)sqlrdr["Deleted"]),
				mId = (long)sqlrdr["id"]
			};
		}

		// Token: 0x04000007 RID: 7
		public const long kInvalidId = -1L;

		// Token: 0x04000008 RID: 8
		private string mName = "";

		// Token: 0x04000009 RID: 9
		private long mGroupID;

		// Token: 0x0400000A RID: 10
		private ItemType mItemType = ItemType.UNKNOWN;

		// Token: 0x0400000B RID: 11
		private long mResourceTypeField = -1L;

		// Token: 0x0400000C RID: 12
		private bool mDeleted;

		// Token: 0x0400000D RID: 13
		private long mId = -1L;
	}
}
