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
    class RightMovingCrabmeatState : IEnemyState
    {
        private int updateDelayCounter;
        private Crabmeat crabmeat;
        private IEnemySprite sprite;
        private Vector2 partolingCenterPoint;

        public RightMovingCrabmeatState(Crabmeat crabmeat)
        {
            this.crabmeat = crabmeat;
            updateDelayCounter = DelayCountStartValue;
            partolingCenterPoint = crabmeat.PartolingCenterPoint;
            sprite = new RightMovingCrabmeatSprite();
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
            crabmeat.State = new AttackCrabmeatState(crabmeat);
        }

        public void ChangeDirection()
        {
            crabmeat.State = new IdleAfterMovingCrabmeatState(crabmeat);
        }

        public void TakeDamage()
        {
            crabmeat.State = new DeadCrabmeatState(crabmeat);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if(updateDelayCounter % DelayTime20 == ZERO)
                crabmeat.Position= new Vector2(crabmeat.Position.X + MoveOneUnit, crabmeat.Position.Y);
            if (crabmeat.Position.X - partolingCenterPoint.X >= CrabmeatPatrolDistance)
                ChangeDirection();
            sprite.Update();
        }
    }
}
