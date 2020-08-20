using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class LeftMovingMotoBugState : IEnemyState
    {
        private MotoBug motobug;
        private IEnemySprite sprite;
        private Vector2 partolingCenterPoint;

        public LeftMovingMotoBugState(MotoBug motobug)
        {
            this.motobug = motobug;
            partolingCenterPoint = motobug.PartolingCenterPoint;
            sprite = new LeftMovingMotoBugSprite();
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
            motobug.State = new RightMovingMotoBugState(motobug);
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
            motobug.Position = new Vector2(motobug.Position.X - MoveOneUnit, motobug.Position.Y);
            if (partolingCenterPoint.X - motobug.Position.X >= MotoBugPatrolDistance)
                ChangeDirection();
            sprite.Update();
        }
    }
}
