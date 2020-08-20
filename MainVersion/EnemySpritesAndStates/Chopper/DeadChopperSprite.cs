using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    class DeadChopperSprite : ISprite
    {
        private ISprite explosionSprite;
        private ISprite animalSprite;
        

        public DeadChopperSprite(Vector2 position)
        {
            explosionSprite = new ExplosionSprite(position);
            animalSprite = new SealSprite(position);
        }
        public Rectangle BoundingBox()
        {
            return new Rectangle();
        }
        public void Update()
        {
            animalSprite.Update();
            explosionSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animalSprite.Draw(spriteBatch);
            explosionSprite.Draw(spriteBatch);
        }
    }
}
