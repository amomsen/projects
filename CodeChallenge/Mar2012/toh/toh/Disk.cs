using System.Drawing;
using System.Windows.Forms;

namespace toh
{
    public class Disk : PictureBox
    {
        public int Number { get; set; }

        public Disk(int number) : base()
        {
            Number = number;
            Image = GameState.ImageList[Number];
            Size = Image.Size;
        }

        public void MoveToPole(Pole destinationPole)
        {
            if (destinationPole == null || destinationPole.Disks == null)
            {
                return;
            }
            int numberOfRungsOnSelectedPole = destinationPole.Disks.Count;         
            int x = (destinationPole.Location.X + destinationPole.Width) - (destinationPole.Width / 2)  - (this.Size.Width / 2);
            int y = destinationPole.Location.Y + destinationPole.Size.Height - ((numberOfRungsOnSelectedPole + 1) * this.Size.Height) - toh.Properties.Resources._base.Size.Height;
            this.Location = new Point(x, y);
            this.BringToFront();
        }

        public override string ToString()
        {
            return Number.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
         
            Disk disk = obj as Disk;
            if ((System.Object)disk == null)
            {
                return false;
            }
            return disk.Number == Number;

        }
    }
}

