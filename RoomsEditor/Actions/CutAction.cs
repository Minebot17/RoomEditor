using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RoomsEditor.Utils;

namespace RoomsEditor.Actions {
	public class CutAction : IAction {
		public bool[,] selection;
		public MatrixType[,] oldMatrix;
		public Vec<int> offset;

		public CutAction(bool[,] selection, MatrixType[,] oldMatrix, Vec<int> offset) {
			this.selection = selection;
			this.oldMatrix = oldMatrix;
			this.offset = offset;
		}

		public void Cancel() {
			for(int x = 0; x < selection.GetLength(0); x++)
				for(int y = 0; y < selection.GetLength(1); y++) {
					Tools.EditWallsTool.tradeBuffer = null;
					if (selection[x, y])
						MainForm.form.matrix.matrix[x + offset.x, y + offset.y] = oldMatrix[x, y];
				}
			MainForm.form.matrix.CompileList();
		}

		public void Return() {
			for (int x = 0; x < selection.GetLength(0); x++)
				for (int y = 0; y < selection.GetLength(1); y++) {
					Tools.EditWallsTool.tradeBuffer = oldMatrix;
					if (selection[x, y]) {
						MainForm.form.matrix.matrix[x + offset.x, y + offset.y] = MatrixType.AIR;
					}
				}
			MainForm.form.matrix.CompileList();
		}
	}
}
