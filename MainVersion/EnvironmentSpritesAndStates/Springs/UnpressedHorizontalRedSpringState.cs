using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class UnpressedHorizontalRedSpringState : ISpringState
    {
        private Spring spring;
        private ISprite springSprite;
        private Vector2 position;

        public UnpressedHorizontalRedSpringState(Spring spring, Vector2 position)
        {
            this.spring = spring;
            this.position = position;
            springSprite = new UnpressedHorizontalRedSpringSprite(position);
        }

        public void BePressed() { spring.state = new PressedHorizontalRedSpringState(spring, position); }

        public void Update() { } //Nothing to update this state

        public void Draw(SpriteBatch spriteBatch) { springSprite.Draw(spriteBatch); }

        public Rectangle BoundingBox() { return springSprite.BoundingBox(); }
    }
}
