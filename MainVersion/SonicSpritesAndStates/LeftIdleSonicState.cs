using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public class LeftIdleSonicState : ISonicState
    {
        private Sonic sonic;
        public Directions.Direction Orientation { get { return Directions.Direction.Left; } }

        public LeftIdleSonicState(Sonic sonic)
        {
            this.sonic = sonic;
            sonic.SonicSprite = new LeftIdleSonicSprite(sonic);
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
            sonic.SonicState = new LeftBallSonicState(sonic);
        }

        public void Jump()
        {
            
                sonic.SonicState = new LeftJumpingSonicState(sonic);
            
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
