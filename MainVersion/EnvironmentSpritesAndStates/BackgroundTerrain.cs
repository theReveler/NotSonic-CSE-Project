﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSonicGame.EnvironmentSpritesAndStates
{
    class BackgroundTerrain : IBlock, IGameObject
    {
        private ISprite terrainSprite;

        public BackgroundTerrain(Vector2 position)
        {
            terrainSprite = new SimpleTerrainSprite(position);
        }

        public void Update() { terrainSprite.Update(); }

        public void Draw(SpriteBatch spriteBatch) { terrainSprite.Draw(spriteBatch); }

        public void Interact() { }

        public Rectangle BoundingBox() { return terrainSprite.BoundingBox(); }
    }
}
