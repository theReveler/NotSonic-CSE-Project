using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    class ChillPenguinJumpState : IBossState
    {
        private ChillPenguin chillPenguin;
        private ChillPenguinJumpSprite sprite;
        private int Xdisplacement;
        public bool IsFacingLeft { get { return chillPenguin.IsFacingLeft; } }

        public ChillPenguinJumpState(ChillPenguin chillPenguin)
        {
            this.chillPenguin = chillPenguin;
            if (IsFacingLeft)
                Xdisplacement = -2;
            else
                Xdisplacement = 2;
            sprite = new ChillPenguinJumpSprite(IsFacingLeft);
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
            chillPenguin.State = new ChillPenguinFallingState(chillPenguin);
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
            if (sprite.InAir)
                chillPenguin.Position = new Vector2(chillPenguin.Position.X + Xdisplacement, chillPenguin.Position.Y - 3);
            if (chillPenguin.Position.Y <= 0)
                ChangeDirection();
        }
    }
}
