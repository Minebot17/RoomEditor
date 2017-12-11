using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;
using static RoomsEditor.InputManager;

namespace RoomsEditor {
	public class RoomMatrix : IRenderer {
		public MatrixType[,] matrix;
		public int scaleFactor;
		public int widthRoom;
		public int heightRoom;
		private int list;
		public static Color[] colors = new Color[] {
			new Color(0xFFF0F0F0),
			new Color(0xFF283233),
			new Color(0xFF5E76E2)
		};

		public RoomMatrix(int width, int height) {
			widthRoom = width;
			heightRoom = height;
			matrix = new MatrixType[495*width,277*height];

			List<Func<Vec<int>, bool>> conditions = new List<Func<Vec<int>, bool>>();
			for (int x = 0; x < width; x++) {
				float xCenter = 495f*(x + 0.5f);
				conditions.Add(delegate (Vec<int> coords) {
					return coords.y < 23 && coords.x > xCenter - 38.5f && coords.x < xCenter + 38.5f;
				});
				conditions.Add(delegate (Vec<int> coords) {
					return coords.y > matrix.GetLength(1) - 23 && coords.x > xCenter - 38.5f && coords.x < xCenter + 38.5f;
				});
			}
			for (int y = 0; y < height; y++) {
				float yCenter = 277f * (y + 0.5f);
				conditions.Add(delegate (Vec<int> coords) {
					return coords.x < 46 && coords.y > yCenter - 38.5f && coords.y < yCenter + 38.5f;
				});
				conditions.Add(delegate (Vec<int> coords) {
					return coords.x > matrix.GetLength(0) - 46 && coords.y > yCenter - 38.5f && coords.y < yCenter + 38.5f;
				});
			}

			for (int x = 0; x < matrix.GetLength(0); x++)
				for (int y = 0; y < matrix.GetLength(1); y++) {
					if (x < 46 || x > matrix.GetLength(0) - 46 || y < 23 || y > matrix.GetLength(1) - 23) {
						bool yes = true;
						for (int i = 0; i < conditions.Count; i++) {
							if (conditions[i].Invoke(new Vec<int>(x, y))) {
								yes = false;
								break;
							}
						}

						matrix[x, y] = yes ? MatrixType.WALL : MatrixType.AIR;
					}
					else
						matrix[x, y] = MatrixType.AIR;
				}

			scaleFactor = width > height ? width : height;
			list = glGenLists(1);
			CompileList();
		}

		public void CompileList() {
			glNewList(list, GL_COMPILE);
			glBegin(GL_QUADS);
			for (int x = 0; x < matrix.GetLength(0); x++)
				for (int y = 0; y < matrix.GetLength(1); y++) {
					Color color = colors[(int)matrix[x,y]];
					glColor3f(color.r, color.g, color.b);
					glVertex2i(x, y);
					glVertex2i(x + 1, y);
					glVertex2i(x + 1, y + 1);
					glVertex2i(x, y + 1);
				}
			glEnd();

			if (InputManager.scaleFactor > 3) {
				glLineWidth(1);
				glBegin(GL_LINES);
				glColor3f(0.7f, 0.7f, 0.7f);
				for (int i = 0; i < matrix.GetLength(0); i++) {
					glVertex2i(i, 0);
					glVertex2i(i, matrix.GetLength(1));
				}
				for (int i = 0; i < matrix.GetLength(1); i++) {
					glVertex2i(0, i);
					glVertex2i(matrix.GetLength(0), i);
				}
				glEnd();
			}
			glEndList();
		}

		public void Draw() {
			glCallList(list);
		}

		public void Disponse() {
			glDeleteLists(list, 1);
		}

		public void Fill(MatrixType type, Vec<int> from, Vec<int> to) {
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
					matrix[x, y] = type;

			CompileList();
		}
	}

	public enum MatrixType {
		AIR = 0,
		WALL = 1,
		HIDENWALL = 2
	}
}
