using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;


namespace PiecePuzzleGame
{
    /// <summary>
    /// Game class, inherits System.Windows.Forms.Form so also acts as the window
    /// </summary>
    [System.ComponentModel.DesignerCategory("")] // Disables the windows forms designer in VS
    public class PiecePuzzleGame : Form
    {
        private readonly PictureBox pictureBox = new PictureBox();

        private Point[] points = Piece.CreatePoints();
        private Piece[] pieces = new Piece[15];

        int emptyPoint;

        /// <summary>
        /// Game class constuctor
        /// </summary>
        public PiecePuzzleGame()
        {
            CreatePieces();

            SetBounds(0, 0, 425, 450);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            pictureBox.Size = new Size(410, 420);
            pictureBox.BackColor = Color.Black;
            pictureBox.Visible = true;
            pictureBox.CreateGraphics();

            Controls.Add(pictureBox);

            pictureBox.Click += PictureBox_Click;
            pictureBox.Paint += PictureBox_Paint;

            Scramble();
        }

        /// <summary>
        /// Called when the picturebox is clicked
        /// </summary>
        /// <param name="sender">pictureBox</param>
        /// <param name="e">Event arguments</param>
        private void PictureBox_Click(object sender, EventArgs e)
        {
            foreach (Piece piece in pieces)
            {
                if (piece.rectangle.Contains(PointToClient(Cursor.Position)))
                {
                    if (Math.Abs(
                          piece.Pos - emptyPoint) == 4 || 
                        (piece.Pos - emptyPoint == 1 && !(piece.Pos % 4 == 0)) 
                        || 
                        (piece.Pos - emptyPoint == -1 && !((piece.Pos + 1) % 4 == 0)))
                    {
                        int temp = piece.Pos;
                        piece.Moveto(points[emptyPoint], emptyPoint);
                        emptyPoint = temp;
                    }
                }
            }
            pictureBox.Refresh();
        }


        private void Scramble()
        {
            int[] a = new int[15];
            for (int i = 0; i < a.Length; i++) a[i] = 16;
            for (int i = 0; i < 15; i++)
            {
                int n = 16;
                while (a.Contains(n))
                {
                    n = new Random().Next(16);
                }
                a[i] = n;
            }

            for (int i = 0; i < 15; i++)
            {
                if (!a.Contains(i)) emptyPoint = i;
                pieces[i].Moveto(points[a[i]], a[i]);
            }
        }

        /// <summary>
        /// Paints all pieces on the picturebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            foreach (Piece piece in pieces)
            {
                e.Graphics.DrawRectangle(new Pen(Color.White), piece.rectangle);
                PointF tpos;
                if (piece.CorrectPos > 8) tpos = new PointF(piece.rectangle.X + 25, piece.rectangle.Y + 35);
                else tpos = new PointF(piece.rectangle.X + 35, piece.rectangle.Y + 35);
                e.Graphics.DrawString($"{piece.CorrectPos + 1}", new Font(FontFamily.GenericSansSerif, 20), Brushes.White, tpos);
            }
        }

        /// <summary>
        /// Populates the pieces array
        /// </summary>
        public void CreatePieces()
        {
            for (int i = 0; i < 15; i++)
            {
                pieces[i] = new Piece(i, i, points[i]);
            }
        }


        /// <summary>
        /// Starting point
        /// </summary>
        public static void Main()
        {
            Application.Run(new PiecePuzzleGame());
        }
    }
}
