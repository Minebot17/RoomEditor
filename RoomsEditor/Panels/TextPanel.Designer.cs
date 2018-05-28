namespace RoomsEditor.Panels {
	partial class TextPanel {
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
			this.textBox = new System.Windows.Forms.TextBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.textButton = new System.Windows.Forms.Button();
			this.colorButton = new System.Windows.Forms.Button();
			this.colorPanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Текст:";
			// 
			// textBox
			// 
			this.textBox.Location = new System.Drawing.Point(58, 12);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(88, 20);
			this.textBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Цвет:";
			// 
			// textButton
			// 
			this.textButton.Location = new System.Drawing.Point(152, 10);
			this.textButton.Name = "textButton";
			this.textButton.Size = new System.Drawing.Size(104, 23);
			this.textButton.TabIndex = 3;
			this.textButton.Text = "Задать";
			this.textButton.UseVisualStyleBackColor = true;
			this.textButton.Click += new System.EventHandler(this.textButton_Click);
			// 
			// colorButton
			// 
			this.colorButton.Location = new System.Drawing.Point(152, 43);
			this.colorButton.Name = "colorButton";
			this.colorButton.Size = new System.Drawing.Size(104, 23);
			this.colorButton.TabIndex = 4;
			this.colorButton.Text = "Выбрать";
			this.colorButton.UseVisualStyleBackColor = true;
			this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
			// 
			// colorPanel
			// 
			this.colorPanel.BackColor = System.Drawing.Color.Black;
			this.colorPanel.Location = new System.Drawing.Point(56, 43);
			this.colorPanel.Name = "colorPanel";
			this.colorPanel.Size = new System.Drawing.Size(90, 23);
			this.colorPanel.TabIndex = 5;
			// 
			// TextPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.colorPanel);
			this.Controls.Add(this.colorButton);
			this.Controls.Add(this.textButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.label1);
			this.Name = "TextPanel";
			this.Size = new System.Drawing.Size(270, 170);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button textButton;
		private System.Windows.Forms.Button colorButton;
		private System.Windows.Forms.Panel colorPanel;
	}
}
