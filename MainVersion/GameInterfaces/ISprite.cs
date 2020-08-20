using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace NotSonicGame
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
        Rectangle BoundingBox();
    }
}