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
	public partial class BananaPanel : UserControl {
		private float time;

		public BananaPanel(float time) {
			this.time = time;
			InitializeComponent();
			timeBox.Text = time+"";
		}

		private void timeButton_Click(object sender, EventArgs e) {
			float def = time;
			float.TryParse(timeBox.Text, out def);
			time = def;
			Tools.EditObjectsTool.MarkDirtyActiveObject();
		}

		public float GetTime() { return time; }
	}
}
