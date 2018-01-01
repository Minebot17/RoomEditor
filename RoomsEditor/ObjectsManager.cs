using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Json;
using RoomsEditor.Objects;
using System.Runtime.Serialization;
using static RoomsEditor.InputManager;

namespace RoomsEditor {
	public static class ObjectsManager {
		private static Dictionary<ObjectRenderer, Type> rendersList = new Dictionary<ObjectRenderer, Type>();

		public static void ReadAllObjects() {
			DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObjectRenderer));

			MainForm.form.ObjectsView.LargeImageList = new System.Windows.Forms.ImageList();
			string[] files = Directory.GetFiles("objects");
			foreach (string file in files)
				using (FileStream stream = new FileStream(file, FileMode.Open)) {
					Type type;
					ObjectRenderer obj = (ObjectRenderer)jsonFormatter.ReadObject(stream);
					if (obj.uv == null)
						obj.constructUV();
					if (obj.name == null)
						obj.name = file.Substring(8).Split('.')[0];
					switch (obj.name) {
						// Кейсами тут биндь по имени к наследникам от RoomObject
						case "chestWooden":
							type = typeof(ChestObject);
							break;
						case "leftGate":
						case "rightGate":
						case "topGate":
						case "downGate":
							type = typeof(GateObject);
							break;
						default:
							type = typeof(RoomObject);
							break;
					}

					if (!obj.notAddToMenu) {
						Bitmap original = Utils.LoadBitmap("textures/" + obj.texture);
						Bitmap icon = new Bitmap(obj.width, obj.height);
						for (int x = 0; x < obj.width; x++)
							for (int y = 0; y < obj.height; y++)
								icon.SetPixel(x, y, original.GetPixel(obj.offset.x + x, obj.offset.y + y));
						MainForm.form.ObjectsView.LargeImageList.Images.Add(obj.name, icon);
						MainForm.form.ObjectsView.Items.Add(obj.name, obj.name);
					}
					rendersList.Add(obj, type);
				}
		}

		public static void SpawnObjectWithoutSymmetry(string name) {
			RoomObject obj = GetObjectByRenderName(name);
			obj.coords = new Utils.Vec<int>(-InputManager.translate.x, -InputManager.translate.y);
			MainForm.form.objects.Add(obj);
			if (MainForm.form.activeTool is Tools.EditObjectsTool)
				((Tools.EditObjectsTool)MainForm.form.activeTool).SelectObjects(new List<RoomObject>() { obj });
		}

		public static void SpawnObject(string name) {
			RoomObject obj = GetObjectByRenderName(name);
			obj.coords = new Utils.Vec<int>(-InputManager.translate.x, -InputManager.translate.y);
			MainForm.form.objects.Add(obj);
			if (MainForm.form.XSymmetryBox.Checked) {
				RoomObject symmetry = obj.Copy();
				symmetry.coords = new Utils.Vec<int>(495*MainForm.form.matrix.widthRoom + InputManager.translate.x - symmetry.render.width, -InputManager.translate.y);
				MainForm.form.objects.Add(symmetry);
			}
			if (MainForm.form.YSymmetryBox.Checked) {
				RoomObject symmetry = obj.Copy();
				symmetry.coords = new Utils.Vec<int>(-InputManager.translate.x, 277 * MainForm.form.matrix.heightRoom + InputManager.translate.y - symmetry.render.height);
				MainForm.form.objects.Add(symmetry);
			}
			if (MainForm.form.XYSymmetryBox.Checked) {
				RoomObject symmetry = obj.Copy();
				symmetry.coords = new Utils.Vec<int>(495 * MainForm.form.matrix.widthRoom + InputManager.translate.x - symmetry.render.width, 277 * MainForm.form.matrix.heightRoom + InputManager.translate.y - symmetry.render.height);
				MainForm.form.objects.Add(symmetry);
			}

			if (MainForm.form.activeTool is Tools.EditObjectsTool)
				((Tools.EditObjectsTool)MainForm.form.activeTool).SelectObjects(new List<RoomObject>() { obj });
		}

		public static RoomObject FindObjectByID(int ID) {
			return FindObject(x => x.ID == ID);
		}

		public static RoomObject FindObject(Predicate<RoomObject> predicate) {
			foreach (RoomObject obj in MainForm.form.objects)
				if (predicate.Invoke(obj))
					return obj;
			return null;
		}

		public static RoomObject GetObjectByRenderName(string name) {
			foreach (ObjectRenderer obj in rendersList.Keys) {
				if (obj.name.Equals(name)) {
					return (RoomObject)rendersList[obj].GetConstructor(new Type[] { typeof(ObjectRenderer) }).Invoke(new object[] { obj });
				}
			}
			return null;
		}

		public static ObjectRenderer GetRenderByName(string name) {
			foreach (ObjectRenderer obj in rendersList.Keys) {
				if (obj.name.Equals(name)) {
					return obj;
				}
			}
			return null;
		}

		public static RoomObject GetObjectOverMouse() {
			foreach (RoomObject obj in MainForm.form.objects) {
				if (mouseWorldPosition.x > obj.coords.x && mouseWorldPosition.x < obj.coords.x + obj.render.width && mouseWorldPosition.y > obj.coords.y && mouseWorldPosition.y < obj.coords.y + obj.render.height)
					return obj;
			}
			return null;
		}
	}
}
