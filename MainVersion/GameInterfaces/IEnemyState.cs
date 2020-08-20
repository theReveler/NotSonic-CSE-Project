using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public interface IEnemyState
    {
        Rectangle BoundingBox();
        void Idle();
        void ChangeDirection();
        void TakeDamage();
        void Attack();
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        void Update();
    }
}
