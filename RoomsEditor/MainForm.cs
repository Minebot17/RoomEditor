using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using static Tao.OpenGl.Gl;
using static Tao.OpenGl.Glu;
using static Tao.FreeGlut.Glut;
using static Tao.DevIl.Il;
using static RoomsEditor.Utils;
using static RoomsEditor.InputManager;

namespace RoomsEditor {
	public partial class MainForm : Form {
		public static Random rnd = new Random();
		public static MainForm form;
		public RoomMatrix matrix;
		bool isLoaded;

		public MainForm() {
			InitializeComponent();
			viewPort.InitializeContexts();
		}
		private RoomObject testObj;

		private void MainForm_Load(object sender, EventArgs e) {
			glutInit();
			glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH);
			ilInit();
			ilEnable(IL_ORIGIN_SET);
			glClearColor(255, 255, 255, 1);
			glViewport(0, 0, viewPort.Width, viewPort.Height);

			// настройка проекции
			glMatrixMode(GL_PROJECTION);
			glLoadIdentity();
			gluOrtho2D(0.0, viewPort.Width, 0.0, viewPort.Height);
			glMatrixMode(GL_MODELVIEW);

			//glEnable(GL_DEPTH_TEST);
			glEnable(GL_BLEND);
			glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

			TextureManager.LoadAllTextures();
			testObj = new RoomObject("asd", "Obj.png", 26, 30, new Vec<int>(147, 144));
			matrix = new RoomMatrix(1, 1);
			matrix.CompileList(true);
			form = this;
			InputManager.scaleFactor = 1;
			isLoaded = true;
		}

		private void DrawViewPort(object sender, EventArgs e) {
			if (!isLoaded)
				return;

			glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

			glClearColor(0, 0, 0, 1);
			glColor3f(1.0f, 1.0f, 1.0f);
			glLoadIdentity();

			Console.WriteLine(mouseWorldPosition);
			if (wheel != 0) {
				ScaleMatrix(GetWheelDelta() > 0 ? 1.1f : 0.9f);
			}

			if (IsKeyDown(Keys.Space)) {
				float xTranslate = deltaWindowVector.x / scaleFactor;
				float yTranslate = deltaWindowVector.y / scaleFactor;
				if (GetMouseWindowDelta() > 2 && IsMouseButtonDown(MouseButtons.Left))
					TranslateMatrix((int)xTranslate, (int)yTranslate);
			}

			glScalef(scaleFactor, scaleFactor, 1);
			glTranslatef(translate.x, translate.y, 0);
			matrix.Draw();

			glEnable(GL_TEXTURE_2D);
			testObj.Draw();
			glDisable(GL_TEXTURE_2D);

			glFlush();
			viewPort.Invalidate();
		}

		#region "Handlers"
		private void viewPort_MouseWheel(object sender, MouseEventArgs e) {
			InputManager.MouseWheelHandle(e);
		}

		private void viewPort_MouseMove(object sender, MouseEventArgs e) {
			InputManager.MouseMoveHandle(e);
		}

		private void viewPort_MouseDown(object sender, MouseEventArgs e) {
			InputManager.MouseDownHandle(e);
		}

		private void viewPort_MouseUp(object sender, MouseEventArgs e) {
			InputManager.MouseUpHandle(e);
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e) {
			InputManager.KeyDownHandle(e);
			if (e.KeyCode == Keys.Space)
				viewPort.Cursor = Cursors.Hand;
		}

		private void MainForm_KeyUp(object sender, KeyEventArgs e) {
			InputManager.KeyUpHandle(e);
			if (e.KeyCode == Keys.Space)
				viewPort.Cursor = Cursors.Default;
		}

		private void viewPort_MouseLeave(object sender, EventArgs e) {
			InputManager.MouseLeaveHandle();
		}
		#endregion

		private void viewPort_MouseEnter(object sender, EventArgs e) {
			InputManager.MouseLeaveHandle();
		}
	}
}
