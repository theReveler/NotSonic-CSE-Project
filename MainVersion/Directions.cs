using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public static class Directions
    {
        public enum Direction { Left, Right, Up, Down, LeftUp, LeftDown, RightUp, RightDown, None };
         
        public static Vector2 GetUnitVector(this Direction input)
        {
            switch (input)
            {
                case Direction.Left: return new Vector2(-1, 0);
                case Direction.Right: return new Vector2(1, 0);
                case Direction.Up: return new Vector2(0, -1);
                case Direction.Down: return new Vector2(0, 1);
                case Direction.LeftUp: return new Vector2(-1, -1);
                case Direction.LeftDown: return new Vector2(-1, 1);
                case Direction.RightUp: return new Vector2(1, -1);
                case Direction.RightDown: return new Vector2(1, 1);
                default: return new Vector2(0, 0);
            }
        }

        public static bool isDirectionAdjacentTo(this Direction self, Direction compare)
        {
            switch (self)
            {
                case Direction.Left: return (compare == Direction.Left || compare == Direction.LeftUp || compare == Direction.LeftDown);
                case Direction.Right: return (compare == Direction.Right || compare == Direction.RightUp || compare == Direction.RightDown);
                case Direction.Up: return (compare == Direction.Up || compare == Direction.LeftUp || compare == Direction.RightUp);
                case Direction.Down: return (compare == Direction.Down|| compare == Direction.LeftDown|| compare == Direction.RightDown);
                case Direction.LeftUp: return (compare == Direction.LeftUp || compare == Direction.Left || compare == Direction.Up);
                case Direction.LeftDown: return (compare == Direction.LeftDown || compare == Direction.Left || compare == Direction.Down);
                case Direction.RightUp: return (compare == Direction.RightUp || compare == Direction.Right || compare == Direction.Up);
                case Direction.RightDown: return (compare == Direction.RightDown || compare == Direction.Right || compare == Direction.Down);
                default: return (compare == self);
            }
        }
    }
}
