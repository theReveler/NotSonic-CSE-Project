using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class InvincibleItemSprite : ISprite
    {
        private Texture2D itemSpriteSheet;
        private Rectangle destRectangle;
        private Rectangle invincibleRectangle;

        public InvincibleItemSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            invincibleRectangle = ItemUtility.InvincibleItemSpriteRectangle;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, invincibleRectangle.Width, invincibleRectangle.Height);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, invincibleRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return destRectangle; }
    }
}
