using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class SuperRingItemSprite : ISprite
    {
        private Texture2D itemSpriteSheet;
        private Rectangle destRectangle;
        private Rectangle superRingRectangle;

        public SuperRingItemSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            superRingRectangle = ItemUtility.SuperRingItemSpriteRectangle;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, superRingRectangle.Width, superRingRectangle.Height);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, superRingRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return new Rectangle(); }
    }
}
