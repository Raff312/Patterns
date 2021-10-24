using System.Drawing;

namespace MusicEditor.Models {
    public class Position {
        public Point Current { get; set; }

        public Position(int x, int y) {
            Current = new Point(x, y);
        }

        public static Position CalculateNotePositionOnDeletion(Position lastPosition) {
            if (lastPosition.Current.X == 43) {
                return new Position(917, lastPosition.Current.Y - 50);
            }

            return new Position(lastPosition.Current.X - 23, lastPosition.Current.Y);
        }

        public static Position CalculateStaffPositionOnDeletion(Position lastPosition) {
            return new Position(lastPosition.Current.X, lastPosition.Current.Y - 50);
        }

        public static Position CalculateNotePosition(Position lastPosition) {
            if (lastPosition.Current.X >= 900) {
                return new Position(43, lastPosition.Current.Y + 50);
            }

            return new Position(lastPosition.Current.X + 23, lastPosition.Current.Y);
        }

        public static Position CalculateStaffPosition(Position lastPosition) {
            if (lastPosition.Current.X >= 900) {
                return new Position(20, lastPosition.Current.Y + 50);
            }

            return new Position(lastPosition.Current.X + 23, lastPosition.Current.Y);
        }

        public static Position CalculatePausePosition(Position lastPosition) {
            if (lastPosition.Current.X >= 900) {
                return new Position(20, lastPosition.Current.Y + 30);
            }

            return new Position(lastPosition.Current.X + 15, lastPosition.Current.Y);
        }
    }
}
