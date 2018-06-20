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
	public partial class ColorModule : UserControl, IModule {

		public ColorModule(string labelText, int defaultColor) {
			InitializeComponent();

			label.Text = labelText;
			SetColor(defaultColor);
		}

		private void colorPanel_Click(object sender, EventArgs e) {
			DialogResult result = colorDialog.ShowDialog();
			if (result != DialogResult.Cancel) {
				SetColor(colorDialog.Color.ToArgb());
				Tools.EditObjectsTool.MarkDirtyActiveObject();
			}
		}

		private void SetColor(int color) {
			Color toSet = Color.FromArgb(color);
			colorDialog.Color = toSet;
			colorPanel.BackColor = toSet;
		}

		public string GetData() {
			return colorDialog.Color.ToArgb() + "";
		}

		public void SetData(string data) {
			SetColor(int.Parse(data));
		}
	}
}
