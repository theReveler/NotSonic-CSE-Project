using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class DroppedRing : IRing
    {
        public ISprite ringSprite;
        private float fallingCapVelocity = ItemUtility.FallingCapacityVelocity;
        private int counter = ItemUtility.DroppedRingCounter;

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public int TimeUp { get { return counter; } }

        public DroppedRing(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
            ringSprite = new RingSprite(this);
        }

        public void Update()
        {
            if(counter == 0)
            {
                Game1.PlayState.RemoveFromGameList(this);
            }

            counter--;
            Position += Velocity;
            if (Velocity.Y <= fallingCapVelocity)
            {
                Velocity = new Vector2(Velocity.X * ItemUtility.DroppedRingAccelerationX, Velocity.Y + ItemUtility.DroppedRingAccelerationY);
            }
            ringSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (counter > 0)
                ringSprite.Draw(spriteBatch);
        }

        public void GetPickedUp()
        {
            ringSprite = new PickedUpRingSprite(Position);
            HUD.Rings++;
        }

        public Rectangle BoundingBox() { return ringSprite.BoundingBox(); }
    }
}
