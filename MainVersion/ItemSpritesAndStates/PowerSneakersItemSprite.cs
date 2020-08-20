using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class PowerSneakersItemSprite : ISprite
    {
        private Texture2D itemSpriteSheet;
        private Rectangle destRectangle;
        private Rectangle powerSneakersRectangle;

        public PowerSneakersItemSprite(Vector2 position)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            powerSneakersRectangle = ItemUtility.PowerSneakerItemSpriteRectangle;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, powerSneakersRectangle.Width, powerSneakersRectangle.Height);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, powerSneakersRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return new Rectangle(); }
    }
}
