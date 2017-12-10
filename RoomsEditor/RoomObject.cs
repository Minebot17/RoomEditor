using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;

/*   UV
 * 3----2
 * ------
 * ------
 * 0----1
 */
namespace RoomsEditor {
	class RoomObject : IRenderer {

		public string name;
		public string texture;
		public int ID;
		public int height;
		public int width;
		public Vec<float>[] uv;

		public RoomObject(string name, string texture) {
			Bitmap bmp = LoadBitmap("textures/" + texture);
			this.name = name;
			this.texture = texture;
			this.height = bmp.Height;
			this.width = bmp.Width;
			this.uv = new Vec<float>[] { new Vec<float>(1, 0), new Vec<float>(1, 1), new Vec<float>(0, 1), new Vec<float>(0, 0) };
		}

		public RoomObject(string name, string texture, int width, int height, Vec<int> offset) {
			Bitmap bmp = LoadBitmap("textures/"+texture);
			this.name = name;
			this.texture = texture;
			this.height = height;
			this.width = width;
			Vec<float> start = new Vec<float>(offset.x / (float)bmp.Width, 1f - (offset.y + height) / (float)bmp.Height);
			Vec<float> end = new Vec<float>((offset.x + width) / (float)bmp.Width, 1f-offset.y / (float)bmp.Height);
			this.uv = new Vec<float>[] { new Vec<float>(end.x, start.y), new Vec<float>(end.x, end.y), new Vec<float>(start.x, end.y), new Vec<float>(start.x, start.y) };
		}

		public RoomObject(string name, string texture, int width, int height, Vec<float>[] uv) {
			this.name = name;
			this.texture = texture;
			this.height = height;
			this.width = width;
			this.uv = uv;
			this.ID = MainForm.rnd.Next();
		}

		public virtual void Draw() {
			TextureManager.BindTexture("Obj.png");
			glBegin(GL_POLYGON);
			glVertex2i(0, 0);
			glTexCoord2f(uv[0].x, uv[0].y);
			glVertex2i(width, 0);
			glTexCoord2f(uv[1].x, uv[1].y);
			glVertex2i(width, height);
			glTexCoord2f(uv[2].x, uv[2].y);
			glVertex2i(0, height);
			glTexCoord2f(uv[3].x, uv[3].y);
			glEnd();
		}

		public override String ToString() => "Name: " + name + " ID: " + ID;
		public override int GetHashCode() => ID;
		public override bool Equals(object obj) => obj is RoomObject && ((RoomObject)obj).name.Equals(name) && ((RoomObject)obj).ID == ID;
	}
}
