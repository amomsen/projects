﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace sudoku
{
    public static class Board
    
    {

        //public static int NumberOfRowsAndColumns { get; set; }
        public static int EmptyFlagValue { get; set;}
        public static int SquareGrouping { get; set; }
        private static readonly List<int> Squares;
        private static Label[] Labels;
        public static int[] Values {get; set;}
        
        /*


        static Board()
        {

            int BoardSize = sudoku_new.Properties.Settings.Default.BoardSize;
            //SquareGrouping = sudoku_new.Properties.Settings.Default.SquareGrouping;
            EmptyFlagValue = sudoku_new.Properties.Settings.Default.EmptyFlag;

            try
            {
                //NumberOfRowsAndColumns = Convert.ToInt32(Math.Sqrt(BoardSize));
                
            }
            catch (OverflowException e)
            {
                //Use defaults values
                BoardSize = 1;
                //NumberOfRowsAndColumns = 1;

            }

            Squares = new List<int>(BoardSize);
            Labels = new Label[BoardSize];
            Values = new int[BoardSize];
            
        }*/
    }
}
