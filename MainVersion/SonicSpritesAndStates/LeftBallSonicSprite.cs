using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

//Only draws the ball sonic sprite and updates the animation

namespace NotSonicGame
{
    internal class LeftBallSonicSprite : ISprite
    {
        private Texture2D SonicSpriteSheet { get; set; }
        int xLocation, yLocation;
        private int totalFrames = 3;
        private int currentFrame;
        private int animationSpeed = 4;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Sonic sonic;

        public LeftBallSonicSprite(Sonic sonic)
        {
            this.sonic = sonic;
            SonicSpriteSheet = AssetStorage.SonicSpriteSheet;
            currentFrame = 0;
            currentFrame = animationSpeed;
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, 25, 38);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            xLocation = 540 - 45 * (currentFrame / animationSpeed);
            yLocation = 150;

            sourceRectangle = new Rectangle(xLocation, yLocation, 45, 35);
            destinationRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, 45, 35);
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
            if (currentFrame == totalFrames * animationSpeed)
                currentFrame = 0;
        }
    }
}