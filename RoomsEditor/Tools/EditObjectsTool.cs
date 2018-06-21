using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoomsEditor.Objects;
using RoomsEditor.Actions;
using static RoomsEditor.Utils;
using static Tao.OpenGl.Gl;

namespace RoomsEditor.Tools {
	class EditObjectsTool : Tool {
		public List<RoomObject> activeObject;
		public int panelMode;
		public List<Vec<int>> startMovePoses;
		public bool isMoved;
		public List<RoomObject> copyBuffer;

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
			else if (InputManager.IsMouseButtonDown(System.Windows.Forms.MouseButtons.Right) && activeObject != null && activeObject.Count != 0) {
				startMovePoses = new List<Vec<int>>();
				foreach (RoomObject obj in activeObject)
					startMovePoses.Add(obj.coords);
				isMoved = true;
			}
		}

		public override void MouseMove() {
			if (!InputManager.IsMouseButtonDown(System.Windows.Forms.MouseButtons.Right) || activeObject == null)
				return;

			Vec<int> delta = SubstractVector(InputManager.mouseWorldPosition, activeObject[0].coords);
			if (!activeObject[0].render.mustNotMove) {
				activeObject[0].coords = InputManager.mouseWorldPosition;
				if (xSymmetryObject != null)
					xSymmetryObject.coords = new Vec<int>(495 * MainForm.form.matrix.widthRoom - InputManager.mouseWorldPosition.x - xSymmetryObject.GetRender().width, InputManager.mouseWorldPosition.y);
				if (ySymmetryObject != null)
					ySymmetryObject.coords = new Vec<int>(InputManager.mouseWorldPosition.x, 277 * MainForm.form.matrix.heightRoom - InputManager.mouseWorldPosition.y - ySymmetryObject.GetRender().height);
				if (xySymmetryObject != null)
					xySymmetryObject.coords = new Vec<int>(495 * MainForm.form.matrix.widthRoom - InputManager.mouseWorldPosition.x - xySymmetryObject.GetRender().width, 277 * MainForm.form.matrix.heightRoom - InputManager.mouseWorldPosition.y - xySymmetryObject.GetRender().height);
			}
			for (int i = 1; i < activeObject.Count; i++)
				if (!activeObject[i].render.mustNotMove)
					activeObject[i].coords = UniteVectors(activeObject[i].coords, delta);

			if (panelMode == 1)
				updatePanelCoords();
		}

		public override void MouseUp() {
			if (isMoved) {
				List<MoveObjectAction.MoveArgs> args = new List<MoveObjectAction.MoveArgs>();
				for (int i = 0; i < activeObject.Count; i++) {
					args.Add(new MoveObjectAction.MoveArgs(activeObject[i], startMovePoses[i], activeObject[i].coords));
				}
				isMoved = false;

				ActionManager.Add(new MoveObjectAction(args));
			}
		}

