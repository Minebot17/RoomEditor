using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoomsEditor.Objects;
using static Tao.OpenGl.Gl;

namespace RoomsEditor.Tools {
	class EditObjectsTool : Tool {
		public RoomObject activeObject;

		public override void MouseDown() {
			if (InputManager.IsMouseButtonDown(System.Windows.Forms.MouseButtons.Left))
				activeObject = ObjectsManager.GetObjectOverMouse();
		}

		public override void MouseMove() {
			if (!InputManager.IsMouseButtonDown(System.Windows.Forms.MouseButtons.Right) || activeObject == null)
				return;

			activeObject.coords = InputManager.mouseWorldPosition;
		}

		public override void Draw() {
			if (activeObject == null)
				return;

			glColor3f(1, 0, 0);
			glLineWidth(1);
			glBegin(GL_LINE_LOOP);
			glVertex2i(activeObject.coords.x, activeObject.coords.y);
			glVertex2i(activeObject.render.width + activeObject.coords.x, activeObject.coords.y);
			glVertex2i(activeObject.render.width + activeObject.coords.x, activeObject.render.height + activeObject.coords.y);
			glVertex2i(activeObject.coords.x, activeObject.render.height + activeObject.coords.y);
			glEnd();
			glColor3f(1, 1, 1);
		}
	}
}
