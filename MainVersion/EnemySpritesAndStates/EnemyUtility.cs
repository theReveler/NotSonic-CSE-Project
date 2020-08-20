using Microsoft.Xna.Framework;
using System;

namespace NotSonicGame
{
    public static class EnemyUtility
    {
        public static int ProjectileRemoveHeight { get { return 3000; } }
        public static int ProjectileRemoveLeftDistance { get { return -1000; } }
        public static int ProjectileRemoveRightDistance { get { return 100000000; } }
        public static int DelayCountMax { get { return 10000; } }
        public static int DelayCountStartValue { get { return 0; } }
        public static int DelayTimeTwo { get { return 2; } }
        public static int DelayTimeFive { get { return 5; } }
        public static int DelayTimeEight { get { return 8; } }
        public static int DelayTimeTen { get { return 10; } }
        public static int DelayTime15 { get { return 15; } }
        public static int DelayTime20 { get { return 20; } }
        public static int DelayTime50 { get { return 50; } }
        public static int ZERO { get { return 0; } }
        public static int TWO { get { return 2; } }
        public static int THREE { get { return 3; } }
        public static int FOUR { get { return 4; } }
        public static int MoveOneUnit { get { return 1; } }

        private static Random rnd = new Random();
        public static Random Randon_Number_Generater { get { return rnd; } }

        //BuzzBomber Values
        public static int BuzzBomberSpriteSourceY { get { return 6; } }
        public static int BuzzBomberSpriteWidth { get { return 47; } }
        public static int BuzzBomberSpriteHeight { get { return 36; } }
        public static int BuzzBomberPatrolDistance { get { return 100; } }
        public static int LeftFacingAttackBuzzBomberSpriteStartFrame { get { return 4; } }
        public static int LeftFacingAttackBuzzBomberSpriteEndFrame { get { return 5; } }
        public static int LeftIdleBuzzBomberStartFrame { get { return 3; } }
        public static int LeftMovingBuzzBomberStartFrame { get { return 0; } }
        public static int LeftMovingBuzzBomberEndFrame { get { return 1; } }
        public static int RightFacingAttackBuzzBomberStartFrame { get { return 6; } }
        public static int RightFacingAttackBuzzBomberEndFrame { get { return 7; } }
        public static Vector2 BuzzBomberRightProjectileOffSet { get { return new Vector2(26, 30); } }
        public static int RightIdleBuzzBomberStartFrame { get { return 8; } }
        public static int RightMovingBuzzBomberStartFrame { get { return 10; } }
        public static int RightMovingBuzzBomberEndFrame { get { return 11; } }

        //Cannon Values
        public static int CannonWidth { get { return 53; } }
        public static int CannonHeight { get { return 32; } }
        public static int IdleCannonWidth { get { return 42; } }
        public static int IdleCannonHeight { get { return 27; } }

        private static Rectangle[] leftAttackCannonSourceRectangles = { new Rectangle(647, 342, 42, 27), new Rectangle(655, 374, 34, 33), new Rectangle(621, 374, 30, 34), new Rectangle(578, 379, 39, 28), new Rectangle(503, 383, 71, 24), new Rectangle(429, 373, 70, 34), new Rectangle(360, 372, 65, 35), new Rectangle(309, 372, 47, 35) };
        public static Rectangle[] GetLeftAttackCannonSourceRectangles() { return leftAttackCannonSourceRectangles; }

        private static Vector2[] leftAttackCannonSourceRectanglesOffSets = { new Vector2(0, 0), new Vector2(7, 6), new Vector2(11, 6), new Vector2(5, 1), new Vector2(-23, -3), new Vector2(-28, 7), new Vector2(-23, 8), new Vector2(-5, 8) };
        public static Vector2[] GetLeftAttackCannonSourceRectanglesOffSets() { return leftAttackCannonSourceRectanglesOffSets;  }
        public static int LeftAttackCannonStartFrame { get { return 0; } }
        public static int LeftAttackCannonSpwanProjectileFrame { get { return 4; } }
        public static int LeftAttackCannonEndFrame { get { return 7; } }
        public static Vector2 LeftCannonProjectileOffset { get { return new Vector2(30, 4); } }
        public static int LeftDeadCannonStartFrame { get { return 5; } }
        public static int LeftDeadCannonEndFrame { get { return 0; } }
        public static Vector2 LeftDeadCannonSource { get { return new Vector2(387, 411); } }
        public static int LeftIdleCannonSourceX { get { return 647; } }
        public static int LeftIdleCannonSourceY { get { return 342; } }

        private static Rectangle[] rightAttackCannonSourceRectangles = { new Rectangle(159, 448, 42, 27), new Rectangle(159, 480, 34, 33), new Rectangle(197, 479, 30, 34), new Rectangle(231, 485, 39, 28), new Rectangle(274, 489, 71, 24), new Rectangle(349, 479, 70, 34), new Rectangle(423, 478, 65, 35), new Rectangle(492, 478, 47, 35) };
        public static Rectangle[] GetRightAttackCannonSourceRectangles() { return rightAttackCannonSourceRectangles; }

