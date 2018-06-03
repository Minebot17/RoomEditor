namespace RoomsEditor.Panels {
	partial class BananaPanel {
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
			this.timeBox = new System.Windows.Forms.TextBox();
			this.timeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(58, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Время эффекта в секундах";
			// 
			// timeBox
			// 
			this.timeBox.Location = new System.Drawing.Point(61, 68);
			this.timeBox.Name = "timeBox";
			this.timeBox.Size = new System.Drawing.Size(91, 20);
			this.timeBox.TabIndex = 1;
			// 
			// timeButton
			// 
			this.timeButton.Location = new System.Drawing.Point(158, 68);
			this.timeButton.Name = "timeButton";
			this.timeButton.Size = new System.Drawing.Size(46, 20);
			this.timeButton.TabIndex = 2;
			this.timeButton.Text = "OK";
			this.timeButton.UseVisualStyleBackColor = true;
			this.timeButton.Click += new System.EventHandler(this.timeButton_Click);
			// 
			// BananaPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.timeButton);
			this.Controls.Add(this.timeBox);
			this.Controls.Add(this.label1);
			this.Name = "BananaPanel";
			this.Size = new System.Drawing.Size(270, 170);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox timeBox;
		private System.Windows.Forms.Button timeButton;
	}
}
