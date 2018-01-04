using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Objects;

namespace RoomsEditor.Actions {
	public class PastAction : IAction {
		public RoomChunkObject obj;
		public MatrixType[,] oldMatrix;

		public PastAction(RoomChunkObject obj, MatrixType[,] oldMatrix) {
			this.obj = obj;
			this.oldMatrix = oldMatrix;
		}

		public void Cancel() {
			ObjectsManager.SpawnObject(obj, false);
			for (int x = 0; x < oldMatrix.GetLength(0); x++)
				for (int y = 0; y < oldMatrix.GetLength(1); y++) {
					//try {
						MainForm.form.matrix.matrix[x + obj.coords.x, y + obj.coords.y] = oldMatrix[x, y];
					//}
					//catch (IndexOutOfRangeException ignore) { }
				}
			MainForm.form.matrix.CompileList();
		}

		public void Return() {
			MainForm.form.matrix.Past(Tools.EditObjectsTool.revert(obj.renderer.matrix, obj.mirror.x, obj.mirror.y), obj.coords);
			ObjectsManager.RemoveObject(obj, false);
		}
	}
}
