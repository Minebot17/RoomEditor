using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using RoomsEditor.Panels;
using RoomsEditor.Shaders;
using static Tao.OpenGl.Gl;

namespace RoomsEditor.Objects {

	[DataContract]
	public class MarkerObject : RoomObjectWithData<MarkerPanel> {
		private string name;
		private Color color;

		public MarkerObject(ObjectRenderer render) : base(render) {
			name = "";
			color = Color.Black;
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

		public override string[] createDataFromPanel(MarkerPanel panel) {
			name = panel.GetText();
			color = panel.GetColor();
			return new string[] {
				panel.GetText(),
				panel.GetColor().ToArgb()+""
			};
		}

		public override MarkerPanel createPanelFromData(string[] data) {
			return new MarkerPanel(data[0], Color.FromArgb(int.Parse(data[1])));
		}

		public override string[] getDefaultData() {
			return new string[] { "", Color.Black.ToArgb()+"" };
		}
	}
}