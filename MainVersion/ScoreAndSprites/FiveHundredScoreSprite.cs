using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class FiveHundredScoreSprite : ISprite
    {
        private Rectangle scoreRectangle;
        private Rectangle destRectangle;
        private Texture2D spriteSheet;

        public FiveHundredScoreSprite(Vector2 position)
        {
            spriteSheet = AssetStorage.ItemObjectSpriteSheet;
            scoreRectangle = ScoreUtility.FiveHundredRectangle;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, scoreRectangle.Width, scoreRectangle.Height);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch) { spriteBatch.Draw(spriteSheet, destRectangle, scoreRectangle, Color.White); }

        public Rectangle BoundingBox() { return destRectangle; }
    }
}
