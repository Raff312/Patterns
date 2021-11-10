namespace Lab4_Adapter {
    public abstract class Watch {
        protected DateTime Time;

        public DateTime GetTime() { 
            return Time;
        }

        public void SetTime(DateTime time) {
            Time = time;
        }

        public void AddTime(TimeSpan time) {
            Time = Time.Add(time);
        }

        public abstract void Draw(PictureBox pictureBox);
    }
}
