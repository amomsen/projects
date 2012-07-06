using System.Collections.Generic;
using Microsoft.SolverFoundation.Services;

namespace Sudoku
{
    public static class DecisionFactory
    {
        private static readonly List<Decision> Decisions = new List<Decision>(9);
        private static Domain domain = Domain.IntegerRange(1, 9);

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
                    Decisions.Add(new Decision(domain, "_" + i));
                }
            }
        }

        public static List<Decision> BuildDecisions(List<int> squares)
        {
            if (squares == null || squares.Count == 0)
            {
                return new List<Decision>();
            }

            Decisions.Clear();

            foreach (int i in squares)
            {
                Decisions.Add(new Decision(domain, "_" + i));
            }
            return Decisions;
        }
    }
}