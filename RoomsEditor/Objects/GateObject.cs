using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Serialization;
using static Tao.OpenGl.Gl;

namespace RoomsEditor.Objects {
	[DataContract]
	class GateObject : RoomObjectWithData<GatePanel> {

		public GateObject(ObjectRenderer render) : base(render) {
		}

		public override void Draw() {
			glPushMatrix();
			glTranslatef(mirror.x ? coords.x + render.width : coords.x, mirror.y ? coords.y + render.height : coords.y, 0);
			glScalef(mirror.x ? -1 : 1, mirror.y ? -1 : 1, 0);
			render.Draw();
			glPopMatrix();

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
					glVertex2i(panel.selectedObject.render.width, 0);
					glVertex2i(panel.selectedObject.render.width, panel.selectedObject.render.height);
					glVertex2i(0, panel.selectedObject.render.height);
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
					glVertex2i(objects[i].render.width, 0);
					glVertex2i(objects[i].render.width, objects[i].render.height);
					glVertex2i(0, objects[i].render.height);
					glEnd();
					glColor3f(1, 1, 1);
					glPopMatrix();
				}
			}
			glEnable(GL_TEXTURE_2D);
		}

		public override object[] createDataFromPanel(GatePanel panel) {
			return new object[] { panel.type, panel.existsIDs, panel.unexistsIDs };
		}

		public override GatePanel createPanelFromData(object[] data) {
			if (data == null)
				data = new object[] { 0, new List<int>(), new List<int>() };

			List<int> array1 = new List<int>();
			List<int> array2 = new List<int>();
			try {
				array1 = (List<int>)data[1];
				array2 = (List<int>)data[2];
			}
			catch (InvalidCastException e) {
				for (int i = 0; i < ((object[])data[1]).Length; i++)
					array1.Add((int)((object[])data[1])[i]);
				for (int i = 0; i < ((object[])data[2]).Length; i++)
					array2.Add((int)((object[])data[2])[i]);
			}

			return new GatePanel((int)data[0], array1, array2);
		}
	}
}
