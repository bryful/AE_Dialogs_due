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
	public class A_radiobutton : RadioButton
	{
		private string _objName = "";

		//------------------------------------------------------------------------------------------------------------
		public A_radiobutton()
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
		public string BoundStr
		{
			get { return Utils.GetBoundStr(this); }
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
		public string AE_text
		{
			get
			{ if (base.Text == "") base.Text = this.Name;
				return base.Text;
			}
			set { base.Text = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
		public bool AE_value
		{
			get { return this.Checked; }
			set { this.Checked = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE")]
		public int[] AE_bounds
		{
			get { return Utils.ToBounds(this); }
			set { Utils.FromBounds(value, this); }
		}
		[Category("AE")]
		public string ScriptCode
		{
			get
			{
				string ret = $"var {AE_objName} = {Utils.GetWinObjName(this)}.add(\"radiobutton\", {BoundStr}, \"{AE_text}\");\r\n";
				ret += $"{AE_objName} = {AE_value.ToString().ToLower()};\r\n";

				return ret;
			}
		}
		// ****************************************************************************************
		#region Prop
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AutoCheck
		{
			get { return base.AutoCheck; }
			set { base.AutoCheck = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.Appearance Appearance
		{
			get { return base.Appearance; }
			set { base.Appearance = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.ContentAlignment CheckAlign
		{
			get { return base.CheckAlign; }
			set { base.CheckAlign = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean Checked
		{
			get { return base.Checked; }
			set { base.Checked = value; }
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
		public new System.Drawing.ContentAlignment TextAlign
		{
			get { return base.TextAlign; }
			set { base.TextAlign = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AutoEllipsis
		{
			get { return base.AutoEllipsis; }
			set { base.AutoEllipsis = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AutoSize
		{
			get { return false ; }
			set { base.AutoSize = false; }
		}
		// **************************************************************
		
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Input.ICommand Command
		{
			get { return base.Command; }
			set { base.Command = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Object CommandParameter
		{
			get { return base.CommandParameter; }
			set { base.CommandParameter = value; }
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
		public new System.Drawing.Image Image
		{
			get { return base.Image; }
			set { base.Image = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.ContentAlignment ImageAlign
		{
			get { return base.ImageAlign; }
			set { base.ImageAlign = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Int32 ImageIndex
		{
			get { return base.ImageIndex; }
			set { base.ImageIndex = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String ImageKey
		{
			get { return base.ImageKey; }
			set { base.ImageKey = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.ImageList ImageList
		{
			get { return base.ImageList; }
			set { base.ImageList = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.ImeMode ImeMode
		{
			get { return base.ImeMode; }
			set { base.ImeMode = value; }
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
		public new System.Windows.Forms.TextImageRelation TextImageRelation
		{
			get { return base.TextImageRelation; }
			set { base.TextImageRelation = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean UseMnemonic
		{
			get { return base.UseMnemonic; }
			set { base.UseMnemonic = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean UseCompatibleTextRendering
		{
			get { return base.UseCompatibleTextRendering; }
			set { base.UseCompatibleTextRendering = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean UseVisualStyleBackColor
		{
			get { return base.UseVisualStyleBackColor; }
			set { base.UseVisualStyleBackColor = value; }
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

		#endregion
		// ****************************************************************************************
		// ****************************************************************************************
		// ****************************************************************************************
	}
}
