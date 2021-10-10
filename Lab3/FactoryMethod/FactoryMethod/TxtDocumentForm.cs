using System;
using System.Windows.Forms;

namespace FactoryMethod {
    public partial class TxtDocumentForm : Form {
        private readonly Form _parentForm;
        private readonly TxtDocument _document;

        public TxtDocumentForm(Form parentForm, TxtDocument document) {
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
    }
}
