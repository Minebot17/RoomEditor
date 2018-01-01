using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoomsEditor.Objects;
using static RoomsEditor.Utils;
using static Tao.OpenGl.Gl;

namespace RoomsEditor.Tools {
	class EditObjectsTool : Tool {
		public List<RoomObject> activeObject;
		public int panelMode;

		public RoomObject xSymmetryObject;
		public RoomObject ySymmetryObject;
		public RoomObject xySymmetryObject;

		public override void MouseDown() {
			if (InputManager.IsMouseButtonDown(System.Windows.Forms.MouseButtons.Left)) {
				RoomObject obj = ObjectsManager.GetObjectOverMouse();
				if (InputManager.IsKeyDown(System.Windows.Forms.Keys.ShiftKey))
					AddToSelectObject(obj);
				else
					SelectObjects(new List<RoomObject>() { obj });
			}
		}

		public override void MouseMove() {
			if (!InputManager.IsMouseButtonDown(System.Windows.Forms.MouseButtons.Right) || activeObject == null)
				return;

			Vec<int> delta = SubstractVector(InputManager.mouseWorldPosition, activeObject[0].coords);
			if (!activeObject[0].render.mustNotMove) {
				activeObject[0].coords = InputManager.mouseWorldPosition;
				if (xSymmetryObject != null)
					xSymmetryObject.coords = new Vec<int>(495 * MainForm.form.matrix.widthRoom - InputManager.mouseWorldPosition.x - xSymmetryObject.render.width, InputManager.mouseWorldPosition.y);
				if (ySymmetryObject != null)
					ySymmetryObject.coords = new Vec<int>(InputManager.mouseWorldPosition.x, 277 * MainForm.form.matrix.heightRoom - InputManager.mouseWorldPosition.y - ySymmetryObject.render.height);
				if (xySymmetryObject != null)
					xySymmetryObject.coords = new Vec<int>(495 * MainForm.form.matrix.widthRoom - InputManager.mouseWorldPosition.x - xySymmetryObject.render.width, 277 * MainForm.form.matrix.heightRoom - InputManager.mouseWorldPosition.y - xySymmetryObject.render.height);
			}
			for (int i = 1; i < activeObject.Count; i++)
				if (!activeObject[i].render.mustNotMove)
					activeObject[i].coords = UniteVectors(activeObject[i].coords, delta);

			if (panelMode == 1)
				updatePanelCoords();
		}

		public override void Draw() {
			if (activeObject == null)
				return;

			glColor3f(1, 0, 0);
			glLineWidth(1);
			foreach (RoomObject obj in activeObject) {
				glBegin(GL_LINE_LOOP);
				glVertex2i(obj.coords.x, obj.coords.y);
				glVertex2i(obj.render.width + obj.coords.x, obj.coords.y);
				glVertex2i(obj.render.width + obj.coords.x, obj.render.height + obj.coords.y);
				glVertex2i(obj.coords.x, obj.render.height + obj.coords.y);
				glEnd();
			}
			glColor3f(1, 1, 1);
		}

		public override void Disponse() {
			MainForm.form.objectTransformPanel.Visible = false;
			if (activeObject != null && activeObject.Count == 1 && activeObject[0] is IExtendedData)
				((IExtendedData)activeObject[0]).closePanel();
			activeObject = null;
			loadObjectPanel();
			FindSymmetryObjects();
		}

		public override void KeyDown() {
			if (InputManager.IsKeyDown(System.Windows.Forms.Keys.Delete) && activeObject != null) {
				FindSymmetryObjects();
				if (xSymmetryObject != null)
					MainForm.form.objects.Remove(xSymmetryObject);
				if (ySymmetryObject != null)
					MainForm.form.objects.Remove(ySymmetryObject);
				if (xySymmetryObject != null)
					MainForm.form.objects.Remove(xySymmetryObject);
				if (activeObject.Count == 1 && activeObject[0] is IExtendedData)
					((IExtendedData)activeObject[0]).closePanel();
				MainForm.form.objects.RemoveAll(x => activeObject.Contains(x) && !x.render.mustNotDelete);
				activeObject = null;
				loadObjectPanel();
			}
		}

		public void SelectObjects(List<RoomObject> objects) {
			if (activeObject != null && activeObject.Count == 1 && activeObject[0] is IExtendedData)
				((IExtendedData)activeObject[0]).closePanel();
			if (objects.All(x => x == null))
				activeObject = null;
			else
				activeObject = objects;
			if (activeObject != null && activeObject.Count == 1 && activeObject[0] is IExtendedData)
				((IExtendedData)activeObject[0]).openPanel();
			loadObjectPanel();
			FindSymmetryObjects();
		}

