using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class SuperRingItem :IItem
    {
        private ISprite superRingSprite;
        private Vector2 position;
        private bool isPickedUp = false;

        private int currentFrames = 0;
        private int maxFrame = ItemUtility.GeneralMaxFrames;

        public SuperRingItem(Vector2 position)
        {
            this.position = position;
            superRingSprite = new SuperRingItemSprite(position);
        }

        public void Update()
        {
            if (isPickedUp)
            {
                if (currentFrames < maxFrame * ItemUtility.GeneralItemFrameTwoMultiplier)
                {
                    position.Y--;
                    currentFrames++;
                }
                else if (currentFrames != maxFrame)
                    currentFrames++;

                superRingSprite = new SuperRingItemSprite(position);
            }

            superRingSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrames != maxFrame)
                superRingSprite.Draw(spriteBatch);
        }

        public void GetPickedUp()
        {
            isPickedUp = true;
            HUD.Rings += ItemUtility.SuperRings;
            AssetStorage.PickUpRingSoundEffect.Play();
        } 

        public Rectangle BoundingBox() { return superRingSprite.BoundingBox(); }
    }
}
