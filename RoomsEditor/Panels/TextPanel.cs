using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomsEditor.Panels {
	public partial class MarkerPanel : UserControl {
		private string text;
		private Color color;

		public MarkerPanel(string text, Color color) {
			this.text = text;
			this.color = color;
			InitializeComponent();
			textBox.Text = text;
			colorPanel.BackColor = color;
		}

		private void textButton_Click(object sender, EventArgs e) {
			text = textBox.Text;
			Tools.EditObjectsTool.MarkDirtyActiveObject();
		}

		private void colorButton_Click(object sender, EventArgs e) {
			DialogResult result = colorDialog1.ShowDialog();
			if (result == DialogResult.OK)
				setCurrentColor();
		}

		private void setCurrentColor() {
			color = colorDialog1.Color;
			colorPanel.BackColor = color;
			Tools.EditObjectsTool.MarkDirtyActiveObject();
		}

		public string GetText() { return text; }
		public Color GetColor() { return color; }
	}
}
