using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class AttackCrabmeatState : IEnemyState
    {
        private Crabmeat crabmeat;
        private AttackCrabmeatSprite sprite;
        private IProjectile leftProjectile;
        private IProjectile rightProjectile;

        public AttackCrabmeatState(Crabmeat crabmeat)
        {
            this.crabmeat = crabmeat;
            sprite = new AttackCrabmeatSprite();
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
            //spwans 2 projectiles
            leftProjectile = new CrabmeatLeftProjectile(new Vector2(crabmeat.Position.X - LeftProjectileCrabmeatOffSetX, crabmeat.Position.Y - LeftProjectileCrabmeatOffSetY));
            rightProjectile = new CrabmeatRightProjectile(new Vector2(crabmeat.Position.X + RightProjectileCrabmeatOffSetX, crabmeat.Position.Y - RightProjectileCrabmeatOffSetY));
            Game1.PlayState.AddToGameList(leftProjectile);
            Game1.PlayState.AddToGameList(rightProjectile);

        }

        public void ChangeDirection()
        {
            //goes to idle state then changes direction
            crabmeat.State = new IdleAfterAttackingCrabmeatState(crabmeat);
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
            if (sprite.SpawnProjectiles)
            {
                sprite.SpawnProjectiles = false;
                crabmeat.Attack();
            }
            if (sprite.AttackFinished)
                crabmeat.ChangeDirection();
            else
                sprite.Update();

        }
    }
}
