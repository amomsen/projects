﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace sudoku
{
    public partial class SudokuGrid : UserControl
    {
        private List<SudokuSquare> sudokuSquares = new List<SudokuSquare>();
        private List<int> solution = new List<int>();
        private List<int> problem = new List<int>();
        private List<Point> PositionList = new List<Point>();

        public SudokuGrid()
        {
            InitializeComponent();
            solution = GameController.GetSudokuSolution();
            problem = GameController.GetSudokuProblem();
            DrawSquares();
        }

        private void getPossibleSolution()
        {
            solution = new List<int>();
            foreach (SudokuSquare square in sudokuSquares)
            {
                solution.Add(Convert.ToInt32(square.Value));
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
            getPossibleSolution();
            GameController.IsSudokuSolved(solution);
        }

    }
}