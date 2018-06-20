using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Objects.ExtendedDataSystem;
using RoomsEditor.Panels.Modules;
using System.Windows.Forms;

namespace RoomsEditor.Objects {

	[DataContract]
	public class BulavaObject : RoomObjectWithModulePanel {

		public BulavaObject(ObjectRenderer render) : base(render) {

		}

		protected override Control[] GetModules() {
			return new Control[] {
				new TextModule("Количество тайлов", "0"),
				new ComboModule("Тип вращения", new []{ "Отсутствует", "Качание", "Полный оборот" }, 0),
				new TextModule("Угловая скорость (градусы/сек)", "0"),
				new TextModule("Начальный угол", "0"),
				new ComboModule("Ось движения", new []{ "0", "X", "Y" }, 0),
				new TextModule("Скорость (пиксели/сек)", "0"),
				new TextModule("Максимальная дистанция", "0"),
				new TextModule("Начальный путь", "0"),
			};
		}
	}
}
