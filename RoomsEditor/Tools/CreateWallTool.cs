using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;
using static RoomsEditor.InputManager;

namespace RoomsEditor.Tools {
	public class CreateWallTool : Tool {
		public Vec<int> startPos;

		public override void MouseDown() => startPos = mouseWorldPosition;

		public override void MouseUp() {
			Vec<int> startPos = new Vec<int>(
				this.startPos.x < 0 ? 0 : this.startPos.x > MainForm.form.matrix.widthRoom * 495 ? MainForm.form.matrix.widthRoom * 495 : this.startPos.x,
				this.startPos.y < 0 ? 0 : this.startPos.y > MainForm.form.matrix.heightRoom * 277 ? MainForm.form.matrix.heightRoom * 277 : this.startPos.y);

			Vec<int> endPos = new Vec<int>(
				mouseWorldPosition.x < 0 ? 0 : mouseWorldPosition.x > MainForm.form.matrix.widthRoom * 495 ? MainForm.form.matrix.widthRoom * 495 : mouseWorldPosition.x,
				mouseWorldPosition.y < 0 ? 0 : mouseWorldPosition.y > MainForm.form.matrix.heightRoom * 277 ? MainForm.form.matrix.heightRoom * 277 : mouseWorldPosition.y);
			
			MainForm.form.matrix.Fill(MatrixType.WALL, startPos, endPos);
			this.startPos = new Vec<int>();
		}

		public override void Draw() {
			if (startPos.isZero())
				return;

			bool[] sides = new bool[4] {
				mouseWindowPosition.x < 100,
				mouseWindowPosition.x > MainForm.form.viewPort.Width - 100,
				mouseWindowPosition.y < 100,
				mouseWindowPosition.y > MainForm.form.viewPort.Height - 100
			};
			if (sides[0] || sides[1] || sides[2] || sides[3])
				TranslateMatrix(sides[0] ? 1 : sides[1] ? -1 : 0, sides[2] ? 1 : sides[3] ? -1 : 0);
			DrawQuad(startPos, mouseWorldPosition, RoomMatrix.colors[1]);
		}
	}
}
