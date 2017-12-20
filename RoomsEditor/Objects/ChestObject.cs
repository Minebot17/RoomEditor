using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace RoomsEditor.Objects {
	[DataContract]
	public class ChestObject : RoomObjectWithData<ChestPanel> {

		public ChestObject(ObjectRenderer render) : base(render) {
			
		}

		public override ChestPanel createPanelFromData(object[] data) {
			if (data == null)
				data = new object[] { 0, new string[0] };
			string[] array;
			try {
				array = (string[])data[1];
			}
			catch (InvalidCastException e) {
				array = new string[((object[])data[1]).Length];
				for (int i = 0; i < array.Length; i++)
					array[i] = (string)((object[])data[1])[i];
			}
			return new ChestPanel((int)data[0], array);
		}

		public override object[] createDataFromPanel(ChestPanel panel) {
			return new object[] { panel.getType(), panel.getIDs() };
		}
	}
}
