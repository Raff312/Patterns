using System;
using System.Windows.Forms;

namespace FactoryMethod {
    public partial class MainForm : Form {
        public MainForm() {
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
            App application = documentType == DocumentType.Txt
                ? new TxtApplication(this)
                : new PngApplication(this);

            if (actionType == ActionType.Create) {
                application.CreateDocument();
            } else {
                application.OpenDocument();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
