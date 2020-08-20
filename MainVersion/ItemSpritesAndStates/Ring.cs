using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class Ring : IRing
    {
        private ISprite ringSprite;
        private int counter = 0;
        private bool IsPickedUp = false;
        public Vector2 Position { get; set; }

        public Ring(Vector2 position)
        {
            Position = position;
            ringSprite = new RingSprite(this);
        }

        public void Update()
        {
            ringSprite.Update();
            if (IsPickedUp && counter == 0)
                Game1.PlayState.RemoveFromGameList(this);
        }

        public void Draw(SpriteBatch spriteBatch) { ringSprite.Draw(spriteBatch); }

        public void GetPickedUp()
        {
            ringSprite = new PickedUpRingSprite(Position);//Add to sonic's ring counter.
            HUD.Rings++;
            counter = ItemUtility.GeneralMaxFrames;
            IsPickedUp = true;
        }

        public Rectangle BoundingBox() { return ringSprite.BoundingBox(); }
    }
}
