using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public class ScoreControl
    {
        private static int scoreMultiplier = 0;
        private static int counter = 0;
        private static IGameObject score;

        private static List<IGameObject> scoreList = new List<IGameObject>();

        public void Update()
        {
            if (counter == 0)
                scoreMultiplier = 0;
            else
                counter--;

            int i = 0;
            while(i < scoreList.Count)
            {
                scoreList[i].Update();
                i++;
            }
        }

        public static void EnemyDefeated(Vector2 position)
        {
            score = new Score(position, scoreMultiplier);
            scoreList.Add(score);
            if (scoreMultiplier != ScoreUtility.ScoreMultiplierLimit)
            {
                scoreMultiplier++;
                counter = ScoreUtility.TimeStart;
            }
        }

        public static void GetEndRing(Vector2 position)
        {
            score = new Score(position, ScoreUtility.ScoreMultiplierLimit);
            scoreList.Add(score);
        }

        public static void RestartMulitplier()
        {
            scoreMultiplier = 0;
            counter = 0;
        }

        public static void RemoveFromScoreList(IGameObject obj) { scoreList.Remove(obj); }

        public void Draw(SpriteBatch spriteBatch)
        {
            int i = 0;
            while (i < scoreList.Count)
            {
                scoreList[i].Draw(spriteBatch);
                i++;
            }
        }
    }
}
