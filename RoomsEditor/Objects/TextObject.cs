using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using RoomsEditor.Panels;
using RoomsEditor.Shaders;
using static Tao.OpenGl.Gl;
using RoomsEditor.Objects.ExtendedDataSystem;
using RoomsEditor.Panels.Modules;
using System.Windows.Forms;

namespace RoomsEditor.Objects {

	[DataContract]
	public class MarkerObject : RoomObjectWithModulePanel {
		private Color color = Color.Black;

		public MarkerObject(ObjectRenderer render) : base(render) {
			
		}

		public override void markDirty() {
			base.markDirty();
			if (data != null)
				color = Color.FromArgb(int.Parse(data[1]));
		}

		public override void Draw(int type) {
			glPushMatrix();
			glTranslatef(coords.x, coords.y, 0);
			glColor3f(color.R/255f, color.G/255f, color.B/255f);
			ShaderManager.whiteColored.start();
			render.Draw(type);
			ShaderManager.whiteColored.stop();
			glColor3f(1, 1, 1);
			glPopMatrix();
		}

		protected override Control[] GetModules() {
			return new Control[] {
				new TextModule("Текст", "Метка"),
				new ColorModule("Цвет", 0)
			};
		}
	}
}