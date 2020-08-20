using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class ChillPenguinIdleState : IBossState
    {
        private ChillPenguin chillPenguin;
        private ChillPenguinIdleSprite sprite;
        public bool IsFacingLeft { get { return chillPenguin.IsFacingLeft; } }
        public ChillPenguinIdleState(ChillPenguin chillPenguin)
        {
            this.chillPenguin = chillPenguin;
            sprite = new ChillPenguinIdleSprite(IsFacingLeft);
        }
        public void Attack()
        {
            int random_num = Randon_Number_Generater.Next(0,2);
            if (random_num == 0)
                chillPenguin.State = new ChillPenguinJumpState(chillPenguin);
            else if(random_num == 1)
                chillPenguin.State = new ChillPenguinSlidingState(chillPenguin);
        }

        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }

        public void ChangeDirection()
        {
            sprite.IsFacingLeft = !sprite.IsFacingLeft;
            chillPenguin.IsFacingLeft = sprite.IsFacingLeft;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public void Idle()
        {

        }

        public void TakeDamage()
        {

        }

        public void Update()
        {
            sprite.Update();
            if ((chillPenguin.Position.X <= 3487 && sprite.IsFacingLeft) || (chillPenguin.Position.X > 3487 && !sprite.IsFacingLeft))
                ChangeDirection();
            if (sprite.ReadyToAttack)
                Attack();
        }
    }
}
