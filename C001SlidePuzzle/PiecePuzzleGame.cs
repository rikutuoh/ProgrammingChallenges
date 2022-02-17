using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;


namespace PiecePuzzleGame
{
    [System.ComponentModel.DesignerCategory("")] // Disables the windows forms designer in VS
    public class PiecePuzzleGame : Form
    {
        private PictureBox pictureBox = new PictureBox();

        private Point[] points = Piece.CreatePoints();
        private Piece[] pieces = new Piece[15];

        int emptyPoint;

        public PiecePuzzleGame()
        {
            CreatePieces();

            SetBounds(0, 0, 425, 450);
            FormBorderStyle = FormBorderStyle.FixedSingle;


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
        /// 
        /// </summary>
        /// <param name="sender">pictureBox</param>
        /// <param name="e">Event arguments</param>
        private void PictureBox_Click(object sender, EventArgs e)
        {
            foreach (Piece piece in pieces)
            {
                if (piece.rectangle.Contains(PointToClient(Cursor.Position)))
                {

                    if (Math.Abs(piece.Pos - emptyPoint) == 4 || 
                        ((piece.Pos - emptyPoint == 1 && !(piece.Pos == 4 || piece.Pos == 8 || piece.Pos == 12)) 
                        || (piece.Pos - emptyPoint == -1 && !(piece.Pos == 3 || piece.Pos == 7 || piece.Pos == 11))))
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

            for (int i = 0; i < 15; i++)
            {
                int n = new Random().Next(16);

                while (a.Contains(n))
                {
                    n = new Random().Next(16);
                }

                a[i] = n;
            }

            int b = 0;

            foreach (Piece piece in pieces)
            {
                piece.Moveto(points[a[b]], a[b]);
                b++;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            e.Graphics.Clear(Color.Black);

            foreach (Piece piece in pieces)
            {
                graphics.DrawRectangle(new Pen(Color.White), piece.rectangle);
                graphics.DrawString($"{piece.CorrectPos + 1}", new Font(FontFamily.GenericSansSerif, 10), Brushes.White, piece.rectangle.Location);

            }
        }

        /// <summary>
        /// Populates the pieces array
        /// </summary>
        public void CreatePieces()
        {
            for (int i = 0; i < 15; i++)
            {
                pieces[i] = new(i, i, points[i]);
            }
        }


    }
}
