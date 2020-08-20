using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class LeftIdleCannonSprite : ISprite
    {
        private int width = IdleCannonWidth;
        private int height = IdleCannonHeight;
        private Texture2D enemySpriteSheet;
        private Rectangle destinationRectangle;
        private Vector2 position;

        public LeftIdleCannonSprite(Vector2 position)
        {
            enemySpriteSheet = AssetStorage.EnemySpriteSheet;
            this.position = position;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(LeftIdleCannonSourceX, LeftIdleCannonSourceY, width, height);
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
