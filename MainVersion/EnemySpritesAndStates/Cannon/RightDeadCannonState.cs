using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    class RightDeadCannonState : IEnemyState, IDeadEnemyState
    {
        private IEnemySprite sprite;

        public RightDeadCannonState()
        {
            sprite = new RightDeadCannonSprite();
        }
        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }
        public void Idle()
        {

        }
        public void Attack()
        {
            //Can't attack when dead
        }

        public void ChangeDirection()
        {
            //Can't changeDirection when dead
        }

        public void TakeDamage()
        {
            //already dead
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update()
        {
            sprite.Update();
        }
    }
}
