using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class Spike : ISpike
    {
        private ISprite spikeSprite;
        public bool IsHorizontal { get; set; }

        public Spike(Vector2 position, bool isHorizontal)
        {
            IsHorizontal = isHorizontal;
            if (isHorizontal)
                spikeSprite = new HorizontalSpikeSprite(position);
            else
                spikeSprite = new VerticalSpikeSprite(position);
        }

        public void Update() { spikeSprite.Update(); }

        public void Draw(SpriteBatch spriteBatch) { spikeSprite.Draw(spriteBatch); }

        //Collision handles the interaction.
        public void Interact() { throw new NotImplementedException(); }

        public Rectangle BoundingBox() { return spikeSprite.BoundingBox(); }
    }
}
