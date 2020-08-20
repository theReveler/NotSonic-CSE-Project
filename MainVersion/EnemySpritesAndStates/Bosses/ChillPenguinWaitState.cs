using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    class ChillPenguinWaitState : IBossState
    {
        private ChillPenguin chillPenguin;
        public bool IsFacingLeft { get { return true; } }

        public ChillPenguinWaitState(ChillPenguin chillPenguin)
        {
            this.chillPenguin = chillPenguin;
        }

        public void Attack()
        {
            
        }

        public Rectangle BoundingBox()
        {
            return new Rectangle((int)chillPenguin.Position.X, (int)chillPenguin.Position.Y, 0, 0);
        }

        public void ChangeDirection()
        {
            chillPenguin.State = new ChillPenguinIntroState(chillPenguin);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {

        }

        public void Idle()
        {

        }

        public void TakeDamage()
        {

        }

        public void Update()
        {

        }
    }
}
