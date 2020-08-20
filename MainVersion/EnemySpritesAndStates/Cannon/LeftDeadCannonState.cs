using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    class LeftDeadCannonState : IEnemyState, IDeadEnemyState
    {
        private IEnemySprite sprite;
        public LeftDeadCannonState()
        {
            sprite = new LeftDeadCannonSprite();
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
            //Can't changeDirection when dead
        }

        public void TakeDamage()
        {
            //already dead
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Update()
        {
            sprite.Update();
        }
    }
}
