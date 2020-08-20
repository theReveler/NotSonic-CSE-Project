using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    
    public interface ICollision
    {
        void HandleCollision(IGameObject gameObject1, IGameObject gameObject2, Direction collisionType);
    }
}
