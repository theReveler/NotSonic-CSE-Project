using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    public class SonicProjectileCollisionHandler : ICollision
    {
        public void HandleCollision(IGameObject gameObject1, IGameObject gameObject2, Direction collisionType)
        {
            var sonic = (Sonic)gameObject1;

            if (collisionType != Direction.None && !sonic.IsInvincible)
                sonic.TakeDamage();
        }
    }
}
