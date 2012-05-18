using System.IO;

namespace toh
{
    public static class ScoreWriter
    {
        public static void writeScore(Score score)
        {
            string[] stringArray = new string[] {score.ToString()};
            File.AppendAllLines(Properties.Settings.Default.ScoreFile, stringArray);
        }
    }
}