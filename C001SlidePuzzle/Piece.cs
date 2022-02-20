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
        public Piece(int correctPosition)
        {
            Pos = correctPosition;
            CorrectPos = correctPosition;
            rectangle = new Rectangle(new Point(correctPosition % 4 * 100 + 10, correctPosition / 4 * 100 + 10), new Size(90, 90));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="nPos"></param>
        public void Moveto(int nPos)
        {
            Pos = nPos;
            rectangle.Location = new Point(nPos % 4 * 100 + 10, nPos / 4 * 100 + 10);
        }
    }
}