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
	public class Dropdownlist_AE : ComboBox
	{
		private bool _IsLocal = true;
		private string _objName = "";
		private string _itemsName = "";
		private int _index = -1;
		//------------------------------------------------------------------------------------------------------------
		public Dropdownlist_AE()
		{
			this.DropDownStyle = ComboBoxStyle.DropDownList;
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
		public string AE_itemsName
		{
			get
			{
				return _itemsName;
			}
			set { _itemsName = value.Trim(); }
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
		public bool AE_isLocal
		{
			get { return _IsLocal; }
			set { _IsLocal = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public int AE_index
		{
			get
			{
				return _index;
			}
			set
			{
				_index = value;
				if ((value >= 0) && (value < this.Items.Count))
				{
					this.SelectedIndex = value;
					this.Invalidate();
				}
					
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public string BoundStr
		{
			get { return Utils.GetBoundStr(this); }
		}
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			if (_index < 0) _index = this.SelectedIndex;
			base.OnSelectedIndexChanged(e);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.SelectedIndex != _index)
			{
				if ((_index >= 0) && (_index < this.Items.Count))
				{
					this.SelectedIndex = _index;
				}
			}
			base.OnPaint(e);
		}
	}
}
