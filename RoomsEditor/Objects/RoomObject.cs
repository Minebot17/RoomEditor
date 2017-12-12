using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;

namespace RoomsEditor.Objects {
	public class RoomObject : IRenderer {
		public ObjectRenderer render;
		public string prefabName;
		public Vec<int> coords;
		public Object[] data;
		public int ID;

		public RoomObject(ObjectRenderer render) {
			this.render = render;
			prefabName = render.name;
			coords = new Vec<int>();
			ID = MainForm.rnd.Next();
		}

		public void Draw() {
			glPushMatrix();
			glTranslatef(coords.x, coords.y, 0);
			render.Draw();
			glPopMatrix();
		}
	}
}
