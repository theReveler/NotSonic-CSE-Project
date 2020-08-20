using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class PressedHorizontalRedSpringState : ISpringState
    {
        private Spring spring;
        private ISprite springSprite;
        private Vector2 position;

        private int currentFrame = 0;
        private int maxFrames = BlockUtility.SpringMaxFrames;

        public PressedHorizontalRedSpringState(Spring spring, Vector2 position)
        {
            this.spring = spring;
            this.position = position;
            springSprite = new PressedHorizontalRedSpringSprite(position);
        }

        public void BePressed() { }

        public void Update()
        {
            if (currentFrame == maxFrames)
                spring.state = new UnpressedHorizontalRedSpringState(spring, position);
            else
            {
                springSprite.Update();
                currentFrame++;
            }
        }

        public void Draw(SpriteBatch spriteBatch) { springSprite.Draw(spriteBatch); }

        public Rectangle BoundingBox() { return springSprite.BoundingBox(); }
    }
}
