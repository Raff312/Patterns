using MusicEditor.Controls;
using MusicEditor.Models;
using MusicEditor.Properties;
using PianoSoundLibrary.Library;
using System;
using System.Threading;
using System.Windows.Forms;

namespace MusicEditor.Graphic {
    public class Note : Graphic {
        public int Duration { get; set; }
        public int Value { get; set; }
        public NoteLength Length { get; set; }

        public Note(Form form, int duration) : base(form) {
            Duration = duration;
            Value = 60;
            InitImage(duration);
        }

        private void InitImage(int duration) {
            switch (duration) {
                case 62:
                    Image = Resources.SixteenthNoteSmall2323;
                    Length = NoteLength.Sixteenth;
                    break;
                case 125:
                    Image = Resources.EighthNoteSmall2323;
                    Length = NoteLength.Eighth;
                    break;
                case 250:
                    Image = Resources.QuarterNoteSmall2323;
                    Length = NoteLength.Quarter;
                    break;
                case 500:
                    Image = Resources.HalfNoteSmall2323;
                    Length = NoteLength.Half;
                    break;
                case 1000:
                    Image = Resources.WholeNoteSmall2323;
                    Length = NoteLength.Whole;
                    break;
            }
        }

        public void Play() {
            try {
                if (Form is EditorForm form && Value <= 127) {
                    form.OutputDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, Value, 127));
                    Thread.Sleep(Duration);
                    form.OutputDevice.Send(new ChannelMessage(ChannelCommand.NoteOff, 0, Value, 127));
                } else {
                    MessageBox.Show("Some errors occured");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Draw(Position position) {
            var control = new NoteTransportControl(this);

            if (Image == null) {
                InitImage(Duration);
            }

            int posYValidated = position.Current.Y;
            if (Value != 60) {
                for (int i = 60; i < Value; i++) {
                    if (!NotesCollections.SharpNotes.Contains(i)) {
                        posYValidated -= 2;
                    }
                }
            }

            control.BackColor = System.Drawing.Color.Transparent;
            control.Color = System.Drawing.Color.Transparent;
            control.Location = new System.Drawing.Point(position.Current.X, posYValidated);
            control.Name = "transpControl1";
            control.Opacity = 100;
            control.Image = Image;
            control.Size = new System.Drawing.Size(Image.Width, Image.Height);
            control.Staff = GetRespStaff(control);
            ScoreSheetPanel.Controls.Add(control);
            Form.ResumeLayout(false);
        }

        private StaffTransportControl GetRespStaff(TransportControl control) {
            foreach (var staff in ObjectsStore.StaffControls) {
                if (staff.Location.X == control.Location.X && staff.Location.Y == control.Location.Y - 13) {
                    return staff;
                }
            }
            return null;
        }

        public override Graphic Clone() {
            var clonedNote = new Note(Form, Duration);
            return clonedNote;
        }
    }

    public enum NoteLength {
        Whole,
        Half,
        Quarter,
        Eighth,
        Sixteenth
    }
}
