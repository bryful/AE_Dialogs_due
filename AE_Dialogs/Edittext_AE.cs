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
	public class Edittext_AE : TextBox
	{
		private bool _IsLocal = false;
		private string _objName = "";
		private string _textObjName = "";
		//------------------------------------------------------------------------------------------------------------
		public Edittext_AE()
		{
			this.Font = new Font("Tahoma", 8.25f);

		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_objName
		{
			get
			{
				if (_objName == string.Empty)
					_objName = this.Name;
				return _objName;
			}
			set { _objName = value.Trim(); }
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_textObjName
		{
			get { return _textObjName; }
			set { _textObjName = value.Trim(); }
		}
		//------------------------------------------------------------------------------------------------------------
		public string[] AE_text
		{
			get{
				return this.Lines;
			}
			set {
				this.Lines = value;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_textLine()
		{
			if (this.Lines.Length <= 0)
			{
				return string.Empty;
			}
			else
			{
				string ret = "";
				for (int i = 0; i < this.Lines.Length; i++)
				{
					ret += this.Lines[i];
					if (i < this.Lines.Length - 1) ret += "\\n";
				}
				return ret;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public Rectangle AE_bounds
		{
			get { return new Rectangle(this.Left, this.Top, this.Width, this.Height); }
			set
			{
				this.Location = new Point(value.Left, value.Top);
				this.Size = new Size(value.Width, value.Height);
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_readonly
		{
			get { return this.ReadOnly; }
			set { this.ReadOnly = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_borderless
		{
			get { return (this.BorderStyle == System.Windows.Forms.BorderStyle.None); }
			set 
			{
				if (value == true)
				{
					this.BorderStyle = System.Windows.Forms.BorderStyle.None;
				}
				else
				{
					this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_multiline
		{
			get { return this.Multiline; }
			set { this.Multiline = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_scrollable
		{
			get { return ((this.Multiline == true)&&(this.ScrollBars != System.Windows.Forms.ScrollBars.None )); }
			set 
			{
				if (value == true)
				{
					this.ScrollBars = System.Windows.Forms.ScrollBars.Both;
				}
				else
				{
					this.ScrollBars = System.Windows.Forms.ScrollBars.None;
				}
			}
		}

		//------------------------------------------------------------------------------------------------------------
		public bool AE_noecho
		{
			get { return (this.PasswordChar !='\0'); }
			set
			{
				if (value == true)
				{
					this.PasswordChar = '*';
				}
				else
				{
					this.PasswordChar = '\0';
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_isLocal
		{
			get { return _IsLocal; }
			set { _IsLocal = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public string BoundStr
		{
			get { return Utils.GetBoundStr(this); }
		}

		//------------------------------------------------------------------------------------------------------------

	}
}
