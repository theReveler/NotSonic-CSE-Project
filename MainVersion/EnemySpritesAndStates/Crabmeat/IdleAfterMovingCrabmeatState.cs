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
    class IdleAfterMovingCrabmeatState :IEnemyState
    {
        private Crabmeat crabmeat;
        private IEnemySprite sprite;
        private Vector2 partolingCenterPoint;
        private int updateDelayCounter;

        public IdleAfterMovingCrabmeatState(Crabmeat crabmeat)
        {
            this.crabmeat = crabmeat;
            partolingCenterPoint = crabmeat.PartolingCenterPoint;
            updateDelayCounter = DelayCountStartValue;
            sprite = new IdleCrabmeatSprite();
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
            if (crabmeat.Position.X < partolingCenterPoint.X)
                crabmeat.State = new RightMovingCrabmeatState(crabmeat);
            else
                crabmeat.State = new LeftMovingCrabmeatState(crabmeat);
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
            if (updateDelayCounter % DelayTime50 == ZERO)
                crabmeat.Attack();
        }
    }
}
