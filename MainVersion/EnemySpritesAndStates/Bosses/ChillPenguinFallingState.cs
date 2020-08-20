using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    class ChillPenguinFallingState : IBossState
    {
        private ChillPenguin chillPenguin;
        private ChillPenguinFallingSprite sprite;
        private int Xdisplacement;
        public bool IsFacingLeft { get { return chillPenguin.IsFacingLeft; } }

        public ChillPenguinFallingState(ChillPenguin chillPenguin) 
        {
            this.chillPenguin = chillPenguin;
            if (IsFacingLeft)
                Xdisplacement = -2;
            else
                Xdisplacement = 2;
            sprite = new ChillPenguinFallingSprite(IsFacingLeft);
        }
        public void Attack()
        {
            
        }

        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }

        public void ChangeDirection()
        {
            chillPenguin.State = new ChillPenguinIntroState(chillPenguin);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Idle()
        {
            chillPenguin.State = new ChillPenguinIdleState(chillPenguin);
        }

        public void TakeDamage()
        {
            
        }

        public void Update()
        {
            sprite.Update();
            chillPenguin.Position = new Vector2(chillPenguin.Position.X + Xdisplacement, chillPenguin.Position.Y + 3);
        }
    }
}
