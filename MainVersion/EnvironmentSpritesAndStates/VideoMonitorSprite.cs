using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class VideoMonitorSprite : ISprite
    {
        private Rectangle destRectangle;
        private Rectangle videoMonitorRectangle;
        private Texture2D itemSpriteSheet;

        private int currentFrame = 0;
        private int maxFrames = BlockUtility.VideoMonitorMaxFrames;

        public VideoMonitorSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            videoMonitorRectangle = BlockUtility.VideoMonitorFrameOne;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, videoMonitorRectangle.Width, videoMonitorRectangle.Height);
        }

        public void Update()
        {
            if (currentFrame == maxFrames)
                currentFrame = 0;
            else
                currentFrame++;

            if (currentFrame <= maxFrames * BlockUtility.GeneralBlockFrameTwoMultiplier)
                videoMonitorRectangle = BlockUtility.VideoMonitorFrameOne;
            else
                videoMonitorRectangle = BlockUtility.VideoMonitorFrameTwo;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, videoMonitorRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return destRectangle; }
    }
}
