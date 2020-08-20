using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public interface ISonicState
    {
        void MoveLeft();
        void MoveRight();
        void Jump();
        void Crouch();
        void Update();
        void DefaultState();
        void Draw(SpriteBatch spriteBatch);
        Directions.Direction Orientation { get; }

    }
}
