using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Objects.ExtendedDataSystem;
using RoomsEditor.Panels.Modules;
using System.Windows.Forms;
using System.Runtime.Serialization;
using static Tao.OpenGl.Gl;
using static RoomsEditor.Utils;

namespace RoomsEditor.Objects {

	[DataContract]
	public class StairObject : RoomObjectWithModulePanel {
		private int stairType;
		private int width;
		private bool enders;

		public StairObject(ObjectRenderer render) : base(render.Copy()) {
			
		}

		public override void Draw(int type) {
			glPushMatrix();
			glTranslatef(coords.x, coords.y, 0);
			TextureManager.BindTexture(render.texture);
			float yUVOffset = stairType == 0 ? 0.25f : stairType == 1 ? 0 : 0.5f;
			float xUVOffset = stairType == 0 ? 0f : stairType == 1 ? 0.0625f : 0.125f;

			if (enders) {
				Utils.DrawTexturedQuad(new Vec<int>(0, 0), new Vec<int>(2, 8), new Vec<float>(xUVOffset, 0), new Vec<float>(xUVOffset + 0.0625f, 0.25f));
				Utils.DrawTexturedQuad(new Vec<int>(width - 2, 0), new Vec<int>(width, 8), new Vec<float>(xUVOffset + 0.0625f, 0), new Vec<float>(xUVOffset, 0.25f));
			}

			Utils.DrawTexturedQuad(new Vec<int>(enders ? 2 : 0, 0), new Vec<int>(enders ? width - 2 : width, 8), new Vec<float>(0, 0.25f + yUVOffset), new Vec<float>((enders ? width - 4 : width)/32f, 0.5f + yUVOffset));
			glPopMatrix();
		}

		public bool flag = false;
		public override void markDirty() {
			if (flag)
				return;
			base.markDirty();
			if (data != null) {
				stairType = int.Parse(data[0]);
				width = int.Parse(data[2]);
				enders = bool.Parse(data[3]);
				this.render.types[0].width = width;

				if ((MainForm.form.activeTool is Tools.EditObjectsTool)) {
					StairObject xS = (StairObject)((Tools.EditObjectsTool)MainForm.form.activeTool).xSymmetryObject;
					StairObject yS = (StairObject)((Tools.EditObjectsTool)MainForm.form.activeTool).ySymmetryObject;
					StairObject xyS = (StairObject)((Tools.EditObjectsTool)MainForm.form.activeTool).xySymmetryObject;
					if (xS == this || yS == this || xyS == this)
						return;
					flag = true;
					if (xS != null) {
						if (xS.modulePanel == null) {
							xS.flag = true;
							xS.modulePanel = new Panels.ModulePanel(xS.GetModules());
							xS.modulePanel.Location = new System.Drawing.Point(4, 65);
							xS.flag = false;
						}
						xS.coords.x += xS.width - width;
						xS.modulePanel.SetupData(data);
						xS.markDirty();
					}
					if (yS != null) {
						if (yS.modulePanel == null) {
							yS.flag = true;
							yS.modulePanel = new Panels.ModulePanel(yS.GetModules());
							yS.modulePanel.Location = new System.Drawing.Point(4, 65);
							yS.flag = false;
						}
						yS.modulePanel.SetupData(data);
						yS.markDirty();
					}
					if (xyS != null) {
						if (xyS.modulePanel == null) {
							xyS.flag = true;
							xyS.modulePanel = new Panels.ModulePanel(xyS.GetModules());
							xyS.modulePanel.Location = new System.Drawing.Point(4, 65);
							xyS.flag = false;
						}
						xyS.coords.x += xyS.width - width;
						xyS.modulePanel.SetupData(data);
						xyS.markDirty();
					}
					flag = false;
				}
			}
		}

		protected override Control[] GetModules() {
			return new Control[] {
				new ComboModule("Тип", new []{ "Обычная", "Исчезающая", "Ломающаяся" }, 0),
				new TextModule("Задержка исчезновения (сек)", "0"),
				new TextModule("Ширина", "16"),
				new BoolModule("Наконечники", true)
			};
		}

		public override RoomObject Copy() {
			StairObject copy = (StairObject)base.Copy();
			copy.stairType = stairType;
			copy.enders = enders;
			copy.width = width;
			copy.render.types[0].width = width;
			return copy;
		}
	}
}
