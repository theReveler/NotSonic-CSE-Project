using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    public interface IPlatformState
    {
        Vector2 Position { get; set; }

        Rectangle BoundingBox();
        void Draw(SpriteBatch spriteBatch);
        void Update();
        void SetDirection(Direction direction);
    }
}
