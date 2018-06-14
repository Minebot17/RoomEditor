namespace RoomsEditor.Panels {
	partial class ChestPanel {
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
			this.typesBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.itemsBox = new System.Windows.Forms.ListBox();
			this.idBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.addButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// typesBox
			// 
			this.typesBox.FormattingEnabled = true;
			this.typesBox.Location = new System.Drawing.Point(81, 13);
			this.typesBox.Name = "typesBox";
			this.typesBox.Size = new System.Drawing.Size(121, 21);
			this.typesBox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Тип сундука:";
			// 
			// itemsBox
			// 
			this.itemsBox.FormattingEnabled = true;
			this.itemsBox.Location = new System.Drawing.Point(6, 46);
			this.itemsBox.Name = "itemsBox";
			this.itemsBox.Size = new System.Drawing.Size(261, 95);
			this.itemsBox.TabIndex = 2;
			this.itemsBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.itemsBox_MouseDoubleClick);
			// 
			// idBox
			// 
			this.idBox.Location = new System.Drawing.Point(21, 147);
			this.idBox.Name = "idBox";
			this.idBox.Size = new System.Drawing.Size(165, 20);
			this.idBox.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 150);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(21, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "ID:";
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(192, 145);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(75, 23);
			this.addButton.TabIndex = 4;
			this.addButton.Text = "Добавить";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(208, 13);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(59, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "Задать";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// ChestPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.idBox);
			this.Controls.Add(this.itemsBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.typesBox);
			this.Name = "ChestPanel";
			this.Size = new System.Drawing.Size(270, 170);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox typesBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox itemsBox;
		private System.Windows.Forms.TextBox idBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button okButton;
	}
}
