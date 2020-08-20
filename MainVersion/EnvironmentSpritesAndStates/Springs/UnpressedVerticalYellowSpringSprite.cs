﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class UnpressedVerticalYellowSpringSprite : ISprite
    {
        private Texture2D itemSpriteSheet;
        private Rectangle destRectangle;
        private Rectangle springRectangle;

        public UnpressedVerticalYellowSpringSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            springRectangle = BlockUtility.GetYellowLeftFacingFrames()[0];
            destRectangle = new Rectangle((int)position.X, (int)position.Y, springRectangle.Width, springRectangle.Height);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, springRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return destRectangle; }
    }
}
