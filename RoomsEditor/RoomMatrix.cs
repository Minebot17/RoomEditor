﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Objects;
using System.Runtime.Serialization;
using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;
using static RoomsEditor.InputManager;

namespace RoomsEditor {
	[DataContract]
	public class RoomMatrix : IRenderer {
		[DataMember]
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
					return coords.y < 24 && coords.x > xCenter - 33f && coords.x < xCenter + 33f;
				});
				conditions.Add(delegate (Vec<int> coords) {
					return coords.y > matrix.GetLength(1) - 24 && coords.x > xCenter - 33f && coords.x < xCenter + 33f;
				});

				RoomObject downGate = ObjectsManager.GetObjectByRenderName("downGate");
				RoomObject topGate = ObjectsManager.GetObjectByRenderName("topGate");
				downGate.coords = new Vec<int>((int)(xCenter - 33f), 0);
				topGate.coords = new Vec<int>((int)(xCenter - 33f), 277 * height - 23);
				MainForm.form.objects.Add(downGate);
				MainForm.form.objects.Add(topGate);
			}
			for (int y = 0; y < height; y++) {
				float yCenter = 277f * (y + 0.5f);
				conditions.Add(delegate (Vec<int> coords) {
					return coords.x < 46 && coords.y > yCenter - 33f && coords.y < yCenter + 33f;
				});
				conditions.Add(delegate (Vec<int> coords) {
					return coords.x > matrix.GetLength(0) - 46 && coords.y > yCenter - 33f && coords.y < yCenter + 33f;
				});

				RoomObject leftGate = ObjectsManager.GetObjectByRenderName("leftGate");
				RoomObject rightGate = ObjectsManager.GetObjectByRenderName("rightGate");
				leftGate.coords = new Vec<int>(0, (int)(yCenter - 33f));
				rightGate.coords = new Vec<int>(495 * width - 45, (int)(yCenter - 33f));
				MainForm.form.objects.Add(leftGate);
				MainForm.form.objects.Add(rightGate);
			}

			for (int x = 0; x < matrix.GetLength(0); x++)
				for (int y = 0; y < matrix.GetLength(1); y++) {
					if (x < 45 || x > matrix.GetLength(0) - 46 || y < 23 || y > matrix.GetLength(1) - 24) {
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

		public void DeleteWallsInGates() {
			List<Func<Vec<int>, bool>> conditions = new List<Func<Vec<int>, bool>>();
			for (int x = 0; x < widthRoom; x++) {
				float xCenter = 495f * (x + 0.5f);
				conditions.Add(delegate (Vec<int> coords) {
					return coords.y < 24 && coords.x > xCenter - 33f && coords.x < xCenter + 33f;
				});
				conditions.Add(delegate (Vec<int> coords) {
					return coords.y > matrix.GetLength(1) - 24 && coords.x > xCenter - 33f && coords.x < xCenter + 33f;
				});
			}
			for (int y = 0; y < heightRoom; y++) {
				float yCenter = 277f * (y + 0.5f);
				conditions.Add(delegate (Vec<int> coords) {
					return coords.x < 46 && coords.y > yCenter - 33f && coords.y < yCenter + 33f;
				});
				conditions.Add(delegate (Vec<int> coords) {
					return coords.x > matrix.GetLength(0) - 46 && coords.y > yCenter - 33f && coords.y < yCenter + 33f;
				});
			}

			for (int x = 0; x < matrix.GetLength(0); x++)
				for (int y = 0; y < matrix.GetLength(1); y++) {
					if (x < 45 || x > matrix.GetLength(0) - 46 || y < 23 || y > matrix.GetLength(1) - 24) {
						bool yes = true;
						for (int i = 0; i < conditions.Count; i++) {
							if (conditions[i].Invoke(new Vec<int>(x, y))) {
								yes = false;
								break;
							}
						}

						if (!yes)
							matrix[x, y] = MatrixType.AIR;
					}
				}
		}

		public void CompileList() {
			List<Polygon> polygons = new List<Polygon>();
			List<Vec<int>> checkedPoints = new List<Vec<int>>();
			for (int y = 0; y < matrix.GetLength(1); y++) {
				int thisIndex = 0;
				MatrixType thisType = matrix[0, y];

				for (int x = 0; x < matrix.GetLength(0); x++) {
					if (matrix[x, y] != thisType || matrix.GetLength(0) == x + 1) {
						polygons.Add(new Polygon(thisType, new Vec<int>(thisIndex, y), x - thisIndex));
						thisIndex = x;
						thisType = matrix[x, y];
					}
				}
			}

			glNewList(list, GL_COMPILE);
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

		public void FillSymmetry(MatrixType type, Vec<int> from, Vec<int> to, MatrixType layer) {
			Fill(type, from, to, layer);
			if (MainForm.form.XSymmetryBox.Checked)
				Fill(type, new Vec<int>(495 * widthRoom - from.x, from.y), new Vec<int>(495 * widthRoom - to.x, to.y), layer);
			if (MainForm.form.YSymmetryBox.Checked)
				Fill(type, new Vec<int>(from.x, 277 * heightRoom - from.y), new Vec<int>(to.x, 277 * heightRoom - to.y), layer);
			if (MainForm.form.XYSymmetryBox.Checked)
				Fill(type, new Vec<int>(495 * widthRoom - from.x, 277 * heightRoom - from.y), new Vec<int>(495 * widthRoom - to.x, 277 * heightRoom - to.y), layer);
			CompileList();
		}

		public void Fill(MatrixType type, Vec<int> from, Vec<int> to, MatrixType layer) {
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
					if (layer == MatrixType.AIR || matrix[x, y] == layer)
						matrix[x, y] = type;
		}

		public void Past(MatrixType[,] toPast, Vec<int> startCoord) {
			for (int x = 0; x < toPast.GetLength(0); x++)
				for (int y = 0; y < toPast.GetLength(1); y++)
					if (toPast[x, y] != MatrixType.AIR)
						matrix[x + startCoord.x, y + startCoord.y] = toPast[x, y];

			CompileList();
		}

		private struct Polygon {
			public Vec<int> offset;
			public int lenght;
			public MatrixType type;
			public Polygon(MatrixType type, Vec<int> offset, int lenght) {
				this.type = type;
				this.offset = offset;
				this.lenght = lenght;
			}
		}
	}

	[DataContract]
	public enum MatrixType {
		AIR = 0,
		WALL = 1,
		HIDENWALL = 2
	}
}
