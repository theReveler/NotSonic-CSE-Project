using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class UndergroundBlock : IBlock, IGameObject
    {
        private ISprite undergroundBlockSprite;

        public UndergroundBlock(Vector2 position)
        {
            undergroundBlockSprite = new UndergroundBlockSprite(position);
        }

        public void Update() { undergroundBlockSprite.Update(); }

        public void Draw(SpriteBatch spriteBatch) {undergroundBlockSprite.Draw(spriteBatch); }

        public void Interact() { }

        public Rectangle BoundingBox() { return undergroundBlockSprite.BoundingBox(); }
    }
}