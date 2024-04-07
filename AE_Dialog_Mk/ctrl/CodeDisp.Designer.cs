namespace AE_Dialog_Mk
{
	partial class CodeDisp
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			btnOK = new Button();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			closeMenu = new ToolStripMenuItem();
			editToolStripMenuItem = new ToolStripMenuItem();
			copyMenu = new ToolStripMenuItem();
			selectAllMenu = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripSeparator();
			fontMenu = new ToolStripMenuItem();
			statusStrip1 = new StatusStrip();
			fontDialog1 = new FontDialog();
			textBox1 = new TextBox();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// btnOK
			// 
			btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			btnOK.DialogResult = DialogResult.OK;
			btnOK.Location = new Point(967, 682);
			btnOK.Margin = new Padding(4);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(88, 29);
			btnOK.TabIndex = 1;
			btnOK.Text = "close";
			btnOK.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(7, 2, 0, 2);
			menuStrip1.Size = new Size(1101, 24);
			menuStrip1.TabIndex = 2;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { closeMenu });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// closeMenu
			// 
			closeMenu.Name = "closeMenu";
			closeMenu.ShortcutKeys = Keys.Control | Keys.W;
			closeMenu.Size = new Size(146, 22);
			closeMenu.Text = "Close";
			closeMenu.Click += closeMenu_Click;
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyMenu, selectAllMenu, toolStripMenuItem1, fontMenu });
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new Size(39, 20);
			editToolStripMenuItem.Text = "Edit";
			// 
			// copyMenu
			// 
			copyMenu.Name = "copyMenu";
			copyMenu.ShortcutKeys = Keys.Control | Keys.C;
			copyMenu.Size = new Size(160, 22);
			copyMenu.Text = "Copy";
			copyMenu.Click += copyMenu_Click;
			// 
			// selectAllMenu
			// 
			selectAllMenu.Name = "selectAllMenu";
			selectAllMenu.ShortcutKeys = Keys.Control | Keys.A;
			selectAllMenu.Size = new Size(160, 22);
			selectAllMenu.Text = "SelectAll";
			selectAllMenu.Click += selectAllMenu_Click;
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(157, 6);
			// 
			// fontMenu
			// 
			fontMenu.Name = "fontMenu";
			fontMenu.Size = new Size(160, 22);
			fontMenu.Text = "Font";
			fontMenu.Click += fontMenu_Click;
			// 
			// statusStrip1
			// 
			statusStrip1.Location = new Point(0, 720);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Padding = new Padding(1, 0, 16, 0);
			statusStrip1.Size = new Size(1101, 22);
			statusStrip1.TabIndex = 3;
			statusStrip1.Text = "statusStrip1";
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBox1.BackColor = SystemColors.Window;
			textBox1.Font = new Font("源ノ角ゴシック Code JP R", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
			textBox1.Location = new Point(0, 34);
			textBox1.Margin = new Padding(4);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.ScrollBars = ScrollBars.Both;
			textBox1.Size = new Size(1101, 640);
			textBox1.TabIndex = 0;
			// 
			// CodeDisp
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1101, 742);
			Controls.Add(textBox1);
			Controls.Add(statusStrip1);
			Controls.Add(btnOK);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Margin = new Padding(4);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "CodeDisp";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "JavaScriptコード";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeMenu;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyMenu;
		private System.Windows.Forms.ToolStripMenuItem selectAllMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem fontMenu;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.TextBox textBox1;
	}
}