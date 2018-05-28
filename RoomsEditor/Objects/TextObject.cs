using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using RoomsEditor.Panels;
using static Tao.OpenGl.Gl;
using static Tao.Platform.Windows.Wgl;
using System.Runtime.InteropServices;


namespace RoomsEditor.Objects {

	[DataContract]
	public class TextObject : RoomObjectWithData<TextPanel> {
		private string text;
		private Color color;

		public TextObject(ObjectRenderer render) : base(render) {
			text = "";
			color = Color.Black;
		}

		[DllImport("Gdi32.dll", SetLastError = true)]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		public override void Draw(int type) {
			glPushMatrix();
			glColor3b(color.R, color.G, color.B);
			using (Font font = new Font(FontFamily.GenericSerif, 20, FontStyle.Bold)) {
				SelectObject(MainForm.hdc, font.ToHfont());
				wglUseFontBitmapsW(MainForm.hdc, 0, 1104, 1000);
			}
			glListBase(1000);
			glCallLists(text.Length, GL_UNSIGNED_BYTE, text);
			glListBase(0);
			glColor3f(1, 1, 1);
			glPopMatrix();
		}

		public override string[] createDataFromPanel(TextPanel panel) {
			text = panel.GetText();
			color = panel.GetColor();
			return new string[] {
				panel.GetText(),
				panel.GetColor().ToArgb()+""
			};
		}

		public override TextPanel createPanelFromData(string[] data) {
			if (data == null)
				return new TextPanel("", Color.Black);
			return new TextPanel(data[0], Color.FromArgb(int.Parse(data[1])));
		}
	}
}