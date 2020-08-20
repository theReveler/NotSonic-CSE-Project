using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame.SonicSpritesAndStates
{
    class RightStunnedSonicSprite : ISprite
    {
        private Texture2D SonicSpriteSheet { get; set; }
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Sonic sonic;

        public RightStunnedSonicSprite(Sonic sonic)
        {
            this.sonic = sonic;
            SonicSpriteSheet = AssetStorage.SonicSpriteSheet;
            sourceRectangle = new Rectangle(352, 5, 40, 35);
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

