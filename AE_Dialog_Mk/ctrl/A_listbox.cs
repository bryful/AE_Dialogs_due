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
				if (Enabled == false) ret += $"{AE_objName}.enabled = false;\r\n";

				return ret;
			}
		}
		// ****************************************************************************************
		// ****************************************************************************************
		// ****************************************************************************************
		#region Prop
		// **************************************************************
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Image BackgroundImage
		{
			get { return base.BackgroundImage; }
			set { base.BackgroundImage = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.ImageLayout BackgroundImageLayout
		{
			get { return base.BackgroundImageLayout; }
			set { base.BackgroundImageLayout = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.BorderStyle BorderStyle
		{
			get { return base.BorderStyle; }
			set { base.BorderStyle = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 ColumnWidth
		{
			get { return base.ColumnWidth; }
			set { base.ColumnWidth = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean UseCustomTabOffsets
		{
			get { return base.UseCustomTabOffsets; }
			set { base.UseCustomTabOffsets = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.DrawMode DrawMode
		{
			get { return base.DrawMode; }
			set { base.DrawMode = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Font Font
		{
			get { return base.Font; }
			set { base.Font = value; }
		}
		// **************************************************************
		
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 HorizontalExtent
		{
			get { return base.HorizontalExtent; }
			set { base.HorizontalExtent = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean HorizontalScrollbar
		{
			get { return base.HorizontalScrollbar; }
			set { base.HorizontalScrollbar = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean IntegralHeight
		{
			get { return base.IntegralHeight; }
			set { base.IntegralHeight = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 ItemHeight
		{
			get { return base.ItemHeight; }
			set { base.ItemHeight = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean MultiColumn
		{
			get { return base.MultiColumn; }
			set { base.MultiColumn = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean ScrollAlwaysVisible
		{
			get { return base.ScrollAlwaysVisible; }
			set { base.ScrollAlwaysVisible = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 SelectedIndex
		{
			get { return base.SelectedIndex; }
			set { base.SelectedIndex = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Object SelectedItem
		{
			get { return base.SelectedItem; }
			set { base.SelectedItem = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.SelectionMode SelectionMode
		{
			get { return base.SelectionMode; }
			set { base.SelectionMode = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean Sorted
		{
			get { return base.Sorted; }
			set { base.Sorted = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String Text
		{
			get { return base.Text; }
			set { base.Text = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 TopIndex
		{
			get { return base.TopIndex; }
			set { base.TopIndex = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean UseTabStops
		{
			get { return base.UseTabStops; }
			set { base.UseTabStops = value; }
		}
		// **************************************************************
	
		// **************************************************************
		[Browsable(false)]
		public new System.Object DataSource
		{
			get { return base.DataSource; }
			set { base.DataSource = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String DisplayMember
		{
			get { return base.DisplayMember; }
			set { base.DisplayMember = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.IFormatProvider FormatInfo
		{
			get { return base.FormatInfo; }
			set { base.FormatInfo = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String FormatString
		{
			get { return base.FormatString; }
			set { base.FormatString = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean FormattingEnabled
		{
			get { return base.FormattingEnabled; }
			set { base.FormattingEnabled = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String ValueMember
		{
			get { return base.ValueMember; }
			set { base.ValueMember = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Object SelectedValue
		{
			get { return base.SelectedValue; }
			set { base.SelectedValue = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String AccessibleDefaultActionDescription
		{
			get { return base.AccessibleDefaultActionDescription; }
			set { base.AccessibleDefaultActionDescription = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String AccessibleDescription
		{
			get { return base.AccessibleDescription; }
			set { base.AccessibleDescription = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String AccessibleName
		{
			get { return base.AccessibleName; }
			set { base.AccessibleName = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.AccessibleRole AccessibleRole
		{
			get { return base.AccessibleRole; }
			set { base.AccessibleRole = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AllowDrop
		{
			get { return base.AllowDrop; }
			set { base.AllowDrop = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.AnchorStyles Anchor
		{
			get { return base.Anchor; }
			set { base.Anchor = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AutoSize
		{
			get { return base.AutoSize; }
			set { base.AutoSize = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Point AutoScrollOffset
		{
			get { return base.AutoScrollOffset; }
			set { base.AutoScrollOffset = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Object DataContext
		{
			get { return base.DataContext; }
			set { base.DataContext = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.BindingContext BindingContext
		{
			get { return base.BindingContext; }
			set { base.BindingContext = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Rectangle Bounds
		{
			get { return base.Bounds; }
			set { base.Bounds = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean Capture
		{
			get { return base.Capture; }
			set { base.Capture = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean CausesValidation
		{
			get { return base.CausesValidation; }
			set { base.CausesValidation = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Size ClientSize
		{
			get { return base.ClientSize; }
			set { base.ClientSize = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.ContextMenuStrip ContextMenuStrip
		{
			get { return base.ContextMenuStrip; }
			set { base.ContextMenuStrip = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.Cursor Cursor
		{
			get { return base.Cursor; }
			set { base.Cursor = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.DockStyle Dock
		{
			get { return base.Dock; }
			set { base.Dock = value; }
		}
		// **************************************************************
		
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 Height
		{
			get { return base.Height; }
			set { base.Height = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean IsAccessible
		{
			get { return base.IsAccessible; }
			set { base.IsAccessible = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 Left
		{
			get { return base.Left; }
			set { base.Left = value; }
		}
		// **************************************************************
		
		// **************************************************************
		
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Size MaximumSize
		{
			get { return base.MaximumSize; }
			set { base.MaximumSize = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Size MinimumSize
		{
			get { return base.MinimumSize; }
			set { base.MinimumSize = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String Name
		{
			get { return base.Name; }
			set { base.Name = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.Control Parent
		{
			get { return base.Parent; }
			set { base.Parent = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Region Region
		{
			get { return base.Region; }
			set { base.Region = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.RightToLeft RightToLeft
		{
			get { return base.RightToLeft; }
			set { base.RightToLeft = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.ComponentModel.ISite Site
		{
			get { return base.Site; }
			set { base.Site = value; }
		}
		// **************************************************************
		
		// **************************************************************
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean TabStop
		{
			get { return base.TabStop; }
			set { base.TabStop = value; }
		}
		// **************************************************************
		
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 Top
		{
			get { return base.Top; }
			set { base.Top = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean UseWaitCursor
		{
			get { return base.UseWaitCursor; }
			set { base.UseWaitCursor = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean Visible
		{
			get { return base.Visible; }
			set { base.Visible = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 Width
		{
			get { return base.Width; }
			set { base.Width = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.IWindowTarget WindowTarget
		{
			get { return base.WindowTarget; }
			set { base.WindowTarget = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.ImeMode ImeMode
		{
			get { return base.ImeMode; }
			set { base.ImeMode = value; }
		}

		#endregion

		// ****************************************************************************************

	}
}
