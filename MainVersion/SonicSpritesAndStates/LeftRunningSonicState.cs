using Microsoft.Xna.Framework.Graphics;
using NotSonicGame.SonicSpritesAndStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class LeftRunningSonicState : ISonicState
    {
        private Sonic sonic;
        public Directions.Direction Orientation { get { return Directions.Direction.Left; } }

        public LeftRunningSonicState(Sonic sonic)
        {
            this.sonic = sonic;
            sonic.SonicSprite = new LeftRunningSonicSprite(6, sonic);
        }
        public void MoveRight()
        {
            sonic.SonicState = new LeftIdleSonicState(sonic);
        }

        public void MoveLeft()
        {
            //Already running left - no state change
        }

        /*public void RunLeft()
        {
            sonic.SonicState = new LeftRunningFastSonicState(sonic);
        }*/

        public void Crouch()
        {
            sonic.SonicState = new LeftBallSonicState(sonic);
        }

        public void Jump()
        {
            sonic.SonicState = new LeftJumpingSonicState(sonic);
        }

        public void DefaultState()
        {
            sonic.SonicState = new LeftIdleSonicState(sonic);
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
