using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static NotSonicGame.Directions;
using System;
using System.Linq;

namespace NotSonicGame
{
    public class CollisionDetector
    {
        private ICollision collision;
        private Direction collisionType;

        internal void Update(List<IGameObject> gameObjectList)
        {
            var sonics = from sonic in gameObjectList where sonic is ISonic select sonic;
            var enemies = from enemy in gameObjectList where enemy is IEnemy select enemy;
            var projectiles = from projectile in gameObjectList where projectile is IProjectile select projectile;
            var droppedRings = from ring in gameObjectList where ring is DroppedRing select ring;
            var gameObjectArray = gameObjectList.ToArray();

            foreach (ISonic sonic in sonics)
            {
                foreach (IGameObject gameObject2 in gameObjectArray)
                {
                    HandleCollision(sonic, gameObject2);
                }
            }
            foreach (IEnemy enemy in enemies)
            {
                foreach (IGameObject gameObject2 in gameObjectArray)
                {
                    HandleCollision(enemy, gameObject2);
                }
            }
            foreach(IProjectile projectile in projectiles.ToArray())
            {
                foreach (IGameObject gameObject2 in gameObjectArray)
                {
                    HandleCollision(projectile, gameObject2);
                }
            }
            foreach(IRing ring in droppedRings.ToArray())
            {
                foreach (IGameObject gameObject2 in gameObjectArray)
                {
                    HandleCollision(ring, gameObject2);
                }
            }
        }

        public void HandleCollision(IGameObject gameObject1, IGameObject gameObject2)
        {
            collision = null;
            if (gameObject1.Equals(gameObject2))
            {
                //Do Nothing - An Object cant collide with itself
            }
            else
            {
                collisionType = GetCollisionType(gameObject1, gameObject2);
                if (gameObject1 is ISonic)
                {
                    collision = GetSonicCollisionHandler(gameObject2);
                }
                else if (gameObject1 is IEnemy)
                {
                    collision = GetEnemyCollisionHandler(gameObject2);
                }
                else if (gameObject1 is IProjectile)
                {
                    collision = GetProjectileCollisionHandler(gameObject2);
                }
                else if (gameObject1 is IRing)
                {
                    collision = GetItemCollisionHandler(gameObject2);
                }

                if (collision != null)
                    collision.HandleCollision(gameObject1, gameObject2, collisionType);
            }
        }

        private ICollision GetSonicCollisionHandler(IGameObject gameObject)
        {
            if (gameObject is ISpike)
                return new SonicSpikeCollisionHandler();
            else if (gameObject is ISpring)
                return new SonicSpringCollisionHandler();
            else if (gameObject is IBlock)
                return new SonicBlockCollisionHandler();
            else if (gameObject is IEnemy)
                return new SonicEnemyCollisionHandler();
            else if (gameObject is IItem)
                return new SonicItemCollisionHandler();
            else if (gameObject is IProjectile)
                return new SonicProjectileCollisionHandler();
            else
                return null;
        }

        private static ICollision GetEnemyCollisionHandler(IGameObject gameObject)
        {
            if (gameObject is IBlock)
                return new EnemyBlockCollisionHandler();
            else
                return null;
        }
        private static ICollision GetProjectileCollisionHandler(IGameObject gameObject)
        {
            if (gameObject is IBlock)
                return new ProjectileBlockCollisionHandler();
            else
                return null;
        }
        private static ICollision GetItemCollisionHandler(IGameObject gameObject)
        {
            if (gameObject is IBlock)
                return new ItemBlockCollisionHandler();
            else
                return null;
        }
        //Decides what type of collision is occuring between the two GameObjects
        public Direction GetCollisionType(IGameObject gameObject1, IGameObject gameObject2)
        {
               Rectangle rectangle1 = gameObject1.BoundingBox();
               Rectangle rectangle2 = gameObject2.BoundingBox();

               //TODO - Change choice of collisionType based on centroid, not rectangle parts

               if (rectangle1.Intersects(rectangle2)) {
                    //rectangle1.Center.X 
                    //relative to second

                    int deltaX = rectangle1.Center.X - rectangle2.Center.X;
                    int deltaY = rectangle1.Center.Y - rectangle2.Center.Y;

                   // offset for the directions here is 22.5
                    Vector2 centersVector = new Vector2(rectangle1.Center.X - rectangle2.Center.X, rectangle1.Center.Y - rectangle2.Center.Y);
                    centersVector.Normalize();
                    float diagonalComp = 0.75f; //this is 45 degrees, small deadzone
                    if (centersVector.Y < -diagonalComp) {
                        collisionType = Direction.Up;
                    } else if (centersVector.Y > diagonalComp) {
                        collisionType = Direction.Down;
                    } else if (centersVector.X < -diagonalComp) {
                        collisionType = Direction.Left;
                    } else if (centersVector.X > diagonalComp) {
                        collisionType = Direction.Right;
                    } else {
                        collisionType = Direction.None;
                    }
               } else {
                    collisionType = Direction.None;
               }

            return collisionType;
        }
    }
}
