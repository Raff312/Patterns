using System.Windows.Forms;

namespace MusicEditor.Tool {
    public abstract class Tool {
        protected Form Form = null;
        protected Panel ScoreSheetPanel;

        protected Tool(Panel panel) {
            ScoreSheetPanel = panel;
        }

        public abstract void Manipulate();
    }
}
