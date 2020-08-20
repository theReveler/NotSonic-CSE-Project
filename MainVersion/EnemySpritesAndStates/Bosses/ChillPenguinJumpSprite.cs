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
    class ChillPenguinJumpSprite : IBossSprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private Rectangle[] sourceRectangles = { new Rectangle(22, 4, 78, 74), new Rectangle(63, 89, 77, 73), new Rectangle(196, 12, 78, 66), new Rectangle(3, 207, 73, 77), new Rectangle(85, 201, 75, 77) };
        private Vector2[] offsets = { new Vector2(0, 18), new Vector2(1, 19), new Vector2(0, 26), new Vector2(0, 15), new Vector2(0, 15)};
        private Rectangle destinationRectangle;
        private SpriteEffects spriteEffect;
        public bool IsFacingLeft { get; set; }
        public bool InAir { get; set; }
        public ChillPenguinJumpSprite(bool isFacingLeft)
        {
            currentFrame = 0;
            endFrame = 4;
            updateDelayCounter = 0;
            IsFacingLeft = isFacingLeft;
            InAir = false;
            if (isFacingLeft)
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
                if (currentFrame != endFrame)
                    currentFrame++;
                else
                    InAir = true;
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
