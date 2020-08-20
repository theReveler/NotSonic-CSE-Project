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
    public class RightIdleBuzzBomberSpirte : IEnemySprite
    {
        private int frame;
        private int width = BuzzBomberSpriteWidth;
        private int height = BuzzBomberSpriteHeight;
        private Texture2D enemySpriteSheet;
        private Rectangle destinationRectangle;

        public RightIdleBuzzBomberSpirte()
        {
            enemySpriteSheet = AssetStorage.EnemySpriteSheet;
            frame = RightIdleBuzzBomberStartFrame;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle sourceRectangle = new Rectangle(width * frame, BuzzBomberSpriteSourceY, width, height);
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
