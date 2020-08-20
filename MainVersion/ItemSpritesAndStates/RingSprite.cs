using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class RingSprite : ISprite
    {
        private int currentFrame = 0;
        private int maxFrames = ItemUtility.GeneralMaxFrames;

        private Rectangle destRectangle;
        private Rectangle ringRectangle;
        private Texture2D itemSpriteSheet;

        private Vector2 position;
        private IRing ring;
        private Rectangle[] ringFrames = ItemUtility.GetRingFrames();

        public RingSprite(IRing ring)
        {
            this.ring = ring;
            position = ring.Position;
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            ringRectangle = ringFrames[0];
            destRectangle = new Rectangle((int)position.X, (int)position.Y, ringRectangle.Width, ringRectangle.Height);
        }

        public void Update()
        {
            if (currentFrame == maxFrames)
                currentFrame = 0;
            else
                currentFrame++;

            if (currentFrame <= maxFrames * ItemUtility.GeneralItemFrameOneMultiplier)
                ringRectangle = ringFrames[0];
            else if (currentFrame <= maxFrames * ItemUtility.GeneralItemFrameTwoMultiplier)
                ringRectangle = ringFrames[1];
            else if (currentFrame <= maxFrames * ItemUtility.GeneralItemFrameThreeMultiplier)
                ringRectangle = ringFrames[2];
            else
                ringRectangle = ringFrames[3];

            position = ring.Position;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, ringRectangle.Width, ringRectangle.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, ringRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return destRectangle; }
    }
}
