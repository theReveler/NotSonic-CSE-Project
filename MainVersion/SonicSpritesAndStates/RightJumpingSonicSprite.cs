using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Draws Sonic's right jumping sprite

namespace NotSonicGame
{
    internal class RightJumpingSonicSprite : ISprite
    {
        private Texture2D SonicSpriteSheet;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Sonic sonic;
        public RightJumpingSonicSprite(Sonic sonic)
        {
            this.sonic = sonic;
            SonicSpriteSheet = AssetStorage.SonicSpriteSheet;
            sourceRectangle = SonicUtility.RightJumpingRectagle;
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
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, 25, 38);
        }
    }
}
