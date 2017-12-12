﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Runtime.Serialization.Json;
using System.IO;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using RoomsEditor.Tools;
using RoomsEditor.Objects;
using static Tao.OpenGl.Gl;
using static Tao.OpenGl.Glu;
using static Tao.FreeGlut.Glut;
using static Tao.DevIl.Il;
using static RoomsEditor.Utils;
using static RoomsEditor.InputManager;

namespace RoomsEditor {
	public partial class MainForm : Form {
		public const float scaleForGrid = 3;
		public static Random rnd = new Random();
		public static MainForm form;
		public RoomMatrix matrix;
		public List<RoomObject> objects;
		public Tool oldTool;
		public Tool activeTool;
		bool isLoaded;

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

			glEnable(GL_BLEND);
			glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

			form = this;
			TextureManager.LoadAllTextures();
			ObjectsManager.ReadAllObjects();
			activeTool = new CreateWallTool(false);

			InputManager.scaleFactor = 1;

			isLoaded = true;
		}

		private void DrawViewPort(object sender, EventArgs e) {
			if (!isLoaded || matrix == null)
				return;

			glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

			glClearColor(0, 0, 0, 1);
			glColor3f(1.0f, 1.0f, 1.0f);
			glLoadIdentity();

			if (wheel != 0) {
				float oldScale = scaleFactor;
				ScaleMatrix(GetWheelDelta() > 0 ? 1.1f : 0.9f);
				if (oldScale < scaleForGrid && scaleFactor > scaleForGrid || oldScale > scaleForGrid && scaleFactor < scaleForGrid)
					matrix.CompileList();
			}

			if (IsKeyDown(Keys.Space) && !(activeTool is MoveTool)) {
				oldTool = activeTool;
				activeTool = new MoveTool();
			}
			else if (!IsKeyDown(Keys.Space) && activeTool is MoveTool) {
				activeTool.Disponse();
				activeTool = oldTool;
			}
			infoLabel.Text = mouseWorldPosition.ToString();

			glScalef(scaleFactor, scaleFactor, 1);
			glTranslatef(translate.x, translate.y, 0);

			matrix.Draw();
			glEnable(GL_TEXTURE_2D);
			for (int i = 0; i < objects.Count; i++)
				objects[i].Draw();
			glDisable(GL_TEXTURE_2D);
			activeTool.Draw();

			glFlush();
			viewPort.Invalidate();
		}

		#region "Handlers"
		private void viewPort_MouseWheel(object sender, MouseEventArgs e) {
			InputManager.MouseWheelHandle(e);
		}

		private void viewPort_MouseMove(object sender, MouseEventArgs e) {
			InputManager.MouseMoveHandle(e);
			activeTool.MouseMove();
		}

		private void viewPort_MouseDown(object sender, MouseEventArgs e) {
			InputManager.MouseDownHandle(e);
			activeTool.MouseDown();
		}

		private void viewPort_MouseUp(object sender, MouseEventArgs e) {
			InputManager.MouseUpHandle(e);
			activeTool.MouseUp();
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e) {
			InputManager.KeyDownHandle(e);
			activeTool.KeyDown();
		}

		private void MainForm_KeyUp(object sender, KeyEventArgs e) {
			InputManager.KeyUpHandle(e);
			activeTool.KeyUp();
		}

		private void viewPort_MouseLeave(object sender, EventArgs e) {
			InputManager.MouseLeaveHandle();
			activeTool.MouseLeave();
		}

		private void viewPort_MouseEnter(object sender, EventArgs e) {
			InputManager.MouseLeaveHandle();
			activeTool.MouseEnter();
		}
		#endregion

		private void сброситьТрансформациюToolStripMenuItem_Click(object sender, EventArgs e) {
			ResetTransformation();
		}

		private void оКToolStripMenuItem_Click(object sender, EventArgs e) {
			string text = toolStripComboBox1.Text;
			Vec<int> size = new Vec<int>(int.Parse(text[0]+""), int.Parse(text[2]+""));
			matrix = new RoomMatrix(size.x, size.y);
			objects = new List<RoomObject>();
			ResetTransformation();
		}

		private void CreateWallButton_Click(object sender, EventArgs e) {
			activeTool = new CreateWallTool(false);
		}

		private void CreateHideButton_Click(object sender, EventArgs e) {
			activeTool = new CreateWallTool(true);
		}

		private void EditObjectButton_Click(object sender, EventArgs e) {
			activeTool = new EditObjectsTool();
		}

		private void ObjectsView_MouseDoubleClick(object sender, MouseEventArgs e) {
			if (ObjectsView.SelectedItems.Count != 0)
				ObjectsManager.SpawnObject(ObjectsView.SelectedItems[0].Text);
		}
	}
}