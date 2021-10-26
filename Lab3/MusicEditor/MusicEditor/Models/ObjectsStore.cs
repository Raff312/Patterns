using MusicEditor.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicEditor.Models {
    public static class ObjectsStore {
        public static List<NoteTransportControl> NoteControls { get; private set; }
        public static List<StaffTransportControl> StaffControls { get; private set; }

        static ObjectsStore() {
            NoteControls = new List<NoteTransportControl>();
            StaffControls = new List<StaffTransportControl>();
        }

        public static async Task Play() {
            foreach (var control in NoteControls) {
                await control.Note.Play();
            }
        }

        public static void Add(TransportControl control) {
            if (control is NoteTransportControl) {
                NoteControls.Add(control as NoteTransportControl);
            } else if (control is StaffTransportControl) {
                StaffControls.Add(control as StaffTransportControl);
            }
        }

        public static void Clear() {
            NoteControls?.Clear();
            StaffControls?.Clear();
        }

        public static void UnregisterLastNote() {
            if (NoteControls.Count != 0) {
                var noteForm = NoteControls[^1].FindForm() as EditorForm;
                var getPanel = noteForm.Controls.Find("panel1", false)[0].Controls.Find("scoreSheetPanel", false)[0];
                var noteContainer = (getPanel as Panel);
                noteContainer.Controls.Remove(NoteControls[^1]);
                NoteControls.RemoveAt(NoteControls.Count - 1);
            }
        }

        public static void UnregisterLastStaff() {
            if (StaffControls.Count != 0) {
                var staffForm = StaffControls[^1].FindForm() as EditorForm;
                var getPanel = staffForm.Controls.Find("panel1", false)[0].Controls.Find("scoreSheetPanel", false)[0];
                Panel staffContainer = (getPanel as Panel);
                for (int i = 0; i < 40; i++) {
                    staffContainer.Controls.Remove(StaffControls[^1]);
                    StaffControls.RemoveAt(StaffControls.Count - 1);
                }
            }
        }
    }
}
