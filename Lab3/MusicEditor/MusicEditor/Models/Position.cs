using System.Drawing;

namespace MusicEditor.Models {
    public class Position {
        public Point Current { get; set; }

        public Position(int x, int y) {
            Current = new Point(x, y);
        }
    }
}
