using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    public class Chopper : IEnemy
    {
        public IEnemyState State { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PartolingCenterPoint { get; set; }
        public Chopper(Vector2 position)
        {
            this.Position = position;
            PartolingCenterPoint = position;
            State = new LeftFacingJumpingChopperState(this);   
        }
        public Rectangle BoundingBox()
        {
            return State.BoundingBox();
        }
        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void TakeDamage()
        {
            State.TakeDamage();
        }
        public void Attack()
        {
            State.Attack();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, Position);
        }

        public void Update()
        {
            State.Update();
        }
    }
}
