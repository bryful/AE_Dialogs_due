using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Reflection;

namespace AE_Dialog_Mk
{
	public enum windowType
	{
		dialog = 0,
		paletet,
		window,
		floatingPalette,
	}
	public enum iconbuttonStyle
	{
		button = 0,
		toolbutton
	}
	public enum borderStyle
	{
		black = 0,
		etched,
		gray,
		raised,
		sunken
	}
	public static class Utils
	{
		private static string[] windowTypeT = new string[]
		{
			"dialog",
			"paletet",
			"window",
			"palette", //floatingPalette
		};
		public static string windowTypeStr(windowType wt)
		{
			return windowTypeT[(int)wt];
		}
		//------------------------------------------------------------------------------------------------------------
		public static string RectToBounds(Rectangle rct)
		{
			string ret = "";
			ret = $"[{rct.Left},{rct.Top},{rct.Left}+{rct.Width},{rct.Top}+{rct.Height}]";
			return ret;
		}
		//------------------------------------------------------------------------------------------------------------
		public static string zero3(int v)
		{
			string ret = v.ToString();


			int l = ret.Length;

			if (l < 4)
			{
				for (int i = 0; i < (4 - l); i++)
				{
					ret = " " + ret;
				}
			}




			return ret;
		}
		//------------------------------------------------------------------------------------------------------------
		public static string GetBoundStr(Control sender)
		{
			Rectangle b = sender.Bounds;
			if(sender is Form)
			{
				b = sender.ClientRectangle;
			}
			/*
			if ((sender.Parent is Panel_AE) || (sender.Parent is Group_AE) || (sender.Parent is GroupBox) || (sender.Parent is Panel))
			{
				b.Y -= 8;
			}
			*/
			return RectToBounds(b);
		}
		//------------------------------------------------------------------------------------------------------------
		public static int[] ToBounds(Control sender)
		{
			return new int[] { sender.Left, sender.Top, sender.Right, sender.Bottom };
		}
		//------------------------------------------------------------------------------------------------------------
		public static void FromBounds(int[] b, Control sender)
		{
			if (b.Length >= 4)
			{
				int v = 0;
				if (b[0] > b[2])
				{
					v = b[0];
					b[0] = b[2];
					b[2] = v;
				}
				if (b[1] > b[3])
				{
					v = b[1];
					b[1] = b[3];
					b[3] = v;
				}
			}
			if (b.Length >= 2)
			{
				sender.Location = new Point(b[0], b[1]);
			}
			if (b.Length >= 4)
			{
				sender.Size = new Size(b[2] - b[0], b[3] - b[1]);
			}
			//------------------------------------------------------------------------------------------------------------
		}
		public static Form? GetForm(Control c)
		{
			Form? ret = null;
			var p = c.Parent;
			while (p != null)
			{
				if (p is Form)
				{
					ret = (Form?)p; 
					break;
				}
				p = p.Parent;
			}
			return ret;
		}
		public static string GetWinObjName(Control c)
		{
			string ret = "parent";
			Control? f = c.Parent;
			if (f != null)
			{
				if (f is A_Form)
				{
					ret = ((A_Form)f).AE_objName;
					
				}else if (f is A_group)
				{
					ret = ((A_group)f).AE_objName;
				}
			}
			return ret;
		}
		private static int FindTabIndex(Control ctrl,int tidx)
		{
			int ret = -1;
			if ((tidx<0)||(tidx>=ctrl.Controls.Count)) return ret;
			for (int i = 0; i < ctrl.Controls.Count; i++)
			{
				if (ctrl.Controls[i].TabIndex == tidx)
				{
					ret = i; 
					break;
				}
			}
			return ret;
		}
		public static string GetControlsScriptCode(Control ctrl)
		{
			string ret = "";
			if (ctrl.Controls.Count > 0)
			{
				for(int i= 0; i< ctrl.Controls.Count; i++)
				{
					int idx = FindTabIndex(ctrl, i);
					if (idx < 0) continue;
					Control c = ctrl.Controls[idx];
					string ss = "";
					if (c is A_button) { ss = ((A_button)c).ScriptCode; }
					else if (c is A_checkbox) { ss = ((A_checkbox)c).ScriptCode; }
					else if (c is A_group) { ss = ((A_group)c).GetScriptCode(); }
					else if (c is A_panel) { ss = ((A_panel)c).GetScriptCode(); }
					else if (c is A_dropdownlist) { ss = ((A_dropdownlist)c).ScriptCode; }
					else if (c is A_edittext) { ss = ((A_edittext)c).ScriptCode; }
					else if (c is A_listbox) { ss = ((A_listbox)c).ScriptCode; }
					else if (c is A_radiobutton) { ss = ((A_radiobutton)c).ScriptCode; }
					else if (c is A_statictext) { ss = ((A_statictext)c).ScriptCode; }
					/*
					else if (c is Iconbutton_AE) { ss = ((Iconbutton_AE)c).ScriptCode; }
					else if (c is Image_AE) { ss = ((Image_AE)c).ScriptCode; }
					else if (c is Progressbar_AE) { ss = ((Progressbar_AE)c).ScriptCode; }
					else if (c is ScrollbarH_AE) { ss = ((ScrollbarH_AE)c).ScriptCode; }
					else if (c is ScrollbarV_AE) { ss = ((ScrollbarV_AE)c).ScriptCode; }
					else if (c is Slider_AE) { ss = ((Slider_AE)c).ScriptCode; }
					*/
					if (ss != "") ret += ss;

				}
			}
			return ret;
		}
		public static string GetProps(Type ct)
		{
			// DateTimeのプロパティ一覧を取得する
			PropertyInfo[] p = ct.GetProperties();

			// 取得した一覧をコンソールに出力する
			string s = "";
			foreach (var a in p)
			{
				if (a.CanWrite == true)
				{
					s += "// **************************************************************\r\n";
					s += $"[Browsable(false)]\r\n";
					s += $"public new {a.PropertyType.ToString()} {a.Name}\r\n";
					s += $"{{\r\n";
					s += $"	get {{ return base.{a.Name}; }}\r\n";
					s += $"	set {{ base.{a.Name} = value; }}\r\n";
					s += "}\r\n";
				}
			}
			return s;
		}
		public static string GetPropsFromForm()
		{
			// DateTimeのプロパティ一覧を取得する
			PropertyInfo[] p = typeof(Form).GetProperties();

			// 取得した一覧をコンソールに出力する
			string s = "";
			foreach (var a in p)
			{
				if (a.CanWrite == true)
				{
					s += "// **************************************************************\r\n";
					s += $"[Browsable(false)]\r\n";
					s += $"public new {a.PropertyType.ToString()} {a.Name}\r\n";
					s += $"{{\r\n";
					s += $"	get {{ return base.{a.Name}; }}\r\n";
					s += $"	set {{ base.{a.Name} = value; }}\r\n";
					s += "}\r\n";
				}
			}
			return s;
		}
	}
}
