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
    class RightIdleCannonState : IEnemyState
    {
        private Cannon cannon;
        private ISprite sprite;
        private int updateDelayconuter;

        public RightIdleCannonState(Cannon cannon)
        {
            this.cannon = cannon;
            updateDelayconuter = DelayCountStartValue;
            sprite = new RightIdleCannonSprite(cannon.Position);
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
            cannon.State = new RightAttackCannonState(cannon);
        }

        public void ChangeDirection()
        {
            cannon.State = new LeftIdleCannonState(cannon);
        }

        public void TakeDamage()
        {
            cannon.State = new RightDeadCannonState();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update()
        {
            //sprite.Update();
            updateDelayconuter++;
            if (updateDelayconuter % DelayCountMax == ZERO)
                cannon.State.Attack();
        }
    }
}
