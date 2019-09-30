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
	public class Listbox_AE : ListBox
	{
		private bool _IsLocal = true;
		private string _objName = "";
		private bool _showHeaders = false;
		private int [] _columnWidths = new int[1];
		private string[] _columnTitles = new string[1];
		private string _itemsName = "";
		//------------------------------------------------------------------------------------------------------------
		public Listbox_AE()
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
			set { _objName = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_itemsName
		{
			get
			{
				if (_itemsName == string.Empty)
				{
					_itemsName = this.AE_objName + "_items";
				}
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
				if ((this.Location.X != value.Left) || (this.Location.Y != value.Top) || (this.Size.Width != value.Width) || (this.Size.Height != value.Height))
				{
					this.Location = new Point(value.Left, value.Top);
					this.Size = new Size(value.Width, value.Height);
					chkWidth();
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
		public bool AE_multiselect
		{
			get { return ((this.SelectionMode == System.Windows.Forms.SelectionMode.MultiExtended) || (this.SelectionMode == System.Windows.Forms.SelectionMode.MultiSimple)); }
			set
			{
				if (value == true)
				{
					this.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
				}
				else
				{
					this.SelectionMode = System.Windows.Forms.SelectionMode.One;
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		private void chkWidth()
		{
			if (AE_numberOfColumns <= 0) return;

			int totalW = 0;
			for (int i = 0; i < _columnWidths.Length; i++)
			{
				if (_columnWidths[i] <= 0) _columnWidths[i] = 10;
				totalW += _columnWidths[i];
			}
			Rectangle r = AE_bounds;

			if (r.Width == totalW)
			{
				//
			}
			else if (r.Width > totalW)
			{
				_columnWidths[_columnWidths.Length - 1] += r.Width - totalW;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public int AE_numberOfColumns
		{
			get
			{
				return _columnTitles.Length;
			}
			set
			{
				if (value > 0)
				{
					if (_columnTitles.Length != value)
					{
						Array.Resize(ref _columnTitles, value);
					}
					if (_columnWidths.Length != value)
					{
						Array.Resize(ref _columnWidths, value);
					}
					chkWidth();
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_showHeaders
		{
			get { return _showHeaders; }
			set { _showHeaders = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public int[] AE_columnWidths
		{
			get { return _columnWidths; }
			set 
			{
				_columnWidths = value;
				if (_columnTitles.Length != _columnWidths.Length)
				{
					Array.Resize(ref _columnTitles, _columnWidths.Length);
					AE_columnTitles = _columnTitles;
				}
				chkWidth();
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public string[] AE_columnTitles
		{
			get { return _columnTitles; }
			set
			{
				_columnTitles = value;
				if (_columnWidths.Length != _columnTitles.Length)
				{
					Array.Resize(ref _columnWidths, _columnTitles.Length);
					AE_columnWidths = _columnWidths;
				}
				chkWidth();
			}
		}
	}
}
