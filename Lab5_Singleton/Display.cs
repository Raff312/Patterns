namespace Lab5_Singleton {
    class Display : IDisposable {
        private static Display? _instance;

        private Display() {
            var randomizer = new Random();

            try {
                if (randomizer.Next(0, 2) == 0) {
                    throw new Exception("Display instance cannot be created");
                }
            } catch (Exception ex) {
                Log.GetInstance().Write(MessageType.Error, ex.Message);
            }
        }

        ~Display() {
            Dispose();
        }

        public void Dispose() {
            _instance = null;
            Log.GetInstance().Write(MessageType.Info, "Display deleted");
        }

        public static Display GetInstance() {
            if (_instance == null) {
                _instance = new Display();
            }
            return _instance;
        }
    }
}