using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    class DeadSonicSprite : ISprite
    {
        public Texture2D SonicSpriteSheet { get; set; }
        public Rectangle sourceRectangle;
        public Rectangle destinationRectangle;
        private Sonic sonic;

        public DeadSonicSprite(Sonic sonic)
        {
            SonicSpriteSheet = AssetStorage.SonicSpriteSheet;
            this.sonic = sonic;
            sourceRectangle = SonicUtility.DeadRectangle;
            destinationRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, sourceRectangle.Width + SonicUtility.DeadOffset, sourceRectangle.Height + SonicUtility.DeadOffset);
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sonic.IsTinted == false)
            {
                spriteBatch.Draw(SonicSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(SonicSpriteSheet, destinationRectangle, sourceRectangle, Color.Red);
            }
        }

        public void Update()
        {
            destinationRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, 38, 43);
        }
    }
}
