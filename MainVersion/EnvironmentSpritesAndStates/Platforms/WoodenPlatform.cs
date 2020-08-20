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
    public class WoodenPlatform : IPlatform
    {
        public IPlatformState State { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 MovingCenterPoint { get; set; }

        public WoodenPlatform(Vector2 position, Direction direction)
        {
            Position = position;
            MovingCenterPoint = position;
            SetDirection(direction);
        }

        public void Update()
        {
            State.Update();
            Position = State.Position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public void Interact() { }

        public Rectangle BoundingBox()
        {
            return State.BoundingBox();
        }
        public void SetDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    State = new UpMovingWoodenPlatformState(this);
                    break;
                case Direction.Down:
                    State = new DownMovingWoodenPlatformState(this);
                    break;
                case Direction.Right:
                    State = new RightMovingWoodenPlatformState(this);
                    break;
                case Direction.Left:
                    State = new LeftMovingWoodenPlatformState(this);
                    break;
                default:
                    State = new NonMovingWoodenPlatformState(this);
                    break;
            }
        }
    }
}