        private static Vector2[] rightAttackCannonSourceRectanglesOffSets = { new Vector2(0, 0), new Vector2(1, 6), new Vector2(1, 7), new Vector2(-2, 1), new Vector2(-6, -3), new Vector2(0, 7), new Vector2(0, 8), new Vector2(0, 8) };
        public static Vector2[] GetRightAttackCannonSourceRectanglesOffSets() { return rightAttackCannonSourceRectanglesOffSets; }
        public static int RightAttackCannonStartFrame { get { return 0; } }
        public static int RightAttackCannonEndFrame { get { return 7; } }
        public static int RightAttackCannonSpwanProjectileFrame { get { return 4; } }
        public static Vector2 RightCannonProjectileOffset { get { return new Vector2(64, 4); } }
        public static int RightDeadCannonStartFrame { get { return 0; } }
        public static int RightDeadCannonEndFrame { get { return 5; } }
        public static Vector2 RightDeadCannonSource { get { return new Vector2(157, 515); } }
        public static Vector2 RightIdleSource { get { return new Vector2(159, 448); } }

        //Chopper Values
        public static int ChopperWidth { get { return 31; } }
        public static int ChopperHeight { get { return 33; } }
        public static int ChopperSourceY { get { return 150; } }
        public static int ChopperPatrolDistance { get { return 100; } }
        public static int LeftJumpingChopperStartFrame { get { return 0; } }
        public static int LeftJumpingChopperEndFrame { get { return 1; } }
        public static int RightJumpingChopperStartFrame { get { return 2; } }
        public static int RightJumpingChopperEndFrame { get { return 3; } }

        //Crabmeat Values
        public static int CrabmeatPatrolDistance { get { return 24; } }
        public static int CrabmeatWidth { get { return 49; } }
        public static int CrabmeatHeight { get { return 32; } }
        public static int CrabmeatSourceY { get { return 194; } }
        public static int AttackCrabmeatStartFrame { get { return 1; } }
        public static int AttackCrabmeatEndFrame { get { return 3; } }
        public static int LeftProjectileCrabmeatOffSetX { get { return 26; } }
        public static int LeftProjectileCrabmeatOffSetY { get { return 13; } }
        public static int RightProjectileCrabmeatOffSetX { get { return 62; } }
        public static int RightProjectileCrabmeatOffSetY { get { return 13; } }
        public static int LeftProjectileArcOffSetX { get { return 5; } }
        public static int LeftProjectileArcOffSetY { get { return 10; } }
        public static double ProjectileArcFactor { get { return .5; } }
        public static int RightProjectileArcOffSetX { get { return 5; } }
        public static int RightProjectileArcOffSetY { get { return 10; } }
        public static int IdleCrabmeatFrame { get { return 1; } }
        public static int LeftMovingCrabmeatStartFrame { get { return 1; } }
        public static int LeftMovingCrabmeatResetFrame { get { return 1; } }
        public static int LeftMovingCrabmeatEndFrame { get { return 0; } }
        public static int RightMovingCrabmeatStartFrame { get { return 1; } }
        public static int RightMovingCrabmeatEndFrame { get { return 2; } }
        public static int RightMovingCrabmeatResetFrame { get { return 0; } }

        //MotoBug Values
        public static int MotoBugWidth { get { return 60; } }
        public static int MotoBugHeight { get { return 31; } }
        public static int MotoBugSourceY { get { return 110; } }
        public static int MotoBugPatrolDistance { get { return 100; } }
        public static int LeftMovingMotoBugStartFrame { get { return 0; } }
        public static int LeftMovingMotoBugEndFrame { get { return 5; } }
        public static int RightMovingMotoBugStartFrame { get { return 6; } }
        public static int RightMovingMotoBugEndFrame { get { return 11; } }

        //Aniaml Values
        public static int AnimalStartFrame { get { return 0; } }
        public static int AnimalLeftMovingFrame { get { return 1; } }
        public static int AnimalEndFrame { get { return 2; } }
        public static int AnimalJumpHeight { get { return 25; } }
        public static int AnimalLeftJumpHeight { get { return 50; } }
        public static int BlueJayWidth { get { return 17; } }
        public static int BlueJayHeight { get { return 21; } }
        public static Vector2 BlueJayOffSet { get { return new Vector2(11, 9); } }
        public static int BlueJaySourceY { get { return 368; } }
        public static int BunnyWidth { get { return 17; } }
        public static int BunnyHeight { get { return 25; } }
        public static Vector2 BunnyOffSet { get { return new Vector2(16, 5); } }
        public static int BunnySourceY { get { return 437; } }
        public static int ChickenWidth { get { return 16; } }
        public static int ChickenHeight { get { return 24; } }
        public static Vector2 ChickenOffSet { get { return new Vector2(11, 3); } }
        public static int ChickenSourceY { get { return 412; } }
        public static int SealWidth { get { return 17; } }
        public static int SealHeight { get { return 21; } }
        public static Vector2 SealOffSet { get { return new Vector2(5, 5); } }
        public static int SealSourceY { get { return 390; } } 

        //Explosion Values
        public static int ExplosionStartFrame { get { return 0; } }
        public static int ExplosionEndFrame { get { return 4; } }
        public static int ExplosionWidth { get { return 39; } }
        public static int ExplosionHeight { get { return 39; } }
        public static int ExplosionSourceY { get { return 288; } }

        //Projectiles
        public static int ProjectileWidth { get { return 13; } }
        public static int ProjectileHeight { get { return 13; } }
        public static int ProjectileSourceY { get { return 66; } }
        public static int YellowProjectileStartFrame { get { return 0; } }
        public static int YellowProjectileEndFrame { get { return 1; } }
        public static int RedProjectileStartFrame { get { return 1; } }
        public static int RedProjectileEndFrame { get { return 2; } }

        //boss
        public static bool HasStartBossIntro { get; set; } = false;
        public static bool HasStartBossFight { get; set; } = false;
    }
}
