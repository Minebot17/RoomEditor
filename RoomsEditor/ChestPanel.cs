using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomsEditor {
	public partial class ChestPanel : UserControl {
		public static List<string> types = new List<string>() {
			"Пустой",
			"Холостой",
			"Иди нахуй с моего репозитория"
		};
		private int type;
		private string[] ids;

		public ChestPanel(int type, string[] ids) {
			this.type = type;
			this.ids = ids;
			InitializeComponent();
			typesBox.Text = types[type];
			itemsBox.Items.Clear();
			for (int i = 0; i < ids.Length; i++)
				itemsBox.Items.Add(ids[i]);

			foreach (string t in types)
				typesBox.Items.Add(t);
		}

		private void okButton_Click(object sender, EventArgs e) {
			int result = -1;
			for (int i = 0; i < types.Count; i++)
				if (types[i].Equals(typesBox.Text)) {
					result = i;
					break;
				}

			if (result == -1) {
				result = 0;
				typesBox.Text = types[0];
				MessageBox.Show("Такого типа не существует", "Ошибка долбоеба");
			}
			type = result;
		}

		private void addButton_Click(object sender, EventArgs e) {
			itemsBox.Items.Add(idBox.Text);
			ids = new string[itemsBox.Items.Count];
			for (int i = 0; i < itemsBox.Items.Count; i++)
				ids[i] = itemsBox.Items[i].ToString();
		}

		private void itemsBox_MouseDoubleClick(object sender, MouseEventArgs e) {
			if (itemsBox.SelectedItem != null)
				itemsBox.Items.Remove(itemsBox.SelectedItem);
		}

		public int getType() { return type; }
		public string[] getIDs() { return ids; }
	}
}
