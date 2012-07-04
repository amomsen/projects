using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.SolverFoundation.Services;

namespace sudoku
{
    public static class GameController
    {

        public static List<int> GetSudokuSolution()
        {
            if (SudokuProblem.GetSolution().Count == 0)
            {
                SudokuProblem.Generate();
            }
            return SudokuProblem.GetSolution();
        }
        public static List<int> GetSudokuProblem()
        {
            if (SudokuProblem.GetProblem().Count == 0)
            {
                SudokuProblem.Generate();
            }
            return SudokuProblem.GetProblem();
        }
        public static void IsSudokuSolved(List<int> solution)
        {
            if (!solution.Contains(0))
            {
                if (SudokuProblem.IsSolved(solution))
                {
                    MessageBox.Show("Congratulations!");
                }
            }
        }
    }
}