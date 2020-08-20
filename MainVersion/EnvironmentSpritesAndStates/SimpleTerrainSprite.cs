using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NotSonicGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class SimpleTerrainSprite : ISprite
    {
        private Texture2D terrainSpriteSheet;
        private Rectangle terrainRectangle;
        private Rectangle destRectangle;

        public SimpleTerrainSprite(Vector2 position)
        {
            terrainSpriteSheet = AssetStorage.TerrainSpriteSheet;
            terrainRectangle = BlockUtility.SimpleTerrainRectangle;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, terrainRectangle.Width, terrainRectangle.Height);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(terrainSpriteSheet, destRectangle, terrainRectangle, Color.White);
        }

        public Rectangle BoundingBox() { return destRectangle; }
    }
}
