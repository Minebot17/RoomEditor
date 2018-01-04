using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomsEditor.Objects;
using static RoomsEditor.Utils;

namespace RoomsEditor.Actions {
	public class MoveObjectAction : IAction {
		public List<MoveArgs> args;

		public MoveObjectAction(List<MoveArgs> args) {
			this.args = args;
		}

		public void Cancel() {
			foreach(MoveArgs arg in args)
				arg.obj.coords = arg.start;
		}

		public void Return() {
			foreach (MoveArgs arg in args)
				arg.obj.coords = arg.end;
		}

		public struct MoveArgs {
			public RoomObject obj;
			public Vec<int> start;
			public Vec<int> end;

			public MoveArgs(RoomObject obj, Vec<int> start, Vec<int> end) {
				this.obj = obj;
				this.start = start;
				this.end = end;
			}
		}
	}
}
