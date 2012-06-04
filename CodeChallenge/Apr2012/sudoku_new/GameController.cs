using System;
using System.Collections.Generic;
using Microsoft.SolverFoundation.Services;

namespace sudoku
{
    class GameController
    {
        private static void HideNumbers(List<int> list, int amount)
        {
            List<int> toHide = Utils.GetUniqueRandomIntegers(0, 81, amount);
            for (int x = 0; x < list.Count; x++)
            {
                if (toHide.Contains(x))
                {
                        list[x] = 0;
                }
            }
        } 

        public static List<int> GetSudokuProblem(int amountOfHints)
        {
            List<int> problem = GetSudokuNumbers();
            HideNumbers(problem, (problem.Count - amountOfHints));
            return problem;
        }

        

        private static bool isValidMove(List<int> problem, int index, int value)
        {
            SolverContext context = SolverContext.GetContext();
            context.ClearModel();
            Model model = context.CreateModel();
            List<Decision> decisionList = DecisionFactory.BuildDecisions(GridHelper.GetAllSquares());

            model.AddDecisions(decisionList.ToArray());

            /* Add constraints to model.*/

            int j = index;

                model.AddConstraints("constraint_" + j,
                    Model.AllDifferent(getDecision(decisionList, GridHelper.GetRow(j))),
                    Model.AllDifferent(getDecision(decisionList, GridHelper.GetColumn(j))),
                    Model.AllDifferent(getDecision(decisionList, GridHelper.GetBox(j)))
                );
            
            int seed = value;
            int position = index;
            model.AddConstraints("seed", decisionList[position] == seed);

            Solution solution = context.Solve(new ConstraintProgrammingDirective());
            Report report = solution.GetReport();
      
            return false;

        }

        private static List<int> GetSudokuNumbers()
        {
            SolverContext context = SolverContext.GetContext();
            context.ClearModel();
            Model model = context.CreateModel();
            List<Decision> decisionList = DecisionFactory.BuildDecisions(GridHelper.GetAllSquares());

            model.AddDecisions(decisionList.ToArray());

            /* Add constraints to model.*/
            for (int j = 0; j < 9; j++)
            {
                model.AddConstraints("constraint_" + j,
                    Model.AllDifferent(getDecision(decisionList, GridHelper.GetRow(j))),
                    Model.AllDifferent(getDecision(decisionList, GridHelper.GetColumn(j))),
                    Model.AllDifferent(getDecision(decisionList, GridHelper.GetBox(j)))
                );
            }
            int seed = Utils.GetUniqueRandomIntegers(1, 10, 1)[0];
            int position = Utils.GetUniqueRandomIntegers(1, 10, 1)[0];
            model.AddConstraints("seed", decisionList[position] == seed);

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
