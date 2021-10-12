using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FileEditor.Documents {
    public class TxtDocument : Document {
        private readonly TxtEditorForm _form;
        private readonly OpenFileDialog _openFileDialog;
        private readonly SaveFileDialog _saveFileDialog;

        public TxtDocument(Form parentForm) {
            _form = new TxtEditorForm(parentForm, this);

            _openFileDialog = new OpenFileDialog();
            _saveFileDialog = new SaveFileDialog();
            _openFileDialog.Filter = _saveFileDialog.Filter = @"Text files (*.txt)|*.txt|All files (*.*)|*.*";
            _openFileDialog.FileName = _saveFileDialog.FileName = @"Document";
        }

        public override void New() {
            _form.ShowForm();
        }

        public override void Open() {
            if (_openFileDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            var docName = new FileInfo(_openFileDialog.FileName);
            _form.Text = docName.Name;

            var fileContent = File.ReadAllText(_openFileDialog.FileName);
            _form.ShowText(fileContent);

            _form.ShowForm();
        }

        public override void SaveAs() {
            if (_saveFileDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            var save = new StreamWriter(_saveFileDialog.FileName, false, Encoding.GetEncoding("utf-8"));
            save.Write(_form.RichTextBox.Text);
            save.Close();
        }

        public override void Clear() {
            _form.ShowText(string.Empty);
        }

        public override void Close() {
            var result = MessageBox.Show(@"Are you sure you want to close the document?", @"Close document",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes) {
                _form.Close();
            }
        }
    }
}