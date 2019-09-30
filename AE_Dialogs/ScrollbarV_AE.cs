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
	public class ScrollbarV_AE : VScrollBar
	{
		private bool _IsLocal = false;
		private string _objName = "";

		//------------------------------------------------------------------------------------------------------------
		public ScrollbarV_AE()
		{
			this.Value = 0;
			this.Minimum = 0;
			this.Maximum = 100;
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
			set { _objName = value; }
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
		public int AE_value
		{
			get { return this.Value; }
			set { this.Value = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public int AE_minvalue
		{
			get { return this.Minimum; }
			set
			{
				if (this.Maximum < value) return;
				int jd = 100 * this.LargeChange / (this.Maximum - this.Minimum);
				this.Minimum = value;
				this.LargeChange = (this.Maximum - this.Minimum) * jd / 100;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public int AE_maxvalue
		{
			get { return this.Maximum; }
			set
			{
				if (this.Minimum > value) return;
				int jd = 100 * this.LargeChange / (this.Maximum - this.Minimum);
				this.Maximum = value;
				this.LargeChange = (this.Maximum - this.Minimum) * jd / 100;
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


	}
}
