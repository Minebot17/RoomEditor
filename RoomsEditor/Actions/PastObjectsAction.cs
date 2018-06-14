using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Objects;

namespace RoomsEditor.Actions {
	public class PastObjectsAction : IAction {
		public List<RoomObject> objects;

		public PastObjectsAction(List<RoomObject> objects) {
			this.objects = objects;
		}

		public void Cancel() {
			foreach (RoomObject obj in objects)
				ObjectsManager.RemoveObject(obj, false);
		}

		public void Return() {
			foreach (RoomObject obj in objects)
				ObjectsManager.SpawnObject(obj, false);
		}
	}
}
