using System;
using System.Windows.Forms;
using FileEditor.Documents;
using FileEditor.Editors;

namespace FileEditor {
    public partial class EditorForm : Form {
        public EditorForm() {
            InitializeComponent();
        }

        private void TxtCreateDocumentToolStripMenuItem_Click(object sender, EventArgs e) {
            HandleDocumentAction(DocumentType.Txt, ActionType.Create);
        }

        private void PngCreateDocumentToolStripMenuItem_Click(object sender, EventArgs e) {
            HandleDocumentAction(DocumentType.Png, ActionType.Create);
        }

        private void TxtOpenDocumentToolStripMenuItem1_Click(object sender, EventArgs e) {
            HandleDocumentAction(DocumentType.Txt, ActionType.Open);
        }

        private void PngOpenDocumentToolStripMenuItem1_Click(object sender, EventArgs e) {
            HandleDocumentAction(DocumentType.Png, ActionType.Open);
        }

        private void HandleDocumentAction(DocumentType documentType, ActionType actionType) {
            Editor editor = documentType == DocumentType.Txt
                ? new TxtEditor(this)
                : new PngEditor(this);

            if (actionType == ActionType.Create) {
                editor.CreateDocument();
            } else {
                editor.OpenDocument();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
