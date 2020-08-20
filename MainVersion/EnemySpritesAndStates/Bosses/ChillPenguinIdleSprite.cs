using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;
using static NotSonicGame.AssetStorage;

namespace NotSonicGame
{
    class ChillPenguinIdleSprite : IBossSprite
    {
        private Rectangle[] sourceRectangles = { new Rectangle(22, 4, 78, 74), new Rectangle(63, 89, 77, 73) };
        private Vector2[] offsets = { new Vector2(0, 16), new Vector2(1, 17) };
        private Rectangle destinationRectangle;
        private SpriteEffects spriteEffect;
        private int updateDelayCounter;
        private int currentFrame;
        private int endFrame;
        public bool ReadyToAttack { get; set; }
        public bool IsFacingLeft { get; set; }
        public ChillPenguinIdleSprite(bool isFacingLeft)
        {
            currentFrame = 0;
            endFrame = 1;
            updateDelayCounter = 0;
            IsFacingLeft = isFacingLeft;
            if (isFacingLeft)
                spriteEffect = SpriteEffects.None;
            else
                spriteEffect = SpriteEffects.FlipHorizontally;
            ReadyToAttack = false;
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
            if (updateDelayCounter % 50 == ZERO)
            {
                if (currentFrame == endFrame && !ReadyToAttack)
                    ReadyToAttack = true;
                else if(currentFrame != endFrame)
                    currentFrame++;
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
