using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class ShieldSprite : ISprite
    {
        private Texture2D itemSpriteSheet;
        private Rectangle destRectangle;
        private Rectangle shieldRectangle;
        private Rectangle[] shieldFrames = ItemUtility.GetShieldFrames();
        private ISonic sonic;

        private int currentFrame = 0;
        private int maxFrames = ItemUtility.ShieldMaxFrames;

        public ShieldSprite(ISonic sonic)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            shieldRectangle = shieldFrames[0];
            destRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y + ItemUtility.PositionOffset, shieldRectangle.Width, shieldRectangle.Height);
            this.sonic = sonic;
        }

        public void Update()
        {
            if (currentFrame == maxFrames * ItemUtility.GeneralItemFrameThreeMultiplier)
                currentFrame = 0;
            else
                currentFrame++;

            if (currentFrame < maxFrames * ItemUtility.GeneralItemFrameOneMultiplier)
                shieldRectangle = shieldFrames[0];
            else if (currentFrame < maxFrames * ItemUtility.GeneralItemFrameTwoMultiplier)
                shieldRectangle = shieldFrames[1];
            else
                shieldRectangle = shieldFrames[2];

            destRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y + ItemUtility.PositionOffset, shieldRectangle.Width, shieldRectangle.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(itemSpriteSheet, destRectangle, shieldRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return new Rectangle(); }
    }
}
