using System.Drawing;
using System.Windows.Forms;

namespace toh
{
    public class Disk : PictureBox
    {
        public int Number { get; set; }

        public Disk(int Number) : base()
        {
            this.Number = Number;
            this.Image = GameState.ImageList[Number];
            this.Size = this.Image.Size;
            this.BackColor = SystemColors.ControlDark;
            this.BringToFront();
        }

        public void MoveToPole(Pole DestinationPole)
        {
            int numberOfRungsOnSelectedPole = DestinationPole.Disks.Count;
            int growthFactor = this.Number * Properties.Settings.Default.DiskWidthGrowthFactor;            
            int x = (DestinationPole.Location.X + DestinationPole.Width) - (DestinationPole.Width / 2)  - (this.Size.Width / 2);
            int y = DestinationPole.Location.Y + DestinationPole.Size.Height - ((numberOfRungsOnSelectedPole + 1) * this.Size.Height) - toh.Properties.Resources._base.Size.Height;
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
            return ((Disk)obj).Number == Number;

        }
    }
}

