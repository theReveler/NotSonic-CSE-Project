using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class LeftMovingMotoBugSprite : IEnemySprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private Texture2D enemySpriteSheet;
        private Rectangle destinationRectangle;
        private int width = MotoBugWidth;
        private int height = MotoBugHeight;
        
        public LeftMovingMotoBugSprite()
        {
            enemySpriteSheet = AssetStorage.EnemySpriteSheet;
            currentFrame = LeftMovingMotoBugStartFrame;
            endFrame = LeftMovingMotoBugEndFrame;
            updateDelayCounter = DelayCountStartValue;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, MotoBugSourceY, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(enemySpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (updateDelayCounter % DelayTimeTen == ZERO)
            {
                if (currentFrame == endFrame)
                    currentFrame = DelayCountStartValue;
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
