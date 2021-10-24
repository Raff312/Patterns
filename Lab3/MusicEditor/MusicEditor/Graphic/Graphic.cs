using System.Drawing;
using System.Windows.Forms;
using MusicEditor.Models;

namespace MusicEditor.Graphic {
    public abstract class Graphic {
        protected Form Form;
        protected Image Image;
        protected Panel ScoreSheetPanel;

        protected Graphic(Form form) {
            Form = form;
            var getPanel = Form.Controls.Find("panel1", false)[0].Controls.Find("scoreSheetPanel", false)[0];
            ScoreSheetPanel = getPanel as Panel;
        }

        public abstract void Draw(Position position);
        public abstract Graphic Clone();
    }
}
