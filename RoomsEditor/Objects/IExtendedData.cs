using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoomsEditor.Objects {
	public interface IExtendedData {
		object[] saveData();
		void loadData(object[] data);
		Control loadUI();
	}
}
