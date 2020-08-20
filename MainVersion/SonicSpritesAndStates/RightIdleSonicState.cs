using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class RightIdleSonicState : ISonicState
    {
        private Sonic sonic;
        public Directions.Direction Orientation { get { return Directions.Direction.Right; } }
        public RightIdleSonicState(Sonic sonic)
        {
            this.sonic = sonic;
            sonic.SonicSprite = new RightIdleSonicSprite(sonic);
        }
        public void MoveRight()
        {
            sonic.SonicState = new RightRunningSonicState(sonic);
        }

        public void MoveLeft()
        {
            sonic.SonicState = new LeftIdleSonicState(sonic);
        }

        public void Crouch()
        {
            sonic.SonicState = new RightBallSonicState(sonic);
        }

        public void Jump()
        {
            sonic.SonicState = new RightJumpingSonicState(sonic);     
        }

        public void DefaultState()
        {
            //Already in a default state - no state change
        }

        public void Update()
        {
            //Sonic doesnt do anything
            sonic.SonicSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sonic.SonicSprite.Draw(spriteBatch);
        }

    }
}
