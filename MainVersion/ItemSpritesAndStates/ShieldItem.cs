using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class ShieldItem : IItem
    {
        private ISprite shieldItemSprite;
        private Vector2 position;
        private bool isPickedUp = false;

        private int currentFrames = 0;
        private int maxFrame = ItemUtility.GeneralMaxFrames;

        public ShieldItem(Vector2 position)
        {
            this.position = position;
            shieldItemSprite = new ShieldItemSprite(position);
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
                else if(currentFrames != maxFrame)
                    currentFrames++;

                shieldItemSprite = new ShieldItemSprite(position);
            }
            shieldItemSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(currentFrames!= maxFrame)
                shieldItemSprite.Draw(spriteBatch);
        }

        public void GetPickedUp()
        {
            isPickedUp = true;
            ISonic sonic = (ISonic)Game1.PlayState.FindSonic();
            sonic.GetShield();
        }


        public Rectangle BoundingBox() { return shieldItemSprite.BoundingBox(); }
    }
}
