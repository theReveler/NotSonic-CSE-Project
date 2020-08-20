using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class PowerSneakersItem : IItem
    {
        private ISprite powerSneakersSprite;
        private Vector2 position;
        private bool isPickedUp = false;

        private int currentFrames = 0;
        private int maxFrame = ItemUtility.GeneralMaxFrames;

        public PowerSneakersItem(Vector2 position)
        {
            this.position = position;
            powerSneakersSprite = new PowerSneakersItemSprite(position);
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

                powerSneakersSprite = new PowerSneakersItemSprite(position);
            }
            powerSneakersSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrames != maxFrame)
                powerSneakersSprite.Draw(spriteBatch);
        }

        public void GetPickedUp()
        {
            isPickedUp = true;
            ISonic sonic = (ISonic)Game1.PlayState.FindSonic();
            sonic.GetPowerSneaker();
        }



        public Rectangle BoundingBox() { return powerSneakersSprite.BoundingBox(); }
    }
}
