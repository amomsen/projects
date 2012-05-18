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
            move(numberOfDisks - 1, 0, 2);
            return moves;
        }

        public static int GetMoveCount(int numberOfDisks)
        {
            Double numberOfDisks_Double = (Double) numberOfDisks;
            return (int) Math.Pow(2.0, numberOfDisks_Double) - 1;
        }

        private static void move(int n, int fromPole, int toPole)
        {
            if (n == -1)
            {
                return; // We are done
            }
            int intermediatePole = getIntermediatePole(fromPole, toPole);
            
            move(n - 1, fromPole, intermediatePole);
            moves.Add(new Move(fromPole, toPole));
            move(n - 1, intermediatePole, toPole);
        }

        private static int getIntermediatePole(int startPole, int endPole)
        {
            return (3 - startPole - endPole);
        }
    }
}
