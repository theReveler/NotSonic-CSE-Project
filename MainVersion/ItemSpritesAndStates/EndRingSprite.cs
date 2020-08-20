using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class EndRingSprite : ISprite
    {
        private int currentFrame = 0;
        private int maxFrames = ItemUtility.GeneralMaxFrames;
        private Rectangle[] endRingFrames = ItemUtility.GetEndRingFrames();

        private Rectangle destRectangle;
        //private Rectangle overlapDestRectangle;
        private Rectangle ringRectangle;
        //private Rectangle overlapRectangle;
        private Texture2D itemSpriteSheet;

        public EndRingSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            ringRectangle = endRingFrames[0];
            destRectangle = new Rectangle((int)position.X, (int)position.Y, ringRectangle.Width, ringRectangle.Height);
            //overlapRectangle = new Rectangle(11, 513, 32, 65);
            //overlapDestRectangle = new Rectangle(destRectangle.X + destRectangle.Width - 32, destRectangle.Y, 32, 65);
        }

        public void Update()
        {
            if (currentFrame == maxFrames)
                currentFrame = 0;
            else
                currentFrame++;

            if (currentFrame <= maxFrames * ItemUtility.GeneralItemFrameOneMultiplier)
            {
                ringRectangle = endRingFrames[0];
                //overlapRectangle = new Rectangle(0, 513, 49, 65);
                //overlapDestRectangle = new Rectangle(destRectangle.X + destRectangle.Width - overlapRectangle.Width, destRectangle.Y, overlapRectangle.Width, overlapRectangle.Height);
            }
            else if (currentFrame <= maxFrames * ItemUtility.GeneralItemFrameTwoMultiplier)
            {
                ringRectangle = endRingFrames[1];
                //overlapRectangle = new Rectangle(54, 513, 47, 65);
                //overlapDestRectangle = new Rectangle(destRectangle.X + destRectangle.Width - overlapRectangle.Width, destRectangle.Y, overlapRectangle.Width , overlapRectangle.Height);
            }
            else if (currentFrame <= maxFrames * ItemUtility.GeneralItemFrameThreeMultiplier)
            {
                ringRectangle = endRingFrames[2];
                //overlapRectangle = new Rectangle(119, 513, 52, 65);
                //overlapDestRectangle = new Rectangle(destRectangle.X + destRectangle.Width - overlapRectangle.Width, destRectangle.Y, overlapRectangle.Width, overlapRectangle.Height);
            }
            else
            {
                ringRectangle = endRingFrames[3];
                //overlapRectangle = new Rectangle(187, 513, 65, 65);
                //overlapDestRectangle = new Rectangle(destRectangle.X + destRectangle.Width - overlapRectangle.Width, destRectangle.Y, overlapRectangle.Width, overlapRectangle.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, ringRectangle, Color.White);
            //spriteBatch.Draw(itemSpriteSheet, overlapDestRectangle, overlapRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return destRectangle; }
    }
}