using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.Game1;
using static NotSonicGame.AssetStorage;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    class EndState : IGameState
    {  
        private gameState gameState;
        public gameState GameState { get { return gameState; } }
        public int timeout = 150;

        public EndState()
        {
            gameState = gameState.end;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            Rectangle sourceRectangle = new Rectangle(0, 0, 1527, 1070);
            Rectangle destinationRectangle = new Rectangle(0, 0, 750, 525); ;
            spriteBatch.Draw(MainMenuSplash, destinationRectangle, sourceRectangle, new Color(0, 0, 0, 100));
            spriteBatch.DrawString(Noodle32, "Level          Complete", new Vector2(280, 230) + new Vector2(2, 1), Color.DarkCyan);
            spriteBatch.DrawString(Noodle32, "Level          Complete", new Vector2(280, 230), Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            if (timeout > 0)
                timeout--;
        }
    }
}
