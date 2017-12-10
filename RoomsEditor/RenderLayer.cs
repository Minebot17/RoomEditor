using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsEditor {
	class RenderLayer {
		public string name;
		public List<IRenderer> objects;
		public float z;

		public RenderLayer(string name, float z) {
			this.name = name;
			this.z = z;
			objects = new List<IRenderer>();
		}

		public void AddObject(IRenderer obj) => objects.Add(obj);
		public void RemoveObject(IRenderer obj) {
			if (objects.Contains(obj))
				objects.Remove(obj);
		}
	}
}
