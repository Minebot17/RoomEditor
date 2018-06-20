using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using RoomsEditor.Panels;

namespace RoomsEditor.Objects.ExtendedDataSystem {
	public abstract class RoomObjectWithModulePanel : RoomObject, IExtendedData {
		protected ModulePanel modulePanel;
		[DataMember]
		protected string[] data;

		public string[] getDefaultData() {
			if (modulePanel == null)
				createPanel();
			return data;
		}

		public void markDirty() {
			data = modulePanel.CollectData();
		}

		public void openPanel() {
			if (modulePanel == null)
				createPanel();

			MainForm.form.Controls.Add(modulePanel);
		}

		public void closePanel() {
			markDirty();
			MainForm.form.Controls.Remove(modulePanel);
		}

		public string[] serializeData() {
			return data;
		}

		public void deserializeData(string[] data) {
			this.data = data;
		}

		private void createPanel() {
			modulePanel = new ModulePanel(GetModules());
			modulePanel.Location = new System.Drawing.Point(4, 65);
			markDirty();
		}

		public override RoomObject Copy() {
			RoomObjectWithModulePanel copy = (RoomObjectWithModulePanel)base.Copy();
			copy.data = data;
			return copy;
		}

		protected abstract Control[] GetModules();
	}
}
