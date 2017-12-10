using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;

namespace RoomsEditor {
	public class RoomMatrix : IRenderer {
		public MatrixType[,] matrix;
		public int scaleFactor;
		public int widthRoom;
		public int heightRoom;
		private int list;
		private Color[] colors = new Color[] {
			new Color(0f, 1f, 0f, 1f),
			new Color(0.5f, 0.5f, 0.5f, 1f),
			new Color(1f, 1f, 1f, 1f)
		};

		public RoomMatrix(int width, int height) {
			widthRoom = width;
			heightRoom = height;
			matrix = new MatrixType[495,277];
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
					matrix[i, j] = MainForm.rnd.Next(2) == 0 ? MatrixType.AIR : MatrixType.WALL;

			scaleFactor = width > height ? width : height;
			list = glGenLists(1);
		}

		public void CompileList(bool drawGrid) {
			glNewList(list, GL_COMPILE);
			glPushMatrix();
			glScalef(scaleFactor, scaleFactor, scaleFactor);
			glBegin(GL_QUADS);
			for (int x = 0; x < matrix.GetLength(0); x++)
				for (int y = 0; y < matrix.GetLength(1); y++) {
					Color color = colors[(int)matrix[x,y]];
					glColor3f(color.r, color.g, color.b);
					glVertex2i(x * 4, y * 4);
					glVertex2i(x * 4 + 4, y * 4);
					glVertex2i(x * 4 + 4, y * 4 + 4);
					glVertex2i(x * 4, y * 4 + 4);
				}
			glEnd();

			if (drawGrid) {
				glLineWidth(1);
				glBegin(GL_LINES);
				glColor3f(1, 1, 1);
				for (int i = 0; i < matrix.GetLength(0); i++) {
					glVertex2i(i * 4, 0);
					glVertex2i(i * 4, matrix.GetLength(1) * 4);
				}
				for (int i = 0; i < matrix.GetLength(1); i++) {
					glVertex2i(0, i * 4);
					glVertex2i(matrix.GetLength(0) * 4, i * 4);
				}
				glEnd();
			}
			glPopMatrix();
			glEndList();
		}

		public void Draw() {
			glCallList(list);
		}

		public void Disponse() {
			glDeleteLists(list, 1);
		}
	}

	public enum MatrixType {
		AIR = 0,
		WALL = 1,
		HIDENWALL = 2
	}
}
