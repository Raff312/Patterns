using System.Windows.Forms;
using MusicEditor.Graphic;
using MusicEditor.Models;

namespace MusicEditor {
    public partial class EditorForm : Form {
        private readonly Staff _staff;

        private readonly Position _staffPosition;
        private readonly Position _notePosition;

        public EditorForm() {
            InitializeComponent();

            _staffPosition = new Position(0, 0);
            _notePosition = new Position(0, 0);

            _staff = new Staff(this);

            _staff.Draw(_staffPosition);

        }
    }
}
