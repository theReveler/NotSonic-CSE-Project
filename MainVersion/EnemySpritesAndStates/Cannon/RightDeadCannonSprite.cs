using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class RightDeadCannonSprite : IEnemySprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private Texture2D enemySpriteSheet;
        private Rectangle destinationRectangle;
        private int width = CannonWidth;
        private int height = CannonHeight;

        public RightDeadCannonSprite()
        {
            enemySpriteSheet = AssetStorage.EnemySpriteSheet;
            currentFrame = RightDeadCannonStartFrame;
            endFrame = RightDeadCannonEndFrame;
            updateDelayCounter = DelayCountStartValue;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle sourceRectangle = new Rectangle((int)RightDeadCannonSource.X + width * currentFrame, (int)RightDeadCannonSource.Y, width, height);
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
                if (currentFrame != endFrame)
                    currentFrame++;
            }
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle();
        }
    }
}
