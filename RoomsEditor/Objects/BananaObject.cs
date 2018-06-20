using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Panels;

namespace RoomsEditor.Objects {

	[DataContract]
	public class BananaObject : RoomObjectWithCustomPanel<BananaPanel> {

		public BananaObject(ObjectRenderer render) : base(render) {
			
		}

		public override string[] createDataFromPanel(BananaPanel panel) {
			return new string[] { panel.GetTime()+"" };
		}

		public override BananaPanel createPanelFromData(string[] data) {
			return new BananaPanel(float.Parse(data[0]));
		}

		public override string[] getDefaultData() {
			return new string[] { "3" };
		}
	}
}
