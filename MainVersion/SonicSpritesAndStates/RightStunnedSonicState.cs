using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame.SonicSpritesAndStates
{
    class RightStunnedSonicState : ISonicState
    {
        private Sonic sonic;
        public Directions.Direction Orientation { get { return Directions.Direction.Right; } }

        public RightStunnedSonicState(Sonic sonic)
        {
            this.sonic = sonic;
            sonic.SonicSprite = new RightStunnedSonicSprite(sonic);
        }
        public void Crouch()
        {
        }

        public void DefaultState()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sonic.SonicSprite.Draw(spriteBatch);
        }

        public void Jump()
        {
        }

        public void MoveLeft()
        {
            sonic.SonicState = new LeftStunnedSonicState(sonic);
        }

        public void MoveRight()
        {
        }

        public void Update()
        {
            sonic.SonicSprite.Update();
            if (!sonic.IsStunned)
            {
                sonic.SonicState = new LeftIdleSonicState(sonic);
            }
        }
    }
}
