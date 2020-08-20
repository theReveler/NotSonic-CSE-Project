using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class LeftMovingCrabmeatSprite : IEnemySprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private int width = CrabmeatWidth;
        private int height = CrabmeatHeight;
        private Texture2D enemySpriteSheet;
        private Rectangle destinationRectangle;

        public LeftMovingCrabmeatSprite()
        {
            enemySpriteSheet = AssetStorage.EnemySpriteSheet;
            currentFrame = LeftMovingCrabmeatStartFrame;
            endFrame = LeftMovingCrabmeatEndFrame;
            updateDelayCounter = DelayCountStartValue;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, CrabmeatSourceY, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(enemySpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (updateDelayCounter % DelayTime20 == ZERO)
            {
                if (currentFrame == endFrame)
                    currentFrame = LeftMovingCrabmeatResetFrame;
                else
                    currentFrame--;
            }
        }
        public Rectangle BoundingBox()
        {
            return new Rectangle(destinationRectangle.X, destinationRectangle.Y, width, height);
        }
    }
}
