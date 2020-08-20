using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class RightMovingBuzzBomberState : IEnemyState
    {
        private BuzzBomber buzzbomber;
        private IEnemySprite sprite;
        private Vector2 partolingCenterPoint;
        public RightMovingBuzzBomberState(BuzzBomber buzzbomber)
        {
            this.buzzbomber = buzzbomber;
            partolingCenterPoint = buzzbomber.PartolingCenterPoint;
            sprite = new RightMovingBuzzBomberSprite();
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
            buzzbomber.State = new RightFacingAttackBuzzBomberState(buzzbomber);
        }

        public void ChangeDirection()
        {
            buzzbomber.State = new LeftIdleBuzzBomberState(buzzbomber);
        }

        public void TakeDamage()
        {
            buzzbomber.State = new DeadBuzzBomberState(buzzbomber);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update()
        {
            buzzbomber.Position = new Vector2(buzzbomber.Position.X + MoveOneUnit, buzzbomber.Position.Y);
            if (buzzbomber.Position.X - partolingCenterPoint.X >= BuzzBomberPatrolDistance)
                ChangeDirection();
            sprite.Update();
        }
    }
}
