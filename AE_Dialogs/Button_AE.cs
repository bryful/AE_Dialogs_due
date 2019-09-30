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
	public class Button_AE : Button
	{
		private bool _IsLocal = true;
		private string _objName = "";
		private string _textObjName = "";
		//------------------------------------------------------------------------------------------------------------
		public Button_AE()
		{
			this.Font = new Font("Tahoma", 8.25f);
			_objName = this.Name;
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_isLocal
		{
			get { return _IsLocal; }
			set { _IsLocal = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_text
		{
			get { return this.Text; }
			set { this.Text = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_textObjName
		{
			get { return _textObjName; }
			set { _textObjName = value.Trim(); }
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
		public Rectangle AE_bounds
		{
			get { return new Rectangle(this.Left,this.Top,this.Width,this.Height); }
			set 
			{
				this.Location = new Point(value.Left, value.Top);
				this.Size = new Size(value.Width, value.Height);
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public defaultElement AE_defaultElement
		{
			get 
			{
				switch (this.DialogResult)
				{
					case System.Windows.Forms.DialogResult.OK:
						return defaultElement.ok;
					case System.Windows.Forms.DialogResult.Yes:
						this.DialogResult = System.Windows.Forms.DialogResult.OK;
						return defaultElement.ok;
					case System.Windows.Forms.DialogResult.Cancel:
						return defaultElement.cancel;
					case System.Windows.Forms.DialogResult.Abort:
					case System.Windows.Forms.DialogResult.No:
					case System.Windows.Forms.DialogResult.Ignore:
					case System.Windows.Forms.DialogResult.Retry:
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
						return defaultElement.cancel;
					case System.Windows.Forms.DialogResult.None:
					default:
						return defaultElement.none;
				}
			}
			set
			{
				switch (value)
				{
					case defaultElement.none:
						this.DialogResult = System.Windows.Forms.DialogResult.None;
						break;
					case defaultElement.ok:
						this.DialogResult = System.Windows.Forms.DialogResult.OK;
						break;
					case defaultElement.cancel:
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
						break;

				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public string BoundStr
		{
			get{return Utils.GetBoundStr(this);}
		}
		//------------------------------------------------------------------------------------------------------------

	}
}
