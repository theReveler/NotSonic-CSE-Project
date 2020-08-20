using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    public class DeadSonicState : ISonicState
    {
        private Sonic sonic;
        public Directions.Direction Orientation { get { return Directions.Direction.Down; } }

        public DeadSonicState(Sonic sonic)
        {
            this.sonic = sonic;
            sonic.SonicSprite = new DeadSonicSprite(sonic);
        }
        public void Crouch()
        {
            //ur ded
        }

        public void DefaultState()
        {
            //ur ded
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sonic.SonicSprite.Draw(spriteBatch);
        }

        public void Jump()
        {
            //ur ded
        }

        public void MoveLeft()
        {
            //ur ded
        }

        public void MoveRight()
        {
            //ur ded
        }

        public void Update()
        {
            sonic.SonicSprite.Update();
        }
    }
}
