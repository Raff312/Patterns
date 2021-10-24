using MusicEditor.Graphic;
using MusicEditor.Models;
using System.Windows.Forms;

namespace MusicEditor.Tool {
    public class GraphicTool : Tool {
        private Graphic.Graphic _prototype;

        public GraphicTool(Graphic.Graphic prototype, Panel panel) : base(panel) {
            _prototype = prototype;
        }

        public override void Manipulate() {
            var curForm = ScoreSheetPanel.FindForm() as EditorForm;
            var p = _prototype.Clone();

            if (p is Note) {
                p.Draw(curForm.NotePosition);
                curForm.NotePosition = Position.CalculateNotePosition(curForm.NotePosition);
            } else {
                Position.CalculateStaffPosition(curForm.StaffPosition);

                for (int i = 0; i < 40; i++) {
                    p.Draw(curForm.StaffPosition);
                    curForm.StaffPosition = Position.CalculateStaffPosition(curForm.StaffPosition);
                }
            }
        }
    }
}
