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
		public RenderType[] types;
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
			RenderType type = new RenderType();
			type.height = bmp.Height;
			type.width = bmp.Width;
			type.uv = new Vec<float>[] { new Vec<float>(1, 0), new Vec<float>(1, 1), new Vec<float>(0, 1), new Vec<float>(0, 0) };
			types = new RenderType[1];
			types[0] = type;
		}

		public ObjectRenderer(string name, string texture, int width, int height, Vec<int> offset) {
			this.name = name;
			this.texture = texture;
			RenderType type = new RenderType();
			type.width = width;
			type.height = height;
			type.offset = offset;
			types = new RenderType[1];
			types[0] = type;
			constructUV(type);
		}

		public ObjectRenderer(string name, string texture, int width, int height, Vec<float>[] uv) {
			this.name = name;
			this.texture = texture;
			RenderType type = new RenderType();
			type.height = height;
			type.width = width;
			type.uv = uv;
			types = new RenderType[1];
			types[0] = type;
		}

		public virtual void Draw() {
			Draw(0);
		}

		public virtual void Draw(int type) {
			RenderType render = types[type];
			TextureManager.BindTexture(texture);
			glBegin(GL_QUADS);
			glTexCoord2f(render.uv[0].x, render.uv[0].y);
			glVertex2i(0, 0);
			glTexCoord2f(render.uv[1].x, render.uv[1].y);
			glVertex2i(render.width, 0);
			glTexCoord2f(render.uv[2].x, render.uv[2].y);
			glVertex2i(render.width, render.height);
			glTexCoord2f(render.uv[3].x, render.uv[3].y);
			glVertex2i(0, render.height);
			glEnd();
		}

		public void constructUV(RenderType type) {
			Bitmap bmp = LoadBitmap("textures/" + texture);
			Vec<float> start = new Vec<float>(type.offset.x / (float)bmp.Width, 1f - type.offset.y / (float)bmp.Height);
			Vec<float> end = new Vec<float>((type.offset.x + type.width) / (float)bmp.Width, 1f - (type.offset.y + type.height) / (float)bmp.Height);
			type.uv = new Vec<float>[] { new Vec<float>(start.x, end.y), new Vec<float>(end.x, end.y), new Vec<float>(end.x, start.y), new Vec<float>(start.x, start.y) };
		}

		public override bool Equals(object obj) => obj is ObjectRenderer && ((ObjectRenderer)obj).name.Equals(name);
		public override int GetHashCode() => name.GetHashCode();

		[DataContract]
		public class RenderType {
			[DataMember]
			public int height;
			[DataMember]
			public int width;
			[DataMember]
			public Vec<float>[] uv;
			[DataMember]
			public Vec<int> offset;
		}
	}
}
