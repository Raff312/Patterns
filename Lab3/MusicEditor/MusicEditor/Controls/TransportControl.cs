using MusicEditor.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusicEditor.Controls {
    public abstract class TransportControl : Control {
        private Color _color = Color.Transparent;
        private int _opacity = 100;
        private Image _image;

        public bool Marked { get; set; }
        public bool Rotated { get; set; }

        public Image Image {
            get { return _image; }
            set {
                if (value != null) {
                    _image = value;
                }
            }
        }

        public Color Color {
            get { return _color; }
            set {
                _color = value;
                RecreateHandle();
            }
        }

        public int Opacity {
            get {
                if (_opacity > 100) {
                    _opacity = 100;
                } else if (_opacity < 0) {
                    _opacity = 100;
                }

                return _opacity;
            }
            set {
                _opacity = value;
                RecreateHandle();
            }
        }

        protected override CreateParams CreateParams {
            get {
                var createParams = base.CreateParams;
                createParams.ExStyle |= 32;
                return createParams;
            }
        }

        public TransportControl() {
            SetStyle(ControlStyles.UserMouse, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Image = Resources.WholeNote;
            Width = 23;
            Height = 23;
            Marked = false;
            Rotated = false;
        }

        protected override void OnPaint(PaintEventArgs pe) {
            var graphics = pe.Graphics;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            var baseColor = Color;
            var alpha = !(baseColor == Color.Transparent) ? Opacity * byte.MaxValue / 100 : 0;
            var pen = new Pen(Color.Black);
            var solidBrush = new SolidBrush(Color.FromArgb(alpha, baseColor));
            
            graphics.DrawImage(Image, new Point(0, 0));
            graphics.FillRectangle(solidBrush, rect);
            
            pen.Dispose();
            solidBrush.Dispose();
            graphics.Dispose();
        }

        protected override void OnMove(EventArgs e) {
            RecreateHandle();
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
        }
    }
}
