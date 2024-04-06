using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AE_Dialog_Mk
{
	public class A_listbox : ListBox
	{
		private string _objName = "";
		private string _itemsName = "";

		private bool _selected = true;
		private int[] _columnWidths = new int[1];
		private string[] _columnTitles = new string[1];
		private bool _showHeaders = false;
		//------------------------------------------------------------------------------------------------------------
		public A_listbox()
		{
			this.Font = new Font("Tahoma", 8.25f);

		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
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
		[Category("AE")]
		public string AE_itemsName
		{
			get
			{
				if (_itemsName == string.Empty)
				{
					_itemsName = AE_objName + "_items";
				}
				return _itemsName;
			}
			set { _itemsName = value.Trim(); }
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
		public int[] AE_bounds
		{
			get { return Utils.ToBounds(this); }
			set { Utils.FromBounds(value, this); }
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
		public string BoundStr
		{
			get { return Utils.GetBoundStr(this); }
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
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
		[Category("AE")]
		public bool AE_selected
		{
			get { return _selected; }
			set
			{
				_selected = value;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
		private void chkWidth()
		{
			if (AE_numberOfColumns <= 0) return;

			int totalW = 0;
			for (int i = 0; i < _columnWidths.Length; i++)
			{
				if (_columnWidths[i] <= 0) _columnWidths[i] = 10;
				totalW += _columnWidths[i];
			}
			Rectangle r = this.ClientRectangle;

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
		[Category("AE")]
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
		[Category("AE")]
		public bool AE_showHeaders
		{
			get { return _showHeaders; }
			set { _showHeaders = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
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
		[Category("AE")]
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

		[Category("AE")]
		public string ScriptCode
		{
			get
			{
				string itms = "";
				if (this.Items.Count > 0)
				{
					foreach (var item in this.Items)
					{
						string ss = item.ToString();
						if (itms != "") itms += ",";
						itms += "\"" + ss + "\"";
					}
				}

				var op = "";
				if (AE_multiselect == true)
				{
					if (op != "") op += ",";
					op += "multiselect:true";
				}
				if (AE_selected == true)
				{
					if (op != "") op += ",";
					op += "selected:true";
				}
				if (AE_numberOfColumns > 1)
				{
					if (op != "") op += ",";
					op += $"numberOfColumns:{AE_numberOfColumns}";
				}
				if (AE_showHeaders == true)
				{
					if (op != "") op += ",";
					op += "showHeaders:true";
					if (AE_columnWidths.Length > 0)
					{
						if (op != "") op += ",";
						string cw = string.Empty;
						foreach (int v in AE_columnWidths)
						{
							if (cw != "") cw += ",";
							cw += $"{v}";
						}
						op += $",columnWidths:[{cw}]";
					}
					if (AE_columnTitles.Length > 0)
					{
						if (op != "") op += ",";
						string ct = string.Empty;
						foreach (string sss in AE_columnTitles)
						{
							if (ct != "") ct += ",";
							ct += $"\"{sss}\"";
						}
						op += $",columnTitles:[{ct}]";
					}
				}
				if (op != "") op = ",{" + op + "}";


				string ret = "";
				ret += $"var {AE_itemsName} = [{itms}];\r\n";
				ret += $"var {AE_objName} = {Utils.GetWinObjName(this)}.add(\"listbox\", {BoundStr}, {AE_itemsName} {op});\r\n";

				return ret;
			}
		}
		// ****************************************************************************************
		// ****************************************************************************************
		// ****************************************************************************************
		#region Prop
		#endregion

		// ****************************************************************************************

	}
}
