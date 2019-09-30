using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bryful_due
{
	public partial class CodeDisp : Form
	{
		[System.Runtime.InteropServices.DllImport("User32.dll")]
		static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int[] lParam);
		public CodeDisp()
		{
			InitializeComponent();
			const int EM_SETTABSTOPS = 0x00CB;
			SendMessage(textBox1.Handle, EM_SETTABSTOPS, 1, new int[] { 8 });

		}
		public string Code
		{
			get { return textBox1.Text; }
			set 
			{
				textBox1.Text = value;
			}
		}
		private void SelectAll()
		{
			if (textBox1.Text.Length > 0)
			{
				textBox1.SelectionStart = 0;
				textBox1.SelectionLength = textBox1.Text.Length;
			}
		}
		private void toClipboard()
		{
			if (textBox1.SelectedText.Length > 0)
			{
				Clipboard.SetText(textBox1.SelectedText);
			}
		}
		private void closeMenu_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void selectAllMenu_Click(object sender, EventArgs e)
		{
			SelectAll();
		}

		private void copyMenu_Click(object sender, EventArgs e)
		{
			toClipboard();
		}

		private void fontMenu_Click(object sender, EventArgs e)
		{
			fontDialog1.Font = textBox1.Font;
			if (fontDialog1.ShowDialog() == DialogResult.OK)
			{
				textBox1.Font = fontDialog1.Font;
			}
		}
	}
}
