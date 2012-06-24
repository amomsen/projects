
using System.Collections.Generic;

namespace sudoku
{
    public static class Grid
    {
        private static readonly List<int> Squares = new List<int>(81);

        static Grid()
        {
            if (Squares.Count == 0)
            {
                for (int i = 0; i < 81; i++)
                {
                    Squares.Add(i);
                }
            }
        }

        public static List<int> GetAllSquares()
        {
            return Squares;
        }

        public static List<int> GetRow(int rowNumber)
        {
            List<int> row = new List<int>(9);
            for (int i = 0; i < 9; i++)
            {
                row.Add(Squares[i + (rowNumber * 9)]);
            }
            return row;
        }

        public static List<int> GetColumn(int columnNumber)
        {
            List<int> column = new List<int>(9);
            for (int i = 0; i < 9; i++)
            {
                column.Add(Squares[(i * 9) + columnNumber]);
            }
            return column;
        }

        public static List<int> GetBox(int boxNumber)
        {
            List<int> box = new List<int>(9);
            int verticalOffSet = (boxNumber / 3) * 3;
            for (int i = 0 + verticalOffSet; i < 3 + verticalOffSet; i++)
            {
                List<int> row = GetRow(i);
                int horizontalOffSet = (boxNumber % 3) * 3;
                for (int j = 0 + horizontalOffSet; j < 3 + horizontalOffSet; j++)
                {
                    box.Add(row[j]);
                }
            }
            return box;
        }
    }
}


