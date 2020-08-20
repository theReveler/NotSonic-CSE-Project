using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class RightAttackCannonSprite : IEnemySprite
    {
        private int updateDelayCounter;
        private int currentFrame;
        private int endFrame;
        private Texture2D enemySpriteSheet;
        private Rectangle destinationRectangle;
        private Rectangle[] sourceRectangle = GetRightAttackCannonSourceRectangles();
        private Vector2[] offsets = GetRightAttackCannonSourceRectanglesOffSets();

        public bool SpawnProjectile { get; set; }
        public bool AttackFinished { get; set; }
        public RightAttackCannonSprite()
        {
            enemySpriteSheet = AssetStorage.EnemySpriteSheet;
            currentFrame = RightAttackCannonStartFrame;
            endFrame = RightAttackCannonEndFrame;
            updateDelayCounter = DelayCountStartValue;
            SpawnProjectile = false;
            AttackFinished = false;
        }
        public Rectangle BoundingBox()
        {
            return destinationRectangle;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle source = sourceRectangle[currentFrame];
            Vector2 offset = offsets[currentFrame];
            destinationRectangle = new Rectangle((int)position.X + (int)offset.X, (int)position.Y - (int)offset.Y, source.Width, source.Height);

            spriteBatch.Draw(enemySpriteSheet, destinationRectangle, sourceRectangle[currentFrame], Color.White);
        }

        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (updateDelayCounter % DelayTimeEight == ZERO)
            {
                if (currentFrame == endFrame)
                {
                    currentFrame = RightAttackCannonStartFrame;
                    AttackFinished = true;
                }
                else
                {
                    currentFrame++;
                    if (currentFrame == RightAttackCannonSpwanProjectileFrame)
                        SpawnProjectile = true;
                }
            }
        }
    }
}
