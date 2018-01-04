using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace RoomsEditor.Actions {
	public class SwitchSymmetryAction : IAction {
		public CheckBox box;

		public SwitchSymmetryAction(CheckBox box) {
			this.box = box;
		}

		public void Cancel() {
			MainForm.form.checkBoxSwitch = true;
			box.Checked = !box.Checked;
		}

		public void Return() {
			MainForm.form.checkBoxSwitch = true;
			box.Checked = !box.Checked;
		}
	}
}
