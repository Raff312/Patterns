using System.Drawing;
using System.Windows.Forms;
using MusicEditor.Models;

namespace MusicEditor.Graphic {
    public abstract class Graphic {
        protected Form Form;
        protected Image Image;

        protected Graphic(Form form) {
            Form = form;
        }

        public abstract void Draw(Position position);
        public abstract Graphic Clone();
    }
}
