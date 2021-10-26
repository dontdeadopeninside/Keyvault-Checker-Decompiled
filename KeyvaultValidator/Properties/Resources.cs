using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace KeyvaultValidator.Properties
{
	// Token: 0x02000005 RID: 5
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class Resources
	{
		// Token: 0x0600002A RID: 42 RVA: 0x000041C2 File Offset: 0x000023C2
		internal Resources()
		{
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000041CC File Offset: 0x000023CC
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("KeyvaultValidator.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002C RID: 44 RVA: 0x0000420B File Offset: 0x0000240B
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00004212 File Offset: 0x00002412
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002E RID: 46 RVA: 0x0000421C File Offset: 0x0000241C
		internal static byte[] apReq1
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("apReq1", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00004244 File Offset: 0x00002444
		internal static byte[] apreq2
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("apreq2", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000030 RID: 48 RVA: 0x0000426C File Offset: 0x0000246C
		internal static byte[] APRESP
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("APRESP", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00004294 File Offset: 0x00002494
		internal static byte[] authenticator
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("authenticator", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000042BC File Offset: 0x000024BC
		internal static byte[] macsresp
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("macsresp", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000042E4 File Offset: 0x000024E4
		internal static byte[] resp
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("resp", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000034 RID: 52 RVA: 0x0000430C File Offset: 0x0000250C
		internal static byte[] servicereq
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("servicereq", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00004334 File Offset: 0x00002534
		internal static byte[] test
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("test", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000036 RID: 54 RVA: 0x0000435C File Offset: 0x0000255C
		internal static byte[] TGSREQ
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("TGSREQ", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00004384 File Offset: 0x00002584
		internal static byte[] tgsres
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("tgsres", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000038 RID: 56 RVA: 0x000043AC File Offset: 0x000025AC
		internal static byte[] tgsresp
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("tgsresp", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000043D4 File Offset: 0x000025D4
		internal static byte[] XMACSREQ
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("XMACSREQ", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x04000014 RID: 20
		private static ResourceManager resourceMan;

		// Token: 0x04000015 RID: 21
		private static CultureInfo resourceCulture;
	}
}
