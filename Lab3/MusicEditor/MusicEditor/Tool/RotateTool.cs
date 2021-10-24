using MusicEditor.Controls;
using MusicEditor.Models;
using System.Drawing;
using System.Windows.Forms;

namespace MusicEditor.Tool {
    public class RotateTool : Tool {
        public RotateTool(Panel panel) : base(panel) {
        }

        public override void Manipulate() {
            if (ScoreSheetPanel == null) {
                return;
            }

            foreach (Control c in ScoreSheetPanel.Controls) {
                if (c is TransportControl curPB && curPB is NoteTransportControl) {
                    var pb = curPB as NoteTransportControl;

                    if (pb.Marked) {
                        var image = Rotate.RotateImage(pb.Image, new Point(0, 0), 180);
                        pb.Image = image;
                        pb.Hide();
                        pb.Refresh();
                        pb.Show();

                        if (!pb.Rotated) {
                            pb.Rotated = true;
                        } else {
                            pb.Rotated = false;
                        }

                        ScoreSheetPanel.ResumeLayout(false);
                    }
                }
            }
        }
    }
}
