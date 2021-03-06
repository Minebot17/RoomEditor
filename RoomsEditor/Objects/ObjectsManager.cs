﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using RoomsEditor.Objects;
using System.Runtime.Serialization;
using RoomsEditor.Tools;
using RoomsEditor.Actions;
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
					foreach (ObjectRenderer.RenderType render in obj.types)
						if (render.uv == null)
							obj.constructUV(render);
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
						case "marker":
							type = typeof(MarkerObject);
							break;
						case "barrelOfBananas":
						case "banana":
							type = typeof(BananaObject);
							break;
						case "bulava":
							type = typeof(BulavaObject);
							break;
						case "stair":
							type = typeof(StairObject);
							break;
						case "jumpPoint":
							type = typeof(JumpPointObject);
							break;
						default:
							type = typeof(RoomObject);
							break;
					}

					if (!obj.notAddToMenu) {
						Bitmap original = Utils.LoadBitmap("textures/" + obj.texture);
						Bitmap icon = new Bitmap(obj.types[0].width, obj.types[0].height);
						for (int x = 0; x < obj.types[0].width; x++)
							for (int y = 0; y < obj.types[0].height; y++)
								icon.SetPixel(x, y, original.GetPixel(obj.types[0].offset.x + x, obj.types[0].offset.y + y));
						ListViewGroupCollection collection = MainForm.form.ObjectsView.Groups;
						MainForm.form.ObjectsView.LargeImageList.Images.Add(obj.name, icon);
						string group = obj.group;
						if (group != null)
							group = group.Equals("1") ? "Катакомбы" : group.Equals("2") ? "Шахты" : group.Equals("3") ? "Ад" : group;
						MainForm.form.ObjectsView.Items.Add(obj.name, obj.name).Group = FindGroup(collection, group == null || FindGroup(collection, group) == null ? "Остальное" : group);
					}
					rendersList.Add(obj, type);
				}
		}

		public static ListViewGroup FindGroup(ListViewGroupCollection collection, string group) {
			ListViewGroup result = null;
			foreach (ListViewGroup g in collection)
				if (g.Name.Equals(group)) {
					result = g;
					break;
				}
			return result;
		}

		public static void SpawnObjectWithoutSymmetry(string name) {
			RoomObject obj = GetObjectByRenderName(name);
			if (obj is IExtendedData && ((IExtendedData)obj).serializeData() == null)
				((IExtendedData)obj).deserializeData(((IExtendedData)obj).getDefaultData());
			obj.coords = new Utils.Vec<int>(-InputManager.translate.x, -InputManager.translate.y);
			MainForm.form.objects.Add(obj);
			if (MainForm.form.activeTool is Tools.EditObjectsTool)
				((Tools.EditObjectsTool)MainForm.form.activeTool).SelectObjects(new List<RoomObject>() { obj });
		}

		public static void SpawnObject(string name, bool createAction) {
			List<RoomObject> objectsToSpawn = new List<RoomObject>();
			RoomObject obj = GetObjectByRenderName(name);
			if (obj is IExtendedData && ((IExtendedData)obj).serializeData() == null)
				((IExtendedData)obj).deserializeData(((IExtendedData)obj).getDefaultData());
			obj.coords = new Utils.Vec<int>(-InputManager.translate.x, -InputManager.translate.y);
			MainForm.form.objects.Add(obj);
			objectsToSpawn.Add(obj);
			if (MainForm.form.XSymmetryBox.Checked) {
				RoomObject symmetry = obj.Copy();
				symmetry.coords = new Utils.Vec<int>(495*MainForm.form.matrix.widthRoom + InputManager.translate.x - obj.GetRender().width, -InputManager.translate.y);
				MainForm.form.objects.Add(symmetry);
				objectsToSpawn.Add(symmetry);
			}
			if (MainForm.form.YSymmetryBox.Checked) {
				RoomObject symmetry = obj.Copy();
				symmetry.coords = new Utils.Vec<int>(-InputManager.translate.x, 277 * MainForm.form.matrix.heightRoom + InputManager.translate.y - obj.GetRender().height);
				MainForm.form.objects.Add(symmetry);
				objectsToSpawn.Add(symmetry);
			}
			if (MainForm.form.XYSymmetryBox.Checked) {
				RoomObject symmetry = obj.Copy();
				symmetry.coords = new Utils.Vec<int>(495 * MainForm.form.matrix.widthRoom + InputManager.translate.x - obj.GetRender().width, 277 * MainForm.form.matrix.heightRoom + InputManager.translate.y - obj.GetRender().height);
				MainForm.form.objects.Add(symmetry);
				objectsToSpawn.Add(symmetry);
			}

			if (MainForm.form.activeTool is Tools.EditObjectsTool)
				((Tools.EditObjectsTool)MainForm.form.activeTool).SelectObjects(new List<RoomObject>() { obj });

			if (createAction)
				ActionManager.Add(new SpawnObjectAction(objectsToSpawn));
		}


		public static void SpawnObject(RoomObject obj, bool createAction) {
			List<RoomObject> objectsToSpawn = new List<RoomObject>();
			if (obj is IExtendedData && ((IExtendedData)obj).serializeData() == null)
				((IExtendedData)obj).deserializeData(((IExtendedData)obj).getDefaultData());
			MainForm.form.objects.Add(obj);
			objectsToSpawn.Add(obj);

			if (createAction)
				ActionManager.Add(new SpawnObjectAction(objectsToSpawn));
		}

		public static void RemoveObject(RoomObject obj, bool createAction) {
			MainForm.form.objects.Remove(obj);
			if (MainForm.form.activeTool is EditObjectsTool) {
				EditObjectsTool tool = (EditObjectsTool)MainForm.form.activeTool;
				if (tool.activeObject != null && tool.activeObject.Contains(obj)) {
					if (tool.activeObject != null && tool.activeObject.Count == 1 && tool.activeObject[0] is IExtendedData)
						((IExtendedData)tool.activeObject[0]).closePanel();
					tool.activeObject.Remove(obj);
					tool.loadObjectPanel();
					tool.FindSymmetryObjects();
				}
			}
			if (createAction)
				ActionManager.Add(new RemoveObjectAction(new List<RoomObject>() { obj }));
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
				Utils.Vec<int> coord = obj.coords;
				if (obj.render.mustCenterPosition)
					coord = new Utils.Vec<int>(coord.x - obj.render.types[obj.type].width/2, coord.y - obj.render.types[obj.type].height/2);
				if (mouseWorldPosition.x > coord.x && mouseWorldPosition.x < coord.x + obj.GetRender().width && mouseWorldPosition.y > coord.y && mouseWorldPosition.y < coord.y + obj.GetRender().height)
					return obj;
			}
			return null;
		}

		public static List<RoomObject> GetObjectsInRectangle(Utils.Vec<int> min, Utils.Vec<int> max) {
			List<RoomObject> result = new List<RoomObject>();
			MainForm.form.objects.ForEach(obj => {
				if (obj.coords.x > min.x && obj.coords.x + obj.GetRender().width < max.x && obj.coords.y > min.y && obj.coords.y + obj.GetRender().height < max.y)
					result.Add(obj);
			});
			return result;
		}
	}
}
