using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class Spring : ISpring
    {
        public ISpringState state;
        public bool IsHorizontal {get;set;}

        //Default Spring Constructor is horizontal yellow.
        public Spring(Vector2 position)
        {
            IsHorizontal = true;
            state = new UnpressedHorizontalYellowSpringState(this, position);
        }

        public Spring(Vector2 position, bool isRed, bool isHorizontal)
        {
            IsHorizontal = isHorizontal;

            if (isRed && isHorizontal)
                state = new UnpressedHorizontalRedSpringState(this, position);
            else if (isRed && !isHorizontal)
                state = new UnpressedVerticalRedSpringState(this, position);
            else if (!isRed && isHorizontal)
                state = new UnpressedHorizontalYellowSpringState(this, position);
            else
                state = new UnpressedVerticalYellowSpringState(this, position);
        }

        public void Update() { state.Update(); }

        public void Draw(SpriteBatch spriteBatch) { state.Draw(spriteBatch); }

        public void Interact() { state.BePressed(); }

        public Rectangle BoundingBox() { return state.BoundingBox(); }
    }
}
