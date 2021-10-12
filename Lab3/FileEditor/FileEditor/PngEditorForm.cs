using System.Drawing;
using System.Windows.Forms;
using FileEditor.Documents;

namespace FileEditor {
    public partial class PngEditorForm : Form {
        private readonly Form _parentForm;
        private readonly PngDocument _document;

        public PngEditorForm(Form parentForm, PngDocument document) {
            InitializeComponent();
            _document = document;
            _parentForm = parentForm;
            InitializePictureBox();
        }

        private void InitializePictureBox() {
            Image image = new Bitmap(PictureBox.Width, PictureBox.Width);
            using var graphics = Graphics.FromImage(image);
            graphics.Clear(Color.White);
            graphics.Dispose();

            PictureBox.Image?.Dispose();
            PictureBox.Image = image;
        }

        public void ShowForm() {
            MdiParent = _parentForm;
            Show();
        }

        private void OpenToolStripButton_Click(object sender, System.EventArgs e) {
            _document.Open();
        }

        private void SaveToolStripButton_Click(object sender, System.EventArgs e) {
            _document.SaveAs();
        }

        private void CloseToolStripButton_Click(object sender, System.EventArgs e) {
            _document.Close();
        }

        private void ColorPalette_Click(object sender, System.EventArgs e) {
            _document.ChooseColor();
        }

        private void ClearToolStripButton_Click(object sender, System.EventArgs e) {
            _document.Clear();
        }
    }
}
