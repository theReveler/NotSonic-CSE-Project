using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class RightAttackCannonState : IEnemyState
    {
        private Cannon cannon;
        private RightAttackCannonSprite sprite;
        private IProjectile projectile;

        public RightAttackCannonState(Cannon cannon)
        {
            this.cannon = cannon;
            sprite = new RightAttackCannonSprite();
        }
        public void Attack()
        {
            //spawns a projectile
            projectile = new CannonRightProjectile(new Vector2(cannon.Position.X + RightCannonProjectileOffset.X, cannon.Position.Y + RightCannonProjectileOffset.Y));
            Game1.PlayState.AddToGameList(projectile);
        }

        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }

        public void ChangeDirection()
        {
            cannon.State = new LeftAttackCannonState(cannon);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Idle()
        {
            cannon.State = new RightIdleCannonState(cannon);
        }

        public void TakeDamage()
        {
            cannon.State = new RightDeadCannonState();
        }

        public void Update()
        {
            if (sprite.SpawnProjectile)
            {
                sprite.SpawnProjectile = false;
                cannon.Attack();
            }
            if (sprite.AttackFinished)
                cannon.Idle();
            sprite.Update();
        }
    }
}
