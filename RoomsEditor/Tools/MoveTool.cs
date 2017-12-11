using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using static RoomsEditor.InputManager;

namespace RoomsEditor.Tools {
	public class MoveTool : Tool {
		public MoveTool() => MainForm.form.viewPort.Cursor = Cursors.SizeAll;

		public override void Draw() {
			float xTranslate = deltaWindowVector.x / scaleFactor;
			float yTranslate = deltaWindowVector.y / scaleFactor;
			if (GetMouseWindowDelta() > 2 && IsMouseButtonDown(MouseButtons.Left))
				TranslateMatrix((int)xTranslate, (int)yTranslate);
		}

		public override void Disponse() => MainForm.form.viewPort.Cursor = Cursors.Default;
	}
}
