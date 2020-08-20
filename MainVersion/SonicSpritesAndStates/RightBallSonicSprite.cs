using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

//Only draws the ball sonic sprite and updates the animation

namespace NotSonicGame
{
    internal class RightBallSonicSprite : ISprite
    {
        private Texture2D SonicSpriteSheet { get; set; }
        int xLocation, yLocation;
        private int totalFrames = 3;
        private int currentFrame;
        private int animationSpeed = 4;
        public Rectangle sourceRectangle;
        public Rectangle destinationRectangle;
        private Sonic sonic;
        public RightBallSonicSprite(Sonic sonic)
        {
            this.sonic = sonic;
            SonicSpriteSheet = AssetStorage.SonicSpriteSheet;
            currentFrame = animationSpeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            xLocation = 0 + 45 * (currentFrame / animationSpeed);
            yLocation = 150;

            sourceRectangle = new Rectangle(xLocation, yLocation, 45, 35);
            destinationRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, 45, 35);
            //spriteBatch.Begin();
            if (sonic.IsTinted == false)
            {
                spriteBatch.Draw(SonicSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(SonicSpriteSheet, destinationRectangle, sourceRectangle, Color.Red);
            }
            //spriteBatch.End();

        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames * animationSpeed)
                currentFrame = 0;
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, 25, 38);
        }
    }
}