using System;
using System.Collections.Generic;
using Microsoft.SolverFoundation.Services;
using System.Windows;

namespace sudoku
{
    //Notes: Currently no Game/move evaluation
    public static class GameController
    {
        private static List<int> sudokuProblem = new List<int>();

        private static List<int> HideNumbers(int amountToHide)
        {
            List<int> toHide = Utils.GetUniqueRandomNumbers(0, 81, amountToHide);

            
            List<int> sudokuProblemWithHints = new List<int>();
            sudokuProblemWithHints.AddRange(sudokuProblem);
            foreach (int hideMe in toHide)
            {
                sudokuProblemWithHints[hideMe] = 0;
            }
            return sudokuProblemWithHints;
        }

        public static List<int> GetSudokuProblem()
        {
            sudokuProblem = GetSudokuNumbers();
            int amountOfHints = sudoku_new.Properties.Settings.Default.Hints;
            return HideNumbers((sudokuProblem.Count - amountOfHints));
            
        }

        public static bool IsProblemSolved(List<int> possibleSolution)
        {
            for (int i = 0; i < possibleSolution.Count; i++)
            {
                if (possibleSolution[i] != sudokuProblem[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static List<int> GetSudokuNumbers()
        {
            SolverContext context = SolverContext.GetContext();
            context.ClearModel();
            Model model = context.CreateModel();
            List<Decision> decisionList = DecisionFactory.BuildDecisions(Grid.GetAllSquares());

            model.AddDecisions(decisionList.ToArray());

            /* Add constraints to model.*/
            for (int j = 0; j < 9; j++)
            {
                model.AddConstraints("constraint_" + j,
                    Model.AllDifferent(getDecision(decisionList, Grid.GetRow(j))),
                    Model.AllDifferent(getDecision(decisionList, Grid.GetColumn(j))),
                    Model.AllDifferent(getDecision(decisionList, Grid.GetBox(j)))
                );
            }
            int seedValue = Utils.GetRandomNumber(1, 10);
            int seedPosition = Utils.GetRandomNumber(1, 10);
            model.AddConstraints("seed", decisionList[seedPosition] == seedValue);

            context.Solve(new ConstraintProgrammingDirective());

            List<int> results = ConvertDecicionsToIntegers(decisionList);
            return results;
        }

        private static List<int> ConvertDecicionsToIntegers(List<Decision> decisionList)
        {
            List<int> results = new List<int>();
            foreach (Decision decision in decisionList)
            {
                results.Add(Convert.ToInt32(decision.ToString()));
            }
            return results;
        }

        private static Term[] getDecision(List<Decision> decisionList, List<int> indexes)
        {
            Term[] results = new Term[9];
            int i = 0;
            foreach (int index in indexes)
            {
                results[i] = (decisionList[index]);
                i++;
            }
            return results;
        }
    }
}