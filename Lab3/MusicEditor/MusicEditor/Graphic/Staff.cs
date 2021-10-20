using System.Windows.Forms;
using MusicEditor.Models;
using MusicEditor.Properties;

namespace MusicEditor.Graphic {
    public class Staff : Graphic {
        public Staff(Form form) : base(form) {
            Image = Resources.staff;
        }

        public override void Draw(Position position) {
            throw new System.NotImplementedException();
        }

        public override Graphic Clone() {
            return new Staff(Form);
        }
    }
}
