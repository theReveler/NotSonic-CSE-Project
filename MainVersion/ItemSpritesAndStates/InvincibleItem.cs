using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class InvincibleItem : IItem
    {
        private ISprite invincibleItemSprite;
        private Vector2 position;
        private bool isPickedUp = false;

        private int currentFrames = 0;
        private int maxFrame = ItemUtility.GeneralMaxFrames;

        public InvincibleItem(Vector2 position)
        {
            this.position = position;
            invincibleItemSprite = new InvincibleItemSprite(position);
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

                invincibleItemSprite = new InvincibleItemSprite(position);
            }
            invincibleItemSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrames != maxFrame)
                invincibleItemSprite.Draw(spriteBatch);
        }

        public void GetPickedUp()
        {
            isPickedUp = true;
            ISonic sonic = (ISonic)Game1.PlayState.FindSonic();
            sonic.GetInvincible();
        }


        public Rectangle BoundingBox() { return invincibleItemSprite.BoundingBox(); }
    }
}
