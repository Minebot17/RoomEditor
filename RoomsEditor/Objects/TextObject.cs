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
			glColor3b(color.R, color.G, color.B);
			//ShaderManager.whiteColored.start();
			render.Draw(type);
			//ShaderManager.whiteColored.stop();
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
			if (data == null)
				return new MarkerPanel("", Color.Black);
			return new MarkerPanel(data[0], Color.FromArgb(int.Parse(data[1])));
		}
	}
}