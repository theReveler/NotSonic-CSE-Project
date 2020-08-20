using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class LeftFacingJumpingChopperSprite : IEnemySprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private Texture2D enemySpriteSheet;
        private Rectangle destinationRectangle;

        public LeftFacingJumpingChopperSprite()
        {
            enemySpriteSheet = AssetStorage.EnemySpriteSheet;
            currentFrame = LeftJumpingChopperStartFrame;
            endFrame = LeftJumpingChopperEndFrame;
            updateDelayCounter = DelayCountStartValue;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = ChopperWidth;
            int height = ChopperHeight;
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, ChopperSourceY, width, height);
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
                    currentFrame = LeftJumpingChopperStartFrame;
                else
                    currentFrame++;
            }
        }
        public Rectangle BoundingBox()
        {
            return destinationRectangle;
        }
    }
}
