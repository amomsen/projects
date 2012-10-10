using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Sudoku
{
    //Rename boards?
    public partial class SudokuGrid : UserControl
    {
        private List<SudokuSquare> sudokuSquares = new List<SudokuSquare>();
        private List<int> solution = new List<int>();
        private List<int> attempt = new List<int>();
        private List<int> problem = new List<int>();
        private List<Point> PositionList = new List<Point>();

        public SudokuGrid()
        {
            InitializeComponent();
            solution = GameController.GetSudokuSolution();
            problem = GameController.GetSudokuProblem();
            DrawSquares();
        }

        private void GetPossibleSolution()
        {
            attempt = new List<int>();
            int input = 0;
            foreach (SudokuSquare square in sudokuSquares)
            {
                Int32.TryParse((square.SudokuTextBox.Text), out input);
                attempt.Add(input);
            }
        }

        private void DrawSquares()
        {
            int squareNumber = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    SudokuSquare sudokuSquare = new SudokuSquare(problem[squareNumber], solution[squareNumber], row, column);
                    sudokuSquare.SudokuTextBox.TextChanged += new TextChangedEventHandler(TextChanged);
                    sudokuSquares.Add(sudokuSquare);
                    Canvas.Children.Insert(1, sudokuSquare);
                    squareNumber++;
                }
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            GetPossibleSolution();
            GameController.IsSudokuSolved(attempt);
        }
    }
}