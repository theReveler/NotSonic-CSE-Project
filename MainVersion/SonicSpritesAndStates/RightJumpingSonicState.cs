using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class RightJumpingSonicState : ISonicState
    {
        private Sonic sonic;
        public Directions.Direction Orientation { get { return Directions.Direction.Right; } }
        public RightJumpingSonicState(Sonic sonic)
        {
            this.sonic = sonic;
            sonic.SonicSprite = new RightBallSonicSprite(sonic);
        }
        public void MoveRight()
        {
            if (!sonic.HasJumped)
            {
                sonic.SonicState = new RightRunningSonicState(sonic);
            }
        }

        public void MoveLeft()
        {
            sonic.SonicState = new LeftJumpingSonicState(sonic);
        }

        public void Crouch()
        {
            sonic.SonicState = new RightIdleSonicState(sonic);
        }

        public void Jump()
        {
            //Sonic is already jumping - no state change
        }

        public void DefaultState()
        {
            if (!sonic.HasJumped)
            {
                sonic.SonicState = new RightIdleSonicState(sonic);
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
