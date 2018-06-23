using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Objects.ExtendedDataSystem;
using RoomsEditor.Panels.Modules;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace RoomsEditor.Objects {

	[DataContract]
	public class JumpPointObject : RoomObjectWithModulePanel {

		public JumpPointObject(ObjectRenderer render) : base(render) {

		}

		protected override Control[] GetModules() {
			return new Control[] {
				new TextModule("Высота прыжка", "0")
			};
		}
	}
}
