using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class AttackCrabmeatSprite : IEnemySprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private Texture2D enemySpriteSheet;
        private Rectangle destinationRectangle;
        public bool SpawnProjectiles { get; set; }
        public bool AttackFinished { get; set; }

        public AttackCrabmeatSprite()
        {
            enemySpriteSheet = AssetStorage.EnemySpriteSheet;
            currentFrame = AttackCrabmeatStartFrame;
            endFrame = AttackCrabmeatEndFrame;
            updateDelayCounter = DelayCountStartValue;
            SpawnProjectiles = false;
            AttackFinished = false;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = CrabmeatWidth;
            int height = CrabmeatHeight;
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, CrabmeatSourceY, width, height);
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(enemySpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (updateDelayCounter % DelayTime20 == ZERO)
            {
                if (currentFrame == endFrame)
                {
                    currentFrame = AttackCrabmeatStartFrame;
                    AttackFinished = true;
                }
                else
                {
                    SpawnProjectiles = true;
                    currentFrame += TWO;
                }
            }
        }
        public Rectangle BoundingBox()
        {
            return destinationRectangle;
        }
    }
}
