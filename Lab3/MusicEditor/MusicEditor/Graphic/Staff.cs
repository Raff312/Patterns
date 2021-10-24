using System.Windows.Forms;
using MusicEditor.Controls;
using MusicEditor.Models;
using MusicEditor.Properties;

namespace MusicEditor.Graphic {
    public class Staff : Graphic {
        public Staff(Form form) : base(form) {
            Image = Resources.Staff;
        }

        public override void Draw(Position position) {
            var control = new StaffTransportControl();
            control.BackColor = System.Drawing.Color.Transparent;
            control.Color = System.Drawing.Color.Transparent;
            control.Size = new System.Drawing.Size(23, 25);
            control.Location = new System.Drawing.Point(position.Current.X, position.Current.Y);
            if (control.Location.X != 20) {
                Image = Resources.Staff;
                control.Image = Image;
            } else {
                Image = Resources.key;
                control.Image = Image;
            }
            control.Opacity = 100;
            control.Enabled = false;
            ScoreSheetPanel.Controls.Add(control);
            ObjectsStore.Add(control);
            Form.ResumeLayout(false);
        }

        public override Graphic Clone() {
            return new Staff(Form);
        }
    }
}
