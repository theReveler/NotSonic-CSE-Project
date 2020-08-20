using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    class DeadCrabmeatSprite : IEnemySprite
    {
        private ISprite explosionSprite;
        private ISprite animalSprite;
        public DeadCrabmeatSprite(Vector2 position)
        {
            explosionSprite = new ExplosionSprite(position);
            animalSprite = new BunnySprite(position);
        }
        public Rectangle BoundingBox()
        {
            return new Rectangle();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            animalSprite.Draw(spriteBatch);
            explosionSprite.Draw(spriteBatch);
        }

        public void Update()
        {
            animalSprite.Update();
            explosionSprite.Update();
        }
    }
}
