namespace RoomsEditor {
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
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
			this.infoLabel = new System.Windows.Forms.Label();
			DrawTimer = new System.Windows.Forms.Timer(this.components);
			this.MainMenuStrip.SuspendLayout();
			this.panel1.SuspendLayout();
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
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(4, 27);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 32);
			this.button1.TabIndex = 2;
			this.button1.Text = "СС";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(74, 27);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 32);
			this.button2.TabIndex = 3;
			this.button2.Text = "СПП";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(144, 27);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 32);
			this.button3.TabIndex = 4;
			this.button3.Text = "РСИП";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(214, 27);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(64, 32);
			this.button4.TabIndex = 5;
			this.button4.Text = "РО";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.infoLabel);
			this.panel1.Location = new System.Drawing.Point(4, 65);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(271, 231);
			this.panel1.TabIndex = 6;
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
			// infoLabel
			// 
			this.infoLabel.AutoSize = true;
			this.infoLabel.Location = new System.Drawing.Point(3, 215);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(0, 13);
			this.infoLabel.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1272, 556);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
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
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
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
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
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
	}
}

