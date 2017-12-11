using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;

namespace RoomsEditor {
	public static class InputManager {
		public static float scaleFactor;
		public static Vec<int> translate;
		public static int wheel;

		public static Vec<int> mouseWindowPosition;
		public static float deltaWindowDistance;
		public static Vec<int> deltaWindowVector;

		public static Vec<int> mouseWorldPosition;
		public static float deltaWorldDistance;
		public static Vec<int> deltaWorldVector;

		public static List<Keys> keys = new List<Keys>();
		public static List<MouseButtons> buttons = new List<MouseButtons>();

		public static bool IsKeyDown(Keys key) {
			return keys.Contains(key);
		}

		public static bool IsMouseButtonDown(MouseButtons button) {
			return buttons.Contains(button);
		}

		public static int GetWheelDelta() {
			int flag = wheel;
			wheel = 0;
			return flag;
		}

		public static float GetMouseWindowDelta() {
			float flag = deltaWindowDistance;
			deltaWindowDistance = 0;
			deltaWindowVector = new Vec<int>();
			return flag;
		}

		public static float GetMouseWorldDelta() {
			float flag = deltaWorldDistance;
			deltaWorldDistance = 0;
			deltaWorldVector = new Vec<int>();
			return flag;
		}

		public static void SetMatrixTranslation(int x, int y) {
			Vec<int> delta = GetDelta(translate, new Vec<int>(x, y));
			TranslateMatrix(delta.x, delta.y);
		}

		public static void TranslateMatrix(int x, int y) {
			//glTranslatef(x, y, 0);
			translate = UniteVectors(translate, new Vec<int>(x, y));
		}

		public static void ScaleMatrix(float scale) {
			//glScalef(scale, scale, 0);
			scaleFactor *= scale;
		}

		public static void ResetTransformation() {
			scaleFactor = 2f/MainForm.form.matrix.scaleFactor;
			translate = new Vec<int>();
		}

		#region "Handlers"
		public static void KeyDownHandle(KeyEventArgs args) {
			if (!keys.Contains(args.KeyCode))
				keys.Add(args.KeyCode);
		}

		public static void KeyUpHandle(KeyEventArgs args) {
			if (keys.Contains(args.KeyCode))
				keys.Remove(args.KeyCode);
		}

		public static void MouseDownHandle(MouseEventArgs e) {
			buttons.Add(e.Button);
		}

		public static void MouseUpHandle(MouseEventArgs e) {
			if (buttons.Contains(e.Button))
				buttons.Remove(e.Button);
		}

		public static void MouseMoveHandle(MouseEventArgs e) {
			Vec<int> mousePos = new Vec<int>(e.X, MainForm.form.viewPort.Height - e.Y);
			Vec<int> mouseWorldPos = new Vec<int>((int)Math.Round(mouseWindowPosition.x / scaleFactor - translate.x), (int)Math.Round(mouseWindowPosition.y / scaleFactor - translate.y));

			deltaWindowDistance += GetDistance(mouseWindowPosition, mousePos);
			deltaWindowVector = UniteVectors(deltaWindowVector, GetDelta(mouseWindowPosition, mousePos));

			deltaWorldDistance += GetDistance(mouseWorldPosition, mouseWorldPos);
			deltaWorldVector = UniteVectors(deltaWorldVector, GetDelta(mouseWorldPosition, mouseWorldPos));

			if (deltaWindowDistance != 0)
				mouseWindowPosition = mousePos;

			if (deltaWorldDistance != 0)
				mouseWorldPosition = mouseWorldPos;
		}

		public static void MouseWheelHandle(MouseEventArgs e) {
			wheel = e.Delta == 0 ? 0 : e.Delta > 0 ? 1 : -1;
		}

		public static void MouseLeaveHandle() {
			keys = new List<Keys>();
			buttons = new List<MouseButtons>();
			MainForm.form.viewPort.Cursor = Cursors.Default;
		}
		#endregion
	}
}
