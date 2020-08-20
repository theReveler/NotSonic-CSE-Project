﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

//Draws the left fast ball sonic sprite

namespace NotSonicGame
{
    internal class LeftFastBallSonicSprite : ISprite
    {
        public Texture2D SonicSpriteSheet { get; set; }
        public Rectangle sourceRectangle;
        public Rectangle destinationRectangle;
        private Sonic sonic;

        public LeftFastBallSonicSprite(Sonic sonic)
        {
            SonicSpriteSheet = AssetStorage.SonicSpriteSheet;
            this.sonic = sonic;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int xLocation, yLocation;

            xLocation = 448;
            yLocation = 150;

            //pulls the global position from Sonic.cs
            sourceRectangle = new Rectangle(xLocation, yLocation, 40, 40);
            destinationRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y + 5, 40, 40);

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
            //not needed yet. needed when we animate the idle stance
            /*      currentFrame++;
                  if (currentFrame == totalFrames)
                      currentFrame = 0;*/
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y, 25, 38);
        }
    }
}