using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame.SonicSpritesAndStates
{
    class LeftRunningFastSonicState : ISonicState
    {
        private Sonic sonic;
        public Directions.Direction Orientation { get { return Directions.Direction.Left; } }

        public LeftRunningFastSonicState(Sonic sonic)
        {
            this.sonic = sonic;
            sonic.SonicSprite = new LeftRunningFastSonicSprite(sonic);
        }
        public void MoveRight()
        {
            sonic.SonicState = new RightIdleSonicState(sonic);
        }

        public void MoveLeft()
        {
            //you already going fast
        }

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