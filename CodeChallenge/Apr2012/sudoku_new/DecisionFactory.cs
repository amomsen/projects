using System.Collections.Generic;
using Microsoft.SolverFoundation.Services;

namespace sudoku
{
    public static class DecisionFactory
    {
        private static readonly List<Decision> Decisions = new List<Decision>(9);

        static DecisionFactory()
        {
            Initialize();
        }

        private static void Initialize()
        {
            if (Decisions.Count == 0)
            {
                for (int i = 0; i < 81; i++)
                {
                    Decisions.Add(new Decision(Domain.IntegerRange(1, 9), "_" + i));
                }
            }
        }

        public static List<Decision> BuildDecisions(List<int> squares)
        {
            Decisions.Clear();
            foreach (int i in squares)
            {
                Decisions.Add(new Decision(Domain.IntegerRange(1, 9), "_" + i));
            }
            return Decisions;
        }
    }
}