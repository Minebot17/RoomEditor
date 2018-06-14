using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;
using RoomsEditor.Tools;
using RoomsEditor.Objects;
using RoomsEditor.Actions;
using RoomsEditor.Shaders;
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
			ShaderManager.RegisterShaders();
			activeTool = new CreateWallTool(false);

			InputManager.scaleFactor = 1;
			//glCullFace(GL_FRONT_AND_BACK);

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
			glDisable(GL_CULL_FACE);
			for (int i = 0; i < objects.Count; i++)
				objects[i].Draw();
			glEnable(GL_CULL_FACE);
			glDisable(GL_TEXTURE_2D);
			activeTool.Draw();

			glFlush();
			viewPort.Invalidate();
		}

		public void SetTool(Tool tool) {
			activeTool.Disponse();
			activeTool = tool;
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

			if (IsKeyDown(Keys.ControlKey)) {
				if (IsKeyDown(Keys.Z))
					ActionManager.Cancel();
				else if (IsKeyDown(Keys.Y))
					ActionManager.Return();
					
			}
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
			if (matrix != null)
				matrix.Disponse();
			activeTool.Disponse();
			ActionManager.Disponse();
			string text = toolStripComboBox1.Text;
			Vec<int> size = new Vec<int>(int.Parse(text[0]+""), int.Parse(text[2]+""));
			objects = new List<RoomObject>();
			matrix = new RoomMatrix(size.x, size.y);
			ResetTransformation();
			сохранитьToolStripMenuItem2.Enabled = true;
		}

		private void CreateWallButton_Click(object sender, EventArgs e) {
			SetTool(new CreateWallTool(false));
			SetPopupButtons();
			CreateWallButton.FlatStyle = FlatStyle.Flat;
		}

		private void CreateHideButton_Click(object sender, EventArgs e) {
			SetTool(new CreateWallTool(true));
			SetPopupButtons();
			CreateHideButton.FlatStyle = FlatStyle.Flat;
		}

		private void EditObjectButton_Click(object sender, EventArgs e) {
			SetTool(new EditObjectsTool());
			SetPopupButtons();
			EditObjectButton.FlatStyle = FlatStyle.Flat;
		}

		private void EditWallButton_Click(object sender, EventArgs e) {
			SetTool(new EditWallsTool());
			SetPopupButtons();
			EditWallButton.FlatStyle = FlatStyle.Flat;
		}

		private void SetPopupButtons() {
			CreateWallButton.FlatStyle = FlatStyle.Popup;
			CreateHideButton.FlatStyle = FlatStyle.Popup;
			EditObjectButton.FlatStyle = FlatStyle.Popup;
			EditWallButton.FlatStyle = FlatStyle.Popup;
		}

		private void ObjectsView_MouseDoubleClick(object sender, MouseEventArgs e) {
			if (ObjectsView.SelectedItems.Count != 0)
				ObjectsManager.SpawnObject(ObjectsView.SelectedItems[0].Text, true);
		}

		private void objectMirrorXBox_CheckedChanged(object sender, EventArgs e) {
			if (activeTool is EditObjectsTool)
				((EditObjectsTool)activeTool).changeMirror();
		}

		private void objectMirrorYBox_CheckedChanged(object sender, EventArgs e) {
			if (activeTool is EditObjectsTool)
				((EditObjectsTool)activeTool).changeMirror();
		}

		private void TypeBox_SelectedIndexChanged(object sender, EventArgs e) {
			if (activeTool is EditObjectsTool)
				((EditObjectsTool)activeTool).changeRenderType();
		}

		private void открытьToolStripMenuItem2_Click(object sender, EventArgs e) {
			DialogResult result = openFileDialog.ShowDialog();
			if (result != DialogResult.Cancel)
				SaveLoader.Load(openFileDialog.FileName);
		}

		private void сохранитьToolStripMenuItem2_Click(object sender, EventArgs e) {
			DialogResult result = saveFileDialog.ShowDialog();
			if (result != DialogResult.Cancel)
				SaveLoader.Save(saveFileDialog.FileName.Substring(saveFileDialog.FileName.Length - 5).Equals(".json") ? saveFileDialog.FileName : saveFileDialog.FileName + ".json");
		}


		public bool checkBoxSwitch;
		private void XSymmetryBox_CheckedChanged(object sender, EventArgs e) {
			if (!checkBoxSwitch)
				ActionManager.Add(new SwitchSymmetryAction((CheckBox)sender));
			else
				checkBoxSwitch = false;
		}

		private void YSymmetryBox_CheckedChanged(object sender, EventArgs e) {
			if (!checkBoxSwitch)
				ActionManager.Add(new SwitchSymmetryAction((CheckBox)sender));
			else
				checkBoxSwitch = false;
		}

		private void XYSymmetryBox_CheckedChanged(object sender, EventArgs e) {
			if (!checkBoxSwitch)
				ActionManager.Add(new SwitchSymmetryAction((CheckBox)sender));
			else
				checkBoxSwitch = false;
		}

		private void переключитьФонToolStripMenuItem_Click(object sender, EventArgs e) {
			if (matrix != null) {
				matrix.renderTextureBackground = !matrix.renderTextureBackground;
				matrix.CompileList();
			}
		}

		private void тестНаВыбранномОбъектеToolStripMenuItem_Click(object sender, EventArgs e) {
			if (!(activeTool is EditObjectsTool))
				return;

			List<RoomObject> activeObjects = ((EditObjectsTool)activeTool).activeObject;
			if (activeObjects == null || activeObjects.Count == 0)
				return;

			const string directoryPath = "Build/Build_Data/StreamingAssets";
			DirectoryInfo directory = new DirectoryInfo(directoryPath);
			if (directory.Exists)
				Directory.Delete(directoryPath, true);
			Directory.CreateDirectory(directoryPath);

			Vec<int> playerCoords = activeObjects[0].coords;
			SaveLoader.Save(directoryPath + "/room.json");
			File.WriteAllLines(directoryPath + "/gate.txt", new string[] {
				playerCoords.x + 8 + "",
				playerCoords.y + 33 + "",
				false.ToString()
			});

			System.Diagnostics.Process.Start(Application.StartupPath + "/Build/Build.exe");
		}

		private void BackUpTimer_Tick(object sender, EventArgs e) {
			if (matrix != null)
				SaveLoader.Save("backup.json");
		}

		private void backUpState_CheckedChanged(object sender, EventArgs e) {
			BackUpTimer.Enabled = backUpState.Checked;
		}
	}
}
