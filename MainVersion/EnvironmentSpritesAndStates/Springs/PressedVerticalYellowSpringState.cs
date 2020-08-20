using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class PressedVerticalYellowSpringState : ISpringState
    {
        private Spring spring;
        private ISprite springSprite;
        private Vector2 position;

        private int currentFrame = 0;
        private int maxFrames = BlockUtility.SpringMaxFrames;

        public PressedVerticalYellowSpringState(Spring spring, Vector2 position)
        {
            this.spring = spring;
            this.position = position;
            springSprite = new PressedVerticalYellowSpringSprite(position);
        }

        public void BePressed() { }

        public void Update()
        {
            if (currentFrame == maxFrames)
                spring.state = new UnpressedVerticalYellowSpringState(spring, position);
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
