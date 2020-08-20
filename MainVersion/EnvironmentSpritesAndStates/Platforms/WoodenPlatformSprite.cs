using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    class WoodenPlatformSprite : IPlatformSprite
    {
        private Texture2D spriteSheet;
        private Rectangle destinationRectangle;
        private Rectangle sourceRectangle;
        private Vector2 position;

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public WoodenPlatformSprite(Vector2 position)
        {
            spriteSheet = AssetStorage.MoreTerrain;
            this.position = position;
            sourceRectangle = BlockUtility.WoodenPlatformRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, sourceRectangle.Width, sourceRectangle.Height);
        }

        public Rectangle BoundingBox()
        {
            return destinationRectangle;
        }
    }
}
