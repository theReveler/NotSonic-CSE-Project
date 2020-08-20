using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static NotSonicGame.AssetStorage;
using static NotSonicGame.Game1;
using static NotSonicGame.GameUtility;
using static NotSonicGame.EnemyUtility;



namespace NotSonicGame
{
    class MainMenu : IGameState
    {
        private int updateDelayCounter;
        private int sonicCurrentFrame;
        private gameState gameState;
        private int index;
        private static int options = 4;
        private int cursorCooldown = 40;
        private GraphicsDevice graphicsDevice;

        public gameState GameState { get { return gameState; } }

        public MainMenu(GraphicsDevice graphicsDevice)
        {
            gameState = gameState.menu;
            this.graphicsDevice = graphicsDevice;

            sonicCurrentFrame = TitleScreenSonicStartFrame;
            updateDelayCounter = DelayCountStartValue;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(blendState: BlendState.AlphaBlend);
            DrawBackground(spriteBatch);
            DrawText(spriteBatch);
            spriteBatch.End();
        }

        public void Update()
        {
            if (cursorCooldown > 0)
               cursorCooldown--;
        }

        private void DrawBackground(SpriteBatch spriteBatch)
        {

                Rectangle sourceRectangle = new Rectangle(0, 0, 1527, 1070);
                Rectangle destinationRectangle = new Rectangle(0, 0, 750, 525); ;
                spriteBatch.Draw(MainMenuSplash, destinationRectangle, sourceRectangle, Color.White);
            
        }
        private void DrawText(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(Noodle32, "Classic", new Vector2(510, 150) + new Vector2(2, 1), MainTextShadow);         
            spriteBatch.DrawString(Noodle32, "Time          Attack", new Vector2(510, 200) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Infinite          Run", new Vector2(510, 250) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Credits", new Vector2(510, 300) + new Vector2(2, 1), MainTextShadow);

            switch (index)
            {
                case 0: spriteBatch.DrawString(Noodle32, "Classic          <", new Vector2(510, 150), HighlightTextColor);
                    spriteBatch.DrawString(Noodle32, "Time          Attack", new Vector2(510, 200), MainTextColor);
                    spriteBatch.DrawString(Noodle32, "Infinite          Run", new Vector2(510, 250), MainTextShadow);
                    spriteBatch.DrawString(Noodle32, "Credits", new Vector2(510, 300), MainTextColor);
                    break;
                case 1: spriteBatch.DrawString(Noodle32, "Time          Attack          <", new Vector2(510, 200), HighlightTextColor);
                    spriteBatch.DrawString(Noodle32, "Classic", new Vector2(510, 150), MainTextColor);
                    spriteBatch.DrawString(Noodle32, "Infinite          Run", new Vector2(510, 250), MainTextShadow);
                    spriteBatch.DrawString(Noodle32, "Credits", new Vector2(510, 300), MainTextColor);
                    break;
                case 2: spriteBatch.DrawString(Noodle32, "Infinite          Run          <", new Vector2(510, 250), MainTextShadow);
                    spriteBatch.DrawString(Noodle32, "Classic", new Vector2(510, 150), MainTextColor);
                    spriteBatch.DrawString(Noodle32, "Time          Attack", new Vector2(510, 200), MainTextColor);
                    spriteBatch.DrawString(Noodle32, "Credits", new Vector2(510, 300), MainTextColor);
                    break;
                case 3: spriteBatch.DrawString(Noodle32, "Credits          <", new Vector2(510, 300), HighlightTextColor);
                    spriteBatch.DrawString(Noodle32, "Classic", new Vector2(510, 150), MainTextColor);
                    spriteBatch.DrawString(Noodle32, "Time          Attack", new Vector2(510, 200), MainTextColor);
                    spriteBatch.DrawString(Noodle32, "Infinite          Run", new Vector2(510, 250), MainTextShadow);
                    break;
            }

        }

        public void CycleUp()
        {
            if (cursorCooldown == 0)
            {
                if (index == 0)
                {
                    index = options - 1;
                }
                else
                    index--;
                cursorCooldown = 12;
            }
        }

        public void CycleDown()
        {
            if (cursorCooldown == 0)
            {
                if (index == options - 1)
                {
                    index = 0;
                }
                else
                    index++;               
                cursorCooldown = 12;
            }
        }

        public void StartMode(Game1 game1)
        {
            if (cursorCooldown == 0)
            {
                switch (index)
                {
                    case 0: //Normal Game
                        game1.SetToPlayState();
                        game1.ResumePlay();
                        break;
                    case 1: //Infinite
                        game1.SetToRandomState();
                        game1.ResumePlay();
                        break;
                    case 3:
                        game1.State = new CreditsState();
                        break;
                }
            }
        }
    }
}

