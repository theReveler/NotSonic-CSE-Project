using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    class DeadBuzzBomberState : IEnemyState, IDeadEnemyState
    {
        private ISprite sprite;
        public DeadBuzzBomberState(BuzzBomber buzzbomber)
        {
            sprite = new DeadBuzzBomberSprite(buzzbomber.Position);
        }
        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }
        public void Idle()
        {
            //Can't go Idle when dead
        }
        public void Attack()
        {
            //Can't attack when dead
        }

        public void ChangeDirection()
        {
            //Can't change direction when dead
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
