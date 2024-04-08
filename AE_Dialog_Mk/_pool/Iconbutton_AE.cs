using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BRY
{
	public class Iconbutton_AE : Button
	{
		private string _objName = "";

		private string _imageObjName = "";
		private string _imageFileName = "";
		private string _defExt = ".png";
		//------------------------------------------------------------------------------------------------------------
		public Iconbutton_AE()
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
			set { _objName = value.Trim(); }
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_imageObjName
		{
			get 
			{
				if (_imageObjName == "")
				{
					_imageObjName = AE_objName + "_img";
				}
				return _imageObjName;
			}
			set { _imageObjName = value.Trim(); }
		}
		//------------------------------------------------------------------------------------------------------------
		public int[] AE_bounds
		{
			get { return Utils.ToBounds(this); }
			set { Utils.FromBounds(value, this); }
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_defaultExt
		{
			get
			{
				return _defExt;
			}
			set
			{
				_defExt = value.Trim();
				if (_defExt != "")
				{
					if (_defExt[0] != '.') _defExt = "." + _defExt; 
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_imageFileName
		{
			get
			{
				if (_imageFileName == "")
					_imageFileName = AE_imageObjName + AE_defaultExt;
				
				if (Path.GetExtension(_imageFileName) == "")
				{
					_imageFileName = _imageFileName + AE_defaultExt;
				}
				_imageFileName = _imageFileName.Replace("\\", "\\\\");
				return _imageFileName;
			}
			set
			{ 
				_imageFileName = value.Trim();
				_imageFileName = _imageFileName.Replace("\\\\", "\\");
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_text
		{
			get { return base.Text; }
			set { base.Text = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public string BoundStr
		{
			get { return Utils.GetBoundStr(this); }
		}
		public string ScriptCode
		{
			get
			{
				string ret = $"var {AE_imageObjName} = new File(\"{AE_imageFileName}\");\r\n";
				ret += $"var {AE_objName} = ";
				if (this.Parent is Ae_Form)
				{
					ret += ((Ae_Form)this.Parent).AE_objName;
				}
				else if (this.Parent is Group_AE)
				{
					ret += ((Group_AE)this.Parent).AE_objName;
				}
				else if (this.Parent is Panel_AE)
				{
					ret += ((Panel_AE)this.Parent).AE_objName;
				}
				else
				{
					ret += "parent";
				}

				ret += $".add(\"iconbutton\", {BoundStr},{AE_imageObjName});\r\n";
				return ret;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		[Browsable(false)]
		public new string Text
		{
			get { return ""; }
			set { base.Text = ""; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.AutoSizeMode AutoSizeMode
		{
			get { return base.AutoSizeMode; }
			set { base.AutoSizeMode = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.DialogResult DialogResult
		{
			get { return base.DialogResult; }
			set { base.DialogResult = value; }
		}
		[Browsable(false)]
		public new System.Boolean AutoEllipsis
		{
			get { return base.AutoEllipsis; }
			set { base.AutoEllipsis = value; }
		}
		[Browsable(false)]
		public new System.Boolean AutoSize
		{
			get { return base.AutoSize; }
			set { base.AutoSize = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Color BackColor
		{
			get { return base.BackColor; }
			set { base.BackColor = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.FlatStyle FlatStyle
		{
			get { return base.FlatStyle; }
			set { base.FlatStyle = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Image Image
		{
			get { return base.Image; }
			set { base.Image = value; }
		}
		[Browsable(false)]
		public new System.Drawing.ContentAlignment ImageAlign
		{
			get { return base.ImageAlign; }
			set { base.ImageAlign = value; }
		}
		[Browsable(false)]
		public new System.Int32 ImageIndex
		{
			get { return base.ImageIndex; }
			set { base.ImageIndex = value; }
		}
		[Browsable(false)]
		public new System.String ImageKey
		{
			get { return base.ImageKey; }
			set { base.ImageKey = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.ImageList ImageList
		{
			get { return base.ImageList; }
			set { base.ImageList = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.ImeMode ImeMode
		{
			get { return base.ImeMode; }
			set { base.ImeMode = value; }
		}
		[Browsable(false)]
		public new System.Drawing.ContentAlignment TextAlign
		{
			get { return base.TextAlign; }
			set { base.TextAlign = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.TextImageRelation TextImageRelation
		{
			get { return base.TextImageRelation; }
			set { base.TextImageRelation = value; }
		}
		[Browsable(false)]
		public new System.Boolean UseMnemonic
		{
			get { return base.UseMnemonic; }
			set { base.UseMnemonic = value; }
		}
		[Browsable(false)]
		public new System.Boolean UseCompatibleTextRendering
		{
			get { return base.UseCompatibleTextRendering; }
			set { base.UseCompatibleTextRendering = value; }
		}
		[Browsable(false)]
		public new System.Boolean UseVisualStyleBackColor
		{
			get { return base.UseVisualStyleBackColor; }
			set { base.UseVisualStyleBackColor = value; }
		}
		[Browsable(false)]
		public new System.String AccessibleDefaultActionDescription
		{
			get { return base.AccessibleDefaultActionDescription; }
			set { base.AccessibleDefaultActionDescription = value; }
		}
		[Browsable(false)]
		public new System.String AccessibleDescription
		{
			get { return base.AccessibleDescription; }
			set { base.AccessibleDescription = value; }
		}
		[Browsable(false)]
		public new System.String AccessibleName
		{
			get { return base.AccessibleName; }
			set { base.AccessibleName = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.AccessibleRole AccessibleRole
		{
			get { return base.AccessibleRole; }
			set { base.AccessibleRole = value; }
		}
		[Browsable(false)]
		public new System.Boolean AllowDrop
		{
			get { return base.AllowDrop; }
			set { base.AllowDrop = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.AnchorStyles Anchor
		{
			get { return base.Anchor; }
			set { base.Anchor = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Point AutoScrollOffset
		{
			get { return base.AutoScrollOffset; }
			set { base.AutoScrollOffset = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Image BackgroundImage
		{
			get { return base.BackgroundImage; }
			set { base.BackgroundImage = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.ImageLayout BackgroundImageLayout
		{
			get { return base.BackgroundImageLayout; }
			set { base.BackgroundImageLayout = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.BindingContext BindingContext
		{
			get { return base.BindingContext; }
			set { base.BindingContext = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Rectangle Bounds
		{
			get { return base.Bounds; }
			set { base.Bounds = value; }
		}
		[Browsable(false)]
		public new System.Boolean Capture
		{
			get { return base.Capture; }
			set { base.Capture = value; }
		}
		[Browsable(false)]
		public new System.Boolean CausesValidation
		{
			get { return base.CausesValidation; }
			set { base.CausesValidation = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Size ClientSize
		{
			get { return base.ClientSize; }
			set { base.ClientSize = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.ContextMenu ContextMenu
		{
			get { return base.ContextMenu; }
			set { base.ContextMenu = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.ContextMenuStrip ContextMenuStrip
		{
			get { return base.ContextMenuStrip; }
			set { base.ContextMenuStrip = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.Cursor Cursor
		{
			get { return base.Cursor; }
			set { base.Cursor = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.DockStyle Dock
		{
			get { return base.Dock; }
			set { base.Dock = value; }
		}
		[Browsable(false)]
		public new System.Boolean Enabled
		{
			get { return base.Enabled; }
			set { base.Enabled = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Font Font
		{
			get { return base.Font; }
			set { base.Font = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Color ForeColor
		{
			get { return base.ForeColor; }
			set { base.ForeColor = value; }
		}
		[Browsable(false)]
		public new System.Int32 Height
		{
			get { return base.Height; }
			set { base.Height = value; }
		}
		[Browsable(false)]
		public new System.Boolean IsAccessible
		{
			get { return base.IsAccessible; }
			set { base.IsAccessible = value; }
		}
		[Browsable(false)]
		public new System.Int32 Left
		{
			get { return base.Left; }
			set { base.Left = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Point Location
		{
			get { return base.Location; }
			set { base.Location = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.Padding Margin
		{
			get { return base.Margin; }
			set { base.Margin = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Size MaximumSize
		{
			get { return base.MaximumSize; }
			set { base.MaximumSize = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Size MinimumSize
		{
			get { return base.MinimumSize; }
			set { base.MinimumSize = value; }
		}
		[Browsable(false)]
		public new System.String Name
		{
			get { return base.Name; }
			set { base.Name = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.Control Parent
		{
			get { return base.Parent; }
			set { base.Parent = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Region Region
		{
			get { return base.Region; }
			set { base.Region = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.RightToLeft RightToLeft
		{
			get { return base.RightToLeft; }
			set { base.RightToLeft = value; }
		}
		[Browsable(false)]
		public new System.ComponentModel.ISite Site
		{
			get { return base.Site; }
			set { base.Site = value; }
		}
		[Browsable(false)]
		public new System.Drawing.Size Size
		{
			get { return base.Size; }
			set { base.Size = value; }
		}
		[Browsable(false)]
		public new System.Int32 TabIndex
		{
			get { return base.TabIndex; }
			set { base.TabIndex = value; }
		}
		/*
		[Browsable(false)]
		public new System.Boolean TabStop
		{
			get { return base.TabStop; }
			set { base.TabStop = value; }
		}
		*/
		[Browsable(false)]
		public new System.Object Tag
		{
			get { return base.Tag; }
			set { base.Tag = value; }
		}
		[Browsable(false)]
		public new System.Int32 Top
		{
			get { return base.Top; }
			set { base.Top = value; }
		}
		[Browsable(false)]
		public new System.Boolean UseWaitCursor
		{
			get { return base.UseWaitCursor; }
			set { base.UseWaitCursor = value; }
		}
		[Browsable(false)]
		public new System.Boolean Visible
		{
			get { return base.Visible; }
			set { base.Visible = value; }
		}
		[Browsable(false)]
		public new System.Int32 Width
		{
			get { return base.Width; }
			set { base.Width = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.IWindowTarget WindowTarget
		{
			get { return base.WindowTarget; }
			set { base.WindowTarget = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.Padding Padding
		{
			get { return base.Padding; }
			set { base.Padding = value; }
		}

	}
}
