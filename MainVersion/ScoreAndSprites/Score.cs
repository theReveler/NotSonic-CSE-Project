using Sprint0.GameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    class Score : IGameObject
    {
        private ISprite scoreSprite;

        private int counter;

        public Score(Vector2 position, int scoreIndex)
        {
            if (scoreIndex <= ScoreUtility.TierOne)
            {
                scoreSprite = new OneHundredScoreSprite(position);
                HUD.Score += ScoreUtility.ScoreTierOne;
            }
            else if (scoreIndex <= ScoreUtility.TierTwo)
            {
                scoreSprite = new TwoHundredFiftyScoreSprite(position);
                HUD.Score += ScoreUtility.ScoreTierTwo;
            }
            else if (scoreIndex <= ScoreUtility.TierThree)
            {
                scoreSprite = new FiveHundredScoreSprite(position);
                HUD.Score += ScoreUtility.ScoreTierThree;
            }
            else if (scoreIndex <= ScoreUtility.TierFour)
            {
                scoreSprite = new OneThousandScoreSprite(position);
                HUD.Score += ScoreUtility.ScoreTierFour;
            }
            else
            {
                scoreSprite = new OneHundredScoreSprite(position);
                HUD.Score += ScoreUtility.ScoreTierOne;
            }

            counter = ScoreUtility.ScoreTimer;
        }

        public void Draw(SpriteBatch spriteBatch) { scoreSprite.Draw(spriteBatch); }
        public void Update()
        {
            if (counter == 0)
                ScoreControl.RemoveFromScoreList(this);
            else
                counter--;
        }

        public Rectangle BoundingBox() { return scoreSprite.BoundingBox(); }
    }
}
