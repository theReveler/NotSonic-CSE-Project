using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NotSonicGame.Game1;

namespace NotSonicGame
{
    public interface IGameState
    {
        gameState GameState { get; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
