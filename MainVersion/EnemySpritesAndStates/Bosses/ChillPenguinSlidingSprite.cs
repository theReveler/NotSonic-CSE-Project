using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.AssetStorage;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class ChillPenguinSlidingSprite : IBossSprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private Rectangle[] sourceRectangles = { new Rectangle(287, 3, 85, 75), new Rectangle(337, 93, 75, 69), new Rectangle(439, 103, 81, 59) };
        private Vector2[] offsets = { new Vector2(0, 15), new Vector2(0, 20), new Vector2(0, 31) };
        private Rectangle destinationRectangle;
        private bool isSlideACrossFloor;
        private SpriteEffects spriteEffect;
        public bool IsSlideACrossFloor { get { return isSlideACrossFloor; } } 
        public bool IsFacingLeft { get; set; }

        public ChillPenguinSlidingSprite(bool isFacingLeft)
        {
            currentFrame = 0;
            endFrame = 2;
            updateDelayCounter = 0;
            isSlideACrossFloor = false;
            IsFacingLeft = isFacingLeft;
            if(isFacingLeft)
                spriteEffect = SpriteEffects.None;
            else
                spriteEffect = SpriteEffects.FlipHorizontally;
        }
        public Rectangle BoundingBox()
        {
            return destinationRectangle;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            destinationRectangle = new Rectangle((int)position.X + (int)offsets[currentFrame].X, (int)position.Y + (int)offsets[currentFrame].Y, sourceRectangles[currentFrame].Width, sourceRectangles[currentFrame].Height);
            spriteBatch.Draw(BossSpriteSheet, destinationRectangle, sourceRectangles[currentFrame], Color.White, 0, new Vector2(0, 0), spriteEffect, 0f);
        }

        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (updateDelayCounter % 10 == ZERO)
            {
                if (currentFrame == endFrame)
                    isSlideACrossFloor = true;
                else
                {
                    currentFrame++;
                }
            }
            if (IsFacingLeft)
            {
                spriteEffect = SpriteEffects.None;
            }
            else
            {
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
        }
    }
}
