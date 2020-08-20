using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class OneUpItem : IItem
    {
        private ISprite oneUpSprite;
        private Vector2 position;
        private bool isPickedUp = false;

        private int currentFrames = 0;
        private int maxFrame = ItemUtility.GeneralMaxFrames;

        public OneUpItem(Vector2 position)
        {
            this.position = position;
            oneUpSprite = new OneUpItemSprite(position);
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

                oneUpSprite = new OneUpItemSprite(position);
            }
            oneUpSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentFrames != maxFrame)
                oneUpSprite.Draw(spriteBatch);
        }

        public void GetPickedUp()
        {
            isPickedUp = true;
            HUD.Lives++;
            AssetStorage.OneUpSoundEffect.Play();
        } 

        public Rectangle BoundingBox() { return oneUpSprite.BoundingBox(); }
    }
}
