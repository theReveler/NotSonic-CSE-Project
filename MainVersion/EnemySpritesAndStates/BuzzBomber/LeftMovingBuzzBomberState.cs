using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class LeftMovingBuzzBomberState : IEnemyState
    {
        private BuzzBomber buzzbomber;
        private IEnemySprite sprite;
        private Vector2 partolingCenterPoint;

        public LeftMovingBuzzBomberState(BuzzBomber buzzbomber)
        {
            this.buzzbomber = buzzbomber;
            partolingCenterPoint = buzzbomber.PartolingCenterPoint;
            sprite = new LeftMovingBuzzBomberSprite();
        }
        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }
        public void Idle()
        {
            //buzzbomber.State = new
        }
        public void Attack()
        {
            buzzbomber.State = new LeftFacingAttackBuzzBomberState(buzzbomber);
        }

        public void ChangeDirection()
        {
            //buzzbomber.State = new RightMovingBuzzBomberState(buzzbomber);
            buzzbomber.State = new RightIdleBuzzBomberState(buzzbomber);
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
            buzzbomber.Position = new Vector2(buzzbomber.Position.X - MoveOneUnit, buzzbomber.Position.Y);
            if (partolingCenterPoint.X - buzzbomber.Position.X >= BuzzBomberPatrolDistance)
                ChangeDirection();
            sprite.Update();
        }
    }
}
