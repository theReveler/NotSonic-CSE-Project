using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    public class LeftAttackCannonState : IEnemyState
    {
        private Cannon cannon;
        private LeftAttackCannonSprite sprite;
        private IProjectile projectile;
        public Vector2 Position { get; set; }

        public LeftAttackCannonState(Cannon cannon)
        {
            this.cannon = cannon;
            Position = cannon.Position;
            sprite = new LeftAttackCannonSprite();
        }
        public void Attack()
        {
            //spwans a projectile
            projectile = new CannonLeftProjectile(new Vector2(Position.X - LeftCannonProjectileOffset.X, Position.Y + LeftCannonProjectileOffset.Y));
            Game1.PlayState.AddToGameList(projectile);
        }

        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }

        public void ChangeDirection()
        {
            cannon.State = new RightAttackCannonState(cannon);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Idle()
        {
            cannon.State = new LeftIdleCannonState(cannon);
        }

        public void TakeDamage()
        {
            cannon.State = new LeftDeadCannonState();
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
