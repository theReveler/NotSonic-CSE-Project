using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.Game1;
using static NotSonicGame.GameUtility;
using static NotSonicGame.AssetStorage;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    class PauseState : IGameState
    {
        private gameState gameState;
        private int index;
        private static int options = 4;
        private int cursorCooldown = 40;

        public gameState GameState { get { return gameState; } }

        public PauseState()
        {
            gameState = gameState.pause;
            MediaPlayer.Volume = BackGroundMusicPausedVolume;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();           
            DrawBackground(spriteBatch);
            spriteBatch.DrawString(Noodle32, "Paused_", new Vector2(280, 210) + new Vector2(2, 1), Color.Black);
            spriteBatch.DrawString(Noodle32, "Paused_", new Vector2(280, 210), Color.White);
            DrawText(spriteBatch);
            spriteBatch.End();
        }

        private void DrawBackground(SpriteBatch spriteBatch)
        {
                Rectangle sourceRectangle = new Rectangle(0, 0, 1527, 1070);
                Rectangle destinationRectangle = new Rectangle(0, 0, 750, 525); ;
                spriteBatch.Draw(MainMenuSplash, destinationRectangle, sourceRectangle, new Color(0, 0, 0, 255));
            
        }

        private void DrawText(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Noodle32, "Resume", new Vector2(460, 150) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Resume", new Vector2(460, 150), MainTextColor);
            spriteBatch.DrawString(Noodle32, "Restart", new Vector2(460, 200) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Restart", new Vector2(460, 200), MainTextColor);
            spriteBatch.DrawString(Noodle32, "Main          Menu", new Vector2(460, 250) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Main          Menu", new Vector2(460, 250), MainTextColor);

            spriteBatch.DrawString(Noodle32, "Exit          To          Desktop", new Vector2(460, 300) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Exit          To          Desktop", new Vector2(460, 300), MainTextColor);

            switch (index)
            {
                case 0: spriteBatch.DrawString(Noodle32, "Resume          <", new Vector2(460, 150), HighlightTextColor); break;
                case 1: spriteBatch.DrawString(Noodle32, "Restart          <", new Vector2(460, 200), HighlightTextColor); break;
                case 2: spriteBatch.DrawString(Noodle32, "Main          Menu          <", new Vector2(460, 250), HighlightTextColor); break;
                case 3: spriteBatch.DrawString(Noodle32, "Exit          To          Desktop          <", new Vector2(460, 300), HighlightTextColor); break;
            }
        }

        public void Update()
        {
            if (cursorCooldown > 0)
                cursorCooldown--;
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
                    case 0: //Resume
                        game1.ResumePlay();
                        MediaPlayer.Volume = 0.2f;
                        break;
                    case 1: //Restart
                        HUD.Lives = 3;
                        HUD.Score = 0;
                        HUD.Time = 0;
                        game1.Restart();
                        break;
                    case 2: //To Menu
                        HUD.Lives = 3;
                        HUD.Score = 0;
                        HUD.Time = 0;
                        game1.SetToMenuState();
                        break;
                    case 3: //quit
                        game1.Exit();
                        break;
                }
            }
        }
    }
}
