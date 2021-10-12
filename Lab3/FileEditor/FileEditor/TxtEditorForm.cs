using System;
using System.Windows.Forms;
using FileEditor.Documents;

namespace FileEditor {
    public partial class TxtEditorForm : Form {
        private readonly Form _parentForm;
        private readonly TxtDocument _document;

        public TxtEditorForm(Form parentForm, TxtDocument document) {
            InitializeComponent();
            _document = document;
            _parentForm = parentForm;
        }

        public void ShowForm() {
            MdiParent = _parentForm;
            Show();
        }

        public void ShowText(string text) {
            RichTextBox.Text = text;
        }

        private void OpenToolStripButton_Click(object sender, EventArgs e) {
            _document.Open();
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e) {
            _document.SaveAs();
        }

        private void CloseToolStripButton_Click(object sender, EventArgs e) {
            _document.Close();
        }

        private void ClearToolStripButton_Click(object sender, EventArgs e) {
            _document.Clear();
        }
    }
}
