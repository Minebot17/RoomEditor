namespace RoomsEditor.Panels.Modules {
	partial class ColorModule {
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
			this.label = new System.Windows.Forms.Label();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.colorPanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// label
			// 
			this.label.AutoSize = true;
			this.label.Location = new System.Drawing.Point(5, 8);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(9, 13);
			this.label.TabIndex = 5;
			this.label.Text = "l";
			// 
			// colorDialog
			// 
			this.colorDialog.AnyColor = true;
			// 
			// colorPanel
			// 
			this.colorPanel.BackColor = System.Drawing.Color.Black;
			this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.colorPanel.Location = new System.Drawing.Point(150, 0);
			this.colorPanel.Name = "colorPanel";
			this.colorPanel.Size = new System.Drawing.Size(100, 30);
			this.colorPanel.TabIndex = 6;
			this.colorPanel.Click += new System.EventHandler(this.colorPanel_Click);
			// 
			// ColorModule
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.colorPanel);
			this.Controls.Add(this.label);
			this.Name = "ColorModule";
			this.Size = new System.Drawing.Size(250, 30);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.Panel colorPanel;
	}
}
