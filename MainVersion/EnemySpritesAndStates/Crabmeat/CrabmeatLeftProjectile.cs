using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using static NotSonicGame.EnemyUtility;

namespace NotSonicGame
{
    class CrabmeatLeftProjectile : IProjectile
    {
        private IEnemySprite sprite;
        private Vector2 position;
        private int updateDelayCounter;
        private Vector2 parabolicVectex;
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
        public CrabmeatLeftProjectile(Vector2 position)
        {
            parabolicVectex = new Vector2(position.X - LeftProjectileArcOffSetX, position.Y - LeftProjectileArcOffSetY);
            this.position = new Vector2(position.X, (float)(ProjectileArcFactor * Math.Pow(position.X - parabolicVectex.X, TWO) + parabolicVectex.Y));
            sprite = new RedProjectileSprite();
        }

        public Rectangle BoundingBox()
        {
            return sprite.BoundingBox();
        }
        public void Update()
        {
            updateDelayCounter++;
            if (updateDelayCounter == DelayCountMax)
                updateDelayCounter = DelayCountStartValue;
            if (updateDelayCounter % DelayTimeFive == ZERO)
            {
                position.X--;
                position.Y = (float)(ProjectileArcFactor * Math.Pow(position.X - parabolicVectex.X, TWO) + parabolicVectex.Y);
            }
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
