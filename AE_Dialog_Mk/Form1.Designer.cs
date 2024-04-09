namespace AE_Dialog_Mk
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			a_button1 = new A_button();
			a_panel1 = new A_panel();
			a_statictext1 = new A_statictext();
			a_edittext1 = new A_edittext();
			a_radiobutton3 = new A_radiobutton();
			a_radiobutton2 = new A_radiobutton();
			a_radiobutton1 = new A_radiobutton();
			a_panel2 = new A_panel();
			a_edittext5 = new A_edittext();
			a_statictext5 = new A_statictext();
			a_edittext4 = new A_edittext();
			a_statictext4 = new A_statictext();
			a_edittext3 = new A_edittext();
			a_statictext3 = new A_statictext();
			a_edittext2 = new A_edittext();
			a_statictext2 = new A_statictext();
			a_button2 = new A_button();
			a_button3 = new A_button();
			a_panel1.SuspendLayout();
			a_panel2.SuspendLayout();
			SuspendLayout();
			// 
			// a_button1
			// 
			a_button1.AE_bounds = new int[]
	{
	25,
	8,
	325,
	40
	};
			a_button1.AE_objName = "btnGet";
			a_button1.AE_text = "現在のアートボードのサイズを獲得";
			a_button1.DataContext = null;
			a_button1.Font = new Font("Tahoma", 8.25F);
			a_button1.Image = null;
			a_button1.Location = new Point(25, 8);
			a_button1.Name = "a_button1";
			a_button1.Size = new Size(300, 32);
			a_button1.TabIndex = 0;
			a_button1.Text = "現在のアートボードのサイズを獲得";
			a_button1.UseVisualStyleBackColor = true;
			// 
			// a_panel1
			// 
			a_panel1.AE_borderStyle = borderStyle.etched;
			a_panel1.AE_bounds = new int[]
	{
	25,
	46,
	325,
	100
	};
			a_panel1.AE_objName = "pUnit";
			a_panel1.AE_text = "Unit";
			a_panel1.Controls.Add(a_statictext1);
			a_panel1.Controls.Add(a_edittext1);
			a_panel1.Controls.Add(a_radiobutton3);
			a_panel1.Controls.Add(a_radiobutton2);
			a_panel1.Controls.Add(a_radiobutton1);
			a_panel1.DataContext = null;
			a_panel1.Font = new Font("Tahoma", 8.25F);
			a_panel1.Location = new Point(25, 46);
			a_panel1.Name = "a_panel1";
			a_panel1.Size = new Size(300, 54);
			a_panel1.TabIndex = 1;
			a_panel1.TabStop = false;
			a_panel1.Text = "Unit";
			// 
			// a_statictext1
			// 
			a_statictext1.AE_bounds = new int[]
	{
	248,
	20,
	274,
	40
	};
			a_statictext1.AE_multiline = false;
			a_statictext1.AE_objName = "stDpi";
			a_statictext1.AE_scrolling = false;
			a_statictext1.AE_text = "dpi";
			a_statictext1.DataContext = null;
			a_statictext1.Font = new Font("Tahoma", 8.25F);
			a_statictext1.Image = null;
			a_statictext1.Location = new Point(248, 20);
			a_statictext1.Name = "a_statictext1";
			a_statictext1.Size = new Size(26, 20);
			a_statictext1.TabIndex = 4;
			a_statictext1.Text = "dpi";
			// 
			// a_edittext1
			// 
			a_edittext1.AE_borderless = false;
			a_edittext1.AE_bounds = new int[]
	{
	201,
	20,
	243,
	40
	};
			a_edittext1.AE_multiline = false;
			a_edittext1.AE_noecho = false;
			a_edittext1.AE_objName = "edDpi";
			a_edittext1.AE_readonly = false;
			a_edittext1.AE_scrollable = false;
			a_edittext1.AE_text = "300";
			a_edittext1.AE_textLines = new string[]
	{
	"300"
	};
			a_edittext1.DataContext = null;
			a_edittext1.Font = new Font("Tahoma", 8.25F);
			a_edittext1.Location = new Point(201, 20);
			a_edittext1.Name = "a_edittext1";
			a_edittext1.Size = new Size(42, 20);
			a_edittext1.TabIndex = 3;
			a_edittext1.Text = "300";
			// 
			// a_radiobutton3
			// 
			a_radiobutton3.AE_bounds = new int[]
	{
	143,
	20,
	197,
	40
	};
			a_radiobutton3.AE_objName = "rbPixel";
			a_radiobutton3.AE_text = "Pixel";
			a_radiobutton3.AE_value = false;
			a_radiobutton3.DataContext = null;
			a_radiobutton3.Font = new Font("Tahoma", 8.25F);
			a_radiobutton3.Image = null;
			a_radiobutton3.Location = new Point(143, 20);
			a_radiobutton3.Name = "a_radiobutton3";
			a_radiobutton3.Size = new Size(54, 20);
			a_radiobutton3.TabIndex = 2;
			a_radiobutton3.Text = "Pixel";
			a_radiobutton3.UseVisualStyleBackColor = true;
			// 
			// a_radiobutton2
			// 
			a_radiobutton2.AE_bounds = new int[]
	{
	69,
	20,
	134,
	40
	};
			a_radiobutton2.AE_objName = "rbPoint";
			a_radiobutton2.AE_text = "Point";
			a_radiobutton2.AE_value = false;
			a_radiobutton2.DataContext = null;
			a_radiobutton2.Font = new Font("Tahoma", 8.25F);
			a_radiobutton2.Image = null;
			a_radiobutton2.Location = new Point(69, 20);
			a_radiobutton2.Name = "a_radiobutton2";
			a_radiobutton2.Size = new Size(65, 20);
			a_radiobutton2.TabIndex = 1;
			a_radiobutton2.Text = "Point";
			a_radiobutton2.UseVisualStyleBackColor = true;
			// 
			// a_radiobutton1
			// 
			a_radiobutton1.AE_bounds = new int[]
	{
	6,
	20,
	49,
	40
	};
			a_radiobutton1.AE_objName = "rbMM";
			a_radiobutton1.AE_text = "mm";
			a_radiobutton1.AE_value = false;
			a_radiobutton1.DataContext = null;
			a_radiobutton1.Font = new Font("Tahoma", 8.25F);
			a_radiobutton1.Image = null;
			a_radiobutton1.Location = new Point(6, 20);
			a_radiobutton1.Name = "a_radiobutton1";
			a_radiobutton1.Size = new Size(43, 20);
			a_radiobutton1.TabIndex = 0;
			a_radiobutton1.Text = "mm";
			a_radiobutton1.UseVisualStyleBackColor = true;
			// 
			// a_panel2
			// 
			a_panel2.AE_borderStyle = borderStyle.etched;
			a_panel2.AE_bounds = new int[]
	{
	25,
	106,
	325,
	189
	};
			a_panel2.AE_objName = "pSize";
			a_panel2.AE_text = "Size";
			a_panel2.Controls.Add(a_edittext5);
			a_panel2.Controls.Add(a_statictext5);
			a_panel2.Controls.Add(a_edittext4);
			a_panel2.Controls.Add(a_statictext4);
			a_panel2.Controls.Add(a_edittext3);
			a_panel2.Controls.Add(a_statictext3);
			a_panel2.Controls.Add(a_edittext2);
			a_panel2.Controls.Add(a_statictext2);
			a_panel2.DataContext = null;
			a_panel2.Font = new Font("Tahoma", 8.25F);
			a_panel2.Location = new Point(25, 106);
			a_panel2.Name = "a_panel2";
			a_panel2.Size = new Size(300, 83);
			a_panel2.TabIndex = 2;
			a_panel2.TabStop = false;
			a_panel2.Text = "Size";
			// 
			// a_edittext5
			// 
			a_edittext5.AE_borderless = false;
			a_edittext5.AE_bounds = new int[]
	{
	201,
	48,
	243,
	68
	};
			a_edittext5.AE_multiline = false;
			a_edittext5.AE_noecho = false;
			a_edittext5.AE_objName = "edWidth";
			a_edittext5.AE_readonly = false;
			a_edittext5.AE_scrollable = false;
			a_edittext5.AE_text = "";
			a_edittext5.DataContext = null;
			a_edittext5.Font = new Font("Tahoma", 8.25F);
			a_edittext5.Location = new Point(201, 48);
			a_edittext5.Name = "a_edittext5";
			a_edittext5.Size = new Size(42, 20);
			a_edittext5.TabIndex = 7;
			// 
			// a_statictext5
			// 
			a_statictext5.AE_bounds = new int[]
	{
	147,
	48,
	195,
	68
	};
			a_statictext5.AE_multiline = false;
			a_statictext5.AE_objName = "stHeight";
			a_statictext5.AE_scrolling = false;
			a_statictext5.AE_text = "height";
			a_statictext5.DataContext = null;
			a_statictext5.Font = new Font("Tahoma", 8.25F);
			a_statictext5.Image = null;
			a_statictext5.Location = new Point(147, 48);
			a_statictext5.Name = "a_statictext5";
			a_statictext5.Size = new Size(48, 20);
			a_statictext5.TabIndex = 6;
			a_statictext5.Text = "height";
			// 
			// a_edittext4
			// 
			a_edittext4.AE_borderless = false;
			a_edittext4.AE_bounds = new int[]
	{
	70,
	45,
	112,
	65
	};
			a_edittext4.AE_multiline = false;
			a_edittext4.AE_noecho = false;
			a_edittext4.AE_objName = "edWidth";
			a_edittext4.AE_readonly = false;
			a_edittext4.AE_scrollable = false;
			a_edittext4.AE_text = "";
			a_edittext4.DataContext = null;
			a_edittext4.Font = new Font("Tahoma", 8.25F);
			a_edittext4.Location = new Point(70, 45);
			a_edittext4.Name = "a_edittext4";
			a_edittext4.Size = new Size(42, 20);
			a_edittext4.TabIndex = 5;
			// 
			// a_statictext4
			// 
			a_statictext4.AE_bounds = new int[]
	{
	16,
	48,
	64,
	68
	};
			a_statictext4.AE_multiline = false;
			a_statictext4.AE_objName = "stWidth";
			a_statictext4.AE_scrolling = false;
			a_statictext4.AE_text = "width";
			a_statictext4.DataContext = null;
			a_statictext4.Font = new Font("Tahoma", 8.25F);
			a_statictext4.Image = null;
			a_statictext4.Location = new Point(16, 48);
			a_statictext4.Name = "a_statictext4";
			a_statictext4.Size = new Size(48, 20);
			a_statictext4.TabIndex = 4;
			a_statictext4.Text = "width";
			// 
			// a_edittext3
			// 
			a_edittext3.AE_borderless = false;
			a_edittext3.AE_bounds = new int[]
	{
	201,
	22,
	243,
	42
	};
			a_edittext3.AE_multiline = false;
			a_edittext3.AE_noecho = false;
			a_edittext3.AE_objName = "edTop";
			a_edittext3.AE_readonly = false;
			a_edittext3.AE_scrollable = false;
			a_edittext3.AE_text = "";
			a_edittext3.DataContext = null;
			a_edittext3.Font = new Font("Tahoma", 8.25F);
			a_edittext3.Location = new Point(201, 22);
			a_edittext3.Name = "a_edittext3";
			a_edittext3.Size = new Size(42, 20);
			a_edittext3.TabIndex = 3;
			// 
			// a_statictext3
			// 
			a_statictext3.AE_bounds = new int[]
	{
	147,
	22,
	195,
	42
	};
			a_statictext3.AE_multiline = false;
			a_statictext3.AE_objName = "stTop";
			a_statictext3.AE_scrolling = false;
			a_statictext3.AE_text = "top";
			a_statictext3.DataContext = null;
			a_statictext3.Font = new Font("Tahoma", 8.25F);
			a_statictext3.Image = null;
			a_statictext3.Location = new Point(147, 22);
			a_statictext3.Name = "a_statictext3";
			a_statictext3.Size = new Size(48, 20);
			a_statictext3.TabIndex = 2;
			a_statictext3.Text = "top";
			// 
			// a_edittext2
			// 
			a_edittext2.AE_borderless = false;
			a_edittext2.AE_bounds = new int[]
	{
	70,
	19,
	112,
	39
	};
			a_edittext2.AE_multiline = false;
			a_edittext2.AE_noecho = false;
			a_edittext2.AE_objName = "edLeft";
			a_edittext2.AE_readonly = false;
			a_edittext2.AE_scrollable = false;
			a_edittext2.AE_text = "";
			a_edittext2.DataContext = null;
			a_edittext2.Font = new Font("Tahoma", 8.25F);
			a_edittext2.Location = new Point(70, 19);
			a_edittext2.Name = "a_edittext2";
			a_edittext2.Size = new Size(42, 20);
			a_edittext2.TabIndex = 1;
			// 
			// a_statictext2
			// 
			a_statictext2.AE_bounds = new int[]
	{
	16,
	22,
	64,
	42
	};
			a_statictext2.AE_multiline = false;
			a_statictext2.AE_objName = "stLeft";
			a_statictext2.AE_scrolling = false;
			a_statictext2.AE_text = "left";
			a_statictext2.DataContext = null;
			a_statictext2.Font = new Font("Tahoma", 8.25F);
			a_statictext2.Image = null;
			a_statictext2.Location = new Point(16, 22);
			a_statictext2.Name = "a_statictext2";
			a_statictext2.Size = new Size(48, 20);
			a_statictext2.TabIndex = 0;
			a_statictext2.Text = "left";
			// 
			// a_button2
			// 
			a_button2.AE_bounds = new int[]
	{
	25,
	195,
	109,
	227
	};
			a_button2.AE_objName = "btnUndo";
			a_button2.AE_text = "Undo";
			a_button2.DataContext = null;
			a_button2.Font = new Font("Tahoma", 8.25F);
			a_button2.Image = null;
			a_button2.Location = new Point(25, 195);
			a_button2.Name = "a_button2";
			a_button2.Size = new Size(84, 32);
			a_button2.TabIndex = 3;
			a_button2.Text = "Undo";
			a_button2.UseVisualStyleBackColor = true;
			// 
			// a_button3
			// 
			a_button3.AE_bounds = new int[]
	{
	138,
	195,
	325,
	227
	};
			a_button3.AE_objName = "btnApply";
			a_button3.AE_text = "Apply";
			a_button3.DataContext = null;
			a_button3.Font = new Font("Tahoma", 8.25F);
			a_button3.Image = null;
			a_button3.Location = new Point(138, 195);
			a_button3.Name = "a_button3";
			a_button3.Size = new Size(187, 32);
			a_button3.TabIndex = 4;
			a_button3.Text = "Apply";
			a_button3.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AE_bounds = new int[]
	{
	15,
	15,
	371,
	291
	};
			AE_title = "アートボードのサイズ";
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(340, 237);
			Controls.Add(a_button3);
			Controls.Add(a_button2);
			Controls.Add(a_panel2);
			Controls.Add(a_panel1);
			Controls.Add(a_button1);
			DoubleBuffered = true;
			Name = "Form1";
			Text = "アートボードのサイズ";
			a_panel1.ResumeLayout(false);
			a_panel2.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private A_button a_button1;
		private A_panel a_panel1;
		private A_radiobutton a_radiobutton1;
		private A_statictext a_statictext1;
		private A_edittext a_edittext1;
		private A_radiobutton a_radiobutton3;
		private A_radiobutton a_radiobutton2;
		private A_panel a_panel2;
		private A_edittext a_edittext5;
		private A_statictext a_statictext5;
		private A_edittext a_edittext4;
		private A_statictext a_statictext4;
		private A_edittext a_edittext3;
		private A_statictext a_statictext3;
		private A_edittext a_edittext2;
		private A_statictext a_statictext2;
		private A_button a_button2;
		private A_button a_button3;
	}
}
