using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using static Tao.OpenGl.Gl;
using static Tao.OpenGl.Glu;
using static Tao.FreeGlut.Glut;
using static Tao.DevIl.Il;

namespace RoomsEditor {
	public static class Utils {
		public struct Vec<T>{
			public T x;
			public T y;

			public Vec(T x, T y) {
				this.x = x;
				this.y = y;
			}
		}

		public static Bitmap LoadBitmap(string fileName) {
			using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
				return new Bitmap(fs);
		}
	}
}
