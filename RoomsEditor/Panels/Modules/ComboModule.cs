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
	public partial class ComboModule : UserControl, IModule {
	
		public ComboModule(string labelText, string[] elements, int defaultIndex) {
			InitializeComponent();
			SetLabelText(labelText);
			elements.ToList().ForEach(x => comboBox.Items.Add(x));
			comboBox.SelectedIndex = defaultIndex;
		}

		private void SetLabelText(string text) {
			label.Text = text;
			int margin = 10 + TextRenderer.MeasureText(label.Text, label.Font).Width;
			comboBox.Location = new Point(margin, comboBox.Location.Y);
			comboBox.Size = new Size(Size.Width - 5 - margin, comboBox.Size.Height);
		}

		public string GetData() {
			return comboBox.SelectedIndex + "";
		}

		public void SetData(string data) {
			comboBox.SelectedIndex = int.Parse(data);
		}

		private void comboBox_SelectedIndexChanged(object sender, EventArgs e) {
			Tools.EditObjectsTool.MarkDirtyActiveObject();
		}

		private void label_Click(object sender, EventArgs e) {

		}
	}
}
