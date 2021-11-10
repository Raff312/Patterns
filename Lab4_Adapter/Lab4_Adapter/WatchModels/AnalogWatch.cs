namespace Lab4_Adapter {
    public class AnalogWatch : Watch {
        private WatchDrawer drawer;

        public AnalogWatch() {
            drawer = new WatchDrawer();
        }

        public override void Draw(PictureBox pictureBox) {
            pictureBox.Image = drawer.DrawAnalog(new Size(pictureBox.Width, pictureBox.Height), Time);
        }
    }
}
