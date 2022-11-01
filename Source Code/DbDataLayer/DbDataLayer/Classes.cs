using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sims3.DbDataLayer
{
	// Token: 0x0200008A RID: 138
	public class Classes
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0001024B File Offset: 0x0000F24B
		// (set) Token: 0x060004C1 RID: 1217 RVA: 0x00010253 File Offset: 0x0000F253
		[XmlElement(ElementName = "Class", Type = typeof(ClassInfo))]
		public List<ClassInfo> ClassInfoList
		{
			get
			{
				return this.mClasses;
			}
			set
			{
				this.mClasses = value;
			}
		}

		// Token: 0x04000155 RID: 341
		private List<ClassInfo> mClasses = new List<ClassInfo>();
	}
}
