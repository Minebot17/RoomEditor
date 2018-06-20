using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsEditor.Objects.ExtendedDataSystem {
	public interface IModule {
		void Initialize(string data);
		string GetData();
	}
}
