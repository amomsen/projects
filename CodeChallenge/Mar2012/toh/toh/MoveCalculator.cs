using System;
using System.Collections.Generic;

namespace toh
{
    public static class MoveCalculator
    {
        private static List<Move> moves { get; set; }

        public static List<Move> GetMoves(int numberOfDisks)
        {
            moves = new List<Move>();
            Calculate(numberOfDisks - 1, 0, 2);
            return moves;
        }

        public static int GetMoveCount(int numberOfDisks)
        {
            Double numberOfDisks_Double = (Double) numberOfDisks;
            return (int) Math.Pow(2.0, numberOfDisks_Double) - 1;
        }

        private static void Calculate(int n, int fromPole, int toPole)
        {
            if (n == -1)
            {
                return; // We are done
            }
            int intermediatePole = GetIntermediatePole(fromPole, toPole);
            
            Calculate(n - 1, fromPole, intermediatePole);
            moves.Add(new Move(fromPole, toPole));
            Calculate(n - 1, intermediatePole, toPole);
        }

        private static int GetIntermediatePole(int startPole, int endPole)
        {
            return (3 - startPole - endPole);
        }
    }
}