		public override void Draw() {
			if (activeObject == null)
				return;

			glColor3f(1, 0, 0);
			glLineWidth(1);
			foreach (RoomObject obj in activeObject) {
				glBegin(GL_LINE_LOOP);
				glVertex2i(obj.coords.x, obj.coords.y);
				glVertex2i(obj.GetRender().width + obj.coords.x, obj.coords.y);
				glVertex2i(obj.GetRender().width + obj.coords.x, obj.GetRender().height + obj.coords.y);
				glVertex2i(obj.coords.x, obj.GetRender().height + obj.coords.y);
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
				List<RoomObject> toAction = new List<RoomObject>(activeObject);

				FindSymmetryObjects();
				if (xSymmetryObject != null) {
					toAction.Add(xSymmetryObject);
					MainForm.form.objects.Remove(xSymmetryObject);
				}
				if (ySymmetryObject != null) {
					toAction.Add(ySymmetryObject);
					MainForm.form.objects.Remove(ySymmetryObject);
				}
				if (xySymmetryObject != null) {
					toAction.Add(xySymmetryObject);
					MainForm.form.objects.Remove(xySymmetryObject);
				}
				ActionManager.Add(new RemoveObjectAction(toAction));

				if (activeObject.Count == 1 && activeObject[0] is IExtendedData)
					((IExtendedData)activeObject[0]).closePanel();
				MainForm.form.objects.RemoveAll(x => activeObject.Contains(x) && !x.render.mustNotDelete);
				activeObject = null;
				loadObjectPanel();
			}
			else if (InputManager.IsKeyDown(System.Windows.Forms.Keys.Enter) && activeObject != null && activeObject.Count == 1 && activeObject[0] is RoomChunkObject) {
				RoomChunkObject obj = (RoomChunkObject)activeObject[0];
				MatrixType[,] forAction = new MatrixType[obj.renderer.matrix.GetLength(0), obj.renderer.matrix.GetLength(1)];
				for (int x = 0; x < forAction.GetLength(0); x++)
					for (int y = 0; y < forAction.GetLength(1); y++) {
						try {
							forAction[x, y] = MainForm.form.matrix.matrix[x + obj.coords.x, y + obj.coords.y];
						}
						catch (IndexOutOfRangeException ignore) { }
					}
				MainForm.form.matrix.Past(revert(obj.renderer.matrix, obj.mirror.x, obj.mirror.y), obj.coords);
				MainForm.form.objects.Remove(obj);

				ActionManager.Add(new PastAction(obj, forAction));
				activeObject = null;
				loadObjectPanel();
			}
			else if (InputManager.IsKeyDown(System.Windows.Forms.Keys.ControlKey)) {
				if (InputManager.IsKeyDown(System.Windows.Forms.Keys.C) && activeObject != null && activeObject.Count != 0)
					copyBuffer = activeObject.ConvertAll(x => x.Copy());
				else if (InputManager.IsKeyDown(System.Windows.Forms.Keys.V) && copyBuffer != null && copyBuffer.Count != 0) {
					if (copyBuffer.Exists(x => x.render.mustNotDelete || x.render.mustNotMove))
						return;

					List<RoomObject> toSpawn = copyBuffer.ConvertAll(x => x.Copy());
					foreach (RoomObject obj in toSpawn)
						ObjectsManager.SpawnObject(obj, false);
					ActionManager.Add(new PastObjectsAction(toSpawn));
				}
				else if (InputManager.IsKeyDown(System.Windows.Forms.Keys.B) && copyBuffer != null && copyBuffer.Count == 1 && copyBuffer[0] is IExtendedData &&
					activeObject != null && activeObject.Count != 0) {
					bool valid = true;
					for (int i = 0; i < activeObject.Count; i++)
						if (!(activeObject[i] is IExtendedData) || (!activeObject[i].prefabName.Equals(copyBuffer[0].prefabName) && !(copyBuffer[0].prefabName.Contains("Gate") ? activeObject[i].prefabName.Contains("Gate") : false)))
							valid = false;

					if (valid) {
						ActionManager.Add(new PastObjectDataAction(activeObject, ((IExtendedData)copyBuffer[0]).serializeData()));
						for (int i = 0; i < activeObject.Count; i++)
							((IExtendedData)activeObject[i]).deserializeData(((IExtendedData)copyBuffer[0]).serializeData());
					}
				}
			}
		}

		public static void MarkDirtyActiveObject() {
			if (MainForm.form.activeTool is EditObjectsTool) {
				EditObjectsTool tool = (EditObjectsTool)MainForm.form.activeTool;
				if (tool.activeObject != null && tool.activeObject.Count == 1 && tool.activeObject[0] is IExtendedData) {
					IExtendedData obj = (IExtendedData) tool.activeObject[0];
					obj.markDirty();
				}
			}
		}

