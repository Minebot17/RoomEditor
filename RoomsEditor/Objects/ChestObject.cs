using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomsEditor.Objects {
	public class ChestObject : RoomObjectWithData<ChestPanel> {

		public ChestObject(ObjectRenderer render) : base(render) {
			
		}

		public override ChestPanel createPanelFromData(object[] data) {
			if (data == null)
				data = new object[] { 0, new string[0] };
			return new ChestPanel((int)data[0], (string[])data[1]);
		}

		public override object[] createDataFromPanel(ChestPanel panel) {
			return new object[] { panel.getType(), panel.getIDs() };
		}
	}
}
