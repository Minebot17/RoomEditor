using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;

/*   UV
 * 3----2
 * ------
 * ------
 * 0----1
 */
namespace RoomsEditor {

	[DataContract]
	public class ObjectRenderer : IRenderer {

		[DataMember]
		public string name;
		[DataMember]
		public string texture;
		[DataMember]
		public string group;
		[DataMember]
		public int height;
		[DataMember]
		public int width;
		[DataMember]
		public Vec<float>[] uv;
		[DataMember]
		public Vec<int> offset;
		[DataMember]
		public bool notAddToMenu;
		[DataMember]
		public bool mustNotMove;
		[DataMember]
		public bool mustNotDelete;
		[DataMember]
		public bool mustNotDoRenderWithSymmetry;

		public ObjectRenderer(string name, string texture) {
			Bitmap bmp = LoadBitmap("textures/" + texture);
			this.name = name;
			this.texture = texture;
			this.height = bmp.Height;
			this.width = bmp.Width;
			this.uv = new Vec<float>[] { new Vec<float>(1, 0), new Vec<float>(1, 1), new Vec<float>(0, 1), new Vec<float>(0, 0) };
		}

		public ObjectRenderer(string name, string texture, int width, int height, Vec<int> offset) {
			this.name = name;
			this.offset = offset;
			this.texture = texture;
			this.height = height;
			this.width = width;
			constructUV();
		}

		public ObjectRenderer(string name, string texture, int width, int height, Vec<float>[] uv) {
			this.name = name;
			this.texture = texture;
			this.height = height;
			this.width = width;
			this.uv = uv;
		}

		public virtual void Draw() {
			TextureManager.BindTexture(texture);
			glBegin(GL_QUADS);
			glTexCoord2f(uv[0].x, uv[0].y);
			glVertex2i(0, 0);
			glTexCoord2f(uv[1].x, uv[1].y);
			glVertex2i(width, 0);
			glTexCoord2f(uv[2].x, uv[2].y);
			glVertex2i(width, height);
			glTexCoord2f(uv[3].x, uv[3].y);
			glVertex2i(0, height);
			glEnd();
		}

		public void constructUV() {
			Bitmap bmp = LoadBitmap("textures/" + texture);
			Vec<float> start = new Vec<float>(offset.x / (float)bmp.Width, 1f - offset.y / (float)bmp.Height);
			Vec<float> end = new Vec<float>((offset.x + width) / (float)bmp.Width, 1f - (offset.y + height) / (float)bmp.Height);
			this.uv = new Vec<float>[] { new Vec<float>(start.x, end.y), new Vec<float>(end.x, end.y), new Vec<float>(end.x, start.y), new Vec<float>(start.x, start.y) };
		}

		public override bool Equals(object obj) => obj is ObjectRenderer && ((ObjectRenderer)obj).name.Equals(name);
		public override int GetHashCode() => name.GetHashCode();
	}
}
