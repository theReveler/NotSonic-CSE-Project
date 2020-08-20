using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    class ChillPenguin : IBoss
    {
        private int health;
        public IEnemyState State { get; set; }
        public Vector2 Position { get; set; }
        public int Health { get { return health; } }
        public bool IsFacingLeft { get; set; }

        public ChillPenguin(Vector2 position)
        {
            this.Position = position;
            health = 6;
            IsFacingLeft = true;
            State = new ChillPenguinWaitState(this);
        }

        public void StartFight()
        {
            State = new ChillPenguinIntroState(this);
        }

        public void Attack()
        {
            State.Attack();
        }

        public Rectangle BoundingBox()
        {
            return State.BoundingBox();
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, Position);
        }

        public void TakeDamage()
        {
            health--;
            State.TakeDamage();
        }

        public void Update()
        {
            State.Update();
        }
    }
}
