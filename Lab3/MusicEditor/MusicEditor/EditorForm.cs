using System.Collections.Generic;
using System.Windows.Forms;
using MusicEditor.Controls;
using MusicEditor.Graphic;
using MusicEditor.Models;
using MusicEditor.Tool;
using NAudio.Midi;

namespace MusicEditor {
    public partial class EditorForm : Form {
        private readonly Note _whole;
        private readonly Note _half;
        private readonly Note _quarter;
        private readonly Note _sixteenth;
        private readonly Note _eighth;
        private readonly Staff _staff;
        private Tool.Tool _tool;

        public Position StaffPosition { get; set; }
        public Position NotePosition { get; set; }

        public MidiOut OutputDevice { get; private set; }

        public EditorForm() {
            InitializeComponent();

            _eighth = new Note(this, 125);
            _sixteenth = new Note(this, 62);
            _quarter = new Note(this, 250);
            _half = new Note(this, 500);
            _whole = new Note(this, 1000);
            _staff = new Staff(this);

            NotePosition = new Position(43, 32);
            StaffPosition = new Position(20, 19);

            OutputDevice = new MidiOut(0);

            DrawObject(_staff);
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            OutputDevice.Dispose();
        }

        private void EditorForm_ResizeEnd(object sender, System.EventArgs e) {
            foreach (var item in ObjectsStore.NoteControls) {
                item.RefreshView();
            }
        }

        private void btnWholeNote_Click(object sender, System.EventArgs e) {
            DrawObject(_whole);
        }

        private void btnHalfNote_Click(object sender, System.EventArgs e) {
            DrawObject(_half);
        }

        private void btnQuarterNote_Click(object sender, System.EventArgs e) {
            DrawObject(_quarter);
        }

        private void btnEighthNote_Click(object sender, System.EventArgs e) {
            DrawObject(_eighth);
        }

        private void btnSixteenthNote_Click(object sender, System.EventArgs e) {
            DrawObject(_sixteenth);
        }

        private void btnAbove_Click(object sender, System.EventArgs e) {
            _tool = new RelocationTool(scoreSheetPanel);
            _tool.Manipulate();
        }

        private void btnRotate_Click(object sender, System.EventArgs e) {
            _tool = new RotateTool(scoreSheetPanel);
            _tool.Manipulate();
        }

        private void btnDelNote_Click(object sender, System.EventArgs e) {
            DeleteLastNote();
        }

        private void DeleteLastNote() {
            if (NotePosition.Current.X == 43) {
                ObjectsStore.UnregisterLastStaff();
                StaffPosition = Position.CalculateStaffPositionOnDeletion(StaffPosition);
            }
            ObjectsStore.UnregisterLastNote();
            NotePosition = Position.CalculateNotePositionOnDeletion(NotePosition);
            foreach (var control in scoreSheetPanel.Controls) {
                if (control is NoteTransportControl) {
                    (control as NoteTransportControl).Hide();
                    (control as NoteTransportControl).Refresh();
                    (control as NoteTransportControl).Show();
                }

            }
        }

        private void btnUnMark_Click(object sender, System.EventArgs e) {
            UnMarkAll();
        }

        private void UnMarkAll() {
            foreach (var control in scoreSheetPanel.Controls) {
                if (control is NoteTransportControl) {
                    if ((control as NoteTransportControl).Marked) {
                        (control as NoteTransportControl).Marked = false;
                    }

                    (control as NoteTransportControl).DeselectNote();
                }
            }
        }

        private async void btnPlay_Click(object sender, System.EventArgs e) {
            await ObjectsStore.Play();
        }

        private void btnClear_Click(object sender, System.EventArgs e) {
            Clear();
        }

        private void Clear() {
            TransportControl controlToDelete;

            var controlsToDelete = new List<TransportControl>();
            foreach (var c in this.scoreSheetPanel.Controls) {
                controlToDelete = c as TransportControl;
                if (controlToDelete != null) {
                    controlsToDelete.Add(controlToDelete);
                }
            }
            foreach (TransportControl c in controlsToDelete) {
                c.Dispose();
            }

            ObjectsStore.Clear();
            NotePosition = new Position(43, 32);
            StaffPosition = new Position(20, 19);
            DrawObject(_staff);
        }

        private void DrawObject(Graphic.Graphic obj) {
            bool changeFlag = false;
            if (obj is Note) {
                foreach (var control in scoreSheetPanel.Controls) {
                    if (control is NoteTransportControl) {
                        if ((control as NoteTransportControl).Marked) {
                            (control as NoteTransportControl).Note.Length = (obj as Note).Length;
                            (control as NoteTransportControl).Note.Duration = (obj as Note).Duration;
                            (control as NoteTransportControl).ResetNoteImage();
                            changeFlag = true;
                        }
                    }
                }
            }

            if (!changeFlag) {
                _tool = new GraphicTool(obj, scoreSheetPanel);
                _tool.Manipulate();
                if (obj is Note) {
                    if (ObjectsStore.NoteControls[^1].Location.X > 900)
                        DrawObject(_staff);
                }
            }
        }

        private void scoreSheetPanel_ControlAdded(object sender, ControlEventArgs e) {
            btnDelNote.Enabled = ObjectsStore.NoteControls.Count > 0;
            btnPlay.Enabled = ObjectsStore.NoteControls.Count > 0;
        }

        private void scoreSheetPanel_ControlRemoved(object sender, ControlEventArgs e) {
            btnDelNote.Enabled = !(ObjectsStore.NoteControls.Count == 1);
            btnPlay.Enabled = !(ObjectsStore.NoteControls.Count == 1);
        }
    }
}
