using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace AE_Dialog_Mk
{
	public partial class A_Form : Form
	{
		private ContextMenuStrip cm = new ContextMenuStrip();
		private ToolStripMenuItem saveAsMenu = new ToolStripMenuItem();
		private ToolStripMenuItem showCodeMenu = new ToolStripMenuItem();


		private windowType _windowType = windowType.dialog;
		private bool _resizeable = false;
		private bool _center = true;

		public const string objNameDef = "winObj";
		private string _objName = objNameDef; 
		public A_Form()
		{
			base.AutoSize = false;
			InitializeComponent();
			//メニューを追加
			showCodeMenu.Text = "ダイアログに表示";
			showCodeMenu.Click += new EventHandler(showCodeMenu_Click);

			cm.Items.Add(showCodeMenu);
			this.ContextMenuStrip = cm;
			if (_center == true)
			{
				this.StartPosition = FormStartPosition.CenterScreen;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		private void showCodeMenu_Click(object sender, EventArgs e)
		{
			CodeDisp dlg = new CodeDisp();
			dlg.Code = GetScriptCode();
			dlg.ShowDialog();
		}

		//------------------------------------------------------------------------------------------------------------
		public string GetScriptCode()
		{
			string ret = "";

			string wt = "";
			switch (_windowType)
			{
				case windowType.floatingPalette:
				case windowType.paletet:
					wt = "palette";
					break;
				case windowType.dialog:
					wt = "dialog";
					break;
				case windowType.window:
					wt = "window";
					break;
			}

			string lines = Utils.GetControlsScriptCode(this);
			if (lines != "")
			{
				lines =  lines.Replace("\r\n", "\r\n\t");
			}
			string op = "";
			if (AE_resizeable)
			{
				op += "resizeable:true";
			}
			if (AE_maximizeButton)
			{
				if (op != "") op += ",";
				op += "maximizeButton:true";
			}
			if (AE_minimizeButton)
			{
				if (op != "") op += ",";
				op += "minimizeButton:true";
			}
			if (op != "") op = ",{" + op + "}";

			string ic = "";
			if (AE_isCenter)
			{
				ic = $"{AE_objName}.center();";
			}
			ret = $"(function(){{\r\n";
			if (_windowType == windowType.floatingPalette)
			{
				ret += $"\tvar {AE_objName} = ( me instanceof Panel) ? me : new Window(\"palette\", \"{AE_title}\", {Utils.GetBoundStr(this)}  ,{{resizeable:true}});\r\n";

			}
			else
			{
				ret += $"\tvar {AE_objName} = new Window(\"{wt}\",\"{AE_title}\" ,{Utils.GetBoundStr(this)} {op});\r\n";
			}
			ret += $"\t{lines}\r\n";
			if (_windowType == windowType.floatingPalette)
			{
				ret += $"\tif ({AE_objName} instanceof Panel ) {{\r\n";
				ret += $"\t\t{AE_objName}.center();\r\n";
				ret += $"\t\t{AE_objName}.show();\r\n";
				ret += "\t}\r\n";
			}
			else
			{
				ret += $"\t{ic}\r\n" +
				$"\t{AE_objName}.show();\r\n";
			}
			ret += "})();\r\n";

			return ret;


		}
		// **************************************************************************************
		// **************************************************************************************
		#region PronAE
		//------------------------------------------------------------------------------------------------------------
		[Category("AE"), Browsable(true)]
		public string AE_title
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;

			}
		}


		//------------------------------------------------------------------------------------------------------------
		[Category("AE"), Browsable(true)]
		public bool AE_isCenter
		{
			get
			{
				_center = (this.StartPosition == FormStartPosition.CenterScreen);
				return _center;
			}
			set
			{
				_center = value;
				if (_center == true)
				{
					this.StartPosition = FormStartPosition.CenterScreen;
				}
				else
				{
					this.StartPosition = FormStartPosition.WindowsDefaultLocation;
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE"), Browsable(true)]
		public string AE_objName
		{
			get { return _objName; }
			set { _objName = value; }
		}

		//------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// windowTypeの指定
		/// </summary>
		[Category("AE"), Browsable(true)]
		public windowType AE_windowType
		{
			get { return _windowType; }
			set
			{
				_windowType = value;
				switch (_windowType)
				{
					case windowType.dialog:
					case windowType.window:
						if (_resizeable)
						{
							this.FormBorderStyle = FormBorderStyle.Sizable;
						}
						else
						{
							this.FormBorderStyle = FormBorderStyle.FixedDialog;
						}
						break;
					case windowType.paletet:
					case windowType.floatingPalette:
						if (_resizeable)
						{
							this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
						}
						else
						{
							this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
						}
						break;
				}

			}
		}
		//------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// リサイズ可能にする
		/// </summary>
		[Category("AE"), Browsable(true)]
		public bool AE_resizeable
		{
			get { return _resizeable; }
			set
			{
				_resizeable = value;
				if (_resizeable)
				{
					if ((_windowType == windowType.dialog) || (_windowType == windowType.window))
					{
						this.FormBorderStyle = FormBorderStyle.Sizable;
					}
					else
					{
						this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
					}
				}
				else
				{
					if ((_windowType == windowType.dialog) || (_windowType == windowType.window))
					{
						this.FormBorderStyle = FormBorderStyle.FixedDialog;
					}
					else
					{
						this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
					}
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// 最大化ボタンを表示する
		/// </summary>
		[Category("AE"), Browsable(true)]
		public bool AE_maximizeButton
		{
			get
			{
				return base.MaximizeBox;
			}
			set
			{
				base.MaximizeBox = value;
			}

		}
		//------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// 最小化ボタンを表示する
		/// </summary>
		[Category("AE"), Browsable(true)]
		public bool AE_minimizeButton
		{
			get
			{
				return base.MinimizeBox;
			}
			set
			{
				base.MinimizeBox = value;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		[Category("AE"), Browsable(true)]
		public int[] AE_bounds
		{
			get
			{
				return Utils.ToBounds(this);
			}
			set
			{
				Utils.FromBounds(value, this);
			}
		}
		#endregion
		// **************************************************************************************
		#region Prop
		// **************************************************************
		// **************************************************************
		[Browsable(false)]
		public new bool DoubleBuffered
		{
			get { return base.DoubleBuffered; }
			set { base.DoubleBuffered = value; }
		}
		[Browsable(false)]
		public new System.Windows.Forms.IButtonControl? AcceptButton
		{
			get { return base.AcceptButton; }
			set { base.AcceptButton = value; }
		}
		[Browsable(false)]
		public new System.Boolean AllowTransparency
		{
			get { return base.AllowTransparency; }
			set { base.AllowTransparency = value; }
		}
		// **************************************************************
		/*
		[Browsable(false)]
		public new System.Boolean AutoScale
		{
			get { return base.AutoScale; }
			set { base.AutoScale = value; }
		}
		*/
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Size AutoScaleBaseSize
		{
			get { return base.AutoScaleBaseSize; }
			set { base.AutoScaleBaseSize = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean AutoScroll
		{
			get { return base.AutoScroll; }
			set { base.AutoScroll = value; }
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
		public new System.Windows.Forms.AutoValidate AutoValidate
		{
			get { return base.AutoValidate; }
			set { base.AutoValidate = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.FormBorderStyle FormBorderStyle
		{
			get { return base.FormBorderStyle; }
			set { base.FormBorderStyle = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.IButtonControl? CancelButton
		{
			get { return base.CancelButton; }
			set { base.CancelButton = value; }
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
		public new System.Boolean ControlBox
		{
			get { return base.ControlBox; }
			set { base.ControlBox = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Rectangle DesktopBounds
		{
			get { return base.DesktopBounds; }
			set { base.DesktopBounds = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Point DesktopLocation
		{
			get { return base.DesktopLocation; }
			set { base.DesktopLocation = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.DialogResult DialogResult
		{
			get { return base.DialogResult; }
			set { base.DialogResult = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean HelpButton
		{
			get { return base.HelpButton; }
			set { base.HelpButton = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Icon? Icon
		{
			get { return base.Icon; }
			set { base.Icon = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean IsMdiContainer
		{
			get { return base.IsMdiContainer; }
			set { base.IsMdiContainer = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean KeyPreview
		{
			get { return base.KeyPreview; }
			set { base.KeyPreview = value; }
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
		public new System.Windows.Forms.MenuStrip? MainMenuStrip
		{
			get { return base.MainMenuStrip; }
			set { base.MainMenuStrip = value; }
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
		public new System.Boolean MaximizeBox
		{
			get { return base.MaximizeBox; }
			set { base.MaximizeBox = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean MdiChildrenMinimizedAnchorBottom
		{
			get { return base.MdiChildrenMinimizedAnchorBottom; }
			set { base.MdiChildrenMinimizedAnchorBottom = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.Form? MdiParent
		{
			get { return base.MdiParent; }
			set { base.MdiParent = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean MinimizeBox
		{
			get { return base.MinimizeBox; }
			set { base.MinimizeBox = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Double Opacity
		{
			get { return base.Opacity; }
			set { base.Opacity = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.Form? Owner
		{
			get { return base.Owner; }
			set { base.Owner = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean RightToLeftLayout
		{
			get { return base.RightToLeftLayout; }
			set { base.RightToLeftLayout = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean ShowInTaskbar
		{
			get { return base.ShowInTaskbar; }
			set { base.ShowInTaskbar = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean ShowIcon
		{
			get { return base.ShowIcon; }
			set { base.ShowIcon = value; }
		}
		// **************************************************************
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.SizeGripStyle SizeGripStyle
		{
			get { return base.SizeGripStyle; }
			set { base.SizeGripStyle = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.FormStartPosition StartPosition
		{
			get { return base.StartPosition; }
			set { base.StartPosition = value; }
		}
		// **************************************************************
		/*
		[Browsable(false)]
		public new System.Int32 TabIndex
		{
			get { return base.TabIndex; }
			set { base.TabIndex = value; }
		}
		*/
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
		public new System.Boolean TopLevel
		{
			get { return base.TopLevel; }
			set { base.TopLevel = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Boolean TopMost
		{
			get { return base.TopMost; }
			set { base.TopMost = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Color TransparencyKey
		{
			get { return base.TransparencyKey; }
			set { base.TransparencyKey = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.FormWindowState WindowState
		{
			get { return base.WindowState; }
			set { base.WindowState = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.SizeF AutoScaleDimensions
		{
			get { return base.AutoScaleDimensions; }
			set { base.AutoScaleDimensions = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.AutoScaleMode AutoScaleMode
		{
			get { return base.AutoScaleMode; }
			set { base.AutoScaleMode = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.BindingContext? BindingContext
		{
			get { return base.BindingContext; }
			set { base.BindingContext = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.Control? ActiveControl
		{
			get { return base.ActiveControl; }
			set { base.ActiveControl = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Size AutoScrollMargin
		{
			get { return base.AutoScrollMargin; }
			set { base.AutoScrollMargin = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Point AutoScrollPosition
		{
			get { return base.AutoScrollPosition; }
			set { base.AutoScrollPosition = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Size AutoScrollMinSize
		{
			get { return base.AutoScrollMinSize; }
			set { base.AutoScrollMinSize = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String? AccessibleDefaultActionDescription
		{
			get { return base.AccessibleDefaultActionDescription; }
			set { base.AccessibleDefaultActionDescription = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String? AccessibleDescription
		{
			get { return base.AccessibleDescription; }
			set { base.AccessibleDescription = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.String? AccessibleName
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
		public new System.Object? DataContext
		{
			get { return base.DataContext; }
			set { base.DataContext = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Image? BackgroundImage
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
		public new System.Windows.Forms.ContextMenuStrip? ContextMenuStrip
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
		[Browsable(false)]
		public new System.String Name
		{
			get { return base.Name; }
			set { base.Name = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Windows.Forms.Control? Parent
		{
			get { return base.Parent; }
			set { base.Parent = value; }
		}
		// **************************************************************
		[Browsable(false)]
		public new System.Drawing.Region? Region
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
		public new System.ComponentModel.ISite? Site
		{
			get { return base.Site; }
			set { base.Site = value; }
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
	}

}
