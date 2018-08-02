using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoomsEditor.Objects {
	public interface IExtendedData {
		void openPanel();
		void closePanel();
		void markDirty();
		void applyData();

		string[] serializeData();
		void deserializeData(string[] data);
		string[] getDefaultData();
	}
}
