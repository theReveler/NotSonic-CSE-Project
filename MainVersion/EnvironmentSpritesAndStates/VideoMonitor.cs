using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class VideoMonitor : IBlock
    {
        private ISprite videoMonitorSprite;
        private IItem item;
        private Vector2 position;
        private bool isDestroyed = false;

        private int currentFrame = 0;
        private int maxFrames = BlockUtility.VideoMontiorItemMaxFrames;

        public bool IsDestroyed
        {
            get
            {
                return isDestroyed;
            }
        } 

        public VideoMonitor(int itemNum, Vector2 position)
        {
            this.position = position;
            videoMonitorSprite = new VideoMonitorSprite(position);

            if (itemNum == 1)
                item = new SuperRingItem(new Vector2(position.X + BlockUtility.ItemXOffset, position.Y + BlockUtility.ItemYOffset));
            else if (itemNum == 2)
                item = new InvincibleItem(new Vector2(position.X + BlockUtility.ItemXOffset, position.Y + BlockUtility.ItemYOffset));
            else if (itemNum == 3)
                item = new ShieldItem(new Vector2(position.X + BlockUtility.ItemXOffset, position.Y + BlockUtility.ItemYOffset));
            else if (itemNum == 4)
                item = new PowerSneakersItem(new Vector2(position.X + BlockUtility.ItemXOffset, position.Y + BlockUtility.ItemYOffset));
            else
                item = new OneUpItem(new Vector2(position.X + BlockUtility.ItemXOffset, position.Y + BlockUtility.ItemYOffset));
        }

        public void Update()
        {
            if (currentFrame != maxFrames)
                currentFrame++;
            else
                currentFrame = 0;

            videoMonitorSprite.Update();
            item.Update();
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            videoMonitorSprite.Draw(spriteBatch);
            if (videoMonitorSprite is VideoMonitorSprite && currentFrame < maxFrames * BlockUtility.GeneralBlockFrameTwoMultiplier)
                item.Draw(spriteBatch);
            else if (videoMonitorSprite is DestroyedVideoMonitorSprite)
                item.Draw(spriteBatch);
        }

        public void Interact()
        {
            if (!isDestroyed)
            {
                videoMonitorSprite = new DestroyedVideoMonitorSprite(position);
                item.GetPickedUp();
                isDestroyed = true;
                AssetStorage.BounceOffEnemeySoundEffect.Play();
            }
        }

        public Rectangle BoundingBox() { return videoMonitorSprite.BoundingBox(); }
    }
}
