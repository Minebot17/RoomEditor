using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using static Tao.OpenGl.Gl;
using static Tao.OpenGl.Glu;
using static Tao.FreeGlut.Glut;
using static Tao.DevIl.Il;

namespace RoomsEditor {
	public static class Utils {
		[DataContract]
		public struct Vec<T>{
			[DataMember]
			public T x;
			[DataMember]
			public T y;

			public Vec(T x, T y) {
				this.x = x;
				this.y = y;
			}

			public bool isZero() => x.Equals(0) && y.Equals(0);
			public override String ToString() => "X: " + x.ToString() + " Y: " + y.ToString();
			public override int GetHashCode() => x.GetHashCode() + y.GetHashCode();
			public override bool Equals(object obj) => x.Equals(((Vec<T>)obj).x) && y.Equals(((Vec<T>)obj).y);
		}

		public struct Color {
			public float r;
			public float g;
			public float b;
			public float a;

			public Color(float r, float g, float b, float a) {
				this.r = r;
				this.g = g;
				this.b = b;
				this.a = a;
			}

			public Color(uint argb) {
				this.a = ((argb & -16777216) >> 0x18) / 255f;
				this.r = ((argb & 0xff0000) >> 0x10) / 255f;
				this.g = ((argb & 0xff00) >> 8) / 255f;
				this.b = (argb & 0xff) / 255f;
			}

			public override String ToString() => "R: " + r.ToString() + " G: " + g.ToString() + " B: " + b.ToString() + " A: " + a.ToString();
			public override int GetHashCode() => a.GetHashCode() + r.GetHashCode() + b.GetHashCode() + a.GetHashCode();
			public override bool Equals(object obj) => r == ((Color)obj).r && g == ((Color)obj).g && b == ((Color)obj).b && a == ((Color)obj).a;
		}

		public static Bitmap LoadBitmap(string fileName) {
			using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
				return new Bitmap(fs);
		}

		public static void DrawQuad(Vec<int> start, Vec<int> end, Color color) {
			glDisable(GL_CULL_FACE);
			glColor4f(color.r, color.g, color.b, color.a);
			glBegin(GL_QUADS);
			glVertex2i(start.x, start.y);
			glVertex2i(end.x, start.y);
			glVertex2i(end.x, end.y);
			glVertex2i(start.x, end.y);
			glEnd();
			glEnable(GL_CULL_FACE);
		}

		public static float GetDistance(Vec<float> from, Vec<float> to) {
			Vec<float> delta = GetDelta(from, to);
			return GetLength(delta);
		}

		public static float GetDistance(Vec<int> from, Vec<int> to) {
			Vec<int> delta = GetDelta(from, to);
			return GetLength(delta);
		}

		public static float GetLength(Vec<float> vector) {
			return (float)Math.Sqrt(vector.x * vector.x + vector.y * vector.y);
		}

		public static float GetLength(Vec<int> vector) {
			return (float)Math.Sqrt(vector.x * vector.x + vector.y * vector.y);
		}

		public static Vec<float> GetDelta(Vec<float> from, Vec<float> to) {
			return new Vec<float>(to.x - from.x, to.y - from.y);
		}

		public static Vec<int> GetDelta(Vec<int> from, Vec<int> to) {
			return new Vec<int>(to.x - from.x, to.y - from.y);
		}

		public static Vec<int> UniteVectors(params Vec<int>[] vectors) {
			Vec<int> result = new Vec<int>();
			foreach (Vec<int> vector in vectors)
				result = new Vec<int>(result.x + vector.x, result.y + vector.y);
			return result;
		}

		public static Vec<int> SubstractVector(Vec<int> vector1, Vec<int> vector2) {
			return new Vec<int>(vector1.x - vector2.x, vector1.y - vector2.y);
		}
	}
}
