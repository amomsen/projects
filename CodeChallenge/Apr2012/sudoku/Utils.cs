using System;
using System.Collections.Generic;
using Microsoft.SolverFoundation.Services;

namespace sudoku
{
    public static class Utils
    {

        static private List<int> randomIntegers = new List<int>();
        static private Random random = new Random();

        /* This method will return a list of unique random integers.
         * The minValue & maxValue will be used as the range.
         * count is the amount of intergers that will be returned. */
        public static List<int> GetUniqueRandomIntegers(int minValue, int maxValue, int count)
        {
            /* Check that the input parameters are valid */
            if (((maxValue - minValue) - 1) < count)
            {
                return null;
            }

            Random random = new Random();
            while (randomIntegers.Count <= count)
            {
                //0 81
                int next = random.Next(minValue, maxValue);
                if (!randomIntegers.Contains(next))
                {
                    randomIntegers.Add(next);
                }
            }
            return randomIntegers;
        }


        public static List<int> GetUniqueRandomIntegers(int minValue, int maxValue)
        {
            if (minValue >= maxValue)
            {
                return null;
            }
            return GetUniqueRandomIntegers(minValue, maxValue, maxValue - minValue - 1);
        }


        /*        public static List<int> getFourtySixRandomIntegers()
                {
                    Random random = new Random();

                    List<int> randoms = new List<int>();

                    while (randoms.Count < 46)
                    {
                        int next = random.Next(0, 81);
                        if (!randoms.Contains(next))
                        {
                            randoms.Add(next);
                        }
                    }

                    return randoms;
                }
                */

        /*
        public static List<int> getNineRandomIntegers()
        {
            Random random = new Random();


            while (randomIntegers.Count <= 8)
            {
                int next = random.Next(1, 10);
                if (!randomIntegers.Contains(next))
                {
                    randomIntegers.Add(next);
                }
            }

            return randomIntegers;
        }*/





    }
}
