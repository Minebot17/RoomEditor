using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RoomsEditor.Utils;

namespace RoomsEditor.Actions {
	public class CreateWallAction : IAction {
		public List<OldChunk> oldChunks;

		public CreateWallAction(List<OldChunk> oldChunks) {
			this.oldChunks = oldChunks;
		}

		public void Cancel() {
			foreach (OldChunk oldChunk in oldChunks)
				for (int x = oldChunk.offset.x; x < oldChunk.offset.x + oldChunk.matrix.GetLength(0); x++)
					for (int y = oldChunk.offset.y; y < oldChunk.offset.y + oldChunk.matrix.GetLength(1); y++)
						MainForm.form.matrix.matrix[x, y] = oldChunk.matrix[x - oldChunk.offset.x, y - oldChunk.offset.y];
			MainForm.form.matrix.CompileList();
		}

		public void Return() {
			foreach (OldChunk filling in oldChunks)
				MainForm.form.matrix.Fill(filling.type, filling.offset, new Vec<int>(filling.offset.x + filling.matrix.GetLength(0), filling.offset.y + filling.matrix.GetLength(1)), filling.layer);
			MainForm.form.matrix.CompileList();
		}

		public struct OldChunk {
			public MatrixType[,] matrix;
			public Vec<int> offset;

			public MatrixType type;
			public MatrixType layer;

			public OldChunk(MatrixType[,] matrix, Vec<int> offset, MatrixType type, MatrixType layer) {
				this.matrix = matrix;
				this.offset = offset;
				this.type = type;
				this.layer = layer;
			}
		}
	}
}
