using System.Windows.Forms;
using FileEditor.Documents;

namespace FileEditor.Editors {
    public class TxtEditor : Editor {
        private readonly Form _parentForm;

        public TxtEditor(Form parentForm) {
            _parentForm = parentForm;
        }

        public override Document CreateDocument() {
            var document = new TxtDocument(_parentForm);
            document.New();
            return document;
        }

        public override void OpenDocument() {
            var document = new TxtDocument(_parentForm);
            document.Open();
        }
    }
}