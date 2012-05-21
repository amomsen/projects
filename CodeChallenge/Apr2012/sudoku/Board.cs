using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace sudoku
{
    public static class Board
    
    {
        private static int BoardSize {get; set;}
        public static int NumberOfRowsAndColumns { get; set; }
        public static int EmptyFlagValue { get; set;}
        public static int SquareGrouping { get; set; }
        private static readonly List<int> Squares;
        private static Label[] Labels;
        public static int[] Values {get; set;}
        private static int SelectedBlock;


        static Board()
        {

            BoardSize = Properties.Settings.Default.BoardSize;
            SquareGrouping = Properties.Settings.Default.SquareGrouping;
            EmptyFlagValue = Properties.Settings.Default.EmptyFlag;

            try
            {
                NumberOfRowsAndColumns = Convert.ToInt32(Math.Sqrt(BoardSize));
                
            }
            catch (OverflowException e)
            {
                //Use defaults values
                BoardSize = 1;
                NumberOfRowsAndColumns = 1;

            }

            Squares = new List<int>(BoardSize);
            Labels = new Label[BoardSize];
            Values = new int[BoardSize];


            
        }

        

    }
}
