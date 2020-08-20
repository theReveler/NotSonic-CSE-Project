using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class DestroyedVideoMonitorSprite : ISprite
    {
        private Rectangle videoMonitorDestinationRectangle;
        private Rectangle videoMonitorRectangle;
        private Rectangle explosionRectangle;
        private Rectangle explosionDestinationRectangle;

        private Texture2D itemSpriteSheet;
        private int x;
        private int y;

        private int currentFrame = 0;
        private int maxFrames = BlockUtility.GeneralMaxFrames;
        private int[] frameChanges = BlockUtility.GetDestroyedMonitorFrameChanges();
        private int[] explosionXOffset = BlockUtility.GetExplosionXOffset();
        private int[] explosionYOffset = BlockUtility.GetExplosionYOffset();
        private Rectangle[] explosionFrames = BlockUtility.GetExplosionFrameRectangles();



        public DestroyedVideoMonitorSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            x = (int)position.X;
            y = (int)position.Y;
            videoMonitorRectangle = BlockUtility.VideoMonitorFrameOne;
            videoMonitorDestinationRectangle = new Rectangle(x, y, videoMonitorRectangle.Width, videoMonitorRectangle.Height);
        }

        public void Update()
        {
            if (currentFrame != maxFrames)
                currentFrame++;

            //Exploding Animation
            if (currentFrame == frameChanges[0])
            {
                explosionRectangle = explosionFrames[0];
                explosionDestinationRectangle = new Rectangle(x + explosionXOffset[0], y + explosionYOffset[0], explosionRectangle.Width, explosionRectangle.Height);
            }
            else if (currentFrame == frameChanges[1])
            {
                explosionRectangle = explosionFrames[1];
                explosionDestinationRectangle = new Rectangle(x + explosionXOffset[1], y + explosionYOffset[1], explosionRectangle.Width, explosionRectangle.Height);
            }
            else if (currentFrame == frameChanges[2])
            {
                videoMonitorRectangle = BlockUtility.DestroyedMonitorRectangle;
                videoMonitorDestinationRectangle = new Rectangle(x, y + BlockUtility.DestroyedMonitorYOffset, videoMonitorRectangle.Width, videoMonitorRectangle.Height);
            }
            else if (currentFrame == frameChanges[3])
            {
                explosionRectangle = explosionFrames[2];
                explosionDestinationRectangle = new Rectangle(x + explosionXOffset[2], y + explosionYOffset[2], explosionRectangle.Width, explosionRectangle.Height);
            }
            else if (currentFrame == frameChanges[4])
            {
                explosionRectangle = explosionFrames[3];
                explosionDestinationRectangle = new Rectangle(x + explosionXOffset[3], y + explosionYOffset[3], explosionRectangle.Width, explosionRectangle.Height);
            }
            else if (currentFrame == frameChanges[5])
            {
                explosionRectangle = explosionFrames[4];
                explosionDestinationRectangle = new Rectangle(x + explosionXOffset[4], y + explosionYOffset[4], explosionRectangle.Width, explosionRectangle.Height);
            }
            else if (currentFrame == maxFrames)
            {
                explosionDestinationRectangle = new Rectangle();
                explosionRectangle = new Rectangle();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, videoMonitorDestinationRectangle, videoMonitorRectangle, Color.White);
            spriteBatch.Draw(itemSpriteSheet, explosionDestinationRectangle, explosionRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return new Rectangle(); }
    }
}
