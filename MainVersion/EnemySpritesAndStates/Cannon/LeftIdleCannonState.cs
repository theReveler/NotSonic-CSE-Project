using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class LeftIdleCannonState : IEnemyState
    {
        private Cannon cannon;
        private ISprite sprite;
        private int updateDelayconuter;

        public LeftIdleCannonState(Cannon cannon)
        {
            this.cannon = cannon;
            updateDelayconuter = 0;
            sprite = new LeftIdleCannonSprite(cannon.Position);
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
            cannon.State = new LeftAttackCannonState(cannon);
        }

        public void ChangeDirection()
        {
            cannon.State = new RightIdleCannonState(cannon);
        }

        public void TakeDamage()
        {
            cannon.State = new LeftDeadCannonState();
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

