using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class LeftFacingJumpingChopperState : IEnemyState
    {
        private Chopper chopper;
        private IEnemySprite sprite;
        private Vector2 partolingCenterPoint;
        private bool movingUp;

        public LeftFacingJumpingChopperState(Chopper chopper)
        {
            this.chopper = chopper;
            partolingCenterPoint = chopper.PartolingCenterPoint;
            movingUp = true;
            sprite = new LeftFacingJumpingChopperSprite();
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
            //chopper does not have an attack
        }
        public void ChangeDirection()
        {
            chopper.State = new RightFacingJumpingChopperState(chopper);
        }
        public void TakeDamage()
        {
            chopper.State = new DeadChopperState(chopper);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }
        public void Update()
        {
            if (movingUp)
                MoveUp();
            else
                MoveDown();
            sprite.Update();
        }
        private void MoveUp()
        {
            chopper.Position = new Vector2(chopper.Position.X, chopper.Position.Y - MoveOneUnit);
            if (partolingCenterPoint.Y - chopper.Position.Y >= ChopperPatrolDistance)
            {
                movingUp = false;
            }
        }
        private void MoveDown()
        {
            chopper.Position = new Vector2(chopper.Position.X, chopper.Position.Y + MoveOneUnit);
            if (chopper.Position.Y - partolingCenterPoint.Y >= ChopperPatrolDistance)
            {
                movingUp = true;
            }
        }
    }
}
