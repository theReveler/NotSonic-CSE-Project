using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    public class Cannon : IEnemy
    {
        public IEnemyState State { get; set; }
        public Vector2 Position { get; set; }

        public Cannon(Vector2 position)
        {
            Position = position;
            State = new LeftAttackCannonState(this);
        }
        public Rectangle BoundingBox()
        {
            return State.BoundingBox();
        }
        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void TakeDamage()
        {
            State.TakeDamage();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, Position);
        }

        public void Update()
        {
            State.Update();
        }

        public void Attack()
        {
            State.Attack();
        }

        public void Idle()
        {
            State.Idle();
        }
    }
}
