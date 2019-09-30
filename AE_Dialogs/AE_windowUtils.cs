using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace bryful_due
{
	public enum windowType
	{
		dialog = 0,
		paletet,
		floatingPalette,
		window,
	}
	public enum defaultElement
	{
		none = 0,
		ok,
		cancel
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
	public static class  Utils
	{
		private static string[] windowTypeT = new string[]
		{
			"dialog",
			"paletet",
			"palette", //floatingPalette
			"window"
		};
		public static string windowTypeStr(windowType wt)
		{
			return windowTypeT[(int)wt];
		}
		//------------------------------------------------------------------------------------------------------------
		public static string RectToBounds(Rectangle rct)
		{
			string ret = "";
			ret += "[" + zero3(rct.Left) + ", " + zero3(rct.Top) + ", " + zero3(rct.Left) + "+" + zero3(rct.Width) + ", " + zero3(rct.Top) + "+" + zero3(rct.Height) + "]";
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
		public static string GetBoundStr( Control sender)
		{
			Rectangle b = sender.Bounds;
			if ((sender.Parent is Panel_AE) || (sender.Parent is Group_AE) || (sender.Parent is GroupBox) || (sender.Parent is Panel))
			{
				b.Y -= 8;
			}
			return RectToBounds(b);
		}
		//------------------------------------------------------------------------------------------------------------
	}
}
