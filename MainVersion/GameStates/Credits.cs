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
    class CreditsState : IGameState
    {
        private gameState gameState;
        private int index;
        private static int options = 4;
        private int cursorCooldown = 40;

        public gameState GameState { get { return gameState; } }

        public CreditsState()
        {
            gameState = gameState.subMenu;
            MediaPlayer.Volume = BackGroundMusicPausedVolume;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();           
            DrawBackground(spriteBatch);
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
            spriteBatch.DrawString(Noodle14, "Press          ESC          To          Return", new Vector2(10, 10) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle14, "Press          ESC          To          Return", new Vector2(10, 10), MainTextColor);
            spriteBatch.DrawString(Noodle32, "Not          Sonic          Team//", new Vector2(320, 150) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Not          Sonic          Team//", new Vector2(320, 150), MainTextColor);
            spriteBatch.DrawString(Noodle32, "Matt          Rowe", new Vector2(360, 200) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Matt          Rowe", new Vector2(360, 200), MainTextColor);
            spriteBatch.DrawString(Noodle32, "Tre          Plowman", new Vector2(360, 250) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Tre          Plowman", new Vector2(360, 250), MainTextColor);
            spriteBatch.DrawString(Noodle32, "Zack          Sliger", new Vector2(360, 300) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Zach          Sliger", new Vector2(360, 300), MainTextColor);
            spriteBatch.DrawString(Noodle32, "Shaun          Bolan", new Vector2(360, 350) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Shawn          Bolan", new Vector2(360, 350), MainTextColor);
            spriteBatch.DrawString(Noodle32, "Eric          Salberg", new Vector2(360, 400) + new Vector2(2, 1), MainTextShadow);
            spriteBatch.DrawString(Noodle32, "Eric          Salberg", new Vector2(360, 400), MainTextColor);
        }

        public void Update()
        {
            if (cursorCooldown > 0)
                cursorCooldown--;
        }
        
    }
}
