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
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].rectangle.Contains(PointToClient(Cursor.Position)))
                {
                    if (Math.Abs(
                          pieces[i].Pos - emptyPoint) == 4 ||
                        (pieces[i].Pos - emptyPoint == 1 && !(pieces[i].Pos % 4 == 0))
                        ||
                        (pieces[i].Pos - emptyPoint == -1 && !((pieces[i].Pos + 1) % 4 == 0)))
                    {
                        int temp = pieces[i].Pos;
                        pieces[i].Moveto(emptyPoint);
                        emptyPoint = temp;
                    }
                }
            }
            pictureBox.Refresh();
        }

        /// <summary>
        /// Scrambles the pieces
        /// </summary>
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
                pieces[i].Moveto(a[i]);
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

            for (int i = 0; i < pieces.Length; i++)
            {
                e.Graphics.DrawRectangle(new Pen(Color.White), pieces[i].rectangle);
                Point tpos;
                if (pieces[i].CorrectPos > 8) tpos = new Point(pieces[i].rectangle.X + 25, pieces[i].rectangle.Y + 35);
                else tpos = new Point(pieces[i].rectangle.X + 35, pieces[i].rectangle.Y + 35);
                e.Graphics.DrawString($"{pieces[i].CorrectPos + 1}", new Font(FontFamily.GenericSansSerif, 20), Brushes.White, tpos);
            }
        }

        /// <summary>
        /// Populates the pieces array
        /// </summary>
        public void CreatePieces()
        {
            for (int i = 0; i < 15; i++)
            {
                pieces[i] = new Piece(i);
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