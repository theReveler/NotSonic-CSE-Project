using Microsoft.Xna.Framework;
using NotSonicGame.GameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    class SonicPhysics : IPhysics
    {
        Sonic sonic;
        float maxLinearVelocity = 9f;

        //Vector2 position;
        //Vector2 velocity;

        //bool activateGravity;
        //bool onGround;

        public SonicPhysics(Sonic s)
        {
            //onGround = false;
            //activateGravity = true;
            sonic = s;
        }

        public void Update()
        {
            sonic.AccelX = getXAccel(sonic.Velocity, sonic.AccelDirectionX);
            if (Math.Abs(sonic.Velocity.X) < 0.3)
            {
                sonic.Velocity = new Vector2(0, sonic.Velocity.Y);
            }

            if (sonic.Velocity.Y > 11)
            {
                sonic.Velocity = new Vector2(sonic.Velocity.X, 11);
            }

            if (!sonic.IsStunned)
            {
                if (sonic.OnGround && sonic.Velocity.X < maxLinearVelocity)
                {
                    sonic.Velocity = new Vector2(sonic.Velocity.X + sonic.AccelX, 0);
                }
                else if (sonic.Velocity.Y < 12 && sonic.Velocity.X < maxLinearVelocity)
                {
                    sonic.Velocity = new Vector2(sonic.Velocity.X + sonic.AccelX / 1.1f, sonic.Velocity.Y + 0.25f);
                }
                else if (sonic.Velocity.Y < 12)
                {
                    sonic.Velocity = new Vector2(sonic.Velocity.X, sonic.Velocity.Y + 0.20f);
                }
            } else
            {
                sonic.Velocity = new Vector2(sonic.Velocity.X, sonic.Velocity.Y + 0.20f);
            }

            sonic.Position = new Vector2(sonic.Position.X + sonic.Velocity.X, sonic.Position.Y + sonic.Velocity.Y);

            if (sonic.HasJumped == true)
            {
                if (sonic.OnGround)
                {
                    sonic.HasJumped = false;
                }
            }

            //correcting position
            if (sonic.Position.X < 0)
            {
                sonic.Position = new Vector2(0, sonic.Position.Y);
            }

            if (sonic.Position.Y > 700)
            {
                sonic.Dead();
            }
        }

        internal float getXAccel(Vector2 velocity, Direction direction)
        {
            switch(direction)
            {
                case Direction.Right:
                    return (velocity.X > 0) ? (0.7f - Math.Abs(velocity.X) / maxLinearVelocity) : (1.2f - Math.Abs(velocity.X) / maxLinearVelocity * 1.5f);            
                case Direction.Left:
                    return (velocity.X < 0) ? (-0.7f + Math.Abs(velocity.X) / maxLinearVelocity) : (-1.2f + Math.Abs(velocity.X) / maxLinearVelocity * 1.5f);
                default:
                    if (Math.Abs(velocity.X) < maxLinearVelocity / 40)
                        return 0;
                    else
                        return (velocity.X > 0) ? (-maxLinearVelocity / 40) : (maxLinearVelocity / 40);
            }

        }
    }
}
