using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace RoomsEditor.Objects {
	[DataContract]
	[KnownType(typeof(ChestObject))]
	[KnownType(typeof(GateObject))]
	[KnownType(typeof(String[]))]
	public abstract class RoomObjectWithData<T> : RoomObject, IExtendedData where T : Control {
		private T panel;
		[DataMember]
		private object[] data;

		public RoomObjectWithData(ObjectRenderer render) : base(render) {
			
		}

		public void openPanel() {
			panel = createPanelFromData(data);
			panel.Location = new System.Drawing.Point(4, 65);
			MainForm.form.Controls.Add(panel);
		}

		public void closePanel() {
			data = createDataFromPanel(panel);
			MainForm.form.Controls.Remove(panel);
			panel = null;
		}

		public object[] serializeData() {
			return data;
		}

		public void deserializeData(object[] data) {
			this.data = data;
		}

		public abstract T createPanelFromData(object[] data);
		public abstract object[] createDataFromPanel(T panel);
	}
}
