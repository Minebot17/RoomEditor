using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tao.OpenGl.Gl;

namespace RoomsEditor.Objects {
	public class RoomChunkObject : RoomObject {
		public MatrixRenderer renderer;

		public RoomChunkObject(MatrixRenderer renderer) {
			this.prefabName = "ChunkOfRoom";
			this.ID = MainForm.rnd.Next();
			this.renderer = renderer;
			this.render = new ObjectRenderer("", "", renderer.matrix.GetLength(0), renderer.matrix.GetLength(1), new Utils.Vec<float>[0]);
		}

		public override void Draw() {
			glPushMatrix();
			glTranslatef(mirror.x ? coords.x + renderer.matrix.GetLength(0) : coords.x, mirror.y ? coords.y + renderer.matrix.GetLength(1) : coords.y, 0);
			glScalef(mirror.x ? -1 : 1, mirror.y ? -1 : 1, 0);
			renderer.Draw();
			glPopMatrix();
		}

		public override RoomObject Copy() {
			RoomChunkObject copy = new RoomChunkObject(renderer);
			copy.prefabName = prefabName;
			copy.coords = coords;
			copy.mirror = mirror;
			copy.ID = MainForm.rnd.Next();
			return copy;
		}
	}
}
