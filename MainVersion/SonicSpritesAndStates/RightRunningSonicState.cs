using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class RightRunningSonicState : ISonicState
    {
        private Sonic sonic;
        public Directions.Direction Orientation { get { return Directions.Direction.Right; } }
        public RightRunningSonicState(Sonic sonic)
        {
            this.sonic = sonic;
            sonic.SonicSprite = new RightRunningSonicSprite(6, sonic);
        }
        public void MoveRight()
        {
            //Already running right - no state change 
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
            sonic.SonicState = new RightIdleSonicState(sonic);
        }

        public void Update()
        {
            sonic.SonicSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sonic.SonicSprite.Draw(spriteBatch);
        }
    }
}
