﻿using System;
using System.Collections.Generic;
using Microsoft.SolverFoundation.Services;

namespace sudoku
{
    public static class Utils
    {

        
        

        /* This method will return a list of unique random integers.
         * The minValue & maxValue will be used as the range.
         * count is the amount of random intergers that will be returned. */

        public static List<int> GetUniqueRandomIntegers(int minValue, int maxValue, int count)
        {
        
            List<int> randomIntegers = new List<int>();

            /* Check that the input parameters are valid */
            if (((maxValue - minValue) - 1) < count)
            {
                return null;
            }

            Random random = new Random();
            while (randomIntegers.Count <= count)
            {
                int next = random.Next(minValue, maxValue);
                if (!randomIntegers.Contains(next))
                {
                    randomIntegers.Add(next);
                }
            }
            return randomIntegers;
        }

        /*public static List<int> GetUniqueRandomIntegers(int minValue, int maxValue)
        {
            if (minValue >= maxValue)
            {
                return null;
            }
            return GetUniqueRandomIntegers(minValue, maxValue, maxValue - minValue - 1);
        }*/

    }
}
