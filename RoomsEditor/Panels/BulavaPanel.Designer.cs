namespace RoomsEditor.Panels {
	partial class BulavaPanel {
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.speedLabel = new System.Windows.Forms.Label();
			this.typeCombo = new System.Windows.Forms.ComboBox();
			this.countBox = new System.Windows.Forms.TextBox();
			this.speedBox = new System.Windows.Forms.TextBox();
			this.angleSpeedBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.maxDistanceBox = new System.Windows.Forms.TextBox();
			this.velocityAxisCombo = new System.Windows.Forms.ComboBox();
			this.okButton = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.startDistanceBox = new System.Windows.Forms.TextBox();
			this.startAngleBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Тип вращения";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Количество тайлов";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(174, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Угловая скорость (градусы/сек)";
			// 
			// speedLabel
			// 
			this.speedLabel.AutoSize = true;
			this.speedLabel.Location = new System.Drawing.Point(3, 118);
			this.speedLabel.Name = "speedLabel";
			this.speedLabel.Size = new System.Drawing.Size(129, 13);
			this.speedLabel.TabIndex = 3;
			this.speedLabel.Text = "Скорость (пиксели/сек)";
			// 
			// typeCombo
			// 
			this.typeCombo.FormattingEnabled = true;
			this.typeCombo.Items.AddRange(new object[] {
            "Отсутствует",
            "Качание",
            "Полный оборот"});
			this.typeCombo.Location = new System.Drawing.Point(89, 36);
			this.typeCombo.Name = "typeCombo";
			this.typeCombo.Size = new System.Drawing.Size(178, 21);
			this.typeCombo.TabIndex = 4;
			this.typeCombo.Text = "Отсутствует";
			// 
			// countBox
			// 
			this.countBox.Location = new System.Drawing.Point(113, 6);
			this.countBox.Name = "countBox";
			this.countBox.Size = new System.Drawing.Size(40, 20);
			this.countBox.TabIndex = 5;
			this.countBox.Text = "0";
			// 
			// speedBox
			// 
			this.speedBox.Location = new System.Drawing.Point(138, 115);
			this.speedBox.Name = "speedBox";
			this.speedBox.Size = new System.Drawing.Size(40, 20);
			this.speedBox.TabIndex = 7;
			this.speedBox.Text = "0";
			// 
			// angleSpeedBox
			// 
			this.angleSpeedBox.Location = new System.Drawing.Point(183, 63);
			this.angleSpeedBox.Name = "angleSpeedBox";
			this.angleSpeedBox.Size = new System.Drawing.Size(40, 20);
			this.angleSpeedBox.TabIndex = 8;
			this.angleSpeedBox.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 97);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Ось движения";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(140, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Максимальная дистанция";
			// 
			// maxDistanceBox
			// 
			this.maxDistanceBox.Location = new System.Drawing.Point(149, 141);
			this.maxDistanceBox.Name = "maxDistanceBox";
			this.maxDistanceBox.Size = new System.Drawing.Size(40, 20);
			this.maxDistanceBox.TabIndex = 11;
			this.maxDistanceBox.Text = "0";
			// 
			// velocityAxisCombo
			// 
			this.velocityAxisCombo.FormattingEnabled = true;
			this.velocityAxisCombo.Items.AddRange(new object[] {
            "0",
            "X",
            "Y"});
			this.velocityAxisCombo.Location = new System.Drawing.Point(89, 94);
			this.velocityAxisCombo.Name = "velocityAxisCombo";
			this.velocityAxisCombo.Size = new System.Drawing.Size(40, 21);
			this.velocityAxisCombo.TabIndex = 12;
			this.velocityAxisCombo.Text = "0";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(192, 139);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 13;
			this.okButton.Text = "Задать";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(189, 102);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(31, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Путь";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(230, 102);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "Угол";
			// 
			// startDistanceBox
			// 
			this.startDistanceBox.Location = new System.Drawing.Point(192, 115);
			this.startDistanceBox.Name = "startDistanceBox";
			this.startDistanceBox.Size = new System.Drawing.Size(35, 20);
			this.startDistanceBox.TabIndex = 16;
			this.startDistanceBox.Text = "0";
			// 
			// startAngleBox
			// 
			this.startAngleBox.Location = new System.Drawing.Point(233, 115);
			this.startAngleBox.Name = "startAngleBox";
			this.startAngleBox.Size = new System.Drawing.Size(34, 20);
			this.startAngleBox.TabIndex = 17;
			this.startAngleBox.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(198, 89);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 13);
			this.label8.TabIndex = 18;
			this.label8.Text = "Начальный";
			// 
			// BulavaPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label8);
			this.Controls.Add(this.startAngleBox);
			this.Controls.Add(this.startDistanceBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.velocityAxisCombo);
			this.Controls.Add(this.maxDistanceBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.angleSpeedBox);
			this.Controls.Add(this.speedBox);
			this.Controls.Add(this.countBox);
			this.Controls.Add(this.typeCombo);
			this.Controls.Add(this.speedLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "BulavaPanel";
			this.Size = new System.Drawing.Size(270, 170);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label speedLabel;
		private System.Windows.Forms.ComboBox typeCombo;
		private System.Windows.Forms.TextBox countBox;
		private System.Windows.Forms.TextBox speedBox;
		private System.Windows.Forms.TextBox angleSpeedBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox maxDistanceBox;
		private System.Windows.Forms.ComboBox velocityAxisCombo;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox startDistanceBox;
		private System.Windows.Forms.TextBox startAngleBox;
		private System.Windows.Forms.Label label8;
	}
}
