using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace sudoku
{
    public partial class SudokuGrid : UserControl
    {
        private List<SudokuSquare> sudokuSquares = new List<SudokuSquare>();
        private List<int> possibleSolution = new List<int>();
        private int[] sudokuProblem = new int[81];
        private List<Point> PositionList = new List<Point>();

        public SudokuGrid()
        {
            InitializeComponent();
            sudokuProblem = GameController.GetSudokuProblem().ToArray();
            DrawSquares();
        }

        private void getPossibleSolution()
        {
            possibleSolution = new List<int>();
            foreach (SudokuSquare square in sudokuSquares)
            {
                possibleSolution.Add(Convert.ToInt32(square.Value));
            }
        }

        private void CheckIfSuccess()
        {
            getPossibleSolution();
            if (!possibleSolution.Contains(0))
            {
                if (GameController.IsProblemSolved(possibleSolution))
                {
                    MessageBox.Show("Congratulations!");
                }
            }
        }

        private void DrawSquares()
        {
            int squareNumber = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    SudokuSquare sudokuSquare = new SudokuSquare(sudokuProblem[squareNumber], row, column);
                    sudokuSquare.SudokuTextBox.TextChanged += new TextChangedEventHandler(TextChanged);
                    sudokuSquares.Add(sudokuSquare);
                    Canvas.Children.Insert(1, sudokuSquare);
                    squareNumber++;
                }
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfSuccess();
        }

    }
}