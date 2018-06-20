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
	public partial class StairPanel : UserControl {
		private int type;
		private int time;
		private int width;
		private bool enders;

		public StairPanel(int type, int time, int width, bool enders) {
			this.type = type;
			this.time = time;
			this.width = width;
			this.enders = enders;
			InitializeComponent();
			typeCombo.SelectedIndex = type;
			timeBox.Text = time + "";
			widthBox.Text = width + "";
			endersCheck.Checked = enders;
		}

		private void okButton_Click(object sender, EventArgs e) {

			Tools.EditObjectsTool.MarkDirtyActiveObject();
		}
	}
}
