using System;
using System.Collections.Generic;
using Microsoft.SolverFoundation.Services;

namespace Sudoku
{
    public static class SudokuProblem
    {
        private static List<int> problem = new List<int>();
        private static List<int> solution = new List<int>();
        private static int hints = Sudoku.Properties.Settings.Default.Hints;

        public static bool IsSolved(List<int> possibleSolution)
        {
            if (possibleSolution == null)
            {
                return false;
            }

            for (int i = 0; i < possibleSolution.Count; i++)
            {
                if (possibleSolution[i] != solution[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static void GenerateProblem()
        {
            SolverContext context = SolverContext.GetContext();
            context.ClearModel();
            Model model = context.CreateModel();
            List<Decision> decisionList = DecisionFactory.BuildDecisions(Grid.GetAllSquares());

            model.AddDecisions(decisionList.ToArray());

            // Add constraints to model.
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

            solution = ConvertDecicionsToIntegers(decisionList);

            HideNumbers();
        }

        public static List<int> GetSolution()
        {
            return solution;
        }

        public static List<int> GetProblem()
        {
            return problem;
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

        private static void HideNumbers()
        {
            List<int> toHide = Utils.GetUniqueRandomNumbers(0, 81, 81 - hints);

            problem.AddRange(solution);
            foreach (int hideMe in toHide)
            {
                problem[hideMe] = 0;
            }
        }
    }
}