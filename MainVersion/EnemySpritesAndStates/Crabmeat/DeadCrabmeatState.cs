using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    class DeadCrabmeatState : IEnemyState, IDeadEnemyState
    {
        private Crabmeat crabmeat;
        private IEnemySprite sprite;

        public DeadCrabmeatState(Crabmeat crabmeat)
        {
            this.crabmeat = crabmeat;
            sprite = new DeadCrabmeatSprite(crabmeat.Position);
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
            sprite.Draw(spriteBatch, crabmeat.Position);
        }

        public void Update()
        {
            sprite.Update();
        }
    }
}
