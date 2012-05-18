using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace toh
{
    public class Pole : PictureBox
    {
        public SortedList<int, Disk> Disks { get; set; }
        public int Number { get; set; }

        private const int spaceBetweenPoles = 300;
        private const int startXPosition = 90;
        private const int startYPosition = 320;
        private const int width = 200;
        private const int heigth = 20;

        public Pole(int number)
        {
            this.Number = number;
            int XPosition = startXPosition + (number * spaceBetweenPoles);
            int YPosition = startYPosition;

            Disks = new SortedList<int, Disk>();
            this.BackColor = SystemColors.ControlDarkDark;
            this.Size = new Size(width, heigth);
            this.Image = toh.Properties.Resources._base;
            this.Location = new Point(XPosition, YPosition);
        }

        public bool isEmpty()
        {
            return Disks.Count == 0;
        }

        public bool allowDisk(Disk disk)
        {
            if (disk == null)
            {
                return false;
            }
            if (Disks.Count == 0)
            {
                return true;
            }
            return getTopDisk().Number > disk.Number;
        }

        public Disk getTopDisk()
        {
            if (Disks.Count > 0)
            {
                return Disks.First().Value;
            }
            return null;
        }

        public void RemoveDisk()
        {
            Disks.Remove(Disks.First().Key);
        }

        public void AddDisk(Disk disk)
        {
            if (allowDisk(disk))
            {
                disk.moveToPole(this);
                Disks.Add(disk.Number, disk);
            }
        }

        override public string ToString()
        {
            return string.Format("{0}", Number);
        }

        public override bool Equals(object obj)
        {
            {
                // If parameter is null return false.
                if (obj == null)
                {
                    return false;
                }

                // If parameter cannot be cast to Pole return false.
                Pole pole = obj as Pole;
                if ((System.Object)pole == null)
                {
                    return false;
                }
                return ((Pole)obj).Number == Number;
            }
        }

    }
}

