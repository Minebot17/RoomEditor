using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoomsEditor.Objects;
using RoomsEditor.Actions;
using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;
using static RoomsEditor.InputManager;

namespace RoomsEditor.Tools {
	class EditWallsTool : Tool {
		public Vec<int> startPos;
		private int mode; // 0 - select, 1 - add to select (shift), 2 - remove from select (ctrl), 3 - move selected area
		private static bool[,] selectionMatrix;
		public static MatrixType[,] tradeBuffer;
		private static Color color = new Color(0.6f, 0.6f, 1f, 0.5f);

		public EditWallsTool() {
			selectionMatrix = new bool[MainForm.form.matrix.matrix.GetLength(0), MainForm.form.matrix.matrix.GetLength(1)];
		}

		public override void MouseDown() {
			startPos = mouseWorldPosition;
			mode = IsMouseButtonDown(System.Windows.Forms.MouseButtons.Left) ? (IsKeyDown(System.Windows.Forms.Keys.ShiftKey) ? 1 : IsKeyDown(System.Windows.Forms.Keys.ControlKey) ? 2 : 0) : 3;
		}

		public override void MouseUp() {
			Vec<int> startPos = new Vec<int>(
				this.startPos.x < 0 ? 0 : this.startPos.x > MainForm.form.matrix.widthRoom * 495 ? MainForm.form.matrix.widthRoom * 495 : this.startPos.x,
				this.startPos.y < 0 ? 0 : this.startPos.y > MainForm.form.matrix.heightRoom * 277 ? MainForm.form.matrix.heightRoom * 277 : this.startPos.y);

			Vec<int> endPos = new Vec<int>(
				mouseWorldPosition.x < 0 ? 0 : mouseWorldPosition.x > MainForm.form.matrix.widthRoom * 495 ? MainForm.form.matrix.widthRoom * 495 : mouseWorldPosition.x,
				mouseWorldPosition.y < 0 ? 0 : mouseWorldPosition.y > MainForm.form.matrix.heightRoom * 277 ? MainForm.form.matrix.heightRoom * 277 : mouseWorldPosition.y);

			if (startPos.x > endPos.x) {
				startPos.x = startPos.x + endPos.x;
				endPos.x = startPos.x - endPos.x;
				startPos.x = startPos.x - endPos.x;
			}
			if (startPos.y > endPos.y) {
				startPos.y = startPos.y + endPos.y;
				endPos.y = startPos.y - endPos.y;
				startPos.y = startPos.y - endPos.y;
			}

			if (mode == 0)
				selectionMatrix = new bool[MainForm.form.matrix.matrix.GetLength(0), MainForm.form.matrix.matrix.GetLength(1)];
			FillSymmetry(startPos, endPos);
			this.startPos = new Vec<int>();
		}

		public override void Draw() {
			glColor4f(color.r, color.g, color.b, color.a);
			glBegin(GL_QUADS);
			for (int x = 0; x < selectionMatrix.GetLength(0); x++)
				for (int y = 0; y < selectionMatrix.GetLength(1); y++)
					if (selectionMatrix[x, y]) {
						glVertex2i(x, y);
						glVertex2i(x + 1, y);
						glVertex2i(x + 1, y + 1);
						glVertex2i(x, y + 1);
					}
			glEnd();

			if (startPos.isZero())
				return;
			else {
				DrawQuad(startPos, mouseWorldPosition, color);
				if (MainForm.form.XSymmetryBox.Checked)
					DrawQuad(new Vec<int>(selectionMatrix.GetLength(0) - startPos.x, startPos.y), new Vec<int>(selectionMatrix.GetLength(0) - mouseWorldPosition.x, mouseWorldPosition.y), color);
				if (MainForm.form.YSymmetryBox.Checked)
					DrawQuad(new Vec<int>(startPos.x, selectionMatrix.GetLength(1) - startPos.y), new Vec<int>(mouseWorldPosition.x, selectionMatrix.GetLength(1) - mouseWorldPosition.y), color);
				if (MainForm.form.XYSymmetryBox.Checked)
					DrawQuad(new Vec<int>(selectionMatrix.GetLength(0) - startPos.x, selectionMatrix.GetLength(1) - startPos.y), new Vec<int>(selectionMatrix.GetLength(0) - mouseWorldPosition.x, selectionMatrix.GetLength(1) - mouseWorldPosition.y), color);
			}

			MainForm.form.infoLabel.Text = "W: " + (mouseWorldPosition.x - startPos.x) + " H: " + (mouseWorldPosition.y - startPos.y);
			bool[] sides = new bool[4] {
				mouseWindowPosition.x < 10,
				mouseWindowPosition.x > MainForm.form.viewPort.Width - 10,
				mouseWindowPosition.y < 10,
				mouseWindowPosition.y > MainForm.form.viewPort.Height - 10
			};
			if (sides[0] || sides[1] || sides[2] || sides[3])
				TranslateMatrix(sides[0] ? (int)((mouseWindowPosition.x - 10) * -0.3f) : sides[1] ? (int)((mouseWindowPosition.x - MainForm.form.viewPort.Width + 10) * -0.3f) : 0, sides[2] ? (int)((mouseWindowPosition.y - 10) * -0.3f) : sides[3] ? (int)((mouseWindowPosition.y - MainForm.form.viewPort.Height + 10) * -0.3f) : 0);
		}

