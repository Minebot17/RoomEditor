using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsEditor {
	public interface IRenderer {
		void Draw();
		void Draw(int type);
	}
}
