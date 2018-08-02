using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using RoomsEditor.Panels;

namespace RoomsEditor.Objects.ExtendedDataSystem {

	[DataContract]
	[KnownType(typeof(BananaObject))]
	[KnownType(typeof(BulavaObject))]
	[KnownType(typeof(MarkerObject))]
	[KnownType(typeof(StairObject))]
	[KnownType(typeof(JumpPointObject))]
	public abstract class RoomObjectWithModulePanel : RoomObject, IExtendedData {
		protected ModulePanel modulePanel;
		[DataMember]
		protected string[] data;

		public RoomObjectWithModulePanel(ObjectRenderer render) : base(render) {

		}

		public string[] getDefaultData() {
			if (modulePanel == null)
				createPanel();
			return data;
		}

		public virtual void markDirty() {
			if (modulePanel != null)
				data = modulePanel.CollectData();
		}

		public void openPanel() {
			if (modulePanel == null)
				createPanel();
			modulePanel.SetupData(data);

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
			if (modulePanel == null)
				createPanel();
			modulePanel.SetupData(data);
		}

		protected void createPanel() {
			modulePanel = new ModulePanel(GetModules());
			modulePanel.Location = new System.Drawing.Point(4, 65);
			if (data != null)
				modulePanel.SetupData(data);
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
