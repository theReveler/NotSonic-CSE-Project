using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class ExplosionSprite : ISprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private Texture2D spriteSheet;
        private Vector2 position;
        private Rectangle destinationRectangle;

        public ExplosionSprite(Vector2 position)
        {
            this.spriteSheet = AssetStorage.EnemySpriteSheet;
            this.position = position;
            currentFrame = ExplosionStartFrame;
            endFrame = ExplosionEndFrame;
            updateDelayCounter = DelayCountStartValue;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = ExplosionWidth;
            int height = ExplosionHeight;
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, ExplosionSourceY, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (updateDelayCounter % DelayTimeFive == ZERO)
            {
                if (currentFrame <= endFrame)
                    currentFrame++;
            }
        }

        public Rectangle BoundingBox()
        {
            return destinationRectangle;
        }
    }
}
