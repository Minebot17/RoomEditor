using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Objects.ExtendedDataSystem;
using RoomsEditor.Panels.Modules;
using System.Windows.Forms;
using System.Runtime.Serialization;
using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;

namespace RoomsEditor.Objects {

	[DataContract]
	public class StairObject : RoomObjectWithModulePanel {
		private int stairType;
		private int width;
		private bool enders;

		public StairObject(ObjectRenderer render) : base(render) {

		}

		public override void Draw(int type) {
			glPushMatrix();
			glTranslatef(coords.x, coords.y, 0);
			TextureManager.BindTexture(render.texture);
			float yUVOffset = stairType == 0 ? 0.25f : stairType == 1 ? 0 : 0.5f;
			float xUVOffset = stairType == 0 ? 0f : stairType == 1 ? 0.0625f : 0.125f;

			if (enders) {
				Utils.DrawTexturedQuad(new Vec<int>(0, 0), new Vec<int>(2, 8), new Vec<float>(xUVOffset, 0), new Vec<float>(xUVOffset + 0.0625f, 0.25f));
				Utils.DrawTexturedQuad(new Vec<int>(width - 2, 0), new Vec<int>(width, 8), new Vec<float>(xUVOffset + 0.0625f, 0), new Vec<float>(xUVOffset, 0.25f));
			}

			Utils.DrawTexturedQuad(new Vec<int>(enders ? 2 : 0, 0), new Vec<int>(enders ? width - 2 : width, 8), new Vec<float>(0, 0.25f + yUVOffset), new Vec<float>((enders ? width - 4 : width)/32f, 0.5f + yUVOffset));
			glPopMatrix();
		}

		public override void markDirty() {
			base.markDirty();
			if (data != null) {
				stairType = int.Parse(data[0]);
				width = int.Parse(data[2]);
				enders = bool.Parse(data[3]);
			}
		}

		protected override Control[] GetModules() {
			return new Control[] {
				new ComboModule("Тип", new []{ "Обычная", "Исчезающая", "Ломающаяся" }, 0),
				new TextModule("Задержка исчезновения (сек)", "0"),
				new TextModule("Ширина", "16"),
				new BoolModule("Наконечники", true)
			};
		}
	}
}
