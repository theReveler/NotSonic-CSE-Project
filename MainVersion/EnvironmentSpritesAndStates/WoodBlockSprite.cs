using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    class WoodBlockSprite : ISprite
    {
        
        private Texture2D blockSpriteSheet;
        private Rectangle blockRectangle;
        private Rectangle destRectangle;

        public WoodBlockSprite(Vector2 position)
        {
            blockSpriteSheet = AssetStorage.BlockSpriteSheet;
            blockRectangle = BlockUtility.WoodenBlockRectangle;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, blockRectangle.Width, blockRectangle.Height);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockSpriteSheet, destRectangle, blockRectangle, Color.White);                    
        }

        public Rectangle BoundingBox() {
            return destRectangle;
        }
    }
}
