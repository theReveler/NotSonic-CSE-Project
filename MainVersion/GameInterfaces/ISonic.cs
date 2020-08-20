using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    public interface ISonic : IGameObject
    {
        Vector2 Position { get; set; }

        Vector2 Velocity { get; set; }

        //placeholder
        bool OnGround { get; set; }
        bool HasJumped { get; set; }

        void MoveRight();

        void MoveLeft();

        void SpringJump();
        void Jump();

        void Crouch();

        void Dead();
        void TakeDamage();
        void GetInvincible();
        void GetShield();
        void GetPowerSneaker();
    }
}
