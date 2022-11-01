using System;
using System.ComponentModel;

namespace Sims3.DbDataLayer
{
	// Token: 0x02000011 RID: 17
	public class DbDataLayerTypeDescriptorContext : ITypeDescriptorContext, IServiceProvider
	{
		// Token: 0x0600010E RID: 270 RVA: 0x00005B8C File Offset: 0x00004B8C
		public DbDataLayerTypeDescriptorContext(object inst)
		{
			this.mInstance = inst;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00005B9B File Offset: 0x00004B9B
		public IContainer Container
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00005B9E File Offset: 0x00004B9E
		public object Instance
		{
			get
			{
				return this.mInstance;
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00005BA6 File Offset: 0x00004BA6
		public void OnComponentChanged()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005BB2 File Offset: 0x00004BB2
		public bool OnComponentChanging()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00005BBE File Offset: 0x00004BBE
		public PropertyDescriptor PropertyDescriptor
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00005BC1 File Offset: 0x00004BC1
		public object GetService(Type serviceType)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x0400003C RID: 60
		private object mInstance;
	}
}
