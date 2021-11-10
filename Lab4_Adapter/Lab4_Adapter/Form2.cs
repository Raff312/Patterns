namespace Lab4_Adapter {
    public partial class Form2 : Form {
        private readonly Watch? _watch;

        public Form2(Watch? watch) {
            InitializeComponent();
            _watch = watch;
        }

        private void Form2_Load(object sender, EventArgs e) {
            if (_watch == null) { return; }

            var time = _watch.GetTime();
            numHours.Value = time.Hour;
            numMinutes.Value = time.Minute;
            numSeconds.Value = time.Second;
        }

        private void btnOk_Click(object sender, EventArgs e) {
            var timeStr = $"{numHours.Value}:{numMinutes.Value}:{numSeconds.Value}";
            _watch?.SetTime(DateTime.Parse(timeStr));
            Hide();
        }
    }
}
