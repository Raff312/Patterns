using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileEditor.Documents {
    public class PngDocument : Document {
        private readonly Pen _pen = new(Color.Black);
        private readonly PngEditorForm _form;
        private readonly OpenFileDialog _openFileDialog;
        private readonly SaveFileDialog _saveFileDialog;
        private readonly ColorDialog _colorDialog;
        private Bitmap _oldImage;

        private Point _startPoint;
        private readonly Point _nullPoint = new(int.MaxValue, 0);

        public PngDocument(Form parentForm) {
            _form = new PngEditorForm(parentForm, this);

            _openFileDialog = new OpenFileDialog();
            _saveFileDialog = new SaveFileDialog();
            _openFileDialog.Filter = _saveFileDialog.Filter = @"Image files (*.bmp, *.jpg, *.png, *.gif)|*.bmp;*.jpg;*.png;*.gif";
            _openFileDialog.FileName = _saveFileDialog.FileName = @"Image";

            _colorDialog = new ColorDialog();

            _oldImage = new Bitmap(_form.PictureBox.Image);

            _form.PictureBox.MouseDown += PictureBox_MouseDown;
            _form.PictureBox.MouseMove += PictureBox_MouseMove;
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e) {
            _startPoint = e.Location;
            UpdateImage();
            if (Control.ModifierKeys != Keys.Alt) {
                return;
            }

            var color = ((Bitmap)_form.PictureBox.Image).GetPixel(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
                _form.ColorPalette.BackColor = color;
        }

        private void UpdateImage() {
            _oldImage.Dispose();
            _oldImage = new Bitmap(_form.PictureBox.Image);
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e) {
            if (_startPoint == _nullPoint)
                return;

            if (e.Button != MouseButtons.Left) {
                return;
            }

            using var graphics = Graphics.FromImage(_form.PictureBox.Image);
            graphics.DrawLine(_pen, _startPoint, e.Location);
            graphics.Dispose();
            _startPoint = e.Location;
            _form.PictureBox.Invalidate();
        }

        public override void New() {
            _form.ShowForm();
        }

        public override void Open() {
            _startPoint = _nullPoint;
            if (_openFileDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            var fileName = _openFileDialog.FileName;

            try {
                Image image = new Bitmap(fileName);
                using var graphics = Graphics.FromImage(image);
                graphics.Dispose();

                _form.PictureBox.Image?.Dispose();
                _form.PictureBox.Image = image;

                _form.Show();
                UpdateImage();
            } catch {
                MessageBox.Show(@"File " + fileName + @" has a wrong format.", @"Error");
                return;
            }

            _form.Text = @"Image Editor - " + fileName;
            _saveFileDialog.FileName = Path.ChangeExtension(fileName, "png");
            _openFileDialog.FileName = "";
        }

        public override void SaveAs() {
            var oldFileName = _saveFileDialog.FileName;

            if (_saveFileDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            var newFileName = _saveFileDialog.FileName;
            if (string.Equals(newFileName, oldFileName, StringComparison.CurrentCultureIgnoreCase)) {
                oldFileName = Path.GetDirectoryName(oldFileName) + "\\($$##$$).png";

                _form.PictureBox.Image.Save(oldFileName);
                _form.PictureBox.Image.Dispose();

                File.Delete(newFileName);
                File.Move(oldFileName, newFileName);

                _form.PictureBox.Image = new Bitmap(newFileName);
            } else {
                _form.PictureBox.Image.Save(newFileName);
            }

            _form.Text = @"Image Editor - " + newFileName;
        }

        public override void Clear() {
            using var graphics = Graphics.FromImage(_form.PictureBox.Image);
            graphics.Clear(Color.White);
            _form.PictureBox.Invalidate();
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

        public void ChooseColor() {
            _colorDialog.Color = _form.ColorPalette.BackColor;
            if (_colorDialog.ShowDialog() == DialogResult.OK) {
                _pen.Color = _form.ColorPalette.BackColor = _colorDialog.Color;
            }
        }
    }
}