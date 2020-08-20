using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class PressedHorizontalRedSpringSprite : ISprite
    {
        private Texture2D itemSpriteSheet;
        private Rectangle destRectangle;
        private Rectangle springRectangle;
        private Rectangle[] yellowHorizontalFrames = BlockUtility.GetYellowUpFacingFrames();

        private int currentFrame = 0;
        private int maxFrames = BlockUtility.SpringMaxFrames;
        private int x;
        private int y;


        public PressedHorizontalRedSpringSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            x = (int)position.X;
            y = (int)position.Y;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame <= maxFrames * BlockUtility.GeneralBlockFrameTwoMultiplier)
            {
                springRectangle = yellowHorizontalFrames[1];
                destRectangle = new Rectangle(x, y + BlockUtility.SpringFrameTwoOffset, springRectangle.Width, springRectangle.Height);
            }
            else if (currentFrame <= maxFrames)
            {
                springRectangle = yellowHorizontalFrames[2];
                destRectangle = new Rectangle(x, y + BlockUtility.SpringFrameThreeOffset, springRectangle.Width, springRectangle.Height);
            }
            else
            {
                springRectangle = yellowHorizontalFrames[0];
                destRectangle = new Rectangle(x, y, springRectangle.Width, springRectangle.Height);
                currentFrame = 0;
            }

            springRectangle.Y += BlockUtility.SpringColorOffset;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, springRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return destRectangle; }
    }
}
