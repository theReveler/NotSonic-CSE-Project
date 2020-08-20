using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class PickedUpEndRingSprite : ISprite
    {
        private Rectangle destRectangle;
        private Rectangle ringRectangle;
        private Texture2D itemSpriteSheet;
        private Rectangle[] pickedUpFrames = ItemUtility.GetPickedUpEndRingFrames();

        private int currentFrame = 0;
        private int maxFrames = ItemUtility.GeneralMaxFrames;

        public PickedUpEndRingSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            ringRectangle = pickedUpFrames[0];
            destRectangle = new Rectangle((int)position.X, (int)position.Y, ringRectangle.Width, ringRectangle.Height);
        }

        public void Update()
        {
            if (currentFrame >= maxFrames)
            {
                ringRectangle = new Rectangle();
            }
            else if (currentFrame <= maxFrames * ItemUtility.GeneralItemFrameOneMultiplier)
            {
                ringRectangle = pickedUpFrames[0];
                currentFrame++;
            }
            else if (currentFrame <= maxFrames * ItemUtility.GeneralItemFrameTwoMultiplier)
            {
                ringRectangle = pickedUpFrames[1];
                currentFrame++;
            }
            else if (currentFrame <= maxFrames * ItemUtility.GeneralItemFrameThreeMultiplier)
            {
                ringRectangle = pickedUpFrames[2];
                currentFrame++;
            }
            else if (currentFrame <= maxFrames)
            {
                ringRectangle = pickedUpFrames[3];
                currentFrame++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, ringRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return new Rectangle(); }
    }
}
