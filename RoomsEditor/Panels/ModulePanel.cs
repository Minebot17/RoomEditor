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

namespace RoomsEditor.Panels {
	public partial class ModulePanel : UserControl {
		protected Control[] controls;

		public ModulePanel(Control[] controls) {
			InitializeComponent();

			this.controls = controls;
			int height = 0;
			controls.ToList().ForEach(x => {
				x.Location = new Point(0, height);
				height += x.Height;
			});
			Controls.AddRange(controls);

			if (height <= Size.Height)
				scrollBar.Visible = false;
			else
				scrollBar.Maximum = height - Size.Height;
		}

		public void SetupData(string[] data) {
			for (int i = 0; i < data.Length; i++)
				((IModule)controls[i]).SetData(data[i]);
		}

		public string[] CollectData() {
			return Array.ConvertAll(controls, x => ((IModule)x).GetData());
		}

		private void scrollBar_Scroll(object sender, ScrollEventArgs e) {
			controls.ToList().ForEach(x => x.Location = new Point(x.Location.X, x.Location.Y + e.NewValue - e.OldValue));
		}
	}
}
