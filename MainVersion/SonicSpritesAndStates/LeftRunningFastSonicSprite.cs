using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame.SonicSpritesAndStates
{
    class LeftRunningFastSonicSprite : ISprite
    {
        private Texture2D SonicSpriteSheet { get; set; }
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Sonic sonic;
        private int currentFrame;
        private int totalFrames;

        public LeftRunningFastSonicSprite(Sonic sonic)
        {
            SonicSpriteSheet = AssetStorage.SonicSpriteSheet;
            this.sonic = sonic;
            currentFrame = 0;
            totalFrames = 4;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //pulls the global position from Sonic.cs
            sourceRectangle = new Rectangle(540-currentFrame*45, 105, 45, 50);
            destinationRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, 45, 50);
           
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
            
                 currentFrame++;
                  if (currentFrame == totalFrames)
                      currentFrame = 0;
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle((int)sonic.Position.X + 5, (int)sonic.Position.Y + 5, 28, 39);
        }
    }
}
