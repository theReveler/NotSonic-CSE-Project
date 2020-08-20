using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class SealSprite : ISprite
    {
        private int currentFrame;
        private int endFrame;
        private int updateDelayCounter;
        private Texture2D spriteSheet;
        private Rectangle destinationRectangle;
        private bool movingUpOnly;
        private bool movingDownOnly;
        private bool movingUpAndLeft;
        private Vector2 startingPosition;
        private Vector2 position;

        public SealSprite(Vector2 position)
        {
            this.spriteSheet = AssetStorage.EnemySpriteSheet;
            this.position = position;
            startingPosition = position;
            movingUpOnly = true;
            movingDownOnly = false;
            movingUpAndLeft = false;
            currentFrame = AnimalStartFrame;
            endFrame = AnimalEndFrame;
            updateDelayCounter = DelayCountStartValue;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = SealWidth;
            int height = SealHeight;
            int widthOffset = (int)SealOffSet.X;
            int heightOffset = (int)SealOffSet.Y;
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, SealSourceY, width, height);
            destinationRectangle = new Rectangle((int)position.X + widthOffset, (int)position.Y + heightOffset, width, height);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }
        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (movingUpOnly)
            {
                if (updateDelayCounter % DelayTimeTwo == ZERO)
                {
                    position.Y--;
                    if (position.Y == startingPosition.Y - AnimalJumpHeight)
                    {
                        movingUpOnly = false;
                        movingDownOnly = true;
                    }
                }
            }
            else if (movingDownOnly)
            {
                position.Y++;
                if (position.Y == startingPosition.Y)
                {
                    movingDownOnly = false;
                    movingUpAndLeft = true;
                    currentFrame = AnimalLeftMovingFrame;
                }
            }
            //moving left loop
            else if (!movingUpOnly && !movingDownOnly)
            {
                if (updateDelayCounter % DelayTime15 == ZERO)
                {
                    if (currentFrame == endFrame)
                        currentFrame = AnimalLeftMovingFrame;
                    else
                        currentFrame++;
                }
                if (movingUpAndLeft)
                {
                    position.Y--;
                    if (position.Y == startingPosition.Y - AnimalLeftJumpHeight)
                        movingUpAndLeft = false;
                }
                else
                {
                    position.Y++;
                    if (position.Y == startingPosition.Y)
                        movingUpAndLeft = true;
                }
                position.X -= TWO;

            }
        }
        public Rectangle BoundingBox()
        {
            return destinationRectangle;
        }
    }
}
