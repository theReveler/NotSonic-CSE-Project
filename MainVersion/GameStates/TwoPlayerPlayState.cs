using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using static NotSonicGame.Game1;
using Microsoft.Xna.Framework;
using static NotSonicGame.GameUtility;
using Microsoft.Xna.Framework.Media;

namespace NotSonicGame
{
    public class TwoPlayerPlayState : IGameState
    {
        private gameState gameState;
        private HUD hud1;
        private HUD hud2;
        private ISonic sonic1;
        private ISonic sonic2;

        private GraphicsDevice graphicsDevice;
        private static List<IGameObject> gameObjectList;
        private OnePlayerLevel onePlayerLevel;
        Camera camera1 = new Camera();
        Camera camera2 = new Camera();
        private Viewport topViewport;
        private Viewport bottomViewport;

        CollisionDetector collisionDetector;
        

        public Camera Camera1 { get { return camera1; } }
        public Camera Camera2 { get { return camera2; } }

        public gameState GameState { get { return gameState; } }
        public ISonic Sonic1 { get { return sonic1; } }
        public ISonic Sonic2 { get { return sonic2; } }

        public TwoPlayerPlayState(GraphicsDevice graphicsDevice, CollisionDetector collisionDetector)
        {
            gameState = gameState.play;
            this.graphicsDevice = graphicsDevice;
            this.collisionDetector = collisionDetector;
            LoadLevel();

            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, transformMatrix: camera1.Transform);
            foreach (IGameObject gameObject in gameObjectList)
            {
                gameObject.Draw(spriteBatch);
            }
            hud1.Draw(spriteBatch);
            spriteBatch.End();

            //Drawing in separate windows

            //Viewport original = GraphicsDevice.Viewport;
            //GraphicsDevice.Viewport = topViewport;

            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            //spriteBatch.DrawString(AssetStorage.MainFont, "lol", new Vector2(20, 35), Color.White);
            //spriteBatch.End();
            //GraphicsDevice.Viewport = original;
        }
        public void Update()
        {
            camera1.Update((Sonic)sonic1);
            camera2.Update((Sonic)sonic2);

            collisionDetector.Update(gameObjectList);

            var gameObjectArray = gameObjectList.ToArray();
            foreach (IGameObject gameObject in gameObjectArray)
            {
                gameObject.Update();
            }
            hud1.Update();
        }
        public static void RemoveFromGameList(IGameObject gameObject)
        {
            gameObjectList.Remove(gameObject);
        }

        public static void AddToGameList(IGameObject gameObject)
        {
            gameObjectList.Add(gameObject);
        }
        public static IGameObject FindSonic()
        {
            foreach (IGameObject gameObject in gameObjectList)
            {
                if (gameObject is ISonic)
                    return gameObject;
            }
            return null;
        }
        public void LoadLevel()
        {
           // var twoPlayerLevelLoader = new TwoPlayerLevelLoader();
           // twoPlayerLevel = twoPlayerLevelLoader.LoadTwoPlayerLevel();
            sonic1 = new Sonic(SonicStartingPosition);
            sonic2 = new Sonic(SonicStartingPosition);
           // gameObjectList = twoPlayerLevel.returnObjectList();
            AddToGameList(sonic1);
            AddToGameList(sonic2);
        // Need a background for each player
           // Background main1 = twoPlayerLevel.returnBackground();
            //main1.ConnectCamera(camera1);
            //main2.ConnectCamera(camera2);
            hud1 = new HUD(camera1, this);
            hud2 = new HUD(camera2, this);

            topViewport = new Viewport();
            topViewport.X = 0;
            topViewport.Y = 0;
            topViewport.Width = 400;
            topViewport.Height = 240;
            topViewport.MinDepth = 0;
            topViewport.MaxDepth = 1;
        }
    }
}
