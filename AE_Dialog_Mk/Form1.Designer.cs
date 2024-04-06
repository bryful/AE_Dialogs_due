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
			a_button2 = new A_button();
			SuspendLayout();
			// 
			// a_button1
			// 
			a_button1.AE_bounds = new int[]
	{
	95,
	12,
	170,
	35
	};
			a_button1.AE_objName = "a_button1";
			a_button1.AE_text = "a_button1";
			a_button1.DataContext = null;
			a_button1.Font = new Font("Tahoma", 8.25F);
			a_button1.Image = null;
			a_button1.Location = new Point(95, 12);
			a_button1.Name = "a_button1";
			a_button1.Size = new Size(75, 23);
			a_button1.TabIndex = 0;
			a_button1.Text = "a_button1";
			a_button1.UseVisualStyleBackColor = true;
			// 
			// a_button2
			// 
			a_button2.AE_bounds = new int[]
	{
	95,
	50,
	170,
	73
	};
			a_button2.AE_objName = "a_button2";
			a_button2.AE_text = "a_button2";
			a_button2.DataContext = null;
			a_button2.Font = new Font("Tahoma", 8.25F);
			a_button2.Image = null;
			a_button2.Location = new Point(95, 50);
			a_button2.Name = "a_button2";
			a_button2.Size = new Size(75, 23);
			a_button2.TabIndex = 1;
			a_button2.Text = "a_button2";
			a_button2.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AE_bounds = new int[]
	{
	15,
	15,
	234,
	150
	};
			AE_title = "AE_Script";
			AE_windowType = windowType.floatingPalette;
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(203, 96);
			Controls.Add(a_button2);
			Controls.Add(a_button1);
			DoubleBuffered = true;
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "Form1";
			Text = "AE_Script";
			ResumeLayout(false);
		}

		#endregion

		private A_button a_button1;
		private A_button a_button2;
	}
}
