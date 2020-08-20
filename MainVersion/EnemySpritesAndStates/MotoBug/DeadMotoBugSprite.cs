using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace NotSonicGame
{
    class DeadMotoBugSprite : IEnemySprite
    {
        private ISprite explosionSprite;
        private ISprite animalSprite;

        public DeadMotoBugSprite(Vector2 position)
        {
            explosionSprite = new ExplosionSprite(position);
            animalSprite = new BlueJaySprite(position);
        }
        public Rectangle BoundingBox()
        {
            return new Rectangle();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 positon)
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
