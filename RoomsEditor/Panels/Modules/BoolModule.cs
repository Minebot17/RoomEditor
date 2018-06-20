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
	public partial class BoolModule : UserControl, IModule {

		public BoolModule(string labelText, bool defaultValue) {
			InitializeComponent();

			checkBox.Text = labelText;
			checkBox.Checked = defaultValue;
		}

		public string GetData() {
			return checkBox.Checked.ToString();
		}

		public void SetData(string data) {
			checkBox.Checked = bool.Parse(data);
		}

		private void checkBox_CheckedChanged(object sender, EventArgs e) {
			Tools.EditObjectsTool.MarkDirtyActiveObject();
		}
	}
}
