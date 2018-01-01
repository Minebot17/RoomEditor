using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;

namespace RoomsEditor.Objects {
	[DataContract]
	[KnownType(typeof(ChestObject))]
	[KnownType(typeof(GateObject))]
	public class RoomObject : IRenderer {
		public ObjectRenderer render;
		[DataMember]
		public string prefabName;
		[DataMember]
		public Vec<int> coords;
		[DataMember]
		public Vec<bool> mirror;
		[DataMember]
		public int ID;

		public RoomObject() { }

		public RoomObject(ObjectRenderer render) {
			this.render = render;
			prefabName = render.name;
			coords = new Vec<int>();
			ID = MainForm.rnd.Next();
		}

		public virtual void Draw() {
			glPushMatrix();
			glTranslatef(mirror.x ? coords.x + render.width : coords.x, mirror.y ? coords.y + render.height : coords.y, 0);
			glScalef(mirror.x ? -1 : 1, mirror.y ? -1 : 1, 0);
			render.Draw();
			glPopMatrix();
		}

		public virtual RoomObject Copy() {
			RoomObject copy = ObjectsManager.GetObjectByRenderName(render.name);
			copy.prefabName = prefabName;
			copy.coords = coords;
			copy.mirror = mirror;
			copy.ID = MainForm.rnd.Next();
			return copy;
		}
	}
}
