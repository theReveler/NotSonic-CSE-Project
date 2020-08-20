using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class CannonRightProjectile : IProjectile
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
        public CannonRightProjectile(Vector2 position)
        {
            this.position = position;
            sprite = new RedProjectileSprite();
        }

        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }
        public void Update()
        {
            position.X++;
            sprite.Update();
            if (position.X > ProjectileRemoveRightDistance)
                Game1.PlayState.RemoveFromGameList(this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }
    }
}
