using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class InvincibleSprite : ISprite
    {
        private Texture2D itemSpriteSheet;
        private Rectangle destRectangle;
        private Rectangle invincibleRectangle;
        private Rectangle[] invincibiltyFrames = ItemUtility.GetInvincibiltyFrames();
        private ISonic sonic;

        private List<Rectangle> destinationRectangleFrames = new List<Rectangle>();
        private List<Rectangle> invincibleRectagleFrames = new List<Rectangle>();

        private int currentFrame = 0;
        private int maxFrames = ItemUtility.InvincibilityMaxFrames;

        public InvincibleSprite(ISonic sonic)
        {
            itemSpriteSheet = AssetStorage.ItemObjectSpriteSheet;
            invincibleRectangle = invincibiltyFrames[0];
            destRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y + ItemUtility.PositionOffset, invincibleRectangle.Width, invincibleRectangle.Height);
            this.sonic = sonic;
        }

        public void Update()
        {
            destRectangle = new Rectangle((int)sonic.Position.X, (int)sonic.Position.Y + ItemUtility.PositionOffset, invincibleRectangle.Width, invincibleRectangle.Height);

            if (currentFrame == maxFrames)
            {
                currentFrame = 0;
                invincibleRectangle = invincibiltyFrames[3];
                invincibleRectagleFrames.Add(invincibleRectangle);
                destinationRectangleFrames.Add(destRectangle);
            }
            else
                currentFrame++;

            if (currentFrame == maxFrames - maxFrames / ItemUtility.InvincibiltyListLimit)
            {
                invincibleRectangle = invincibiltyFrames[0];
                invincibleRectagleFrames.Add(invincibleRectangle);
                destinationRectangleFrames.Add(destRectangle);
            }
            else if (currentFrame == maxFrames - maxFrames * 2 / ItemUtility.InvincibiltyListLimit)
            {
                invincibleRectangle = invincibiltyFrames[1];
                invincibleRectagleFrames.Add(invincibleRectangle);
                destinationRectangleFrames.Add(destRectangle);
            }
            else if (currentFrame == maxFrames - maxFrames * 3 / ItemUtility.InvincibiltyListLimit)
            {
                invincibleRectangle = invincibiltyFrames[2];
                invincibleRectagleFrames.Add(invincibleRectangle);
                destinationRectangleFrames.Add(destRectangle);
            }

            if (invincibleRectagleFrames.Count == ItemUtility.InvincibiltyListLimit)
            {
                invincibleRectagleFrames.RemoveAt(0);
                destinationRectangleFrames.RemoveAt(0);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < invincibleRectagleFrames.Count; i++)
                spriteBatch.Draw(itemSpriteSheet, destinationRectangleFrames[i], invincibleRectagleFrames[i], Color.White);
        }

        public Rectangle BoundingBox() { return new Rectangle(); }
    }
}