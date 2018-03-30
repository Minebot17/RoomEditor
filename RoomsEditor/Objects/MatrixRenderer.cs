using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tao.OpenGl.Gl;
using static RoomsEditor.RoomMatrix;
using static RoomsEditor.Utils;

namespace RoomsEditor.Objects {
	public class MatrixRenderer : IRenderer {
		public MatrixType[,] matrix;
		private List<Polygon> polygons = new List<Polygon>();
		public static Color[] colors = new Color[] {
			new Color(0xFFF0F0F0),
			new Color(0xFF283233),
			new Color(0xFF5E76E2)
		};

		public MatrixRenderer(MatrixType[,] matrix) {
			this.matrix = matrix;
			for (int y = 0; y < matrix.GetLength(1); y++) {
				int thisIndex = 0;
				MatrixType thisType = matrix[0, y];

				for (int x = 0; x < matrix.GetLength(0); x++) {
					if (matrix[x, y] != thisType || matrix.GetLength(0) == x + 1) {
						if (thisType != MatrixType.AIR)
							polygons.Add(new Polygon(thisType, new Vec<int>(thisIndex, y), x - thisIndex));
						thisIndex = x;
						thisType = matrix[x, y];
					}
				}
			}
		}

		public void Draw(int type) {
			Draw();
		}

		public void Draw() {
			glDisable(GL_TEXTURE_2D);
			glBegin(GL_QUADS);
			foreach (Polygon polygon in polygons) {
				Color color = colors[(int)polygon.type];
				glColor3f(color.r, color.g, color.b);
				glVertex2i(polygon.offset.x, polygon.offset.y);
				glVertex2i(polygon.offset.x + polygon.lenght, polygon.offset.y);
				glVertex2i(polygon.offset.x + polygon.lenght, polygon.offset.y + 1);
				glVertex2i(polygon.offset.x, polygon.offset.y + 1);
			}
			glEnd();
			glEnable(GL_TEXTURE_2D);
		}
	}
}
