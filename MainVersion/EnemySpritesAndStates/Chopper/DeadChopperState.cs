using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    class DeadChopperState : IEnemyState, IDeadEnemyState
    {
        private ISprite sprite;

        public DeadChopperState(Chopper chopper)
        {
            sprite = new DeadChopperSprite(chopper.Position);
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
            //Can't attack when dead
        }

        public void ChangeDirection()
        {
            //Can't change directions when dead
        }

        public void TakeDamage()
        {
            //already dead
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update()
        {
            sprite.Update();
        }
    }
}
