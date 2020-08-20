using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class RightFacingAttackBuzzBomberSprite : IEnemySprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private Texture2D enemySpriteSheet;
        private Rectangle destinationRectangle;
        public bool SpawnProjectile { get; set; }
        public bool AttackFinished { get; set; }
        public RightFacingAttackBuzzBomberSprite()
        {
            enemySpriteSheet = AssetStorage.EnemySpriteSheet;
            currentFrame = RightFacingAttackBuzzBomberStartFrame;
            endFrame = RightFacingAttackBuzzBomberEndFrame;
            updateDelayCounter = DelayCountStartValue;
            SpawnProjectile = false;
            AttackFinished = false;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = BuzzBomberSpriteWidth;
            int height = BuzzBomberSpriteHeight;
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, BuzzBomberSpriteSourceY, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(enemySpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (updateDelayCounter % DelayTimeTen == ZERO)
            {
                if (currentFrame == endFrame)
                {
                    currentFrame = RightFacingAttackBuzzBomberStartFrame;
                    AttackFinished = true;
                }
                else
                {
                    SpawnProjectile = true;
                    currentFrame++;
                }
            }
        }
        public Rectangle BoundingBox()
        {
            return destinationRectangle;
        }
    }
}
