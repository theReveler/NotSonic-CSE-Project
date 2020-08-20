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
    class RightFacingAttackBuzzBomberState : IEnemyState
    {
        private BuzzBomber buzzbomber;
        private RightFacingAttackBuzzBomberSprite sprite;
        private IProjectile projectile;

        public RightFacingAttackBuzzBomberState(BuzzBomber buzzbomber)
        {
            this.buzzbomber = buzzbomber;
            sprite = new RightFacingAttackBuzzBomberSprite();
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
            //spwans a projectile
            projectile = new BuzzBomberRightProjectile(new Vector2(buzzbomber.Position.X + BuzzBomberRightProjectileOffSet.X, buzzbomber.Position.Y + BuzzBomberRightProjectileOffSet.Y));
            Game1.PlayState.AddToGameList(projectile);
        }

        public void ChangeDirection()
        {
            //starts moving right
            buzzbomber.State = new RightMovingBuzzBomberState(buzzbomber);
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
            if (sprite.SpawnProjectile)
            {
                sprite.SpawnProjectile = false;
                buzzbomber.Attack();
            }
            if (sprite.AttackFinished)
                buzzbomber.ChangeDirection();
            sprite.Update();
        }
    }
}
