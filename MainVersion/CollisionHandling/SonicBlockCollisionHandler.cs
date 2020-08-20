using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    public class SonicBlockCollisionHandler : ICollision
    {
        public void HandleCollision(IGameObject gameObject1, IGameObject gameObject2, Direction collisionType)
        {
            ISonic sonic = (ISonic)gameObject1;
            IBlock block = (IBlock)gameObject2;
            VideoMonitor videoTemp;
            WoodenPlatform platform;

            if (block is VideoMonitor)
            {
                videoTemp = (VideoMonitor)block;
                
                if(videoTemp.IsDestroyed)
                {
                    return;
                }
            }

            if (block is WoodenPlatform)
            {
                platform = (WoodenPlatform)block;
            }


            if (collisionType == Direction.Left)
            {
                if (block is VideoMonitor /*&& IsSonicAttacking(sonic)*/)
                {
                    block.Interact();
                }
                else if (block is WoodenPlatform)
                {

                }
                else if(sonic.Velocity.X <= -8f)
                {
                    sonic.Position = new Vector2(block.BoundingBox().Right, sonic.Position.Y);
                } 
                else
                {
                    sonic.Position = new Vector2(block.BoundingBox().Left - sonic.BoundingBox().Width, sonic.Position.Y);
                }

            }
            else if (collisionType == Direction.Right)
            {

                if (block is VideoMonitor /*&& IsSonicAttacking(sonic)*/)
                {
                    block.Interact();
                }
                else if (block is WoodenPlatform)
                {

                }
                else if (sonic.Velocity.X >= 8f)
                {
                    sonic.Position = new Vector2(block.BoundingBox().Left - sonic.BoundingBox().Width, sonic.Position.Y);
                } else
                {
                    sonic.Position = new Vector2(block.BoundingBox().Right, sonic.Position.Y);
                }
            }
            else if (collisionType == Direction.Up)
            {
                if (block is VideoMonitor /*&& IsSonicAttacking(sonic)*/)
                {
                    block.Interact();
                    sonic.Position = sonic.Position + new Vector2(0, -15f);
                    sonic.Velocity = new Vector2(0, -2f);
                    sonic.Jump();
                }

                else if (block is WoodenPlatform)
                {
                    platform = (WoodenPlatform)block;
                    block.Interact();
                    sonic.Position = new Vector2(sonic.Position.X, block.BoundingBox().Top - sonic.BoundingBox().Height) + GetVector(platform.State);
                    sonic.OnGround = true;
                    ScoreControl.RestartMulitplier();
                }

                else
                {
                    //placeholder     
                    sonic.OnGround = true;
                    ScoreControl.RestartMulitplier();
                    sonic.Position = new Vector2(sonic.Position.X, block.BoundingBox().Top - sonic.BoundingBox().Height);
                }
                ((Sonic)sonic).JumpCount = 0;

            }
            else if (collisionType == Direction.Down)
            {

                sonic.Position = new Vector2 (sonic.Position.X, block.BoundingBox().Bottom);
               

            }
            else if (collisionType == Direction.None)
            {
                //Do nothing                                        
            }
        }

        /*public bool IsSonicAttacking(ISonic sonic)
        {
            bool isAttackingLeft = (sonic.sonicState is LeftJumpingSonicState || sonic.sonicState is LeftBallSonicState || sonic.sonicState is LeftFastBallSonicState);
            bool isAttackingRight = (sonic.sonicState is RightJumpingSonicState || sonic.sonicState is RightBallSonicState || sonic.sonicState is RightFastBallSonicState);
            return isAttackingLeft || isAttackingRight;
        }*/


        private static Vector2 GetVector(IPlatformState recieved)
        {
            if (recieved is UpMovingWoodenPlatformState) { return new Vector2(0, -1); }
            else if (recieved is DownMovingWoodenPlatformState) { return new Vector2(0, 1); }
            else if (recieved is LeftMovingWoodenPlatformState) { return new Vector2(-1, 0); }
            else if (recieved is RightMovingWoodenPlatformState) { return new Vector2(1, 0); }
            else { return new Vector2(0, 0); }              
        }

        
    }
}
