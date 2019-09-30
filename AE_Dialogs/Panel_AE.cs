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
	public class Panel_AE : GroupBox
	{
		private bool _IsLocal = false;
		private string _objName = "";
		private string _textObjName = "";
		private borderStyle _borderStyle = borderStyle.etched;
		//------------------------------------------------------------------------------------------------------------
		public Panel_AE()
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
		public string AE_textObjName
		{
			get { return _textObjName; }
			set { _textObjName = value.Trim(); }
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_isLocal
		{
			get { return _IsLocal; }
			set { _IsLocal = value; }
		}
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
		public string BoundStr
		{
			get { return Utils.GetBoundStr(this); }
		}
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
							r2 = new Rectangle(r.Left, r.Top, r.Width-1, r.Height - 1);
							g.DrawRectangle(p, r2);
							p.Dispose();
							break;
						case borderStyle.gray:
							p = new Pen(Color.Gray);
							r2 = new Rectangle(r.Left, r.Top, r.Width-1, r.Height - 1);
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
			//

		}
	}
}
