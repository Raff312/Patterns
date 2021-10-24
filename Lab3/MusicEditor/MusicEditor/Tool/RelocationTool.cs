using MusicEditor.Controls;
using MusicEditor.Models;
using System.Drawing;
using System.Windows.Forms;

namespace MusicEditor.Tool {
    public class RelocationTool : Tool {
        public RelocationTool(Panel panel) : base(panel) {
        }

        public override void Manipulate() {
            if (ScoreSheetPanel == null) {
                return;
            }

            foreach (Control c in ScoreSheetPanel.Controls) {
                if (c is TransportControl TranspPB && TranspPB is NoteTransportControl) {
                    var pb = TranspPB as NoteTransportControl;
                    if (pb.Marked) {
                        if (pb.Location.Y <= pb.Staff.Location.Y - 11) {
                            pb.Location = new Point(pb.Location.X, pb.Staff.Location.Y + 12);
                            pb.ResetNoteValue();
                        } else {
                            pb.ChangeNoteValue();
                            if (NotesCollections.SharpNotes.Contains(pb.Note.Value)) {
                                pb.ChangeNoteValue();
                            }

                            pb.Location = new Point(pb.Location.X, pb.Location.Y - 2);
                        }
                    }
                }
            }
        }
    }
}
