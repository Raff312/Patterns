using System.Drawing.Drawing2D;

namespace Lab4_Adapter {
    public class WatchDrawer {
        public Bitmap DrawAnalog(Size size, DateTime time) {
            var image = new Bitmap(size.Width, size.Height);
            var g = Graphics.FromImage(image);

            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, size.Width, size.Height);

            DrawClockFace(g, size);

            int hours = Convert.ToInt32(time.ToString("hh"));
            int minutes = Convert.ToInt32(time.ToString("mm"));
            int seconds = Convert.ToInt32(time.ToString("ss"));

            var angle1 = 2.0 * Math.PI * (hours + minutes / 60.0) / 12.0;
            var angle2 = 2.0 * Math.PI * (minutes + seconds / 60.0) / 60.0;
            var angle3 = 2.0 * Math.PI * seconds / 60.0;

            DrawArrow(g, size, new Pen(Color.Black, 4), Convert.ToDouble(angle1), 190);
            DrawArrow(g, size, new Pen(Color.Black, 3), Convert.ToDouble(angle2), 220);
            DrawArrow(g, size, new Pen(Color.Red, 2), Convert.ToDouble(angle3), 235);

            return image;
        }

        public void DrawClockFace(Graphics g, Size size) {
            g.FillEllipse(new SolidBrush(Color.White), 0, 0, size.Width, size.Height);

            var angle = -Math.PI / 3;

            for (var i = 1; i <= 12; i++) {
                var x = 250 * Math.Cos(angle) + size.Width / 2;
                var y = 250 * Math.Sin(angle) + size.Height / 2;

                g.DrawString(i.ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), (float)x, (float)y);

                angle += Math.PI / 6;
            }
        }

        public void DrawArrow(Graphics g, Size size, Pen pen, double angle, int length) {
            var x = length * Math.Cos(angle - Math.PI / 2) + size.Width / 2;
            var y = length * Math.Sin(angle - Math.PI / 2) + size.Height / 2;

            g.DrawLine(pen, size.Width / 2, size.Height / 2, (float)x, (float)y);
        }
    }
}
