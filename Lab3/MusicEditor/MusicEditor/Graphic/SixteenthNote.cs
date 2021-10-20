using System.Windows.Forms;
using MusicEditor.Models;
using MusicEditor.Properties;

namespace MusicEditor.Graphic {
    public class SixteenthNote : Note {
        protected SixteenthNote(Form form) : base(form) {
            Duration = 0.0625;
            Image = Resources.sixteenth;
        }

        public override void Draw(Position position) {
            throw new System.NotImplementedException();
        }

        public override Graphic Clone() {
            throw new System.NotImplementedException();
        }
    }
}
