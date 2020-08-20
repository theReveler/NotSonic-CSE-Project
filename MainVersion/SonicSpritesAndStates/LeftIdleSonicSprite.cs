using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

//Only draws the idle sonic sprite

namespace NotSonicGame
{

    internal class LeftIdleSonicSprite : ISprite
    {
        private Texture2D SonicSpriteSheet{ get; set; }
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Sonic sonic;

        public LeftIdleSonicSprite(Sonic sonic)
        {
            SonicSpriteSheet = AssetStorage.SonicSpriteSheet;
            this.sonic = sonic;
            sourceRectangle = SonicUtility.LeftIdleRectangle;
            destinationRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, sourceRectangle.Width, sourceRectangle.Height);
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
            destinationRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, sourceRectangle.Width, sourceRectangle.Height);
            //not needed yet. needed when we animate the idle stance
            /*      currentFrame++;
                  if (currentFrame == totalFrames)
                      currentFrame = 0;*/
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle((int)sonic.Position.X + 5, (int)sonic.Position.Y + 5, 28, 39);
        }
    }
}