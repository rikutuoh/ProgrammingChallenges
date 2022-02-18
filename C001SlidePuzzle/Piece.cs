using System.Drawing;

namespace PiecePuzzleGame
{
    class Piece
    {
        public int Pos { get; set; }
        public int CorrectPos { get; set; }

        public Rectangle rectangle;

        /// <summary>
        /// Piece constructor
        /// </summary>
        /// <param name="correctPosition">index of correct position</param>
        /// <param name="position">index of current position</param>
        /// <param name="point">coordinates of current position</param>
        public Piece(int correctPosition, int position, Point point)
        {
            Pos = position;
            CorrectPos = correctPosition;

            rectangle = new Rectangle(point, new Size(90, 90));
        }

        public static Point[] CreatePoints()
        {
            int n = 0;
            Point[] a = new Point[16];

            for (int iy = 0; iy < 4; iy++)
            {
                for (int ix = 0; ix < 4; ix++)
                {
                    Point point = new Point(ix * 100 + 10, iy * 100 + 10);

                    a[n] = point;
                    n++;
                }
            }
            return a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="nPos"></param>
        public void Moveto(Point point, int nPos)
        {
            rectangle.Location = point;
            Pos = nPos;
        }
    }
}
