namespace Lab4_Adapter {
    public class DigitalWatch : Watch {
        public override void Draw(PictureBox pictureBox) {
            var g = pictureBox.CreateGraphics();

            g.Clear(Color.White);

            string stringTime = Time.ToString("HH:mm:ss");
            var drawBrush = new SolidBrush(Color.Black);
            g.DrawString(stringTime, new Font("Arial", 60), drawBrush, 120, 220);
        }
    }
}
