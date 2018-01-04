using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomsEditor.Actions {
	public static class ActionManager {
		public static Stack<IAction> actions = new Stack<IAction>();
		public static Stack<IAction> canceledActions = new Stack<IAction>();

		public static void Add(IAction action) {
			actions.Push(action);
			canceledActions = new Stack<IAction>();
		}

		public static void Cancel() {
			if (actions.Count == 0)
				return;

			IAction action = actions.Pop();
			action.Cancel();
			canceledActions.Push(action);
		}

		public static void Return() {
			if (canceledActions.Count == 0)
				return;

			IAction action = canceledActions.Pop();
			action.Return();
			actions.Push(action);
		}

		public static void Disponse() {
			actions = new Stack<IAction>();
			canceledActions = new Stack<IAction>();
		}
	}
}
