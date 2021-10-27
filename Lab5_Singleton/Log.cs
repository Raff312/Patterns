namespace Lab5_Singleton {
    public class Log : IDisposable {
        private static Log? _instance;

        private Log() { }

        ~Log() {
            Dispose();
        }

        public void Dispose() {
            _instance = null;
        }

        public static Log GetInstance() {
            if (_instance == null) {
                _instance = new Log();
            }
            return _instance;
        }

        public void Write(MessageType type, string msg) {
            if (type == MessageType.Error) {
                ConsoleTools.WriteLine(ConsoleColor.DarkRed, msg);
            } else if (type == MessageType.Info) {
                ConsoleTools.WriteLine(ConsoleColor.DarkGreen, msg);
            }
        }
    }
}