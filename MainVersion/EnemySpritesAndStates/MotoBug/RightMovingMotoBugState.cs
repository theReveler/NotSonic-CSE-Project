using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class RightMovingMotoBugState : IEnemyState
    {
        private MotoBug motobug;
        private IEnemySprite sprite;
        private Vector2 partolingCenterPoint;

        public RightMovingMotoBugState(MotoBug motobug)
        {
            this.motobug = motobug;
            partolingCenterPoint = motobug.PartolingCenterPoint;
            sprite = new RightMovingMotoBugSprite();
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
            //motobugs do not have an attack
        }

        public void ChangeDirection()
        {
            motobug.State = new LeftMovingMotoBugState(motobug);
        }

        public void TakeDamage()
        {
            motobug.State = new DeadMotoBugState(motobug);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update()
        {
            motobug.Position = new Vector2(motobug.Position.X + MoveOneUnit, motobug.Position.Y);
            if (motobug.Position.X - partolingCenterPoint.X >= MotoBugPatrolDistance)
                ChangeDirection();
            sprite.Update();
        }
    }
}
