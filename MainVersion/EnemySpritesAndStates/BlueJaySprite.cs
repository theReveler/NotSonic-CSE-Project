using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class BlueJaySprite : ISprite
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

        public BlueJaySprite(Vector2 position)
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

        public Rectangle BoundingBox()
        {
            return destinationRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = BlueJayWidth;
            int height = BlueJayHeight;
            int widthOffset = (int)BlueJayOffSet.X;
            int heightOffset = (int)BlueJayOffSet.Y;
            Rectangle sourceRectangle = new Rectangle(width * currentFrame, BlueJaySourceY, width, height);
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
    }
}
