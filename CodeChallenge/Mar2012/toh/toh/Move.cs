﻿
namespace toh
{
    public class Move
    {
        public Pole FromPole { get; set; }
        public Pole ToPole { get; set; }

        public Move(Pole fromPole, Pole toPole)
        {
            this.FromPole = fromPole;
            this.ToPole = toPole;
        }

        public bool affectCount()
        {
            //If the poles dont change the move should not be counted
            if (ToPole.Equals(FromPole))
            {
                return false;
            }
            return isValid();
        }            

        public bool isValid()
        {
            //Allow a move where the pole dont change
            if (ToPole.Equals(FromPole))
            {
                return true;
            }
            return ToPole.allowDisk(FromPole.getTopDisk());
        }

        public Move(int fromPoleNumber, int toPoleNumber)
        {
            this.FromPole = GameState.Poles[fromPoleNumber];
            this.ToPole = GameState.Poles[toPoleNumber];
        }

        override public string ToString()
        {
            if (FromPole == null || ToPole == null)
            {
                return "Missing poles";
            }
            return "Move the top disk from " + FromPole.ToString() + " to " + ToPole.ToString() + "\n";
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
            // If parameter cannot be cast to Move return false.
            Move move = obj as Move;
            if ((System.Object)move == null)
            {
                return false;
            }
            return ((Move)obj).FromPole.Number == move.FromPole.Number &&
                ((Move)obj).ToPole.Number == move.ToPole.Number;
        }
    }
}