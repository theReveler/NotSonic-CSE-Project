using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    class SonicSpikeCollisionHandler : ICollision
    {
        public void HandleCollision(IGameObject gameObject1, IGameObject gameObject2, Direction collisionType)
        {
            Sonic sonic = (Sonic)gameObject1;
            ISpike spike = (ISpike)gameObject2;

            if (collisionType == Direction.Left)
            {
                if(spike.IsHorizontal)
                    sonic.TakeDamage();
                sonic.Position = new Vector2(spike.BoundingBox().Left - sonic.BoundingBox().Width - 5, sonic.Position.Y);
            }
            else if (collisionType == Direction.Right)
            {
                sonic.Position = new Vector2(spike.BoundingBox().Right + 5, sonic.Position.Y);
            }
            else if (collisionType == Direction.Up)
            {
                if (!spike.IsHorizontal)
                {
                    sonic.TakeDamage();
                    
                }
                    
                sonic.Position = new Vector2(sonic.Position.X, spike.BoundingBox().Top - sonic.BoundingBox().Height - 5);
                sonic.OnGround = true;
                ScoreControl.RestartMulitplier();
            }
            else if (collisionType == Direction.Down)
            {
                sonic.Position = new Vector2(sonic.Position.X, spike.BoundingBox().Bottom + 5);
            }
            else if (collisionType == Direction.None)
            {
                //Do nothing
            }
        }
    }
}
