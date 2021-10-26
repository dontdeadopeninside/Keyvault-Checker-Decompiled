using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Metro.ColorTables;
using XRPCLib;

namespace XenonKerbAuthenticator
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : MetroForm
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000026B0 File Offset: 0x000008B0
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000026D4 File Offset: 0x000008D4
		private void Form1_Load(object sender, EventArgs e)
		{
			this.listBox1.Items.Clear();
			string path = AppDomain.CurrentDomain.BaseDirectory + "KVs\\";
			string[] files = Directory.GetFiles(path);
			string[] directories = Directory.GetDirectories(path);
			foreach (string text in directories)
			{
				this.subFiles = Directory.GetFiles(text);
				foreach (string text2 in this.subFiles)
				{
					if (text2.EndsWith(".bin"))
					{
						int num = text.LastIndexOf('\\');
						int num2 = (num > 0) ? text2.LastIndexOf('\\', num - 1) : -1;
						string item = text2.Substring(num2 + 1);
						this.Names.Add(item);
						this.listBox1.Items.Add(item);
					}
				}
			}
			foreach (string text3 in files)
			{
				if (text3.EndsWith(".bin"))
				{
					int num3 = text3.LastIndexOf('\\');
					int num4 = (num3 > 0) ? text3.LastIndexOf('\\', num3 - 1) : -1;
					string item2 = text3.Substring(num4 + 1);
					this.Names.Add(item2);
					this.listBox1.Items.Add(item2);
				}
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000283A File Offset: 0x00000A3A
		private void progressBarStep()
		{
			this.progressBarX1.Step = 100 / this.Names.Count<string>();
			this.progressBarX1.PerformStep();
			this.progressBarX1.Refresh();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000286C File Offset: 0x00000A6C
		private void buttonX1_Click(object sender, EventArgs e)
		{
			this.listBox1.Items.Clear();
			this.buttonX1.Enabled = false;
			Program program = new Program();
			if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "KVs\\log.txt"))
			{
				try
				{
					program.textWriter.Close();
					File.Delete(AppDomain.CurrentDomain.BaseDirectory + "KVs\\log.txt");
				}
				catch (Exception arg)
				{
					this.exception = arg;
					MessageBox.Show("The file located at KVs\\log.txt is in use and cannot be accessed\n" + arg);
				}
			}
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.doWork));
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000029BC File Offset: 0x00000BBC
		private void doWork(object state)
		{
			Program program = new Program();
			base.Invoke(new MethodInvoker(delegate()
			{
				this.progressBarX1.Value = 0;
			}));
			string status;
			foreach (string text in this.Names)
			{
				program.getStatus(text);
				if (!program.returnStatus())
				{
					status = text + " is Unbanned";
					base.Invoke(new MethodInvoker(delegate()
					{
						this.listBox1.Items.Add(status);
					}));
					base.Invoke(new MethodInvoker(delegate()
					{
						this.listBox1.Refresh();
					}));
				}
				else
				{
					status = text + " is Banned";
					base.Invoke(new MethodInvoker(delegate()
					{
						this.listBox1.Items.Add(status);
					}));
					base.Invoke(new MethodInvoker(delegate()
					{
						this.listBox1.Refresh();
					}));
				}
				base.Invoke(new MethodInvoker(delegate()
				{
					this.progressBarStep();
				}));
				base.Invoke(new MethodInvoker(delegate()
				{
					this.progressBarX1.Refresh();
				}));
			}
			base.Invoke(new MethodInvoker(delegate()
			{
				this.progressBarX1.Value = 100;
			}));
			program.textWriter.Close();
			base.Invoke(new MethodInvoker(delegate()
			{
				this.buttonX1.Enabled = true;
			}));
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002B4C File Offset: 0x00000D4C
		private void buttonX2_Click_1(object sender, EventArgs e)
		{
			this.Jtag.Connect();
			if (this.Jtag.activeConnection)
			{
				string text = this.listBox1.GetItemText(this.listBox1.SelectedItem);
				if (text.EndsWith(" is Banned"))
				{
					text = text.Substring(0, text.Length - 10);
				}
				if (text.EndsWith(" is Unbanned"))
				{
					text = text.Substring(0, text.Length - 12);
				}
				using (IEnumerator<string> enumerator = this.Names.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						string text2 = enumerator.Current;
						if (text2 == text)
						{
							try
							{
								if (this.renameCheck)
								{
									this.Jtag.xbCon.SendFile(AppDomain.CurrentDomain.BaseDirectory + text2, "HDD:\\" + text2.Substring(text2.LastIndexOf('\\') + 1));
									this.progressBarX1.Value = 100;
									MessageBox.Show("Sent KV Successfully", "Success");
									this.progressBarX1.Value = 100;
								}
								else if (!this.renameCheck)
								{
									this.Jtag.xbCon.SendFile(AppDomain.CurrentDomain.BaseDirectory + text2, "HDD:\\KV.bin");
									this.progressBarX1.Value = 100;
									MessageBox.Show("Sent KV Successfully", "Success");
								}
								this.progressBarX1.Value = 0;
							}
							catch (Exception arg)
							{
								MessageBox.Show("Sorry, Sending the KV.bin file has failed\n" + arg);
							}
						}
					}
					return;
				}
			}
			MessageBox.Show("Sorry, Could not connect to Console\nVerify your connection and try again");
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002D04 File Offset: 0x00000F04
		private static string checkNames(string item)
		{
			if (item.EndsWith(" is Banned"))
			{
				item = item.Substring(item.Length - 10, 10);
			}
			else if (item.EndsWith(" is Unbanned"))
			{
				item = item.Substring(item.Length - 12, 12);
			}
			return item;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002D54 File Offset: 0x00000F54
		private void buttonX3_Click(object sender, EventArgs e)
		{
			this.Jtag.Connect();
			if (this.Jtag.activeConnection)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Title = "Save your Xbox 360 KV.bin file";
				saveFileDialog.Filter = "Binary File (*.bin)|*.bin";
				saveFileDialog.FileName = "KV";
				saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
				Program program = new Program();
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				try
				{
					this.Jtag.xbCon.ReceiveFile(saveFileDialog.FileName, "HDD:\\KV.bin");
					int num = saveFileDialog.FileName.LastIndexOf('\\');
					int num2 = (num > 0) ? saveFileDialog.FileName.LastIndexOf('\\', num - 1) : -1;
					string str = saveFileDialog.FileName.Substring(num2 + 1);
					program.getStatus(saveFileDialog.FileName);
					if (!program.returnStatus())
					{
						string item = str + " is Unbanned";
						this.listBox1.Items.Add(item);
						this.listBox1.Refresh();
					}
					else
					{
						string item = str + " is Banned";
						this.listBox1.Items.Add(item);
						this.listBox1.Refresh();
					}
					program.textWriter.Close();
					return;
				}
				catch (Exception arg)
				{
					MessageBox.Show("Sorry, Receiving the KV.bin file has failed" + arg);
					return;
				}
			}
			MessageBox.Show("Sorry, Could not connect to Console/nVerify your connection and try again");
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002EC4 File Offset: 0x000010C4
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002EC8 File Offset: 0x000010C8
		private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
			{
				return;
			}
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, Color.DarkOrange);
			}
			e.DrawBackground();
			e.Graphics.DrawString(this.listBox1.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
			e.DrawFocusRectangle();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002F69 File Offset: 0x00001169
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox1.Checked)
			{
				this.renameCheck = false;
				return;
			}
			this.renameCheck = true;
		}

		// Token: 0x0400000A RID: 10
		private string[] subFiles;

		// Token: 0x0400000B RID: 11
		private bool renameCheck;

		// Token: 0x0400000C RID: 12
		private Exception exception;

		// Token: 0x0400000D RID: 13
		private IList<string> Names = new List<string>();

		// Token: 0x0400000E RID: 14
		private XRPC Jtag = new XRPC();
    }
}
