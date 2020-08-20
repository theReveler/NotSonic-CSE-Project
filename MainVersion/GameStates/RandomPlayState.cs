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
    public class RandomPlayState : IPlayState
    {
        private gameState gameState;
        private HUD hud;
        private ISonic sonic;
        private GraphicsDevice graphicsDevice;
        private static List<IGameObject> gameObjectList;

        //make new level + level loader
        private RandomLevel randomLevel;


        private Camera camera = new Camera();
        private CollisionDetector collisionDetector = new CollisionDetector();
        private ScoreControl scoreControl = new ScoreControl();

        public Camera Camera { get { return camera; } }
        public gameState GameState { get { return gameState; } }
        public ISonic Sonic { get { return sonic; } }

        public RandomPlayState(GraphicsDevice graphicsDevice)
        {
            gameState = gameState.play;
            this.graphicsDevice = graphicsDevice;
            LoadLevel();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, transformMatrix: camera.Transform);
            foreach (IGameObject gameObject in gameObjectList)
            {
                gameObject.Draw(spriteBatch);
            }
            hud.Draw(spriteBatch);
            scoreControl.Draw(spriteBatch);
            spriteBatch.End();
        }
        public void Update()
        {
            camera.Update((Sonic)sonic);
            collisionDetector.Update(gameObjectList);

            var gameObjectArray = gameObjectList.ToArray();
            foreach (IGameObject gameObject in gameObjectArray)
            {
                gameObject.Update();
            }
            hud.Update();
            scoreControl.Update();

        }
        public void RemoveFromGameList(IGameObject gameObject)
        {
            gameObjectList.Remove(gameObject);
        }

        public void AddToGameList(IGameObject gameObject)
        {
            gameObjectList.Add(gameObject);
        }
        public IGameObject FindSonic()
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
            //new level
            var RandomLevelLoader = new RandomLevelLoader();
            randomLevel = RandomLevelLoader.LoadOnePlayerLevel();



            sonic = new Sonic(SonicStartingPosition); //Random Start is typed up in GameUtility
            gameObjectList = randomLevel.returnObjectList();
            AddToGameList(sonic);
            Background main = randomLevel.returnBackground();
            main.ConnectCamera(camera);
            hud = new HUD(camera, this);
        }
    }
}
