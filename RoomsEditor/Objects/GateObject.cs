using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RoomsEditor.Objects {
	[DataContract]
	class GateObject : RoomObjectWithData<GatePanel> {
		public GateObject(ObjectRenderer render) : base(render) {
		}

		public override object[] createDataFromPanel(GatePanel panel) {
			throw new NotImplementedException();
		}

		public override GatePanel createPanelFromData(object[] data) {
			throw new NotImplementedException();
		}
	}
}
