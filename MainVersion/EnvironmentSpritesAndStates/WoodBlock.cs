using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    class WoodBlock : IBlock , IGameObject
    {
        private ISprite woodBlockSprite;

        public WoodBlock(Vector2 position)
        {
            woodBlockSprite = new WoodBlockSprite(position);
        }

        public void Update() { woodBlockSprite.Update(); }

        public void Draw(SpriteBatch spriteBatch) { woodBlockSprite.Draw(spriteBatch); }

        public void Interact() { }

        public Rectangle BoundingBox() { return woodBlockSprite.BoundingBox(); }
    }
}
