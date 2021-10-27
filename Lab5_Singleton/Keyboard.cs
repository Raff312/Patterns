namespace Lab5_Singleton {
    class Keyboard : IDisposable {
        private static Keyboard? _instance;

        private Keyboard() { }

        ~Keyboard() {
            Dispose();
        }

        public void Dispose() {
            _instance = null;
            Log.GetInstance().Write(MessageType.Info, "Keyboard deleted");
        }

        public static Keyboard GetInstance() {
            if (_instance == null) {
                _instance = new Keyboard();
            }
            return _instance;
        }
    }
}