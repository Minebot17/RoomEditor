using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Objects;

namespace RoomsEditor.Actions {
	class SpawnObjectAction : IAction {
		private List<RoomObject> objects;

		public SpawnObjectAction(List<RoomObject> objects) {
			this.objects = objects;
		}

		public void Cancel() {
			foreach (RoomObject obj in objects)
				ObjectsManager.RemoveObject(obj, false);
		}

		public void Return() {
			foreach (RoomObject obj in objects) {
				ObjectsManager.SpawnObject(obj, false);
			}
		}
	}
}