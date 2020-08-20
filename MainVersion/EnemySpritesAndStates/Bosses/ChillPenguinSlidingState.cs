using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    class ChillPenguinSlidingState : IBossState
    {
        private ChillPenguin chillPenguin;
        private ChillPenguinSlidingSprite sprite;
        private int travelDistance;
        public bool IsFacingLeft { get { return chillPenguin.IsFacingLeft; } }
        public ChillPenguinSlidingState(ChillPenguin chillPenguin)
        {
            this.chillPenguin = chillPenguin;
            sprite = new ChillPenguinSlidingSprite(IsFacingLeft);
            if(IsFacingLeft)
                travelDistance = -3;
            else
                travelDistance = 3;
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
            sprite.IsFacingLeft = !sprite.IsFacingLeft;
            chillPenguin.IsFacingLeft = sprite.IsFacingLeft;
            travelDistance *= -1;
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
            if((chillPenguin.Position.X <= 3150 && sprite.IsFacingLeft ) || (chillPenguin.Position.X >= 3750 && !sprite.IsFacingLeft))
            {
                Idle();
            }
            if(sprite.IsSlideACrossFloor)
            {
                chillPenguin.Position = new Vector2((int)chillPenguin.Position.X + travelDistance, (int)chillPenguin.Position.Y);
            }
        }
    }
}
