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
	public class Iconbutton_AE : Button
	{
		private bool _IsLocal = true;
		private string _objName = "";

		private string _imageObjName = "";
		private string _imageFileName = "";
		private string _imageFilePath = "./";
		private string _defExt = ".png";
		//------------------------------------------------------------------------------------------------------------
		public Iconbutton_AE()
		{
			this.Font = new Font("Tahoma", 8.25f);
			this.Text = "";
		}
		protected override void OnTextChanged(EventArgs e)
		{
			this.Text = "";
			base.OnTextChanged(e);
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
		public bool AE_isLocal
		{
			get { return _IsLocal; }
			set { _IsLocal = value; }
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
				return _imageFileName;
			}
			set
			{ 
				_imageFileName = value.Trim();
				_imageFileName = _imageFileName.Replace("\\", "");
				_imageFileName = _imageFileName.Replace("/", "");
				_imageFileName = _imageFileName.Replace("*", "");
				_imageFileName = _imageFileName.Replace(":", "");
				_imageFileName = _imageFileName.Replace("<", "");
				_imageFileName = _imageFileName.Replace(">", "");
				_imageFileName = _imageFileName.Replace("?", "");
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_imageFilePath
		{
			get
			{
				return _imageFilePath;
			}
			set
			{
				_imageFilePath = value.Trim();
				_imageFilePath = _imageFilePath.Replace("\\", "/");
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public string AE_imageFullPath
		{
			get
			{
				if (_imageFilePath == "")
				{
					return AE_imageFileName;
				}
				if (_imageFilePath[_imageFilePath.Length - 1] != '/')
				{
					return AE_imageFilePath + "/" + AE_imageFileName;
				}
				else
				{
					return AE_imageFilePath + AE_imageFileName;
				}
			}
		}
		//------------------------------------------------------------------------------------------------------------
		public string BoundStr
		{
			get { return Utils.GetBoundStr(this); }
		}
		//------------------------------------------------------------------------------------------------------------
	}
}
