using System.Windows.Forms;
using MusicEditor.Models;
using MusicEditor.Properties;

namespace MusicEditor.Graphic {
    public class WholeNote : Note {
        protected WholeNote(Form form) : base(form) {
            Duration = 1.0;
            Image = Resources.whole;
        }

        public override void Draw(Position position) {
            throw new System.NotImplementedException();
        }

        public override Graphic Clone() {
            throw new System.NotImplementedException();
        }
    }
}
