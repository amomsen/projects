using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace toh
{
    public partial class GameForm : Form
    {
        private List<Bitmap> imageList = new List<Bitmap>();

        public GameForm()
        {
            InitializeComponent();
            this.AllowDrop = true;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            RestartGame();
        }

        void thisBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void thisBox_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

            ((PictureBox)sender).Location = new Point(Cursor.Position.X - this.Location.X,
                                                      Cursor.Position.Y - this.Location.Y);

            if (e.Action == DragAction.Drop)
            {
                int destinationPoleNumber = DeterminePoleFromCursorPosition();

                //The disk we are moving
                Disk disk = (Disk)sender;
                Pole currentPole = GameState.FindDisk(disk);
                Move move = new Move(currentPole, GameState.Poles[destinationPoleNumber]);

                if (move.IsValid())
                {
                    MakeMove(move);
                }
                else
                {
                    Move moveBack = new Move(currentPole, currentPole);
                    GameState.Move(moveBack);
                }
            }
        }

        private void MakeMove(Move move)
        {
            int moveCount = GameState.Move(move);
            moveCounter.Text = moveCount.ToString();
            if (GameState.IsSolved())
            {
                Score score = new Score(usernameTextbox.Text, GameState.MoveCount.ToString());
                Form dlg1 = new Form();
                dlg1.ShowDialog();
                //.Text += "Solved :) ";
            }
        }

        private void disk_MouseDown(object sender, MouseEventArgs e)
        {
            Disk disk = (Disk)sender;
            Pole pole = GameState.FindDisk(disk);

            //Check if the disk is the top one
            if (!pole.getTopDisk().Equals(disk))
            {
                return;
            }
            ((PictureBox)sender).DoDragDrop(((PictureBox)sender), DragDropEffects.All);
        }

        private Point GetMousePosition()  {
            return new Point(Cursor.Position.X - this.Location.X - 10, Cursor.Position.Y - this.Location.Y - 30);
        }

        //Determine at which pole the cursor is
        private int DeterminePoleFromCursorPosition()
        {
            Point MousePosition = GetMousePosition();
            if (MousePosition.X < GameState.Poles[0].Location.X)
                return 0;
            if (MousePosition.X > GameState.Poles[1].Location.X - 60 && MousePosition.X < GameState.Poles[2].Location.X - 60)
                return 1;
            if (MousePosition.X > GameState.Poles[2].Location.X - 60 && MousePosition.X < GameState.Poles[2].Location.X + 350)
                return 2;
            //Use pole 0 as default
            return 0;
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem Item = sender as ToolStripDropDownItem;
            RestartGame(Convert.ToInt16(Item.Text));
        }

        private void Form2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void showMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartGame();
            SolveGame();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void SolveGame()
        {
            List<Move> moves = MoveCalculator.GetMoves(GameState.NumberOfDisks);
            //hints.Text = "";
            //hints.Text = "Hints: ";
            foreach (Move move in moves)
            {
                //hints.Text += move.ToString();
                MakeMove(move);
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void RestartGame(int numberOfDisks)
        {
            GameState.NumberOfDisks = numberOfDisks;
            RestartGame();
        }

        private void RestartGame()
        {
            RemoveAllDisks();
            GameState.RestartGame();
            AddComponents();
            //hints.Text = "";
            moveCounter.Text = GameState.MoveCount.ToString();
            possibleToSolve.Text = "It is possible to solve this puzzel in " + MoveCalculator.GetMoveCount(GameState.NumberOfDisks).ToString() + " moves.";
        }

        private void RemoveAllDisks()
        {
            foreach (Pole pole in GameState.Poles)
            {
                foreach (Disk disk in pole.Disks.Values)
                {
                    this.Controls.Remove(disk);
                }
            }
        }

        private void AddComponents()
        {
            PictureBox _base = new PictureBox();
            _base.Image = toh.Properties.Resources._base;
            _base.Size = toh.Properties.Resources._base.Size;
            _base.BackColor = SystemColors.ControlDarkDark;
            _base.Location = new Point(GameConstants.BaseStartPositionX, GameConstants.BaseStartPositionY);


            this.Controls.Add(_base);
            
            moveCounter.Text = GameState.MoveCount.ToString();
            
            foreach (Pole pole in GameState.Poles)
            {
                InitPole(pole);
                foreach (Disk disk in pole.Disks.Values)
                {
                    InitDisk(disk);
                }
            }
        }

        private void InitPole(Pole pole)
        {
            if (!this.Controls.Contains(pole))
            {
                this.Controls.Add(pole);
            }
        }

        private void InitDisk(Disk disk)
        {
            if (!this.Controls.Contains(disk))
            {
                disk.MouseDown += new MouseEventHandler(disk_MouseDown);
                disk.QueryContinueDrag += new QueryContinueDragEventHandler(thisBox_QueryContinueDrag);
                disk.DragOver += new DragEventHandler(thisBox_DragOver);
                this.Controls.Add(disk);
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            usernameTextbox.Text = "";
        }

    }
}