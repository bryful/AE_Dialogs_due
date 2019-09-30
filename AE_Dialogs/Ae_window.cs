using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace bryful_due
{
	public class Ae_window : Component
	{
		private Form _Form;
        private ContextMenuStrip cm = new ContextMenuStrip();
        private ToolStripMenuItem saveAsMenu = new ToolStripMenuItem();
        private ToolStripMenuItem showCodeMenu = new ToolStripMenuItem();

		private List<string> dataLines = new List<string>();

		private List<string> lines = new List<string>();
		private List<Bitmap> images = new List<Bitmap>();
		private List<string> imagesPath = new List<string>();

		private string _Result = "";

		private windowType _windowType = windowType.dialog;
		private bool _IsLocal = true;
		private bool _resizeable = false;
		private bool _center = true;

		public const string objNameDef = "winObj";
		private string _objName = objNameDef;

		private string _funcName = "myDialog";

		private bool _isInFunc = true;
		private bool _isExportPict = true;
        //------------------------------------------------------------------------------------------------------------
		public Ae_window()
        {
			//メニューを追加
            saveAsMenu.Text = "テキストへ保存";
            saveAsMenu.Click += new EventHandler(saveAsMenu_Click);
            showCodeMenu.Text = "ダイアログに表示";
            showCodeMenu.Click += new EventHandler(showCodeMenu_Click);

			cm.Items.Add(saveAsMenu);
            cm.Items.Add(showCodeMenu);

        }
		//------------------------------------------------------------------------------------------------------------
        private void showCodeMenu_Click(object sender, EventArgs e)
        {
            Listup();
			CodeDisp dlg = new CodeDisp();
			dlg.Code = _Result;
			dlg.ShowDialog();
        }
        //------------------------------------------------------------------------------------------------------------
        private void saveAsMenu_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
        //------------------------------------------------------------------------------------------------------------
        public Form AE_Form
        {
            get { return _Form; }
            set
            {
                _Form = value;
                if (_Form != null)
                {
                    _Form.ContextMenuStrip = cm;
					if (_center == true)
					{
						_Form.StartPosition = FormStartPosition.CenterScreen;
					}
                }
            }
        }
		//------------------------------------------------------------------------------------------------------------
		public string AE_funcName
		{
			get
			{
				return _funcName;
			}
			set
			{
				_funcName = value;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_title
		{
			get
			{
				if (_Form != null)
				{
					return _Form.Text;
				}
				else
				{
					return "";
				}
			}
			set
			{
				if (_Form != null)
				{
					_Form.Text = value;
				}

			}
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_isLocal
		{
			get
			{
				if (_isInFunc == false) return true;
				return _IsLocal;
			}
			set { _IsLocal = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_isInFunc
		{
			get{return _isInFunc;}
			set { _isInFunc = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_isExportPict
		{
			get{return _isExportPict;}
			set { _isInFunc = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		public bool AE_isCenter
		{
			get
			{
				if (_Form == null)
				{
					return _center;
				}
				else
				{
					_center = (_Form.StartPosition == FormStartPosition.CenterScreen);
					return _center;
				}
			}
			set 
			{
				_center = value;
				if (_Form != null)
				{
					if (_center == true)
					{
						_Form.StartPosition = FormStartPosition.CenterScreen;
					}
					else
					{
						_Form.StartPosition = FormStartPosition.WindowsDefaultLocation;
					}
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_objName
		{
			get { return _objName; }
			set { _objName = value; }
		}

		//------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// windowTypeの指定
		/// </summary>
		public windowType AE_windowType
		{
			get 
			{
				if (_Form != null)
				{
					switch (_Form.FormBorderStyle)
					{
						case FormBorderStyle.Fixed3D:
						case FormBorderStyle.FixedDialog:
						case FormBorderStyle.FixedSingle:
						case FormBorderStyle.None:
						case FormBorderStyle.Sizable:
							_Form.FormBorderStyle = FormBorderStyle.Sizable;
							if ((_windowType == windowType.floatingPalette) || (_windowType == windowType.paletet))
							{
								if (_Form.ShowIcon == true)
								{
									_windowType = windowType.window;
								}
								else
								{
									_windowType = windowType.dialog;
								}
							}
							break;
						case FormBorderStyle.FixedToolWindow:
						case FormBorderStyle.SizableToolWindow:
							_Form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
							if ((_windowType == windowType.dialog) || (_windowType == windowType.window))
							{
								_windowType = windowType.paletet;
							}
							break;
					}
				}
				return _windowType;
			}
			set 
			{ 
				_windowType = value;
				if (_Form != null)
				{
					switch (_windowType)
					{
						case windowType.paletet:
						case windowType.floatingPalette:
							_Form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
							break;
						case windowType.window:
							_Form.FormBorderStyle = FormBorderStyle.Sizable;
							_Form.ShowIcon = true;
							break;
						case windowType.dialog:
						default:
							_Form.FormBorderStyle = FormBorderStyle.Sizable;
							_Form.ShowIcon = false;
							break;

					}
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// リサイズ可能にする
		/// </summary>
		public bool AE_resizeable
		{
			get { return _resizeable; }
			set { _resizeable = value; }
		}
		//------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// 最大化ボタンを表示する
		/// </summary>
		public bool AE_maximizeButton
		{
			get
			{
				if (_Form == null)
				{
					return false;
				}
				else
				{
					return _Form.MaximizeBox;
				}
			}
			set
			{
				if (_Form != null)
				{
					_Form.MaximizeBox = value;
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// 最小化ボタンを表示する
		/// </summary>
		public bool AE_minimizeButton
		{
			get {
				if (_Form == null)
				{
					return false;
				}
				else
				{
					return _Form.MinimizeBox;
				}
			}
			set 
			{
				if (_Form != null)
				{
					_Form.MinimizeBox = value;
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public Size AE_size
		{
			get
			{
				if (_Form == null)
				{
					return new Size(0, 0);
				}
				else
				{
					return _Form.ClientSize;
				}
			}
			set
			{
				if (_Form != null)
				{
					_Form.ClientSize = value;
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		private string getFontStr(Font fnt)
		{
			string ret = "";
			//Tahoma, 8.25pt
			//if ((fnt.Name == "Tahoma") && (fnt.Size == 8.25f) && (fnt.Bold == false) && (fnt.Italic == false)) return ret;

			ret = "ScriptUI.newFont(";
			ret += "\""+fnt.FontFamily.Name+"\",";

			if ((fnt.Bold==false)&&(fnt.Italic==false))
			{
				ret += "ScriptUI.FontStyle.REGULAR";
			}
			else if ((fnt.Bold==true)&&(fnt.Italic==false))
			{
				ret += "ScriptUI.FontStyle.BOLD";

			}
			else if ((fnt.Bold==false)&&(fnt.Italic==true))
			{
				ret += "ScriptUI.FontStyle.ITALIC";

			}
			else if ((fnt.Bold==true)&&(fnt.Italic==true))
			{
				ret += "ScriptUI.FontStyle.BOLDITALIC";

			}
			ret += ", ";

			ret += (fnt.Size*11/8.25).ToString();
			ret += ");";
			return ret;
		}
		//------------------------------------------------------------------------------------------------------------
        private void AddButton(string parentName, Button_AE item)
        {
			//	this.btnOK = this.winObj.add("button", [641, 435, 641+109, 435+35], "実行", {name:'ok'});
			
			string based = "$VAR$NAME = $PARENT.add(\"button\", $RECT, $TEXT $OP);";

			string head = "";
			if ((item.AE_isLocal == true)||(this.AE_isInFunc ==false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);

			based = based.Replace("$PARENT", parentName);

			based = based.Replace("$RECT", item.BoundStr);

			if (item.AE_textObjName == "")
			{
				based = based.Replace("$TEXT", "\"" + item.Text + "\"");
			}
			else
			{
				dataLines.Add("var " + item.AE_textObjName + " = \""+ item.Text + "\";");
				based = based.Replace("$TEXT", item.AE_textObjName);
			}

			string op = "";
			if (item.AE_defaultElement == defaultElement.ok)
			{
				op = "name:\"ok\"";
			}
			else if (item.AE_defaultElement == defaultElement.cancel)
			{
				op = "name:\"cancel\"";
			}
			if (op != "")
			{
				op = ", { " + op + " }";
			}
			based = based.Replace("$OP", op);
			lines.Add(based);

			string s = getFontStr(item.Font);
			if (s != "")
			{
				if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
				lines.Add(head + item.AE_objName + ".graphics.font = " + s);
			}

        }
		//------------------------------------------------------------------------------------------------------------
		private void AddCheckBox(string parentName, Checkbox_AE item)
		{
			//	this.checkBox3 = this.winObj.add("checkbox", [136, 97, 136+80, 97+16], "checkBox3" );
			string based = "$VAR$NAME = $PARENT.add(\"checkbox\", $RECT, $TEXT);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);

			based = based.Replace("$PARENT", parentName);

			based = based.Replace("$RECT", item.BoundStr);
			if (item.AE_textObjName == "")
			{
				based = based.Replace("$TEXT", "\"" + item.Text + "\"");
			}
			else
			{
				dataLines.Add("var " + item.AE_textObjName + " = \"" + item.Text + "\";");
				based = based.Replace("$TEXT", item.AE_textObjName);
			}
			lines.Add(based);

			if (item.Checked == true)
			{
				string based2 = "$VAR$NAME.value = true;";
				if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
				based2 = based2.Replace("$VAR", head);
				based2 = based2.Replace("$NAME", item.AE_objName);

				lines.Add(based2);
			}

			string s = getFontStr(item.Font);
			if (s != "")
			{
				if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
				lines.Add(head + item.AE_objName + ".graphics.font = " + s);
			}
		}
		//------------------------------------------------------------------------------------------------------------
		private void AddDropdownlist(string parentName, Dropdownlist_AE item)
		{
			//	this.comboBox1 = this.winObj.add("dropdownlist", [300, 43, 300+121, 43+20], ["a","b","c","d","f" ] );

			string based = "$VAR$NAME = $PARENT.add(\"dropdownlist\", $RECT, $LIST);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);
			based = based.Replace("$PARENT", parentName);
			based = based.Replace("$RECT", item.BoundStr);

			string s = "[";
			if (item.Items.Count > 0)
			{
				for (int i = 0; i < item.Items.Count; i++)
				{
					s += "\"" + item.Items[i].ToString() + "\"";
					if (i < item.Items.Count - 1) s += ",";
				}
			}
			s += " ]";

			if (item.AE_itemsName == "")
			{
				based = based.Replace("$LIST", s);
			}
			else
			{
				dataLines.Add("var " + item.AE_itemsName + " = " + s + ";");
				based = based.Replace("$LIST", item.AE_itemsName);
			}

			lines.Add(based);
			if (item.AE_index >= 0)
			{
				string ss = "$VAR$NAME.items[$INDEX].selected = true;";

				if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
				ss = ss.Replace("$VAR", head);
				ss = ss.Replace("$NAME", item.AE_objName);
				ss = ss.Replace("$INDEX", item.AE_index.ToString());

				lines.Add(ss);
			}

			s = getFontStr(item.Font);
			if (s != "")
			{
				if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
				lines.Add(head + item.Name + ".graphics.font = " + s);
			}
		}
		//------------------------------------------------------------------------------------------------------------
		private void AddEdittext(string parentName, Edittext_AE item)
		{
			//	this.textBox1 = this.winObj.add("edittext", [14, 367, 14+100, 367+19], "" );

			string based = "$VAR$NAME = $PARENT.add(\"edittext\", $RECT, $TEXT$OP);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);

			based = based.Replace("$PARENT", parentName);

			based = based.Replace("$RECT", item.BoundStr);


			if (item.AE_textObjName == "")
			{
				based = based.Replace("$TEXT", "\"" + item.AE_textLine() + "\"");
			}
			else
			{
				dataLines.Add("var " + item.AE_textObjName + " = \"" + item.AE_textLine() + "\";");
				based = based.Replace("$TEXT", item.AE_textObjName);
			}

			string op = "";
			if (item.AE_readonly == true)
			{
				if (op != "") op += ", ";
				op += "readonly:true";
			}
			if (item.AE_noecho == true)
			{
				if (op != "") op += ", ";
				op += "noecho:true";
			}
			if (item.AE_borderless == true)
			{
				if (op != "") op += ", ";
				op += "borderless:true";
			}

			if (item.AE_multiline == true)
			{
				if (op != "") op += ", ";
				op += "multiline:true";
				if (item.AE_scrollable == true)
				{
					op += ", scrollable:true";
				}
			}
			if (op != "")
			{
				op = ", { " + op + " }";
			}
			based = based.Replace("$OP", op);


			lines.Add(based);

			string s = getFontStr(item.Font);
			if (s != "")
			{
				if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
				lines.Add(head + item.AE_objName + ".graphics.font = " + s);
			}
		}
		//------------------------------------------------------------------------------------------------------------
		private void AddGroup(string parentName, Group_AE item)
		{
			//	this.groupBox1 = this.winObj.add("group", [136, 238, 136+200, 238+100], "groupBox1" );
			string based = "$VAR$NAME = $PARENT.add(\"group\", $RECT);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);
			based = based.Replace("$PARENT", parentName);
			based = based.Replace("$RECT", item.BoundStr);

			lines.Add(based);

 
		}
		//------------------------------------------------------------------------------------------------------------
		private void AddIconbutton(string parentName, bryful_due.Iconbutton_AE item)
		{
			//     this.pictureBox1 = this.winObj.add("image", [364, 278, 364+136, 278+83],new File("./適当な画像ファイル.png") );
			//     $VAR$NAME = $PARENT.add(\"image\", $RECT,new File(\"&IMAGENAME\") );

			string based = "$VAR$NAME = $PARENT.add(\"iconbutton\", $RECT $IMG);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);
			based = based.Replace("$PARENT", parentName);
			based = based.Replace("$RECT", item.BoundStr);


			//画像の処理
			if (item.Image != null)
			{
				based = based.Replace("$IMG", ", " + item.AE_imageObjName);

				if (_isExportPict == true)
				{
					Bitmap b = new Bitmap(item.Image.Width, item.Image.Height, item.Image.PixelFormat);
					b.SetResolution(item.Image.HorizontalResolution, item.Image.VerticalResolution);
					Graphics g = Graphics.FromImage(b);
					g.DrawImage(item.Image, 0, 0);
					images.Add(b);
					imagesPath.Add(item.AE_imageFullPath);
					dataLines.Add("var " + item.AE_imageObjName + " = new File(\"" + item.AE_imageFullPath + "\");");
				}
				else
				{
					dataLines.Add("var " + item.AE_imageObjName + " = new File(\"\");"); 
				}
			}
			else
			{
				based = based.Replace("$IMG", "/*," +item.AE_imageObjName +"*/");
				dataLines.Add("//var " + item.AE_imageObjName + " = new File(\"\");"); 
			}
			lines.Add(based);
 
		}

		//------------------------------------------------------------------------------------------------------------
		private void AddImage(string parentName, Image_AE item)
		{
			//	/* var pictureBox1_image = new File("./適当な画像ファイル.png"); */
			//     this.pictureBox1 = this.winObj.add("image", [364, 278, 364+136, 278+83]/*  ,pictureBox1_image*/ );
			//     this.pictureBox1 = this.winObj.add("image", [364, 278, 364+136, 278+83],new File("./適当な画像ファイル.png") );
			//     $VAR$NAME = $PARENT.add(\"image\", $RECT,$IMG );

			string based = "$VAR$NAME = $PARENT.add(\"image\", $RECT $IMG );";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.Name);
			based = based.Replace("$PARENT", parentName);
			based = based.Replace("$RECT", item.BoundStr);

			//画像の処理
			if (item.Image != null)
			{
				based = based.Replace("$IMG", ", " + item.AE_imageObjName);

				if (_isExportPict == true)
				{
					Bitmap b = new Bitmap(item.Image.Width, item.Image.Height, item.Image.PixelFormat);
					b.SetResolution(item.Image.HorizontalResolution, item.Image.VerticalResolution);
					Graphics g = Graphics.FromImage(b);
					g.DrawImage(item.Image, 0, 0);
					images.Add(b);
					imagesPath.Add(item.AE_imageFullPath);

					dataLines.Add("var " + item.AE_imageObjName + " = new File(\"" + item.AE_imageFullPath + "\");");
				}
				else
				{
					based = based.Replace("$IMG", "/*," + item.AE_imageObjName + "*/");
					dataLines.Add("//var " + item.AE_imageObjName + " = new File(\"\");");
				}
			}
			else
			{
				based = based.Replace("$IMG", "/*, " + item.AE_imageObjName + "*/");
				dataLines.Add("//var " + item.AE_imageObjName + " = new File(\"\");");
			}
			lines.Add(based);
		}
		//------------------------------------------------------------------------------------------------------------
		private void AddListbox(string parentName, Listbox_AE item)
		{
			//	this.listBox1 = this.winObj.add("listbox", [364, 93, 364+136, 93+112], ["１２３","４５６","７８９" ] );

			string based = "$VAR$NAME = $PARENT.add(\"listbox\", $RECT, $LIST $OP);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);
			based = based.Replace("$PARENT", parentName);
			based = based.Replace("$RECT", item.BoundStr);

			string s = "[";
			if (item.Items.Count > 0)
			{
				for (int i = 0; i < item.Items.Count; i++)
				{
					s += "\"" + item.Items[i].ToString() + "\"";
					if (i < item.Items.Count - 1) s += ",";
				}
			}
			else
			{
				s += " ";
			}
			s += " ]";

			if (item.AE_itemsName != "")
			{
				based = based.Replace("$LIST", item.AE_itemsName);
				dataLines.Add("var " + item.AE_itemsName + " = " + s + ";");
			}
			else
			{
				based = based.Replace("$LIST", s);
			}

			string op = "";
			if (item.AE_multiselect == true)
			{
				if ( op != "") op += ", ";
				op += "multiselect:true";
			}
			if (item.AE_showHeaders == true)
			{
				if (op != "") op += ", ";
				op += "showHeaders:true";
			}
			if (item.AE_numberOfColumns > 1)
			{
				if (op != "") op += ", ";
				op += "numberOfColumns:" + item.AE_numberOfColumns.ToString();
			}
			if (item.AE_columnWidths.Length > 1)
			{
				if (op != "") op += ", ";
				string cw = "[";
				for (int i = 0; i < item.AE_columnWidths.Length; i++)
				{
					cw += item.AE_columnWidths[i].ToString();
					if (i < item.AE_columnWidths.Length - 1) cw += ", ";
				}
				cw += "]";
				string nm = item.AE_objName +"_widths";
				dataLines.Add("var "+  nm +  " = " + cw +";");
				op += "columnWidths:"+nm;
			}
			if ((item.AE_columnTitles.Length > 0)&&(item.AE_showHeaders))
			{
				if (op != "") op += ", ";
				string cw = "[";
				for (int i = 0; i < item.AE_columnTitles.Length; i++)
				{
					cw += "\""+item.AE_columnTitles[i] +"\"";
					if (i < item.AE_columnTitles.Length - 1) cw += ", ";
				}
				cw += "]";
				string nm = item.AE_objName + "_titles";
				dataLines.Add("var " + nm + " = " + cw + ";");
				op += "columnTitles:" + nm;
			}
			if (op != "")
			{
				op = ", {" + op + "}";
			}
			based = based.Replace("$OP", op);

			lines.Add(based);

			s = getFontStr(item.Font);
			if (s != "")
			{
				if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
				lines.Add(head + item.AE_objName + ".graphics.font = " + s);
			}
		}
		//------------------------------------------------------------------------------------------------------------
		private void AddPanel(string parentName, Panel_AE item)
		{
			//	this.panel1 = this.winObj.add("panel", [246, 367, 246+131, 367+105], "" );

			string based = "$VAR$NAME = $PARENT.add(\"panel\", $RECT, $TEXT $OP);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);

			based = based.Replace("$PARENT", parentName);

			based = based.Replace("$RECT", item.BoundStr);

			if (item.AE_textObjName != "")
			{
				dataLines.Add("var " + item.AE_textObjName + " = \"" + item.Text + "\";");
				based = based.Replace("$TEXT", item.AE_textObjName);
			}
			else
			{
				based = based.Replace("$TEXT", "\"" + item.AE_text + "\"");
			}

			string op = "";

			if (item.AE_borderStyle != borderStyle.etched)
			{
				op += "borderStyle:";
				switch (item.AE_borderStyle)
				{
					case borderStyle.black: op += "\"black\""; break;
					case borderStyle.etched: op += "\"etched\""; break;
					case borderStyle.gray: op += "\"gray\""; break;
					case borderStyle.raised: op += "\"raised\""; break;
					case borderStyle.sunken: op += "\"sunken\""; break;
				}
			}
			if (op != "")
			{
				op = ", { " + op + " }";
			}
			based = based.Replace("$OP", op);

			lines.Add(based);
			string s = getFontStr(item.Font);
			if (s != "")
			{
				if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
				lines.Add(head + item.AE_objName + ".graphics.font = " + s);
			}
		}
		//------------------------------------------------------------------------------------------------------------
		private void AddProgressbar(string parentName, Progressbar_AE item)
		{
			//this.progressBar1 = this.winObj.add("progressbar", [188, 11, 188+185, 11+24], 50,100 );

			string based = "$VAR$NAME = $PARENT.add(\"progressbar\", $RECT, $VALUE ,$MINV, $MAXV );";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);

			based = based.Replace("$PARENT", parentName);

			based = based.Replace("$RECT", item.BoundStr);
			based = based.Replace("$VALUE", Utils.zero3(item.AE_value));
			based = based.Replace("$MINV", Utils.zero3(item.AE_minvalue));
			based = based.Replace("$MAXV", Utils.zero3(item.AE_maxvalue));

			lines.Add(based);

		}
		//------------------------------------------------------------------------------------------------------------
		private void AddRadiobutton(string parentName, Radiobutton_AE item)
		{
			//	this.radioButton1 = this.groupBox1.add("radiobutton", [29, 48, 29+88, 48+16], "radioButton1" );

			string based = "$VAR$NAME = $PARENT.add(\"radiobutton\", $RECT, $TEXT);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);

			based = based.Replace("$PARENT", parentName);

			based = based.Replace("$RECT", item.BoundStr);

			if (item.AE_textObjName != "")
			{
				dataLines.Add("var " + item.AE_textObjName + " = \"" + item.AE_text + "\";");
				based = based.Replace("$TEXT", item.AE_textObjName);
			}
			else
			{
				based = based.Replace("$TEXT", "\"" + item.AE_text + "\"");
			}
			lines.Add(based);

			if (item.AE_value == true)
			{
				if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
				string based2 = "$VAR$NAME.value = true;";
				based2 = based2.Replace("$VAR", head);
				based2 = based2.Replace("$NAME", item.AE_objName);
				lines.Add(based2);
			}

			string s = getFontStr(item.Font);
			if (s != "")
			{
				if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
				lines.Add(head + item.AE_objName + ".graphics.font = " + s);
			}
		}
		//------------------------------------------------------------------------------------------------------------
		private void AddScrollbarH(string parentName, ScrollbarH_AE item)
		{
			//	this.hScrollBar1 = this.winObj.add("scrollbar", [165, 481, 165+171, 481+17], 0, 0, 100 );
			string based = "$VAR$NAME = $PARENT.add(\"scrollbar\", $RECT, $VALUE ,$MINV, $MAXV);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);

			based = based.Replace("$PARENT", parentName);

			based = based.Replace("$RECT", item.BoundStr);
			based = based.Replace("$VALUE", Utils.zero3(item.AE_value));
			based = based.Replace("$MINV", Utils.zero3(item.AE_minvalue));
			based = based.Replace("$MAXV", Utils.zero3(item.AE_maxvalue));

			lines.Add(based);
		}
		//------------------------------------------------------------------------------------------------------------
		private void AddScrollbarV(string parentName, ScrollbarV_AE item)
		{
			//	this.vScrollBar1 = this.winObj.add("scrollbar", [462, 392, 462+17, 392+80], 0, 0, 100 );
			string based = "$VAR$NAME = $PARENT.add(\"scrollbar\", $RECT, $VALUE ,$MINV,  $MAXV);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);

			based = based.Replace("$PARENT", parentName);

			based = based.Replace("$RECT", item.BoundStr);
			based = based.Replace("$VALUE", Utils.zero3(item.AE_value));
			based = based.Replace("$MINV", Utils.zero3(item.AE_minvalue));
			based = based.Replace("$MAXV", Utils.zero3(item.AE_maxvalue));

			lines.Add(based);
		}
		//------------------------------------------------------------------------------------------------------------
		private void AddSlider(string parentName, Slider_AE item)
		{
			//	this.trackBar1 = this.winObj.add("slider", [136, 359, 136+104, 359+45], 0, 0, 10 );
			string based = "$VAR$NAME = $PARENT.add(\"slider\", $RECT, $VALUE ,$MINV,  $MAXV);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);

			based = based.Replace("$PARENT", parentName);

			based = based.Replace("$RECT", item.BoundStr);
			based = based.Replace("$VALUE", Utils.zero3(item.AE_value));
			based = based.Replace("$MINV", Utils.zero3(item.AE_minvalue));
			based = based.Replace("$MAXV", Utils.zero3(item.AE_maxvalue));

			lines.Add(based);
		}
		//------------------------------------------------------------------------------------------------------------
		private void AddStaticText(string parentName, Statictext_AE item)
        {
			//	this.lnIn = this.gbIn.add("statictext", [16, 33, 16+86, 33+12], "インポートフォルダ" );

			string based = "$VAR$NAME = $PARENT.add(\"statictext\", $RECT, $TEXT$OP);";
			string head = "";
			if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = "var "; } else { head = "this."; }

			based = based.Replace("$VAR", head);
			based = based.Replace("$NAME", item.AE_objName);

			based = based.Replace("$PARENT", parentName);

			based = based.Replace("$RECT", item.BoundStr);

			if (item.AE_textObjName != "")
			{
				dataLines.Add("var " + item.AE_textObjName + " = \"" + item.AE_text + "\";");
				based = based.Replace("$TEXT", item.AE_textObjName);
			}
			else
			{
				based = based.Replace("$TEXT", "\"" + item.AE_text + "\"");
			}

			string op = "";

			if (item.AE_multiline == true)
			{
				if (op != "") op += ", ";
				op += "multiline:true";
				if (item.AE_scrolling == true)
				{
					op += ", scrolling:true";
				}
			}
			if (op != "")
			{
				op = ", { " + op + " }";
			}
			based = based.Replace("$OP", op);

			lines.Add(based);

			string s = getFontStr(item.Font);
			if (s != "")
			{
				if ((item.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
				lines.Add(head + item.AE_objName + ".graphics.font = " + s);
			}
		}
  		//------------------------------------------------------------------------------------------------------------
        private void ListupControls( string parentName, System.Windows.Forms.Control.ControlCollection ctrls)
        {
            if (ctrls.Count <= 0) return;
			int TabMax = 0;
			for (int i = 0; i < ctrls.Count; i++)
			{
				if (ctrls[i].TabIndex > TabMax) TabMax = ctrls[i].TabIndex; 
			}

			//タブ順に探していく
			for (int k = 0; k <= TabMax; k++)
			{

				//Addされてるので、後ろから読み込み
				for (int i = ctrls.Count - 1; i >= 0; i--)
				{
					//タブのIndexが同じなら実行
					if (ctrls[i].TabIndex == k)
					{
						if (ctrls[i] is Button_AE)
						{
							AddButton(parentName, (Button_AE)ctrls[i]);
						}
						else if (ctrls[i] is Statictext_AE)
						{
							AddStaticText(parentName, (Statictext_AE)ctrls[i]);
						}
						else if (ctrls[i] is Edittext_AE)
						{
							AddEdittext(parentName, (Edittext_AE)ctrls[i]);
						}
						else if (ctrls[i] is Checkbox_AE)
						{
							AddCheckBox(parentName, (Checkbox_AE)ctrls[i]);
						}
                        else if (ctrls[i] is Radiobutton_AE)
                        {
							AddRadiobutton(parentName, (Radiobutton_AE)ctrls[i]);
                        }
                        else if (ctrls[i] is ScrollbarH_AE)
                        {
							AddScrollbarH(parentName, (ScrollbarH_AE)ctrls[i]);
                        }
						else if (ctrls[i] is ScrollbarV_AE)
                        {
                            AddScrollbarV(parentName, (ScrollbarV_AE)ctrls[i]);
                        }
                        else if (ctrls[i] is Slider_AE)
                        {
                            AddSlider(parentName, (Slider_AE)ctrls[i]);
                        }
                        else if (ctrls[i] is Dropdownlist_AE)
						{
							AddDropdownlist(parentName, (Dropdownlist_AE)ctrls[i]);
						}
						else if (ctrls[i] is Listbox_AE)
						{
							AddListbox(parentName, (Listbox_AE)ctrls[i]);
						}
						else if (ctrls[i] is Progressbar_AE)
                        {
							AddProgressbar(parentName, (Progressbar_AE)ctrls[i]);
                        }
                        else if (ctrls[i] is Iconbutton_AE)
                        {
                            AddIconbutton(parentName, (Iconbutton_AE)ctrls[i]);
                        }
						else if (ctrls[i] is Image_AE)
                        {
							AddImage(parentName, (Image_AE)ctrls[i]);
                        }
                        else if (ctrls[i] is Panel_AE)
						{
							Panel_AE p = (Panel_AE)ctrls[i];

							AddPanel(parentName, p);
							var head = "";
							if ((p.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }

							ListupControls(head + p.AE_objName, p.Controls);
						}
						else if (ctrls[i] is Group_AE)
						{
							Group_AE g = (Group_AE)ctrls[i];
							AddGroup(parentName, g);
							var head = "";
							if ((g.AE_isLocal == true) || (this.AE_isInFunc == false)) { head = ""; } else { head = "this."; }
							ListupControls(head + g.AE_objName, g.Controls);
						}
					}
				}
			}
        }
		//------------------------------------------------------------------------------------------------------------
		private class chkObj
		{
			public Control cnt;
			public string name;
			public string varName;
			public string typeName;

		}
		private void listup_chkObj(List<chkObj> list,System.Windows.Forms.Control.ControlCollection ctrls)
		{
			if (ctrls.Count <= 0) return;
			for (int i = ctrls.Count - 1; i >= 0; i--)
			{

				if (ctrls[i] is Panel_AE)
				{
					Panel_AE oj = (Panel_AE)ctrls[i];
					chkObj c = new chkObj();
					c.cnt = ctrls[i];
					c.name = ctrls[i].Name;
					c.varName = oj.AE_objName;
					c.typeName = "AE_objName";
					list.Add(c);
					if (oj.AE_textObjName != "")
					{
						chkObj c1 = new chkObj();
						c1.cnt = ctrls[i];
						c1.name = ctrls[i].Name;
						c1.varName = oj.AE_textObjName;
						c1.typeName = "AE_textObjName";
						list.Add(c1);
					}
					listup_chkObj(list, oj.Controls);
				}
				else if (ctrls[i] is Group_AE)
				{
					Group_AE oj = (Group_AE)ctrls[i];
					chkObj c = new chkObj();
					c.cnt = ctrls[i];
					c.name = ctrls[i].Name;
					c.varName = oj.AE_objName;
					c.typeName = "AE_objName";
					list.Add(c);
					listup_chkObj(list, oj.Controls);
				}
				else if (ctrls[i] is Button_AE)
				{
					Button_AE oj = (Button_AE)ctrls[i];
					chkObj c = new chkObj();
					c.cnt = ctrls[i];
					c.name = ctrls[i].Name;
					c.varName = oj.AE_objName;
					c.typeName = "AE_objName";
					list.Add(c);
					if (oj.AE_textObjName != "")
					{
						chkObj c1 = new chkObj();
						c1.cnt = ctrls[i];
						c1.name = ctrls[i].Name;
						c1.varName = oj.AE_textObjName;
						c1.typeName = "AE_textObjName";
						list.Add(c1);
					}
				}
				else if (ctrls[i] is Checkbox_AE)
				{
					Checkbox_AE oj = (Checkbox_AE)ctrls[i];
					chkObj c = new chkObj();
					c.cnt = ctrls[i];
					c.name = ctrls[i].Name;
					c.varName = oj.AE_objName;
					c.typeName = "AE_objName";
					list.Add(c);
					if (oj.AE_textObjName != "")
					{
						chkObj c1 = new chkObj();
						c1.cnt = ctrls[i];
						c1.name = ctrls[i].Name;
						c1.varName = oj.AE_textObjName;
						c1.typeName = "AE_textObjName";
						list.Add(c1);
					}
				}
				else if (ctrls[i] is Statictext_AE)
				{
					Statictext_AE oj = (Statictext_AE)ctrls[i];
					chkObj c = new chkObj();
					c.cnt = ctrls[i];
					c.name = ctrls[i].Name;
					c.varName = oj.AE_objName;
					c.typeName = "AE_objName";
					list.Add(c);
					if (oj.AE_textObjName != "")
					{
						chkObj c1 = new chkObj();
						c1.cnt = ctrls[i];
						c.name = ctrls[i].Name;
						c1.varName = oj.AE_textObjName;
						c1.typeName = "AE_textObjName";
						list.Add(c1);
					}
				}
				else if (ctrls[i] is Radiobutton_AE)
				{
					Radiobutton_AE oj = (Radiobutton_AE)ctrls[i];
					chkObj c = new chkObj();
					c.cnt = ctrls[i];
					c.name = ctrls[i].Name;
					c.varName = oj.AE_objName;
					c.typeName = "AE_objName";
					list.Add(c);
					if (oj.AE_textObjName != "")
					{
						chkObj c1 = new chkObj();
						c1.cnt = ctrls[i];
						c.name = ctrls[i].Name;
						c1.varName = oj.AE_textObjName;
						c1.typeName = "AE_textObjName";
						list.Add(c1);
					}
				}
				else if (ctrls[i] is Edittext_AE)
				{
					Edittext_AE oj = (Edittext_AE)ctrls[i];
					chkObj c = new chkObj();
					c.cnt = ctrls[i];
					c.name = ctrls[i].Name;
					c.varName = oj.AE_objName;
					c.typeName = "AE_objName";
					list.Add(c);
					if (oj.AE_textObjName != "")
					{
						chkObj c1 = new chkObj();
						c1.cnt = ctrls[i];
						c1.name = ctrls[i].Name;
						c1.varName = oj.AE_textObjName;
						c1.typeName = "AE_textObjName";
						list.Add(c1);
					}
				}
				else if (ctrls[i] is Image_AE)
				{
					Image_AE oj = (Image_AE)ctrls[i];
					chkObj c = new chkObj();
					c.cnt = ctrls[i];
					c.name = ctrls[i].Name;
					c.varName = oj.AE_objName;
					c.typeName = "AE_objName";
					list.Add(c);
					if (oj.AE_imageObjName != "")
					{
						chkObj c1 = new chkObj();
						c1.cnt = ctrls[i];
						c1.name = ctrls[i].Name;
						c1.varName = oj.AE_imageObjName;
						c1.typeName = "AE_imageObjName";
						list.Add(c1);
					}
				}
				else if (ctrls[i] is Iconbutton_AE)
				{
					Iconbutton_AE oj = (Iconbutton_AE)ctrls[i];
					chkObj c = new chkObj();
					c.cnt = ctrls[i];
					c.name = ctrls[i].Name;
					c.varName = oj.AE_objName;
					c.typeName = "AE_objName";
					list.Add(c);
					if (oj.AE_imageObjName != "")
					{
						chkObj c1 = new chkObj();
						c1.cnt = ctrls[i];
						c1.name = ctrls[i].Name;
						c1.varName = oj.AE_imageObjName;
						c1.typeName = "AE_imageObjName";
						list.Add(c1);
					}
				}
				else if (ctrls[i] is Listbox_AE)
				{
					Listbox_AE oj = (Listbox_AE)ctrls[i];
					chkObj c = new chkObj();
					c.cnt = ctrls[i];
					c.name = ctrls[i].Name;
					c.varName = oj.AE_objName;
					c.typeName = "AE_objName";
					list.Add(c);
					if (oj.AE_itemsName != "")
					{
						chkObj c1 = new chkObj();
						c1.cnt = ctrls[i];
						c1.name = ctrls[i].Name;
						c1.varName = oj.AE_itemsName;
						c1.typeName = "AE_itemsName";
						list.Add(c1);
					}
				}
				else if (ctrls[i] is Dropdownlist_AE)
				{
					Dropdownlist_AE oj = (Dropdownlist_AE)ctrls[i];
					chkObj c = new chkObj();
					c.cnt = ctrls[i];
					c.name = ctrls[i].Name;
					c.varName = oj.AE_objName;
					c.typeName = "AE_objName";
					list.Add(c);
					if (oj.AE_itemsName != "")
					{
						chkObj c1 = new chkObj();
						c1.cnt = ctrls[i];
						c1.name = ctrls[i].Name;
						c1.varName = oj.AE_itemsName;
						c1.typeName = "AE_itemsName";
						list.Add(c1);
					}
				}
			}
		}
		private string chkObjName()
		{
			List<chkObj> list = new List<chkObj>();

			listup_chkObj(list, _Form.Controls);
			string res = "";
			if (list.Count > 0)
			{
				for (int i = 0; i < list.Count-1; i++)
				{
					string src = list[i].varName;
					for (int j = i + 1; j < list.Count; j++)
					{
						string dst = list[j].varName;
						if (src == dst)
						{
							res += "// [ " + list[i].name + " ]:" + list[i].varName + "(" + list[i].typeName + ") と " + "[ " + list[j].name + " ]:" + list[j].varName + "(" + list[i].typeName + ") が同じ名前\r\n"; 
						}
					}
				}
			}
			if (res != "")
			{
				res = "// 名前が重複しています。\r\n\r\n" + res;
			}
			return res;
		}
		//------------------------------------------------------------------------------------------------------------
		private string getWindowsOption()
		{
			string ret = "";

			if (AE_resizeable == true)
			{
				ret += "resizeable:true";

			}
			if (AE_maximizeButton == true)
			{
				if (ret != "") ret += ", ";
				ret += "maximizeButton:true";
			}
			if (AE_minimizeButton == true)
			{
				if (ret != "") ret += ", ";
				ret += "minimizeButton:true";
			}
			if (ret != "")
			{
				ret = " ,{" + ret + "}";
			}
			return ret;
		}
		//------------------------------------------------------------------------------------------------------------
		private void Listup()
        {
            string ret = "";
			
			dataLines.Clear();
			lines.Clear();
			images.Clear();

			_Result = "";
			if (_Form == null) return;
			//if ( _Form.Controls.Count<=0) return;


			switch (_windowType)
			{
				case windowType.floatingPalette:
					if (_isInFunc == true)
					{
						ret = bryful_due.Properties.Resources.BaseFloatingPaletteInFunc;
					}
					else
					{
						ret = bryful_due.Properties.Resources.BaseFloatingPalette;
					}
						break;
				default:
					if (_isInFunc == true)
					{
						ret = bryful_due.Properties.Resources.BaseDialogInFunc;
					}
					else
					{
						ret = bryful_due.Properties.Resources.BaseDialog;
					}
					break;
			}

			//変換後の文字を作成
			if ((AE_isInFunc == true) && (AE_windowType != windowType.floatingPalette))
			{
				string funcName = AE_funcName.Trim();
				ret = ret.Replace("$funcName", funcName);
			}

			string varS = "var" + " ";
			string thisS = "";
			if ((AE_isInFunc == true) && (AE_isLocal == false) && (_windowType != windowType.floatingPalette))
			{
				varS = "";
				thisS = "this.";
			}
			ret = ret.Replace("$var", varS);
			ret = ret.Replace("$this", thisS);

			string objName = _objName.Trim();
			ret = ret.Replace("$objName", objName);

			ret = ret.Replace("$windowType", Utils.windowTypeStr(_windowType));

			ret = ret.Replace("$title", AE_title);

			string bounds = Utils.RectToBounds(new Rectangle(_Form.Left, _Form.Top, _Form.ClientSize.Width, _Form.ClientSize.Height));
			ret = ret.Replace("$bounds", bounds);

			string op = getWindowsOption();
			ret = ret.Replace("$option", op);

			string center = "//";
			if (AE_isCenter == true) center = "";
			ret = ret.Replace("$center", center);

			ListupControls(thisS + objName, _Form.Controls);
			

			string lineHead = "";
			if (AE_isInFunc == true) lineHead = "\t";

			string data = "";
			if (dataLines.Count > 0)
			{
				for (int i = 0; i < dataLines.Count; i++)
				{
					data += lineHead + dataLines[i] + "\r\n";
				}
			}
			ret = ret.Replace("$data", data);
			string ctrl = "";
			if (lines.Count > 0)
			{
				for (int i = 0; i < lines.Count; i++)
				{
					ctrl += lineHead + lines[i] + "\r\n";
				}
			}
			ret = ret.Replace("$build", ctrl);


			_Result += chkObjName() + "\r\n";
			_Result += ret;
          
        }
		//------------------------------------------------------------------------------------------------------------
		private bool MakeDirectory(string path)
		{
			if (Directory.Exists(path) == true) return true;
			string p = Path.GetDirectoryName(path);
			if (Directory.Exists(p) == false)
			{
				if (MakeDirectory(p) == false) return false;
			}
			try
			{
				Directory.CreateDirectory(path);
				return true;
			}
			catch
			{
				return false; ;
			}
		}
		//------------------------------------------------------------------------------------------------------------
		private bool SavePicture(string path, Bitmap bmp)
		{
			string p = Path.GetDirectoryName(path);
			if (MakeDirectory(p) == false) return false;
			string f = Path.GetFileName(path);
			try
			{
				bmp.Save(path);
				return true;
			}
			catch
			{
				return false;
			}

		}
		//------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// ファイル名を指定して保存
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public bool SaveToFile(string path)
		{
			if (_Result == "") return false;

			string bak = Directory.GetCurrentDirectory();
			System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false, System.Text.Encoding.GetEncoding("utf-8"));
			try
			{
				Directory.SetCurrentDirectory(Path.GetDirectoryName(path));
				//TextBox1.Textの内容を書き込む
				sw.Write(_Result);
				if (images.Count > 0)
				{
					for (int i = 0; i < images.Count; i++)
					{
						string p = Path.GetFullPath(imagesPath[i].Replace("/", "\\"));
						SavePicture(p, images[i]);
					}
				}
			}
			catch
			{
				return false;
			}
			finally
			{
				sw.Close();
				Directory.SetCurrentDirectory(bak);
			}
			return true;
		}
		//------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// ダイアログを表示してExport
		/// </summary>
		/// <returns></returns>
		public bool SaveAs()
		{
			Listup();
			if (_Result == string.Empty) return false;
			SaveFileDialog sv = new SaveFileDialog();
			sv.Title = "Export JavaScript Code";
			sv.Filter = "jsx(*.jsx)|*.jsx|txt(*.txt)|*.txt|all(*.*)|*.*";
			if (sv.ShowDialog() == DialogResult.OK)
			{
				return SaveToFile(sv.FileName);
			}
			else
			{
				return false;
			}
		}
		//------------------------------------------------------------------------------------------------------------

	}
}
