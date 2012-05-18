using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace toh
{
    public static class ScoreReader
    {
        private static string scores;

        public static string GetScores()
        {
            scores = "";
            ReadFile();
            return scores;
        }

        private static void ReadFile()
        {
            using (StreamReader reader = new StreamReader(Properties.Settings.Default.ScoreFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    scores += line + "\n";
                }
            }
        }
    }
}
