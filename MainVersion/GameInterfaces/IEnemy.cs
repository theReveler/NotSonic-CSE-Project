using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    public interface IEnemy : IGameObject
    {
        IEnemyState State { get; set; }
        Vector2 Position { get; set; }
        void ChangeDirection();
        void TakeDamage();
        void Attack();
    }
}
