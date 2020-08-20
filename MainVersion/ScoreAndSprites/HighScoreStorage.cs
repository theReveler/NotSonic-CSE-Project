using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public static class HighScoreStorage
    {
        public static String[] GetHighScore()
        {
            string[] highScores = new String[100];
            if (File.Exists("C://HighScore.txt"))
                highScores = File.ReadAllLines("C://HighScore.txt");
            return highScores;
        }

        public static void WriteHighScores(string[] highScores)
        {
            File.WriteAllLines("C://HighScore.txt", highScores);
        }
    }
}
