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
    class LeftIdleBuzzBomberState : IEnemyState
    {
        private BuzzBomber buzzbomber;
        private IEnemySprite sprite;
        private int updateDelayCounter;
        public LeftIdleBuzzBomberState(BuzzBomber buzzbomber)
        {
            this.buzzbomber = buzzbomber;
            updateDelayCounter = DelayCountStartValue;
            sprite = new LeftIdleBuzzBomberSprite();
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
                buzzbomber.State = new LeftMovingBuzzBomberState(buzzbomber);
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
            updateDelayCounter++;
            if (updateDelayCounter % DelayTime50 == ZERO)
                buzzbomber.Attack();
        }
    }
}
