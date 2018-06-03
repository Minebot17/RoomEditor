using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Serialization;
using static Tao.OpenGl.Gl;
using RoomsEditor.Panels;

namespace RoomsEditor.Objects {
	[DataContract]
	public class GateObject : RoomObjectWithData<GatePanel> {

		public GateObject(ObjectRenderer render) : base(render) {
		}

		public override void Draw() {
			int state = data == null ? 0 : int.Parse(data[0]);
			glPushMatrix();
			glTranslatef(mirror.x ? coords.x + GetRender().width : coords.x, mirror.y ? coords.y + GetRender().height : coords.y, 0);
			glScalef(mirror.x ? -1 : 1, mirror.y ? -1 : 1, 0);
			if (state == 0) {
				render.Draw();
				glDisable(GL_TEXTURE_2D);
				glEnable(GL_BLEND);
				Utils.Color color = RoomMatrix.colors[1];
				glColor4f(color.r, color.g, color.b, 0.5f);
				render.Draw();
			}
			else if (state == 1)
				render.Draw();
			else if (state == 2) {
				glDisable(GL_TEXTURE_2D);
				Utils.Color color = RoomMatrix.colors[1];
				glColor3f(color.r, color.g, color.b);
				render.Draw();
			}
			glPopMatrix();
			glColor3f(1, 1, 1);

			glDisable(GL_TEXTURE_2D);
			glLineWidth(1);
			if (panel != null && panel.selectMode) {
				panel.selectedObject = ObjectsManager.GetObjectOverMouse();
				if (panel.selectedObject != null) {
					glPushMatrix();
					glColor3f(0, 1, 0);
					glTranslatef(panel.selectedObject.coords.x, panel.selectedObject.coords.y, 0);
					glBegin(GL_LINE_LOOP);
					glVertex2i(0, 0);
					glVertex2i(panel.selectedObject.GetRender().width, 0);
					glVertex2i(panel.selectedObject.GetRender().width, panel.selectedObject.GetRender().height);
					glVertex2i(0, panel.selectedObject.GetRender().height);
					glEnd();
					glColor3f(1, 1, 1);
					glPopMatrix();
				}
			}

			if (panel != null && ((ListBox)panel.gateDataTab.SelectedTab.Controls[0]).SelectedItems.Count != 0) {
				List<RoomObject> objects = new List<RoomObject>();
				for (int i = 0; i < ((ListBox)panel.gateDataTab.SelectedTab.Controls[0]).SelectedItems.Count; i++)
					objects.Add(ObjectsManager.FindObjectByID(int.Parse(((ListBox)panel.gateDataTab.SelectedTab.Controls[0]).SelectedItems[i].ToString().Split(' ')[1])));

				for (int i = 0; i < objects.Count; i++) {
					glPushMatrix();
					glColor3f(0, 0, 1);
					glTranslatef(objects[i].coords.x, objects[i].coords.y, 0);
					glBegin(GL_LINE_LOOP);
					glVertex2i(0, 0);
					glVertex2i(objects[i].GetRender().width, 0);
					glVertex2i(objects[i].GetRender().width, objects[i].GetRender().height);
					glVertex2i(0, objects[i].GetRender().height);
					glEnd();
					glColor3f(1, 1, 1);
					glPopMatrix();
				}
			}
			glEnable(GL_TEXTURE_2D);
		}

		public override string[] createDataFromPanel(GatePanel panel) {
			List<string> result = new List<string>();
			result.Add(panel.type+"");
			foreach (int x in panel.existsIDs)
				result.Add(x + "");
			result.Add("splitter");
			foreach (int x in panel.unexistsIDs)
				result.Add(x + "");
			return result.ToArray();
		}

		public override GatePanel createPanelFromData(string[] data) {
			List<int> array1 = new List<int>();
			List<int> array2 = new List<int>();

			int index = 99999;
			for (int i = 1; i < data.Length; i++) {
				if (data[i].Equals("splitter")) {
					index = i + 1;
					break;
				}
				array1.Add(int.Parse(data[i]));
			}
			if (index < data.Length)
				for (int i = index; i < data.Length; i++)
					array2.Add(int.Parse(data[i]));

			return new GatePanel(int.Parse(data[0]), array1, array2, this);
		}

		public override string[] getDefaultData() {
			return new string[] { "0", "splitter" };
		}
	}
}
