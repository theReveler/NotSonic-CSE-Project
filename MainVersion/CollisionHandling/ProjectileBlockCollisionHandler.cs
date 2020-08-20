using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    class ProjectileBlockCollisionHandler : ICollision
    {
        public void HandleCollision(IGameObject gameObject1, IGameObject gameObject2, Direction collisionType)
        {
            IProjectile projectile = (IProjectile)gameObject1;

            if (collisionType != Direction.None)
            {
                Game1.PlayState.RemoveFromGameList(projectile);
            }
        }
    }
}
