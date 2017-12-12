﻿namespace RoomsEditor {
	partial class MainForm {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Timer DrawTimer;
			this.viewPort = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.создатьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			this.оКToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьКакToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.сброситьТрансформациюToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.вьюпортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сброситьТрансформациюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CreateWallButton = new System.Windows.Forms.Button();
			this.CreateHideButton = new System.Windows.Forms.Button();
			this.EditWallButton = new System.Windows.Forms.Button();
			this.EditObjectButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.infoLabel = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.файлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.создатьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьКакToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.вьюпортToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.сброситьТрансформациюToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.XSymmetryBox = new System.Windows.Forms.CheckBox();
			this.YSymmetryBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.XYSymmetryBox = new System.Windows.Forms.CheckBox();
			DrawTimer = new System.Windows.Forms.Timer(this.components);
			this.MainMenuStrip.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DrawTimer
			// 
			DrawTimer.Enabled = true;
			DrawTimer.Interval = 20;
			DrawTimer.Tick += new System.EventHandler(this.DrawViewPort);
			// 
			// viewPort
			// 
			this.viewPort.AccumBits = ((byte)(0));
			this.viewPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.viewPort.AutoCheckErrors = false;
			this.viewPort.AutoFinish = false;
			this.viewPort.AutoMakeCurrent = true;
			this.viewPort.AutoSwapBuffers = true;
			this.viewPort.BackColor = System.Drawing.Color.Black;
			this.viewPort.ColorBits = ((byte)(32));
			this.viewPort.DepthBits = ((byte)(16));
			this.viewPort.Location = new System.Drawing.Point(281, 0);
			this.viewPort.Name = "viewPort";
			this.viewPort.Size = new System.Drawing.Size(992, 558);
			this.viewPort.StencilBits = ((byte)(0));
			this.viewPort.TabIndex = 0;
			this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.viewPort_MouseDown);
			this.viewPort.MouseEnter += new System.EventHandler(this.viewPort_MouseEnter);
			this.viewPort.MouseLeave += new System.EventHandler(this.viewPort_MouseLeave);
			this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.viewPort_MouseMove);
			this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.viewPort_MouseUp);
			this.viewPort.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.viewPort_MouseWheel);
			// 
			// MainMenuStrip
			// 
			this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
			this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.MainMenuStrip.Name = "MainMenuStrip";
			this.MainMenuStrip.Size = new System.Drawing.Size(1272, 24);
			this.MainMenuStrip.TabIndex = 1;
			this.MainMenuStrip.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem2,
            this.открытьToolStripMenuItem2,
            this.сохранитьToolStripMenuItem2,
            this.сохранитьКакToolStripMenuItem2});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(49, 20);
			this.toolStripMenuItem1.Text = "Файл";
			// 
			// создатьToolStripMenuItem2
			// 
			this.создатьToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.оКToolStripMenuItem});
			this.создатьToolStripMenuItem2.Name = "создатьToolStripMenuItem2";
			this.создатьToolStripMenuItem2.Size = new System.Drawing.Size(166, 22);
			this.создатьToolStripMenuItem2.Text = "Создать";
			// 
			// toolStripComboBox1
			// 
			this.toolStripComboBox1.Items.AddRange(new object[] {
            "1x1",
            "1x2",
            "1x3",
            "1x4",
            "2x1",
            "3x1",
            "4x1",
            "2x2",
            "3x2",
            "4x2",
            "3x2",
            "3x3",
            "4x4"});
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
			// 
			// оКToolStripMenuItem
			// 
			this.оКToolStripMenuItem.Name = "оКToolStripMenuItem";
			this.оКToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.оКToolStripMenuItem.Text = "ОК";
			this.оКToolStripMenuItem.Click += new System.EventHandler(this.оКToolStripMenuItem_Click);
			// 
			// открытьToolStripMenuItem2
			// 
			this.открытьToolStripMenuItem2.Name = "открытьToolStripMenuItem2";
			this.открытьToolStripMenuItem2.Size = new System.Drawing.Size(166, 22);
			this.открытьToolStripMenuItem2.Text = "Открыть";
			// 
			// сохранитьToolStripMenuItem2
			// 
			this.сохранитьToolStripMenuItem2.Name = "сохранитьToolStripMenuItem2";
			this.сохранитьToolStripMenuItem2.Size = new System.Drawing.Size(166, 22);
			this.сохранитьToolStripMenuItem2.Text = "Сохранить";
			// 
			// сохранитьКакToolStripMenuItem2
			// 
			this.сохранитьКакToolStripMenuItem2.Name = "сохранитьКакToolStripMenuItem2";
			this.сохранитьКакToolStripMenuItem2.Size = new System.Drawing.Size(166, 22);
			this.сохранитьКакToolStripMenuItem2.Text = "Сохранить как...";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сброситьТрансформациюToolStripMenuItem2});
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(69, 20);
			this.toolStripMenuItem2.Text = "Вьюпорт";
			// 
			// сброситьТрансформациюToolStripMenuItem2
			// 
			this.сброситьТрансформациюToolStripMenuItem2.Name = "сброситьТрансформациюToolStripMenuItem2";
			this.сброситьТрансформациюToolStripMenuItem2.Size = new System.Drawing.Size(226, 22);
			this.сброситьТрансформациюToolStripMenuItem2.Text = "Сбросить трансформацию";
			this.сброситьТрансформациюToolStripMenuItem2.Click += new System.EventHandler(this.сброситьТрансформациюToolStripMenuItem_Click);
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// создатьToolStripMenuItem
			// 
			this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
			this.создатьToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.создатьToolStripMenuItem.Text = "Создать";
			// 
			// открытьToolStripMenuItem
			// 
			this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
			this.открытьToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.открытьToolStripMenuItem.Text = "Открыть";
			// 
			// сохранитьToolStripMenuItem
			// 
			this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
			this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.сохранитьToolStripMenuItem.Text = "Сохранить";
			// 
			// сохранитьКакToolStripMenuItem
			// 
			this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
			this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
			// 
			// вьюпортToolStripMenuItem
			// 
			this.вьюпортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сброситьТрансформациюToolStripMenuItem});
			this.вьюпортToolStripMenuItem.Name = "вьюпортToolStripMenuItem";
			this.вьюпортToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
			this.вьюпортToolStripMenuItem.Text = "Вьюпорт";
			// 
			// сброситьТрансформациюToolStripMenuItem
			// 
			this.сброситьТрансформациюToolStripMenuItem.Name = "сброситьТрансформациюToolStripMenuItem";
			this.сброситьТрансформациюToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
			this.сброситьТрансформациюToolStripMenuItem.Text = "Сбросить трансформацию";
			this.сброситьТрансформациюToolStripMenuItem.Click += new System.EventHandler(this.сброситьТрансформациюToolStripMenuItem_Click);
			// 
			// CreateWallButton
			// 
			this.CreateWallButton.Location = new System.Drawing.Point(4, 27);
			this.CreateWallButton.Name = "CreateWallButton";
			this.CreateWallButton.Size = new System.Drawing.Size(64, 32);
			this.CreateWallButton.TabIndex = 2;
			this.CreateWallButton.Text = "СС";
			this.CreateWallButton.UseVisualStyleBackColor = true;
			this.CreateWallButton.Click += new System.EventHandler(this.CreateWallButton_Click);
			// 
			// CreateHideButton
			// 
			this.CreateHideButton.Location = new System.Drawing.Point(74, 27);
			this.CreateHideButton.Name = "CreateHideButton";
			this.CreateHideButton.Size = new System.Drawing.Size(64, 32);
			this.CreateHideButton.TabIndex = 3;
			this.CreateHideButton.Text = "СПП";
			this.CreateHideButton.UseVisualStyleBackColor = true;
			this.CreateHideButton.Click += new System.EventHandler(this.CreateHideButton_Click);
			// 
			// EditWallButton
			// 
			this.EditWallButton.Location = new System.Drawing.Point(144, 27);
			this.EditWallButton.Name = "EditWallButton";
			this.EditWallButton.Size = new System.Drawing.Size(64, 32);
			this.EditWallButton.TabIndex = 4;
			this.EditWallButton.Text = "РСИП";
			this.EditWallButton.UseVisualStyleBackColor = true;
			// 
			// EditObjectButton
			// 
			this.EditObjectButton.Location = new System.Drawing.Point(214, 27);
			this.EditObjectButton.Name = "EditObjectButton";
			this.EditObjectButton.Size = new System.Drawing.Size(64, 32);
			this.EditObjectButton.TabIndex = 5;
			this.EditObjectButton.Text = "РО";
			this.EditObjectButton.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(4, 65);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(271, 218);
			this.panel1.TabIndex = 6;
			// 
			// infoLabel
			// 
			this.infoLabel.AutoSize = true;
			this.infoLabel.Location = new System.Drawing.Point(224, 286);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(47, 13);
			this.infoLabel.TabIndex = 0;
			this.infoLabel.Text = "dawdaw";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(4, 302);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(271, 256);
			this.tabControl1.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(263, 230);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(263, 230);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// файлToolStripMenuItem1
			// 
			this.файлToolStripMenuItem1.Name = "файлToolStripMenuItem1";
			this.файлToolStripMenuItem1.Size = new System.Drawing.Size(49, 20);
			this.файлToolStripMenuItem1.Text = "Файл";
			// 
			// создатьToolStripMenuItem1
			// 
			this.создатьToolStripMenuItem1.Name = "создатьToolStripMenuItem1";
			this.создатьToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
			this.создатьToolStripMenuItem1.Text = "Создать";
			// 
			// открытьToolStripMenuItem1
			// 
			this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
			this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
			this.открытьToolStripMenuItem1.Text = "Открыть";
			// 
			// сохранитьToolStripMenuItem1
			// 
			this.сохранитьToolStripMenuItem1.Name = "сохранитьToolStripMenuItem1";
			this.сохранитьToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
			this.сохранитьToolStripMenuItem1.Text = "Сохранить";
			// 
			// сохранитьКакToolStripMenuItem1
			// 
			this.сохранитьКакToolStripMenuItem1.Name = "сохранитьКакToolStripMenuItem1";
			this.сохранитьКакToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
			this.сохранитьКакToolStripMenuItem1.Text = "Сохранить как...";
			// 
			// вьюпортToolStripMenuItem1
			// 
			this.вьюпортToolStripMenuItem1.Name = "вьюпортToolStripMenuItem1";
			this.вьюпортToolStripMenuItem1.Size = new System.Drawing.Size(69, 20);
			this.вьюпортToolStripMenuItem1.Text = "Вьюпорт";
			// 
			// сброситьТрансформациюToolStripMenuItem1
			// 
			this.сброситьТрансформациюToolStripMenuItem1.Name = "сброситьТрансформациюToolStripMenuItem1";
			this.сброситьТрансформациюToolStripMenuItem1.Size = new System.Drawing.Size(226, 22);
			this.сброситьТрансформациюToolStripMenuItem1.Text = "Сбросить трансформацию";
			this.сброситьТрансформациюToolStripMenuItem1.Click += new System.EventHandler(this.сброситьТрансформациюToolStripMenuItem_Click);
			// 
			// XSymmetryBox
			// 
			this.XSymmetryBox.AutoSize = true;
			this.XSymmetryBox.Location = new System.Drawing.Point(67, 284);
			this.XSymmetryBox.Name = "XSymmetryBox";
			this.XSymmetryBox.Size = new System.Drawing.Size(33, 17);
			this.XSymmetryBox.TabIndex = 8;
			this.XSymmetryBox.Text = "X";
			this.XSymmetryBox.UseVisualStyleBackColor = true;
			// 
			// YSymmetryBox
			// 
			this.YSymmetryBox.AutoSize = true;
			this.YSymmetryBox.Location = new System.Drawing.Point(105, 284);
			this.YSymmetryBox.Name = "YSymmetryBox";
			this.YSymmetryBox.Size = new System.Drawing.Size(33, 17);
			this.YSymmetryBox.TabIndex = 9;
			this.YSymmetryBox.Text = "Y";
			this.YSymmetryBox.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1, 285);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Симметрия:";
			// 
			// XYSymmetryBox
			// 
			this.XYSymmetryBox.AutoSize = true;
			this.XYSymmetryBox.Location = new System.Drawing.Point(144, 284);
			this.XYSymmetryBox.Name = "XYSymmetryBox";
			this.XYSymmetryBox.Size = new System.Drawing.Size(40, 17);
			this.XYSymmetryBox.TabIndex = 11;
			this.XYSymmetryBox.Text = "XY";
			this.XYSymmetryBox.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1272, 556);
			this.Controls.Add(this.XYSymmetryBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.YSymmetryBox);
			this.Controls.Add(this.XSymmetryBox);
			this.Controls.Add(this.infoLabel);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.EditObjectButton);
			this.Controls.Add(this.EditWallButton);
			this.Controls.Add(this.CreateHideButton);
			this.Controls.Add(this.CreateWallButton);
			this.Controls.Add(this.viewPort);
			this.Controls.Add(this.MainMenuStrip);
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "Rooms Editor [0.1]";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			this.MainMenuStrip.ResumeLayout(false);
			this.MainMenuStrip.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip MainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
		public Tao.Platform.Windows.SimpleOpenGlControl viewPort;
		private System.Windows.Forms.ToolStripMenuItem вьюпортToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сброситьТрансформациюToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
		private System.Windows.Forms.Button CreateWallButton;
		private System.Windows.Forms.Button CreateHideButton;
		private System.Windows.Forms.Button EditWallButton;
		private System.Windows.Forms.Button EditObjectButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem вьюпортToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem сброситьТрансформациюToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem2;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
		private System.Windows.Forms.ToolStripMenuItem оКToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem сброситьТрансформациюToolStripMenuItem2;
		public System.Windows.Forms.Label infoLabel;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.CheckBox XSymmetryBox;
		public System.Windows.Forms.CheckBox YSymmetryBox;
		public System.Windows.Forms.CheckBox XYSymmetryBox;
	}
}

