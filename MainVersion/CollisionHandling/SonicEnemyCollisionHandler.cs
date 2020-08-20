using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.Directions;
using static NotSonicGame.AssetStorage;

namespace NotSonicGame
{
    public class SonicEnemyCollisionHandler : ICollision
    {
        public void HandleCollision(IGameObject gameObject1, IGameObject gameObject2, Direction collisionType)
        {
            bool enemyIsAlive = !(((IEnemy)gameObject2).State is IDeadEnemyState);
            if (gameObject2 is IBoss && gameObject1 is Sonic && collisionType != Direction.None)
            {
                HandleBossCollision((Sonic)gameObject1, (IBoss)gameObject2);
            }
            else if (gameObject2 is IEnemy && gameObject1 is Sonic && collisionType != Direction.None && enemyIsAlive)
            {
                HandleNonBossCollision((Sonic)gameObject1, (IEnemy)gameObject2);
            }

        }

        private void HandleBossCollision(IGameObject gameObject1, IGameObject gameObject2)
        {

        }

        private void HandleNonBossCollision(Sonic sonic, IEnemy enemy)
        {
            if ((sonic.SonicState is LeftJumpingSonicState) || (sonic.IsInvincible == true))
            {
                enemy.TakeDamage();
                ScoreControl.EnemyDefeated(enemy.Position);
                sonic.Position = sonic.Position + new Vector2(0, -15f);
                sonic.Velocity = new Vector2(sonic.Velocity.X, -4.5f - sonic.JumpCount / 2f);
                sonic.Jump();
                BounceOffEnemeySoundEffect.Play();
            }
            else if ((sonic.SonicState is RightJumpingSonicState) || (sonic.IsInvincible == true))
            {
                enemy.TakeDamage();
                ScoreControl.EnemyDefeated(enemy.Position);
                sonic.Position = sonic.Position + new Vector2(0, -15f);
                sonic.Velocity = new Vector2(sonic.Velocity.X, -4.5f - sonic.JumpCount / 2f);
                sonic.Jump();
                BounceOffEnemeySoundEffect.Play();
            }
            else if ((sonic.SonicState is LeftBallSonicState) || (sonic.IsInvincible == true))
            {
                enemy.TakeDamage();
                ScoreControl.EnemyDefeated(enemy.Position);
                sonic.Position = sonic.Position + new Vector2(0, -15f);
                sonic.Velocity = new Vector2(sonic.Velocity.X, -4.5f - sonic.JumpCount / 2f);
                sonic.Jump();
                BounceOffEnemeySoundEffect.Play();
            }
            else if ((sonic.SonicState is RightBallSonicState) || (sonic.IsInvincible == true))
            {
                enemy.TakeDamage();
                ScoreControl.EnemyDefeated(enemy.Position);
                sonic.Position = sonic.Position + new Vector2(0, -15f);
                sonic.Velocity = new Vector2(sonic.Velocity.X, -4.5f - sonic.JumpCount / 2f);
                sonic.Jump();
                BounceOffEnemeySoundEffect.Play();
            }
            else
                sonic.TakeDamage();

        }
    }
}
