using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Objects;

namespace RoomsEditor.Actions {
	public class PastObjectDataAction : IAction {
		public List<RoomObject> objects = new List<RoomObject>();
		public List<string[]> oldData = new List<string[]>();
		public string[] newData;

		public PastObjectDataAction(List<RoomObject> objects, string[] newData) {
			this.objects = objects;
			this.newData = newData;
			this.oldData = Array.ConvertAll(objects.ToArray(), x => ((IExtendedData)x).serializeData()).ToList();
		}

		public void Cancel() {
			for (int i = 0; i < objects.Count; i++)
				((IExtendedData)objects[i]).deserializeData(oldData[i]);
		}

		public void Return() {
			for (int i = 0; i < objects.Count; i++)
				((IExtendedData)objects[i]).deserializeData(newData);
		}
	}
}
