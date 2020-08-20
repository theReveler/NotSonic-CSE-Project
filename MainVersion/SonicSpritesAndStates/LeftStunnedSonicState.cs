using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame.SonicSpritesAndStates
{
    class LeftStunnedSonicState : ISonicState
    {
        private Sonic sonic;
        public Directions.Direction Orientation { get { return Directions.Direction.Left; } }
        public LeftStunnedSonicState(Sonic sonic)
        {
            this.sonic = sonic;
            sonic.SonicSprite = new LeftStunnedSonicSprite(sonic);
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
        }

        public void MoveRight()
        {
            sonic.SonicState = new RightStunnedSonicState(sonic);
        }

        public void Update()
        {
            sonic.SonicSprite.Update();
            if (!sonic.IsStunned) {
                sonic.SonicState = new RightIdleSonicState(sonic);
            }
        }
    }
}
