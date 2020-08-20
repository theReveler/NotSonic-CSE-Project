using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class HorizontalSpikeSprite :ISprite
    {
        private Texture2D itemSpriteSheet;
        private Rectangle destRectangle;
        private Rectangle spikeRectangle;

        public HorizontalSpikeSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            spikeRectangle = BlockUtility.HorizontalSpikeRectangle;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, spikeRectangle.Width, spikeRectangle.Height);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, spikeRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return destRectangle; }
    }
}