﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static RoomsEditor.Utils;
using static RoomsEditor.InputManager;

namespace RoomsEditor.Tools {
	class EditWallsTool : Tool {
		public Vec<int> startPos;
		private int mode; // 0 - select, 1 - add to select (shift), 2 - remove from select (ctrl), 3 - move selected area
		private bool[,] selectionMatrix;
		private MatrixType[,] tradeBuffer;

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

			//MainForm.form.matrix.FillSymmetry(isLeft ? (hiden ? MatrixType.HIDENWALL : MatrixType.WALL) : (hiden ? MatrixType.WALL : MatrixType.AIR), startPos, endPos, hiden ? (isLeft ? MatrixType.WALL : MatrixType.HIDENWALL) : MatrixType.AIR);
			this.startPos = new Vec<int>();
		}

		public override void Draw() {
			if (startPos.isZero())
				return;

			MainForm.form.infoLabel.Text = "W: " + (mouseWorldPosition.x - startPos.x) + " H: " + (mouseWorldPosition.y - startPos.y);
			bool[] sides = new bool[4] {
				mouseWindowPosition.x < 50,
				mouseWindowPosition.x > MainForm.form.viewPort.Width - 50,
				mouseWindowPosition.y < 50,
				mouseWindowPosition.y > MainForm.form.viewPort.Height - 50
			};
			if (sides[0] || sides[1] || sides[2] || sides[3])
				TranslateMatrix(sides[0] ? 1 : sides[1] ? -1 : 0, sides[2] ? 1 : sides[3] ? -1 : 0);

			//Color color = isLeft ? (hiden ? RoomMatrix.colors[2] : RoomMatrix.colors[1]) : hiden ? RoomMatrix.colors[1] : RoomMatrix.colors[0];
			//DrawQuad(startPos, mouseWorldPosition, color);
			//if (MainForm.form.XSymmetryBox.Checked)
			//	DrawQuad(new Vec<int>(495 * MainForm.form.matrix.widthRoom - startPos.x, startPos.y), new Vec<int>(495 * MainForm.form.matrix.widthRoom - mouseWorldPosition.x, mouseWorldPosition.y), color);
			//if (MainForm.form.YSymmetryBox.Checked)
			//	DrawQuad(new Vec<int>(startPos.x, 277 * MainForm.form.matrix.heightRoom - startPos.y), new Vec<int>(mouseWorldPosition.x, 277 * MainForm.form.matrix.heightRoom - mouseWorldPosition.y), color);
			//if (MainForm.form.XYSymmetryBox.Checked)
			//	DrawQuad(new Vec<int>(495 * MainForm.form.matrix.widthRoom - startPos.x, 277 * MainForm.form.matrix.heightRoom - startPos.y), new Vec<int>(495 * MainForm.form.matrix.widthRoom - mouseWorldPosition.x, 277 * MainForm.form.matrix.heightRoom - mouseWorldPosition.y), color);
		}

		private void AddSymmetry(Vec<int> from, Vec<int> to) {

		}

		private void RemoveSymmetry(Vec<int> from, Vec<int> to) {
		
}
	}
}
