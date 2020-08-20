using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.AssetStorage;

namespace NotSonicGame
{
    class ChillPenguinFallingSprite : IEnemySprite
    {
        private Rectangle sourceRectangle = new Rectangle(502, 202, 72, 90);
        private Rectangle destinationRectangle;
        private SpriteEffects spriteEffect;
        public bool IsFacingLeft { get; set; }

        public ChillPenguinFallingSprite(bool isFacingLeft)
        {
            IsFacingLeft = true;
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
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width, sourceRectangle.Height);
            spriteBatch.Draw(BossSpriteSheet, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), spriteEffect, 0f);
        }

        public void Update()
        {
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
