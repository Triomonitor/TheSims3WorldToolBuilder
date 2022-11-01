using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Crownwood.DotNetMagic.Controls;

namespace Sims3.Automation
{
	// Token: 0x02000008 RID: 8
	public partial class AutoTestForm : Form
	{
		// Token: 0x06000026 RID: 38 RVA: 0x00002E60 File Offset: 0x00001E60
		public AutoTestForm()
		{
			this.InitializeComponent();
			Log.Instance.LogEvent += this.Log_LogEvent;
			try
			{
				Type[] types = Assembly.GetEntryAssembly().GetTypes();
				foreach (Type type in types)
				{
					AttributeCollection attributes = TypeDescriptor.GetAttributes(type);
					foreach (object obj in attributes)
					{
						Attribute attribute = (Attribute)obj;
						if (attribute is AutoTestFixtureAttribute)
						{
							MethodInfo initMethod = null;
							MethodInfo clearMethod = null;
							MethodInfo methodInfo = null;
							MethodInfo teardownMethod = null;
							MethodInfo[] methods = type.GetMethods();
							foreach (MethodInfo methodInfo2 in methods)
							{
								object[] customAttributes = methodInfo2.GetCustomAttributes(typeof(AutoTestInitAttribute), false);
								if (customAttributes.Length > 0)
								{
									initMethod = methodInfo2;
								}
								customAttributes = methodInfo2.GetCustomAttributes(typeof(AutoTestClearAttribute), false);
								if (customAttributes.Length > 0)
								{
									clearMethod = methodInfo2;
								}
								customAttributes = methodInfo2.GetCustomAttributes(typeof(AutoTestFixtureSetupAttribute), false);
								if (customAttributes.Length > 0)
								{
									methodInfo = methodInfo2;
								}
								customAttributes = methodInfo2.GetCustomAttributes(typeof(AutoTestFixtureTearDownAttribute), false);
								if (customAttributes.Length > 0)
								{
									teardownMethod = methodInfo2;
								}
							}
							ConstructorInfo constructor = type.GetConstructor(new Type[0]);
							object obj2 = constructor.Invoke(null);
							Node node = new Node(type.FullName);
							node.Tag = new AutoTestForm.TestFixture(obj2, methodInfo, teardownMethod);
							this.mTreeView.Nodes.Add(node);
							foreach (MethodInfo methodInfo3 in methods)
							{
								object[] customAttributes2 = methodInfo3.GetCustomAttributes(typeof(AutoTestAttribute), false);
								if (customAttributes2.Length > 0)
								{
									Node node2 = new Node(methodInfo3.Name);
									node2.Tag = new AutoTestForm.TestMethod(initMethod, methodInfo3, clearMethod);
									node.Nodes.Add(node2);
								}
							}
							if (methodInfo != null)
							{
								methodInfo.Invoke(obj2, null);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.Instance.Error("AutoTestForm", "Error during setup: " + ex.ToString(), new object[0]);
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000031CC File Offset: 0x000021CC
		public void AddText(string message, Color color)
		{
			this.mTextBox.SelectionStart = this.mTextBox.Text.Length;
			this.mTextBox.SelectionColor = color;
			this.mTextBox.AppendText(message);
			this.mTextBox.AppendText("\r\n");
			this.mTextBox.SelectionStart = this.mTextBox.Text.Length;
			this.mTextBox.ScrollToCaret();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003244 File Offset: 0x00002244
		private void Play_Click(object sender, EventArgs e)
		{
			Node selectedNode = this.mTreeView.SelectedNode;
			if (selectedNode != null)
			{
				try
				{
					if (selectedNode.Tag is AutoTestForm.TestMethod)
					{
						this.mTextBox.Clear();
						AutoTestForm.TestFixture testFixture = selectedNode.Parent.Tag as AutoTestForm.TestFixture;
						object @object = testFixture.Object;
						AutoTestForm.TestMethod testMethod = selectedNode.Tag as AutoTestForm.TestMethod;
						if (testMethod.InitMethod != null)
						{
							testMethod.InitMethod.Invoke(@object, null);
						}
						testMethod.MainMethod.Invoke(@object, null);
						if (testMethod.ClearMethod != null)
						{
							testMethod.ClearMethod.Invoke(@object, null);
						}
					}
				}
				catch (Exception ex)
				{
					Log.Instance.Error("AutoTestForm", "Error during playback: " + ex.ToString(), new object[0]);
				}
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003318 File Offset: 0x00002318
		private void Log_LogEvent(Log.Severity level, string message)
		{
			Color color = AutoTestForm.kSeverityLog;
			switch (level)
			{
			case Log.Severity.Warning:
				color = AutoTestForm.kSeverityWarning;
				break;
			case Log.Severity.Error:
				color = AutoTestForm.kSeverityError;
				break;
			default:
				color = AutoTestForm.kSeverityLog;
				break;
			}
			if (!base.IsDisposed)
			{
				Utils.Forms.InvokeMethod(this, "AddText", new object[]
				{
					message,
					color
				});
			}
		}

		// Token: 0x04000017 RID: 23
		private static readonly Color kSeverityError = Color.Red;

		// Token: 0x04000018 RID: 24
		private static readonly Color kSeverityWarning = Color.Orange;

		// Token: 0x04000019 RID: 25
		private static readonly Color kSeverityLog = Control.DefaultForeColor;

		// Token: 0x02000009 RID: 9
		private class TestMethod
		{
			// Token: 0x0600002D RID: 45 RVA: 0x00003718 File Offset: 0x00002718
			public TestMethod(MethodInfo initMethod, MethodInfo mainMethod, MethodInfo clearMethod)
			{
				this.mInitMethod = initMethod;
				this.mMainMethod = mainMethod;
				this.mClearMethod = clearMethod;
			}

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x0600002E RID: 46 RVA: 0x00003735 File Offset: 0x00002735
			public MethodInfo InitMethod
			{
				get
				{
					return this.mInitMethod;
				}
			}

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x0600002F RID: 47 RVA: 0x0000373D File Offset: 0x0000273D
			public MethodInfo MainMethod
			{
				get
				{
					return this.mMainMethod;
				}
			}

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000030 RID: 48 RVA: 0x00003745 File Offset: 0x00002745
			public MethodInfo ClearMethod
			{
				get
				{
					return this.mClearMethod;
				}
			}

			// Token: 0x04000020 RID: 32
			private MethodInfo mInitMethod;

			// Token: 0x04000021 RID: 33
			private MethodInfo mMainMethod;

			// Token: 0x04000022 RID: 34
			private MethodInfo mClearMethod;
		}

		// Token: 0x0200000A RID: 10
		private class TestFixture
		{
			// Token: 0x06000031 RID: 49 RVA: 0x0000374D File Offset: 0x0000274D
			public TestFixture(object obj, MethodInfo setupMethod, MethodInfo teardownMethod)
			{
				this.mObject = obj;
				this.mSetupMethod = setupMethod;
				this.mTeardownMethod = teardownMethod;
			}

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x06000032 RID: 50 RVA: 0x0000376A File Offset: 0x0000276A
			public object Object
			{
				get
				{
					return this.mObject;
				}
			}

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000033 RID: 51 RVA: 0x00003772 File Offset: 0x00002772
			public MethodInfo SetupMethod
			{
				get
				{
					return this.mSetupMethod;
				}
			}

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000034 RID: 52 RVA: 0x0000377A File Offset: 0x0000277A
			public MethodInfo TeardownMethod
			{
				get
				{
					return this.mTeardownMethod;
				}
			}

			// Token: 0x04000023 RID: 35
			private object mObject;

			// Token: 0x04000024 RID: 36
			private MethodInfo mSetupMethod;

			// Token: 0x04000025 RID: 37
			private MethodInfo mTeardownMethod;
		}
	}
}
