using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using RoomsEditor.Objects;
using static RoomsEditor.Utils;
using System.Windows.Forms;

namespace RoomsEditor.Panels {
	public partial class GatePanel : UserControl {
		public int type;
		public List<int> existsIDs = new List<int>();
		public List<int> unexistsIDs = new List<int>();
		public bool selectMode;
		public RoomObject selectedObject; // Устанавливается из класса объекта
		public GateObject gate;

		public static string[] types = new string[] {
			"Может существовать",
			"Существует",
			"Не существует"
		};

		public GatePanel(int type, List<int> existsIDs, List<int> unexistsIDs, GateObject gate) {
			InitializeComponent();
			this.type = type;
			this.existsIDs = existsIDs;
			this.unexistsIDs = unexistsIDs;
			this.gate = gate;

			typeBox.Text = types[type];
			for (int i = 0; i < types.Length; i++)
				typeBox.Items.Add(types[i]);

			updateLists();
			label2.Visible = type == 0;
			selectButton.Visible = type == 0;
			infoButton.Visible = type == 0;
			gateDataTab.Visible = type == 0;
		}

		public void updateLists() {
			existsIDs.RemoveAll(x => ObjectsManager.FindObjectByID(x) == null);
			existsList.Items.Clear();
			for (int i = 0; i < existsIDs.Count; i++) {
				existsList.Items.Add(ObjectsManager.FindObjectByID(existsIDs[i]).prefabName + " " + existsIDs[i]);
			}

			unexistsIDs.RemoveAll(x => ObjectsManager.FindObjectByID(x) == null);
			unexistsList.Items.Clear();
			for (int i = 0; i < unexistsIDs.Count; i++) {
				unexistsList.Items.Add(ObjectsManager.FindObjectByID(unexistsIDs[i]).prefabName + " " + unexistsIDs[i]);
			}
		}

		private void infoButton_Click(object sender, EventArgs e) {
			MessageBox.Show("Ниже этой кнопки надо внести в список объекты, которые будут убираться в одном из случаев. Что бы внести объекты в список, надо нажать на требуемую вкладку, далее нажать на кнопку 'Выбрать', навестись на объект и нажать Ctrl. Когда объекты будут выбраны, надо нажать 'Готово'. Если вы хотите удалить объекты, то просто выделите их и нажмите Delete. Выделенные объекты подсвечиваются синим");
		}

		private void setTypeButton_Click(object sender, EventArgs e) {
			int selectedType = -1;
			for (int i = 0; i < types.Length; i++)
				if (types[i].Equals(typeBox.Text)) {
					selectedType = i;
				}

			if (selectedType == -1) {
				MessageBox.Show("Такого типа не существует", "Ошибка");
				return;
			}

			label2.Visible = selectedType == 0;
			selectButton.Visible = selectedType == 0;
			infoButton.Visible = selectedType == 0;
			gateDataTab.Visible = selectedType == 0;
			type = selectedType;
			Tools.EditObjectsTool.MarkDirtyActiveObject();
		}

		private void selectButton_Click(object sender, EventArgs e) {
			selectButton.Text = selectMode ? "Выбрать" : "Готово";
			selectMode = !selectMode;
		}

		private void selectButton_Leave(object sender, EventArgs e) {
			if (selectMode)
				selectButton_Click(sender, e);
		}

		private void selectButton_KeyDown(object sender, KeyEventArgs e) {
			List<int> list = gateDataTab.SelectedTab.Name.Equals("tabPage") ? existsIDs : unexistsIDs;
			if (e.KeyCode == Keys.ControlKey && selectedObject != null && !list.Exists(x => x == selectedObject.ID) && !(selectedObject is GateObject)) {
				list.Add(selectedObject.ID);
				((ListBox)gateDataTab.SelectedTab.Controls[0]).Items.Add(selectedObject.prefabName + " " + selectedObject.ID);
				Tools.EditObjectsTool.MarkDirtyActiveObject();
			}
		}

		private void existsList_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete && existsList.SelectedItems.Count != 0) {
				for (int i = 0; i < existsList.SelectedItems.Count; i++) {
					existsIDs.Remove(int.Parse(existsList.SelectedItems[i].ToString().Split(' ')[1]));
					existsList.Items.Remove(existsList.SelectedItems[i]);
					Tools.EditObjectsTool.MarkDirtyActiveObject();
				}
			}
		}

		private void unexistsList_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete && unexistsList.SelectedItems.Count != 0) {
				for (int i = 0; i < unexistsList.SelectedItems.Count; i++) {
					unexistsIDs.Remove(int.Parse(unexistsList.SelectedItems[i].ToString().Split(' ')[1]));
					unexistsList.Items.Remove(unexistsList.SelectedItems[i]);
					Tools.EditObjectsTool.MarkDirtyActiveObject();
				}
			}
		}

		private void testRoomButton_Click(object sender, EventArgs e) {
			const string directoryPath = "Build/RogueLikeTest_Data/StreamingAssets";
			DirectoryInfo directory = new DirectoryInfo(directoryPath);
			if (directory.Exists)
				Directory.Delete(directoryPath, true);
			Directory.CreateDirectory(directoryPath);

			bool isTopDownGate = gate.coords.y == 0 || gate.coords.y == 277 * MainForm.form.matrix.heightRoom - 23;
			Vec<int> playerCoords = gate.coords;
			playerCoords.x += isTopDownGate ? 33 : 22;
			playerCoords.y += isTopDownGate ? 11 : 33;

			SaveLoader.Save(directoryPath + "/room.json");
			File.WriteAllLines(directoryPath + "/gate.txt", new string[] {
				playerCoords.x + "",
				playerCoords.y + "",
				(gate.coords.y == 0).ToString()
			});

			System.Diagnostics.Process.Start(Application.StartupPath + "/Build/RogueLikeTest.exe");
		}
	}
}
