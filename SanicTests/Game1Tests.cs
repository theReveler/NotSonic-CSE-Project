using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using NotSonicGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static NotSonicGame.Directions;

namespace NotSonicGame.Tests
{
    [TestClass()]
    public class Game1Tests
    {
        [TestMethod()]
        public void SonicCollidesWithSimpleTerrainFromLeft()
        {
            var gameObject1 = new Sonic(new Vector2(0, 20));
            var gameObject2 = new SimpleTerrain(new Vector2(30, 33));
            var collisionDetector = new CollisionDetector();
            var collisionType = collisionDetector.GetCollisionType(gameObject1, gameObject2);
            collisionDetector.HandleCollision(gameObject1, gameObject2);

            Assert.AreEqual(collisionType, Direction.Left);
            Assert.AreEqual(gameObject1.Position, new Vector2(-3, 20));
            Assert.AreEqual(gameObject2.BoundingBox().X, 30);
            Assert.AreEqual(gameObject2.BoundingBox().Y, 35);
        }

        [TestMethod()]
        public void SonicCollidesWithSimpleTerrainFromRight()
        {
            var gameObject1 = new Sonic(new Vector2(63, 20));
            gameObject1.SonicState = new LeftIdleSonicState(gameObject1);
            var gameObject2 = new SimpleTerrain(new Vector2(30, 33));
            var collisionDetector = new CollisionDetector();
            var collisionType = collisionDetector.GetCollisionType(gameObject1, gameObject2);
            collisionDetector.HandleCollision(gameObject1, gameObject2);

            Assert.AreEqual(collisionType, Direction.Right);
            Assert.AreEqual(gameObject1.Position, new Vector2(74, 20));
            Assert.AreEqual(gameObject2.BoundingBox().X, 30);
            Assert.AreEqual(gameObject2.BoundingBox().Y, 35);
        }

        [TestMethod()]
        public void SonicCollidesWithSimpleTerrainFromUp()
        {
            var gameObject1 = new Sonic(new Vector2(0, 0));
            var gameObject2 = new SimpleTerrain(new Vector2(0, 40));
            var collisionDetector = new CollisionDetector();
            var collisionType = collisionDetector.GetCollisionType(gameObject1, gameObject2);
            collisionDetector.HandleCollision(gameObject1, gameObject2);

            Assert.AreEqual(collisionType, Direction.Up);
            Assert.AreEqual(gameObject1.Position, new Vector2(0, -2));
            Assert.AreEqual(gameObject2.BoundingBox().X, 0);
            Assert.AreEqual(gameObject2.BoundingBox().Y, 42);
        }

        [TestMethod()]
        public void SonicCollidesWithSimpleTerrainFromDown()
        {
            var gameObject1 = new Sonic(new Vector2(0, 69));
            var gameObject2 = new SimpleTerrain(new Vector2(0, 40));
            var collisionDetector = new CollisionDetector();
            var collisionType = collisionDetector.GetCollisionType(gameObject1, gameObject2);
            collisionDetector.HandleCollision(gameObject1, gameObject2);

            Assert.AreEqual(collisionType, Direction.Down);
            Assert.AreEqual(gameObject1.Position, new Vector2(0, 82));
            Assert.AreEqual(gameObject2.BoundingBox().X, 0);
            Assert.AreEqual(gameObject2.BoundingBox().Y, 42);
        }
        [TestMethod()]
        public void RightIdleSonicCollidesWithEnemy()
        {
            var gameObject1 = new Sonic(new Vector2(0, 0));
            var gameObject2 = new MotoBug(new Vector2(0, 0));
            //var collisionDetector = new CollisionDetector();
            //var collisionType = collisionDetector.GetCollisionType(gameObject1, gameObject2);
            var collisionDetector = new SonicEnemyCollisionHandler();
            collisionDetector.HandleCollision(gameObject1, gameObject2, Direction.Up);

            Assert.IsTrue(gameObject1.SonicState is DeadSonicState);
            Assert.IsFalse(gameObject2.State is DeadMotoBugState);
        }
        [TestMethod()]
        public void LeftIdleSonicCollidesWithEnemy()
        {
            var gameObject1 = new Sonic(new Vector2(0, 0));
            var gameObject2 = new MotoBug(new Vector2(0, 0));
            //var collisionDetector = new CollisionDetector();
            //var collisionType = collisionDetector.GetCollisionType(gameObject1, gameObject2);
            var collisionDetector = new SonicEnemyCollisionHandler();

            gameObject1.MoveLeft();
            collisionDetector.HandleCollision(gameObject1, gameObject2, Direction.Up);

            Assert.IsTrue(gameObject1.SonicState is DeadSonicState);
            Assert.IsFalse(gameObject2.State is DeadMotoBugState);
        }
        [TestMethod()]
        public void RightBallSonicCollidesWithEnemy()
        {
            var gameObject1 = new Sonic(new Vector2(0, 0));
            var gameObject2 = new MotoBug(new Vector2(0, 0));
            //var collisionDetector = new CollisionDetector();
            //var collisionType = collisionDetector.GetCollisionType(gameObject1, gameObject2);
            var collisionDetector = new SonicEnemyCollisionHandler();

            gameObject1.Jump();
            collisionDetector.HandleCollision(gameObject1, gameObject2, Direction.Down);

            Assert.IsFalse(gameObject1.SonicState is DeadSonicState);
            Assert.IsTrue(gameObject2.State is DeadMotoBugState);
        }
        [TestMethod()]
        public void LeftBallSonicCollidesWithEnemy()
        {
            var gameObject1 = new Sonic(new Vector2(0, 0));
            var gameObject2 = new MotoBug(new Vector2(0, 0));
            //var collisionDetector = new CollisionDetector();
            //var collisionType = collisionDetector.GetCollisionType(gameObject1, gameObject2);
            var collisionDetector = new SonicEnemyCollisionHandler();

            gameObject1.MoveLeft();
            gameObject1.Jump();
            collisionDetector.HandleCollision(gameObject1, gameObject2, Direction.Down);

            Assert.IsFalse(gameObject1.SonicState is DeadSonicState);
            Assert.IsTrue(gameObject2.State is DeadMotoBugState);
        }
    }
}