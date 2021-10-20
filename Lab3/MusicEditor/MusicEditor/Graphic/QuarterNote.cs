using System.Windows.Forms;
using MusicEditor.Models;
using MusicEditor.Properties;

namespace MusicEditor.Graphic {
    public class QuarterNote : Note {
        protected QuarterNote(Form form) : base(form) {
            Duration = 0.25;
            Image = Resources.quarter;
        }

        public override void Draw(Position position) {
            throw new System.NotImplementedException();
        }

        public override Graphic Clone() {
            throw new System.NotImplementedException();
        }
    }
}
