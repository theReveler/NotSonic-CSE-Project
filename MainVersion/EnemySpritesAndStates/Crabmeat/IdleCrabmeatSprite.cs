using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class IdleCrabmeatSprite : IEnemySprite
    {
        private int frame;
        private int width = CrabmeatWidth;
        private int height = CrabmeatHeight;
        private Texture2D enemySpriteSheet;
        private Rectangle destinationRectangle;

        public IdleCrabmeatSprite()
        {
            enemySpriteSheet = AssetStorage.EnemySpriteSheet;
            frame = IdleCrabmeatFrame;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle sourceRectangle = new Rectangle(width * frame, CrabmeatSourceY, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(enemySpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            //Since Idle the sprite does not update
        }
        public Rectangle BoundingBox()
        {
            return new Rectangle(destinationRectangle.X, destinationRectangle.Y, width, height);
        }
    }
}
