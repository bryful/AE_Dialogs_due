using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace AE_Dialog_Mk
{
	public class A_dropdownlist : ComboBox
	{
		private string _objName = "";
		private string _itemsName = "";
		private int _index = -1;
		//------------------------------------------------------------------------------------------------------------
		public A_dropdownlist()
		{
			this.AutoSize = false;
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Font = new Font("Tahoma", 8.25f);
			if (this.Name != "")
			{
				_objName = this.Name;
				_itemsName = _objName + "Items";
			}
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
					_itemsName = AE_objName + "Items";
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
		[Category("AE")]
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
				string ret = $"var {AE_itemsName}=[{itms}];\r\n";
				ret += $"var {AE_objName} = {Utils.GetWinObjName(this)}.add(\"dropdownlist\", {BoundStr},{AE_itemsName});\r\n";

				return ret;
			}
		}
		// ****************************************************************************************************
		// ****************************************************************************************************
		// ****************************************************************************************************
		// ****************************************************************************************************
		// **************************************************************
		#region Prop
		[Browsable(false)]
		public new System.Windows.Forms.AutoCompleteMode AutoCompleteMode
		{
			get { return base.AutoCompleteMode; }
			set { base.AutoCompleteMode = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.AutoCompleteSource AutoCompleteSource
		{
			get { return base.AutoCompleteSource; }
			set { base.AutoCompleteSource = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.AutoCompleteStringCollection AutoCompleteCustomSource
		{
			get { return base.AutoCompleteCustomSource; }
			set { base.AutoCompleteCustomSource = value; }
		}
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
		public new System.Object DataSource
		{
			get { return base.DataSource; }
			set { base.DataSource = value; }
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
		public new System.Int32 DropDownWidth
		{
			get { return base.DropDownWidth; }
			set { base.DropDownWidth = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 DropDownHeight
		{
			get { return base.DropDownHeight; }
			set { base.DropDownHeight = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean DroppedDown
		{
			get { return base.DroppedDown; }
			set { base.DroppedDown = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.FlatStyle FlatStyle
		{
			get { return base.FlatStyle; }
			set { base.FlatStyle = value; }
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
		public new System.Int32 MaxDropDownItems
		{
			get { return base.MaxDropDownItems; }
			set { base.MaxDropDownItems = value; }
		}
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
		public new System.Int32 MaxLength
		{
			get { return base.MaxLength; }
			set { base.MaxLength = value; }
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
		public new System.String SelectedText
		{
			get { return base.SelectedText; }
			set { base.SelectedText = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 SelectionLength
		{
			get { return base.SelectionLength; }
			set { base.SelectionLength = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 SelectionStart
		{
			get { return base.SelectionStart; }
			set { base.SelectionStart = value; }
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
		public new System.Windows.Forms.ComboBoxStyle DropDownStyle
		{
			get { return base.DropDownStyle; }
			set { base.DropDownStyle = value; }
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
		[Browsable(false)]
		public new System.Boolean Enabled
		{
			get { return base.Enabled; }
			set { base.Enabled = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Font Font
		{
			get { return base.Font; }
			set { base.Font = value; }
		}
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
		[Browsable(false)]
		public new System.Int32 TabIndex
		{
			get { return base.TabIndex; }
			set { base.TabIndex = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean TabStop
		{
			get { return base.TabStop; }
			set { base.TabStop = value; }
		}
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
		// ****************************************************************************************************
	}
}
