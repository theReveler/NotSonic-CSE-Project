using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame
{
    class AdvanceTerrainSprite : ISprite
    {
        private Texture2D terrainSpriteSheet;
        private Rectangle destRectangle;
        private Rectangle terrainRectangle;

        public AdvanceTerrainSprite(Vector2 position)
        {
            terrainSpriteSheet = Texture2DStorage.TerrainSpriteSheet;
            destRectangle = new Rectangle((int)position.X, (int)position.Y, 128, 68);
            terrainRectangle = new Rectangle(0, 0, 128, 68);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            spriteBatch.Draw(terrainSpriteSheet, destRectangle, terrainRectangle, Color.White);
            //spriteBatch.End();
        }

        public Rectangle BoundingBox() { return destRectangle; }
    }
}
