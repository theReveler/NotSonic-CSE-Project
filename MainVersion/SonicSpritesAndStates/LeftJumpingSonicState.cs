using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class LeftJumpingSonicState : ISonicState
    {
        private Sonic sonic;
        public Directions.Direction Orientation { get { return Directions.Direction.Left; } }

        public LeftJumpingSonicState(Sonic sonic)
        {
            this.sonic = sonic;
            sonic.SonicSprite = new LeftBallSonicSprite(sonic);
        }
        public void MoveRight()
        {
            sonic.SonicState = new RightJumpingSonicState(sonic);
        }

        public void MoveLeft()
        {
            if (!sonic.HasJumped)
            {
                sonic.SonicState = new LeftRunningSonicState(sonic);
            }
        }

        public void Crouch()
        {
            sonic.SonicState = new LeftIdleSonicState(sonic);
        }

        public void Jump()
        {
            //Sonic is already jumping - no state change
        }

        public void DefaultState()
        {
            if (!sonic.HasJumped)
            {
                sonic.SonicState = new LeftIdleSonicState(sonic);
            }
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
