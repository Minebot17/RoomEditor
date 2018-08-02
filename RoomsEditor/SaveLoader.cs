using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using RoomsEditor.Objects;

namespace RoomsEditor {
	public static class SaveLoader {

		public static void Save(string fileName) {
			MainForm.form.matrix.FillWallsInGates();
			DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(SaveFile));
			if (File.Exists(fileName))
				File.Delete(fileName);

			int l1 = MainForm.form.matrix.matrix.GetLength(1);
			MatrixType[][] types = new MatrixType[MainForm.form.matrix.matrix.GetLength(0)][];
			for (int i = 0; i < types.Length; i++) {
				types[i] = new MatrixType[l1];
				for (int j = 0; j < l1; j++)
					types[i][j] = MainForm.form.matrix.matrix[i, j];
			}

			using (FileStream stream = new FileStream(fileName, FileMode.Create)) {
				formatter.WriteObject(stream, new SaveFile(types, MainForm.form.objects, MainForm.form.location));
			}
		}

		public static void Load(string fileName) {
			DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(SaveFile));
			if (File.Exists(fileName)) {
				using (FileStream stream = new FileStream(fileName, FileMode.Open)) {
					SaveFile file = (SaveFile) formatter.ReadObject(stream);

					MatrixType[,] types = new MatrixType[file.matrix.Length, file.matrix[0].Length];
					for (int i = 0; i < types.GetLength(0); i++)
						for (int j = 0; j < types.GetLength(1); j++)
							types[i, j] = file.matrix[i][j];


					MainForm.form.objects = new List<RoomObject>();
					MainForm.form.matrix = new RoomMatrix(file.matrix.Length / 495, file.matrix[0].Length / 277);
					MainForm.form.matrix.matrix = types;

					foreach (RoomObject obj in file.objects) {
						obj.render = ObjectsManager.GetRenderByName(obj.prefabName);
						if (obj is IExtendedData)
							((IExtendedData)obj).applyData();
					}
					MainForm.form.objects = file.objects;
					InputManager.ResetTransformation();
					MainForm.form.сохранитьToolStripMenuItem2.Enabled = true;
					MainForm.form.activeTool.Disponse();
					MainForm.form.activeTool = new Tools.CreateWallTool(false);
					MainForm.form.matrix.CompileList();
				}
			}
		}

		[DataContract]
		public struct SaveFile {
			[DataMember]
			public MatrixType[][] matrix;
			[DataMember]
			public List<RoomObject> objects;
			[DataMember]
			public int location;
			public SaveFile(MatrixType[][] matrix, List<RoomObject> objects, int location) {
				this.matrix = matrix;
				this.objects = objects;
				this.location = location;
			}
		}
	}
}
