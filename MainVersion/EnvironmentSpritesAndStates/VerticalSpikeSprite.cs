using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class VerticalSpikeSprite : ISprite
    {    
        private Rectangle destRectangle;
        private Rectangle spikeRectangle;
        private Texture2D itemSpriteSheet;

        public VerticalSpikeSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            spikeRectangle = BlockUtility.VerticalSpikeRectangle;
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
