using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    public class BuzzBomberLeftProjectile : IProjectile
    {
        private IEnemySprite sprite;
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
        public BuzzBomberLeftProjectile(Vector2 position)
        {
            this.position = position;
            sprite = new YellowProjectileSprite();
        }

        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }
        public void Update()
        {
            position.X--;
            position.Y++;
            sprite.Update();
            if (position.Y > ProjectileRemoveHeight)
                Game1.PlayState.RemoveFromGameList(this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }
    }
}
