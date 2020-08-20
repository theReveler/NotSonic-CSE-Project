using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class EndRing : IItem
    {
        private ISprite endRingSprite;
        private Vector2 position;
        private int counter = 0;
        private bool isPickedUp = false;

        public EndRing(Vector2 position)
        {
            this.position = position;
            endRingSprite = new EndRingSprite(position);
        }

        public void Update()
        {
            endRingSprite.Update();
            if (isPickedUp && counter == 0)
                counter = 0;//InputActions.EndGame();
            else if (counter > 0)
                counter--;
        }

        public void Draw(SpriteBatch spriteBatch) { endRingSprite.Draw(spriteBatch); }

        public void GetPickedUp()
        {
            endRingSprite = new PickedUpEndRingSprite(position);
            isPickedUp = true;
            ScoreControl.GetEndRing(position);
            counter = ItemUtility.GeneralMaxFrames;
        }

        public Rectangle BoundingBox() { return endRingSprite.BoundingBox(); }
    }
}
