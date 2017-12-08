using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using static Tao.OpenGl.Gl;
using static Tao.OpenGl.Glu;
using static Tao.FreeGlut.Glut;
using static Tao.DevIl.Il;

namespace RoomsEditor {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
			viewPort.InitializeContexts();
		}

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

			glEnable(GL_DEPTH_TEST);
			glLineWidth(5);
		}

		private void DrawViewPort(object sender, EventArgs e) {
			glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

			glLoadIdentity();
			glClearColor(0, 0, 0, 1);
			glColor3f(1.0f, 0, 0);

			glPushMatrix();

			glBegin(GL_LINES);
			glVertex2i(0, 0);
			glVertex2i(280, 280);
			glEnd();

			glPopMatrix();
			glFlush();
			viewPort.Invalidate();
		}
	}
}
