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
	public class A_panel : GroupBox
	{
		private string _objName = "";
		private string _textItemName = "";
		private borderStyle _borderStyle = borderStyle.etched;
		//------------------------------------------------------------------------------------------------------------
		public A_panel()
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
		public string AE_textItemName
		{
			get
			{
				if (_textItemName == string.Empty)
				{
					_textItemName = AE_objName + "_item";
				}
				return _textItemName;
			}
			set { _textItemName = value.Trim(); }
		}
		//------------------------------------------------------------------------------------------------------------
		//------------------------------------------------------------------------------------------------------------
		public string AE_text
		{
			get { return this.Text; }
			set { this.Text = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public borderStyle AE_borderStyle
		{
			get { return _borderStyle; }
			set { _borderStyle = value; this.Invalidate(); }
		}
		//------------------------------------------------------------------------------------------------------------
		public int[] AE_bounds
		{
			get { return Utils.ToBounds(this); }
			set { Utils.FromBounds(value, this); }
		}
		//------------------------------------------------------------------------------------------------------------
		public string BoundStr
		{
			get { return Utils.GetBoundStr(this); }
		}
		//------------------------------------------------------------------------------------------------------------
		public string GetScriptCode()
		{
			string ret = "";
			ret = $"var {AE_objName} = {Utils.GetWinObjName(this)}.add(\"panel\", {BoundStr});\r\n";
			ret += Utils.GetControlsScriptCode(this);
			return ret;
		}
		//------------------------------------------------------------------------------------------------------------
		protected override void OnPaint(PaintEventArgs e)
		{

			if (_borderStyle == borderStyle.etched)
			{
				base.OnPaint(e);
			}
			else
			{
				Graphics g = e.Graphics;
				SolidBrush sb = new SolidBrush(this.BackColor);

				try
				{
					SizeF sz = g.MeasureString(this.Text, this.Font);
					int hh = (int)(sz.Height / 2);
					Rectangle rr = this.ClientRectangle;
					Rectangle r = new Rectangle(rr.Left, rr.Top + hh, rr.Width, rr.Height - hh);
					Border3DStyle bs = Border3DStyle.Etched;
					Pen p;
					Rectangle r2;
					switch (_borderStyle)
					{
						case borderStyle.black:
							p = new Pen(Color.Black);
							r2 = new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);
							g.DrawRectangle(p, r2);
							p.Dispose();
							break;
						case borderStyle.gray:
							p = new Pen(Color.Gray);
							r2 = new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);
							g.DrawRectangle(p, r2);
							p.Dispose();
							break;
						case borderStyle.raised:
							bs = Border3DStyle.Raised;
							ControlPaint.DrawBorder3D(g, r, bs);
							break;
						case borderStyle.sunken:
							bs = Border3DStyle.Sunken;
							ControlPaint.DrawBorder3D(g, r, bs);
							break;
					}

					sb.Color = this.BackColor;
					g.FillRectangle(sb, new RectangleF(9f, 0, sz.Width, sz.Height));
					sb.Color = this.ForeColor;
					g.DrawString(this.Text, this.Font, sb, new PointF(9f, 0));
				}
				finally
				{
					sb.Dispose();
				}
			}

		}
		// ***************************************************************************************
		// ***************************************************************************************
		#region
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AllowDrop
		{
			get { return base.AllowDrop; }
			set { base.AllowDrop = value; }
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
		public new System.Windows.Forms.AutoSizeMode AutoSizeMode
		{
			get { return base.AutoSizeMode; }
			set { base.AutoSizeMode = value; }
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
		public new System.Boolean TabStop
		{
			get { return base.TabStop; }
			set { base.TabStop = value; }
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
		public new System.Boolean UseCompatibleTextRendering
		{
			get { return base.UseCompatibleTextRendering; }
			set { base.UseCompatibleTextRendering = value; }
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

		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.ImeMode ImeMode
		{
			get { return base.ImeMode; }
			set { base.ImeMode = value; }
		}

		#endregion
		// ***************************************************************************************
		// ***************************************************************************************


	}
}
