using Timer = System.Timers.Timer;

namespace Lab4_Adapter {
    public partial class Form1 : Form {
        private Timer? timer;
        private Watch? watch;
        private bool isDigitalShown = true;
        private Form2? _form2;

        public Form1() {
            InitializeComponent();

            InitTimer();
            InitDigitalWatch();

            timer?.Start();
        }

        private void InitTimer() {
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e) {
            watch?.AddTime(TimeSpan.FromSeconds(1));
            watch?.Draw(pictureBox);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            timer?.Stop();
            timer?.Dispose();
            _form2?.Close();
        }

        private void btnToggle_Click(object sender, EventArgs e) {
            isDigitalShown = !isDigitalShown;

            if (isDigitalShown) {
                InitDigitalWatch();
            } else {
                InitAnalogWatch();
            }
        }

        private void btnChangeBy_Click(object sender, EventArgs e) {
            var timeStr = $"{numHours.Value}:{numMinutes.Value}:{numSeconds.Value}";
            watch?.AddTime(TimeSpan.Parse(timeStr));
            numHours.Value = 0;
            numMinutes.Value = 0;
            numSeconds.Value = 0;
        }

        private void btnSetTime_Click(object sender, EventArgs e) {
            if (_form2 == null) {
                _form2 = new Form2(watch);
            }

            _form2.Show();
        }

        private void InitDigitalWatch() {
            var time = watch?.GetTime();
            watch = new DigitalWatch();
            watch.SetTime(time == null ? DateTime.Now : time.Value);
        }

        private void InitAnalogWatch() {
            var time = watch?.GetTime();
            watch = new AnalogWatch();
            watch.SetTime(time == null ? DateTime.Now : time.Value);
        }
    }
}