		public static MatrixType[,] revert(MatrixType[,] matrix, bool xB, bool yB) {
			MatrixType[,] copy = (MatrixType[,]) matrix.Clone();
			for (int x = 0; x < copy.GetLength(0); x++)
				for (int y = 0; y < copy.GetLength(1); y++)
					copy[x, y] = matrix[xB ? matrix.GetLength(0) - 1 - x : x, yB ? matrix.GetLength(1) - 1 - y : y];
			return copy;
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
					xSymmetryObject = ObjectsManager.FindObject(obj => obj.coords.y == original.coords.y && 495 * MainForm.form.matrix.widthRoom - obj.coords.x - obj.GetRender().width == original.coords.x && obj.prefabName.Equals(original.prefabName));
				if (MainForm.form.YSymmetryBox.Checked)
					ySymmetryObject = ObjectsManager.FindObject(obj => 277 * MainForm.form.matrix.heightRoom - obj.coords.y - obj.GetRender().height == original.coords.y && obj.coords.x == original.coords.x && obj.prefabName.Equals(original.prefabName));
				if (MainForm.form.XYSymmetryBox.Checked)
					xySymmetryObject = ObjectsManager.FindObject(obj => 277 * MainForm.form.matrix.heightRoom - obj.coords.y - obj.GetRender().height == original.coords.y && 495 * MainForm.form.matrix.widthRoom - obj.coords.x - obj.GetRender().width == original.coords.x && obj.prefabName.Equals(original.prefabName));
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

		public void changeRenderType() {
			if (activeObject == null || activeObject.Count == 0)
				return;

			for (int i = 0; i < activeObject.Count; i++)
				activeObject[i].type = int.Parse(MainForm.form.renderTypeBox.Text);
		}

		public void loadObjectPanel() {
			panelMode = activeObject == null || activeObject.Count == 0 ? 0 : activeObject.Count == 1 ? 1 : 2;

			clearPanel();
			if (panelMode != 0)
				for (int i = 0; i < activeObject[0].render.types.Length; i++)
					MainForm.form.renderTypeBox.Items.Add("" + i);

			switch (panelMode) {
				case 0:
					MainForm.form.objectTransformPanel.Visible = false;
					break;
				case 1:
					MainForm.form.objectNameLabel.Text = activeObject[0].prefabName + " " + activeObject[0].ID;
					MainForm.form.objectXSizeLabel.Text = "W: " + activeObject[0].GetRender().width;
					MainForm.form.objectYSizeLabel.Text = "H: " + activeObject[0].GetRender().height;
					MainForm.form.renderTypeBox.Text = activeObject[0].type+"";
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
					bool sameObjects = true;
					bool sameType = true;
					for (int i = 0; i < activeObject.Count; i++)
						for (int j = 0; j < activeObject.Count; j++) {
							if (sameMirror && (activeObject[i].mirror.x != activeObject[j].mirror.x || activeObject[i].mirror.y != activeObject[j].mirror.y || activeObject[i].render.mustNotDoRenderWithSymmetry))
								sameMirror = false;

							if (sameType && activeObject[i].type != activeObject[j].type)
								sameType = false;

							if (sameObjects && !activeObject[i].prefabName.Equals(activeObject[j].prefabName))
								sameObjects = false;

							if (!sameMirror && !sameMirror && !sameObjects)
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

					if (sameType && sameObjects)
						MainForm.form.renderTypeBox.Text = activeObject[0].type + "";
					else if (sameObjects)
						MainForm.form.renderTypeBox.Text = "-";
					else {
						MainForm.form.renderTypeBox.Visible = false;
						MainForm.form.renderTypeLabel.Visible = false;
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
			MainForm.form.renderTypeBox.Visible = true;
			MainForm.form.renderTypeLabel.Visible = true;
			MainForm.form.objectNameLabel.Text = "";
			MainForm.form.objectXCoordsLabel.Text = "";
			MainForm.form.objectXSizeLabel.Text = "";
			MainForm.form.objectYCoordsLabel.Text = "";
			MainForm.form.objectYSizeLabel.Text = "";
			MainForm.form.renderTypeBox.Text = "";
			MainForm.form.renderTypeBox.Items.Clear();
		}
	}
}
