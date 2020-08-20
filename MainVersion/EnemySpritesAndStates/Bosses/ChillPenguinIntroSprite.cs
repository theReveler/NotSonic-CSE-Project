using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.AssetStorage;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class ChillPenguinIntroSprite : IEnemySprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private Texture2D spriteSheet;
        private Rectangle[] sourceRectangles = { new Rectangle(502, 202, 72, 90), new Rectangle(22, 4, 78, 74), new Rectangle(106, 6, 80, 72), new Rectangle(196, 12, 78, 66), new Rectangle(286, 2, 86, 76), new Rectangle(376, 2, 88, 76), new Rectangle(470, 4, 80, 74)};
        private Vector2[] offsets = { new Vector2(5, 0), new Vector2(0, 18), new Vector2(-1, 20), new Vector2(0, 26), new Vector2(0, 16), new Vector2(0, 16), new Vector2(0, 18)};
        private Rectangle destinationRectangle;
        private bool introFinished;
        public bool IntroFinished { get { return introFinished; } }
        public bool IsFalling { get; set; }
        public ChillPenguinIntroSprite()
        {
            currentFrame = 0;
            endFrame = 6;
            updateDelayCounter = 0;
            IsFalling = true;
            introFinished = false;
            spriteSheet = BossSpriteSheet;
        }
        public Rectangle BoundingBox()
        {
            return destinationRectangle;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            destinationRectangle = new Rectangle((int)position.X + (int)offsets[currentFrame].X, (int)position.Y + (int)offsets[currentFrame].Y, sourceRectangles[currentFrame].Width, sourceRectangles[currentFrame].Height);
            spriteBatch.Draw(BossSpriteSheet, destinationRectangle, sourceRectangles[currentFrame], Color.White);
        }

        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (updateDelayCounter % 10 == ZERO)
            {
                UpdateCurrentFrame();
            }
        }

        private void UpdateCurrentFrame()
        {
            if (currentFrame == endFrame && updateDelayCounter % 50 == ZERO)
            {
                introFinished = true;
                HasStartBossFight = true;
            }
            else if (!IsFalling && currentFrame != endFrame)
                currentFrame++;
        }
    }
}
