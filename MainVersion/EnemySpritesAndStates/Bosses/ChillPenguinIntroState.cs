using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.AssetStorage;

namespace NotSonicGame
{
    class ChillPenguinIntroState : IBossState
    {
        private ChillPenguin chillPenguin;
        private ChillPenguinIntroSprite sprite;
        public bool IsFacingLeft { get { return chillPenguin.IsFacingLeft; } }

        public ChillPenguinIntroState(ChillPenguin chillPenguin)
        {
            this.chillPenguin = chillPenguin;
            sprite = new ChillPenguinIntroSprite();
        }
        public void Attack()
        {
            chillPenguin.State = new ChillPenguinSlidingState(chillPenguin);
        }

        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }

        public void ChangeDirection()
        {
            sprite.IsFalling = false;
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
            //can't take damage during intro
        }

        public void Update()
        {
            sprite.Update();
            if(sprite.IsFalling)
                chillPenguin.Position = new Vector2(chillPenguin.Position.X, chillPenguin.Position.Y + 4);
            else if (sprite.IntroFinished)
                chillPenguin.State = new ChillPenguinIdleState(chillPenguin);

        }
    }
}
