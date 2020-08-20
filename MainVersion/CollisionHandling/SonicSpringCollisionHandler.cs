using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    class SonicSpringCollisionHandler : ICollision
    {
        public void HandleCollision(IGameObject gameObject1, IGameObject gameObject2, Direction collisionType)
        {
            Sonic sonic = (Sonic)gameObject1;
            ISpring spring = (ISpring)gameObject2;

            if (collisionType == Direction.Left)
            {
                if (!spring.IsHorizontal)
                {
                    spring.Interact();
                    spring.Update();
                }
                if (spring.IsHorizontal)
                {
                    spring.Interact();
                    spring.Update();
                }
                sonic.Position = sonic.Position + new Vector2(0, -17f);
                sonic.Velocity = new Vector2(sonic.Velocity.X, -8f);
                sonic.SpringJump();
                // sonic.Position = new Vector2(spring.BoundingBox().Left - sonic.BoundingBox().Width - 5, sonic.Position.Y);
            }
            else if (collisionType == Direction.Right)
            {
                if (spring.IsHorizontal)
                {
                    spring.Interact();
                    spring.Update();
                }
                sonic.Position = sonic.Position + new Vector2(0, -17f);
                sonic.Velocity =  new Vector2(sonic.Velocity.X, -8f);
                sonic.SpringJump();
                // sonic.Position = new Vector2(spring.BoundingBox().Right + 5, sonic.Position.Y);
            }
            else if (collisionType == Direction.Up)
            {
                if (spring.IsHorizontal)
                {
                    spring.Interact();
                    spring.Update();
                }

                sonic.Position = sonic.Position + new Vector2(0, -17f);
                sonic.Velocity = new Vector2(sonic.Velocity.X, -8f); 
                sonic.SpringJump();

                //sonic.Position = new Vector2(sonic.Position.X, spring.BoundingBox().Top - sonic.BoundingBox().Height - 5);
            }
            else if (collisionType == Direction.Down)
            {
                sonic.Position = new Vector2 (sonic.Position.X, spring.BoundingBox().Bottom + 5);
                sonic.Position = sonic.Position + new Vector2(0, -17f);
                sonic.Velocity = new Vector2(sonic.Velocity.X, -8f);
                sonic.SpringJump();
            }
            else if (collisionType == Direction.None)
            {
                //Do nothing
            }
        }
    }
}
