using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsEditor.Actions {
	public interface IAction {
		void Cancel();
		void Return();
	}
}
