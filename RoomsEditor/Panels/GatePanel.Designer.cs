namespace RoomsEditor.Panels {
	partial class GatePanel {
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

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.typeBox = new System.Windows.Forms.ComboBox();
			this.gateDataTab = new System.Windows.Forms.TabControl();
			this.tabPage = new System.Windows.Forms.TabPage();
			this.existsList = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.unexistsList = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.setTypeButton = new System.Windows.Forms.Button();
			this.infoButton = new System.Windows.Forms.Button();
			this.selectButton = new System.Windows.Forms.Button();
			this.testRoomButton = new System.Windows.Forms.Button();
			this.gateDataTab.SuspendLayout();
			this.tabPage.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Тип:";
			// 
			// typeBox
			// 
			this.typeBox.FormattingEnabled = true;
			this.typeBox.Location = new System.Drawing.Point(35, 7);
			this.typeBox.Name = "typeBox";
			this.typeBox.Size = new System.Drawing.Size(154, 21);
			this.typeBox.TabIndex = 1;
			// 
			// gateDataTab
			// 
			this.gateDataTab.Controls.Add(this.tabPage);
			this.gateDataTab.Controls.Add(this.tabPage2);
			this.gateDataTab.Location = new System.Drawing.Point(6, 51);
			this.gateDataTab.Name = "gateDataTab";
			this.gateDataTab.SelectedIndex = 0;
			this.gateDataTab.Size = new System.Drawing.Size(261, 116);
			this.gateDataTab.TabIndex = 2;
			// 
			// tabPage
			// 
			this.tabPage.Controls.Add(this.existsList);
			this.tabPage.Location = new System.Drawing.Point(4, 22);
			this.tabPage.Name = "tabPage";
			this.tabPage.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage.Size = new System.Drawing.Size(253, 90);
			this.tabPage.TabIndex = 0;
			this.tabPage.Text = "Существовании прохода";
			this.tabPage.UseVisualStyleBackColor = true;
			// 
			// existsList
			// 
			this.existsList.FormattingEnabled = true;
			this.existsList.Location = new System.Drawing.Point(0, 0);
			this.existsList.Name = "existsList";
			this.existsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.existsList.Size = new System.Drawing.Size(253, 95);
			this.existsList.TabIndex = 0;
			this.existsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.existsList_KeyDown);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.unexistsList);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(253, 90);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Отсутствии прохода";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// unexistsList
			// 
			this.unexistsList.FormattingEnabled = true;
			this.unexistsList.Location = new System.Drawing.Point(0, -2);
			this.unexistsList.Name = "unexistsList";
			this.unexistsList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.unexistsList.Size = new System.Drawing.Size(253, 95);
			this.unexistsList.TabIndex = 1;
			this.unexistsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.unexistsList_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(174, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Убрать заданные объекты при...";
			// 
			// setTypeButton
			// 
			this.setTypeButton.Location = new System.Drawing.Point(195, 7);
			this.setTypeButton.Name = "setTypeButton";
			this.setTypeButton.Size = new System.Drawing.Size(30, 23);
			this.setTypeButton.TabIndex = 4;
			this.setTypeButton.Text = "ОК";
			this.setTypeButton.UseVisualStyleBackColor = true;
			this.setTypeButton.Click += new System.EventHandler(this.setTypeButton_Click);
			// 
			// infoButton
			// 
			this.infoButton.Location = new System.Drawing.Point(244, 31);
			this.infoButton.Name = "infoButton";
			this.infoButton.Size = new System.Drawing.Size(26, 21);
			this.infoButton.TabIndex = 5;
			this.infoButton.Text = "?";
			this.infoButton.UseVisualStyleBackColor = true;
			this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
			// 
			// selectButton
			// 
			this.selectButton.Location = new System.Drawing.Point(183, 31);
			this.selectButton.Name = "selectButton";
			this.selectButton.Size = new System.Drawing.Size(61, 21);
			this.selectButton.TabIndex = 6;
			this.selectButton.Text = "Выбрать";
			this.selectButton.UseVisualStyleBackColor = true;
			this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
			this.selectButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.selectButton_KeyDown);
			this.selectButton.Leave += new System.EventHandler(this.selectButton_Leave);
			// 
			// testRoomButton
			// 
			this.testRoomButton.Location = new System.Drawing.Point(227, 7);
			this.testRoomButton.Name = "testRoomButton";
			this.testRoomButton.Size = new System.Drawing.Size(39, 23);
			this.testRoomButton.TabIndex = 7;
			this.testRoomButton.Text = "Тест";
			this.testRoomButton.UseVisualStyleBackColor = true;
			this.testRoomButton.Click += new System.EventHandler(this.testRoomButton_Click);
			// 
			// GatePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.testRoomButton);
			this.Controls.Add(this.selectButton);
			this.Controls.Add(this.infoButton);
			this.Controls.Add(this.setTypeButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.gateDataTab);
			this.Controls.Add(this.typeBox);
			this.Controls.Add(this.label1);
			this.Name = "GatePanel";
			this.Size = new System.Drawing.Size(270, 170);
			this.gateDataTab.ResumeLayout(false);
			this.tabPage.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox typeBox;
		private System.Windows.Forms.TabPage tabPage;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button setTypeButton;
		private System.Windows.Forms.Button infoButton;
		private System.Windows.Forms.Button selectButton;
		public System.Windows.Forms.TabControl gateDataTab;
		public System.Windows.Forms.ListBox existsList;
		public System.Windows.Forms.ListBox unexistsList;
		private System.Windows.Forms.Button testRoomButton;
	}
}
