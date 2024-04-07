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
	public class A_edittext : TextBox
	{
		private string _objName = "";
		//------------------------------------------------------------------------------------------------------------
		public A_edittext()
		{
			base.AutoSize = false;
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
			set { _objName = value.Trim(); }
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
		public string AE_text
		{
			get
			{
				string s = this.Text;
				s = s.Replace("\r", "\\r");
				s = s.Replace("\n", "\\n");
				s = s.Replace("\t", "\\t");
				return s;
			}
			set
			{
				string s = value;
				s = s.Replace("\\r", "\r");
				s = s.Replace("\\n", "\n");
				s = s.Replace("\\t", "\t");

				this.Text = s;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
		public string[] AE_textLines
		{
			get
			{
				return this.Lines;
			}
			set
			{
				this.Lines = value;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
		public bool AE_readonly
		{
			get { return this.ReadOnly; }
			set { this.ReadOnly = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
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
		[Category("AE")]
		public bool AE_multiline
		{
			get { return this.Multiline; }
			set { this.Multiline = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
		public bool AE_scrollable
		{
			get { return ((this.Multiline == true) && (this.ScrollBars != System.Windows.Forms.ScrollBars.None)); }
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
		[Category("AE")]
		public bool AE_noecho
		{
			get { return (this.PasswordChar != '\0'); }
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
		[Category("AE")]
		public string ScriptCode
		{
			get
			{
				
				string op = "";
				if (AE_readonly == true)
				{
					op += "readonry:true";
				}
				if (AE_noecho == true)
				{
					if (op != "") op += ",";
					op += "noecho:true";
				}
				if (AE_borderless == true)
				{
					if (op != "") op += ",";
					op += "borderles:true";
				}
				if (AE_multiline)
				{
					if (op != "") op += ",";
					op += "multiline:true";
					if (AE_scrollable)
					{
						if (op != "") op += ",";
						op += "_scrollable:true";
					}
					else
					{
						if (op != "") op += ",";
						op += "_scrollable:false";
					}
				}
				if (op != "") op = ",{" + op + "}";
				
				string ret = $"var {AE_objName} = {Utils.GetWinObjName(this)}.add(\"edittext\", {BoundStr}, \"{AE_text}\" {op});\r\n";

				return ret;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		// ************************************************************************************
		// ************************************************************************************
		// ************************************************************************************
		#region
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AcceptsReturn
		{
			get { return base.AcceptsReturn; }
			set { base.AcceptsReturn = value; }
		}
		// **************************************************************
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
		public new System.Windows.Forms.CharacterCasing CharacterCasing
		{
			get { return base.CharacterCasing; }
			set { base.CharacterCasing = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean Multiline
		{
			get { return base.Multiline; }
			set { base.Multiline = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Char PasswordChar
		{
			get { return base.PasswordChar; }
			set { base.PasswordChar = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.ScrollBars ScrollBars
		{
			get { return base.ScrollBars; }
			set { base.ScrollBars = value; }
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
		public new System.Windows.Forms.HorizontalAlignment TextAlign
		{
			get { return base.TextAlign; }
			set { base.TextAlign = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean UseSystemPasswordChar
		{
			get { return base.UseSystemPasswordChar; }
			set { base.UseSystemPasswordChar = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String PlaceholderText
		{
			get { return base.PlaceholderText; }
			set { base.PlaceholderText = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AcceptsTab
		{
			get { return base.AcceptsTab; }
			set { base.AcceptsTab = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean ShortcutsEnabled
		{
			get { return base.ShortcutsEnabled; }
			set { base.ShortcutsEnabled = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AutoSize
		{
			get { return base.AutoSize; }
			set { base.AutoSize = false; }
		}
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
		
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean HideSelection
		{
			get { return base.HideSelection; }
			set { base.HideSelection = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String[] Lines
		{
			get { return base.Lines; }
			set { base.Lines = value; }
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
		public new System.Boolean Modified
		{
			get { return base.Modified; }
			set { base.Modified = value; }
		}
		
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean ReadOnly
		{
			get { return base.ReadOnly; }
			set { base.ReadOnly = value; }
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
		public new System.Boolean WordWrap
		{
			get { return base.WordWrap; }
			set { base.WordWrap = value; }
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
		// ************************************************************************************
	}
}
