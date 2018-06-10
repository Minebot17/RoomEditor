using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Panels;

namespace RoomsEditor.Objects {

	[DataContract]
	public class BulavaObject : RoomObjectWithData<BulavaPanel> {

		public BulavaObject(ObjectRenderer render) : base(render) {

		}

		public override string[] createDataFromPanel(BulavaPanel panel) {
			return new string[] {
				panel.GetTileCount()+"",
				panel.GetRotateMode()+"",
				panel.GetAngleSpeed()+"",
				panel.GetStartAngle()+"",
				panel.GetMotionMode()+"",
				panel.GetMotionSpeed()+"",
				panel.GetMotionDistance()+"",
				panel.GetStartDistance()+""
			};
		}

		public override BulavaPanel createPanelFromData(string[] data) {
			return new BulavaPanel(
				int.Parse(data[0]),
				int.Parse(data[1]),
				int.Parse(data[2]),
				int.Parse(data[3]),
				int.Parse(data[4]),
				int.Parse(data[5]),
				int.Parse(data[6]),
				int.Parse(data[7])
			);
		}

		public override string[] getDefaultData() {
			return new string[] { "0", "0", "0", "0", "0", "0", "0", "0" };
		}
	}
}
