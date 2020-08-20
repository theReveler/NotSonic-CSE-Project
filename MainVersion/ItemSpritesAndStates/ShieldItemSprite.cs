using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class ShieldItemSprite : ISprite
    {
        private Texture2D itemSpriteSheet;
        private Rectangle destRectangle;
        private Rectangle shieldRectangle;

        public ShieldItemSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            shieldRectangle = ItemUtility.ShieldItemSpriteRectangle;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, shieldRectangle.Width, shieldRectangle.Height);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, shieldRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return new Rectangle(); }
    }
}
