using System.Windows.Forms;

namespace MusicEditor.Graphic {
    public abstract class Note : Graphic {
        public double Duration;

        protected Note(Form form) : base(form) {
        }
    }
}
