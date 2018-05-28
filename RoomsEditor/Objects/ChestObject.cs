using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;
using RoomsEditor.Panels;

namespace RoomsEditor.Objects {
	[DataContract]
	public class ChestObject : RoomObjectWithData<ChestPanel> {

		public ChestObject(ObjectRenderer render) : base(render) {
			
		}

		public override ChestPanel createPanelFromData(string[] data) {
			if (data == null)
				data = new string[] { "0" };
			string[] array = new string[data.Length - 1];
			for (int i = 1; i < data.Length; i++)
				array[i - 1] = data[i]; 
			return new ChestPanel(int.Parse(data[0]), array);
		}

		public override string[] createDataFromPanel(ChestPanel panel) {
			List<string> result = new List<string>();
			result.Add(panel.getType()+"");
			Array.ForEach<string>(panel.getIDs(), x => result.Add(x));
			return result.ToArray();
		}
	}
}
