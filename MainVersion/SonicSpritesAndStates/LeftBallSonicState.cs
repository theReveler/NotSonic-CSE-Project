using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class LeftBallSonicState : ISonicState
    {
        private Sonic sonic;
        public Directions.Direction Orientation { get { return Directions.Direction.Left; } }

        public LeftBallSonicState(Sonic sonic)
        {
            this.sonic = sonic;
            sonic.SonicSprite = new LeftBallSonicSprite(sonic);
        }
        public void MoveRight()
        {
            sonic.SonicState = new RightIdleSonicState(sonic);
        }

        public void MoveLeft()
        {
            sonic.SonicState = new LeftRunningSonicState(sonic);        
        }

        public void Crouch()
        {
            //Sonic is already crouching - no state change
        }

        public void Jump()
        {
            //Sonic cannot jump while crouching - no state change
        }

        public void DefaultState()
        {
            sonic.SonicState = new LeftIdleSonicState(sonic);
        }

        public void Update()
        {
            //Sonic doesnt do anything while crouched
            sonic.SonicSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sonic.SonicSprite.Draw(spriteBatch);
        }
    }
}
