using System.Drawing;

namespace PiecePuzzleGame
{
    class Piece
    {
        public int Pos { get; set; }

        public int CorrectPos { get; set; }

        public Rectangle rectangle;

        public Piece(int correctPosition, int position, Point point)
        {
            CreatePoints();

            Pos = position;
            CorrectPos = correctPosition;

            rectangle = new Rectangle(point, new Size(90, 90));


        }

        public static Point[] CreatePoints()
        {
            int n = 0;
            Point[] a = new Point[16];

            for (int ix = 0; ix < 4; ix++)
            {
                for (int iy = 0; iy < 4; iy++)
                {
                    Point point = new Point(ix * 100 + 10, iy * 100 + 10);

                    a[n] = point;
                    n++;
                }
            }

            return a;
        }

        public void Moveto(Point point, int nPos)
        {
            rectangle.Location = point;
            Pos = nPos;
        }
    }
}
