using System.Drawing;

namespace MusicEditor.Models {
    public class Rotate {
        public static Bitmap RotateImage(Image image, Point offset, float angle) {
            var returnBitmap = new Bitmap(image.Height, image.Width);
            var g = Graphics.FromImage(returnBitmap);

            g.TranslateTransform((float)image.Width / 2, (float)image.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);
            g.DrawImage(image, offset);

            return returnBitmap;
        }
    }
}
