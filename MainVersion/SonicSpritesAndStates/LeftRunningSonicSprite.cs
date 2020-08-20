using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Draws Sonic's left running sprite animation

namespace NotSonicGame
{
    internal class LeftRunningSonicSprite : ISprite
    {

        public Texture2D SonicSpriteSheet { get; set; }
        private int xLocation, yLocation;
        private int currentFrame;
        private int totalFrames;
        private int animationSpeed = 4;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private Sonic sonic;

        public LeftRunningSonicSprite(int tFrames, Sonic sonic)
        {
            this.sonic = sonic;
            SonicSpriteSheet = AssetStorage.SonicSpriteSheet;
            totalFrames = tFrames;
            currentFrame = animationSpeed;
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, 25, 38);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            xLocation = 540 - 45 * (currentFrame / animationSpeed);
            yLocation = 51;

            sourceRectangle = new Rectangle(xLocation, yLocation, 45, 50);
            destinationRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, 45, 50);

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

            //updates frames, controls speed, switches to other side of screen if you go off screen
            currentFrame++;
            if (currentFrame == totalFrames * animationSpeed)
                currentFrame = 0;
        }
    }
}