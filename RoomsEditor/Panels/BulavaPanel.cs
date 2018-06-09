using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomsEditor.Panels {
	public partial class BulavaPanel : UserControl {
		private int tileCount;
		private int rotateMode;
		private int angleSpeed;
		private int startAngle;
		private int motionMode;
		private int motionSpeed;
		private int motionDistance;
		private int startDistance;

		public BulavaPanel(int tileCount, int rotateMode, int angleSpeed, int startAngle, int motionMode, int motionSpeed, int motionDistance, int startDistance) {
			this.tileCount = tileCount;
			this.rotateMode = rotateMode;
			this.angleSpeed = angleSpeed;
			this.startAngle = startAngle;
			this.motionMode = motionMode;
			this.motionSpeed = motionSpeed;
			this.motionDistance = motionDistance;
			this.startDistance = startDistance;
			InitializeComponent();
			countBox.Text = tileCount + "";
			typeCombo.SelectedIndex = rotateMode;
			angleSpeedBox.Text = angleSpeed + "";
			velocityAxisCombo.SelectedIndex = motionMode;
			speedBox.Text = motionSpeed + "";
			maxDistanceBox.Text = motionDistance + "";
		}

		private void okButton_Click(object sender, EventArgs e) {
			tileCount = int.Parse(countBox.Text);
			rotateMode = typeCombo.SelectedIndex;
			angleSpeed = int.Parse(angleSpeedBox.Text);
			startAngle = int.Parse(startAngleBox.Text);
			motionMode = velocityAxisCombo.SelectedIndex;
			motionSpeed = int.Parse(speedBox.Text);
			motionDistance = int.Parse(maxDistanceBox.Text);
			startDistance = int.Parse(startDistanceBox.Text);
			Tools.EditObjectsTool.MarkDirtyActiveObject();
		}

		public int GetTileCount() { return tileCount; }
		public int GetRotateMode() { return rotateMode; }
		public int GetAngleSpeed() { return angleSpeed; }
		public int GetStartAngle() { return startAngle; }
		public int GetMotionMode() { return motionMode; }
		public int GetMotionSpeed() { return motionSpeed; }
		public int GetMotionDistance() { return motionDistance; }
		public int GetStartDistance() { return startDistance; }
	}
}
