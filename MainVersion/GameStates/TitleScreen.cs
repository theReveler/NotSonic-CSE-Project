using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static NotSonicGame.AssetStorage;
using static NotSonicGame.Game1;
using static NotSonicGame.GameUtility;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class TitleScreen : IGameState
    {
        private int updateDelayCounter;
        private int sonicCurrentFrame;
        private Rectangle[] sonicSourceRectangles = GetTitleScreenSonicSourceRectangles();
        private gameState gameState;
        private int flashFlag;

        //add fade in here



        public gameState GameState { get { return gameState; } }

        public TitleScreen()
        {
            gameState = gameState.titleScreen;
            sonicCurrentFrame = TitleScreenSonicStartFrame;
            updateDelayCounter = DelayCountStartValue;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            DrawBackground(spriteBatch);
            DrawLogo(spriteBatch);
            DrawSonic(spriteBatch);
            if (flashFlag < FOUR)
                DrawPrompt(spriteBatch);
            spriteBatch.End();
        }

        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (updateDelayCounter % DelayTimeEight == ZERO)
            {
                flashFlag++;
                if (flashFlag > FOUR)
                    flashFlag = ZERO;
                if (sonicCurrentFrame == TitleScreenSonicEndFrame)
                    sonicCurrentFrame = TitleScreenSonicResetFrame;
                else
                    sonicCurrentFrame++;
            }
        }

        private static void DrawBackground(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = TitleScreenBackGroundSourceRectangle;
            Rectangle destinationRectangle = TitleScreenBackGroundDestRectangle;
            spriteBatch.Draw(SonicTitleScreen, destinationRectangle, sourceRectangle, Color.White);
        }
        private static void DrawLogo(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = TitleScreenLogoSourceRectangle;
            Rectangle destinationRectangle = TitleScreenLogoDestRectangle;
            spriteBatch.Draw(SonicTitleScreen, destinationRectangle, sourceRectangle, Color.White);
        }
        private void DrawSonic(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = sonicSourceRectangles[sonicCurrentFrame];
            Rectangle destinationRectangle = TitleScreenSonicDestRectangle;
            spriteBatch.Draw(SonicTitleScreen, destinationRectangle, sourceRectangle, Color.White);
        }

        private void DrawPrompt(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Noodle32, "Press          Any          Key         To              Continue_", new Vector2(160, 430) + new Vector2(2, 1), Color.Black);
            spriteBatch.DrawString(Noodle32, "Press          Any          Key         To              Continue_", new Vector2(160, 430), Color.White);
        }
    }
}
