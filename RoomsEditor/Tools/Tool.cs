using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsEditor.Tools {
	public class Tool : IRenderer {
		public virtual void MouseDown() { }
		public virtual void MouseUp() { }
		public virtual void MouseMove() { }
		public virtual void MouseEnter() { }
		public virtual void MouseLeave() { }
		public virtual void KeyDown() { }
		public virtual void KeyUp() { }
		public virtual void Draw() { }
		public virtual void Disponse() { }
	}
}
