using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.Directions;

namespace NotSonicGame
{
    class NonMovingWoodenPlatformState : IPlatformState
    {
        private WoodenPlatform platform;
        private IPlatformSprite sprite;
        private Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public NonMovingWoodenPlatformState(WoodenPlatform platform)
        {
            this.platform = platform;
            this.position = platform.Position;
            sprite = new WoodenPlatformSprite(position);
        }
        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
        public void Update()
        {
            sprite.Update();
        }
        public void SetDirection(Direction direction)
        {
            platform.SetDirection(direction);
        }
    }
}
