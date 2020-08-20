using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    public class MotoBug : IEnemy
    {
        public IEnemyState State { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PartolingCenterPoint { get; set; }

        public MotoBug(Vector2 position)
        {
            PartolingCenterPoint = position;
            Position = position;
            State = new LeftMovingMotoBugState(this);
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
    }
}
