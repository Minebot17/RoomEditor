namespace RoomsEditor.Panels {
	partial class StairPanel {
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
			this.okButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.widthBox = new System.Windows.Forms.TextBox();
			this.typeCombo = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.timeBox = new System.Windows.Forms.TextBox();
			this.endersCheck = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ширина";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(192, 93);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 4;
			this.okButton.Text = "Задать";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(26, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Тип";
			// 
			// widthBox
			// 
			this.widthBox.Location = new System.Drawing.Point(65, 67);
			this.widthBox.Name = "widthBox";
			this.widthBox.Size = new System.Drawing.Size(202, 20);
			this.widthBox.TabIndex = 6;
			// 
			// typeCombo
			// 
			this.typeCombo.FormattingEnabled = true;
			this.typeCombo.Items.AddRange(new object[] {
            "Постоянная",
            "Исчезающая",
            "Ломающаяся"});
			this.typeCombo.Location = new System.Drawing.Point(45, 12);
			this.typeCombo.Name = "typeCombo";
			this.typeCombo.Size = new System.Drawing.Size(222, 21);
			this.typeCombo.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(151, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Задержка в появлении (сек)";
			// 
			// timeBox
			// 
			this.timeBox.Location = new System.Drawing.Point(167, 36);
			this.timeBox.Name = "timeBox";
			this.timeBox.Size = new System.Drawing.Size(100, 20);
			this.timeBox.TabIndex = 10;
			// 
			// endersCheck
			// 
			this.endersCheck.AutoSize = true;
			this.endersCheck.Location = new System.Drawing.Point(16, 93);
			this.endersCheck.Name = "endersCheck";
			this.endersCheck.Size = new System.Drawing.Size(93, 17);
			this.endersCheck.TabIndex = 11;
			this.endersCheck.Text = "Наконечники";
			this.endersCheck.UseVisualStyleBackColor = true;
			// 
			// StairPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.endersCheck);
			this.Controls.Add(this.timeBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.typeCombo);
			this.Controls.Add(this.widthBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.label1);
			this.Name = "StairPanel";
			this.Size = new System.Drawing.Size(270, 170);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox widthBox;
		private System.Windows.Forms.ComboBox typeCombo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox timeBox;
		private System.Windows.Forms.CheckBox endersCheck;
	}
}
