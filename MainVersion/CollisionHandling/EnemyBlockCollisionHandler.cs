using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static NotSonicGame.Directions;
namespace NotSonicGame
{
    class EnemyBlockCollisionHandler : ICollision
    {
        public void HandleCollision(IGameObject gameObject1, IGameObject gameObject2, Direction collisionType)
        {
            if (gameObject1 is IBoss)
            {
                HandleBossCollision((IBoss)gameObject1, (IBlock)gameObject2, collisionType);
            }
            else if (gameObject1 is IEnemy)
            {
                HandleNonBossCollision((IEnemy)gameObject1, (IBlock)gameObject2, collisionType);
            }   
        }
        private void HandleBossCollision(IBoss boss, IBlock block, Direction collisionType)
        {
            var intersection = Rectangle.Intersect(boss.BoundingBox(), block.BoundingBox());
            switch (collisionType)
            {
                case Direction.Left:
                    boss.Position = new Vector2(boss.Position.X + intersection.Width, boss.Position.Y);
                    break;
                case Direction.Right:
                    boss.Position = new Vector2(boss.Position.X - intersection.Width, boss.Position.Y);
                    break;
                case Direction.Up:
                    boss.Position = new Vector2(boss.Position.X, boss.Position.Y - intersection.Height);
                    if (boss.State is ChillPenguinIntroState)
                        boss.State.ChangeDirection();
                    else if (boss.State is ChillPenguinFallingState)
                        boss.State.Idle();
                        break;
                case Direction.Down:
                    boss.Position = new Vector2(boss.Position.X, boss.Position.Y + intersection.Height);
                    break;
                case Direction.None:
                    break;
                default:
                    break;
            }
        }

        private void HandleNonBossCollision(IEnemy enemy, IBlock block, Direction collisionType)
        {
            var intersection = Rectangle.Intersect(enemy.BoundingBox(), block.BoundingBox());
            switch (collisionType)
            {
                case Direction.Left:
                    enemy.Position = new Vector2(enemy.Position.X + intersection.Width, enemy.Position.Y);
                    break;
                case Direction.Right:
                    enemy.Position = new Vector2(enemy.Position.X - intersection.Width, enemy.Position.Y);
                    break;
                case Direction.Up:
                    enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y - intersection.Height);
                    break;
                case Direction.Down:
                    enemy.Position = new Vector2(enemy.Position.X, enemy.Position.Y + intersection.Height);
                    break;
                case Direction.None:
                    break;
                default:
                    break;
            }
        }
    }
}
