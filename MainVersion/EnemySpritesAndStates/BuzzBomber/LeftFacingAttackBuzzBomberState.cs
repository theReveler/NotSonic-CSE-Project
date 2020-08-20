using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class LeftFacingAttackBuzzBomberState : IEnemyState
    {
        private BuzzBomber buzzbomber;
        private LeftFacingAttackBuzzBomberSprite sprite;
        private IProjectile projectile;

        public LeftFacingAttackBuzzBomberState(BuzzBomber buzzbomber)
        {
            this.buzzbomber = buzzbomber;
            sprite = new LeftFacingAttackBuzzBomberSprite();
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
            //spwans a projectile
            projectile = new BuzzBomberLeftProjectile(new Vector2(buzzbomber.Position.X + 5, buzzbomber.Position.Y + 30));
            Game1.PlayState.AddToGameList(projectile);
        }

        public void ChangeDirection()
        {
            //starts moving left
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
            if(sprite.SpawnProjectile)
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
