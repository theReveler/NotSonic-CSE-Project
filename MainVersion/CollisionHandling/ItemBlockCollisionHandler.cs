using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    public class ItemBlockCollisionHandler : ICollision
    {
        public void HandleCollision(IGameObject gameObject1, IGameObject gameObject2, Direction collisionType)
        {
            IItem item = (IItem)gameObject1;
            IBlock block = (IBlock)gameObject2;
            DroppedRing temp;

            //Dropped Rings are the only moving items with collision.
            if (item is DroppedRing)
            {
                temp = (DroppedRing)item;
                if(collisionType == Direction.Left)
                {
                    temp.Velocity = new Vector2((-1 * temp.Velocity.X), temp.Velocity.Y);
                    temp.Position = new Vector2(block.BoundingBox().Left - temp.BoundingBox().Width, temp.Position.Y);
                }
                else if (collisionType == Direction.Up)
                {
                    temp.Velocity = new Vector2(temp.Velocity.X, (-1 * temp.Velocity.Y));
                    temp.Position = new Vector2(temp.Position.X, block.BoundingBox().Top - temp.BoundingBox().Height);
                }
                else if(collisionType == Direction.Right)
                {
                    temp.Velocity = new Vector2((-1 * temp.Velocity.X), temp.Velocity.Y);
                    temp.Position = new Vector2(block.BoundingBox().Right, temp.Position.Y);
                }
                else if(collisionType == Direction.Down)
                {
                    temp.Velocity = new Vector2(temp.Velocity.X, (-1 * temp.Velocity.Y));
                    temp.Position = new Vector2(temp.Position.X, block.BoundingBox().Bottom);
                }
            }
        }
    }
}
