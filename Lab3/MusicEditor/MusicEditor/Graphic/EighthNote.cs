using System.Windows.Forms;
using MusicEditor.Models;
using MusicEditor.Properties;

namespace MusicEditor.Graphic {
    public class EighthNote : Note {
        protected EighthNote(Form form) : base(form) {
            Duration = 0.125;
            Image = Resources.eighth;
        }

        public override void Draw(Position position) {
            throw new System.NotImplementedException();
        }

        public override Graphic Clone() {
            throw new System.NotImplementedException();
        }
    }
}
