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
			System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Объекты", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Декорации", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Инструменты", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Остальное", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("Катакомбы", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("Шахты", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Ад", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.viewPort = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.создатьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
			this.оКToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.сброситьТрансформациюToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.переключитьФонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.тестНаВыбранномОбъектеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.objectTransformPanel = new System.Windows.Forms.Panel();
			this.renderTypeBox = new System.Windows.Forms.ComboBox();
			this.renderTypeLabel = new System.Windows.Forms.Label();
			this.objectYSizeLabel = new System.Windows.Forms.Label();
			this.objectXSizeLabel = new System.Windows.Forms.Label();
			this.objectYCoordsLabel = new System.Windows.Forms.Label();
			this.objectMirrorYBox = new System.Windows.Forms.CheckBox();
			this.objectMirrorXBox = new System.Windows.Forms.CheckBox();
			this.objectXCoordsLabel = new System.Windows.Forms.Label();
			this.objectNameLabel = new System.Windows.Forms.Label();
			this.infoLabel = new System.Windows.Forms.Label();
			this.ObjectsView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.backUpState = new System.Windows.Forms.CheckBox();
			this.BackUpTimer = new System.Windows.Forms.Timer(this.components);
			this.сохранитьКакToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			DrawTimer = new System.Windows.Forms.Timer(this.components);
			this.MainMenuStrip.SuspendLayout();
			this.objectTransformPanel.SuspendLayout();
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
            this.toolStripComboBox2,
            this.оКToolStripMenuItem});
			this.создатьToolStripMenuItem2.Name = "создатьToolStripMenuItem2";
			this.создатьToolStripMenuItem2.Size = new System.Drawing.Size(157, 22);
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
            "2x3",
            "4x2",
            "3x2",
            "3x3",
            "4x4"});
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
			// 
			// toolStripComboBox2
			// 
			this.toolStripComboBox2.Items.AddRange(new object[] {
            "Универсальная",
            "Катакомбы",
            "Шахты",
            "Ад"});
			this.toolStripComboBox2.Name = "toolStripComboBox2";
			this.toolStripComboBox2.Size = new System.Drawing.Size(121, 23);
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
			this.открытьToolStripMenuItem2.Size = new System.Drawing.Size(157, 22);
			this.открытьToolStripMenuItem2.Text = "Открыть";
			this.открытьToolStripMenuItem2.Click += new System.EventHandler(this.открытьToolStripMenuItem2_Click);
			// 
			// сохранитьToolStripMenuItem2
			// 
			this.сохранитьToolStripMenuItem2.Enabled = false;
			this.сохранитьToolStripMenuItem2.Name = "сохранитьToolStripMenuItem2";
			this.сохранитьToolStripMenuItem2.Size = new System.Drawing.Size(157, 22);
			this.сохранитьToolStripMenuItem2.Text = "Сохранить";
			this.сохранитьToolStripMenuItem2.Click += new System.EventHandler(this.сохранитьToolStripMenuItem2_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сброситьТрансформациюToolStripMenuItem2,
            this.переключитьФонToolStripMenuItem,
            this.тестНаВыбранномОбъектеToolStripMenuItem});
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(69, 20);
			this.toolStripMenuItem2.Text = "Вьюпорт";
			// 
			// сброситьТрансформациюToolStripMenuItem2
			// 
			this.сброситьТрансформациюToolStripMenuItem2.Name = "сброситьТрансформациюToolStripMenuItem2";
			this.сброситьТрансформациюToolStripMenuItem2.Size = new System.Drawing.Size(234, 22);
			this.сброситьТрансформациюToolStripMenuItem2.Text = "Сбросить трансформацию";
			this.сброситьТрансформациюToolStripMenuItem2.Click += new System.EventHandler(this.сброситьТрансформациюToolStripMenuItem_Click);
			// 
			// переключитьФонToolStripMenuItem
			// 
			this.переключитьФонToolStripMenuItem.Name = "переключитьФонToolStripMenuItem";
			this.переключитьФонToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.переключитьФонToolStripMenuItem.Text = "Переключить фон";
			this.переключитьФонToolStripMenuItem.Click += new System.EventHandler(this.переключитьФонToolStripMenuItem_Click);
			// 
			// тестНаВыбранномОбъектеToolStripMenuItem
			// 
			this.тестНаВыбранномОбъектеToolStripMenuItem.Name = "тестНаВыбранномОбъектеToolStripMenuItem";
			this.тестНаВыбранномОбъектеToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.тестНаВыбранномОбъектеToolStripMenuItem.Text = "Тест на выбранном объекте";
			this.тестНаВыбранномОбъектеToolStripMenuItem.Click += new System.EventHandler(this.тестНаВыбранномОбъектеToolStripMenuItem_Click);
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
			this.CreateWallButton.BackgroundImage = global::RoomsEditor.Properties.Resources.wallTool;
			this.CreateWallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CreateWallButton.Location = new System.Drawing.Point(4, 27);
			this.CreateWallButton.Margin = new System.Windows.Forms.Padding(0);
			this.CreateWallButton.Name = "CreateWallButton";
			this.CreateWallButton.Size = new System.Drawing.Size(64, 32);
			this.CreateWallButton.TabIndex = 2;
			this.CreateWallButton.UseVisualStyleBackColor = true;
			this.CreateWallButton.Click += new System.EventHandler(this.CreateWallButton_Click);
			// 
			// CreateHideButton
			// 
			this.CreateHideButton.BackgroundImage = global::RoomsEditor.Properties.Resources.hildenWallTool;
			this.CreateHideButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.CreateHideButton.Location = new System.Drawing.Point(74, 27);
			this.CreateHideButton.Name = "CreateHideButton";
			this.CreateHideButton.Size = new System.Drawing.Size(64, 32);
			this.CreateHideButton.TabIndex = 3;
			this.CreateHideButton.UseVisualStyleBackColor = true;
			this.CreateHideButton.Click += new System.EventHandler(this.CreateHideButton_Click);
			// 
			// EditWallButton
			// 
			this.EditWallButton.BackgroundImage = global::RoomsEditor.Properties.Resources.editWallTool;
			this.EditWallButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.EditWallButton.Location = new System.Drawing.Point(144, 27);
			this.EditWallButton.Name = "EditWallButton";
			this.EditWallButton.Size = new System.Drawing.Size(64, 32);
			this.EditWallButton.TabIndex = 4;
			this.EditWallButton.UseVisualStyleBackColor = true;
			this.EditWallButton.Click += new System.EventHandler(this.EditWallButton_Click);
			// 
			// EditObjectButton
			// 
			this.EditObjectButton.BackgroundImage = global::RoomsEditor.Properties.Resources.editObjectTool;
			this.EditObjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.EditObjectButton.Location = new System.Drawing.Point(214, 27);
			this.EditObjectButton.Name = "EditObjectButton";
			this.EditObjectButton.Size = new System.Drawing.Size(64, 32);
			this.EditObjectButton.TabIndex = 5;
			this.EditObjectButton.UseVisualStyleBackColor = true;
			this.EditObjectButton.Click += new System.EventHandler(this.EditObjectButton_Click);
			// 
			// objectTransformPanel
			// 
			this.objectTransformPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.objectTransformPanel.Controls.Add(this.renderTypeBox);
			this.objectTransformPanel.Controls.Add(this.renderTypeLabel);
			this.objectTransformPanel.Controls.Add(this.objectYSizeLabel);
			this.objectTransformPanel.Controls.Add(this.objectXSizeLabel);
			this.objectTransformPanel.Controls.Add(this.objectYCoordsLabel);
			this.objectTransformPanel.Controls.Add(this.objectMirrorYBox);
			this.objectTransformPanel.Controls.Add(this.objectMirrorXBox);
			this.objectTransformPanel.Controls.Add(this.objectXCoordsLabel);
			this.objectTransformPanel.Controls.Add(this.objectNameLabel);
			this.objectTransformPanel.Location = new System.Drawing.Point(4, 237);
			this.objectTransformPanel.Name = "objectTransformPanel";
			this.objectTransformPanel.Size = new System.Drawing.Size(271, 45);
			this.objectTransformPanel.TabIndex = 6;
			this.objectTransformPanel.Visible = false;
			// 
			// renderTypeBox
			// 
			this.renderTypeBox.FormattingEnabled = true;
			this.renderTypeBox.Location = new System.Drawing.Point(188, 16);
			this.renderTypeBox.Name = "renderTypeBox";
			this.renderTypeBox.Size = new System.Drawing.Size(35, 21);
			this.renderTypeBox.TabIndex = 16;
			this.renderTypeBox.SelectedIndexChanged += new System.EventHandler(this.TypeBox_SelectedIndexChanged);
			// 
			// renderTypeLabel
			// 
			this.renderTypeLabel.AutoSize = true;
			this.renderTypeLabel.Location = new System.Drawing.Point(188, 0);
			this.renderTypeLabel.Name = "renderTypeLabel";
			this.renderTypeLabel.Size = new System.Drawing.Size(31, 13);
			this.renderTypeLabel.TabIndex = 15;
			this.renderTypeLabel.Text = "Type";
			// 
			// objectYSizeLabel
			// 
			this.objectYSizeLabel.AutoSize = true;
			this.objectYSizeLabel.Location = new System.Drawing.Point(98, 29);
			this.objectYSizeLabel.Name = "objectYSizeLabel";
			this.objectYSizeLabel.Size = new System.Drawing.Size(26, 13);
			this.objectYSizeLabel.TabIndex = 14;
			this.objectYSizeLabel.Text = "WH";
			// 
			// objectXSizeLabel
			// 
			this.objectXSizeLabel.AutoSize = true;
			this.objectXSizeLabel.Location = new System.Drawing.Point(98, 13);
			this.objectXSizeLabel.Name = "objectXSizeLabel";
			this.objectXSizeLabel.Size = new System.Drawing.Size(26, 13);
			this.objectXSizeLabel.TabIndex = 2;
			this.objectXSizeLabel.Text = "WH";
			// 
			// objectYCoordsLabel
			// 
			this.objectYCoordsLabel.AutoSize = true;
			this.objectYCoordsLabel.Location = new System.Drawing.Point(2, 29);
			this.objectYCoordsLabel.Name = "objectYCoordsLabel";
			this.objectYCoordsLabel.Size = new System.Drawing.Size(34, 13);
			this.objectYCoordsLabel.TabIndex = 13;
			this.objectYCoordsLabel.Text = "coord";
			// 
			// objectMirrorYBox
			// 
			this.objectMirrorYBox.AutoSize = true;
			this.objectMirrorYBox.Location = new System.Drawing.Point(235, 25);
			this.objectMirrorYBox.Name = "objectMirrorYBox";
			this.objectMirrorYBox.Size = new System.Drawing.Size(33, 17);
			this.objectMirrorYBox.TabIndex = 12;
			this.objectMirrorYBox.Text = "Y";
			this.objectMirrorYBox.UseVisualStyleBackColor = true;
			this.objectMirrorYBox.CheckedChanged += new System.EventHandler(this.objectMirrorYBox_CheckedChanged);
			// 
			// objectMirrorXBox
			// 
			this.objectMirrorXBox.AutoSize = true;
			this.objectMirrorXBox.Location = new System.Drawing.Point(235, 3);
			this.objectMirrorXBox.Name = "objectMirrorXBox";
			this.objectMirrorXBox.Size = new System.Drawing.Size(33, 17);
			this.objectMirrorXBox.TabIndex = 12;
			this.objectMirrorXBox.Text = "X";
			this.objectMirrorXBox.UseVisualStyleBackColor = true;
			this.objectMirrorXBox.CheckedChanged += new System.EventHandler(this.objectMirrorXBox_CheckedChanged);
			// 
			// objectXCoordsLabel
			// 
			this.objectXCoordsLabel.AutoSize = true;
			this.objectXCoordsLabel.Location = new System.Drawing.Point(3, 13);
			this.objectXCoordsLabel.Name = "objectXCoordsLabel";
			this.objectXCoordsLabel.Size = new System.Drawing.Size(34, 13);
			this.objectXCoordsLabel.TabIndex = 1;
			this.objectXCoordsLabel.Text = "coord";
			// 
			// objectNameLabel
			// 
			this.objectNameLabel.AllowDrop = true;
			this.objectNameLabel.AutoSize = true;
			this.objectNameLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.objectNameLabel.Location = new System.Drawing.Point(3, 0);
			this.objectNameLabel.Name = "objectNameLabel";
			this.objectNameLabel.Size = new System.Drawing.Size(33, 13);
			this.objectNameLabel.TabIndex = 0;
			this.objectNameLabel.Text = "name";
			// 
			// infoLabel
			// 
			this.infoLabel.AutoSize = true;
			this.infoLabel.Location = new System.Drawing.Point(190, 285);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(40, 13);
			this.infoLabel.TabIndex = 0;
			this.infoLabel.Text = "Coords";
			this.infoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ObjectsView
			// 
			this.ObjectsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			listViewGroup8.Header = "Объекты";
			listViewGroup8.Name = "Объекты";
			listViewGroup9.Header = "Декорации";
			listViewGroup9.Name = "Декорации";
			listViewGroup10.Header = "Инструменты";
			listViewGroup10.Name = "Инструменты";
			listViewGroup11.Header = "Остальное";
			listViewGroup11.Name = "Остальное";
			listViewGroup12.Header = "Катакомбы";
			listViewGroup12.Name = "Катакомбы";
			listViewGroup13.Header = "Шахты";
			listViewGroup13.Name = "Шахты";
			listViewGroup14.Header = "Ад";
			listViewGroup14.Name = "Ад";
			this.ObjectsView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup8,
            listViewGroup9,
            listViewGroup10,
            listViewGroup11,
            listViewGroup12,
            listViewGroup13,
            listViewGroup14});
			this.ObjectsView.Location = new System.Drawing.Point(0, 301);
			this.ObjectsView.MultiSelect = false;
			this.ObjectsView.Name = "ObjectsView";
			this.ObjectsView.Size = new System.Drawing.Size(278, 257);
			this.ObjectsView.TabIndex = 0;
			this.ObjectsView.UseCompatibleStateImageBehavior = false;
			this.ObjectsView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ObjectsView_MouseDoubleClick);
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
			this.XSymmetryBox.CheckedChanged += new System.EventHandler(this.XSymmetryBox_CheckedChanged);
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
			this.YSymmetryBox.CheckedChanged += new System.EventHandler(this.YSymmetryBox_CheckedChanged);
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
			this.XYSymmetryBox.CheckedChanged += new System.EventHandler(this.XYSymmetryBox_CheckedChanged);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "JSON files|*.json";
			this.openFileDialog.RestoreDirectory = true;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "JSON files|*.json";
			this.saveFileDialog.RestoreDirectory = true;
			// 
			// backUpState
			// 
			this.backUpState.AutoSize = true;
			this.backUpState.Checked = true;
			this.backUpState.CheckState = System.Windows.Forms.CheckState.Checked;
			this.backUpState.Location = new System.Drawing.Point(196, 4);
			this.backUpState.Name = "backUpState";
			this.backUpState.Size = new System.Drawing.Size(74, 17);
			this.backUpState.TabIndex = 12;
			this.backUpState.Text = "Бекапить";
			this.backUpState.UseVisualStyleBackColor = true;
			this.backUpState.CheckedChanged += new System.EventHandler(this.backUpState_CheckedChanged);
			// 
			// BackUpTimer
			// 
			this.BackUpTimer.Enabled = true;
			this.BackUpTimer.Interval = 30000;
			this.BackUpTimer.Tick += new System.EventHandler(this.BackUpTimer_Tick);
			// 
			// сохранитьКакToolStripMenuItem2
			// 
			this.сохранитьКакToolStripMenuItem2.Enabled = false;
			this.сохранитьКакToolStripMenuItem2.Name = "сохранитьКакToolStripMenuItem2";
			this.сохранитьКакToolStripMenuItem2.Size = new System.Drawing.Size(157, 22);
			this.сохранитьКакToolStripMenuItem2.Text = "Сохранить как";
			this.сохранитьКакToolStripMenuItem2.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem2_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1272, 556);
			this.Controls.Add(this.backUpState);
			this.Controls.Add(this.ObjectsView);
			this.Controls.Add(this.XYSymmetryBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.YSymmetryBox);
			this.Controls.Add(this.XSymmetryBox);
			this.Controls.Add(this.infoLabel);
			this.Controls.Add(this.objectTransformPanel);
			this.Controls.Add(this.EditObjectButton);
			this.Controls.Add(this.EditWallButton);
			this.Controls.Add(this.CreateHideButton);
			this.Controls.Add(this.CreateWallButton);
			this.Controls.Add(this.viewPort);
			this.Controls.Add(this.MainMenuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Rooms Editor [1.0]";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			this.MainMenuStrip.ResumeLayout(false);
			this.MainMenuStrip.PerformLayout();
			this.objectTransformPanel.ResumeLayout(false);
			this.objectTransformPanel.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem сброситьТрансформациюToolStripMenuItem2;
		public System.Windows.Forms.Label infoLabel;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.CheckBox XSymmetryBox;
		public System.Windows.Forms.CheckBox YSymmetryBox;
		public System.Windows.Forms.CheckBox XYSymmetryBox;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		public System.Windows.Forms.ListView ObjectsView;
		public System.Windows.Forms.Panel objectTransformPanel;
		public System.Windows.Forms.Label objectNameLabel;
		public System.Windows.Forms.CheckBox objectMirrorYBox;
		public System.Windows.Forms.CheckBox objectMirrorXBox;
		public System.Windows.Forms.Label objectXCoordsLabel;
		public System.Windows.Forms.Label objectXSizeLabel;
		public System.Windows.Forms.Label objectYCoordsLabel;
		public System.Windows.Forms.Label objectYSizeLabel;
		public System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem2;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripMenuItem переключитьФонToolStripMenuItem;
		public System.Windows.Forms.ComboBox renderTypeBox;
		public System.Windows.Forms.Label renderTypeLabel;
		private System.Windows.Forms.ToolStripMenuItem тестНаВыбранномОбъектеToolStripMenuItem;
		private System.Windows.Forms.CheckBox backUpState;
		private System.Windows.Forms.Timer BackUpTimer;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
		private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem2;
	}
}