		public void FillSymmetry(Vec<int> from, Vec<int> to) {
			Fill(from, to);
			if (MainForm.form.XSymmetryBox.Checked)
				Fill(new Vec<int>(selectionMatrix.GetLength(0) - from.x, from.y), new Vec<int>(selectionMatrix.GetLength(0) - to.x, to.y));
			if (MainForm.form.YSymmetryBox.Checked)
				Fill(new Vec<int>(from.x, selectionMatrix.GetLength(1) - from.y), new Vec<int>(to.x, selectionMatrix.GetLength(1) - to.y));
			if (MainForm.form.XYSymmetryBox.Checked)
				Fill(new Vec<int>(selectionMatrix.GetLength(0) - from.x, selectionMatrix.GetLength(1) - from.y), new Vec<int>(selectionMatrix.GetLength(0) - to.x, selectionMatrix.GetLength(1) - to.y));
		}

		public void Fill(Vec<int> from, Vec<int> to) {
			if (from.x > to.x) {
				from.x = from.x + to.x;
				to.x = from.x - to.x;
				from.x = from.x - to.x;
			}
			if (from.y > to.y) {
				from.y = from.y + to.y;
				to.y = from.y - to.y;
				from.y = from.y - to.y;
			}
			for (int x = from.x; x < to.x; x++)
				for (int y = from.y; y < to.y; y++)
						selectionMatrix[x, y] = mode != 2;
		}

		public override void KeyDown() {
			bool ctrl = IsKeyDown(System.Windows.Forms.Keys.ControlKey);
			bool cut = ctrl && IsKeyDown(System.Windows.Forms.Keys.X);
			bool copy = ctrl && IsKeyDown(System.Windows.Forms.Keys.C);
			bool past = ctrl && IsKeyDown(System.Windows.Forms.Keys.V) && tradeBuffer != null;
			bool del = IsKeyDown(System.Windows.Forms.Keys.Delete);

			if (cut || copy || past || del){
				Vec<int> startCopyPos = new Vec<int>(selectionMatrix.GetLength(0), selectionMatrix.GetLength(1));
				Vec<int> endCopyPos = new Vec<int>();
				for (int x = 0; x < selectionMatrix.GetLength(0); x++)
					for (int y = 0; y < selectionMatrix.GetLength(1); y++) {
						if (selectionMatrix[x, y]) {
							if (startCopyPos.x > x)
								startCopyPos = new Vec<int>(x, startCopyPos.y);
							if (startCopyPos.y > y)
								startCopyPos = new Vec<int>(startCopyPos.x, y);
							if (endCopyPos.x < x)
								endCopyPos = new Vec<int>(x, endCopyPos.y);
							if (endCopyPos.y < y)
								endCopyPos = new Vec<int>(endCopyPos.x, y);
						}
					}

				if (past) {
					RoomObject obj = new RoomChunkObject(new MatrixRenderer(tradeBuffer));
					MainForm.form.objects.Add(obj);
					ActionManager.Add(new SpawnObjectAction(new List<RoomObject>() { obj }));
				}
				else if (del || copy || cut) {
					tradeBuffer = new MatrixType[endCopyPos.x - startCopyPos.x + 1, endCopyPos.y - startCopyPos.y + 1];
					bool[,] select = new bool[tradeBuffer.GetLength(0), tradeBuffer.GetLength(1)];
					for (int x = startCopyPos.x; x <= endCopyPos.x; x++)
						for (int y = startCopyPos.y; y <= endCopyPos.y; y++) {
							if (selectionMatrix[x, y]) {
								select[x - startCopyPos.x, y - startCopyPos.y] = true;
								tradeBuffer[x - startCopyPos.x, y - startCopyPos.y] = MainForm.form.matrix.matrix[x, y];
							}
						}

					if (cut || del) {
						ActionManager.Add(new CutAction(select, tradeBuffer, startCopyPos));
						DeleteSelected();
						MainForm.form.matrix.CompileList();
					}
				}
			}
		}

		private void DeleteSelected() {
			for (int x = 0; x < selectionMatrix.GetLength(0); x++)
				for (int y = 0; y < selectionMatrix.GetLength(1); y++)
					if (selectionMatrix[x, y])
						MainForm.form.matrix.matrix[x, y] = MatrixType.AIR;
		}
	}
}
