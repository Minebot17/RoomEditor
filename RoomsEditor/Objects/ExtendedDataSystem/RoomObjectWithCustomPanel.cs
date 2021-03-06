﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace RoomsEditor.Objects {

	[DataContract]
	[KnownType(typeof(ChestObject))]
	[KnownType(typeof(GateObject))]
	public abstract class RoomObjectWithCustomPanel<T> : RoomObject, IExtendedData where T : Control {
		protected T panel;
		[DataMember]
		protected string[] data;

		public RoomObjectWithCustomPanel(ObjectRenderer render) : base(render) {
			
		}

		public virtual void applyData() {

		}

		public override RoomObject Copy() {
			RoomObjectWithCustomPanel<T> copy = (RoomObjectWithCustomPanel<T>) base.Copy();
			copy.data = data;
			return copy;
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

		public void markDirty() {
			data = createDataFromPanel(panel);
		}

		public string[] serializeData() {
			return data;
		}

		public void deserializeData(string[] data) {
			this.data = data;
		}

		public abstract T createPanelFromData(string[] data);
		public abstract string[] createDataFromPanel(T panel);
		public abstract string[] getDefaultData();
	}
}
