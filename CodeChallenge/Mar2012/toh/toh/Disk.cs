using System.Windows.Forms;
using System.Drawing;

namespace toh
{
    public class Disk : PictureBox
    {
        public int Number { get; set; }

        public Disk(int Number) : base()
        {
            this.Number = Number;
            this.Image = GameState.ImageList[Number];
            int width = Properties.Settings.Default.DefaultDiskWidth + ((Number + 1) * Properties.Settings.Default.DiskWidthGrowthFactor); 
            this.Size = new Size(width, Properties.Settings.Default.DefaultDiskHeight);
            this.Location = new Point(100, 100);
            this.BackColor = SystemColors.ControlDark;
        }

        public void moveToPole(Pole DestinationPole)
        {
            int numberOfRungsOnSelectedPole = DestinationPole.Disks.Count;
            int growthFactor = this.Number * Properties.Settings.Default.DiskWidthGrowthFactor;
            int x = (DestinationPole.Location.X + DestinationPole.Width) - (DestinationPole.Width / 2) - (growthFactor / 2) - (Properties.Settings.Default.DefaultDiskWidth / 2);
            int y = (DestinationPole.Location.Y - ((numberOfRungsOnSelectedPole + 1) * Properties.Settings.Default.DefaultDiskHeight));
            this.Location = new Point(x, y);
        }

        public override string ToString()
        {
            return Number.ToString();
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
            // If parameter cannot be cast to Disk return false.
            Disk disk = obj as Disk;
            if ((System.Object)disk == null)
            {
                return false;
            }
            return ((Disk)obj).Number == Number;

        }
    }
}

