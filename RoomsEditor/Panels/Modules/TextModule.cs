using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoomsEditor.Objects.ExtendedDataSystem;

namespace RoomsEditor.Panels.Modules {
	public partial class TextModule : UserControl, IModule {

		public TextModule(string labelText, string defaultText) {
			InitializeComponent();

			SetLabelText(labelText);
			textBox.Text = defaultText;
		}

		private void SetLabelText(string text) {
			label.Text = text;
			int margin = 10 + TextRenderer.MeasureText(label.Text, label.Font).Width;
			textBox.Location = new Point(margin, textBox.Location.Y);
			textBox.Size = new Size(Size.Width - 5 - margin, textBox.Size.Height);
		}

		public string GetData() {
			return textBox.Text;
		}

		public void SetData(string data) {
			textBox.Text = data;
		}

		private void textBox_TextChanged(object sender, EventArgs e) {
			if (textBox.Text != null && !textBox.Text.Equals(""))
				Tools.EditObjectsTool.MarkDirtyActiveObject();
		}
	}
}
