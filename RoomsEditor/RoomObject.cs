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
	class RoomObject {

		public string name;
		public string texture;
		public int height;
		public int width;
		public Vec<float>[] uv;

		public RoomObject(string name, string texture) {
			Bitmap bmp = LoadBitmap(texture);
			this.name = name;
			this.texture = texture;
			this.height = bmp.Height;
			this.width = bmp.Width;
			this.uv = new Vec<float>[] { new Vec<float>(0, 1), new Vec<float>(1, 1), new Vec<float>(1, 0), new Vec<float>(0, 0) };
		}

		public RoomObject(string name, string texture, int height, int width, Vec<int> offset) {
			Bitmap bmp = LoadBitmap(texture);
			this.name = name;
			this.texture = texture;
			this.height = height;
			this.width = width;
			Vec<float> start = new Vec<float>(offset.x / (float)bmp.Width, offset.y / (float)bmp.Height);
			Vec<float> end = new Vec<float>((offset.x + width) / (float)bmp.Width, (offset.y + height) / (float)bmp.Height);
			this.uv = new Vec<float>[] { new Vec<float>(start.x, end.y), new Vec<float>(end.x, end.y), new Vec<float>(end.x, start.y), new Vec<float>(start.x, start.y) };
		}

		public RoomObject(string name, string texture, int height, int width, Vec<float>[] uv) {
			this.name = name;
			this.texture = texture;
			this.height = height;
			this.width = width;
			this.uv = uv;
		}

		public virtual void draw() {
			TextureManager.BindTexture(texture);
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
	}
}
