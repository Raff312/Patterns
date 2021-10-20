using System.Windows.Forms;
using MusicEditor.Models;
using MusicEditor.Properties;

namespace MusicEditor.Graphic {
    public class HalfNote : Note {
        protected HalfNote(Form form) : base(form) {
            Duration = 0.5;
            Image = Resources.half;
        }

        public override void Draw(Position position) {
            throw new System.NotImplementedException();
        }

        public override Graphic Clone() {
            throw new System.NotImplementedException();
        }
    }
}
