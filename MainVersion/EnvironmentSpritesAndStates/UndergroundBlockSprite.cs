using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class UndergroundBlockSprite : ISprite
    {

        private Texture2D blockSpriteSheet;
        private Rectangle blockRectangle;
        private Rectangle destRectangle;

        public UndergroundBlockSprite(Vector2 position)
        {
            blockSpriteSheet = AssetStorage.BlockSpriteSheet;
            blockRectangle = BlockUtility.UndergroundBlockRectangle;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, blockRectangle.Width, blockRectangle.Height);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockSpriteSheet, destRectangle, blockRectangle, Color.White);
        }

        public Rectangle BoundingBox()
        {
            return destRectangle;
        }
    }
}