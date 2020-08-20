using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    public class DeadMotoBugState : IEnemyState, IDeadEnemyState
    {
        private MotoBug motobug;
        private IEnemySprite sprite;

        public DeadMotoBugState(MotoBug motobug)
        {
            this.motobug = motobug;
            sprite = new DeadMotoBugSprite(motobug.Position);
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
            sprite.Draw(spriteBatch, motobug.Position);
        }

        public void Update()
        {
            sprite.Update();
        }
    }
}
