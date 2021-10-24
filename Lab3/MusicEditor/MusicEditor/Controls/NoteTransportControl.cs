using System.Drawing;
using System.Windows.Forms;
using MusicEditor.Graphic;
using MusicEditor.Models;
using MusicEditor.Properties;

namespace MusicEditor.Controls {
    public partial class NoteTransportControl : TransportControl {
        public Note Note { get; set; }
        public StaffTransportControl Staff { get; set; }

        public NoteTransportControl(Note note) : base() {
            Note = note;
            ObjectsStore.Add(this);
        }

        public void ChangeNoteValue() {
            Note.Value++;
        }

        public void ResetNoteValue() {
            Note.Value = 59;
        }

        public void RefreshView() {
            Hide();
            Show();
        }

        public void DeselectNote() {
            Marked = false;
            ResetNoteImage();
            RecreateHandle();
        }

        public void ResetNoteImage() {
            if (Marked) {
                switch (Note.Length) {
                    case NoteLength.Sixteenth:
                        this.Image = RotatingImageTool(Resources.SixteenthNoteSelected2323);
                        break;
                    case NoteLength.Eighth:
                        this.Image = RotatingImageTool(Resources.EighthNoteSelected2323);
                        break;
                    case NoteLength.Half:
                        this.Image = RotatingImageTool(Resources.HalfNoteSelected2323);
                        break;
                    case NoteLength.Quarter:
                        this.Image = RotatingImageTool(Resources.QuarterNoteSelected2323);
                        break;
                    case NoteLength.Whole:
                        this.Image = RotatingImageTool(Resources.WholeNoteSelected2323);
                        break;
                }
            } else {
                switch (Note.Length) {
                    case NoteLength.Sixteenth:
                        this.Image = RotatingImageTool(Resources.SixteenthNoteSmall2323);
                        break;
                    case NoteLength.Half:
                        this.Image = RotatingImageTool(Resources.HalfNoteSmall2323);
                        break;
                    case NoteLength.Quarter:
                        this.Image = RotatingImageTool(Resources.QuarterNoteSmall2323);
                        break;
                    case NoteLength.Whole:
                        this.Image = RotatingImageTool(Resources.WholeNoteSmall2323);
                        break;
                    case NoteLength.Eighth:
                        this.Image = RotatingImageTool(Resources.EighthNoteSmall2323);
                        break;
                }
            }
            this.RecreateHandle();
        }

        private Image RotatingImageTool(Image img) {
            return Rotated ? Rotate.RotateImage(img, new Point(0, 0), 180) : img;
        }

        protected override void OnMouseClick(MouseEventArgs e) {
            base.OnMouseClick(e);
            Marked = !Marked;
            this.ResetNoteImage();
        }
    }
}
