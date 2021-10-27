namespace Lab5_Singleton {
    public class Program {
        public static void Main() {
            using var keyboard = Keyboard.GetInstance();
            using var display = Display.GetInstance();
        }
    }
}

