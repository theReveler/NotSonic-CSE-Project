using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    class DeadBuzzBomberSprite : ISprite
    {
        private ISprite explosionSprite;
        private ISprite animalSprite;

        public DeadBuzzBomberSprite(Vector2 position)
        {
            explosionSprite = new ExplosionSprite(position);
            animalSprite = new ChickenSprite(position);
        }
        public Rectangle BoundingBox()
        {
            return new Rectangle();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            animalSprite.Draw(spriteBatch);
            explosionSprite.Draw(spriteBatch);
        }

        public void Update()
        {
            animalSprite.Update();
            explosionSprite.Update();
        }
    }
}
