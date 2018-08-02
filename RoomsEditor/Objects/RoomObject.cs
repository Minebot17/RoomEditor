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
	[KnownType(typeof(MarkerObject))]
	[KnownType(typeof(BananaObject))]
	[KnownType(typeof(BulavaObject))]
	[KnownType(typeof(StairObject))]
	[KnownType(typeof(JumpPointObject))]
	[KnownType(typeof(RoomChunkObject))]
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
		[DataMember]
		public int type;

		public RoomObject() { }

		public RoomObject(ObjectRenderer render) {
			this.render = render;
			prefabName = render.name;
			coords = new Vec<int>();
			ID = MainForm.rnd.Next();
			type = 0;
		}
		public virtual void Draw() {
			Draw(type);
		}

		public virtual void Draw(int type) {
			glPushMatrix();
			glTranslatef(mirror.x ? coords.x + render.types[type].width : coords.x, mirror.y ? coords.y + render.types[type].height : coords.y, 0);
			glScalef(mirror.x ? -1 : 1, mirror.y ? -1 : 1, 0);
			render.Draw(type);
			glPopMatrix();
		}

		public virtual ObjectRenderer.RenderType GetRender() {
			return render.types[type];
		}

		public virtual RoomObject Copy() {
			RoomObject copy = ObjectsManager.GetObjectByRenderName(render.name);
			copy.prefabName = prefabName;
			copy.coords = coords;
			copy.mirror = mirror;
			copy.ID = MainForm.rnd.Next();
			copy.type = type;
			return copy;
		}
	}
}
