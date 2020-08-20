using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public class Background : IGameObject
    {
        private Texture2D background;
        //public Texture2D last;
        //public Rectangle sourceLast;
        //public Rectangle destinationLast;
        private Rectangle sourceBack;
        private Rectangle destinationBack;

        private Rectangle sourceMid;
        private Rectangle destinationMid;

        private Rectangle sourceWater;
        private Rectangle destinationWater;

        private Rectangle sourceClouds;
        private Rectangle destinationClouds;

        private int fourCount; //this is for water, maybe more
        private int currentFrame;
        private int endFrame;
        private Camera currentCam;
        private int cloudDrift;

        public Background()
        {
            background = AssetStorage.BackgroundAssets;
           // last = Texture2DStorage.GetLast();
            fourCount = 0;
            currentFrame = 0;
            endFrame = 3;

        }

        public void ConnectCamera(Camera player)
        {
            currentCam = player;
        }

        public void DrawFragment(SpriteBatch spriteBatch, Rectangle source, Rectangle destination)
        {
            spriteBatch.Draw(background, destination, source, Color.White);
            destination.X += destination.Width;
            spriteBatch.Draw(background, destination, source, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            // spriteBatch.Begin();
            DrawFragment(spriteBatch, sourceBack, destinationBack);
            destinationBack.Y += 65;

            DrawFragment(spriteBatch, sourceBack, destinationBack);
            DrawFragment(spriteBatch, sourceClouds, destinationClouds);
            DrawFragment(spriteBatch, sourceWater, destinationWater);
            DrawFragment(spriteBatch, sourceMid, destinationMid);

            //spriteBatch.End();
        }

        public void Update()
        {
            fourCount++;
            cloudDrift++;
            if (fourCount == 80)
                fourCount = 0;
            if (cloudDrift == 8000)
                cloudDrift = 0;
            if (fourCount % 8 == 0)
            {
                if (currentFrame == endFrame)
                    currentFrame = 0;
                else
                    currentFrame++;
            }

            double playerRelativeX = currentCam.Position.X / 750;
            double playerRelativeY = currentCam.Position.Y / 525;

            int bParallaxX = (int)(-playerRelativeX * 300) % 1792 - 200 + (int)currentCam.Position.X;
            int mParallaxX = (int)(-playerRelativeX * 400) % 1792 - 150 + (int)currentCam.Position.X;
            int parallaxY = (int)(-playerRelativeY * 50);

            sourceBack = new Rectangle(0, 2176, 1792, 256);
            destinationBack = new Rectangle(bParallaxX, parallaxY - 5 + (int)currentCam.Position.Y, 1792, 255); //water is 224

            sourceClouds = new Rectangle(0, 2432, 1792, 255);
            destinationClouds = new Rectangle(bParallaxX - cloudDrift / 4 + 200, parallaxY + 60 + (int)currentCam.Position.Y, 1792, 255);

            sourceWater = new Rectangle(0, 1280 + 224 * currentFrame, 1792, 224);
            destinationWater = new Rectangle(mParallaxX, parallaxY + 75 + (int)currentCam.Position.Y, 1792, 256); //2176

            sourceMid = new Rectangle(0, 256 + 256 * currentFrame, 1792, 256);
            destinationMid = new Rectangle(mParallaxX, parallaxY + 60 + (int)currentCam.Position.Y, 1792, 256); //2176
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle(0, 0, 800, 600);
        }
    }
}
