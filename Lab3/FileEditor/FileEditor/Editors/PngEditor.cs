using System.Windows.Forms;
using FileEditor.Documents;

namespace FileEditor.Editors {
    public class PngEditor : Editor {
        private readonly Form _parentForm;

        public PngEditor(Form parentForm) {
            _parentForm = parentForm;
        }

        public override Document CreateDocument() {
            var document = new PngDocument(_parentForm);
            document.New();
            return document;
        }

        public override void OpenDocument() {
            var document = new PngDocument(_parentForm);
            document.Open();
        }
    }
}