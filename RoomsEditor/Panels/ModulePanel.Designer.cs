﻿namespace RoomsEditor.Panels {
	partial class ModulePanel {
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
			this.scrollBar = new System.Windows.Forms.VScrollBar();
			this.SuspendLayout();
			// 
			// scrollBar
			// 
			this.scrollBar.LargeChange = 50;
			this.scrollBar.Location = new System.Drawing.Point(250, 0);
			this.scrollBar.Name = "scrollBar";
			this.scrollBar.Size = new System.Drawing.Size(20, 170);
			this.scrollBar.SmallChange = 5;
			this.scrollBar.TabIndex = 0;
			this.scrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollBar_Scroll);
			// 
			// ModulePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.scrollBar);
			this.Name = "ModulePanel";
			this.Size = new System.Drawing.Size(268, 168);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.VScrollBar scrollBar;
	}
}
