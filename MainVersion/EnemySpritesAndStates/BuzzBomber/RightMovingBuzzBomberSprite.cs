using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class RightMovingBuzzBomberSprite : IEnemySprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private int width = BuzzBomberSpriteWidth;
        private int height = BuzzBomberSpriteHeight;
        private Texture2D enemySpriteSheet;
        private Rectangle destinationRectangle;
        public RightMovingBuzzBomberSprite()
        {
            enemySpriteSheet = AssetStorage.EnemySpriteSheet;
            currentFrame = RightMovingBuzzBomberStartFrame;
            endFrame = RightMovingBuzzBomberEndFrame;
            updateDelayCounter = DelayCountStartValue;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, BuzzBomberSpriteSourceY, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(enemySpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (updateDelayCounter % DelayTimeFive == ZERO)
            {
                if (currentFrame == endFrame)
                    currentFrame = RightMovingBuzzBomberStartFrame;
                else
                    currentFrame++;
            }
        }
        public Rectangle BoundingBox()
        {
            return new Rectangle(destinationRectangle.X, destinationRectangle.Y, width, height);
        }
    }
}
