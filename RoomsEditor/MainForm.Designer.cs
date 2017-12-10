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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainTab = new System.Windows.Forms.TabControl();
			this.roomsMode = new System.Windows.Forms.TabPage();
			this.hideMode = new System.Windows.Forms.TabPage();
			this.createMode = new System.Windows.Forms.TabPage();
			this.editMode = new System.Windows.Forms.TabPage();
			DrawTimer = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1.SuspendLayout();
			this.MainTab.SuspendLayout();
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
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1272, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
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
			// MainTab
			// 
			this.MainTab.Alignment = System.Windows.Forms.TabAlignment.Right;
			this.MainTab.Controls.Add(this.roomsMode);
			this.MainTab.Controls.Add(this.hideMode);
			this.MainTab.Controls.Add(this.createMode);
			this.MainTab.Controls.Add(this.editMode);
			this.MainTab.Location = new System.Drawing.Point(0, 27);
			this.MainTab.Margin = new System.Windows.Forms.Padding(0);
			this.MainTab.Multiline = true;
			this.MainTab.Name = "MainTab";
			this.MainTab.Padding = new System.Drawing.Point(0, 0);
			this.MainTab.SelectedIndex = 0;
			this.MainTab.Size = new System.Drawing.Size(275, 531);
			this.MainTab.TabIndex = 2;
			// 
			// roomsMode
			// 
			this.roomsMode.Location = new System.Drawing.Point(4, 4);
			this.roomsMode.Margin = new System.Windows.Forms.Padding(0);
			this.roomsMode.Name = "roomsMode";
			this.roomsMode.Size = new System.Drawing.Size(248, 523);
			this.roomsMode.TabIndex = 0;
			this.roomsMode.Text = "Комнаты";
			this.roomsMode.UseVisualStyleBackColor = true;
			// 
			// hideMode
			// 
			this.hideMode.Location = new System.Drawing.Point(4, 4);
			this.hideMode.Margin = new System.Windows.Forms.Padding(0);
			this.hideMode.Name = "hideMode";
			this.hideMode.Size = new System.Drawing.Size(248, 523);
			this.hideMode.TabIndex = 1;
			this.hideMode.Text = "Тайники";
			this.hideMode.UseVisualStyleBackColor = true;
			// 
			// createMode
			// 
			this.createMode.Location = new System.Drawing.Point(4, 4);
			this.createMode.Name = "createMode";
			this.createMode.Padding = new System.Windows.Forms.Padding(3);
			this.createMode.Size = new System.Drawing.Size(248, 523);
			this.createMode.TabIndex = 2;
			this.createMode.Text = "Создание объектов";
			this.createMode.UseVisualStyleBackColor = true;
			// 
			// editMode
			// 
			this.editMode.Location = new System.Drawing.Point(4, 4);
			this.editMode.Name = "editMode";
			this.editMode.Padding = new System.Windows.Forms.Padding(3);
			this.editMode.Size = new System.Drawing.Size(248, 523);
			this.editMode.TabIndex = 3;
			this.editMode.Text = "Редактирование объектов";
			this.editMode.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1272, 556);
			this.Controls.Add(this.MainTab);
			this.Controls.Add(this.viewPort);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Rooms Editor [0.1]";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.MainTab.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
		private System.Windows.Forms.TabControl MainTab;
		private System.Windows.Forms.TabPage roomsMode;
		private System.Windows.Forms.TabPage hideMode;
		private System.Windows.Forms.TabPage createMode;
		private System.Windows.Forms.TabPage editMode;
		public Tao.Platform.Windows.SimpleOpenGlControl viewPort;
	}
}

