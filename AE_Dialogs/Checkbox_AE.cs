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
	public class Checkbox_AE : CheckBox
	{
		private bool _IsLocal = true;
		private string _objName = "";
		private string _textObjName = "";

		//------------------------------------------------------------------------------------------------------------
		public Checkbox_AE()
		{
			this.AutoSize = false;
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
		protected override void OnAutoSizeChanged(EventArgs e)
		{
			this.AutoSize = false;
			base.OnAutoSizeChanged(e);
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_isLocal
		{
			get { return _IsLocal; }
			set { _IsLocal = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_value
		{
			get { return this.Checked; }
			set { this.Checked = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_text
		{
			get { return this.Text; }
			set { this.Text = value; }
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
		public string BoundStr
		{
			get { return Utils.GetBoundStr(this); }
		}

	}
}