		public void AddToSelectObject(RoomObject obj) {
			if (activeObject == null)
				activeObject = new List<RoomObject>();

			if (obj == null)
				return;
			else if (activeObject.Contains(obj)) {
				if (activeObject.Count == 1 && activeObject[0] is IExtendedData)
					((IExtendedData)activeObject[0]).closePanel();
				activeObject.Remove(obj);
			}
			else {
				if (activeObject.Count == 1 && activeObject[0] is IExtendedData)
					((IExtendedData)activeObject[0]).closePanel();
				activeObject.Add(obj);
				if (activeObject.Count == 1 && activeObject[0] is IExtendedData)
					((IExtendedData)activeObject[0]).openPanel();
			}
			loadObjectPanel();
		}

		public void FindSymmetryObjects() {
			xSymmetryObject = null;
			ySymmetryObject = null;
			xySymmetryObject = null;

			if (activeObject != null && activeObject.Count == 1) {
				RoomObject original = activeObject[0];
				if (MainForm.form.XSymmetryBox.Checked)
					xSymmetryObject = ObjectsManager.FindObject(obj => obj.coords.y == original.coords.y && 495 * MainForm.form.matrix.widthRoom - obj.coords.x - obj.render.width == original.coords.x && obj.prefabName.Equals(original.prefabName));
				if (MainForm.form.YSymmetryBox.Checked)
					ySymmetryObject = ObjectsManager.FindObject(obj => 277 * MainForm.form.matrix.heightRoom - obj.coords.y - obj.render.height == original.coords.y && obj.coords.x == original.coords.x && obj.prefabName.Equals(original.prefabName));
				if (MainForm.form.XYSymmetryBox.Checked)
					xySymmetryObject = ObjectsManager.FindObject(obj => 277 * MainForm.form.matrix.heightRoom - obj.coords.y - obj.render.height == original.coords.y && 495 * MainForm.form.matrix.widthRoom - obj.coords.x - obj.render.width == original.coords.x && obj.prefabName.Equals(original.prefabName));
			}
		}

		public void changeMirror() {
			if (activeObject == null || activeObject.Count == 0)
				return;

			for (int i = 0; i < activeObject.Count; i++) {
				activeObject[i].mirror.x = MainForm.form.objectMirrorXBox.Checked;
				activeObject[i].mirror.y = MainForm.form.objectMirrorYBox.Checked;
			}
		}

		public void loadObjectPanel() {
			panelMode = activeObject == null || activeObject.Count == 0 ? 0 : activeObject.Count == 1 ? 1 : 2;

			clearPanel();
			switch (panelMode) {
				case 0:
					MainForm.form.objectTransformPanel.Visible = false;
					break;
				case 1:
					MainForm.form.objectNameLabel.Text = activeObject[0].prefabName + " " + activeObject[0].ID;
					MainForm.form.objectXSizeLabel.Text = "W: " + activeObject[0].render.width;
					MainForm.form.objectYSizeLabel.Text = "H: " + activeObject[0].render.height;
					if (activeObject[0].render.mustNotDoRenderWithSymmetry) {
						MainForm.form.objectMirrorXBox.Visible = false;
						MainForm.form.objectMirrorYBox.Visible = false;
					}
					else {
						MainForm.form.objectMirrorXBox.Checked = activeObject[0].mirror.x;
						MainForm.form.objectMirrorYBox.Checked = activeObject[0].mirror.y;
					}
					updatePanelCoords();
					break;
				case 2:
					MainForm.form.objectNameLabel.Text = "Selected " + activeObject.Count + " objects";
					bool sameMirror = true;
					for (int i = 0; i < activeObject.Count; i++)
						for (int j = 0; j < activeObject.Count; j++)
							if (activeObject[i].mirror.x != activeObject[j].mirror.x || activeObject[i].mirror.y != activeObject[j].mirror.y || activeObject[i].render.mustNotDoRenderWithSymmetry) {
								sameMirror = false;
								break;
							}

					if (sameMirror) {
						MainForm.form.objectMirrorXBox.Checked = activeObject[0].mirror.x;
						MainForm.form.objectMirrorYBox.Checked = activeObject[0].mirror.y;
					}
					else {
						MainForm.form.objectMirrorXBox.Visible = false;
						MainForm.form.objectMirrorYBox.Visible = false;
					}
					break;
			}
		}

		private void updatePanelCoords() {
			MainForm.form.objectXCoordsLabel.Text = "X: " + activeObject[0].coords.x;
			MainForm.form.objectYCoordsLabel.Text = "Y: " + activeObject[0].coords.y;
		}

		private void clearPanel() {
			MainForm.form.objectTransformPanel.Visible = true;
			MainForm.form.objectMirrorXBox.Visible = true;
			MainForm.form.objectMirrorYBox.Visible = true;
			MainForm.form.objectNameLabel.Text = "";
			MainForm.form.objectXCoordsLabel.Text = "";
			MainForm.form.objectXSizeLabel.Text = "";
			MainForm.form.objectYCoordsLabel.Text = "";
			MainForm.form.objectYSizeLabel.Text = "";
		}
	}
}
