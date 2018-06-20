using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Objects.ExtendedDataSystem;
using RoomsEditor.Panels.Modules;
using System.Windows.Forms;

namespace RoomsEditor.Objects {

	[DataContract]
	public class BananaObject : RoomObjectWithModulePanel {

		public BananaObject(ObjectRenderer render) : base(render) {

		}

		protected override Control[] GetModules() {
			return new Control[] {
				new TextModule("Время эффекта (сек)", "3")
			};
		}
	}
}
